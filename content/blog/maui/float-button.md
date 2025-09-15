---
title: "Create a Floating Action Button in .NET MAUI"
author: "PrashantUnity"
weight: 106
date: 2025-06-19
lastmod: 2024-06-19
dateString: July 2025  
description: "Learn how to create a floating action button positioned at the bottom right in .NET MAUI using AbsoluteLayout and Border controls"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "NET", "codefrydev", "C sharp", "CFD","maui" , "layout","absolute"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD","maui" , "layout"]
---

## Code Snippet

```xml
 <AbsoluteLayout>
        
    <Grid AbsoluteLayout.LayoutBounds="0,0,1,1" AbsoluteLayout.LayoutFlags="All" >
    <Grid>

    <Border
        StrokeShape="RoundRectangle 30"
        HeightRequest="60"
        WidthRequest="60"
        BackgroundColor="Black"
        AbsoluteLayout.LayoutBounds="1, 1, AutoSize, AutoSize"
        AbsoluteLayout.LayoutFlags="PositionProportional"
        TranslationX="-30"
        TranslationY="-30"
        > 
            <Border.GestureRecognizers>
                <TapGestureRecognizer Tapped="AddButton_Clicked" />
            </Border.GestureRecognizers>
            <Label Text="➕"
                    TextColor="White"
                    VerticalOptions="Center"
                    HorizontalOptions="Center"
                    FontSize="25"/> 
    </Border>
</AbsoluteLayout>
```