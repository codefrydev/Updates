---
title: "IMAGE TO PDF"
author: "PrashantUnity"
weight: 100
date: 2024-06-10T11:57:15+05:30
lastmod: 2024-06-20T23:59:59-07:00
dateString: June 2024  
description: "Step-by-Step Guide to Converting Images to PDF using VS Code and Polyglot Notebooks"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Image TO PDF Basic Cover" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [  "C sharp","PdfSharp","PDF","Image TO PDF","polyglot"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD", "PdfSharp","PDF","Image TO PDF","polyglot"]
---

## Steps

### Requirements

1. **Visual Studio Code (VS Code)**
2. **Polyglot Notebook Extension**

![Create New File](./poly.png)

3. **Basic Setup Knowledge**
   - Visit [Basic Setup]({{< relref "blog/csharp/hello-world-poly.md" >}}) for initial setup instructions.
4. Install .NET SDK If not Installed [**From Official Website**](https://dotnet.microsoft.com/en-us/download)

### File Setup

1. **Install Visual Studio Code**
   - If not already installed, download and install [VS Code](https://code.visualstudio.com/).

2. **Open the Folder with Your Image Files**
   - Navigate to the folder where your image files are located.

3. **Open Terminal in the Folder**
   - For Windows: Right-click in the folder, select "Show More Options," and then "Open in Terminal." Alternatively, type `cmd` in the folder path and press Enter.
   - In the terminal, type `code .` (code followed by a space and a period) to open VS Code in that folder.

   If the above methods don't work, search for VS Code in your PC's start menu and open it, then follow the live video for an alternative method:

{{< youtube EqD1H4T340A >}}


4. **Create a New Folder and Copy Image Files**
   - Create a new folder and copy all your image files into it.

5. **Create a New Polyglot Notebook File**
   - Create a new file with a name ending in either `.ipynb` or `.dib`.
   - Open the newly created file, then click on **Select Kernel** on the top right side of the file and choose **.NET Interactive**.

![Select Kernel](./select.png)

### Library Installation Setup

Copy and paste the following code into the first cell of your notebook:

```csharp {linenos=true}
#r "nuget: PdfSharp, 1.32.3057"
#r "nuget: System.Drawing.Common, 7.0.0"
```

### Main Program Code

1. **Add a New Code Cell**
   - Hover over the middle of the first cell until a "+ code" appears to add a new code cell. Click On Plus Code button

![Add New Cell](./cell.png)

2. **Copy and Paste the Main Program Code**

```csharp {linenos=true}
using System;
using System.Drawing;
using System.IO;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

// Function to convert PNG files to a single PDF
void ConvertPngsToPdf(string imageDirectory, string outputPdfFilePath)
{
    if (!Directory.Exists(imageDirectory))
    {
        Console.WriteLine($"Error: Input directory '{imageDirectory}' does not exist.");
        return;
    }

    try
    {
        // Create a new PDF document
        PdfDocument pdfDocument = new PdfDocument();

        // Get all PNG files in the input directory
        string[] pngFiles = Directory.GetFiles(imageDirectory, "*.*");
        //string[] pngFiles = Directory.GetFiles(imageDirectory, "*.png"); // for specific file type

        // for ordering Un COmment Below
        //pngFiles = pngFiles.OrderBy(x=>x)

        foreach (string pngFilePath in pngFiles)
        {
            // Create a new PDF page
            PdfPage pdfPage = pdfDocument.AddPage();

            // Load the PNG image
            using (XImage xImage = XImage.FromFile(pngFilePath))
            {
                // Adjust the page size to the image size
                pdfPage.Width = xImage.PixelWidth * 72 / xImage.HorizontalResolution;
                pdfPage.Height = xImage.PixelHeight * 72 / xImage.VerticalResolution;

                // Draw the image on the PDF page
                using (XGraphics graphics = XGraphics.FromPdfPage(pdfPage))
                {
                    graphics.DrawImage(xImage, 0, 0, pdfPage.Width, pdfPage.Height);
                }
            }

            Console.WriteLine($"Successfully added {pngFilePath} to PDF.");
        }
        pdfDocument.Save(outputPdfFilePath); 
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

// Define input and output paths
// replace below Path with Your Desired Path
string imageDirectory = @"C:\Users\Prashant\Desktop\Tutorials\PNGPDF\files";
string outputPdfFilePath = @"output.pdf";

// Call the function to convert PNGs to PDF
ConvertPngsToPdf(imageDirectory, outputPdfFilePath);
```

### Code Modifications

You need to modify the code at line numbers 22 and 59:

1. **Line 22: Specify Image Format**
   - Default Code:
     ```csharp
     string[] pngFiles = Directory.GetFiles(imageDirectory, "*.*");
     ```
   - Modified Code (for PNG files):
     ```csharp
     string[] pngFiles = Directory.GetFiles(imageDirectory, "*.png");
     ```

2. **Line 59: Specify Image Folder Path**
   - Replace the placeholder with your actual image folder path:
     ```csharp
     string imageDirectory = @"replace me with image Folder path"; 
     ```

### Run the Program

- Click on the **Run All** button at the top of the screen.

![Run All](./run.png)

After running the program, you should find a PDF file generated in your current directory.

### Live Demo of Code 

{{< youtube zpjJC6SCoBU >}}
