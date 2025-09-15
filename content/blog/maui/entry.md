---
title: "Remove Underline from Entry Control in .NET MAUI"
author: "PrashantUnity"
weight: 106
date: 2025-06-19
lastmod: 2024-06-19
dateString: July 2025  
description: "Learn how to create a custom Entry control in .NET MAUI to remove the default underline styling with platform-specific implementations"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "NET", "codefrydev", "C sharp", "CFD","maui" , "controls","entry"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD","maui" , "controls"]
---

## Create Custom Entry Control

```cs

namespace WaterReminder.CFDControl;

public class CfdEntry :Entry
{
    protected override void OnHandlerChanged()
    {
        base.OnHandlerChanged();

        SetBorderlessBackground();
    }

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if (propertyName == nameof(BackgroundColor))
        {
            SetBorderlessBackground();
        }
    }

    private void SetBorderlessBackground()
    {
#if ANDROID

        if (Handler is IEntryHandler entryHandler)
        {
            if (BackgroundColor == null)
            {
                entryHandler.PlatformView.BackgroundTintList =
                            Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToPlatform());
            }
            else
            {
                entryHandler.PlatformView.BackgroundTintList =
                            Android.Content.Res.ColorStateList.ValueOf(BackgroundColor.ToPlatform());
            }
        }
#endif
    }
}
```

## Step uses

> Import Name Spaces. in Xaml and so on ...

```xml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" 
             xmlns:cfdControl="clr-namespace:WaterReminder.CFDControl">

    <cfdControl:CfdEntry  Placeholder="This is how you will use"  />

</ContentPage>
```

## Similar gor for others 

> Example for Picker is shown below

```cs
public class CfdPicker : Picker
{
    protected override void OnHandlerChanged()
    {
        base.OnHandlerChanged();

        SetBorderlessBackground();
    }

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if (propertyName == nameof(BackgroundColor))
        {
            SetBorderlessBackground();
        }
    }

    private void SetBorderlessBackground()
    {
#if ANDROID

        if (Handler is IPickerHandler pickerHandler)
        {
            if (BackgroundColor == null)
            {
                pickerHandler.PlatformView.BackgroundTintList =
                    Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToPlatform());
            }
            else
            {
                pickerHandler.PlatformView.BackgroundTintList =
                    Android.Content.Res.ColorStateList.ValueOf(BackgroundColor.ToPlatform());
            }
        }
#endif
    }
}
```