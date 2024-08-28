---
title: "Set Seventeen"
author: "PrashantUnity"
weight: 227
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

### What is .NET Core?
.NET Core is a free, open-source, cross-platform framework developed by Microsoft. It is designed to be a high-performance, modular, and scalable platform for building applications that can run on Windows, macOS, and Linux. It supports the development of console applications, web apps, APIs, and microservices.

### How is .NET Core different from the existing .NET Framework?
1. **Cross-Platform**: .NET Core is designed to run on multiple platforms (Windows, macOS, Linux), while the .NET Framework is mainly Windows-based.
2. **Open Source**: .NET Core is open-source, enabling community contributions, while the .NET Framework is proprietary.
3. **Modular Architecture**: .NET Core is modular and lightweight, allowing developers to include only the necessary libraries. The .NET Framework is monolithic, including a large set of libraries by default.
4. **Unified Development**: .NET Core provides a consistent environment for building web, cloud, and IoT applications, whereas the .NET Framework was traditionally used for Windows desktop and server applications.
5. **Performance**: .NET Core is optimized for performance and scalability, making it suitable for modern, cloud-based applications.

### What are .NET Platform Standards?
.NET Platform Standards define a set of APIs that all .NET implementations must follow, ensuring compatibility across different platforms. This standardization allows libraries and code to be shared across various .NET implementations like .NET Core, .NET Framework, Xamarin, and Mono.

### What is ASP.NET Core?
ASP.NET Core is a new version of ASP.NET, redesigned as a unified framework for building modern, cloud-based, internet-connected applications. It is built on top of .NET Core, providing features for web development like MVC (Model-View-Controller), Razor Pages, Web API, and SignalR. ASP.NET Core is also cross-platform, open-source, and highly modular.

### Newly Introduced Functionalities in ASP.NET Core
1. **Cross-Platform Support**: Run on Windows, macOS, and Linux.
2. **Razor Pages**: Simplified page-based coding model.
3. **Built-in Dependency Injection**: Integrated DI for managing dependencies.
4. **Unified MVC and Web API Framework**: A single framework for MVC and Web APIs.
5. **Kestrel Web Server**: A lightweight, high-performance web server.
6. **Middleware**: Configurable request pipeline using middleware components.
7. **Tag Helpers**: Enhanced server-side HTML generation.
8. **Improved Performance and Scalability**: Faster startup and execution times.
9. **Configuration System**: Supports various configuration sources like JSON files, environment variables, and more.
10. **Unified Cross-Site Scripting (XSS) Prevention**: Built-in protection against XSS attacks.

### Why Use ASP.NET Core for Web Application Development?
- **Performance**: High performance due to optimized runtime and Kestrel web server.
- **Cross-Platform**: Develop and deploy applications on multiple operating systems.
- **Modularity**: Build lightweight applications by including only necessary packages.
- **Modern Development Practices**: Built-in support for modern web standards and tools.
- **Open Source**: Community contributions and transparency in development.
- **Cloud-Ready**: Built with cloud-based applications and microservices architecture in mind.

### What is ASP.NET Core Middleware, and How is it Different from HttpModule?
- **Middleware**: A middleware is a component in ASP.NET Core that processes HTTP requests and responses. It's registered in the request pipeline using `app.Use()` methods. Middleware components are executed in the order they are added to the pipeline.
- **HttpModule**: In traditional ASP.NET, HttpModules are classes that handle HTTP request and response events globally. Middleware in ASP.NET Core replaces HttpModules and HttpHandlers, offering more flexibility and control over the request pipeline.

### Various JSON Files in ASP.NET Core
1. **appsettings.json**: Stores application configuration settings like connection strings, app settings, etc.
2. **launchSettings.json**: Contains profiles for different environments, defining environment variables, application URL, and hosting settings.
3. **bundleconfig.json**: (Optional) Used for defining bundling and minification settings.

### What is the `Startup.cs` File in ASP.NET Core?
`Startup.cs` is the entry point for configuring an ASP.NET Core application. It includes methods to configure services (like dependency injection) and define the middleware pipeline.

### `ConfigureServices()` Method in `Startup.cs`
The `ConfigureServices` method is used to register services with the dependency injection container. It allows you to define custom services, third-party services, database contexts, identity, etc.

### `Configure()` Method in `Startup.cs`
The `Configure` method is used to define the request processing pipeline using middleware. This method specifies how the application will respond to HTTP requests by adding components like routing, authentication, static files, and custom middleware.

### Difference Between `app.Use()` vs. `app.Run()` While Adding Middleware
- **`app.Use()`**: Adds a middleware to the request pipeline and passes control to the next middleware in the chain using `next()`.
- **`app.Run()`**: Adds a terminal middleware that does not call the next middleware, effectively ending the request pipeline.

### Difference Between `services.AddTransient()` and `services.AddScoped()` in ASP.NET Core
- **`AddTransient()`**: Creates a new instance of the service every time it's requested. Ideal for lightweight, stateless services.
- **`AddScoped()`**: Creates a single instance of the service per HTTP request. It is suitable for services that maintain state within the scope of a single request.

### What is Kestrel?
Kestrel is a cross-platform, high-performance web server for ASP.NET Core. It is the default server used in ASP.NET Core applications and is optimized for handling both development and production workloads.

### What is WebListener?
WebListener (now replaced by HttpSysServer) is a Windows-specific web server for ASP.NET Core applications that is built on the Windows HTTP Server API. It offers advanced Windows features like Windows authentication and HTTP/2.

### What is ASP.NET Core Module (ANCM)?
The ASP.NET Core Module (ANCM) is a native IIS module that allows ASP.NET Core applications to work with IIS. ANCM serves as a reverse proxy between IIS and the Kestrel server, enabling hosting of ASP.NET Core apps in IIS.

### Different ASP.NET Core Diagnostic Middleware and Error Handling
1. **Developer Exception Page**: Shows detailed exception information during development using `app.UseDeveloperExceptionPage()`.
2. **Exception Handling Middleware**: For production use `app.UseExceptionHandler("/Error")` to redirect to a generic error page.
3. **Status Code Pages**: Use `app.UseStatusCodePages()` to handle non-success HTTP status codes.

### What is a Host, and What’s the Importance of Host in ASP.NET Core Application?
A **host** in ASP.NET Core is responsible for starting the application and managing its lifecycle. It configures the web server, logging, DI, and other services. There are two types of hosts: Generic Host (`IHost`) for non-web applications and Web Host (`IWebHost`) for web applications.

### What Does `WebHost.CreateDefaultBuilder()` Do?
`WebHost.CreateDefaultBuilder()` sets up a default hosting environment for the application, including:
- Configuring Kestrel as the web server.
- Setting up configuration providers for appsettings.json and environment variables.
- Enabling logging.
- Configuring the app to use IIS integration.

### Role of `IHostingEnvironment` Interface in ASP.NET Core
`IHostingEnvironment` provides information about the web hosting environment, such as the content root path, web root path, and environment (Development, Staging, Production). It allows for environment-specific configurations.

### Handling 404 Error in ASP.NET Core 1.0
Use the `app.UseStatusCodePages()` middleware to handle 404 and other status code errors. You can customize the error handling by providing a lambda function or redirecting to a specific error page.

### Use of `UseIISIntegration`
`UseIISIntegration()` configures the application to work with IIS as a reverse proxy. It is added automatically when creating a new ASP.NET Core application using Visual Studio templates.

### Different Ways for Bundling and Minification in ASP.NET Core
1. **Bundler & Minifier Tool**: Uses bundleconfig.json for client-side bundling and minification.
2. **Gulp or Webpack**: Task runners and module bundlers that can be configured to handle complex bundling and minification tasks.
3. **Razor Bundling and Minification**: ASP.NET Core's built-in support using Razor files.

### What is `launchSettings.json` in ASP.NET Core?
`launchSettings.json` contains settings related to project launch configurations, such as environment variables, application URLs, and profile names for running the application in different environments (Development, Production).

### What is the `wwwroot` Folder in ASP.NET Core?
The `wwwroot` folder is the default web root directory in ASP.NET Core. It is used to serve static files like HTML, CSS, JavaScript, and images directly to clients.

### What are “Razor Pages” in ASP.NET Core?
Razor Pages is a page-based programming model in ASP.NET Core that simplifies the development of web UI by organizing code in a page-specific way. It uses `.cshtml` files for markup and a `.cs` file for page logic.

### What is a Tag Helper in ASP.NET Core?
Tag Helpers are server-side components that enable server-side code to participate in creating and rendering HTML elements. They provide a more natural syntax for generating dynamic content compared to traditional HTML Helpers.

### What’s New in .NET Core 2.1 and ASP.NET Core 2

.1?
- **Razor Class Libraries**: Sharing UI components across projects.
- **SignalR**: Real-time web functionality for applications.
- **HTTPS by Default**: Improved security.
- **API Conventions**: Built-in support for common API behaviors.
- **Improved HttpClient**: Enhanced performance and reliability.

### Differences Between ASP.NET MVC 5 and ASP.NET MVC Core 1.0
1. **Platform**: MVC 5 is Windows-only; MVC Core is cross-platform.
2. **Dependency Injection**: Built-in DI in MVC Core, not in MVC 5.
3. **Middleware**: Uses middleware instead of HttpModules.
4. **Modular**: MVC Core is modular and lightweight.

### Which is the Latest Version of ASP.NET Core?
The latest version of ASP.NET Core is part of .NET 8 (as of 2024).

### Where is Startup.cs in ASP.NET Core 6.0?
In ASP.NET Core 6.0, `Startup.cs` is no longer mandatory. Configuration can be directly done in the `Program.cs` file using the new minimal hosting model.

### What is Minimal API in ASP.NET Core 6.0?
Minimal APIs offer a simplified way to create HTTP APIs with minimal dependencies and configuration, using fewer files and lines of code. It allows for defining route handlers, services, and middleware directly in the `Program.cs` file.