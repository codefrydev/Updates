---
title: "Get Id of All items in Google Drive Folder"
author: "PrashantUnity"
weight: 100
dateString: June 2024  
description: ""
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "blog/googledrive.png" # image path/url
    alt: "Google Dive Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "NET", "codefrydev", "C sharp", "CFD", "HtmlAgilityPack","Google Drive","ID"]
---

## Problem
Suppose you want to Extract Id of all the items resides in a Folder of Goolge Drive. There are many ways to Do this like Manually Copying from each file or Programtically . I Will Guide you How to Do this using program in C#   


### Requirement 
- Shared Google Drive Folder id /URL
```
https://drive.google.com/drive/u/4/folders/1759s8Jule46RCPypiQ5y3wLh5aCPlrK6
```
- IDE Like VS Code Or Visual Studio Preffered.
- Leatest .NET SDK Installed. [You Can Get it From Here](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks)


### Steps 1

Open IDE Or Code Editor. Create New console App using IDE Or through this Command In Terminal
```sh
dotnet new console -n MyApp
```
### Steps 2

Install HtmlAgilityPack in project Using one of below Commands

> Package Manager
```sh
NuGet\Install-Package HtmlAgilityPack -Version 1.11.60
```
> Command Line Inter Face
```sh
dotnet add package HtmlAgilityPack --version 1.11.60
```
> If You are using Polyglot Notebook in VS Code
```sh
\#r "nuget: HtmlAgilityPack, 1.11.60"
```
> Right Click on Project Choose Edit Project File 
```sh 
  <ItemGroup>
    <PackageReference Include="HtmlAgilityPack" Version="1.11.61" />
  </ItemGroup> 
```

## Your .csproj file Should Look similar like this

```sh
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

Open Program File and add below Function Snippets.

```cs
string GetHtml(string url)
{
    using (WebClient client = new WebClient())
    {
        return client.DownloadString(url);
    }
}
``` 

```cs
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

```cs
// Replace 'YOUR_FOLDER_ID' with the ID of your Google Drive folder
string folderId = "1759s8Jule46RCPypiQ5y3wLh5aCPlrK6";

// URL of the Google Drive folder
string url = $"https://drive.google.com/drive/folders/{folderId}";

// Fetch the HTML content of the Google Drive folder link
string html = GetHtml(url);

// Extract the file IDs and names from the HTML
var fileList = ExtractFileList(html);
```

### Step 6

Iterating over fileList to Print it to Console.

```cs
foreach (var file in fileList)
{
    Console.WriteLine($"File ID: {file}");
}
```

### Full Code

```cs
using HtmlAgilityPack; 
using System.Net;


// Replace 'YOUR_FOLDER_ID' with the ID of your Google Drive folder
string folderId = "1759s8Jule46RCPypiQ5y3wLh5aCPlrK6";

// URL of the Google Drive folder
string url = $"https://drive.google.com/drive/folders/{folderId}";

// Fetch the HTML content of the Google Drive folder link
string html = GetHtml(url);

// Extract the file IDs and names from the HTML
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

![drive](./videos/drive.mp4)
