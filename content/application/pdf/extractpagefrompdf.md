---
title: "Extract page from PDF"
author: "PrashantUnity"
weight: 100
date: 2024-06-10T11:57:15+05:30
lastmod: 2024-06-22T23:59:59-07:00
dateString: June 2024  
description: "Step-by-Step Guide to Converting Images to PDF using VS Code and Polyglot Notebooks"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Image TO PDF Basic Cover" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [  "C sharp","PdfSharp","PDF","Image TO PDF","polyglot"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD", "PdfSharp","PDF","Image TO PDF","polyglot"]
draft: true
---

```csharp
#r "nuget: itextsharp, 5.5.13.2"

using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

public class PdfExtractor
{
    public static void ExtractPage(string sourcePdfPath, string outputPdfPath, int pageNumber)
    {
        using (PdfReader reader = new PdfReader(sourcePdfPath))
        {
            using (Document document = new Document())
            {
                using (PdfCopy pdfCopy = new PdfCopy(document, new FileStream(outputPdfPath, FileMode.Create)))
                {
                    document.Open();
                    pdfCopy.AddPage(pdfCopy.GetImportedPage(reader, pageNumber));
                    document.Close();
                }
            }
        }
    }
}

// Define the paths and page number
string sourcePdfPath = "source.pdf"; // Path to the source PDF
string outputPdfPath = "output.pdf"; // Path to the output PDF
int pageNumber = 2; // Page number to extract (1-based index)

// Extract the page
PdfExtractor.ExtractPage(sourcePdfPath, outputPdfPath, pageNumber);
Console.WriteLine("Page extracted successfully!");
```
