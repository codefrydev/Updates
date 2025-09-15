---
title: "Getting Started with SkiaSharp Graphics Library"
author: "PrashantUnity"
weight: 100
date: 2024-06-14T00:00:00-07:00
lastmod: 2024-06-14T23:59:59-07:00
dateString: June 2024  
description: "Complete beginner's guide to SkiaSharp - a cross-platform 2D graphics library for .NET with setup instructions and basic drawing examples"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Skia Sharp Basic Cover" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [  "C sharp","Skia Sharp","Getting Started","Basic"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD", "Skia Sharp","Getting Started","Basic"]
---

## Getting Started With SkiaSharp

### Requirements

- **Visual Studio Code (VS Code)**
- **Polyglot Notebook Extension**
  - ![Create New File](./poly.png)
- **A little bit of experience in C#**

### Quick Setup

This guide will walk you through the basic setup and usage of SkiaSharp in VS Code.

#### Step 1: Create a Notebook File

1. Open VS Code.
2. Create a new file and name it **`Basic.ipynb`** or any name with the extension **`.ipynb`** or **`.dib`**.

#### Step 2: Install SkiaSharp Library

In the first cell of your notebook, type the following command to download the SkiaSharp library from the NuGet package repository:

```yaml {linenos=true}
#r "nuget:SkiaSharp"
```
![Create New File](./install.png)

#### Step 3: Import SkiaSharp Library

In a different cell, import the SkiaSharp library using the following code:

```yaml {linenos=true}
using SkiaSharp;
```
![Create New File](./import.png)

#### Step 4: Create a Dot Matrix Using SkiaSharp

Now, let's create a dot matrix using SkiaSharp. Copy and paste the following code into another cell:

```csharp {linenos=true}
int width = 1200;  
int height = 200;  
int step = 30; 

SKBitmap bmp = new(width, height); 
SKCanvas canvas = new(bmp);
canvas.Clear(SKColor.Parse("#fff")); 

SKPaint paint = new() 
{ 
    Color = SKColors.White.WithAlpha(100), 
    IsAntialias = true,
    StrokeWidth = 3,
    ColorF = SKColor.Parse("#003366")
};  

for (var i = step; i < height; i += step)
{
    for (var j = step; j < width; j += step)
    {
        SKPoint point = new(j, i);
        canvas.DrawPoint(point, paint);
    }   
}

// For saving the image as a file
using (SKFileWStream fs = new("image.jpg"))
{
    bmp.Encode(fs, SKEncodedImageFormat.Jpeg, quality: 50);
}
bmp.Display();
```
![Create New File](./matrix.png)

### Additional Information

For more details on the `SKBitmap` class and its usage, please refer to the official [Microsoft documentation on SKBitmap](https://learn.microsoft.com/en-us/dotnet/api/skiasharp.skbitmap).

By following these steps, you will have a basic setup for creating graphics with SkiaSharp in a Polyglot Notebook within VS Code. Enjoy exploring the powerful graphics capabilities of SkiaSharp!