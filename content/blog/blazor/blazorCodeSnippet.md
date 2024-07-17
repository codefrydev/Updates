---
title: "Common Blazor Code Snippet"
author: ["PrashantUnity"]
weight: 200
date: 2024-07-12T00:00:00-07:00
lastmod: 2024-07-19T23:59:59-07:00
dateString: July 2024
description: "Some of most Common Blazor Code Snippet Used in blazor Project" 
tags: ["blazor"]
keywords: ["CFD","CodefryDev","Code Fry Dev","Csharp","blazor","webassembly" ]

cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  #display caption under cover 
---

### String Interpolation

```csharp
<img Class="@($"hello{variable}")" Width="64px" Height="64px" />
```

### Get Dotnet Version Name using in Project

```csharp
string version = Environment.Version.ToString();
```

### Upload File

- Code for Uploading Images

```csharp
@page "/"  
<InputFile multiple OnChange="@HandleFileInput" />
@code 
{ 
    List<string> _items = new();
    async Task HandleFileInput(InputFileChangeEventArgs e)
    { 
        foreach (var item in e.GetMultipleFiles())
        {
            using var stream = item.OpenReadStream();
            using var ms = new MemoryStream();
            await stream.CopyToAsync(ms);
            _items.Add($"data:{item.ContentType};base64,{Convert.ToBase64String(ms.ToArray())}");
        } 
    } 
     
}
```

### Convert Image As base64 string and then Display in Browser

```csharp
@using System.IO
<MudFileUpload T="IBrowserFile" FilesChanged="UploadFiles">
    <ButtonTemplate>
        <MudFab HtmlTag="label"
                Color="Color.Secondary"
                Icon="@Icons.Material.Filled.Image"
                Label="Load picture"
                for="@context.Id" />
    </ButtonTemplate>
</MudFileUpload>

@if(ImageUri!="")
{
    <MudImage Src="@ImageUri" Width="400" Height="400" /> 
}

@code {

    string ImageUri="";
    private async Task UploadFiles(IBrowserFile file)
    { 
        var image = await file.RequestImageFileAsync("image/png", 600, 600);

        using Stream imageStream = image.OpenReadStream(1024 * 1024 * 10);
        
        using MemoryStream ms = new();
        //copy imageStream to Memory stream
        await imageStream.CopyToAsync(ms);

        //convert stream to base64
        ImageUri = $"data:image/png;base64,{Convert.ToBase64String(ms.ToArray())}";
    }
}
```

### Call Javascript Function

```js
window.blazorKeyPressed = function() {
    
};
```

```csharp
[Inject] protected IJSRuntime JSRuntime { get; set; } = null!;
async Task CallJavascript()
{
    await JSRuntime.InvokeVoidAsync("blazorKeyPressed");
}
```

### Call C# Code From JavaScript

```js
window.blazorKeyPressed = function(dotnetHelper) {
    document.addEventListener('keyup', function(event) {
        dotnetHelper.invokeMethodAsync('OnArrowKeyPressed', event.key);
    });
};
```

```csharp
[Inject] protected IJSRuntime JSRuntime { get; set; } = null!;
protected override async Task OnAfterRenderAsync(bool firstRender)
{
    if (firstRender)
    {
        await JSRuntime.InvokeVoidAsync("blazorKeyPressed", DotNetObjectReference.Create(this));
    }
}
```

- Code Which will be Called by Js

```csharp
[JSInvokable]
public void OnArrowKeyPressed(string key)
{
    
}
```

## Download Image

### using Base64 string

```js
window.downloadImage = (base64Image, fileName) => {
    const byteCharacters = atob(base64Image);
    const byteNumbers = new Array(byteCharacters.length);
    for (let i = 0; i < byteCharacters.length; i++) {
        byteNumbers[i] = byteCharacters.charCodeAt(i);
    }
    const byteArray = new Uint8Array(byteNumbers);
    const blob = new Blob([byteArray]);
    const url = window.URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.style.display = 'none';
    a.href = url;
    a.download = fileName;
    document.body.appendChild(a);
    a.click();
    window.URL.revokeObjectURL(url);
};
```

### Download Div as Image

```js
window.generateImage = function (id) {
    html2canvas(document.getElementById(id)).then(function (canvas) {
        var image = canvas.toDataURL('image/png');

        var a = document.createElement('a');
        a.href = image;
        a.download = 'generated_image.png';
        a.click();
    });
}
```

### Using Image URI

```js
window.downloadImageUrl = (imageUrl, fileName) => {
    fetch(imageUrl)
        .then(response => response.blob())
        .then(blob => {
            const url = window.URL.createObjectURL(blob);
            const a = document.createElement('a');
            a.style.display = 'none';
            a.href = url;
            // Set the file name
            a.download = fileName;
            document.body.appendChild(a);
            a.click();
            window.URL.revokeObjectURL(url);
        })
        .catch(error => console.error('Error downloading image:', error));
};
```

### Code To Invoke All Above Three Methods/Approach

```csharp
byte[] ConvertSKBitmapToByteArray(SKBitmap bitmap, SKEncodedImageFormat format)
{
    using (var image = SKImage.FromBitmap(bitmap))
    using (var data = image.Encode(format, 100))
    {
        return data.ToArray();
    }
}
var arr = bmp.Bytes;// ConvertSKBitmapToByteArray(bmp, SKEncodedImageFormat.Png);
await JSRuntime.InvokeVoidAsync("downloadImage", Convert.ToBase64String(arr), "image.png");
await JSRuntime.InvokeVoidAsync("downloadImageUrl", $"https://picsum.photos/200/300", "image.png");
await JSRuntime.InvokeVoidAsync("generateImage", IDOfImageToDownload); // element as canvass as image
```
