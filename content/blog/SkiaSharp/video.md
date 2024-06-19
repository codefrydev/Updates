---
title: "Getting Started With Skia Sharp To Generate Video"
author: "PrashantUnity"
weight: 103
dateString: June 2024  
description: "SkiaSharp is a cross-platform 2D graphics API for .NET platforms based on Google's Skia Graphics Library. It provides a comprehensive 2D API that can be used across mobile, server and desktop models to render images."
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Skia Sharp Basic Cover" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "NET", "codefrydev", "C sharp", "CFD", "Skia Sharp","Generate Video","Basic","FFMPEG"]
draft: true
---


## Generate Video With SkiaSharp and FFMPEG 

### Requirements

- **Visual Studio Code (VS Code)**
- **Polyglot Notebook Extension**
  - ![Create New File](./poly.png)
- **A little bit of experience in C#**
- For Basic/Installation please visit [Basic Setup]({{< relref "blog/skiasharp/basic.md" >}})

#### Code

##### Install SkiaSharp and FFMPEG

```csharp {linenos=true}
#r "nuget: SkiaSharp, 2.88.7"
#r "nuget: FFMpegCore, 5.1.0"
```

##### Import namespaces

```csharp {linenos=true}
using FFMpegCore;
using FFMpegCore.Pipes;
using SkiaSharp;
using System.IO;
using System;
using System.Threading;
```

##### Fixed Class Which you generally don't need to changhe anything

```csharp {linenos=true}
internal class SKBitmapFrame : IVideoFrame, IDisposable
{
    public int Width => Source.Width;
    public int Height => Source.Height;
    public string Format => "bgra";

    private readonly SKBitmap Source;

    public SKBitmapFrame(SKBitmap bmp)
    {
        if (bmp.ColorType != SKColorType.Bgra8888)
            throw new NotImplementedException("only 'bgra' color type is supported");
        Source = bmp;
    }

    public void Dispose() =>
        Source.Dispose();

    public void Serialize(Stream pipe) =>
        pipe.Write(Source.Bytes, 0, Source.Bytes.Length);

    public Task SerializeAsync(Stream pipe, CancellationToken token) =>
        pipe.WriteAsync(Source.Bytes, 0, Source.Bytes.Length, token);
        
}
```

##### In this section you have to code what you want to show inside for loop

```csharp {linenos=true}
IEnumerable<IVideoFrame> CreateFrames(int count, int width, int height)
{
    using SKFont textFont = new(SKTypeface.FromFamilyName("consolas"), size: 32);
    using SKPaint textPaint = new(textFont) { Color = SKColors.Yellow, TextAlign = SKTextAlign.Center };
    using SKPaint rectanglePaint = new() { Color = SKColors.Green, Style = SKPaintStyle.Fill };
    SKColor backgroundColor = SKColors.Navy;

    for (int i = 0; i < count; i++)
    {
        // draw what ever you want for each frame 
        // using for proper disposal otherwise very buggy
        using SKBitmap bmp = new(width, height);
        using SKCanvas canvas = new(bmp);
        
        canvas.Clear(backgroundColor); 
        canvas.DrawText($"{i}", bmp.Width / 2, bmp.Height * .6f, textPaint);

        using SKBitmapFrame frame = new(bmp);
        yield return frame;
    }
}
```

#### Additional Configuration

>codec mpeg4 created output.mp4 that worked in media player but not on browser

>codec libx264 created output.mp4 that worked in my browser not in media player

>codec libvpx-vp9 created output.webm that worked everywhere 

##### Also here you don't have to change anything just provide number of frame, width and height of video.

```csharp {linenos=true}
var frames = CreateFrames(count: 150, width: 400, height: 300);
RawVideoPipeSource videoFramesSource = new(frames) { FrameRate = 30 };
bool success = FFMpegArguments
    .FromPipeInput(videoFramesSource)
    .OutputToFile("output.mp4", overwrite: true, options => options.WithVideoCodec("mpeg4"))
    .ProcessSynchronously();
```
