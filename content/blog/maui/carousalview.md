---
title: "Carousal View in maui"
author: "PrashantUnity"
weight: 106
date: 2025-06-23
lastmod: 2024-06-23
dateString: July 2025  
description: "Code snippet for maui auto change carousal view component"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "NET", "codefrydev", "C sharp", "CFD","maui" , "layout","Carousal"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD","maui" , "Carousal"]
---

### \#\# 1. Create the Reusable Component Files 🧱

First, add a new item to your project. Choose the **.NET MAUI ContentView (XAML)** template. Name it something descriptive, like `FeaturedCarouselView.xaml`.

### \#\# 2.  UI code sample of the ContentView

**`FeaturedCarouselView.xaml`:**

```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentView xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:YourMauiProjectName"
             x:Class="YourMauiProjectName.FeaturedCarouselView">
    <ContentView.Resources>
        <ResourceDictionary>
            <Color x:Key="CardBackgroundColor">#F9FAFB</Color>
            <Color x:Key="ForegroundColor">#111827</Color>
            <Color x:Key="MutedForegroundColor">#6B7280</Color>
            <Color x:Key="BorderColor">#E5E7EB</Color>
            <Color x:Key="PrimaryColor">#4A90E2</Color>
            <Style x:Key="CardBorderStyle" TargetType="Border">
                <Setter Property="Stroke" Value="{StaticResource BorderColor}" />
                <Setter Property="StrokeThickness" Value="1" />
                <Setter Property="BackgroundColor" Value="{StaticResource PageBackgroundColor}" />
                <Setter Property="StrokeShape" Value="RoundRectangle 8" />
                <Setter Property="Padding" Value="0" />
                <Setter Property="Shadow">
                    <Shadow Brush="Black" Offset="2,2" Radius="5" Opacity="0.1" />
                </Setter>
            </Style>
            <Style x:Key="PrimaryButtonStyle" TargetType="Button">
                <Setter Property="BackgroundColor" Value="{StaticResource PrimaryColor}" />
                <Setter Property="TextColor" Value="{StaticResource PrimaryTextColor}" />
                <Setter Property="FontAttributes" Value="Bold" />
                <Setter Property="HeightRequest" Value="48" />
                <Setter Property="CornerRadius" Value="8" />
                <Setter Property="Padding" Value="24,0" />
            </Style>
        </ResourceDictionary>
    </ContentView.Resources>
    <VerticalStackLayout Spacing="16" BackgroundColor="{StaticResource CardBackgroundColor}">
        <CarouselView x:Name="FeaturedCarousel"
                      IndicatorView="FeaturedIndicator"
                      HeightRequest="500">
            <CarouselView.ItemTemplate>
                <DataTemplate x:DataType="local:CarouselItem">
                    <VerticalStackLayout Padding="16,0" Spacing="24">
                        <Border Style="{StaticResource CardBorderStyle}" StrokeShape="RoundRectangle 12" HeightRequest="300">
                            <Image Source="{Binding ImageUrl}" Aspect="AspectFill" />
                        </Border>
                        <VerticalStackLayout Spacing="16" HorizontalOptions="Center" Padding="16,0">
                            <Label Text="{Binding Title}" TextColor="{StaticResource ForegroundColor}" FontSize="24" FontAttributes="Bold" HorizontalTextAlignment="Center" />
                            <Label Text="{Binding Description}" TextColor="{StaticResource MutedForegroundColor}" FontSize="16" HorizontalTextAlignment="Center" />
                            <Button Text="Discover More  →" Style="{StaticResource PrimaryButtonStyle}" HorizontalOptions="Center" />
                        </VerticalStackLayout>
                    </VerticalStackLayout>
                </DataTemplate>
            </CarouselView.ItemTemplate>
        </CarouselView>

        <IndicatorView x:Name="FeaturedIndicator"
                       IndicatorColor="{StaticResource BorderColor}"
                       SelectedIndicatorColor="{StaticResource PrimaryColor}"
                       HorizontalOptions="Center"
                       Margin="0,0,0,16"/>
    </VerticalStackLayout>

</ContentView>
```

### \#\# 3. Logic to the Component's Code-Behind

**Important:** We use the `Loaded` and `Unloaded` events to start and stop the timer.

**`FeaturedCarouselView.xaml.cs`:**

```csharp
// Define the data record here or in a separate file
public record CarouselItem(string Title, string Description, string ImageUrl);

public partial class FeaturedCarouselView : ContentView
{
    private IDispatcherTimer _timer;
    private readonly List<CarouselItem> _carouselItems;

    public FeaturedCarouselView()
    {
        InitializeComponent();

        _carouselItems = new List<CarouselItem>
        {
            new CarouselItem("Solitaire Diamond Ring", "An exquisite solitaire diamond ring, perfect for engagements.", "https://picsum.photos/600/600?random=1"),
            new CarouselItem("Ruby Heart Pendant", "A stunning heart-shaped ruby pendant on a delicate rose gold chain.", "https://picsum.photos/600/600?random=2"),
            new CarouselItem("Emerald Tennis Bracelet", "A timeless classic featuring brilliant-cut emeralds.", "https://picsum.photos/600/600?random=3")
        };

        FeaturedCarousel.ItemsSource = _carouselItems;

        // Use the Loaded and Unloaded events to manage the timer
        this.Loaded += OnLoaded;
        this.Unloaded += OnUnloaded;
    }

    private void OnLoaded(object sender, EventArgs e)
    {
        _timer = Application.Current.Dispatcher.CreateTimer();
        _timer.Interval = TimeSpan.FromSeconds(5);
        _timer.Tick += Timer_Tick;
        _timer.Start();
    }

    private void OnUnloaded(object sender, EventArgs e)
    {
        _timer.Stop();
        _timer.Tick -= Timer_Tick;
        _timer = null;
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        int nextPosition = (FeaturedCarousel.Position + 1) % _carouselItems.Count;
        FeaturedCarousel.Position = nextPosition;
    }
}
```

### \#\# 4. Use Your New Component

**Your main page's XAML (e.g., `HomePage.xaml`):**

```xml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:YourMauiProjectName"
             x:Class="YourMauiProjectName.HomePage"
             Title="Home">

    <ScrollView>
        <VerticalStackLayout>

            <local:FeaturedCarouselView />

        </VerticalStackLayout>
    </ScrollView>

</ContentPage>
```
