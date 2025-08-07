---
title: "Show Table in Polyglot Notebook"
author: "PrashantUnity"
weight: 115
date: 2025-03-14
lastmod: 2025-03-14
dateString: March 2025  
description: "Show list as Table in Polyglot note book using dataframe"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "NET", "codefrydev", "C sharp", "CFD", "Table","Polyglotnotebook","Dataframe"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD","Table","Dataframe"]
hideMeta: true
---

## Create .ipynb file using selwct .net Enviroment and select C# in cell for execution

### Import nuget package

```cs
#r "nuget: Microsoft.Data.Analysis" 
```

### Import namespace

```cs
using System;
using System.Collections.Generic;
using Microsoft.Data.Analysis;
```

### Create class

```cs
public class RedirectEntry
{
    public string WebsiteUrl { get; set; }
    public string RedirectUrl { get; set; }
    public string Status => IsValid ? "✅" : "❌";
    public bool IsValid { get; set; }
}

var data = new List<RedirectEntry>
{
    new RedirectEntry
    {
        WebsiteUrl = "https://codefrydev.in/Updates",
        RedirectUrl = "https://codefrydev.in/",
        IsValid = true
    },
};

```

### Create Generic Function for anytype of list incection

```cs
DataFrame ShowTable<T>(List<T> items)
{
    var properties = typeof(T).GetProperties();
    List<DataFrameColumn> columns = new();

    foreach (string header in properties.Select(p => p.Name))
    {
        columns.Add(new StringDataFrameColumn(header, new List<string>())); // Read as string
    }
    foreach(var item in items)
    {
        for (int i = 0; i < properties.Length; i++)
        {
            var values = properties.Select(p => p.GetValue(item)?.ToString() ?? "").ToList();
            ((StringDataFrameColumn)columns[i]).Append(values[i]);
        }
    }
    return new DataFrame(columns);
}
```

### Simply call the function in next cell without any commas or stuff

```cs
ShowTable(data)
```