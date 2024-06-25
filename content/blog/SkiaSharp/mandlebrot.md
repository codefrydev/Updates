---
title: "Create mandlebrot using SkiaSharp"
author: "PrashantUnity"
weight: 102
date: 2024-06-18T00:00:00-07:00
lastmod: 2024-06-18T23:59:59-07:00
dateString: June 2024  
description: "In this Article I am Going To show you Code Snippet of how I used SkiaSharp to Generate mandlebrot"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Generate Thumbnail" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [  "C sharp", "SkiaSharp","Generate LOGO","Skia","mandlebrot"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD", "SkiaSharp","Generate shapes","Skia","mandlebrot"]
---

## Setup

```csharp
#r "nuget:SkiaSharp" 
using SkiaSharp;
```

### Mandlebrot

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
    StrokeWidth = 2,
    ColorF = SKColor.Parse("#003366")
};
 
double zoom = 1;
double moveX = -0.5;
double moveY = 0;
int maxIterations = 50;

for (int y = 0; y < height; y++)
{
    for (int x = 0; x < width; x++)
    {
        double zx = 1.5 * (x - width / 2) / (0.5 * zoom * width) + moveX;
        double zy = (y - height / 2) / (0.5 * zoom * height) + moveY;
        double cx = zx;
        double cy = zy;
        int iteration = 0;
        double tmp;

        while ((zx * zx + zy * zy < 4) && (iteration < maxIterations))
        {
            tmp = zx * zx - zy * zy + cx;
            zy = 2.0 * zx * zy + cy;
            zx = tmp;
            iteration++;
        }

        if (iteration == maxIterations)
        {
            canvas.DrawPoint(x, y, SKColors.Black);
        }
        else
        {
            // Colorize based on the number of iterations
            var color = SKColor.FromHsv(iteration % 256, 255, 255);
            canvas.DrawPoint(x, y, color);
        }
    }
}
SKFileWStream fs = new("mandlebrot.jpg");
bmp.Encode(fs, SKEncodedImageFormat.Jpeg, quality: 50);
bmp.Display();
```

![images](./mandlebrot.jpg)