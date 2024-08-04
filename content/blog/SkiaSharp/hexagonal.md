---
title: "Generating a Hexagonal Grid with SkiaSharp in C#"
author: "PrashantUnity"
weight: 102
date: 2024-08-03
lastmod: 2024-08-03
dateString: August 2024  
description: "This guide explains how to generate a hexagonal grid using the SkiaSharp library in C#. It covers the basic concepts of hexagon geometry, provides functions to calculate hexagon points from a single coordinate, and demonstrates how to draw a complete hexagonal grid on a canvas. The tutorial includes code snippets and explanations to ensure the implementation is easily understandable and modifiable by reader."
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Generate Thumbnail" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [  "CSharp", "SkiaSharp","Hexagon","Hexagonal Grid"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD", "SkiaSharp","Hexagon","Hexagonal Grid","Skia"]
---


## Concept

- A hexagon consists of six vertices.
- Given one vertex coordinate, we can find all other vertices as the angle between two edges is 120 degrees.
- Consider a starting point **(x, y)** and the width of an edge **b**.
- The right neighbor points will be **(x + b, y)**.
- The right neighbor of the right neighbor will be **(x + b + b * Cos(60), y + b * Sin(60))** and so on.

### Example

![Hexagon Points](./hexagon.png)

## Code Implementation

### SkiaSharp Setup

- Refer to the [SkiaSharp setup guide]({{< relref "blog/skiasharp/basic.md" >}})

### Importing Skiasharp Library

```csharp
#r "nuget:SkiaSharp"
```

### Importing name space

```csharp
using SkiaSharp;
using System.Collections.Generic;

```

### Function to Get Hexagon Points from a Single Coordinate

```csharp
SKPoint[] GetPoints(float x, float y,float width)
{
    var ls = new List<SKPoint>();

    ls.Add(new SKPoint(x                 ,y));
    ls.Add(new SKPoint(x + width         ,y));
    ls.Add(new SKPoint(x + width +width/2,y + width*MathF.Sqrt(3)/2));
    ls.Add(new SKPoint(x + width         ,y + width*MathF.Sqrt(3))); 
    ls.Add(new SKPoint(x                 ,y + width*MathF.Sqrt(3))); 
    ls.Add(new SKPoint(x - width/2       ,y + width*MathF.Sqrt(3)/2)); 
    ls.Add(new SKPoint(x,y));
    return ls.ToArray();
}
```

## Function to Get Next Starting Point

```csharp
(float,float) GetNextPoint(float x, float y, float width)
{
    return (x + width +width/2,y + width*MathF.Sqrt(3)/2);
}
```

- This function calculates the next starting coordinate from **(x, y)**.

![Hexagone points](./nextpoint.png)

- So we will have two starting point
- both will come alternatively
- Below Code Generate the possible points

```csharp
int width = 1200;
int height = 750;
int step =60;
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
 var ls = GetPoints(width/5,height/3,200); 
var skpath = new SKPath();
skpath.AddPoly(ls); 
canvas.DrawPath(skpath,paint);

paint.TextSize = 48f;
canvas.DrawText($"(x,y)",ls[0],paint);
canvas.DrawText($"(x + (w)*3/2, y + (w)*sqrt(3)/2)",ls[2],paint);

canvas.DrawText($"(x + (w)*3/2, y + 0)",(ls[0].X +200*(3.0f/2)),ls[0].Y,paint);

bmp.Display();

```

![Hexagone points](./points.jpg)

## final Code

- I am Drawing hexagonal Shape in vertically fashion
- Line number 22 that is while loop is for width of image Horizontaly
- Line number 37 for vertically for height

- Line Number 25 to 36 will deside next verticall starting cordinate points.

```csharp
int width = 1200;
int height = 750;
int step = 60;
SKBitmap bmp = new(width, height);
SKCanvas canvas = new(bmp);

canvas.Clear(SKColor.Parse("#fff"));

SKPaint paint = new()
{
    IsAntialias = true,
    StrokeWidth = 4,
    Color = SKColor.Parse("#003366"),
    Style = SKPaintStyle.Stroke
};

float incrementY = step * MathF.Sqrt(3);
bool displaceY = false;
float i = 0;

while (i < width)
{
    float y = 0;
    if (!displaceY)
    {
        var (nextX, nextY) = GetNextPoint(i, 0, step);
        y = nextY;
        i = nextX;
    }
    else
    {
        y = 0;
        i += step * 1.5f;
    }

    for (float j = y; j < height; j += incrementY)
    {
        var points = GetPoints(i, j, step);
        var path = new SKPath();
        path.AddPoly(points);
        canvas.DrawPath(path, paint);
    }

    displaceY = !displaceY;
}

bmp.Display();
```

### Explanation

1. **Canvas Setup**: Initializes a canvas with a specified width and height, and clears it with a white background.
2. **Paint Setup**: Configures the paint with desired properties such as color, stroke width, and style.
3. **Hexagon Generation**:
    - Calculates the vertical increment (`incrementY`) based on the step size.
    - Uses a `while` loop to iterate horizontally across the canvas.
    - Uses a nested `for` loop to iterate vertically and draw hexagons.
    - Alternates the starting Y-coordinate to create a staggered hexagon grid.

### Result

The above code generates a hexagonal grid pattern as shown in the image below:

![Hexagone points](./grid.jpg)
