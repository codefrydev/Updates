---
title: "Mosaic in SkiaSharp"
author: "PrashantUnity"
weight: 102
date: 2024-06-20T00:00:00-07:00
lastmod: 2024-06-20T23:59:59-07:00
dateString: June 2024  
description: "Learn how to create mosaic patterns using SkiaSharp with geometric shapes, color variations, and artistic tile arrangements"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Generate Thumbnail" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [  "C sharp", "SkiaSharp","Generate LOGO","Skia"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD", "SkiaSharp","Generate shapes","Skia","Mosaic"]
---


## Setup

```csharp
#r "nuget:SkiaSharp" 
using SkiaSharp;
```

### Mosaic Generation Code 

```csharp
// Create an image and fill it blue
int width = 1920;
int height = 700;

int step =50;
SKBitmap bmp = new(width, height);
SKCanvas canvas = new(bmp);

canvas.Clear(SKColor.Parse("#fff"));

Random rand = new();
SKPaint paint = new() 
{ 
    Color = SKColors.White.WithAlpha(100), 
    IsAntialias = true ,
    StrokeWidth = 2,
    ColorF = SKColor.Parse("#003366")
};

for(var i=0; i<height;i+=step)
{
    for(var j=0; j<width;j+=step)
    {

        if(rand.Next(0,100)>50)
            paint.ColorF =SKColor.Parse("#003366");
        else paint.Color =SKColor.Parse("#000f");
        canvas.DrawRect(i,j,step,step,paint);
    }
}
SKFileWStream fs = new("mosaic.jpg");
bmp.Encode(fs, SKEncodedImageFormat.Jpeg, quality: 50);
bmp.Display();
```

![images](./mosaic.jpg)