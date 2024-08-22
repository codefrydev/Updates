---
title: "Singleton"
author: "PrashantUnity"
weight: 210
date: 2024-08-03
lastmod: 2024-10-22
dateString: August 2024  
description: "Different ways to create Singleton"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "NET", "codefrydev", "C sharp", "CFD"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD"]
---


## Straight Forward

```csharp
Singleton singleton = Singleton.Instance; 

sealed class Singleton
{
    public static Singleton Instance { get; } = new();

    private Singleton()
    {
    }
}
```

## Null Checking

```csharp

Singleton singleton = Singleton.Instance; 

sealed class Singleton
{
    private static Singleton _instance = default!;
    public static Singleton Instance
    {
        get
        {
            if (_instance is null)
            {
                _instance = new Singleton();
            }

            return _instance;
        }
    }

    private Singleton()
    {
        Console.WriteLine("Instantiating singleton");
    }
}
```

## Thread Safe

```csharp

Singleton singleton = Singleton.Instance; 

sealed class Singleton
{
    private static Singleton _instance = default!;
    private static object _lock = new();

    public static Singleton Instance
    {
        get
        {
            if (_instance is null)
            {
                Console.WriteLine("Locking");

                lock (_lock)
                {
                    if (_instance is null)
                    {
                        _instance = new Singleton();
                    }
                }
            }

            return _instance;
        }
    }

    private Singleton()
    {
        Console.WriteLine("Instantiating singleton");
    }
}
```

## using Dotnet Base Class Library (BCL)

```csharp
Singleton singleton = Singleton.Instance;

sealed class Singleton
{
    private static readonly Lazy<Singleton> _lazyInstance = new(() => new());

    public static Singleton Instance => _lazyInstance.Value;

    private Singleton()
    {
        Console.WriteLine("Instantiating singleton");
    }
}
```

## Jon Skeet way

```csharp

Singleton singleton = Singleton.Instance;

sealed class Singleton
{
    public static string ClassName;

    public static Singleton Instance => Nested.Instance;

    private class Nested
    {
        internal static Singleton Instance { get; } = new();

        static Nested()
        {
        }
    }

    private Singleton()
    {
    }

    static Singleton()
    {
        ClassName = "asdf";
    }
}
```

## Using Microsoft Dependency Injection Package

```xml
<ItemGroup>
    <PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="8.0.0" />
  </ItemGroup>
```

```csharp
using Microsoft.Extensions.DependencyInjection;

IServiceCollection services = new ServiceCollection();

services.AddSingleton<Singleton>();

var serviceProvider = services.BuildServiceProvider();

var instance = serviceProvider.GetRequiredService<Singleton>();

class Singleton()
{
}
```