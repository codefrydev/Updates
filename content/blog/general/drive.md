---
title: "Extract All File IDs from a Google Drive Folder"
author: "PrashantUnity"
weight: 100
date: 2024-06-13T00:00:00-07:00
lastmod: 2024-06-13T23:59:59-07:00
dateString: June 2024  
description: "Learn how to programmatically extract file IDs from a Google Drive folder using C# and HtmlAgilityPack. Perfect for bulk operations and automation tasks."
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "googledrive.png" # image path/url
    alt: "Google Drive Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "C sharp", "HtmlAgilityPack","Google Drive","ID"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD", "HtmlAgilityPack","Google Drive","ID"]
---

## Overview
Suppose you want to extract the ID of all items that reside in a folder of Google Drive. There are many ways to do this, like manually copying from each file or programmatically. I will guide you on how to do this using a program in C#   


### Requirements 
- Shared Google Drive Folder id /URL
```
https://drive.google.com/drive/u/4/folders/1759s8Jule46RCPypiQ5y3wLh5aCPlrK6
```
- IDE like VS Code or Visual Studio preferred.
- Latest .NET SDK installed. [You can get it from here](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks)


### Steps 1

Open IDE or code editor. Create a new console app using IDE or through this command in terminal
```sh {linenos=true}
dotnet new console -n MyApp
```
### Steps 2

Install HtmlAgilityPack in project using one of the below commands

> Package Manager
```sh {linenos=true}
NuGet\Install-Package HtmlAgilityPack -Version 1.11.60
```
> Command Line Interface
```sh {linenos=true}
dotnet add package HtmlAgilityPack --version 1.11.60
```
> If you are using Polyglot Notebook in VS Code
```sh {linenos=true}
\#r "nuget: HtmlAgilityPack, 1.11.60"
```
> Right-click on project and choose Edit Project File 
```sh {linenos=true}
  <ItemGroup>
    <PackageReference Include="HtmlAgilityPack" Version="1.11.61" />
  </ItemGroup> 
```

## Your .csproj file should look similar to this

```sh {linenos=true}
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="HtmlAgilityPack" Version="1.11.61" />
  </ItemGroup>

</Project>
```

### Steps 3

Open Program file and add the below function snippets.

```cs {linenos=true}
string GetHtml(string url)
{
    using (WebClient client = new WebClient())
    {
        return client.DownloadString(url);
    }
}
``` 

```cs {linenos=true}
List<string> ExtractFileList(string html)
{
    var fileList = new List<string>();

    // Load the HTML document
    HtmlDocument doc = new HtmlDocument();
    doc.LoadHtml(html);

    // XPath to select elements containing file ID and name
    var nodes = doc.DocumentNode.SelectNodes("//div[@data-id]");

    if (nodes != null)
    {
        foreach (var node in nodes)
        {
            // Extract file ID and name attributes
            string id = node.Attributes["data-id"].Value;
            string name = WebUtility.HtmlDecode(node.GetAttributeValue("data-tooltip", ""));

            fileList.Add(id);
        }
    }

    return fileList;
}
```

### Step 5

- Replace folderId value with Your Drive folder Id
- Or Replace url value with Your Drive Folder Url
- Then Call GetHtml Function To Get Html Content
- ExtractFileList to Get List Of Only

```cs {linenos=true}
// Replace '1759s8Jule46RCPypiQ5y3wLh5aCPlrK6' with the ID of your Google Drive folder
string folderId = "1759s8Jule46RCPypiQ5y3wLh5aCPlrK6";

// URL of the Google Drive folder
string url = $"https://drive.google.com/drive/folders/{folderId}";

// Fetch the HTML content of the Google Drive folder link
string html = GetHtml(url);

// Extract the file IDs from the HTML
var fileList = ExtractFileList(html);
```

### Step 6

Iterating over fileList to Print it to Console.

```cs {linenos=true}
foreach (var file in fileList)
{
    Console.WriteLine($"File ID: {file}");
}
```

### Full Code

```cs {linenos=true}
using HtmlAgilityPack; 
using System.Net;


// Replace '1759s8Jule46RCPypiQ5y3wLh5aCPlrK6' with the ID of your Google Drive folder
string folderId = "1759s8Jule46RCPypiQ5y3wLh5aCPlrK6";

// URL of the Google Drive folder
string url = $"https://drive.google.com/drive/folders/{folderId}";

// Fetch the HTML content of the Google Drive folder link
string html = GetHtml(url);

// Extract the file IDs from the HTML
var fileList = ExtractFileList(html);

// Output the file list
foreach (var file in fileList)
{
    Console.WriteLine($"File ID: {file}");
}
string GetHtml(string url)
{
    using (WebClient client = new WebClient())
    {
        return client.DownloadString(url);
    }
}
List<string> ExtractFileList(string html)
{
    var fileList = new List<string>();

    // Load the HTML document
    HtmlDocument doc = new HtmlDocument();
    doc.LoadHtml(html);

    // XPath to select elements containing file ID and name
    var nodes = doc.DocumentNode.SelectNodes("//div[@data-id]");

    if (nodes != null)
    {
        foreach (var node in nodes)
        {
            // Extract file ID and name attributes
            string id = node.Attributes["data-id"].Value;
            string name = WebUtility.HtmlDecode(node.GetAttributeValue("data-tooltip", ""));

            fileList.Add(id);
        }
    }

    return fileList;
}
```

> You Can Just Paste Full Code And Check If there is any error you are Getting.

> Then You can Hover Over Error And it Will Prompt Show Potential Fixes.

> And Choose HtmlAgilityPack.

> For similar type of Error you do The Same.

> For More Follow below Videos

<video width="360" height="180" controls auto="false">
  <source src="./drive.mp4" type="video/mp4" >
  Your browser does not support the video tag.
</video>