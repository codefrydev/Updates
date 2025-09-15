---
title: ".NET Framework vs .NET Core Interview Questions - Set 15"
author: "PrashantUnity"
weight: 225
date: 2024-08-03
lastmod: 2024-10-25
dateString: August 2024  
description: "Step-by-step comparison of .NET Framework vs .NET Core with easy explanations covering differences, dependency injection, Kestrel, and middleware concepts"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "NET", "codefrydev", "C sharp", "CFD"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD"]
---

### 1. What's the difference between .NET and .NET Framework?
- **.NET Framework**: A Windows-only framework for building web, desktop, and other applications. It has been around since the early 2000s and is deeply integrated with Windows.
- **.NET** (formerly known as .NET Core): A cross-platform, open-source framework that can run on Windows, macOS, and Linux. It is more modular and designed with modern development practices in mind, making it suitable for cloud and microservices architectures.

### 2. How does ASP.NET Core handle dependency injection?
ASP.NET Core has built-in support for dependency injection (DI) using a lightweight and extensible service container. Services are registered in the `Startup.ConfigureServices` method and then injected into controllers, Razor pages, or other services using constructor injection.

### 3. What is Kestrel, and how does it differ from IIS?
- **Kestrel**: A cross-platform web server for ASP.NET Core applications. It is designed to be lightweight, fast, and suitable for hosting applications in both development and production. It can be used as a standalone web server or behind a reverse proxy like Nginx or IIS.
- **IIS (Internet Information Services)**: A full-featured web server for Windows. It provides additional features like advanced security, request handling, and logging. In an ASP.NET Core application, IIS can act as a reverse proxy server that forwards requests to Kestrel.

### 4. What is the purpose of middleware in ASP.NET Core?
Middleware components are pieces of software that handle requests and responses in an ASP.NET Core application. They can perform operations like authentication, logging, error handling, and request routing. Middleware is executed in a pipeline, where each component can modify the request/response and pass it to the next component in the pipeline.

### 5. How does ASP.NET Core handle garbage collection?
ASP.NET Core relies on the .NET runtime's garbage collection mechanism. The garbage collector (GC) in .NET is automatic and works in the background to free up memory occupied by objects that are no longer in use. ASP.NET Core does not handle garbage collection differently from other .NET applications.

### 6. What's the difference between synchronous and asynchronous programming in ASP.NET Core?
- **Synchronous programming**: Operations are executed sequentially, and each operation waits for the previous one to complete, potentially leading to thread blocking and inefficient resource use.
- **Asynchronous programming**: Operations can be executed without waiting for the previous ones to complete, allowing better scalability and responsiveness, especially for I/O-bound operations.

### 7. How does .NET support cross-platform development?
.NET Core (now part of .NET 5 and later versions) is designed to be cross-platform. The runtime and libraries are available for Windows, macOS, and Linux, allowing developers to write applications that run on multiple operating systems without code changes.

### 8. How can you implement background work in an ASP.NET Core application?
Background work in ASP.NET Core can be implemented using:
- **Hosted services**: These are long-running services that can run background tasks. Implement the `IHostedService` interface to define the background task.
- **Task Scheduler**: Use a third-party library like Hangfire or Quartz.NET for scheduling background tasks.

### 9. How does ASP.NET Core handle concurrency and parallelism?
ASP.NET Core uses the asynchronous programming model, which leverages the `async` and `await` keywords. It utilizes the `Task`-based asynchronous pattern to handle concurrency efficiently, allowing multiple requests to be processed concurrently without blocking threads.

### 10. How do you implement caching in ASP.NET Core?
Caching in ASP.NET Core can be implemented using:
- **In-Memory Caching**: Caches data in the server's memory for faster access.
- **Distributed Caching**: Caches data using a distributed cache store, such as Redis, for scenarios where the application is deployed across multiple servers.
- **Response Caching**: Caches HTTP responses to improve response time.

### 11. What's the difference between middleware and a filter in ASP.NET Core?
- **Middleware**: Executes as part of the request pipeline and can handle any type of request or response. It operates globally for all requests.
- **Filters**: Specific to MVC and Razor pages, filters are executed before or after controller actions. They are more fine-grained and can handle cross-cutting concerns like authorization, exception handling, and result formatting.

### 12. What is Core CLR?
Core CLR is the runtime used by .NET Core (and now .NET 5+). It is a modular and cross-platform implementation of the CLR (Common Language Runtime), which provides services such as garbage collection, JIT compilation, and exception handling.

### 13. Have you worked with Docker on ASP.NET Core projects?

---

### 1. How does the ASP.NET Core MVC architecture differ from traditional ASP.NET MVC?
- **ASP.NET MVC (Traditional)**: Built on the .NET Framework and tightly integrated with IIS. It relies on the System.Web assembly, which carries a lot of overhead, and is not cross-platform.
- **ASP.NET Core MVC**: A modern, lightweight, and cross-platform framework. It decouples from System.Web, uses a modular pipeline, and can run on different web servers like Kestrel, IIS, Nginx, etc. ASP.NET Core MVC is more flexible and better suited for modern development practices.

### 2. What is the significance of middleware in ASP.NET Core MVC, and how does it compare to HTTP modules and handlers in classic ASP.NET?
- **Middleware**: In ASP.NET Core, middleware components handle requests and responses within the application pipeline. They replace HTTP modules and handlers from classic ASP.NET. Middleware provides more flexibility and control over request processing, allowing you to build a pipeline that can be tailored to your application's needs.
- **HTTP Modules and Handlers**: In classic ASP.NET, these were used to handle HTTP requests and responses globally. They were tightly coupled to the System.Web infrastructure and less flexible compared to middleware in ASP.NET Core.

### 3. What are Razor Pages, and how do they relate to the MVC pattern in ASP.NET Core?
Razor Pages are a simplified model for building web UI in ASP.NET Core. Unlike the traditional MVC pattern, where the controller and view are separate, Razor Pages encapsulate both the controller logic and view into a single page. Razor Pages are ideal for scenarios where the page-centric model is preferred, and they are built on top of the same foundation as MVC, making them compatible with existing MVC features like routing and model binding.

### 4. How do you implement custom model validation attributes in ASP.NET Core MVC?
To create custom model validation attributes in ASP.NET Core MVC, you can derive a class from `ValidationAttribute` and override the `IsValid` method. Here’s an example:

```csharp
public class CustomDateValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        DateTime dateValue;
        if (DateTime.TryParse(value?.ToString(), out dateValue))
        {
            if (dateValue > DateTime.Now)
            {
                return ValidationResult.Success;
            }
        }
        return new ValidationResult("Date must be in the future.");
    }
}
```

### 5. What is dependency injection in ASP.NET Core MVC, and why is it useful for modern applications?
Dependency injection (DI) is a technique to achieve Inversion of Control (IoC) between classes and their dependencies. ASP.NET Core MVC has built-in support for DI, allowing services to be registered and injected into controllers, views, and other services. DI promotes loose coupling, easier testing, and better maintenance in modern applications.

### 6. Can you explain the role of view components in ASP.NET Core MVC, and provide an example of a scenario where you would use one?
View components are reusable components in ASP.NET Core MVC that allow you to encapsulate rendering logic in a manner similar to partial views but with more functionality. They don’t depend on the controller’s actions and are perfect for scenarios where you need to display data that is independent of the main action logic, like a shopping cart summary or a sidebar widget.

Example scenario: Rendering a frequently updated stock ticker in the sidebar of a web page without tying it to the main page’s data.

### 7. What is the purpose of `AutoValidateAntiforgeryToken` in ASP.NET Core MVC, and how does it help protect against CSRF attacks?
`AutoValidateAntiforgeryToken` is an attribute in ASP.NET Core MVC that automatically applies anti-forgery validation to all POST requests in a controller or application. It helps protect against Cross-Site Request Forgery (CSRF) attacks by ensuring that requests originate from the same site through the use of a token embedded in the form.

### 8. Explain the differences between TempData, ViewData, and ViewBag, and give an example of when you would use each in ASP.NET Core MVC.
- **TempData**: Stores data between requests, using either session or cookies. Example: Passing data between an action that redirects and another that handles the redirected request.
- **ViewData**: Dictionary-based storage for passing data between the controller and view in a single request. Example: Passing a simple message from the controller to the view.
- **ViewBag**: A dynamic wrapper around ViewData, providing a more convenient syntax. Example: Passing complex objects to the view without casting.

### 9. What are Tag Helpers in ASP.NET Core MVC? Can you provide an example of a custom tag helper and explain its benefits?
Tag Helpers are components that enable server-side code to participate in creating and rendering HTML elements in Razor views. They provide a way to manipulate HTML in a strongly typed and IntelliSense-supported way.

Example of a custom tag helper:
```csharp
[HtmlTargetElement("email")]
public class EmailTagHelper : TagHelper
{
    public string Address { get; set; }
    public string Display { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "a";
        output.Attributes.SetAttribute("href", $"mailto:{Address}");
        output.Content.SetContent(Display);
    }
}
```
Benefits: Provides a clean and maintainable way to handle custom HTML generation in Razor views.

### 10. Describe the role of the `IActionResult` interface and its various implementations in ASP.NET Core MVC.
`IActionResult` is an interface that defines the contract for a result that a controller action returns. It allows different types of responses, such as `ViewResult`, `JsonResult`, `RedirectResult`, etc., promoting flexibility in how controller actions respond to requests.

### 11. Explain the concept of model binding in ASP.NET Core MVC, and highlight some of the key configuration options available to customize this process.
Model binding in ASP.NET Core MVC automatically maps HTTP request data (query strings, form data, route data, etc.) to action method parameters. You can customize model binding by creating custom model binders or by configuring global options in the `Startup.cs` file.

### 12. How do you handle exception handling and logging in an ASP.NET Core MVC application?
Exception handling is typically managed using middleware such as `UseExceptionHandler` or `UseDeveloperExceptionPage`. Logging can be implemented using built-in logging providers (e.g., console, file, third-party services) configured in `Startup.cs`.

### 13. Describe the process of migrating an ASP.NET MVC application to ASP.NET Core MVC. What challenges and potential improvements can you anticipate?
Migrating to ASP.NET Core MVC involves several steps:
- Upgrading to .NET Core/.NET 5+.
- Rewriting configurations, dependency injection, and middleware.
- Updating NuGet packages.
- Replacing System.Web dependencies.
Challenges: Compatibility issues, learning curve, potential refactoring of large codebases.
Improvements: Better performance, cross-platform capabilities, modern architecture.

### 14. In ASP.NET Core MVC, what is the purpose of areas, and how do they help in organizing large applications?
Areas in ASP.NET Core MVC allow you to partition a large application into smaller functional groupings. Each area can have its own controllers, views, and models, making the application more organized and easier to manage.

### 15. How do you implement authentication and authorization in an ASP.NET Core MVC application using Identity Framework?
ASP.NET Core Identity is the framework used for managing authentication and authorization. You configure Identity in `Startup.cs` and use services like `UserManager`, `SignInManager`, and `RoleManager` to handle user roles, authentication, and authorization.

### 16. Explain the advantages and limitations of using Entity Framework Core in ASP.NET Core MVC applications.
- **Advantages**: Strongly typed queries, migration support, LINQ integration, and cross-platform support.
- **Limitations**: Performance overhead for complex queries, less control over SQL generation compared to raw SQL.

### 17. What strategies and techniques can be employed to optimize the performance of an ASP.NET Core MVC application?
- Caching (in-memory, distributed).
- Asynchronous programming.
- Minimizing middleware.
- Using response compression.
- Optimizing database queries.
- Profiling and identifying bottlenecks.

### 18. How do you implement real-time communication in an ASP.NET Core MVC application using SignalR?
SignalR is used for real-time communication in ASP.NET Core MVC. It allows server-side code to push content to connected clients instantly. SignalR supports WebSockets, server-sent events, and long polling. You implement SignalR by creating hubs and clients that communicate through SignalR's API.

### 19. What is the role of action filters in ASP.NET Core MVC, and how do they differ from global filters?
Action filters in ASP.NET Core MVC allow you to execute custom logic before and after action methods. Global filters apply across the entire application, while action filters can be applied to specific controllers or actions.

### 20. How do you create and manage custom routes in ASP.NET Core MVC applications?
Custom routes in ASP.NET Core MVC are defined in `Startup.cs` within the `UseRouting` middleware. You can use attribute routing on controllers or define routes explicitly using the `MapControllerRoute` method.

### 21. Describe the functionality and usage of `appsettings.json` in an ASP.NET Core MVC application.
`appsettings.json` is the configuration file used in ASP.NET Core MVC applications for storing configuration settings such as connection strings, application settings, and environment-specific configurations. It can be accessed using the `IConfiguration` interface.

 22. What is the difference between a synchronous and an asynchronous action method in ASP.NET Core MVC? When is it appropriate to use each type?
- **Synchronous methods**: Block the thread until the task is completed. Suitable for CPU-bound operations.
- **Asynchronous methods**: Use `async` and `await` keywords to perform non-blocking operations. Suitable for I/O-bound operations like database access or external API calls, improving scalability.

### 23. Explain the concept of Razor Class Libraries (RCL) in ASP.NET Core MVC, and discuss the pros and cons of their usage in your projects.
Razor Class Libraries (RCL) allow you to create reusable UI components that can be shared across multiple projects. RCLs can include Razor views, view components, controllers, and static assets.

**Pros**: Reusability, modularity, consistency across projects.
**Cons**: Potential complexity in debugging and development overhead.

### 24. What is the role of `WebHostBuilder` in ASP.NET Core MVC, and how do you configure and customize it for various deployment scenarios?
`WebHostBuilder` is used to configure and initialize the ASP.NET Core hosting environment. It sets up the server, middleware, and application services. Customization can be done by configuring settings like environment, logging, Kestrel server options, and middleware.

### 25. What is the Kestrel web server in ASP.NET Core, and how does it compare to IIS in terms of performance, features, and security?
- **Kestrel**: Lightweight, cross-platform, high-performance web server built into ASP.NET Core. It is ideal for serving requests directly or behind a reverse proxy.
- **IIS**: Full-featured, Windows-based web server with advanced security, load balancing, and management features. It can act as a reverse proxy for Kestrel in production deployments.
- **Comparison**: Kestrel is faster and cross-platform, while IIS provides more security and advanced features.
