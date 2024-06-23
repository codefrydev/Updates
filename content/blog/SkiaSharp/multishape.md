---
title: "Multishape in SkiaSharp"
author: "PrashantUnity"
weight: 102
dateString: June 2024  
description: "In this Article I am Going To show you Code Snippet of how I used SkiaSharp to Generate basic Multishape"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Generate Thumbnail" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [  "C sharp", "SkiaSharp","Generate LOGO","Skia"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD", "SkiaSharp","Generate shapes","Skia","Multishape"]
---


## Setup

```csharp
#r "nuget:SkiaSharp" 
using SkiaSharp;
```

### Color Sets

```csharp
var listOfColor = new List<SKColor>
{
    SKColor.Parse("#86B6F6"),
    SKColor.Parse("#176B87"),
    SKColor.Parse("#00A9FF"),
    SKColor.Parse("#FF90BC"),
    SKColor.Parse("#8ACDD7"),
    SKColor.Parse("#F2AFEF"),
    SKColor.Parse("#C499F3"),
    SKColor.Parse("#33186B"),
    
};
```

### Generate point on circumference of circle of different radius

```csharp
List<SKPoint> CirclePoints(int n,float radius=3,float x=0, float y=0 )
{ 
    float  degree = (float)(2*Math.PI/n);  
    return Enumerable
        .Range(1,n)
        .Select(i=>degree*i)
        .Select(i=>(new SKPoint(x+ radius *(float)Math.Cos(i), y+ radius *(float)Math.Sin(i))))
        .ToList();
}
```

### Section formulae Classic Geometric Formula To Calculate division point on line

```csharp
List<(SKPoint,SKPoint)> SectionFormulae(int times, List<SKPoint> points , float factor =0.25f)
{
    var ls = new List<(SKPoint,SKPoint)>();

    float m= times*factor;
    float n= times-m;

    for(var i=0; i<times;i++)
    { 
        var templs = new List<SKPoint>();

        for(var j=0;j<points.Count;j++)
        {
            if(j==points.Count-1)
            {
                var x = (m*points[j].X + n*points[0].X)/times;
                var y = (m*points[j].Y + n*points[0].Y)/times;
                templs.Add(new SKPoint(x,y));
            }
            else
            {
                var x = (m*points[j].X + n*points[j+1].X)/times;
                var y = (m*points[j].Y + n*points[j+1].Y)/times;
                templs.Add(new SKPoint(x,y));
            }
        }
        points = templs;
        for(var j=0;j<points.Count;j++)
        {
            if(j==points.Count-1)
            {
                ls.Add((points[j],points[0]));
            }
            else
            {
                ls.Add((points[j],points[j+1]));
            }
        }
    }


    return ls;
}
```

### Granullar Function for more Control Over Shapes

```csharp
public List<(SKPoint,SKPoint)> GetShape(int n=3, int times=6 ,float factor =0.25f,int baseLength=600,int centerX =0,int centerY=0)
{ 
    return SectionFormulae(times,CirclePoints(n,baseLength,x:centerX,y:centerY),factor);
}
```

### Skiasharp Codde to Use All above Function and Generate Shapes

```
// Create an image and fill it blue
int width = 2000;
int height = 2000;

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
int seperation=4;
for(var i=3;i<=15;i+=3)
{
    paint.Color=listOfColor[rand.Next(0,listOfColor.Count)];
    foreach(var item in GetShape(n:i,times:25, factor:0.08f, baseLength:seperation* i*i,centerX:width/2,centerY:height/2))
    {
        canvas.DrawLine(item.Item1,item.Item2,paint);
    }
}

// Save the image to disk
SKFileWStream fs = new("multishape.jpg");
bmp.Encode(fs, SKEncodedImageFormat.Jpeg, quality: 100); 
bmp.Display();
```

![images](./MultiShapes.jpg)
