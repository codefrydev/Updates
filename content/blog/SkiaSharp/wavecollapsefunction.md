---
title: "Wave Collapse Function"
author: "PrashantUnity"
weight: 99
date: 2024-07-20T00:00:00-07:00
lastmod: 2024-07-20T23:59:59-07:00
dateString: JUl 2024  
description: "Discover how to make beautiful designs using the Wave Collapse Function. Inspired by quantum mechanics, this algorithm turns a grid of possibilities into cool patterns. We’ll use C# and SkiaSharp to show you how to bring these patterns to life. Join us and learn how to create art from randomness!"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Generate Thumbnail" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [  "C sharp", "SkiaSharp","Use Image","Skia","Image"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD", "SkiaSharp","Use Image","Skia","Import Image"]
---

## Concept

Image as Bunch of small box placed at different position

- Take example of Below Image

<style>
.grid-container {
  display: grid;
  grid-template-columns: repeat(8, 66px); /* 64px for image + 2px for border */
  gap: 0;
}

.grid-item img {
  width: 64px;
  height: 64px;
  object-fit: cover;
  display: block;
  border: 1px solid black; /* Black border around each image */
  box-sizing: border-box; /* Includes border in the element's total width and height */
}
</style>

<div class="grid-container">
    <div class="grid-item"><img src="./TL.png" alt="TL.png" ></div>
    <div class="grid-item"><img src="./LRB.png" alt="LRB.png" ></div>
    <div class="grid-item"><img src="./LR.png" alt="LR.png" ></div>
    <div class="grid-item"><img src="./L.png" alt="L.png" ></div>
    <div class="grid-item"><img src="./SL.png" alt="SL.png" ></div>
    <div class="grid-item"><img src="./LRTB.png" alt="LRTB.png" ></div>
    <div class="grid-item"><img src="./TR.png" alt="TR.png" ></div>
    <div class="grid-item"><img src="./B.png" alt="B.png" ></div>
    <div class="grid-item"><img src="./STR.png" alt="STR.png" ></div>
    <div class="grid-item"><img src="./TLR.png" alt="TLR.png" ></div>
    <div class="grid-item"><img src="./TBR.png" alt="TBR.png" ></div>
    <div class="grid-item"><img src="./TB.png" alt="TB.png" ></div>
    <div class="grid-item"><img src="./TBL.png" alt="TBL.png" ></div>
    <div class="grid-item"><img src="./BTL.png" alt="BTL.png" ></div>
    <div class="grid-item"><img src="./T.png" alt="T.png" ></div>
</div>  

- We have each image with 4 sides
- Now Think How is one image can be connected with other image
- Take First image as an example
    - It Has two opening and two close side.
    - Lets make opening as **1** and close as **0**
    - So we Have four side Left right Top Bottom
        - L : 0
        - R : 1
        - T : 0
        - B : 1
    - Now 1 Image can be Connected to right side by any image which have opening in left side.
    - So Possible condidate are 
        - 2 , 3 , 4 , 6, 7, 10, 11, 14
    - We can Choose randomly any element from possible

- That's the main Logic Similarly can be applied to all other elements





## Applying Above Concept

Requiements

- VS Code
- Skia Sharp
- C# as Programming language
- Image used in for this project
<a href="./asset.zip" download>
**Download Images**
</a>

## Code behind

### Import Skia Library

```csharp
#r "nuget:SkiaSharp"
using SkiaSharp;
using System.IO;
```

### Model class for each Cell

Creating Model For holding each Image case data like side open or Close and location image

```csharp
public class Entity
{
    public int L { get; set; } = -1;
    public int R { get; set; } = -1;
    public int T { get; set; } = -1;
    public int B { get; set; } = -1;
    public string Path { get; set; } = string.Empty;
}
```

### Base Directory where all image file will be located

Location of parent folder where image is located

```csharp
var baseDir = @"C:\Users\Prashant\Downloads\demo\WCF\Assets\road";
```

### Creation Model Relation for each image

Creating model for each image with opening data where it is open and close and location of file

```csharp
List<Entity> listOfEntity =
[
    new()
    {
        Path = Path.Combine(baseDir,"B.png"),
        B =1,
        L =0,
        T =0,
        R =0
    },
    new()
    {
        Path = Path.Combine(baseDir,"BTL.png"),
        B =0,
        L =1,
        T =1,
        R =0
    },
    new()
    {
        Path = Path.Combine(baseDir,"L.png"),
        B =0,
        L =1,
        T =0,
        R =0
    },
    new()
    {
        Path = Path.Combine(baseDir,"LR.png"),
        B =0,
        L =1,
        T =0,
        R =1
    },
    new()
    {
        Path = Path.Combine(baseDir,"LRB.png"),
        B =1,
        L =1,
        T =0,
        R =1
    },
    new()
    {
        Path = Path.Combine(baseDir,"LRTB.png"),
        B =1,
        L =1,
        T =1,
        R =1
    },
    new()
    {
        Path = Path.Combine(baseDir,"SL.png"),
        B =0,
        L =0,
        T =0,
        R =1
    },
    new()
    {
        Path = Path.Combine(baseDir,"STR.png"),
        B =0,
        L =0,
        T =1,
        R =1
    },
    new()
    {
        Path = Path.Combine(baseDir,"T.png"),
        B =0,
        L =0,
        T =1,
        R =0
    },
    new()
    {
        Path = Path.Combine(baseDir,"TB.png"),
        B =1,
        L =0,
        T =1,
        R =0
    },
    new()
    {
        Path = Path.Combine(baseDir,"TBL.png"),
        B =1,
        L =0,
        T =1,
        R =1
    },
    new()
    {
        Path = Path.Combine(baseDir,"TBR.png"),
        B =1,
        L =1,
        T =1,
        R =0
    },
    new()
    {
        Path = Path.Combine(baseDir,"TL.png"),
        B =1,
        L =0,
        T =0,
        R =1
    },
    new()
    {
        Path = Path.Combine(baseDir,"TLR.png"),
        B =0,
        L =1,
        T =1,
        R =1
    },
    new()
    {
        Path = Path.Combine(baseDir,"TR.png"),
        B =1,
        L =1,
        T =0,
        R =0
    }

];
```

### Fisher Yeats Suffling to Randomise Data

```csharp
void SuffeledArray<T>(List<T> array)
{
    var rand = new Random();
    for (int i = 0; i < array.Count; i++)
    {
        var randIndex = rand.Next(i, array.Count);
        var tempItem = array[randIndex];
        array[randIndex] = array[i];
        array[i] = tempItem;
    }
}
```

### Draw Image on SKCanvas Function

```csharp
void DrawImage(string path, SKCanvas canvas, float x = 0, float y = 0)
{
    using (var inputStream = File.OpenRead(path))
    {
        using (var inputBitmap = SKBitmap.Decode(inputStream))
        {
            var imageInfo = new SKImageInfo(inputBitmap.Width, inputBitmap.Height);
            canvas.DrawBitmap(inputBitmap, x * 64, y * 64);
        }
    }
}
```

### Find Matching neighobours and return on randomise element

```csharp
Entity FindEntity(int x, int y ,List<List<Entity>> matrix)
{
    var ls = new List<Entity>();
    foreach (var item in listOfEntity)
    {
        if (x == 0 )
        { 
            if( item.L == matrix[x][y-1].R && item.T !=1)
            {
                ls.Add(item); 
            } 
        }
        else
        {
            if(y==0)
            {
                if (item.T == matrix[x - 1][y].B && item.L !=1)
                {
                    ls.Add(item);
                }
            }
            else if(item.T == matrix[x - 1][y].B && item.L == matrix[x][y-1].R)
            {
                ls.Add(item);
            }
        }
    }
    
    SuffeledArray(ls);
    return ls.First();
}
```

## Setpuing SkCanvas and Calling All Other methods 

```csharp

int width = 2560;
int height = 1280;
int step = 64;
Random random = new();
SKBitmap bmp = new(width, height);
SKCanvas canvas = new(bmp);
canvas.Clear(SKColor.Parse("#fff"));
SKPaint paint = new()
{
    Color = SKColors.White.WithAlpha(100),
    IsAntialias = true,
    StrokeWidth = 3,
    ColorF = SKColor.Parse("#003366")
};
var matrix = new List<List<Entity>>();
for(var i =0; i<height;i+=step)
{
    var cell = new List<Entity>();
    for(var j=0;j<width;j+=step) 
    {
        cell.Add(new());
    }
    matrix.Add(cell);
}
for (int i = 0; i < matrix.Count; i++)
{
    for (int j = 0; j < matrix[0].Count; j++)
    {
        if(i==0 && j==0)
        {
            matrix[0][0].Path = Path.Combine(baseDir, "TL.png");
            matrix[0][0].L = 0;
            matrix[0][0].R = 1;
            matrix[0][0].B = 1;
            matrix[0][0].T = 0;
            DrawImage(matrix[0][0].Path, canvas, j, i);
            continue;
        }
        matrix[i][j] = FindEntity(i, j,matrix);
        DrawImage(matrix[i][j].Path, canvas, j, i);
    }
}
// For saving the image as a file
using (SKFileWStream fs = new("image.jpg"))
{
    bmp.Encode(fs, SKEncodedImageFormat.Jpeg, quality: 50);
}
bmp.Display()

```
