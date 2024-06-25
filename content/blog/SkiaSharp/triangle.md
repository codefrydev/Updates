---
title: "Triangle Illusion in SkiaSharp"
author: "PrashantUnity"
weight: 102
date: 2024-06-23T00:00:00-07:00
lastmod: 2024-06-23T23:59:59-07:00
dateString: June 2024  
description: "In this Article I am Going To show you Code Snippet of how I used SkiaSharp to Generate basic Triangle Illusion"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Generate Thumbnail" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [  "C sharp", "SkiaSharp","Generate LOGO","Skia"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD", "SkiaSharp","Generate shapes","Skia","Triangle","Illusion"]
---


## Setup

```csharp
#r "nuget:SkiaSharp" 
using SkiaSharp;
```

### Triangle class

```csharp
public class Triangle
{
    public SKPoint A {get;set;}
    public SKPoint B {get;set;}
    public SKPoint C {get;set;}
}
```

### Triangle Point Helper

```csharp
List<Triangle> GetTrianglePoints(int count=10 ,float factor =0.25f,int baseLength=600)
{
    float length= baseLength;
    var a = new SKPoint((float)Math.Cos(Math.PI/3)*length,0);
    var b = new SKPoint(0,(float)Math.Sin(Math.PI/3)*length);
    var c = new SKPoint(length,(float)Math.Sin(Math.PI/3)*length);

    if(factor>1 || factor<0) factor=0.5f;
    float m= count*factor;
    float n= count-m;

    var ls = new List<Triangle>();
    ls.Add(new Triangle()
    {
        A=a,B=b,C=c
    });

    for(var i=0; i<count;i++)
    {
        var aa = new SKPoint((m*a.X + n*b.X)/count , (m*a.Y + n*b.Y)/count );
        var bb = new SKPoint((m*b.X + n*c.X)/count , (m*b.Y + n*c.Y)/count );
        var cc = new SKPoint((m*c.X + n*a.X)/count , (m*c.Y + n*a.Y)/count );

        var temp = new Triangle()
        {
            A = aa,
            B = bb,
            C = cc
        };
        ls.Add(temp);
        a=aa;
        b=bb;
        c=cc;
    }
    return ls;
}
```

```csharp
// Create an image and fill it blue
int width = 1200;
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

foreach(var item in GetTrianglePoints(10,.2f,700))
{
    //paint.ColorF = listOfColor[rand.Next(0,listOfColor.Count)];
    canvas.DrawLine(item.A,item.B,paint);
    canvas.DrawLine(item.B,item.C,paint);
    canvas.DrawLine(item.C,item.A,paint);
} 
SKFileWStream fs = new("triangleillusion.jpg");
bmp.Encode(fs, SKEncodedImageFormat.Jpeg, quality: 50);
bmp.Display();
```

![images](./triangleillusion.jpg)