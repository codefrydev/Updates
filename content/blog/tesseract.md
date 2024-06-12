---
title: "Tesseract For OCR "
author: "PrashantUnity"
weight: 100
date: 2024-06-10T11:57:15+05:30
dateString: June 2024  
description: "Tesseract OCR is one of the most popular open-source OCR libraries for text Extraction from image. It supports a wide range of languages and can recognize text from various image formats."
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "blog/tesserect_ocr.png" # image path/url
    alt: "Cover Page" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "OCR", "NET", "codefrydev", "C sharp","NET Core" ,".NET Framework" , "Optical Character Recognition"]
---

## Unlocking the Power of Optical Character Recognition with Tesseract

In Optical Character Recognition (OCR), [Tesseract OCR](https://github.com/tesseract-ocr/tesseract#center) stands out as a leading open-source library. Renowned for its extensive language support and ability to handle various image formats, Tesseract is a go-to choice for developers seeking to integrate text recognition capabilities into their applications.

---

## Key Features

### Supported Formats

Tesseract is adept at recognizing text from a multitude of image formats, including JPG, PNG, BMP, and more. This flexibility ensures it can be seamlessly integrated into diverse projects with varying image input requirements.

### Language Support

With support for numerous languages, Tesseract opens doors to global applications. Whether you’re working with English, French, Chinese, or other languages, Tesseract's robust language processing capabilities have got you covered.

### Customizability

One of Tesseract’s standout features is its extensibility. Developers can tailor the OCR process to fit specific needs, enhancing the library's base functionality to meet unique project requirements.

### Efficiency

Out of the box, Tesseract delivers an accuracy rate greater than 70%. With strategic image modifications, such as enhancing contrast, this accuracy can be significantly improved, making Tesseract a powerful tool for extracting text from images.

## System Requirements

To get started with Tesseract in .NET, ensure your development environment meets the following requirements:

- **Platform:** Compatible with Windows, Linux, and Mac.
- **SDK:** Requires the [.NET SDK](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks).
- **Code Editor:** Visual Studio 2022 (recommended) or any code editor of your choice.

## Getting Started: Cloning the Repository

To start using Tesseract OCR, clone the repository from GitHub:

```sh {linenos=true}
git clone https://github.com/codefrydev/OCR.git
```

## Usage Instructions

### Step-by-Step Guide

1. **Download or clone the project.**
2. **Select the appropriate project:**
    - For cross-platform development: **OCR.Tesseract.NetCore**
    - For Windows-specific projects: **OCR.Tesseract.NetFramework**
3. **Open the `Program.cs` file.**
4. **Provide the image path you want to work on.**
5. **Run the application.**

### Sample Code

Here's a quick example of how to use Tesseract to extract text from an image:

```csharp {linenos=true}
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

## Enhancing Performance

Improving the accuracy and performance of OCR can often be achieved through image preprocessing, such as adjusting the contrast. Below is an example of how to modify image contrast using C#:

### Sample Code for Modifying Image Contrast

```csharp {linenos=true}
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

By preprocessing images, you can significantly enhance the accuracy of the OCR process, making Tesseract even more powerful.

## Conclusion

Tesseract OCR is a versatile and robust open-source tool that supports multiple languages and formats. Whether you need to extract text from images for a cross-platform application or a Windows-specific project, Tesseract offers the flexibility and performance needed to get the job done. Enhance its capabilities with image preprocessing techniques to achieve even higher accuracy rates. Choose Tesseract for your next OCR project and experience the power of open-source text recognition.