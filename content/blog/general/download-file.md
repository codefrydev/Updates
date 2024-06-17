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

## File Downloader Using C#

### Requirements

- **Valid File URL/List of URLs**
- **IDE**: Visual Studio or Visual Studio Code (preferred)
- **Latest .NET SDK Installed**: [Download Here](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks)

### Steps

#### 1. Open Visual Studio or Visual Studio Code

#### 2. Paste the Below Snippet


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
            // Save the file with appropriate extension name
            var fileName=$"image.png"
            using FileStream fileStream = File.Create(fileName);
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
