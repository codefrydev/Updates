---
title: "Create Basic Geometry Shape in SkiaSharp"
author: "PrashantUnity"
weight: 102
date: 2024-06-22T00:00:00-07:00
lastmod: 2024-06-22T23:59:59-07:00
dateString: June 2024  
description: "Learn how to create basic geometric shapes using SkiaSharp including circles, rectangles, triangles, and polygons with custom styling"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Generate Thumbnail" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [  "C sharp", "SkiaSharp","Generate LOGO","Skia"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD", "SkiaSharp","Generate shapes","Skia","geometry"]
---


## Setup

```csharp
#r "nuget:SkiaSharp" 
using SkiaSharp;
```

### Circle

```csharp
int width = 1200;
int height = 250;
SKBitmap bmp = new(width, height);
SKCanvas canvas = new(bmp);

canvas.Clear(SKColor.Parse("#fff"));

Random rand = new(0);
SKPaint paint = new() 
{ 
    Color = SKColors.White.WithAlpha(100), 
    IsAntialias = true ,
    StrokeWidth = 4,
    ColorF = SKColor.Parse("#003366"),
    Style = SKPaintStyle.Stroke
}; 
   
canvas.DrawCircle(110,110,100,paint); // hollow Circle

paint.Style = SKPaintStyle.StrokeAndFill;
canvas.DrawCircle(410,110,100,paint); // Follow Circle
bmp.Display();
```

![images](./circle.jpg)

### Line

```csharp
int width = 1200;
int height = 20;
SKBitmap bmp = new(width, height);
SKCanvas canvas = new(bmp);

canvas.Clear(SKColor.Parse("#fff"));

Random rand = new(0);
SKPaint paint = new() 
{ 
    Color = SKColors.White.WithAlpha(100), 
    IsAntialias = true ,
    StrokeWidth = 4,
    ColorF = SKColor.Parse("#003366")
}; 
   
SKPoint pointOne = new (0,10);
SKPoint pointTwo = new (width,10);  
canvas.DrawLine(pointOne,pointTwo,paint);  
bmp.Display();
```

![images](./line.jpg)

### Triangle

```csharp
// Create an image and fill it blue
int width = 1920;
int height = 1080;

int step =50;
SKBitmap bmp = new(width, height);
SKCanvas canvas = new(bmp);

canvas.Clear(SKColor.Parse("#fff"));

Random rand = new();
SKPaint paint = new() 
{ 
    Color = SKColors.White.WithAlpha(100), 
    IsAntialias = true ,
    StrokeWidth = 10,
    ColorF = SKColor.Parse("#F2AFEF")
};
int offset=10;
var a = new SKPoint()
{
    X=width/2,Y=offset
};
var b = new SKPoint()
{
    X=offset,Y= height/2
};
var c = new SKPoint()
{
    X=width/2,Y=height/2
};
SKPath path = new SKPath();
path.AddPoly(new SKPoint[]{a,b,c},true); 
 
canvas.DrawPath(path,paint);
SKFileWStream fs = new("triangle.jpg");
bmp.Encode(fs, SKEncodedImageFormat.Jpeg, quality: 50);
bmp.Display();
```

![images](./triangle.jpg)

### Rectangle

```csharp
int width = 1200;
int height = 100;
SKBitmap bmp = new(width, height);
SKCanvas canvas = new(bmp);

canvas.Clear(SKColor.Parse("#fff"));

Random rand = new(0);
SKPaint paint = new() 
{ 
    Color = SKColors.White.WithAlpha(100), 
    IsAntialias = true ,
    StrokeWidth = 4,
    ColorF = SKColor.Parse("#003366"),
    Style = SKPaintStyle.Stroke
};   
canvas.DrawRect(5,5,100,60,paint);  
bmp.Display();
```

![images](./rect.jpg)

### Rect Matrix

```csharp
int width = 1200;
int height = 100;
SKBitmap bmp = new(width, height);
SKCanvas canvas = new(bmp);

canvas.Clear(SKColor.Parse("#fff"));

Random rand = new(0);
SKPaint paint = new() 
{ 
    Color = SKColors.White.WithAlpha(100), 
    IsAntialias = true ,
    StrokeWidth = 4,
    ColorF = SKColor.Parse("#003366"),
    Style = SKPaintStyle.Stroke
};   

float step=6*(width/height);
var circlDrawn = false;
for(float j=-height; j<height;j+=step)
{
    for(float i=-width; i<width;i+=step)
    {
        var x = i+width/2;
        var y = j+height/2;
        canvas.DrawRect(x,y,step,step,paint); 
        //canvas.DrawRoundRect(i,j,step,step,5,5,paint);
        i+=step; 
    } 
    j+=step;
}
SKFileWStream fs = new("rectmatrix.jpg");
bmp.Encode(fs, SKEncodedImageFormat.Jpeg, quality: 50);
bmp.Display();
```

![images](./rectmatrix.jpg)

### Dot Matrix And One Circle at center

```csharp
int width = 1200;
int height = 100;
SKBitmap bmp = new(width, height);
SKCanvas canvas = new(bmp);

canvas.Clear(SKColor.Parse("#fff"));

Random rand = new(0);
SKPaint paint = new() 
{ 
    Color = SKColors.White.WithAlpha(100), 
    IsAntialias = true ,
    StrokeWidth = 4,
    ColorF = SKColor.Parse("#003366"),
    Style = SKPaintStyle.Stroke
};    
float step=6*(width/height);
var circlDrawn = false;
for(float j=-height; j<height;j+=step)
{
    for(float i=-width; i<width;i+=step)
    {
        var x = i+width/2;
        var y = j+height/2;
        canvas.DrawPoint(x,y,paint);  
        i+=step; 
    } 
    j+=step;
}  
paint.IsStroke=false;
canvas.DrawCircle(width/2,height/2,100,paint);
SKFileWStream fs = new("circlematrix.jpg");
bmp.Encode(fs, SKEncodedImageFormat.Jpeg, quality: 50);
bmp.Display();
```

![images](./circlematrix.jpg)