---
title: "Trigonometry Table"
author: "PrashantUnity"
weight: 102
date: 2024-08-03
lastmod: 2024-08-03
dateString: August 2024  
description: ""
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Generate Thumbnail" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [  "CSharp", "SkiaSharp","Hexagon","Trigonometry table"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD", "SkiaSharp","Trigonometry table","Trigonometry","Math"]
---

## Concept

- Trignonometry Table

![Trignonometry Table](./trig.jpg)

- Code used to Generate Above Table
```csharp

int width = 1500;
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
paint.TextSize = 48f;
string backGroundColor ="#fff";
canvas.Clear(SKColor.Parse(backGroundColor));
paint.Style = SKPaintStyle.Fill;
string trignometricTable = "Trigonometry Table";
string root = "\u221A";
string theta ="\u03B8";
string degree ="\u00B0";
string inf ="\u221E";
var ls = new List<List<string>>();
ls.Add(["",$"0{degree}",$"30{degree}",$"45{degree}",$"60{degree}",$"90{degree}"]);
ls.Add([$"Sin{theta}",$"0",$"1/2",$"1/{root}2",$"({root}3)/2",$"1",]);
ls.Add([$"Cos{theta}",$"1",$"({root}3)/2",$"1/{root}2",$"1/2",$"0",]);
ls.Add([$"Tan{theta}",$"0",$"1/{root}3",$"1",$"{root}3",$"{inf}",]);
ls.Add([$"Cosec{theta}",$"{inf}",$"2",$"{root}2",$"2/{root}3",$"1",]);
ls.Add([$"Sec{theta}",$"1",$"2/{root}3",$"{root}2",$"2",$"{inf}",]);
ls.Add([$"Cot{theta}",$"{inf}",$"{root}3",$"1",$"1/{root}3",$"0",]);



float shifx =150;
float shify =120;

float verticalMax = 600  + shify;
float horizontalMax = 1200  + shifx;

for(var i=shify; i<height; i+=100)
{
    canvas.DrawLine(shifx,i,horizontalMax,i,paint);
}

for(var i=shifx; i<width; i+=200)
{
   canvas.DrawLine(i,shify,i,verticalMax,paint);    
}

paint.TextAlign = SKTextAlign.Center;

canvas.DrawText(trignometricTable,width/2,100,paint);


float y =200;
foreach(var i in ls)
{
    float x =shifx+100;
    foreach(var j in i)
    {
        canvas.DrawText(j,x,y,paint);
        x+=200;
    }
    y+=100;
}
bmp.Display();
```

```csharp
int width = 1500;
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
paint.TextSize = 48f;
string backGroundColor ="#fff";
canvas.Clear(SKColor.Parse(backGroundColor));
paint.Style = SKPaintStyle.Stroke;

var skPath = new SKPath();

float diagonal = 600;
float rX = 150;
float rXX = rX + diagonal*MathF.Sqrt(3)/2;
float rY = 150;
float rYY = rY +diagonal/2;

SKPoint[] rt = [new SKPoint(rX,rY),new SKPoint(rX,rYY),new SKPoint(rXX,rYY)];
float aX = width/2;
float aY = 300;

canvas.DrawText("1",rX-30,(rY+rYY)/2 ,paint);

canvas.DrawText("2",(rX+rXX)/2,(rY+rYY)/2 -10 ,paint);


canvas.DrawText("\u221A3",(rX+rXX)*1/2.5f,rYY +50 ,paint);

var skpath = new SKPath();
skpath.AddPoly(rt);
canvas.DrawPath(skpath,paint); 
bmp.Display();
```

![Trignonometry Table](./sign.jpg)