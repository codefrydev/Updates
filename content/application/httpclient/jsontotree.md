---
title: "Convert JSON to Tree Structure in C#"
author: "PrashantUnity"
weight: 110
date: 2025-02-24
lastmod: 2025-02-25
dateString: February 2025  
description: "Learn how to parse dynamic JSON structures into tree nodes in C# for handling variable property names with consistent depth levels"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "NET", "codefrydev", "C sharp", "CFD","JSON"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD","JSON"]
---


# Handling Dynamic JSON with Variable Property Names

## Here is one way you can solve it 😁.

> Since json can have name and Several children so we can create Tree like node

```cs
public class JsonNode
{
    public string Name {get;set;}
    public List<JsonNode> Child {get;set;} = [];
}
```

> Below code generate tree using Recursion


```cs
using System;
using System.Collections.Generic;
using System.Text.Json;

public static JsonNode BuildTree(JsonElement element, string nodeName)
{
    var node = new JsonNode { Name = nodeName };

    if (element.ValueKind == JsonValueKind.Object)
    {
        foreach (var property in element.EnumerateObject())
        {
            node.Child.Add(BuildTree(property.Value, property.Name));
        }
    }
    else if (element.ValueKind == JsonValueKind.Array)
    {
        int index = 0;
        foreach (var item in element.EnumerateArray())
        {
            node.Child.Add(BuildTree(item, $"[{index}]") );
            index++;
        }
    }
    else
    {
        node.Child.Add(new JsonNode { Name = element.ToString() });
    }

    return node;
}
```

> Here we we have sample code to initialize/ use the above code
```cs
string jsonString = @"
        {
            ""12345"": {
                ""name"": ""Test Business"",
                ""policies"": {
                    ""checkin"": ""12:00 PM"",
                    ""checkout"": ""10:00 AM"",
                    ""cancellation"": {
                        ""before"": ""24 hours"",
                        ""fee"": ""10%""
                    }
                }
            }
        }";
JsonDocument doc = JsonDocument.Parse(jsonString);
JsonElement rootElement = doc.RootElement;
JsonNode rootNode = BuildTree(rootElement, "Root"); 

var parent = rootNode.Child[0];
```

> Example

![Image](./example.png)