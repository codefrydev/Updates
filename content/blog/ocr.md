---
title: "Tesseract OCR "
weight: 100
date: 2024-06-10T11:57:15+05:30
tags: [ "OCR", "NET", "codefrydev", "C sharp","NET Core" ,".NET Framework" , "Optical Character Recognition"]
author: "PrashantUnity"
cover:
    image: "blog/tesserect_ocr.png"
showToc: true 
description: "Tesseract OCR is one of the most popular open-source OCR libraries for text Extraction from image. It supports a wide range of languages and can recognize text from various image formats."
#canonicalURL: "https://canonical.url/to/page"
disableHLJS: true # to disable highlightjs
disableShare: false
disableHLJS: false 
ShowReadingTime: true     
cover:
    image: "blog/tesserect_ocr.png" # image path/url
    alt: "Cover Page" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 
---

# Optical Character Recognition Using Tesseract

[Tesseract OCR](https://github.com/tesseract-ocr/tesseract) is one of the most popular open-source OCR libraries. It supports a wide range of languages and can recognize text from various image formats.

---

## Features

- **Supported Formats:** Multiple image formats (JPG, PNG, BMP, etc.).
- **Languages:** Supports multiple languages.
- **Extensibility:** Highly customizable and extensible.
- **Efficiency:** Greater than 70% accuracy, which can be increased by image modification.

## Requirements

- **Platform:** Windows, Linux, Mac
- **SDK:** [.NET SDK](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks)
- **Code Editor:** Visual Studio 2022 and above (recommended) or any code editor of your choice

## Source Code

Clone the repository:

```sh
git clone https://github.com/codefrydev/OCR.git
```

## Usage

1. Download or clone the project.
2. Select the appropriate project:
    - Cross Platform: **OCR.Tesseract.NetCore**
    - Windows: **OCR.Tesseract.NetFramework**
3. Open the **Program.cs** file.
4. Provide the image path you want to work on.
5. Run the application.

### Sample Code

```cs
static readonly string imagePath = "imagetwo.jpg";
static string extractedTextImageSharp = string.Empty;

using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.LstmOnly))
{
    using var img = Pix.LoadFromFile(imagePath);
    using var page = engine.Process(img);
    extractedTextImageSharp = page.GetText();
} 
Console.WriteLine(extractedTextImageSharp);
```

## Improving Performance

You can enhance performance by modifying the image contrast before extracting text. Below is a sample code snippet for modifying image contrast.

### Sample Code for Modifying Image Contrast

```cs
static void ImagSharpMethod(string path)
{
    using (Image<Rgba32> image = Image.Load<Rgba32>(path))
    {
        image.Mutate(x => x.Resize(image.Width * times, image.Height * times));
        // Iterate through each pixel
        for (int y = 0; y < image.Height; y++)
        {
            for (int x = 0; x < image.Width; x++)
            {
                // Get the pixel color
                Rgba32 pixelColor = image[x, y];

                // Check if the pixel color matches the target colors
                if (IsTargetColor(pixelColor))
                {
                    // Set to absolute white
                    image[x, y] = Rgba32.ParseHex("#fff");
                }
            }
        }
            
        // Save the modified image
        image.Save(modifiedImagePath);
    } 
}
static bool IsTargetColor(Rgba32 color)
{ 

    // Blue and light blue range
    if (color.B > 128 && color.R < 128 && color.G < 128)
        return true;

    // Grey range
    if (color.R > 128 && color.R < 200 && color.G > 128 && color.G < 200 && color.B > 128 && color.B < 200) return true;

    // Yellow range
    if (color.R > 200 && color.G > 200 && color.B < 128)
        return true;

    // Add more color checks as needed

    return false;
}
```

## Conclusion

Tesseract OCR is a versatile open-source option supporting multiple languages and formats. Choose the one that best fits your project's requirements.