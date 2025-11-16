---
title: "Generate QR Code in .NET Applications"
author: "PrashantUnity"
weight: 106
date: 2025-11-16
lastmod: 2025-11-16
dateString: November 2024  
description: "Generate QR Code in .NET Applications for dynamic data type. for any type of data."
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "NET", "codefrydev", "C sharp", "CFD", "QRCode","QR Code","Generate","Generate QR Code"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD", "QRCode","QR Code","Generate","Generate QR Code"]
---


## Generate QR Code in .NET Applications

This comprehensive guide demonstrates how to create beautiful, customizable QR codes in .NET applications. We'll build a QR code generator with advanced features including:

- **Gradient coloring** - Apply color gradients to QR code modules
- **Rounded dots** - Replace standard squares with rounded circles for a modern look
- **Center logo** - Embed logos with automatic sizing and contrast enhancement
- **Footer text** - Add descriptive text below the QR code
- **UPI payment integration** - Generate UPI URIs for Indian payment systems
- **High error correction** - Ensure QR codes remain scannable even with partial obstruction
- **Base64 encoding** - Easy embedding in web applications and documents

### Prerequisites

You'll need:

- .NET 8 or later
- A .NET interactive environment (e.g., Polyglot Notebooks in VS Code)
- Basic C# knowledge


### Import Required NuGet Packages

This section covers the NuGet packages needed to generate fancy QR codes with logos and styling. Polyglot Notebooks allows us to reference packages directly in code cells:

- **SkiaSharp**: Advanced image processing and rendering library for creating graphics
- **ZXing.Net**: Cross-platform barcode encoding library for generating QR codes
- **Markdig**: Markdown parser and renderer for converting Markdown to HTML

```csharp
#r "nuget: SkiaSharp, 3.119.2-preview.1"
#r "nuget: ZXing.Net, 0.16.11"
#r "nuget: Markdig, 0.43.0"
```

### UPI QR Code Generation with Fancy Styling

### Import Namespaces

```csharp
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.Rendering;
using SkiaSharp;  
```

### UPI URI Builder and Fancy QR Generator

```csharp
public static class UpiUriBuilder
{
    /// <summary>
    /// Builds a properly formatted UPI URI string from payment information.
    /// The URI follows the UPI specification for mobile payments in India.
    /// </summary>
    /// <param name="info">Payment information containing VPA, amount, and other details</param>
    /// <returns>A formatted UPI URI string (e.g., upi://pay?pa=...&pn=...)</returns>
    public static string Build(UpiPaymentInfo info)
    {
        // Build query parameters with percent-encoding for special characters
        var query = new List<string>();

        if (!string.IsNullOrWhiteSpace(info.Upid))
            query.Add($"pa={UrlEncode(info.Upid)}");
        if (!string.IsNullOrWhiteSpace(info.PayeeName))
            query.Add($"pn={UrlEncode(info.PayeeName)}");
        if (info.Amount.HasValue)
            query.Add($"am={info.Amount.Value.ToString("0.00")}");
        if (!string.IsNullOrWhiteSpace(info.Note))
            query.Add($"tn={UrlEncode(info.Note)}");
        if (!string.IsNullOrWhiteSpace(info.TransactionId))
            query.Add($"tr={UrlEncode(info.TransactionId)}");
        if (!string.IsNullOrWhiteSpace(info.MerchantCode))
            query.Add($"mc={UrlEncode(info.MerchantCode)}");

        // Currency defaults to INR as per UPI specification
        query.Add("cu=INR");

        string q = string.Join("&", query);
        return $"upi://pay?{q}";
    }

    /// <summary>
    /// URL encodes a string using percent-encoding for safe transmission in query parameters.
    /// </summary>
    /// <param name="value">The string to encode</param>
    /// <returns>The percent-encoded string</returns>
    private static string UrlEncode(string value)
    {
        // Uri.EscapeDataString is the safe method for encoding query string components
        return Uri.EscapeDataString(value ?? string.Empty);
    }
}

public class UpiPaymentInfo
{
    /// <summary>
    /// Virtual Payment Address (VPA) - unique identifier for UPI transactions
    /// </summary>
    public string Upid { get; set; }
    
    /// <summary>
    /// Name of the payment recipient
    /// </summary>
    public string PayeeName { get; set; }
    
    /// <summary>
    /// Transaction amount in INR (optional)
    /// </summary>
    public decimal? Amount { get; set; }
    
    /// <summary>
    /// Transaction note or description (optional)
    /// </summary>
    public string Note { get; set; }
    
    /// <summary>
    /// Unique transaction reference ID (optional)
    /// </summary>
    public string TransactionId { get; set; }
    
    /// <summary>
    /// Merchant category code (optional)
    /// </summary>
    public string MerchantCode { get; set; }
    
    /// <summary>
    /// Payment due date (optional)
    /// </summary>
    public DateTime? DueDate { get; set; }
}

public static class FancyQrGenerator
{
    /// <summary>
    /// Generates a fancy QR code with gradient coloring, rounded dots, optional center logo, and footer text.
    /// </summary>
    /// <param name="qrText">The text or URI to encode in the QR code</param>
    /// <param name="logoStream">Optional image stream for center logo (PNG, JPG supported)</param>
    /// <param name="footerText">Optional text to display below the QR code</param>
    /// <param name="size">Canvas size in pixels (default 600px)</param>
    /// <returns>PNG image as Base64-encoded string for easy embedding</returns>
    public static string GenerateBase64(
        string qrText,
        Stream logoStream = null,
        string footerText = null,
        int size = 600)
    {
        int paddingForText = 80;
        int canvasHeight = size + paddingForText;

        // Generate QR code pixel data with high error correction level
        // This allows up to 30% of the QR code to be obscured and still readable
        var writer = new BarcodeWriterPixelData
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Width = size,
                Height = size,
                Margin = 4, // quiet zone in modules (standard is 1-4 modules)
                ErrorCorrection = ZXing.QrCode.Internal.ErrorCorrectionLevel.H
            }
        };

        PixelData pixelData = writer.Write(qrText);

        // Convert pixel bitmap to module matrix for precise rendering
        var moduleMatrix = PixelDataToModuleMatrix(pixelData, out int moduleCount, out int modulePixelSize);

        // Create Skia surface for drawing
        using var surface = SKSurface.Create(new SKImageInfo(size, canvasHeight));
        var canvas = surface.Canvas;
        canvas.Clear(SKColors.White);

        // Create gradient shader (purple to cyan) for visual appeal
        var shader = SKShader.CreateLinearGradient(
            new SKPoint(0, 0),
            new SKPoint(size, size),
            new SKColor[] { SKColor.Parse("#5A00FF"), SKColor.Parse("#00C2FF") },
            null,
            SKShaderTileMode.Clamp);

        var gradientPaint = new SKPaint
        {
            IsAntialias = true,
            Shader = shader
        };

        float cellSize = size / (float)moduleCount;
        float radius = cellSize * 0.45f; // radius of rounded dots

        // Detect margin modules (quiet zone) by finding first dark module
        int minX = moduleCount, minY = moduleCount;
        for (int y = 0; y < moduleCount; y++)
            for (int x = 0; x < moduleCount; x++)
                if (moduleMatrix[x, y])
                {
                    if (x < minX) minX = x;
                    if (y < minY) minY = y;
                }
        int marginModules = Math.Min(minX, minY);

        // QR code finder patterns are 7x7 modules in the three corners
        int finderSize = 7;
        var finders = new (int fx, int fy)[]
        {
            (marginModules, marginModules), // top-left
            (moduleCount - marginModules - finderSize, marginModules), // top-right
            (marginModules, moduleCount - marginModules - finderSize)  // bottom-left
        };

        // Paint for crisp finder squares (no antialiasing for clean edges)
        var squarePaint = new SKPaint { IsAntialias = false, Shader = shader };

        // Draw all modules - finder patterns as squares, data modules as circles
        for (int my = 0; my < moduleCount; my++)
        {
            for (int mx = 0; mx < moduleCount; mx++)
            {
                if (!moduleMatrix[mx, my]) continue;

                // Check if module is part of a finder pattern
                bool inFinder = finders.Any(f => mx >= f.fx && mx < f.fx + finderSize && my >= f.fy && my < f.fy + finderSize);

                float left = mx * cellSize;
                float top = my * cellSize;
                if (inFinder)
                {
                    // Finder patterns remain as squares for scanning accuracy
                    canvas.DrawRect(new SKRect(left, top, left + cellSize, top + cellSize), squarePaint);
                }
                else
                {
                    // Regular data modules drawn as rounded circles
                    float cx = left + cellSize / 2f;
                    float cy = top + cellSize / 2f;
                    canvas.DrawCircle(cx, cy, radius, gradientPaint);
                }
            }
        }

        // Draw center logo if provided
        if (logoStream != null)
        {
            if (logoStream.CanSeek) logoStream.Seek(0, SeekOrigin.Begin);
            SKBitmap logoBitmap = null;
            try
            {
                logoBitmap = SKBitmap.Decode(logoStream);
            }
            catch
            {
                // Silently ignore decode errors; logoBitmap remains null
            }

            if (logoBitmap != null)
            {
                int logoSize = Math.Max(16, size / 5); // approximately 20% of QR width
                using var resized = logoBitmap.Resize(new SKImageInfo(logoSize, logoSize), SKSamplingOptions.Default);
                float lx = (size - logoSize) / 2f;
                float ly = (size - logoSize) / 2f;

                // Draw white rounded background for logo contrast
                var bgPaint = new SKPaint { Color = SKColors.White, IsAntialias = true };
                canvas.DrawRoundRect(new SKRect(lx - 8, ly - 8, lx + logoSize + 8, ly + logoSize + 8), 20, 20, bgPaint);

                if (resized != null)
                    canvas.DrawBitmap(resized, lx, ly);
                else
                    canvas.DrawBitmap(logoBitmap, (size - logoBitmap.Width) / 2f, (size - logoBitmap.Height) / 2f);
            }
        }

        // Draw footer text below QR code
        if (!string.IsNullOrWhiteSpace(footerText))
        {
            var font = new SKFont(SKTypeface.FromFamilyName("Arial", SKFontStyle.Bold), 36);
            var textPaint = new SKPaint
            {
                IsAntialias = true,
                Color = SKColors.Black,
            };
            textPaint.TextAlign = SKTextAlign.Center;

            float textY = size + (paddingForText / 2f) + (font.Size / 2f) - 6;
            canvas.DrawText(footerText, size / 2f, textY, font, textPaint);
        }

        // Encode to PNG and return as Base64
        using var image = surface.Snapshot();
        using var data = image.Encode(SKEncodedImageFormat.Png, 100);
        byte[] bytes = data.ToArray();
        return Convert.ToBase64String(bytes);
    }

    /// <summary>
    /// Converts ZXing PixelData bitmap to a boolean module matrix for rendering.
    /// Detects the module count and pixel size automatically.
    /// </summary>
    /// <param name="pd">PixelData from ZXing barcode writer</param>
    /// <param name="moduleCount">Output: number of modules per row/column</param>
    /// <param name="modulePixelSize">Output: pixels per module</param>
    /// <returns>2D boolean array where true = dark module, false = light module</returns>
    private static bool[,] PixelDataToModuleMatrix(PixelData pd, out int moduleCount, out int modulePixelSize)
    {
        int w = pd.Width;
        int h = pd.Height;
        var pixels = pd.Pixels;

        // Helper function to determine if a pixel is dark (luminance < 128)
        bool IsDark(int x, int y)
        {
            int idx = (y * w + x) * 4;
            if (idx + 2 >= pixels.Length) return false;
            byte r = pixels[idx], g = pixels[idx + 1], b = pixels[idx + 2];
            int lum = (r * 299 + g * 587 + b * 114) / 1000;
            return lum < 128;
        }

        // Analyze central row to determine module pixel size by finding run lengths
        int row = h / 2;
        var rowB = new bool[w];
        for (int x = 0; x < w; x++) rowB[x] = IsDark(x, row);

        var runs = new List<int>();
        int run = 1;
        for (int x = 1; x < w; x++)
        {
            if (rowB[x] == rowB[x - 1]) run++;
            else { runs.Add(run); run = 1; }
        }
        runs.Add(run);

        modulePixelSize = runs.Count > 0 ? Math.Max(1, runs.Min()) : 1;
        moduleCount = Math.Max(1, w / modulePixelSize);

        // Create module matrix by sampling center of each module
        var matrix = new bool[moduleCount, moduleCount];
        for (int my = 0; my < moduleCount; my++)
        {
            for (int mx = 0; mx < moduleCount; mx++)
            {
                int sx = mx * modulePixelSize + modulePixelSize / 2;
                int sy = my * modulePixelSize + modulePixelSize / 2;
                if (sx >= w) sx = Math.Max(0, mx * modulePixelSize);
                if (sy >= h) sy = Math.Max(0, my * modulePixelSize);
                matrix[mx, my] = IsDark(sx, sy);
            }
        }

        return matrix;
    }
}
```

### Generate UPI QR Code with Logo and Footer Text

This section demonstrates how to generate a complete UPI QR code with a logo image and text footer:

```csharp
// Demo UPI payment information
var info = new UpiPaymentInfo
{
    Upid = "ipad@apl",
    PayeeName = "PrashantUnity",
    Amount = 180m,
    Note = "Payment Invoice #55",
    TransactionId = "INV-55"
};

// Build UPI URI string from payment info
string upiUri = UpiUriBuilder.Build(info);
Console.WriteLine("UPI URI:");
Console.WriteLine(upiUri);

// Load logo image (optional). Replace with your PNG/JPG path or set to null to skip
string logoPath = "/Volumes/External/SourceCode/CodingPractice/twitter.jpg";
Stream logoStream = null;
if (File.Exists(logoPath))
{
    logoStream = File.OpenRead(logoPath);
}

// Generate fancy QR code as Base64-encoded PNG
string base64 = FancyQrGenerator.GenerateBase64(upiUri, logoStream, "Scan & Pay Prashant", size: 600);

// Save to file for verification
byte[] png = Convert.FromBase64String(base64);
string outPath = "fancy-qr.png";
File.WriteAllBytes(outPath, png);
Console.WriteLine($"Wrote {outPath} ({png.Length} bytes)");
Console.WriteLine($"Base64 length: {base64.Length}");

logoStream?.Dispose();
```


### Polyglot Notebook Specific: Display QR Code Inline

This section shows how to display the generated QR code directly in a Polyglot Notebook as HTML:

```csharp
using Microsoft.DotNet.Interactive.Formatting;
Formatter.DefaultMimeType ="text/html";
```

```csharp
var result = Markdig.Markdown.ToHtml(
$$"""
<img src="data:image/png;base64,{{base64}}" alt="Base64 Image" />
"""); 
result.DisplayAs(Formatter.DefaultMimeType)
```

## Summary

This guide covered the complete process of generating stylized QR codes in .NET:

### Key Components

1. **UpiUriBuilder** - Constructs standard UPI payment URIs with proper URL encoding
2. **UpiPaymentInfo** - Data model for UPI payment information
3. **FancyQrGenerator** - Main class that generates gradient-styled QR codes with logos
4. **PixelDataToModuleMatrix** - Helper method to convert bitmap data to QR modules

### Features Demonstrated

- Creating UPI payment URIs compliant with Indian UPI standards
- Rendering QR codes with gradient colors and rounded dots
- Embedding logos with automatic sizing and contrast enhancement
- Adding footer text to QR codes
- High error correction (Level H) for robust scanning
- Base64 encoding for web embedding

### Use Cases

- Payment collection systems
- Invoice generation with payment QR codes
- Event tickets with branded QR codes
- Marketing materials with customized QR codes
- Digital receipts with embedded payment information

### Next Steps

You can extend this implementation by:

- Supporting additional QR code formats (WiFi, vCard, SMS)
- Adding animation support
- Creating batch QR code generation
- Implementing custom color schemes and themes
- Adding dynamic module patterns


