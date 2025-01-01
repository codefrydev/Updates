---
title: "Sqlite Database "
author: "PrashantUnity"
weight: 100
date: 2025-01-01
lastmod: 2025-01-01
dateString: January 2025  
description: "Populate Sqlite Data Base Using Poluglot Notebook and Net"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "sqlite.svg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "NET", "codefrydev", "C sharp", "CFD","Sqlite"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD" ,"Sqlite"]
---

# Nuget Package

## Create .ipynb file

```csharp
#r "nuget: Faker.Net, 2.0.163"
#r "nuget:SkiaSharp, 3.116.1"
#r "nuget: System.Data.SQLite.Core, 1.0.119"
```

## Importing namespace

```csharp
using Faker;
using System.IO;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Data.SQLite;
```

## Create Class

```csharp
public class Book
{
    public int Id { get; set; }  
    public string Title { get; set; } 
    public string Author { get; set; }
    public byte[] Image { get; set; } 
    public decimal Price { get; set; }
    public string Description { get; set; } 
    public DateTime PublishDate { get; set; }
    public string Category { get; set; }
} 
```

## Bunch of Color for random background color

```csharp
var listOfColor = new List<SKColor>
{
    SKColor.Parse("#86B6F6"),
    SKColor.Parse("#176B87"),
    SKColor.Parse("#00A9FF"),
    SKColor.Parse("#FF90BC"),
    SKColor.Parse("#8ACDD7"),
    SKColor.Parse("#F2AFEF"),
    SKColor.Parse("#C499F3"),
    SKColor.Parse("#33186B"),
    
};
```

## Sqlite Database File Location

```csharp
var connectionString = @"Data Source=C:\Users\91746\source\repos\Shopping\Shopping\BookStore.db";
```

## This will Generate Data for Cover Image Dynamically

```csharp
byte[] Generate<T>(T book)
{
    int width = 480;
    int height = 540;  
    int marginY = -10;
    int marginX = -10;

    string mainText =Faker.Name.First(); //book.Title;
    string subText = Faker.Name.Last();

    string backGroundColor =listOfColor[Faker.RandomNumber.Next(0,listOfColor.Count()-1)].ToString();
    string textColor = "#ffffff";
    string boderColor = "#ffffff";
    SKBitmap bmp = new(width, height);
    SKCanvas canvas = new(bmp); 
    canvas.Clear(SKColor.Parse(backGroundColor)); 
    using (var paint = new SKPaint()) 
    {
        paint.TextSize = width/ 10.0f;
        paint.IsAntialias = true;
        paint.Color = SKColor.Parse(textColor);
        paint.IsStroke = false;
        paint.StrokeWidth = 3; 
        paint.TextAlign = SKTextAlign.Center; 
        canvas.DrawText(mainText, width / 2f, height / 2f, paint);
        paint.TextSize = width/ 25.0f;
        paint.TextAlign = SKTextAlign.Right;
        canvas.DrawText(subText, width+marginX, height+marginY, paint);
        paint.TextSize = width/ 20.0f;
        paint.IsStroke = true;
        paint.TextAlign = SKTextAlign.Center;
        paint.Color = SKColor.Parse(textColor); 
    }
    //SKFileWStream fs = new($"Images/{book.Title}.jpg");
    //bmp.Encode(fs, SKEncodedImageFormat.Jpeg, quality: 50);
    bmp.Encode(SKEncodedImageFormat.Jpeg,100);
    using (MemoryStream ms = new MemoryStream())
    { 
        bmp.Encode(ms, SKEncodedImageFormat.Jpeg, 100); 
        return ms.ToArray(); 
    }
    return bmp.Bytes;
}
```

## Using Reflection For Auto filling Data To Proprties

```csharp
T GetObjectOf<T>()
{
    Type objectType = typeof(T);
    object objectObject = Activator.CreateInstance(objectType);

    // Get the properties of the Book class
    PropertyInfo[] properties = objectType.GetProperties();

    // Use Faker.NET to populate the properties dynamically
    foreach (var property in properties)
    {
        // Skip the 'Id' property as it's usually auto-generated
        if (property.Name == "Id")
            continue;

        // Create fake data based on the property type
        if (property.PropertyType == typeof(string))
        {
            property.SetValue(objectObject, Faker.Name.FullName()); 
        }
        else if (property.PropertyType == typeof(int))
        {
            // Assign a random integer
            property.SetValue(objectObject, Faker.RandomNumber.Next());
        }
        else if (property.PropertyType == typeof(decimal))
        {
            // Assign a random decimal value
            property.SetValue(objectObject, (decimal)(Faker.RandomNumber.Next(01,1000) ));
        }
        else if (property.PropertyType == typeof(DateTime))
        {
            // Assign a random past date
            property.SetValue(objectObject, DateTime.Now.AddMonths(Faker.RandomNumber.Next(1,100)));
        }
        else if (property.PropertyType == typeof(byte[]))
        {
            // Assign a random byte array (representing an image or file)
            property.SetValue(objectObject, Generate((T)objectObject));
        }
        else if (property.PropertyType == typeof(System.Enum))
        {
            // For enum types, assign a random enum value if the property is of enum type
            Array enumValues = property.PropertyType.GetEnumValues();
            var randomEnumValue = enumValues.GetValue(Faker.RandomNumber.Next(0, enumValues.Length));
            property.SetValue(objectObject, randomEnumValue);
        }
    }
    return (T)objectObject;
}
```

## Generate Bunch Of Book Will bw used to insert to database

```csharp
List<T> GeBook<T>()
{
    var ls = new List<T>();
    for(var i=0;i<50;i++)
    {
        var newBook = GetObjectOf<T>();
        ls.Add(newBook);
    }
    return ls;
}
```

## Dynamically Creating SqlQuery string Using Reflection

```csharp
public void InsertBook<T>(T entity, string queryString)
{
    string insertQuery = queryString;
    try
    {
        using (SQLiteConnection conn = new SQLiteConnection(connectionString))
        {
            try
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn))
                {
                    Type type = typeof(T); 
                    // Get all properties of the Book class using Reflection
                    PropertyInfo[] properties = type.GetProperties(); 
                    foreach (var property in properties)
                    {
                        // Get the name of the property
                        string propertyName = property.Name; 
                        object propertyValue = property.GetValue(entity); 
                        cmd.Parameters.AddWithValue($"@{propertyName}", propertyValue);
                    }  
                    var num = cmd.ExecuteNonQuery(); 
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    
}
```

## Here data is inserted to database

```csharp
string InsertCommandStringGenerator<T>()
{
    Type bookType = typeof(T);

    // Get all the properties of the Book class
    PropertyInfo[] properties = bookType.GetProperties();

    // Initialize StringBuilder to construct the SQL query
    StringBuilder insertQuery = new StringBuilder();

    // Start building the SQL query
    insertQuery.AppendLine("INSERT INTO Books (");

    // Loop through the properties to add column names
    for (int i = 0; i < properties.Length; i++)
    {
        if(properties[i].Name.ToLower()=="id") continue;
        insertQuery.Append(properties[i].Name);

        if (i < properties.Length - 1)
        {
             insertQuery.Append(", ");
        }
    }

    insertQuery.AppendLine(") VALUES (");

    // Loop through the properties again to add parameter placeholders
    for (int i = 0; i < properties.Length; i++)
    {
        if(properties[i].Name.ToLower()=="id") continue;
        insertQuery.Append("@");
        insertQuery.Append(properties[i].Name);
        if (i < properties.Length - 1)
        {
             insertQuery.Append(", ");
        }
    } 
    insertQuery.AppendLine(");");
    return insertQuery.ToString();
}
```

## Final Command To populate all above

```csharp
var queryString = InsertCommandStringGenerator<Book>();
foreach(var item in GeBook<Book>())
{
    InsertBook(item,queryString);
}
```
