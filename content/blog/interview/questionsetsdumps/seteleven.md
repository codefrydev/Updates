---
title: "Set Eleven"
author: "PrashantUnity"
weight: 221
date: 2024-08-03
lastmod: 2024-10-25
dateString: August 2024  
description: "Common Question Interview Sets of MVC Collected from Internet"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "NET", "codefrydev", "C sharp", "CFD"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD"]
---


### 1. What is ViewData?
**ViewData** is a dictionary object in ASP.NET Core MVC used to pass data from a controller to a view. It is a type of key-value pair dictionary where the key is a string, and the value is an object. ViewData is useful for passing small amounts of data between a controller and a view but lacks type safety and requires typecasting.

### 2. Can ASP.NET Core work with the .NET Framework?
Yes, ASP.NET Core 2.0 supported the .NET Framework, but starting from ASP.NET Core 3.0, ASP.NET Core applications only run on .NET Core. If you need to use .NET Framework-specific libraries, you should use ASP.NET Core 2.1 or earlier.

### 3. Explain the startup process in ASP.NET Core?
The startup process in ASP.NET Core involves the following steps:
1. **Program.cs**: The entry point, which initializes the hosting environment and configuration.
2. **Startup.cs**: Configures services and the middleware pipeline.
   - `ConfigureServices`: This method is used to add services to the container, like MVC services, authentication, etc.
   - `Configure`: This method sets up the HTTP request pipeline using middleware.

### 4. Talk about Logging in ASP.NET Core?
Logging in ASP.NET Core is built into the framework and uses a flexible logging abstraction. It supports various built-in providers, including Console, Debug, EventLog, and third-party providers like Serilog, NLog, etc. You can configure logging levels and categories to control the granularity of logging information.

### 5. What is ASP.NET Core?
ASP.NET Core is a cross-platform, high-performance framework for building modern, cloud-based, internet-connected applications. It is a redesign of ASP.NET to provide a more modular and scalable architecture. ASP.NET Core runs on Windows, macOS, and Linux and is compatible with .NET Core and .NET 5+.

### 6. What is the difference between ASP.NET and ASP.NET MVC?
- **ASP.NET Web Forms**: A traditional event-driven model using server controls and ViewState.
- **ASP.NET MVC**: A framework based on the Model-View-Controller pattern. It promotes a clear separation of concerns, making it easier to manage complex applications.

### 7. What is ViewState?
ViewState is a mechanism in ASP.NET Web Forms used to persist the state of controls between postbacks. It stores data as a base64-encoded string in a hidden field on the page, which can affect performance due to increased page size.

### 8. What is a postback?
A postback is the process of submitting an ASP.NET page to the server for processing. It occurs when a user action, like a button click, triggers a form submission, sending the page and its data to the server.

### 9. What exactly is an application pool? What is its purpose?
An **application pool** in IIS is a container for isolating a web application. It allows multiple applications to run on the same server without affecting each other by using different worker processes. This provides better security, reliability, and resource management.

### 10. What is Generic Host in .NET Core?
The **Generic Host** in .NET Core provides a base for running a wide variety of applications, including web applications, console apps, and worker services. It abstracts common functionalities like dependency injection, configuration, and logging.

### 11. Explain Middleware in ASP.NET Core?
**Middleware** are software components that are assembled into an application pipeline to handle requests and responses. Each middleware component can perform operations before and after the next component in the pipeline is invoked. Examples include authentication, routing, and error handling.

### 12. What is new in ASP.NET Core 2, compared to ASP.NET Core 1?
ASP.NET Core 2 introduced many enhancements, such as:
- Razor Pages for a simpler page-focused scenario.
- A unified Web API and MVC Controller framework.
- Simplified hosting model with a `WebHost.CreateDefaultBuilder()` method.
- Enhanced dependency injection and configuration options.

### 13. Explain usage of Dependency Injection in ASP.NET Core?
Dependency Injection (DI) is a design pattern used to achieve Inversion of Control (IoC) between classes and their dependencies. ASP.NET Core provides built-in support for DI. Services (dependencies) are registered in `ConfigureServices` method and are injected into constructors or methods where they are needed.

### 14. What is the difference between Server.Transfer and Response.Redirect?
- **Server.Transfer**: Transfers execution from one page to another on the server without making a round trip to the client. It retains the original URL.
- **Response.Redirect**: Redirects the client to a new URL, causing a round trip and changing the URL in the browser.

### 15. What are the subtypes of ActionResult?
- `ViewResult`
- `PartialViewResult`
- `JsonResult`
- `RedirectResult`
- `RedirectToActionResult`
- `RedirectToRouteResult`
- `ContentResult`
- `FileResult`
- `EmptyResult`
- `StatusCodeResult`

### 16. What are the different types of caching?
- **Output Caching**: Caches the output of pages.
- **Data Caching**: Stores data in the server memory.
- **Distributed Caching**: Caches data across multiple servers.
- **In-Memory Caching**: Caches data in memory for quick access.

### 17. What is the meaning of Unobtrusive JavaScript?
Unobtrusive JavaScript refers to the practice of separating JavaScript code from HTML markup. This approach promotes a cleaner HTML structure and better maintainability of code.

### 18. List the events in the ASP.NET page life cycle.
1. **Page Request**
2. **Start**
3. **Initialization**
4. **Load**
5. **Postback Event Handling**
6. **Rendering**
7. **Unload**

### 19. Explain JSON Binding?
JSON Binding refers to the process of mapping JSON data to a .NET object in an ASP.NET Core application. It is commonly used in Web APIs to accept and return data in JSON format.

### 20. In which event of the page cycle is the ViewState available?
The ViewState is available during the **Load** event in the ASP.NET page lifecycle.

### 21. Where is the ViewState stored after the page postback?
ViewState is stored in a hidden field on the client-side within the page itself, and it is sent back to the server on postback.

### 22. How can we prevent the browser from caching an ASPX page?
To prevent caching, you can use the following HTTP headers in your ASPX page:
```csharp
Response.Cache.SetCacheability(HttpCacheability.NoCache);
Response.Cache.SetNoStore();
Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
```

### 23. What are the different validators in ASP.NET?
- **RequiredFieldValidator**
- **RangeValidator**
- **RegularExpressionValidator**
- **CompareValidator**
- **CustomValidator**
- **ValidationSummary**

### 24. What is ViewState? How is it encoded? Is it encrypted? Who uses ViewState?
ViewState is a mechanism for preserving page and control values between postbacks in ASP.NET Web Forms. It is base64-encoded, not encrypted by default, but it can be encrypted for security. It is primarily used by ASP.NET Web Forms to maintain the state of controls.

### 25. What exactly is the difference between .NET Core and ASP.NET Core?
- **.NET Core**: A cross-platform runtime for building console apps, services, and libraries.
- **ASP.NET Core**: A framework built on top of .NET Core for building web applications and services.

### 26. How can you create your own scope for a Scoped object in .NET?
You can create a custom scope using `IServiceScopeFactory` like this:
```csharp
using (var scope = serviceProvider.CreateScope())
{
    var scopedService = scope.ServiceProvider.GetRequiredService<MyScopedService>();
    // Use the scoped service
}
```

### 27. What are some benefits of using the Options Pattern in ASP.NET Core?
The Options Pattern provides a way to configure strongly-typed settings objects from configuration files. It helps in organizing settings, providing validation, and automatically reloading configuration changes.

### 28. In OOP, what is the difference between the Repository Pattern and a Service Layer?
- **Repository Pattern**: Manages data access logic. It abstracts data interactions and queries.
- **Service Layer**: Manages business logic. It orchestrates various operations, potentially across different repositories.

### 29. What is the correct pattern to implement long-running background work in ASP.NET Core?
Use a **Hosted Service** (e.g., `BackgroundService`) for long-running background tasks. Implementing `IHostedService` is a common approach.

### 30. Explain the use of BackgroundService class in ASP.NET Core?
`BackgroundService` is an abstract base class for implementing long-running background tasks. It runs in the background, separate from the request processing pipeline, and is typically registered as a hosted service.

### 31. What is the difference between ASP.NET Core Web (.NET Core) vs ASP.NET Core Web (.NET Framework)?
- **ASP.NET Core Web (.NET Core)**: Cross-platform, high-performance, uses .NET Core runtime.
- **ASP.NET Core Web (.NET Framework)**: Limited to Windows, used for compatibility with existing .NET Framework libraries.

### 32. What is the difference between web.config and machine.config?
- **web.config**: Configuration file specific to an ASP.NET web application.
- **machine.config**: Configuration file that applies to all .NET applications on a server.

### 

33. Which type of caching will be used if we want to cache the portion of a page instead of the whole page?
**Fragment Caching** (using `Partial Cache`) is used to cache only portions of a page.

### 34. How can we force all the validation controls to run?
Use the `Page.Validate()` method to force all validation controls on a page to run.

### 35. What are the different Session State management options available in ASP.NET?
- **In-Process**: Stored in the memory of the server.
- **State Server**: Stored in a separate state server.
- **SQL Server**: Stored in a SQL database.
- **Custom**: Custom storage mechanism.
- **Cookie**: Session data stored in cookies.

### 36. Is it possible to create a web application with both WebForms and MVC?
Yes, it is possible to use both WebForms and MVC in a single ASP.NET application by configuring routes and using appropriate controllers and views.

### 37. What are the different types of cookies in ASP.NET?
- **Session Cookies**: Temporary cookies that are deleted when the browser is closed.
- **Persistent Cookies**: Remain on the user's device until they expire or are manually deleted.
- **Secure Cookies**: Transmitted over HTTPS only.

### 38. What is the difference between system.webServer and system.web?
- **system.webServer**: Configuration settings specific to IIS 7+ integrated mode.
- **system.web**: Traditional ASP.NET configuration settings.

### 39. How to choose between ASP.NET 4.x and ASP.NET Core?
Choose ASP.NET Core for new, cross-platform applications with a modern architecture. Choose ASP.NET 4.x if you need to maintain compatibility with existing .NET Framework libraries or legacy applications.

### 40. What is the difference between classic and integrated pipeline mode in IIS7?
- **Classic mode**: Handles requests using ASP.NET ISAPI extensions.
- **Integrated mode**: Integrates ASP.NET directly into the IIS request pipeline, allowing for better performance and flexibility.

### 41. What is HttpModule in ASP.NET?
An **HttpModule** is a class that handles HTTP events during the request pipeline. It can inspect, modify, or end the request.

### 42. What is Katana?
Katana is a set of OWIN components developed by Microsoft to provide a lightweight and modular framework for building web applications.

### 43. What is an HttpHandler in ASP.NET? Why and how is it used?
An **HttpHandler** is a class that processes HTTP requests. It provides custom handling of specific request types, like serving dynamically generated content.

### 44. When to use Transient vs Scoped vs Singleton DI service lifetimes?
- **Transient**: New instance per request or usage. Use for lightweight, stateless services.
- **Scoped**: One instance per request. Use for services that should maintain state within a single request.
- **Singleton**: Single instance for the application lifetime. Use for stateful, long-lived services.

### 45. When using DI in a Controller, should I call IDisposable on any injected service?
No, you should not manually call `IDisposable` on injected services. The DI container manages the disposal of services based on their lifecycle.

### 46. What is the difference between IHostBuilder vs IHostedService vs IHost?
- **IHostBuilder**: Used to configure and build the application host.
- **IHostedService**: Represents a background service that runs with the application.
- **IHost**: The program's runtime environment that contains services and the application's entry point.

### 47. What is the difference between Hosted Services vs WebJobs?
- **Hosted Services**: Run in the background within the ASP.NET Core app process.
- **WebJobs**: Run as background processes in the context of Azure App Services.

### 48. What is the difference between Hosted Services vs Windows Services?
- **Hosted Services**: Run within an ASP.NET Core application and share the same process.
- **Windows Services**: Run independently of web applications and can start automatically with the OS.

### 49. Name some ASP.NET WebForms disadvantages over MVC?
- Tight coupling of presentation and business logic.
- Limited testability due to code-behind model.
- ViewState results in heavier page sizes.
- Less control over HTML output and client-side scripting.

### 50. What is the equivalent of WebForms in ASP.NET Core?
There is no direct equivalent of WebForms in ASP.NET Core. Razor Pages and MVC are the primary options for building UI in ASP.NET Core.

### 51. What is Cross Page Posting?
Cross Page Posting refers to the ability to submit form data from one page to another page directly. In Web Forms, this can be done using the `PostBackUrl` property on a button.

### 52. What exactly is OWIN, and what problems does it solve?
**OWIN (Open Web Interface for .NET)** decouples web servers from web applications. It provides a standard interface between .NET applications and web servers, making it easier to develop and host applications on different web servers.

### 53. Are static class instances unique to a request or a server in ASP.NET?
Static class instances are shared across all requests and users for the lifetime of the application domain. They are server-wide and not unique to a request.

### 54. Explain some deployment considerations for Hosted Services?
- Ensure proper service lifetimes (e.g., Singleton or Scoped) for stability.
- Handle exceptions and provide retry logic.
- Use proper logging to monitor background tasks.
- Configure graceful shutdown and disposal to avoid data corruption or incomplete operations during application shutdown.
