---
title: "Circle and Points And Lines"
author: "PrashantUnity"
weight: 104
date: 2024-08-03
lastmod: 2024-08-03
dateString: August 2024  
description: "Dynamically Generating Bunch of Circle and line and Points on Canvass"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Generate Thumbnail" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [  "CSharp", "SkiaSharp","Polygon","Trigonometry"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD", "SkiaSharp","Trigonometry","Polygon","Math"]
---

## Importing Skiasharp Library from nuget package

```csharp
#r "nuget:SkiaSharp"
```

### Importing namespace to use Skia library

```csharp
using SkiaSharp;
```

### Points On circle

- This function will calculate points on circle and return as list of Points
- I Depends on number of points we wants to find out on circle 
- Radius of Circle r
- Center of circle where is it located (x, y)

```csharp
SKPoint[] CirclePoints(int n,float radius=3,float x=0, float y=0 )
{ 
    float  degree = (float)(2*Math.PI/n);  
    return Enumerable
        .Range(1,n)
        .Select(i=>degree*i)
        .Select(i=>(new SKPoint(x+ radius *(float)Math.Cos(i), y+ radius *(float)Math.Sin(i))))
        .ToArray();
}
```

### Line points

- This Function will first Get all points on circle
- Then pair the all point with each other  as Line Segment Require two Cordinate points one starting point and other end

```csharp
List<(SKPoint,SKPoint)> GetAllLinePoints(int n,int radius=3,float x=0, float y=0 )
{
    var arr =CirclePoints(n:n,x:x,y:y, radius:radius);
    var ls = new List<(SKPoint, SKPoint)>();

    for(var i =0; i<arr.Length; i++)
    {
        for(var j=i+1; j<arr.Length;j++)
        {
            ls.Add((arr[i],arr[j]));
        }
    }
    return ls;
}
```

### All Circle

- This Function will give us all circular points

```csharp
List<(float X,float Y)> GetCenter(int m, int n,int radius=60)
{
    var ls =new List<(float X,float Y)>();  
    int X = radius*3;
    int Y = radius*3;
    for(var i=1; i<m;i++)
    {
        for(var j=1; j<n;j++)
        {
            ls.Add((Y*i,X*j));
        }
    }
    return ls;
}
```

### List of random Precalculated hex value

```csharp
var listOfColor = new List<SKColor>
{
    SKColor.Parse("#EEF5FF"),
    SKColor.Parse("#B4D4FF"),
    SKColor.Parse("#86B6F6"),
    SKColor.Parse("#176B87"),
    SKColor.Parse("#00A9FF"),
    SKColor.Parse("#89CFF3"),
    SKColor.Parse("#A0E9FF"),
    SKColor.Parse("#CDF5FD"),
    SKColor.Parse("#FF90BC"),
    SKColor.Parse("#FFC0D9"),
    SKColor.Parse("#F9F9E0"),
    SKColor.Parse("#8ACDD7"),
    SKColor.Parse("#F2AFEF"),
    SKColor.Parse("#C499F3"),
    SKColor.Parse("#33186B"),
    
};
```

## Final Code to ustiliase all above function
```csharp
// Image size (pixels)
int WIDTH = 1920; 
int radius =60;
 
Random random = new Random();
SKBitmap bmp = new(1280, WIDTH);
SKCanvas canvas = new(bmp);
canvas.Clear(SKColor.Parse("#fff")); 

SKPaint paint = new() 
{ 
    Color = SKColors.White.WithAlpha(100), 
    IsAntialias = true ,
    StrokeWidth = 1,
    ColorF = SKColor.Parse("#000000"),
    Style = SKPaintStyle.Stroke
};   

var ls = GetCenter(10,7,radius);
for(var n=3;n<=26;n++)
{
    float X = ls[n-3].Y;
    float Y = ls[n-3].X;
    paint.ColorF =listOfColor[random.Next(0,listOfColor.Count)];
    foreach(var i in GetAllLinePoints(n:n,x:X,y:Y, radius:radius))
    { 
        canvas.DrawLine(i.Item1,i.Item2,paint);
        canvas.DrawText($"{n} Points",X-20,Y+80,paint);
    }
    canvas.DrawCircle(X,Y,60,paint);
}
bmp.Display()
```
- Image Generated using above Code 

![Result](./result.jpg)