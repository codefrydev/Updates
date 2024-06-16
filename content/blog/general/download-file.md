---
title: "Download File from internet"
author: "PrashantUnity"
weight: 100
dateString: June 2024  
description: "Suppose you want to download File from internet. You can Do this One Manually download or Programtically. I Will walk through you How to Do this using program in C# "
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "download-logo.png" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "NET", "codefrydev", "C sharp", "CFD", "Download File","Downloader","httpclient"]
---

## Downloader

Download File Using C#

### Requirement 

- Valid File Url/ List of Url 
- IDE Like VS Code Or Visual Studio Preffered.
- Leatest .NET SDK Installed. [You Can Get it From Here](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks)

### Steps

- Open visual Studio
- Paste Below Snippets
- replace file Url Value Based on you Requirement
- Save File With Appropriate EExtension for example from above url png is used as it is png Image.

```cs {linenos=true}
 using FileStream fileStream = File.Create($"image.png");
```

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
        using (Stream fileStreaam = await response.Content.ReadAsStreamAsync())
        {
            // Save the file to a file
            using FileStream fileStream = File.Create($"image.png");
            await fileStreaam.CopyToAsync(fileStream);
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

### For List of String you may use

```cs {linenos=true}
var ls = new List<string>();
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
