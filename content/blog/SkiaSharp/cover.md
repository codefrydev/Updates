---
title: "Creating Cover using Skia Sharp"
author: "PrashantUnity"
weight: 101
date: 2024-06-14T00:00:00-07:00
lastmod: 2024-06-14T23:59:59-07:00
dateString: June 2024  
description: "In this Article I am Going To Give you Code Snippet of how i Generate Cover Image for this Website Using SkiaSharp Library"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Generate Thumbnail" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "C sharp", "SkiaSharp","Generate Thumbnail","Skia"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD", "SkiaSharp","Generate Thumbnail","Skia"]
---


## Generate Thumbnail/Cover With SkiaSharp

Cover on this website is generated using SkiaSharp Only

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

#### Code To Generate Cover Or Thumbnail

```csharp  {linenos=true}
int width = 640;
int height = 220;  
int marginY = -10;
int marginX = -10;

string Numbering ="1";
string mainText ="SKIA SHARP";
string subText = "Generate Thumbnail | Polyglot Notebook";

string backGroundColor ="#003366";
string textColor = "#ffffff";
string boderColor = "#ffffff";
SKBitmap bmp = new(width, height);
SKCanvas canvas = new(bmp); 
canvas.Clear(SKColor.Parse(backGroundColor)); 
using (var paint = new SKPaint()) 
{
    paint.TextSize = width/ 10.0f;
    paint.IsAntialias = true;
    paint.Color = SKColor.Parse(textColor);
    paint.IsStroke = false;
    paint.StrokeWidth = 3; 
    paint.TextAlign = SKTextAlign.Center; 
    canvas.DrawText(mainText, width / 2f, height / 2f, paint);
    paint.TextSize = width/ 25.0f;
    paint.TextAlign = SKTextAlign.Right;
    canvas.DrawText(subText, width+marginX, height+marginY, paint);
    paint.TextSize = width/ 20.0f;
    canvas.DrawText(Numbering, (width/ 20.0f)*Numbering.Length,(width/ 20.0f)*1.25f, paint);
    paint.IsStroke = true;
    paint.TextAlign = SKTextAlign.Center;
    paint.Color = SKColor.Parse(textColor); 
}
SKFileWStream fs = new("cover.jpg");
bmp.Encode(fs, SKEncodedImageFormat.Jpeg, quality: 50);
bmp.Display(); 
``` 

![Create New File](./cover.jpg)