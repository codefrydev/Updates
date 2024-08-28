---
title: "Set Twenty"
author: "PrashantUnity"
weight: 230
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

### ASP.NET Core Overview
ASP.NET Core is a modern, cross-platform framework for building high-performance, cloud-based, and internet-connected applications. It is designed to work on Windows, macOS, and Linux, making it versatile and flexible for various development scenarios.

### Key Differences Between ASP.NET Core and ASP.NET
1. **Cross-Platform**: ASP.NET Core is cross-platform, while ASP.NET (classic) is Windows-only.
2. **Performance**: ASP.NET Core offers improved performance and scalability.
3. **Modular Design**: ASP.NET Core is modular and allows you to include only the necessary components.
4. **Unified Programming Model**: ASP.NET Core merges MVC and Web API into a single framework.
5. **Dependency Injection**: ASP.NET Core has built-in support for dependency injection, unlike ASP.NET.
6. **Configuration**: ASP.NET Core uses a new configuration system that is more flexible and extensible.

### Role of the Startup Class
The `Startup` class is central to configuring an ASP.NET Core application. It includes methods to configure services (`ConfigureServices`) and the request processing pipeline (`Configure`). This class is where you set up middleware, configure dependency injection, and define application services.

### Dependency Injection
Dependency Injection (DI) is a design pattern used to achieve Inversion of Control (IoC) between classes and their dependencies. ASP.NET Core has built-in support for DI, allowing you to manage dependencies in a clean, testable manner. It helps decouple components, making code easier to maintain and test.

### Benefits of ASP.NET Core
1. **Cross-Platform**: Works on Windows, macOS, and Linux.
2. **High Performance**: Optimized for modern hardware and software architectures.
3. **Modular and Lightweight**: Allows for more efficient applications by including only necessary components.
4. **Unified Framework**: Combines MVC and Web API into a single framework.
5. **Built-In Dependency Injection**: Facilitates a more maintainable and testable codebase.
6. **Flexible Configuration**: Supports various configuration sources and options.

### Request Processing Pipeline in ASP.NET Core
The request processing pipeline is composed of a series of middleware components that handle HTTP requests and responses. Each middleware component can perform operations on the request before passing it to the next middleware, and on the response before sending it to the client. Middleware components are configured in the `Configure` method of the `Startup` class.

### Differentiating `app.Run` and `app.Use`
- **`app.Use`**: Adds a middleware to the pipeline that can perform actions and pass control to the next middleware.
- **`app.Run`**: Adds a terminal middleware that does not pass control to the next component in the pipeline.

### Request Delegate
A request delegate is a function that handles HTTP requests. It takes an `HttpContext` as a parameter and returns a `Task`. It is used to process requests and responses within middleware components.

### Host in ASP.NET Core
The Host is responsible for managing the app’s lifetime, including starting and stopping the application. It sets up the environment and dependency injection. There are two main types of hosts: `Generic Host` (for background services and console apps) and `Web Host` (for web applications).

### Configuration in ASP.NET Core
Configuration in ASP.NET Core is managed through a flexible system that reads from various sources like `appsettings.json`, environment variables, command-line arguments, and more. Values from `appsettings.json` can be accessed using the `IConfiguration` interface.

### Handling Static Files
ASP.NET Core serves static files (e.g., HTML, CSS, JavaScript) using the `StaticFileMiddleware`. This middleware is added to the pipeline using `app.UseStaticFiles()`.

### Session and State Management
- **Session**: Used to store user-specific data across requests. Configured using `services.AddSession()` and `app.UseSession()`.
- **State Management**: Includes techniques like cookies, sessions, and query strings to persist user data.

### Running ASP.NET Core in Docker
Yes, ASP.NET Core applications can run in Docker containers. Docker provides a consistent runtime environment, making it easier to deploy and manage applications across different environments.

### Model Binding
Model binding in ASP.NET Core converts HTTP request data into .NET objects. It maps data from forms, query strings, and route data to action method parameters.

### Model Validation
Model validation ensures that the data passed to a model is correct. Custom validation can be added by creating custom attributes inheriting from `ValidationAttribute` and applying them to model properties.

### ASP.NET Core MVC Architecture
ASP.NET Core MVC uses the Model-View-Controller (MVC) pattern:
- **Model**: Represents the data and business logic.
- **View**: Renders the UI based on the model data.
- **Controller**: Handles user input, manipulates the model, and returns the view.

### Components of ASP.NET Core MVC
- **Model**: Defines the data structure and business logic.
- **View**: Defines the presentation layer.
- **Controller**: Handles user requests and responses.

### View Models
View models are used to pass data between the controller and view. They encapsulate data needed for rendering a view and may include multiple models or additional properties.

### Routing in ASP.NET Core MVC
Routing maps incoming requests to the appropriate controller and action methods based on URL patterns. Routes can be defined in `Startup.Configure` using `app.UseRouting()` and `app.UseEndpoints()`.

### Attribute-Based Routing
Attribute-based routing allows defining routes directly on controller actions using attributes like `[Route]` or `[HttpGet]`. It provides more control over route templates and parameters.

### Dependency Injection Problems Solved
1. **Tight Coupling**: Reduces dependencies between components.
2. **Testability**: Makes it easier to inject mock dependencies for unit testing.
3. **Flexibility**: Facilitates configuration changes without modifying code.

### Service Lifetimes
1. **Transient**: Created each time they are requested.
2. **Scoped**: Created once per request.
3. **Singleton**: Created once and shared throughout the application.

### Middleware Concept
Middleware are components in the request pipeline that handle HTTP requests and responses. They can perform tasks such as logging, authentication, and error handling.

### Middleware Role
Middleware components are used to:
- Process requests before they reach the application.
- Modify responses before they are sent to the client.
- Implement cross-cutting concerns like authentication and logging.

### Options Pattern
The Options Pattern is used to configure and manage application settings. It involves creating classes to represent settings, binding them to configuration sections, and injecting them into services.

### Managing Multiple Environments
ASP.NET Core supports multiple environments (Development, Staging, Production). You can configure environment-specific settings in `appsettings.{Environment}.json` and use the `IWebHostEnvironment` interface to check the current environment.

### Logging System
ASP.NET Core provides a built-in logging system that supports various logging providers (Console, Debug, File). Logs can be configured in `Startup.Configure` and written using `ILogger` instances.

### Routing in ASP.NET Core
Routing determines how HTTP requests are matched to endpoints (e.g., controllers, pages). It supports attribute-based routing and conventional routing, allowing flexible URL mappings.

### Error and Exception Handling
Error handling in ASP.NET Core can be managed using exception handling middleware (`app.UseExceptionHandler()`), custom error pages, and logging.

### Custom Model Binding
Custom model binding allows you to create your own logic for converting HTTP request data into model objects. Implement the `IModelBinder` interface and register it in `Startup.ConfigureServices`.

### Custom Middleware
Custom middleware can be created by defining a class with a `Invoke` or `InvokeAsync` method. It is added to the pipeline using `app.UseMiddleware<YourMiddleware>()`.

### Accessing HttpContext
`HttpContext` provides information about the current request and response. It can be accessed through dependency injection in controllers and services.

### Change Token
Change tokens are used to detect changes in configuration or settings. They allow applications to respond to changes dynamically without restarting.

### ASP.NET Core APIs in Class Library
APIs in ASP.NET Core can be used in class libraries by referencing the necessary packages and using the `HttpClient` to make API requests.

### Open Web Interface for .NET (OWIN)
OWIN is a specification for decoupling web applications from web servers. ASP.NET Core has its own hosting model but is designed to be compatible with OWIN middleware.

### URL Rewriting Middleware
URL Rewriting Middleware allows modifying incoming request URLs based on rules. It can be used for redirecting or rewriting URLs for SEO or routing purposes.

### Application Model
The application model represents the structure and behavior of the application. It includes components like controllers, views, and routes, defining how the application processes requests.

### Caching Strategies
- **In-Memory Caching**: Stores data in the memory of the server. Used for quick access.
- **Distributed Caching**: Stores data in a distributed cache system (e.g., Redis) to share cache across multiple servers.

### XSRF/CSRF Prevention
Cross-Site Request Forgery (CSRF) attacks can be prevented using anti-forgery tokens. ASP.NET Core includes built-in support for anti-forgery tokens using `[ValidateAntiForgeryToken]`.

### Cross-Site Scripting (XSS) Prevention
To prevent XSS attacks, ensure proper encoding of user input, validate and sanitize data, and use built-in HTML encoding features in ASP.NET Core.

### Enabling CORS
Cross-Origin Resource Sharing (CORS) allows APIs to be accessed from different domains. It is enabled using the `AddCors` method in `Startup.ConfigureServices` and configured in `Startup.Configure`.

### Dependency Injection for Controllers
In ASP.NET Core MVC, dependency

 injection is used to provide services to controllers via constructor injection. Services are registered in `Startup.ConfigureServices`.

### Dependency Injection for Views
For views, you typically use the `IViewComponent` interface or view-specific services. Dependency injection in views is less common but can be achieved using view components or custom tag helpers.

### Unit Testing Controllers
Controllers can be unit tested by mocking dependencies and verifying the behavior of action methods. Use testing frameworks like xUnit or NUnit and mocking libraries like Moq.

### Cache Tag Helper
The Cache Tag Helper helps cache parts of a view to improve performance. It allows caching output of a Razor page or view to reduce server load and improve response times.

### Validation in ASP.NET Core MVC
Validation in ASP.NET Core MVC is achieved using data annotations and the validation attributes applied to model properties. It supports client-side and server-side validation, following the DRY principle.

### Strongly Typed Views
Strongly typed views are views that are bound to a specific model type, providing IntelliSense and compile-time checking. They improve type safety and development efficiency.

### Partial Views
Partial views are reusable components that can be rendered within other views. They are useful for sharing common UI elements across multiple views.

### Security Concerns in ASP.NET Core
ASP.NET Core handles security through features like authentication, authorization, and secure communication. Best practices include using HTTPS, implementing role-based and policy-based authorization, and securing sensitive data.