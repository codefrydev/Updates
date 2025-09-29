---
title: "Generic Google Sheets CRUD Service for .NET Applications"
author: "PrashantUnity"
weight: 115
date: 2025-09-15
lastmod: 2025-09-15
dateString: September 2025
description: "A comprehensive guide to implementing a generic CRUD service for Google Sheets integration in .NET applications with automatic type mapping and error handling"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Google Sheets Integration" # alt text
    #caption: "Google Sheets CRUD Service"  display caption under cover 

tags: [ "Google Sheets", "C#", ".NET", "CRUD", "Google APIs", "codefrydev", "CFD"]
keywords: [ "Google Sheets", "C#", ".NET", "CRUD", "Google APIs", "Generic Service", "Type Mapping", "codefrydev", "CFD"]
hideMeta: true
---

## Overview

The `GenericGoogleSheetsService` is a powerful .NET service that provides a complete CRUD (Create, Read, Update, Delete) interface for Google Sheets integration. This service eliminates the need to write boilerplate code for each entity type by using generic programming and reflection to automatically map between your C# objects and Google Sheets rows.

### Key Features

- **Generic Type Support**: Works with any class that implements `IEntityWithId` and has a parameterless constructor
- **Automatic Type Mapping**: Uses reflection to map property names to Google Sheets columns
- **Complete CRUD Operations**: Create, Read, Update, and Delete operations with async support
- **Flexible Authentication**: Supports both JSON credentials and service account file paths
- **List Property Support**: Handles `List<string>` properties with custom delimiters
- **Error Handling**: Graceful error handling with detailed logging
- **Multiple Sheet Support**: Can work with different sheets within the same spreadsheet

### Use Cases

- **Data Synchronization**: Keep your application data synchronized with Google Sheets
- **Reporting**: Export application data to Google Sheets for analysis
- **Configuration Management**: Store application configuration in Google Sheets
- **Data Backup**: Use Google Sheets as a backup storage solution
- **Collaborative Data Entry**: Allow multiple users to edit data through Google Sheets

## Prerequisites

Before implementing this service, ensure you have:

### Required NuGet Packages

```xml
<PackageReference Include="Google.Apis.Sheets.v4" Version="1.68.0.3500" />
<PackageReference Include="Google.Apis.Auth" Version="1.68.0" />
```

### Google Cloud Setup

1. **Create a Google Cloud Project**
   - Go to [Google Cloud Console](https://console.cloud.google.com/)
   - Create a new project or select an existing one

2. **Enable Google Sheets API**
   - Navigate to "APIs & Services" > "Library"
   - Search for "Google Sheets API" and enable it

3. **Create Service Account Credentials**
   - Go to "APIs & Services" > "Credentials"
   - Click "Create Credentials" > "Service Account"
   - Download the JSON key file or copy the JSON content

4. **Share Your Google Sheet**
   - Open your Google Sheet
   - Click "Share" and add the service account email (found in the JSON credentials)
   - Give "Editor" permissions to the service account

### Required Interface

Your entity classes must implement the `IEntityWithId` interface:

```csharp
public interface IEntityWithId
{
    string Id { get; set; }
}
```

## Implementation

```csharp
using System.ComponentModel;
using System.Reflection;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Shopping.Core; // Assuming IEntityWithId is here

namespace Shopping.Admin.Services;

/// <summary>
/// A generic service to perform CRUD operations for any class T on a Google Sheet.
/// This service provides a type-safe way to interact with Google Sheets by automatically
/// mapping between C# objects and spreadsheet rows using reflection.
/// 
/// Requirements:
/// - T must implement IEntityWithId interface
/// - T must have a parameterless constructor
/// - Property names of T must match the header columns in the Google Sheet
/// - For List&lt;string&gt; properties, values are delimited with "@CFD " separator
/// </summary>
/// <typeparam name="T">The entity type that implements IEntityWithId</typeparam>
public class GenericGoogleSheetsService
{
    #region Private Fields

    /// <summary>
    /// Required OAuth2 scopes for Google Sheets API access
    /// </summary>
    private readonly string[] _scopes = [SheetsService.Scope.Spreadsheets];
    
    /// <summary>
    /// The unique identifier of the Google Spreadsheet to work with
    /// </summary>
    private readonly string _spreadsheetId;
    
    /// <summary>
    /// The authenticated Google Sheets service instance
    /// </summary>
    private readonly SheetsService _sheetsService;
    
    /// <summary>
    /// Custom delimiter used to separate List&lt;string&gt; values in spreadsheet cells
    /// </summary>
    private const string listDelimiter = "@CFD ";

    #endregion

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the GenericGoogleSheetsService
    /// </summary>
    /// <param name="credentials">
    /// Either a JSON string containing service account credentials or a file path to the credentials JSON file.
    /// If the string starts with "{", it's treated as JSON content; otherwise, it's treated as a file path.
    /// </param>
    /// <param name="spreadsheetId">The unique identifier of the Google Spreadsheet</param>
    /// <exception cref="ArgumentException">Thrown when credentials or spreadsheetId is null or empty</exception>
    /// <exception cref="FileNotFoundException">Thrown when credentials file path doesn't exist</exception>
    public GenericGoogleSheetsService(string credentials, string spreadsheetId)
    {
        if (string.IsNullOrEmpty(credentials))
            throw new ArgumentException("Credentials cannot be null or empty", nameof(credentials));
        if (string.IsNullOrEmpty(spreadsheetId))
            throw new ArgumentException("Spreadsheet ID cannot be null or empty", nameof(spreadsheetId));

        _spreadsheetId = spreadsheetId;

        // Determine if credentials is JSON content or file path
        GoogleCredential credential;
        if (credentials.Trim().StartsWith("{"))
        {
            // Treat as JSON content
            credential = GoogleCredential.FromJson(credentials).CreateScoped(_scopes);
        }
        else
        {
            // Treat as file path
            using var stream = new FileStream(credentials, FileMode.Open, FileAccess.Read);
            credential = GoogleCredential.FromStream(stream).CreateScoped(_scopes);
        }

        // Initialize the Google Sheets service
        _sheetsService = new SheetsService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = "GenericShoppingApp",
        });
    }

    #endregion

    #region Public CRUD Methods

    /// <summary>
    /// Retrieves all records from the specified Google Sheet and maps them to objects of type T.
    /// This method reads the entire sheet data, maps column headers to property names,
    /// and converts each row to an instance of type T.
    /// </summary>
    /// <typeparam name="T">The entity type that implements IEntityWithId</typeparam>
    /// <param name="sheetName">The name of the sheet to read from (default: "Sheet1")</param>
    /// <returns>A list of objects of type T populated with data from the sheet</returns>
    /// <exception cref="Google.GoogleApiException">Thrown when Google Sheets API call fails</exception>
    public async Task<List<T>> GetAllAsync<T>(string sheetName = "Sheet1") where T : class, IEntityWithId, new()
    {
        // Get sheet data with header mapping
        var (headerMap, allValues) = await GetSheetDataWithHeaderMap(sheetName);
        if (allValues == null || !allValues.Any()) return [];

        var items = new List<T>();
        // Create a dictionary of properties for efficient lookup
        var properties = typeof(T).GetProperties().ToDictionary(p => p.Name, p => p);

        // Process each data row
        foreach (var row in allValues)
        {
            var item = new T();
            
            // Map each column to the corresponding property
            foreach (var header in headerMap)
            {
                // Skip if property doesn't exist in the type
                if (!properties.TryGetValue(header.Key, out var prop)) continue;
                // Skip if row doesn't have enough columns
                if (header.Value >= row.Count) continue;

                var cellValue = row[header.Value]?.ToString();
                SetPropertyValue(item, prop, cellValue);
            }

            items.Add(item);
        }

        return items;
    }

    /// <summary>
    /// Adds a new record to the specified Google Sheet.
    /// This method generates a new GUID for the Id property, maps the object properties
    /// to sheet columns, and appends the data as a new row.
    /// </summary>
    /// <typeparam name="T">The entity type that implements IEntityWithId</typeparam>
    /// <param name="item">The object to add to the sheet</param>
    /// <param name="sheetName">The name of the sheet to add to (default: "Sheet1")</param>
    /// <returns>The item with the newly generated Id</returns>
    /// <exception cref="Google.GoogleApiException">Thrown when Google Sheets API call fails</exception>
    public async Task<T> AddAsync<T>(T item, string sheetName = "Sheet1") where T : class, IEntityWithId, new()
    {
        // Generate a new unique ID
        item.Id = Guid.NewGuid().ToString();

        // Get header mapping to determine column positions
        var (headerMap, _) = await GetSheetDataWithHeaderMap(sheetName);
        var valueRow = new object[headerMap.Count];
        var properties = typeof(T).GetProperties();

        // Map each property to its corresponding column
        foreach (var prop in properties)
        {
            if (headerMap.TryGetValue(prop.Name, out var colIndex))
            {
                valueRow[colIndex] = FormatPropertyValue(prop.GetValue(item));
            }
        }

        // Append the new row to the sheet
        var valueRange = new ValueRange { Values = [valueRow.ToList()] };
        var appendRequest = _sheetsService.Spreadsheets.Values.Append(valueRange, _spreadsheetId, $"{sheetName}!A1");
        appendRequest.ValueInputOption =
            SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
        await appendRequest.ExecuteAsync();

        return item;
    }

    /// <summary>
    /// Updates an existing record in the specified Google Sheet.
    /// This method finds the row by ID, maps the updated object properties to sheet columns,
    /// and updates the entire row with the new data.
    /// </summary>
    /// <typeparam name="T">The entity type that implements IEntityWithId</typeparam>
    /// <param name="itemToUpdate">The object containing updated data</param>
    /// <param name="sheetName">The name of the sheet to update (default: "Sheet1")</param>
    /// <returns>True if the update was successful, false if the record was not found</returns>
    /// <exception cref="Google.GoogleApiException">Thrown when Google Sheets API call fails</exception>
    public async Task<bool> UpdateAsync<T>(T itemToUpdate, string sheetName = "Sheet1")
        where T : class, IEntityWithId, new()
    {
        // Find the row containing the item to update
        var (rowIndex, _) = await FindRowByIdAsync(itemToUpdate.Id, sheetName);
        if (rowIndex == -1) return false; // Item not found

        // Get header mapping to determine column positions
        var (headerMap, _) = await GetSheetDataWithHeaderMap(sheetName);
        var valueRow = new object[headerMap.Count];
        var properties = typeof(T).GetProperties();

        // Map each property to its corresponding column
        foreach (var prop in properties)
        {
            if (headerMap.TryGetValue(prop.Name, out var colIndex))
            {
                valueRow[colIndex] = FormatPropertyValue(prop.GetValue(itemToUpdate));
            }
        }

        // Update the entire row
        var range = $"{sheetName}!A{rowIndex}:{GetColumnName(headerMap.Count)}{rowIndex}";
        var valueRange = new ValueRange { Values = [valueRow.ToList()] };
        var updateRequest = _sheetsService.Spreadsheets.Values.Update(valueRange, _spreadsheetId, range);
        updateRequest.ValueInputOption =
            SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
        await updateRequest.ExecuteAsync();

        return true;
    }

    /// <summary>
    /// Deletes a record from the specified Google Sheet by its ID.
    /// This method finds the row containing the specified ID and removes it entirely.
    /// </summary>
    /// <param name="id">The unique identifier of the record to delete</param>
    /// <param name="sheetName">The name of the sheet to delete from (default: "Sheet1")</param>
    /// <returns>True if the deletion was successful, false if the record was not found</returns>
    /// <exception cref="Google.GoogleApiException">Thrown when Google Sheets API call fails</exception>
    public async Task<bool> DeleteAsync(string id, string sheetName = "Sheet1")
    {
        // Find the row containing the item to delete
        var (rowIndex, sheetId) = await FindRowByIdAsync(id, sheetName);
        if (rowIndex == -1 || sheetId == null) return false; // Item not found

        // Create a delete request to remove the entire row
        var deleteRequest = new Request
        {
            DeleteDimension = new DeleteDimensionRequest
            {
                Range = new DimensionRange
                    { SheetId = sheetId, Dimension = "ROWS", StartIndex = rowIndex - 1, EndIndex = rowIndex }
            }
        };
        
        // Execute the batch update to delete the row
        var batchUpdateRequest = new BatchUpdateSpreadsheetRequest { Requests = [deleteRequest] };
        await _sheetsService.Spreadsheets.BatchUpdate(batchUpdateRequest, _spreadsheetId).ExecuteAsync();
        return true;
    }

    #endregion

    #region Private Helper Methods

    /// <summary>
    /// Retrieves sheet data and creates a mapping between column headers and their indices.
    /// This method reads the first row (headers) and all data rows from the specified sheet.
    /// </summary>
    /// <param name="sheetName">The name of the sheet to read from</param>
    /// <returns>
    /// A tuple containing:
    /// - headerMap: Dictionary mapping column names to their zero-based indices
    /// - values: List of data rows (excluding the header row)
    /// </returns>
    private async Task<(Dictionary<string, int> headerMap, IList<IList<object>>? values)> GetSheetDataWithHeaderMap(
        string sheetName = "Sheet1")
    {
        // Read data from column A to Z (adjust range as needed for larger sheets)
        var range = $"{sheetName}!A1:Z";
        var response = await _sheetsService.Spreadsheets.Values.Get(_spreadsheetId, range).ExecuteAsync();
        var allValues = response.Values;

        // Return empty result if no data found
        if (allValues == null || !allValues.Any())
        {
            return (new Dictionary<string, int>(), null);
        }

        // Create header mapping from the first row
        var headerMap = allValues[0]
            .Select((header, index) => new { Name = header.ToString(), Index = index })
            .Where(h => !string.IsNullOrEmpty(h.Name))
            .ToDictionary(h => h.Name!, h => h.Index);

        // Return header map and data rows (excluding header)
        return (headerMap, allValues.Skip(1).ToList());
    }

    /// <summary>
    /// Finds the row index and sheet ID for a record with the specified ID.
    /// This method searches through all rows in the sheet to locate the record.
    /// </summary>
    /// <param name="id">The unique identifier to search for</param>
    /// <param name="sheetName">The name of the sheet to search in</param>
    /// <returns>
    /// A tuple containing:
    /// - rowIndex: The 1-based row index where the record was found (-1 if not found)
    /// - sheetId: The internal sheet ID for batch operations (null if not found)
    /// </returns>
    private async Task<(int rowIndex, int? sheetId)> FindRowByIdAsync(string id, string sheetName = "Sheet1")
    {
        var (headerMap, allValues) = await GetSheetDataWithHeaderMap(sheetName);
        
        // Check if "Id" column exists
        if (!headerMap.TryGetValue("Id", out var idColIndex) || allValues == null)
        {
            return (-1, null);
        }

        // Search through all rows for the matching ID
        for (var i = 0; i < allValues.Count; i++)
        {
            if (idColIndex < allValues[i].Count && allValues[i][idColIndex]?.ToString() == id)
            {
                // Get sheet metadata to retrieve the internal sheet ID
                var sheetMetadata = await _sheetsService.Spreadsheets.Get(_spreadsheetId).ExecuteAsync();
                var sheet = sheetMetadata.Sheets.FirstOrDefault(s => s.Properties.Title == sheetName);
                
                // Return 1-based row index (+2 because: +1 for 0-based to 1-based, +1 for skipped header)
                return (i + 2, sheet?.Properties.SheetId);
            }
        }

        return (-1, null);
    }

    /// <summary>
    /// Sets a property value on an object, handling type conversion and special cases.
    /// This method supports automatic type conversion and special handling for List&lt;string&gt; properties.
    /// </summary>
    /// <typeparam name="T">The entity type</typeparam>
    /// <param name="item">The object to set the property on</param>
    /// <param name="prop">The property information</param>
    /// <param name="value">The string value to convert and set</param>
    private void SetPropertyValue<T>(T item, PropertyInfo prop, string? value) where T : class, IEntityWithId, new()
    {
        if (string.IsNullOrEmpty(value)) return;

        try
        {
            // Special handling for List<string> properties
            if (prop.PropertyType == typeof(List<string>))
            {
                var stringList = value.Split([listDelimiter], StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim())
                    .ToList();
                prop.SetValue(item, stringList);
            }
            else
            {
                // Use TypeConverter for automatic type conversion
                var converter = TypeDescriptor.GetConverter(prop.PropertyType);
                if (converter.CanConvertFrom(typeof(string)))
                {
                    prop.SetValue(item, converter.ConvertFromString(value));
                }
            }
        }
        catch (Exception ex)
        {
            // Log conversion errors but don't throw to allow partial data loading
            Console.WriteLine($"Could not set property '{prop.Name}' with value '{value}'. Error: {ex.Message}");
        }
    }

    /// <summary>
    /// Formats a property value for storage in Google Sheets.
    /// This method handles special formatting for List&lt;string&gt; properties using the custom delimiter.
    /// </summary>
    /// <param name="value">The property value to format</param>
    /// <returns>The formatted string representation of the value</returns>
    private static object FormatPropertyValue(object? value)
    {
        // Special formatting for List<string> properties
        if (value is List<string> list)
        {
            return string.Join(listDelimiter, list);
        }

        // Default string conversion
        return value?.ToString() ?? string.Empty;
    }

    /// <summary>
    /// Converts a column number to its corresponding Excel-style column name (A, B, C, ..., AA, AB, etc.).
    /// This method is used to generate proper range references for Google Sheets API calls.
    /// </summary>
    /// <param name="columnNumber">The 1-based column number</param>
    /// <returns>The Excel-style column name</returns>
    private static string GetColumnName(int columnNumber)
    {
        var dividend = columnNumber;
        var columnName = string.Empty;
        
        // Convert to base-26 representation (A=1, B=2, ..., Z=26, AA=27, etc.)
        while (dividend > 0)
        {
            var modulo = (dividend - 1) % 26;
            columnName = Convert.ToChar(65 + modulo) + columnName;
            dividend = (dividend - modulo) / 26;
        }

        return columnName;
    }

    #endregion
}
```

## Usage Examples

### Basic Setup

```csharp
// Initialize the service with JSON credentials
var credentials = File.ReadAllText("path/to/service-account.json");
var spreadsheetId = "your-spreadsheet-id";
var sheetsService = new GenericGoogleSheetsService(credentials, spreadsheetId);

// Or initialize with JSON string directly
var jsonCredentials = "{\"type\":\"service_account\",\"project_id\":\"...\"}";
var sheetsService = new GenericGoogleSheetsService(jsonCredentials, spreadsheetId);
```

### Entity Model Example

```csharp
public class Product : IEntityWithId
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Category { get; set; } = string.Empty;
    public List<string> Tags { get; set; } = new();
    public DateTime CreatedDate { get; set; }
    public bool IsActive { get; set; }
}
```

### Google Sheet Structure

Your Google Sheet should have headers that match your property names:

| Id | Name | Price | Category | Tags | CreatedDate | IsActive |
|----|------|-------|----------|------|-------------|----------|
| guid-1 | Laptop | 999.99 | Electronics | @CFD Gaming@CFD Portable | 2025-01-15 | TRUE |

### CRUD Operations

#### 1. Create (Add) Records

```csharp
var newProduct = new Product
{
    Name = "Wireless Mouse",
    Price = 29.99m,
    Category = "Electronics",
    Tags = new List<string> { "Wireless", "Ergonomic" },
    CreatedDate = DateTime.Now,
    IsActive = true
};

// Add to default sheet (Sheet1)
var createdProduct = await sheetsService.AddAsync(newProduct);

// Add to specific sheet
var createdProduct = await sheetsService.AddAsync(newProduct, "Products");
```

#### 2. Read (Get) Records

```csharp
// Get all products from default sheet
var allProducts = await sheetsService.GetAllAsync<Product>();

// Get all products from specific sheet
var allProducts = await sheetsService.GetAllAsync<Product>("Products");

// Process the results
foreach (var product in allProducts)
{
    Console.WriteLine($"Product: {product.Name}, Price: {product.Price:C}");
    Console.WriteLine($"Tags: {string.Join(", ", product.Tags)}");
}
```

#### 3. Update Records

```csharp
// Find the product to update (you'll need to get it first)
var products = await sheetsService.GetAllAsync<Product>();
var productToUpdate = products.FirstOrDefault(p => p.Name == "Wireless Mouse");

if (productToUpdate != null)
{
    productToUpdate.Price = 24.99m; // Update price
    productToUpdate.Tags.Add("Sale"); // Add new tag
    
    var success = await sheetsService.UpdateAsync(productToUpdate);
    
    if (success)
    {
        Console.WriteLine("Product updated successfully!");
    }
}
```

#### 4. Delete Records

```csharp
// Delete by ID
var success = await sheetsService.DeleteAsync("product-id-here");

// Delete from specific sheet
var success = await sheetsService.DeleteAsync("product-id-here", "Products");

if (success)
{
    Console.WriteLine("Product deleted successfully!");
}
```

### Advanced Usage Patterns

#### Batch Operations

```csharp
// Add multiple products
var products = new List<Product>
{
    new Product { Name = "Keyboard", Price = 79.99m, Category = "Electronics" },
    new Product { Name = "Monitor", Price = 299.99m, Category = "Electronics" },
    new Product { Name = "Desk", Price = 199.99m, Category = "Furniture" }
};

foreach (var product in products)
{
    await sheetsService.AddAsync(product);
}
```

#### Error Handling

```csharp
try
{
    var products = await sheetsService.GetAllAsync<Product>();
    // Process products...
}
catch (Exception ex)
{
    Console.WriteLine($"Error accessing Google Sheets: {ex.Message}");
    // Handle the error appropriately
}
```

#### Working with Different Sheet Types

```csharp
// Define different entity types
public class Customer : IEntityWithId
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
}

public class Order : IEntityWithId
{
    public string Id { get; set; } = string.Empty;
    public string CustomerId { get; set; } = string.Empty;
    public decimal Total { get; set; }
    public DateTime OrderDate { get; set; }
}

// Use with different sheets
var customers = await sheetsService.GetAllAsync<Customer>("Customers");
var orders = await sheetsService.GetAllAsync<Order>("Orders");
```

## Error Handling and Best Practices

### Common Error Scenarios

1. **Authentication Errors**
   - Invalid credentials
   - Expired service account keys
   - Insufficient permissions

2. **Sheet Access Errors**
   - Sheet doesn't exist
   - Sheet not shared with service account
   - Invalid spreadsheet ID

3. **Data Mapping Errors**
   - Property names don't match column headers
   - Type conversion failures
   - Missing required properties

### Best Practices

1. **Always Handle Exceptions**
   ```csharp
   try
   {
       var result = await sheetsService.GetAllAsync<Product>();
   }
   catch (Google.GoogleApiException ex)
   {
       // Handle Google API specific errors
       Console.WriteLine($"Google API Error: {ex.Message}");
   }
   catch (Exception ex)
   {
       // Handle general errors
       Console.WriteLine($"General Error: {ex.Message}");
   }
   ```

2. **Validate Data Before Operations**
   ```csharp
   if (string.IsNullOrEmpty(product.Name))
   {
       throw new ArgumentException("Product name is required");
   }
   ```

3. **Use Specific Sheet Names**
   ```csharp
   // Good: Specific sheet name
   await sheetsService.AddAsync(product, "Products");
   
   // Avoid: Default sheet name when you have multiple sheets
   await sheetsService.AddAsync(product); // Uses "Sheet1"
   ```

4. **Handle List Properties Carefully**
   ```csharp
   // The service uses "@CFD " as delimiter for List<string> properties
   // Make sure your data doesn't contain this delimiter in actual values
   product.Tags = new List<string> { "Electronics", "Gaming" };
   // Will be stored as: "Electronics@CFD Gaming"
   ```

5. **Monitor API Quotas**
   - Google Sheets API has rate limits
   - Implement retry logic for quota exceeded errors
   - Consider caching frequently accessed data

### Performance Considerations

- **Batch Operations**: When possible, minimize API calls by batching operations
- **Caching**: Cache frequently accessed data to reduce API calls
- **Pagination**: For large datasets, consider implementing pagination
- **Async Operations**: Always use async/await for better performance

## Troubleshooting

### Common Issues and Solutions

1. **"The caller does not have permission"**
   - Ensure the service account email is added to the Google Sheet
   - Verify the service account has Editor permissions

2. **"Requested entity was not found"**
   - Check that the spreadsheet ID is correct
   - Ensure the sheet name exists in the spreadsheet

3. **"Invalid column name"**
   - Verify that property names match column headers exactly
   - Check for case sensitivity issues

4. **"Type conversion failed"**
   - Ensure data types in the sheet match your property types
   - Check for null or empty values that can't be converted

### Debugging Tips

1. **Enable Logging**
   ```csharp
   // Add logging to see what's happening
   Console.WriteLine($"Processing property: {prop.Name} with value: {value}");
   ```

2. **Test with Simple Data**
   - Start with a simple entity with basic types
   - Gradually add more complex properties

3. **Verify Sheet Structure**
   - Check that column headers match property names exactly
   - Ensure data types are compatible
