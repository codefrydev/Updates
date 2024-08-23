---
title: "App setting in dotnet"
author: "PrashantUnity"
weight: 210
date: 2024-08-03
lastmod: 2024-10-22
dateString: August 2024  
description: "How To Configure or read from app setting in asp.net core application"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "NET", "codefrydev", "C sharp", "CFD","appsetting"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD","appsetting"]
---

## Reading data from appsetting.json file

```cs
var config = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();
var val =config["randomString"];
```
## assigning value to static readonly class element from appsettings.json
```cs
public static class RandomClass
{
    public const string hello = "hello";

    public static readonly string bello = "90";
    static RandomClass()
    {
        var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .Build();
        bello = configuration["MySettings:Bello"];
    }
}
```

### 1. Add `appsettings.json` to Your Project

Ensure you have an `appsettings.json` file in the root of your project. It might look something like this:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "MySettings": {
    "Setting1": "Value1",
    "Setting2": "Value2"
  }
}
```

### 2. Configure `appsettings.json` in `Program.cs`
 

```csharp
var builder = WebApplication.CreateBuilder(args); 
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true); 
```

### 3. Access Configuration in a Controller or Service

You can inject `IConfiguration` to read the settings.

#### Example in a Controller

```csharp
[ApiController]
[Route("[controller]")]
public class MySettingsController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public MySettingsController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet]
    public IActionResult GetSettings()
    {
        var setting1 = _configuration["MySettings:Setting1"];
        var setting2 = _configuration["MySettings:Setting2"];

        return Ok(new { Setting1 = setting1, Setting2 = setting2 });
    }
}
```

#### Example in a Service

First, define class to map the settings:

```csharp
public class MySettings
{
    public string Setting1 { get; set; }
    public string Setting2 { get; set; }
}
```

Then, configure it in `Program.cs`:

```csharp
builder.Services.Configure<MySettings>(builder.Configuration.GetSection("MySettings"));
```

And finally, inject and use it in a service:

```csharp
public class MyService
{
    private readonly MySettings _mySettings;

    public MyService(IOptions<MySettings> mySettings)
    {
        _mySettings = mySettings.Value;
    }

    public void DoSomething()
    {
        var setting1 = _mySettings.Setting1;
        var setting2 = _mySettings.Setting2;
        // Use the settings
    }
}
```

### 4. Using Dependency Injection in Controllers

Inject the service into a controller to use the settings:

```csharp
[ApiController]
[Route("[controller]")]
public class MyServiceController : ControllerBase
{
    private readonly MyService _myService;

    public MyServiceController(MyService myService)
    {
        _myService = myService;
    }

    [HttpGet]
    public IActionResult UseService()
    {
        _myService.DoSomething();
        return Ok();
    }
}
```

1. **Include `appsettings.json`**: Ensure it's in your project.
2. **Configure settings in `Program.cs`**: Ensure the JSON file is read.
3. **Inject `IConfiguration`**: Use it in controllers or services to access settings.
4. **Configure services**: Use `IOptions<T>` to map settings to POCO classes.

