---
title: "Create Maze using SkiaSharp"
author: "PrashantUnity"
weight: 102
date: 2024-06-19T00:00:00-07:00
lastmod: 2024-06-19T23:59:59-07:00
dateString: June 2024  
description: "Learn how to generate procedural mazes using C# and SkiaSharp with recursive backtracking algorithms and visual rendering"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Generate Thumbnail" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [  "C sharp", "SkiaSharp","Generate LOGO","Skia","maze"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD", "SkiaSharp","Generate shapes","Skia","maze"]
---


## Setup

```csharp
#r "nuget:SkiaSharp" 
using SkiaSharp;
```

### Maze Algorithm

```csharp
public class MazeAlgorithm
{
    Random random = new Random();

    public int[,] GenerateMaze(int rows, int cols)
    {
        int[,] maze = new int[rows, cols];

        // Initialize maze with walls
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                maze[i, j] = 1;
            }
        }

        // Set starting point
        maze[1, 1] = 0;

        DFS(maze, 1, 1);

        return maze;
    }

    void DFS(int[,] maze, int row, int col)
    {
        int[] directions = { 1, 2, 3, 4 };
        Shuffle(directions);

        foreach (int dir in directions)
        {
            int[] dRow = { 0, 0, 1, -1 };
            int[] dCol = { 1, -1, 0, 0 };

            int newRow = row + 2 * dRow[dir - 1];
            int newCol = col + 2 * dCol[dir - 1];

            if (newRow > 0 && newRow < maze.GetLength(0) - 1 &&
                newCol > 0 && newCol < maze.GetLength(1) - 1 &&
                maze[newRow, newCol] == 1)
            {
                maze[row + dRow[dir - 1], col + dCol[dir - 1]] = 0;
                maze[newRow, newCol] = 0;

                DFS(maze, newRow, newCol);
            }
        }
    }

    void Shuffle(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n; i++)
        {
            int r = i + random.Next(n - i);
            int temp = array[r];
            array[r] = array[i];
            array[i] = temp;
        }
    }
}
```


### Skia Sharp To Utilise maze Algorithm and Generate Maze Image

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
int m= width/step, n=height/step;
var ls = (new MazeAlgorithm()).GenerateMaze(m,n);
ls[0,1]=0;
for(var i=0; i<m;i++)
{
    for(var j=0; j<n;j++)
    {
        paint.ColorF=(ls[i,j]==0)?SKColor.Parse("#ffffff"):SKColor.Parse("#000000");
        canvas.DrawRect(i*step,j*step,step,step,paint);
    }
}
SKFileWStream fs = new("maze.jpg");
bmp.Encode(fs, SKEncodedImageFormat.Jpeg, quality: 50);
bmp.Display();
```

![images](./maze.jpg)