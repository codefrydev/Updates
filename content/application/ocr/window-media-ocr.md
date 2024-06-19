---
title: "Window Media OCR library For OCR "
author: "PrashantUnity"
weight: 100
date: 2024-06-10T11:57:15+05:30
dateString: June 2024  
description: "Windows Media OCR, extracted from Microsoft's PowerToys repository, provides a powerful solution for text recognition by leveraging the capabilities of the Windows operating system. In this blog, we'll guide you through setting up and using Windows Media OCR in your projects."
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Cover Page" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "OCR", "NET", "C sharp", "Optical Character Recognition"]
keywords: [ "OCR", "NET", "codefrydev", "C sharp","NET Core" ,".NET Framework" , "Optical Character Recognition"]
draft: false
---
## Windows Media OCR

Windows Media OCR is a powerful tool for extracting text from images, derived from Microsoft's popular [PowerToys repository](https://github.com/microsoft/PowerToys). This tool leverages Windows' built-in capabilities, making text recognition efficient and seamless for Windows 10 and above. In this post/Article, I'll show you how to get started with Windows Media OCR and integrate it into your projects.

## Getting Started

First, you need to clone the repository to your local machine. Use the following command:

```sh {linenos=true}
git clone https://github.com/codefrydev/OCR.git
```

Next, let's look at a simple example of how to use Windows Media OCR. Here’s a `Program.cs` file example from **OCR.WindowMediaOcr.NetCore**:

```cs {linenos=true}
internal class Program
{
    static void Main()
    {
        Console.WriteLine(Extract.ExtractText("imagetwo.jpg"));
    }
}
```

### Key Features

- **Supported Formats**: Works with various image formats recognized by Windows.
- **Compatibility**: Designed for Windows 10 and above.
- **Integration**: Easily integrates into Windows applications for smooth text recognition.

### Requirements

To ensure your project works with Windows Media OCR, make sure it targets Windows 10 or above. Additionally, you’ll need to install the following NuGet packages:

```xml {linenos=true}
<ItemGroup>
    <PackageReference Include="Microsoft.Windows.CsWinRT" />
    <PackageReference Include="System.ComponentModel.Composition" />
    <PackageReference Include="System.Drawing.Common" Version="8.0.6" />
    <PackageReference Include="System.Windows.Extensions" Version="8.0.0" />
    <PackageReference Include="WPF-UI" />
</ItemGroup>
```

### Why Choose Windows Media OCR?

Windows Media OCR is an excellent choice because it integrates well with the Windows operating system, supports multiple image formats, and ensures compatibility with modern Windows applications. Its ease of integration and reliable performance make it a top pick for developers looking to add OCR capabilities to their projects.

### Conclusion

Windows Media OCR is a robust tool for text recognition, offering seamless integration with Windows applications and support for various image formats. By following the steps outlined in this blog, you can quickly set up and start using Windows Media OCR in your projects. This will unlock new possibilities for digitizing documents, automating workflows, and improving accessibility.

Start using Windows Media OCR today and see how it can enhance your applications!

For more information and to access the repository, visit the [PowerToys GitHub page](https://github.com/microsoft/PowerToys).