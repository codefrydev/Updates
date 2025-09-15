---
title: "Google Lens OCR Integration in .NET"
author: "PrashantUnity"
weight: 100
date: 2024-06-15T00:00:00-07:00
lastmod: 2024-06-15T23:59:59-07:00
dateString: June 2024  
description: "Learn how to integrate Google Lens OCR into .NET applications for free text extraction from images without requiring Google account authentication"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Cover Page" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "OCR","Google lens" , "C sharp", "Optical Character Recognition"]
keywords: [ "OCR","Google lens" ,"NET", "codefrydev", "C sharp","NET Core" ,".NET Framework" , "Optical Character Recognition"]
---

## Harness the Power of Google Lens OCR in .NET Core and .NET Framework

Extracting text from images is a handy tool for many tasks, like digitizing documents, automating data entry, and improving accessibility. Google Lens OCR, now available for both .NET Core and .NET Framework, makes this process easy and accurate. Google Lens OCR is derived from the **[Chrome Lens OCR project ](https://github.com/dimdenGD/chrome-lens-ocr)**, this library is a powerful tool for developers. In this post, I'll show you how to set it up and use it in your projects.

## Getting Started

First things first, you’ll need to clone the repository to your local machine. This project is hosted on GitHub and can be easily cloned using the following command:

```sh {linenos=true}
git clone https://github.com/codefrydev/OCR.git
```

Once you have the repository, you can proceed with the following steps to integrate Google Lens OCR into your project.
### Setting Up the Environment

To get started with Google Lens OCR in your .NET project, follow these steps:

1. **Install .NET Core/Framework**:
   Ensure you have .NET Core or .NET Framework installed on your machine. You can download it from the official [Microsoft .NET website](https://dotnet.microsoft.com/download). 

### Usage Instructions

1. **Download the Project**:
   Start by downloading or cloning the repository as mentioned above.

2. **Select Your Choice of Project**: Open **Program.cs** file of **OCR.GoogleLens.NetCore** or **OCR.GoogleLens.NetFramework** based on  your project. This file contains the main implementation where you will provide the path to the image you want to process.

3. **Provide Image Path**:
   Specify the path of the image file (only JPG format is supported) that you want to perform OCR on.

4. **Run the Application**:
   Execute the application to see the OCR results.

## Implementing Google Lens OCR

Here’s a quick snippet to get you started with Google Lens OCR in a .NET environment:

```cs {linenos=true}
var path = "imagetwo.jpg";  
var extract = new Core();
var result = await extract.ScanByFileAsync(path);
foreach (var item in result)
{
    Console.Out.WriteLine(item);
}
```

### Key Features

- **Supported Formats**: The library currently supports only the JPG format, ensuring a streamlined and optimized OCR process.
- **Accuracy**: Google Lens OCR provides highly accurate text recognition, making it reliable for various applications.
- **Compatibility**: The library is compatible with both .NET Core and .NET Framework, offering flexibility for different development environments.
- **As Library** : Delete Progrma.cs file of Goole Lens project and chage project type to Class Library i.e. in Visual Studio 2022 Right Click on project and change application type to Class Library

![properties](./lensprop.png)
![application](./lenswhere.png)
![option](./lenstype.png)

## Why Choose Google Lens OCR?

Google Lens OCR stands out due to its accuracy and ease of use. By leveraging Google’s advanced machine learning algorithms, this library ensures precise text extraction, even from complex images. Moreover, its seamless integration with .NET Core and .NET Framework means you can use it across a wide range of applications, from web services to desktop applications.


### Conclusion

Google Lens OCR provides a robust solution for text recognition, making it an invaluable tool for developers. By integrating this library into your .NET Core or .NET Framework projects, you can enhance your applications with powerful OCR capabilities. Whether you’re digitizing documents, automating workflows, or creating accessible content, Google Lens OCR is the tool you need.

Start leveraging the power of Google Lens OCR in your projects today and experience the difference it can make!

For more details and to access the repository, visit the **[Google Lens OCR GitHub page](https://github.com/codefrydev/OCR)**.