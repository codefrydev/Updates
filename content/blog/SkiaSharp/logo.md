---
title: "Generating CFD Logo using Skia Sharp"
author: "PrashantUnity"
weight: 102
date: 2024-06-17T00:00:00-07:00
lastmod: 2024-06-17T23:59:59-07:00
dateString: June 2024  
description: "Learn how to create custom logos using SkiaSharp with step-by-step guide to generating the CodeFryDev logo with text, shapes, and styling"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Generate Thumbnail" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [  "C sharp", "SkiaSharp","Generate LOGO","Skia"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD", "SkiaSharp","Generate LOGO","Skia"]
---


## Creating Logos with SkiaSharp

LOGO on this website is generated using SkiaSharp Only

### Requirements

- **Visual Studio Code (VS Code)**
- **Polyglot Notebook Extension**
  - ![Create New File](./poly.png)
- **A little bit of experience in C#**
- For Basic/Installation please visit [Basic Setup]({{< relref "blog/skiasharp/basic.md" >}})

#### Code

##### Install SkiaSharp

```csharp  {linenos=true}
#r "nuget:SkiaSharp"
```

#### Import SkiaSharp Library

```csharp  {linenos=true}
using SkiaSharp;
```

#### Code To Generate Logo

Logo Dimention and Stuff

```csharp {linenos=true}
int width=700;
int height=700;
int step = 30;  
float textSize =128f;
string fontFamilyName = "Arial";
string LogoText ="<CFD/>";
float shiftX=150;
float dividerX=2.0f;
float shiftY=38;
float dividerY=3.0f; 
var left=width/dividerX -shiftX;
var top=height/dividerY -shiftY;
var right= textSize*3.95f;
var bottom=textSize*4f;

float targetWidth = 800;  // desired width
float targetHeight = 800; // desired height
float offsetX = 800;       // horizontal offset
float offsetY = 800;
```

Vapor Structure Path

```csharp {linenos=true}
float targetWidth = 200;  // desired width
float targetHeight = 200; // desired height

string pathData = "M68.0627 60.6519C68.3821 54.8593 73.1743 46 73.1743 46C73.1743 46 71.2574 55.5407 71.5769 60.6519C71.8964 65.763 72.5354 65.0815 73.4938 68.8296C74.4522 72.5778 73.8133 74.2815 73.4938 77.0074C73.1743 79.7333 72.8549 80.0741 72.2159 83.4815C71.5769 86.8889 69.9795 92 69.9795 92C69.9795 92 70.299 84.3333 70.299 81.437C70.299 78.5407 70.6185 74.6222 69.6601 70.5333C68.7017 66.4444 67.7432 66.4444 68.0627 60.6519Z M99.9582 38.7481C99.7452 30.9407 96.5504 19 96.5504 19C96.5504 19 97.8284 31.8593 97.6154 38.7481C97.4024 45.637 96.9764 44.7185 96.3375 49.7704C95.6985 54.8222 96.1245 57.1185 96.3375 60.7926C96.5505 64.4667 96.7634 64.9259 97.1894 69.5185C97.6154 74.1111 98.6803 81 98.6803 81C98.6803 81 98.4673 70.6667 98.4673 66.763C98.4673 62.8593 98.2544 57.5778 98.8933 52.0667C99.5322 46.5556 100.171 46.5556 99.9582 38.7481Z M118.042 64.7407C118.255 59.7037 121.45 52 121.45 52C121.45 52 120.172 60.2963 120.385 64.7407C120.598 69.1852 121.024 68.5926 121.663 71.8519C122.301 75.1111 121.876 76.5926 121.663 78.963C121.45 81.3333 121.237 81.6296 120.811 84.5926C120.385 87.5556 119.32 92 119.32 92C119.32 92 119.533 85.3333 119.533 82.8148C119.533 80.2963 119.746 76.8889 119.107 73.3333C118.468 69.7778 117.829 69.7778 118.042 64.7407Z";
// Create a path object from the SVG path data
SKPath path = SKPath.ParseSvgPathData(pathData);

// Get the bounds of the original path
SKRect pathBounds = path.Bounds;
float offsetX = width/2.5f-pathBounds.Width;       // horizontal offset
float offsetY = 50; 
// Calculate scaling factors
float scaleX = targetWidth / pathBounds.Width;
float scaleY = targetHeight / pathBounds.Height;

// Create a transformation matrix for scaling and translation
SKMatrix matrix = SKMatrix.CreateScale(scaleX, scaleY);
matrix.TransX = offsetX - (pathBounds.Left * scaleX);
matrix.TransY = offsetY - (pathBounds.Top * scaleY);

// Transform the path using the matrix
path.Transform(matrix);
```

Finnaly Use of SKCanvas and SKBitmap to Generate Image.

```csharp  {linenos=true}
SKBitmap bmp = new(width, height);
SKCanvas canvas = new(bmp);
canvas.Clear(SKColor.Parse("#fff")); 
SKPaint paint = new() 
{ 
    Color = SKColors.White.WithAlpha(100), 
    IsAntialias = true ,
    StrokeWidth = 3,
    ColorF = SKColor.Parse("#000"),
    TextSize=textSize,
    TextAlign=SKTextAlign.Center,
    Typeface = SKTypeface.FromFamilyName(fontFamilyName, SKFontStyle.Bold)
};    

canvas.DrawText(LogoText,width/2.0f,height/2.0f,paint); 
canvas.DrawPath(path,paint);
var skrect = new SKRect(left,top,right,bottom);
canvas.DrawArc(skrect,0,180,true,paint);
SKFileWStream fs = new("cover.jpg");
bmp.Encode(fs, SKEncodedImageFormat.Jpeg, quality: 50);
bmp.Display();
``` 

![Create New File](./logo.jpg)