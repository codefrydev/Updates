---
title: "Download Files from the Internet Using C#"
author: "PrashantUnity"
weight: 100
date: 2024-06-19T00:00:00-07:00
lastmod: 2024-06-19T23:59:59-07:00
dateString: June 2024  
description: "Learn how to programmatically download files from the internet using C# and HttpClient. Includes examples for single files and batch downloads with error handling."
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "download-logo.png" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "C sharp", "Download File","Downloader","httpclient"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD", "Download File","Downloader","httpclient"]
---

## File Downloader Using C#

### Requirements

- **Valid File URL/List of URLs**
- **IDE**: Visual Studio or Visual Studio Code (preferred)
- **Latest .NET SDK Installed**: [Download Here](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks)

### Steps

#### 1. Open Visual Studio or Visual Studio Code

#### 2. Paste the below snippet


```cs {linenos=true}
using var httpClient = new HttpClient();
// Replace the URL with the actual File URL
string fileUrl = "https://drive.usercontent.google.com/download?id=11PIu2A0ICZHh46phJMFZ3Y547gQDEI7T&export=download&authuser=0";
try
{
    // Send GET request to fetch the File
    using HttpResponseMessage response = await httpClient.GetAsync(fileUrl);
    // Check if request was successful
    if (response.IsSuccessStatusCode)
    {
        // Get the File stream
        using (Stream fileStream = await response.Content.ReadAsStreamAsync())
        {
            // Save the file with appropriate extension name
            var fileName=$"image.png"
            using FileStream fileStream = File.Create(fileName);
            await fileStream.CopyToAsync(fileStream);
        }
        Console.WriteLine("File downloaded successfully.");
    }
    else
    {
        Console.WriteLine($"Failed to download file. Status code: {response.StatusCode}");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}
```


#### 3. Customize the Code

- Replace `fileUrl` with the URL of the file you want to download.
- Replace `fileName` with the desired name and extension for the downloaded file.

#### 4. Run the Program

### For List of String you may use

```cs {linenos=true}
var ls = new List<string>()
{
    "https://picsum.photos/200/300",
    "https://picsum.photos/200/300"
};
foreach (var item in ls)
{
    try
    {
        // Send GET request to fetch the File
        using HttpResponseMessage response = await httpClient.GetAsync(fileUrl);
        // Check if request was successful
        /* 
            rest code
        */
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }

}
```
