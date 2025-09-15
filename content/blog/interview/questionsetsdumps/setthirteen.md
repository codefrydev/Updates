---
title: "ASP.NET Core MVC Interview Questions - Set 13"
author: "PrashantUnity"
weight: 223
date: 2024-08-03
lastmod: 2024-10-25
dateString: August 2024  
description: "Complete tutorial guide to ASP.NET Core MVC interview questions with step-by-step explanations covering architecture, configuration, and modern web development"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "NET", "codefrydev", "C sharp", "CFD"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD"]
---


### ASP.NET MVC Core Overview
ASP.NET MVC Core, often referred to simply as ASP.NET Core, is a cross-platform, high-performance framework for building modern, cloud-based, and internet-connected applications. It combines the features of ASP.NET MVC and ASP.NET Web API into a single programming model. ASP.NET Core is open-source and can run on Windows, macOS, and Linux.

### MVC Architecture
MVC (Model-View-Controller) is an architectural pattern used to separate an application into three main components:
1. **Model**: Manages data logic and business rules. It represents the application's data and usually interacts with the database.
2. **View**: Represents the user interface and displays data to the user. It’s generated from the model data.
3. **Controller**: Handles user input and interaction. It processes incoming requests, interacts with the model, and selects a view to render.

### Configuration in ASP.NET Core
In ASP.NET Core, configuration settings are typically stored in the `appsettings.json` file. Other sources include environment variables, command-line arguments, user secrets (for development), and Azure Key Vault.

### Reading Configuration Files in ASP.NET Core
To read configuration settings in ASP.NET Core:
1. Inject the `IConfiguration` interface into your class (e.g., controller or service).
2. Use `Configuration["Key"]` or `Configuration.GetSection("SectionName")["Key"]`.

### Dependency Injection (DI)
**Dependency Injection** is a design pattern used to achieve Inversion of Control (IoC) between classes and their dependencies. In ASP.NET Core, DI is a built-in feature that allows you to inject services into classes, making them easier to test and maintain.

### Why Dependency Injection?
- **Loosely Coupled Code**: Reduces hard dependencies between classes.
- **Improves Testability**: Makes unit testing easier by allowing mocking of dependencies.
- **Maintenance**: Easier to manage and maintain large codebases.

### Implementing Dependency Injection
1. Register services in the `ConfigureServices` method of `Startup.cs` using `services.AddSingleton()`, `services.AddScoped()`, or `services.AddTransient()`.
2. Inject the service into your classes using constructor injection.

### Middleware Concept
**Middleware** are components that form the request pipeline in ASP.NET Core applications. Each middleware component processes HTTP requests and either passes them to the next middleware or terminates the request.

### Implementing Middleware in MVC Core
1. Create a class that includes an `Invoke` or `InvokeAsync` method.
2. Register the middleware in the `Configure` method using `app.UseMiddleware<YourMiddlewareClass>()`.

### Dependency Injection in MVC
1. **Constructor Injection**: The most common method where dependencies are provided through a class constructor.
2. **Method Injection**: Dependencies are passed directly to methods.
3. **Property Injection**: Dependencies are assigned to properties.

### Session Management in ASP.NET Core
1. **In-Memory Sessions**: Store session data in server memory using `services.AddDistributedMemoryCache()`.
2. **Distributed Caching**: Use SQL Server or Redis for session state.
3. **Cookies**: Store session data in cookies.

### ConfigureServices vs Configure Method
- **ConfigureServices**: Used to configure services and DI container. It registers application services.
- **Configure**: Sets up the request pipeline with middleware components.

### Razor Pages
Razor Pages is a simpler, page-based model for building web UI in ASP.NET Core. Each page is a self-contained view with its model, and it includes a `.cshtml` file and an associated page model class.

### Passing Model Data to the View
- Pass data using a `ViewBag`, `ViewData`, or a strongly typed model.
- Use `return View(model)` in a controller to pass model data to a view.

### Strongly Typed Views
A **strongly typed view** is one that is bound to a specific model type. This allows for compile-time checking of model properties and IntelliSense support in the view.

### ViewModel Concept
A **ViewModel** is a class that contains the data and logic needed by the view. It can combine multiple models or only contain the data required for a specific view, making it different from domain models.

### Kestrel Web Server
**Kestrel** is a cross-platform, high-performance, and lightweight web server for ASP.NET Core. It is used by default and can run behind other servers like IIS or Nginx.

### Kestrel vs. IIS
- **Kestrel**: High-performance server, used for handling requests directly in cross-platform scenarios or behind reverse proxies.
- **IIS**: Traditional web server, acts as a reverse proxy to Kestrel in Windows environments, providing additional security and management features.

### Reverse Proxy Concept
A **reverse proxy** is a server that forwards client requests to backend servers. In ASP.NET Core, IIS or Nginx can act as reverse proxies, directing traffic to the Kestrel server.

### Implementing JWT Token Security in ASP.NET Core
1. Configure JWT authentication in `Startup.cs`.
2. Use `[Authorize]` attribute to protect endpoints.
3. Generate JWT tokens in response to user login.

### Filters in ASP.NET Core
**Filters** are used to execute code before or after specific stages in the request pipeline, such as authorization, action execution, result execution, and exception handling.

### Generic Host vs. WebHost
- **Generic Host**: A new hosting model in ASP.NET Core that supports more types of applications (not just web apps), including background services.
- **WebHost**: A specific host for web applications, providing web-specific features like serving static files.

### Managing Environment-Specific AppSettings
- Use multiple `appsettings.{Environment}.json` files.
- Use `ASPNETCORE_ENVIRONMENT` environment variable to switch environments.

### IApplicationBuilder.Use() vs IApplicationBuilder.Run()
- **Use()**: Adds a middleware delegate to the application's request pipeline that calls the next middleware.
- **Run()**: Adds a terminal middleware delegate that does not call the next middleware.

### HtmlHelper vs TagHelper
- **HtmlHelper**: Provides methods to generate HTML elements in views.
- **TagHelper**: Uses custom HTML tags or attributes to generate HTML dynamically, offering more functionality and better syntax.

### Creating Custom TagHelper
1. Create a class inheriting from `TagHelper`.
2. Override `Process` or `ProcessAsync` method to define custom logic.

### Creating Custom HtmlHelper
1. Define a static method returning `IHtmlContent`.
2. Use extension methods on `HtmlHelper`.

### Enabling Session in ASP.NET Core
1. Configure session middleware in `Startup.cs` using `services.AddSession()` and `app.UseSession()`.
2. Access sessions in controllers using `HttpContext.Session`.

### Implementing Versioning in ASP.NET Core API
1. URL versioning (e.g., `/api/v1/`)
2. Header versioning (using custom headers)
3. Query string versioning (e.g., `/api/resource?version=1`)

### Importance of `.csproj` File in .NET Core
- `.csproj` contains project metadata and build configurations.
- The new format is simpler and more concise compared to previous versions in .NET.

### Common Publishing Errors (e.g., 502.5, 500.30)
- **502.5**: Indicates process startup failure, often due to incorrect configuration or missing files.
- **500.30**: Error during application startup, caused by misconfiguration, missing dependencies, or runtime errors.

### Difference between .NET Standard Library and .NET Core Library
- **.NET Standard**: A specification of APIs that are available across different .NET implementations.
- **.NET Core Library**: Specific to .NET Core, can utilize features exclusive to .NET Core.

### UseRouting and UseEndpoints in Startup Configure Method
- **UseRouting**: Configures the routing middleware, identifying which route handler will process the request.
- **UseEndpoints**: Defines the endpoints the application responds to, connecting route patterns to actions.

### Store ServiceCollection in Different Locations
You can encapsulate service configuration logic into extension methods and call them from `ConfigureServices`.

### ViewComponent and Dependency Injection
- **ViewComponent**: Similar to partial views but with more complex logic. Use `Invoke` or `InvokeAsync`.
- DI is supported directly in view components through constructor injection.

### Using In-Memory Cache in ASP.NET Core
- Configure caching services using `services.AddMemoryCache()`.
- Use `IMemoryCache` to store and retrieve data.

### Storing Objects in Session (Non-String)
Serialize objects to JSON before storing them in session and deserialize them when retrieving.

### Creating Custom Middleware in ASP.NET Core
1. Create a class with an `Invoke` or `InvokeAsync` method.
2. Register it using `app.UseMiddleware<YourMiddlewareClass>()` in the `Configure` method.

### LaunchSettings.json in ASP.NET Core
- Contains settings for different environments (Development, Production).
- Specifies the environment, application URL, and profiles.

### Configuring Runtime Compilation of Views
Enable runtime compilation in development to update views without restarting the server using the `Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation` package.

### AsyncActionFilter in ASP.NET Core MVC
An `AsyncActionFilter` is a filter that allows asynchronous pre-action and post-action logic. Implement it by inheriting from `IAsyncActionFilter`.

### Securing ASP.NET Core with OAuth 2.0
- Use the OAuth middleware to integrate OAuth 2.0 authentication.
- Configure using services like Google, Facebook, or custom OAuth providers.

### Authentication in ASP.NET Core Web API with OWIN
Use OWIN middleware for authentication. Integrate with JWT or OAuth for

 token-based authentication.

### Factory Pattern Using Built-In DI in ASP.NET Core
Use the factory pattern to create instances of services dynamically based on some input or condition.

### Filters in ASP.NET Core
Filters provide a way to execute code before or after specific stages in the request pipeline. Types include Authorization, Resource, Action, Exception, and Result filters.

### IOptions in ASP.NET Core
`IOptions<T>` pattern is used to manage configuration settings. Bind configuration sections to POCO classes and inject them using `IOptions<T>`.