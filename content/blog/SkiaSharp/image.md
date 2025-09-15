---
title: "Import and Use Images in SkiaSharp Canvas"
author: "PrashantUnity"
weight: 102
date: 2024-07-20T00:00:00-07:00
lastmod: 2024-07-20T23:59:59-07:00
dateString: JUl 2024  
description: "Learn how to import, load, and manipulate images in SkiaSharp canvas with file handling, scaling, and drawing techniques"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Generate Thumbnail" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [  "C sharp", "SkiaSharp","Use Image","Skia","Image"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD", "SkiaSharp","Use Image","Skia","Import Image"]
---

## Requirements

- VS Code with Polyglot Notebook
- .Net Installed

### Open VS Code

- create new File Image.ipynb

### Import SkiaSharp Library

- Open Image.ipynb File select .Net Interactive as Kernel
- Create cell inside File

```csharp
#r "nuget:SkiaSharp"
using SkiaSharp;
using System.IO;
```

### Image Drawer Function 

- Create New Cell and Paste below code

```csharp
void DrawImage(string path, SKCanvas canvas, float x = 0, float y = 0)
{
    using (var inputStream = File.OpenRead(path))
    {
        using (var inputBitmap = SKBitmap.Decode(inputStream))
        {
            var imageInfo = new SKImageInfo(inputBitmap.Width, inputBitmap.Height);
            canvas.DrawBitmap(inputBitmap, x , y);
        }
    }
}
```

### Skia SHarp Setup

```csharp
int width = 1280;
int height = 640; 
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
```

### Uses of Function Created earlier for Importing Image

```csharp
DrawImage("image.png", canvas,10, 10);

// For saving the image as a file
using (SKFileWStream fs = new("image.jpg"))
{
    bmp.Encode(fs, SKEncodedImageFormat.Jpeg, quality: 50);
}
bmp.Display()
```

That all needed to use image in SkiaSharp
