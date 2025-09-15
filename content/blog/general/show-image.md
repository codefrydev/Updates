---
title: "Display C# String Values as HTML in Polyglot Notebook"
author: "PrashantUnity"
weight: 100
date: 2024-06-23T00:00:00-07:00
lastmod: 2024-06-23T23:59:59-07:00
dateString: June 2024  
description: "Step-by-step guide to displaying C# string values as HTML content in Polyglot Notebook with practical examples and formatting techniques"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "C sharp", "Polyglot","Html","Dispaly"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD", "Html in Polyglot Notebook","Dispaly"]
---

## Display HTML Content in Polyglot Notebook

### Requirements

1. **Visual Studio Code (VS Code)**
2. **Polyglot Notebook Extension**

![Polyglot Notebook Extension](./poly.png)

3. **Basic Setup Knowledge**
   - If you're new to Polyglot Notebooks, check out the [initial setup instructions here]({{< relref "blog/csharp/hello-world-poly.md" >}}).
4. **.NET SDK**
   - If not installed, download and install it [from the official website](https://dotnet.microsoft.com/en-us/download).
5. An Image File

### Setting Up Your Files

1. **Install Visual Studio Code**
   - If you haven't already, download and install [VS Code](https://code.visualstudio.com/).

2. **Open Your Image Folder**
   - Open Folder and Copy the image Path.

3. **Open Terminal in the Folder**
   - **Windows:** Right-click in the folder, select "Show More Options," then "Open in Terminal." Alternatively, type `cmd` in the folder path and press Enter.
   - In the terminal, type `code .` to open VS Code in that folder.

4. **Still Facing Issues?**
   - Check out the [Basic Setup]({{< relref "blog/csharp/hello-world-poly.md" >}})  for additional guidance.

### Working in Your Notebook

- **Create a New Notebook**
  - Name the file with any desired name and the `.ipynb` extension.

- **Import Necessary Code**
  - Copy and paste the following code to import required namespaces:

```csharp
using System.Drawing;
using System.IO;
using System.Text;
using Microsoft.DotNet.Interactive.Formatting;
Formatter.DefaultMimeType ="text/html";
```

- Below code Function Whose job is to Convert Image to Base64 string.

```csharp
public static string ImageToBase64String(string imagePath)
{
    using  Image image = Image.FromFile(imagePath); 
    using  MemoryStream memoryStream = new MemoryStream();
    image.Save(memoryStream, image.RawFormat);
    byte[] imageBytes = memoryStream.ToArray();

    // Convert byte[] to Base64 String
    string base64String = Convert.ToBase64String(imageBytes);
    return base64String;  
}
```

- **Convert Image to Base64**
  - Identify the image path you want to convert.
  - Call the `ImageToBase64String` function, passing the image path as an argument:

  ```csharp
  var imagePath = @"Images\YourImage.png";
  string base64String = ImageToBase64String(imagePath);
  ```

- **Formatting Markdown to HTML**
    - Now Below code Function is to Converting markdown file to Html
    - Inside string Literal You can Place any Markdown string/Code And it will show it as html
    - Suppose you want to inject some variable inside string literal the you can do so by  providing **$** singn before string and the number of **$** symbol will be used to Interpolate for example if **$$** is used then **{{}}** will replace or if **$$$** is used then **{{{}}}** will be answer.

```csharp
var result = Markdig.Markdown.ToHtml(
$$"""
<img src="data:image/png;base64,{{base64String}}" alt="Base64 Image" />
"""); 
result.DisplayAs(Formatter.DefaultMimeType)
``` 

### Visualizing Results

- **Display C# String Value as HTML**
  - Inject your HTML content within the string literal. Any Markdown or code inside will be rendered as HTML.

![Reference](./sample.png)  


By following these steps, you'll seamlessly convert your image to a Base64 string and then use C# string to visualize Base64 string  as HTML in your Jupyter Notebook. If you need further assistance, refer to the provided images or documentation.