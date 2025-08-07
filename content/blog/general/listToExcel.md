---
title: "Convert List Data to Excel"
author: "PrashantUnity"
weight: 115
date: 2025-03-14
lastmod: 2025-03-14
dateString: March 2025  
description: "Generate multi-sheet Excel files in C sharp using OpenXML"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "NET", "codefrydev", "C sharp", "CFD", "Excel","List"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD"]
hideMeta: true
---

# Creating Excel File from List<T> With Different Sheet With Naming

> nuget package used [OpenXML](https://github.com/dotnet/Open-XML-SDK?tab=readme-ov-file#documentation)
```cs
public static MemoryStream WriteMultipleListsToExcel_OpenXml(params (string sheetName, IEnumerable<object> list)[] sections)
{
   
    var memoryStream = new MemoryStream();

    using (var spreadsheetDocument = SpreadsheetDocument.Create(memoryStream, SpreadsheetDocumentType.Workbook))
    {
        var workbookPart = spreadsheetDocument.AddWorkbookPart();
        workbookPart.Workbook = new Workbook();

        var workbookProps = new WorkbookProperties() { DefaultThemeVersion = 124226 }; // Ensure workbook properties
        workbookPart.Workbook.AppendChild(workbookProps);

        var sheets = workbookPart.Workbook.AppendChild(new Sheets());

        uint sheetId = 1;

        foreach (var (sheetName, list) in sections)
        {
            var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());

            var sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = sheetId++, Name = sheetName };
            sheets.Append(sheet);

            var sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
            var type = list.GetType().GetGenericArguments()[0];
            var properties = type.GetProperties();

            // Add header row
            var headerRow = new Row();
            foreach (var prop in properties)
            {
                headerRow.Append(CreateTextCell(prop.Name));
            }
            sheetData.Append(headerRow);

            // Add data rows
            foreach (var item in list)
            {
                var dataRow = new Row();
                foreach (var prop in properties)
                {
                    var value = prop.GetValue(item)?.ToString() ?? string.Empty;
                    dataRow.Append(CreateTextCell(value));
                }
                sheetData.Append(dataRow);
            }

            worksheetPart.Worksheet.Save();
        }

        workbookPart.Workbook.Save();
    }

    memoryStream.Position = 0;
    return memoryStream;
}
private static Cell CreateTextCell(string value)
{
    return new Cell
    {
        CellValue = new CellValue(value),
        DataType = CellValues.String
    };
}
```

## Use of Above Function

> lets Suppose we have Below Class

```cs
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}

public class Order
{
    public int OrderId { get; set; }
    public decimal Amount { get; set; }
}
```

> Calling the function

```cs
var people = new List<Person>
{
    new Person { Name = "John", Age = 30 },
    new Person { Name = "Jane", Age = 25 }
};

var products = new List<Product>
{
    new Product { Name = "Laptop", Price = 1200 },
    new Product { Name = "Phone", Price = 800 }
};

var orders = new List<Order>
{
};

var memoryStream = WriteMultipleListsToExcel_OpenXml(("People", people), ("Products", products), ("Orders", orders));

File.WriteAllBytes("combined_data_openxml.xlsx", memoryStream.ToArray());
Console.WriteLine("Excel file created successfully using OpenXML!");
```