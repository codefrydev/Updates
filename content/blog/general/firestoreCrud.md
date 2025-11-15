---
title: "Firestore Crud Operations"
author: "PrashantUnity"
weight: 210
date: 2025-11-15
lastmod: 2025-11-15
dateString: November 2024  
description: "Firestore Crud Operations in .NET Applications for dynamic data type. for any type of data."
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "NET", "codefrydev", "C sharp", "CFD", "Firestore","Firebase","Google","CRUD","Crud"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD", "Firestore","Firebase","Google","CRUD","Crud"]
---

## Overview

Firestore is a flexible, scalable database for mobile, web, and server development from Firebase and Google Cloud Platform. It is a NoSQL document database that lets you easily store, sync, and query data for your applications at a global scale.

In this guide, we'll walk through how to implement a complete CRUD (Create, Read, Update, Delete) solution for Firestore in .NET with built-in schema validation and type conversion support.

## Firestore CRUD Operations in .NET

To perform CRUD (Create, Read, Update, Delete) operations in Firestore using .NET, you can use the Google.Cloud.Firestore NuGet package. Below is a complete example demonstrating how to perform these operations with full schema management and validation.

### Setup

First, you need to add the required NuGet packages to your project. These packages provide the necessary functionality to interact with Firestore and Firebase Authentication.

```cs
#r "nuget: Google.Cloud.Firestore, 3.12.0"
#r "nuget: FirebaseAdmin, 3.4.0"
```

### Import Namespaces

Now we import all the necessary namespaces. These enable us to work with collections, async operations, JSON serialization, and Firestore-specific types.

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Google.Api.Gax;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using System.IO;
```

### Model Class

We define model classes that represent the schema structure for our Firestore collections. These classes help us enforce type safety and validation for the data we store.

- **MasterSchema**: A container that holds the schema definitions for multiple collections
- **CollectionSchema**: Defines the structure of a single collection with its properties
- **PropertySchema**: Describes individual properties, including their data types and any references to other collections

```cs
public class MasterSchema
{
    [JsonPropertyName("Master")]
    public Dictionary<string, CollectionSchema> Master { get; set; } = new();
}

public class CollectionSchema
{
    [JsonPropertyName("Name")]
    public string Name { get; set; }

    [JsonPropertyName("Properties")]
    public Dictionary<string, PropertySchema> Properties { get; set; } = new();
}

public class PropertySchema
{
    [JsonPropertyName("Type")]
    public string Type { get; set; } // e.g., "String", "Number", "Boolean", "Reference", "Map", "Array", "Timestamp"

    [JsonPropertyName("Collection")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Collection { get; set; }
}
```

### Firestore CRUD Operations Interface

This interface defines the contract for all CRUD operations we support. It includes:

- **Schema Management**: Methods to create, read, and update schema definitions
- **Create**: `AddAsync` - Add new documents to a collection
- **Read**: `GetByDocumentIdAsync` and `GetCollectionAsync` - Retrieve documents with optional pagination and sorting
- **Update**: `UpdateByDocumentIdAsync` - Modify existing documents
- **Delete**: `DeleteByDocumentIdAsync` - Remove documents from collections

```cs

public interface IFirestoreCrud
{
    Task<Dictionary<string, MasterSchema>> GetMasterSchemaAsync(string collectionName);
    Task<string> CreateMasterSchemaTypeByCollectionNameIfNotExistAsync(string collectionName, Dictionary<string, CollectionSchema> masterSchema);
    Task<string> UpdateMasterSchemaTypeByCollectionNameAsync(string collectionName, Dictionary<string, CollectionSchema> masterSchema);

    Task<string> AddAsync(string collectionName, Dictionary<string, object> data);
    Task<Dictionary<string, object>> GetByDocumentIdAsync(string collectionName, string documentId);
    Task<Dictionary<string, object>> GetCollectionAsync(string collectionName);
    Task<Dictionary<string, Dictionary<string, object>>> GetCollectionAsync(string collectionName, int limit = 15, string pageToken = null, string orderBy = null, bool descending = false, string startAfterDocumentId = null);
    Task<string> UpdateByDocumentIdAsync(string collectionName, string documentId, Dictionary<string, object> data);
    Task<string> DeleteByDocumentIdAsync(string collectionName, string documentId);
}
```

### Firestore CRUD Operations Implementation

This is the core implementation class that handles all CRUD operations. It works with Firestore's document structure and provides automatic type conversion, validation, and reference resolution.

#### Key Features

- **Schema Caching**: Stores schema definitions in a special "MasterSchema" collection for reuse
- **Type Validation**: Ensures data matches the defined schema types before writing to Firestore
- **Type Conversion**: Automatically converts between .NET types and Firestore's native types (Timestamps, DocumentReferences, etc.)
- **Pagination Support**: Allows efficient browsing of large collections with sorting and pagination
- **Reference Management**: Intelligently handles document references between collections

```cs

public class FirestoreCrud : IFirestoreCrud
{
    private readonly FirestoreDb _db;
    private const string MasterSchemaCollection = "MasterSchema";
    private readonly TimeSpan _schemaCacheTtl = TimeSpan.FromMinutes(5);

    public FirestoreCrud(FirestoreDb db)
    {
        _db = db ?? throw new ArgumentNullException(nameof(db));
    }

    #region Schema Management & Caching

    /// <summary>
    /// Returns master schema(s). If collectionName is null/empty or "*" fetches all schema documents.
    /// Otherwise returns a dictionary with a single entry for the requested collection (if exists).
    /// This method retrieves schema definitions from the MasterSchema collection in Firestore.
    /// </summary>
    public async Task<Dictionary<string, MasterSchema>> GetMasterSchemaAsync(string collectionName)
    {
        try
        {

            var result = new Dictionary<string, MasterSchema>(StringComparer.OrdinalIgnoreCase);

            QuerySnapshot snapshot = await _db.Collection(MasterSchemaCollection).GetSnapshotAsync();
            foreach (var doc in snapshot.Documents)
            {
                var collectionSchema = new CollectionSchema
                {
                    Name = doc.Id,
                    Properties = new Dictionary<string, PropertySchema>(StringComparer.OrdinalIgnoreCase)
                };

                var dict = doc.ToDictionary();
                if (dict.TryGetValue("Properties", out var propsObj) && propsObj is Dictionary<string, object> propsDict)
                {
                    foreach (var propEntry in propsDict)
                    {
                        if (propEntry.Value is Dictionary<string, object> propDetails)
                        {
                            var propSchema = new PropertySchema
                            {
                                Type = propDetails.ContainsKey("Type") ? propDetails["Type"] as string : null,
                                Collection = propDetails.ContainsKey("Collection") ? propDetails["Collection"] as string : null
                            };
                            collectionSchema.Properties[propEntry.Key] = propSchema;
                        }
                    }
                }

                var ms = new MasterSchema();
                ms.Master[doc.Id] = collectionSchema;
                result[doc.Id] = ms;
            }

            if (string.IsNullOrWhiteSpace(collectionName) || collectionName == "*") return result;
            return result.Where(kv => kv.Key.Equals(collectionName, StringComparison.OrdinalIgnoreCase))
                .ToDictionary(k => k.Key, k => k.Value);
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<string> CreateMasterSchemaTypeByCollectionNameIfNotExistAsync(string collectionName, Dictionary<string, CollectionSchema> masterSchema)
    {
        if (string.IsNullOrWhiteSpace(collectionName)) throw new ArgumentNullException(nameof(collectionName));
        try
        {
            var docRef = _db.Collection(MasterSchemaCollection).Document(collectionName);
            var snapshot = await docRef.GetSnapshotAsync();
            if (snapshot.Exists)
            {
                return collectionName;
            }

            // Convert to plain dictionary for Firestore
            var properties = masterSchema?.Values.FirstOrDefault()?.Properties ?? new Dictionary<string, PropertySchema>();
            var propsForFirestore = properties.ToDictionary(k => k.Key, k => (object)new Dictionary<string, object>
            {
                { "Type", k.Value.Type },
                { "Collection", k.Value.Collection }
            });

            var payload = new Dictionary<string, object>
            {
                {"Name", collectionName},
                {"Properties", propsForFirestore}
            };

            await docRef.SetAsync(payload);
            return collectionName;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<string> UpdateMasterSchemaTypeByCollectionNameAsync(string collectionName, Dictionary<string, CollectionSchema> masterSchema)
    {
        if (string.IsNullOrWhiteSpace(collectionName)) throw new ArgumentNullException(nameof(collectionName));
        try
        {
            var docRef = _db.Collection(MasterSchemaCollection).Document(collectionName);
            var snapshot = await docRef.GetSnapshotAsync();
            if (!snapshot.Exists)
            {
                return await CreateMasterSchemaTypeByCollectionNameIfNotExistAsync(collectionName, masterSchema);
            }

            var properties = masterSchema?.Values.FirstOrDefault()?.Properties ?? new Dictionary<string, PropertySchema>();
            var propsForFirestore = properties.ToDictionary(k => k.Key, k => (object)new Dictionary<string, object>
            {
                { "Type", k.Value.Type },
                { "Collection", k.Value.Collection }
            });

            var payload = new Dictionary<string, object>
            {
                {"Name", collectionName},
                {"Properties", propsForFirestore}
            };

            await docRef.SetAsync(payload, SetOptions.Overwrite);
            return collectionName;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    #endregion

    #region CRUD Methods

    /// <summary>
    /// CREATE: Adds a new document to a collection with automatic type conversion and validation.
    /// Returns the auto-generated document ID on success.
    /// </summary>
    public async Task<string> AddAsync(string collectionName, Dictionary<string, object> data)
    {
        if (string.IsNullOrWhiteSpace(collectionName)) throw new ArgumentNullException(nameof(collectionName));
        if (data == null) throw new ArgumentNullException(nameof(data));

        // validate and normalize
        if (!await ValidateDataAsync(collectionName, data, isPartialUpdate: false)) return null;

        try
        {
            var converted = await ConvertToFirestoreCompatibleAsync(collectionName, data);
            var docRef = await _db.Collection(collectionName).AddAsync(converted);
            return docRef.Id;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    /// <summary>
    /// READ: Retrieves a single document by its ID from the specified collection.
    /// Returns the document data as a dictionary with automatic type conversion.
    /// </summary>
    public async Task<Dictionary<string, object>> GetByDocumentIdAsync(string collectionName, string documentId)
    {
        if (string.IsNullOrWhiteSpace(collectionName) || string.IsNullOrWhiteSpace(documentId)) return null;
        try
        {
            var snapshot = await _db.Collection(collectionName).Document(documentId).GetSnapshotAsync();
            if (!snapshot.Exists) return null;
            var dict = snapshot.ToDictionary();
            var normalized = ConvertFromFirestoreTypes(dict);
            normalized["_id"] = snapshot.Id;
            return normalized;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    /// <summary>
    /// READ (All): Retrieves all documents in a collection. 
    /// Returns a dictionary mapping document IDs to their data.
    /// Note: Be careful with large collections as this fetches all documents.
    /// </summary>
    public async Task<Dictionary<string, object>> GetCollectionAsync(string collectionName)
    {
        var result = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        try
        {
            var snapshot = await _db.Collection(collectionName).GetSnapshotAsync();
            foreach (var doc in snapshot.Documents)
            {
                var d = ConvertFromFirestoreTypes(doc.ToDictionary());
                d["_id"] = doc.Id;
                result[doc.Id] = d;
            }
            return result;
        }
        catch (Exception ex)
        {
            return result;
        }
    }

    /// <summary>
    /// READ (Paginated): Retrieves documents with pagination, sorting, and filtering support.
    /// Parameters:
    ///   - limit: Maximum number of documents to retrieve (default: 15)
    ///   - orderBy: Field name to sort by (optional)
    ///   - descending: Sort in descending order (default: false)
    ///   - startAfterDocumentId: Document ID to start after for pagination
    /// Returns a dictionary mapping document IDs to their data.
    /// </summary>
    public async Task<Dictionary<string, Dictionary<string, object>>> GetCollectionAsync(string collectionName, int limit = 15, string pageToken = null, string orderBy = null, bool descending = false, string startAfterDocumentId = null)
    {
        var result = new Dictionary<string, Dictionary<string, object>>(StringComparer.OrdinalIgnoreCase);
        try
        {
            Query query = _db.Collection(collectionName);
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                query = descending ? query.OrderByDescending(orderBy) : query.OrderBy(orderBy);
            }
            if (limit > 0) query = query.Limit(limit);

            if (!string.IsNullOrWhiteSpace(startAfterDocumentId))
            {
                var startDoc = await _db.Collection(collectionName).Document(startAfterDocumentId).GetSnapshotAsync();
                if (startDoc.Exists)
                {
                    query = query.StartAfter(startDoc);
                }
            }

            var snapshot = await query.GetSnapshotAsync();
            foreach (var doc in snapshot.Documents)
            {
                var d = ConvertFromFirestoreTypes(doc.ToDictionary());
                d["_id"] = doc.Id;
                result[doc.Id] = d;
            }
            return result;
        }
        catch (Exception ex)
        {
            return result;
        }
    }

    /// <summary>
    /// UPDATE: Modifies an existing document with partial data (only specified fields are updated).
    /// Other fields remain unchanged. Returns the document ID on success.
    /// </summary>
    public async Task<string> UpdateByDocumentIdAsync(string collectionName, string documentId, Dictionary<string, object> data)
    {
        if (string.IsNullOrWhiteSpace(collectionName) || string.IsNullOrWhiteSpace(documentId)) throw new ArgumentNullException("collectionName/documentId");
        if (data == null) throw new ArgumentNullException(nameof(data));

        if (!await ValidateDataAsync(collectionName, data, isPartialUpdate: true)) return null;

        try
        {
            var converted = await ConvertToFirestoreCompatibleAsync(collectionName, data);
            await _db.Collection(collectionName).Document(documentId).UpdateAsync(converted);
            return documentId;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    /// <summary>
    /// DELETE: Removes a document from a collection by its ID.
    /// Returns the document ID on success, null on failure.
    /// </summary>
    public async Task<string> DeleteByDocumentIdAsync(string collectionName, string documentId)
    {
        if (string.IsNullOrWhiteSpace(collectionName) || string.IsNullOrWhiteSpace(documentId)) throw new ArgumentNullException("collectionName/documentId");
        try
        {
            await _db.Collection(collectionName).Document(documentId).DeleteAsync();
            return documentId;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    #endregion

    #region Helpers: Validation + Conversion

    /// <summary>
    /// VALIDATION: Ensures data conforms to the collection's schema.
    /// For CREATE operations (isPartialUpdate=false): all schema fields must be present
    /// For UPDATE operations (isPartialUpdate=true): only supplied fields are validated
    /// </summary>
    private async Task<bool> ValidateDataAsync(string collectionName, Dictionary<string, object> data, bool isPartialUpdate = false)
    {
        // Fetch schema for the specific collection
        var schemas = await GetMasterSchemaAsync(collectionName);
        if (schemas == null || !schemas.TryGetValue(collectionName, out var ms))
        {
            return false;
        }

        var collectionSchema = ms.Master[collectionName];

        if (!isPartialUpdate)
        {
            // enforce presence of required fields (every field defined in schema is treated as required by default)
            foreach (var required in collectionSchema.Properties.Keys)
            {
                if (!data.ContainsKey(required))
                {
                    return false;
                }
            }
        }

        // Type validation for supplied fields
        foreach (var kv in data)
        {
            if (!collectionSchema.Properties.TryGetValue(kv.Key, out var propSchema))
            {
                return false;
            }

            if (!IsTypeValid(kv.Value, propSchema.Type))
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// TYPE CHECKING: Validates that a value matches its declared schema type.
    /// Supports Firestore types: String, Number, Boolean, Timestamp, Reference, Map, Array
    /// </summary>
    private bool IsTypeValid(object value, string schemaType)
    {
        if (value == null) return true; // allow nulls
        switch (schemaType)
        {
            case "String": return value is string;
            case "Number": return value is int || value is long || value is double || value is float || value is decimal;
            case "Boolean": return value is bool;
            case "Timestamp": return value is DateTime || value is Google.Cloud.Firestore.Timestamp;
            case "Reference": return value is DocumentReference || value is string; // allow string id (we'll resolve it)
            case "Map": return value is Dictionary<string, object>;
            case "Array": return value is System.Collections.IEnumerable && !(value is string);
            default: return false;
        }
    }

    /// <summary>
    /// DESERIALIZATION: Converts Firestore's native types to .NET-friendly types.
    /// - Firestore Timestamps → DateTime
    /// - DocumentReferences → Document paths
    /// - Nested Maps → Dictionaries (recursive)
    /// - Arrays → Lists (recursive)
    /// </summary>
    private Dictionary<string, object> ConvertFromFirestoreTypes(Dictionary<string, object> input)
    {
        var result = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        foreach (var kv in input)
        {
            if (kv.Value is Google.Cloud.Firestore.Timestamp t)
            {
                result[kv.Key] = t.ToDateTime();
            }
            else if (kv.Value is DocumentReference docRef)
            {
                result[kv.Key] = docRef.Path; // expose path which can be used to resolve reference
            }
            else if (kv.Value is Dictionary<string, object> map)
            {
                result[kv.Key] = ConvertFromFirestoreTypes(map);
            }
            else if (kv.Value is IEnumerable<object> list)
            {
                var converted = list.Select(item => item is Dictionary<string, object> imap ? ConvertFromFirestoreTypes(imap) : item).ToList();
                result[kv.Key] = converted;
            }
            else
            {
                result[kv.Key] = kv.Value;
            }
        }
        return result;
    }

    /// <summary>
    /// SERIALIZATION: Converts .NET types to Firestore-compatible format.
    /// - Resolves document references using the schema
    /// - DateTime → Firestore Timestamps
    /// - String IDs → DocumentReferences (intelligent path resolution)
    /// - Preserves Maps and Arrays as-is
    /// </summary>
    private async Task<Dictionary<string, object>> ConvertToFirestoreCompatibleAsync(string collectionName, Dictionary<string, object> input)
    {
        var schemas = await GetMasterSchemaAsync(collectionName);
        if (schemas == null || !schemas.TryGetValue(collectionName, out var ms))
        {
            // no schema known - just return input
            return input;
        }

        var collectionSchema = ms.Master[collectionName];
        var converted = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        foreach (var kv in input)
        {
            if (!collectionSchema.Properties.TryGetValue(kv.Key, out var propSchema))
            {
                // Unknown field - pass through
                converted[kv.Key] = kv.Value;
                continue;
            }

            switch (propSchema.Type)
            {
                case "Reference":
                    // Accept either DocumentReference or string id or full path
                    if (kv.Value is DocumentReference dr) converted[kv.Key] = dr;
                    else if (kv.Value is string s)
                    {
                        if (s.Contains("/")) // assume full path
                        {
                            converted[kv.Key] = _db.Document(s);
                        }
                        else if (!string.IsNullOrWhiteSpace(propSchema.Collection))
                        {
                            converted[kv.Key] = _db.Collection(propSchema.Collection).Document(s);
                        }
                        else
                        {
                            // best-effort: try same collection
                            converted[kv.Key] = _db.Collection(collectionName).Document(s);
                        }
                    }
                    else converted[kv.Key] = kv.Value; // pass through
                    break;

                case "Timestamp":
                    if (kv.Value is DateTime dt) converted[kv.Key] = Timestamp.FromDateTime(dt.ToUniversalTime());
                    else converted[kv.Key] = kv.Value;
                    break;

                default:
                    // Map/arrays should be accepted as-is
                    converted[kv.Key] = kv.Value;
                    break;
            }
        }

        return converted;
    }

    #endregion
}
```

### Usage Example

In this section, we'll walk through a practical example of how to use the Firestore CRUD implementation. We'll create schemas for two related collections (Drivers and Cards) and demonstrate all CRUD operations.

#### Connecting to Firestore

```cs
Console.WriteLine("Connecting to Firestore...");

string projectId = "brickssimpledatabase";
string credentialPath = "admin.json"; // <-- MAKE SURE THIS FILE IS IN YOUR RUN DIRECTORY

FirestoreDb db;
 try
{
    // Open the file as a stream
    using (var stream = new FileStream(credentialPath, FileMode.Open, FileAccess.Read))
    {
        // Create the credential from the stream
        var credential = GoogleCredential.FromStream(stream);

        db = new FirestoreDbBuilder
        {
            ProjectId = projectId,
            Credential = credential,
            EmulatorDetection = EmulatorDetection.None
        }.Build();
    }

    Console.WriteLine($"✅ Successfully connected to project '{projectId}'!");
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Connection failed: {ex.Message}");
    Console.WriteLine("\nMake sure 'serviceAccount.json' is in the correct folder.");
    return;
}
```

#### Initialize CRUD Service

Once connected to Firestore, we create an instance of the FirestoreCrud class:

```csharp
var crud = new FirestoreCrud(db);
```

#### Define Collection Schemas

Before we can add data, we need to define the schema for our collections. This ensures type safety and validation.

**Driver Collection Schema:**
This schema defines a Drivers collection with Name, LicenseNumber, and Age fields.

```cs
var driverSchema = new Dictionary<string, CollectionSchema>
{
    {
        "Drivers", new CollectionSchema
        {
            Name = "Drivers",
            Properties = new Dictionary<string, PropertySchema>
            {
                { "Name", new PropertySchema { Type = "String" } },
                { "LicenseNumber", new PropertySchema { Type = "String" } },
                { "Age", new PropertySchema { Type = "Number" } }
            }
        }
    }
};
```

#### Create Schema for Drivers Collection

We'll start by creating a schema for the Drivers collection. This will enforce that all driver documents have Name (String), LicenseNumber (String), and Age (Number) fields:

```cs
await crud.CreateMasterSchemaTypeByCollectionNameIfNotExistAsync("Drivers", driverSchema)
```

#### Create Schema for Cards Collection

Next, we create a schema for the Cards collection which has a reference to the Drivers collection:

**Cards Collection Schema:**
This schema defines a Cards collection that references Drivers. It includes CardNumber, IssuedDate (timestamp), and a reference to a Driver document.

```cs
var cardSchema = new Dictionary<string, CollectionSchema>
{
    {
        "Cards", new CollectionSchema
        {
            Name = "Cards",
            Properties = new Dictionary<string, PropertySchema>
            {
                { "CardNumber", new PropertySchema { Type = "String" } },
                { "IssuedDate", new PropertySchema { Type = "Timestamp" } },
                { "DriverId", new PropertySchema { Type = "Reference", Collection = "Drivers" } }
            }
        }
    }
};
```



```cs
await crud.CreateMasterSchemaTypeByCollectionNameIfNotExistAsync("Cards", cardSchema);
```

```cs
var driverId = await crud.AddAsync("Drivers", new Dictionary<string, object>
{
    { "Name", "Raj Kumar" },
    { "LicenseNumber", "DL-4523-9001" },
    { "Age", 32 }
});
```

```cs
var cardId = await crud.AddAsync("Cards", new Dictionary<string, object>
{
    { "CardNumber", "CARD-1001" },
    { "IssuedDate", DateTime.UtcNow },
    { "DriverId", driverId }  // auto-converted to DocumentReference based on schema
});
```
