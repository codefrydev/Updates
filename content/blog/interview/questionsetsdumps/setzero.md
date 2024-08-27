---
title: "Set Zero"
author: "PrashantUnity"
weight: 210
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

### What is ASP.NET MVC Core?

ASP.NET MVC Core is a modern, open-source, cross-platform framework for building web applications. It is a part of the larger ASP.NET Core framework and follows the Model-View-Controller (MVC) architecture pattern. MVC Core is designed to offer greater performance, scalability, and flexibility compared to its predecessors. It allows developers to create web applications that can run on various platforms (Windows, Linux, macOS) and supports cloud-based deployment. Key features include:

- **Cross-platform compatibility**: Runs on Windows, Linux, and macOS.
- **Modular framework**: Allows inclusion of only necessary packages, reducing application size and improving performance.
- **Unified development model**: Combines MVC and Web API to streamline web application development.
- **Razor pages**: Simplifies the building of web UI using a page-focused approach.

### Differentiate between ASP.NET WebForms vs MVC vs MVC Core

1. **Architecture**:
   - **WebForms**: Follows a page-based approach. Uses server controls and view state for maintaining state. Code-behind files are tightly coupled with the UI.
   - **MVC**: Follows the Model-View-Controller architecture. Separates application concerns, making it easier to manage and test.
   - **MVC Core**: Similar to MVC but is cross-platform, lightweight, and more flexible. Part of ASP.NET Core.

2. **Performance**:
   - **WebForms**: Uses server-side controls which can lead to heavier view states and slower performance.
   - **MVC**: Generally better performance due to lack of view state and more direct control over HTML.
   - **MVC Core**: Optimized for high performance, offering faster request processing and reduced memory consumption.

3. **State Management**:
   - **WebForms**: Uses view state to maintain state between server calls.
   - **MVC**: Does not use view state, relying on more stateless interactions.
   - **MVC Core**: Similar to MVC, promotes stateless design.

4. **Testability**:
   - **WebForms**: Harder to test due to tight coupling of UI and logic.
   - **MVC**: Easier to test due to separation of concerns.
   - **MVC Core**: Same as MVC but with more flexibility in testing, thanks to dependency injection and modularity.

5. **Scalability**:
   - **WebForms**: Less scalable due to heavy server-side processing.
   - **MVC**: More scalable due to stateless nature and better separation of concerns.
   - **MVC Core**: Highly scalable, designed with cloud deployment in mind.

6. **Flexibility**:
   - **WebForms**: Limited flexibility due to reliance on server controls and view state.
   - **MVC**: More flexible, allows fine-grained control over HTML and HTTP.
   - **MVC Core**: Most flexible, built to work with modern front-end frameworks and tools.

### Explain MVC Architecture

The MVC architecture divides an application into three interconnected components:

1. **Model**: Represents the data and business logic of the application. It handles data-related operations and communicates with the database.
2. **View**: Represents the UI of the application. It displays data from the Model to the user and sends user input to the Controller.
3. **Controller**: Acts as an intermediary between Model and View. It handles user input, processes it (possibly updating the Model), and determines the View to display.

### Why do we have the wwwroot folder?

The `wwwroot` folder is the default folder in ASP.NET Core applications for serving static files, such as HTML, CSS, JavaScript, and image files. The importance of the `wwwroot` folder includes:

- **Security**: Only files within `wwwroot` are accessible to the client. This isolates the rest of the application files from being served directly.
- **Organized structure**: Provides a clear separation between static content (accessible to clients) and server-side content (protected from direct client access).
- **Static file serving**: ASP.NET Core applications are configured to serve files directly from `wwwroot`, making it easier to manage and deploy static resources.

### Explain the importance of appsettings.json

`appsettings.json` is a configuration file used in ASP.NET Core applications to store application settings, such as database connection strings, API keys, logging settings, and other configuration options. The importance of `appsettings.json` includes:

- **Centralized configuration**: Provides a single place to manage application settings, which makes it easier to configure and update.
- **Environment-specific settings**: Supports different configurations for different environments (e.g., development, production) by using `appsettings.Development.json`, `appsettings.Production.json`, etc.
- **Readability and maintainability**: Using JSON format makes it human-readable and easy to maintain.

### How to read configurations from appsettings.json?

In ASP.NET Core, configurations from `appsettings.json` can be read using the built-in configuration system:

1. **Load Configuration**: By default, ASP.NET Core loads configuration settings from `appsettings.json` when the application starts.
2. **Inject Configuration**: Use dependency injection to inject `IConfiguration` into controllers, services, or other classes.
3. **Access Configuration Values**:
   ```csharp
   public class MyService
   {
       private readonly IConfiguration _configuration;

       public MyService(IConfiguration configuration)
       {
           _configuration = configuration;
       }

       public string GetSetting()
       {
           return _configuration["MySettingKey"];
       }
   }
   ```
4. **Bind Configuration Sections**: For complex objects, bind configuration sections directly to objects using `GetSection` and `Bind`.
   ```csharp
   var mySettings = new MySettings();
   _configuration.GetSection("MySettingsSection").Bind(mySettings);
   ```

### What is dependency injection?

Dependency Injection (DI) is a design pattern used to manage dependencies and object lifetimes. It allows a class to receive its dependencies from an external source rather than creating them itself. DI helps to achieve loosely coupled and more testable code.

### Why do we need dependency injection?

- **Loosely coupled code**: Reduces the dependency of classes on concrete implementations, making it easier to change implementations without modifying the dependent class.
- **Improved testability**: Allows for easy substitution of mock objects, which makes unit testing simpler.
- **Enhanced maintainability**: Promotes better organization of code, making it easier to maintain and understand.
- **Configuration management**: Centralizes object creation and configuration, promoting consistency across the application.

### How do we implement dependency injection?

In ASP.NET Core, DI is built into the framework and is implemented using the `IServiceCollection` interface:

1. **Register Services**: In the `Startup.cs` file, use the `ConfigureServices` method to register services with the DI container.
   ```csharp
   public void ConfigureServices(IServiceCollection services)
   {
       services.AddTransient<IMyService, MyService>();
       services.AddScoped<IMyRepository, MyRepository>();
       services.AddSingleton<ILogger, Logger>();
   }
   ```
   - `Transient`: New instance each time it's requested.
   - `Scoped`: Same instance per request.
   - `Singleton`: Same instance throughout the application's lifetime.

2. **Inject Services**: Use constructor injection to inject the required services into classes.
   ```csharp
   public class MyController : Controller
   {
       private readonly IMyService _myService;

       public MyController(IMyService myService)
       {
           _myService = myService;
       }
   }
   ```

### What is the use of Middleware?

Middleware is software that is assembled into an application pipeline to handle requests and responses. In ASP.NET Core, middleware components are used to:

- **Process requests**: Perform operations on incoming HTTP requests before they reach the endpoint (e.g., authentication, logging, routing).
- **Modify responses**: Change the outgoing HTTP responses before they are sent back to the client.
- **Request processing pipeline**: Middleware components are executed in the order they are added, allowing a modular and customizable request processing pipeline.

### How to Create Middleware?

In ASP.NET Core, middleware is created to handle requests and responses as they pass through the application pipeline. You can create middleware using a class that follows specific conventions or by using inline middleware. Here’s how to create middleware using both methods:

1. **Using a Middleware Class**:
   - Create a new class that implements the middleware logic.
   - The class should have a `RequestDelegate` in its constructor and a `Task InvokeAsync` method.
   - Use `HttpContext` to access request and response details.

   ```csharp
   public class CustomMiddleware
   {
       private readonly RequestDelegate _next;

       public CustomMiddleware(RequestDelegate next)
       {
           _next = next;
       }

       public async Task InvokeAsync(HttpContext context)
       {
           // Middleware logic before the next component in the pipeline
           await context.Response.WriteAsync("Processing request...");

           // Call the next middleware in the pipeline
           await _next(context);

           // Middleware logic after the next component in the pipeline
           await context.Response.WriteAsync("Request processed.");
       }
   }
   ```

   - Register the middleware in the `Startup.cs` file within the `Configure` method using the `UseMiddleware` extension method:

   ```csharp
   public void Configure(IApplicationBuilder app)
   {
       app.UseMiddleware<CustomMiddleware>();
       // Other middleware registrations...
   }
   ```

2. **Using Inline Middleware**:
   - Inline middleware can be created using the `Run`, `Use`, or `Map` extension methods on `IApplicationBuilder`.

   ```csharp
   public void Configure(IApplicationBuilder app)
   {
       app.Use(async (context, next) =>
       {
           await context.Response.WriteAsync("Processing request inline...");
           await next.Invoke();
           await context.Response.WriteAsync("Inline request processed.");
       });
   }
   ```

### What Does the `Startup.cs` File Do?

The `Startup.cs` file is a critical part of an ASP.NET Core application that configures services and the HTTP request pipeline. It typically contains two methods:

1. **ConfigureServices(IServiceCollection services)**:
   - Used to register services with the dependency injection (DI) container.
   - Services such as MVC, Entity Framework, Identity, and custom services are configured here.
   - The method receives an `IServiceCollection` object, which is used to add services.

   ```csharp
   public void ConfigureServices(IServiceCollection services)
   {
       services.AddControllersWithViews();
       services.AddDbContext<ApplicationDbContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
   }
   ```

2. **Configure(IApplicationBuilder app, IWebHostEnvironment env)**:
   - Used to define the middleware components that handle HTTP requests.
   - Sets up the request processing pipeline.
   - Contains configuration related to exception handling, routing, static files, authentication, etc.

   ```csharp
   public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
   {
       if (env.IsDevelopment())
       {
           app.UseDeveloperExceptionPage();
       }
       else
       {
           app.UseExceptionHandler("/Home/Error");
           app.UseHsts();
       }

       app.UseHttpsRedirection();
       app.UseStaticFiles();

       app.UseRouting();

       app.UseAuthorization();

       app.UseEndpoints(endpoints =>
       {
           endpoints.MapControllerRoute(
               name: "default",
               pattern: "{controller=Home}/{action=Index}/{id?}");
       });
   }
   ```

### ConfigureServices vs. Configure Method

- **ConfigureServices(IServiceCollection services)**:
  - Purpose: Register application services with the DI container.
  - Runs first to configure services before they are needed.
  - Examples: Adding MVC services, configuring database context, setting up authentication services.

- **Configure(IApplicationBuilder app, IWebHostEnvironment env)**:
  - Purpose: Define the middleware that handles requests.
  - Runs second to configure the HTTP request processing pipeline.
  - Examples: Adding middleware for routing, error handling, static files, and other HTTP-related tasks.

### Different Ways of Doing Dependency Injection (DI)

ASP.NET Core supports different types of DI:

1. **Constructor Injection**:
   - The most common and preferred method. Dependencies are provided through the class constructor.
   
   ```csharp
   public class MyController : Controller
   {
       private readonly IMyService _myService;

       public MyController(IMyService myService)
       {
           _myService = myService;
       }
   }
   ```

2. **Method Injection**:
   - Dependencies are passed to methods as parameters.
   
   ```csharp
   public class MyController : Controller
   {
       public IActionResult Index([FromServices] IMyService myService)
       {
           // Use myService here
       }
   }
   ```

3. **Property Injection**:
   - Dependencies are assigned to public properties.
   
   ```csharp
   public class MyController : Controller
   {
       [Inject]
       public IMyService MyService { get; set; }

       public IActionResult Index()
       {
           // Use MyService here
       }
   }
   ```

### Scoped vs. Transient vs. Singleton

1. **Transient**:
   - New instance of the service is created every time it is requested.
   - Best for lightweight, stateless services.
   - Example:
     ```csharp
     services.AddTransient<IMyService, MyService>();
     ```

2. **Scoped**:
   - A single instance of the service is created per HTTP request.
   - Suitable for services that maintain state related to a specific request.
   - Example:
     ```csharp
     services.AddScoped<IMyService, MyService>();
     ```

3. **Singleton**:
   - A single instance of the service is created and shared across the entire application lifecycle.
   - Suitable for stateful services that don’t change per request.
   - Example:
     ```csharp
     services.AddSingleton<IMyService, MyService>();
     ```

### What is Razor?

Razor is a lightweight, server-side templating engine used in ASP.NET Core to generate HTML markup dynamically. It allows embedding C# code directly within HTML using the `@` symbol. Razor syntax is clean and concise, making it easy to write dynamic web pages.

Example of Razor syntax:

```html
@{
    var message = "Hello, World!";
}
<!DOCTYPE html>
<html>
<head>
    <title>Razor Example</title>
</head>
<body>
    <h1>@message</h1>
</body>
</html>
```

### How to Pass Model Data to a View?

In MVC, models are used to pass data from the controller to the view. Here’s how to pass model data:

1. **Create a Model**:
   ```csharp
   public class Product
   {
       public int Id { get; set; }
       public string Name { get; set; }
       public decimal Price { get; set; }
   }
   ```

2. **Pass Model from Controller to View**:
   - In the controller action, pass the model to the view using the `View` method.

   ```csharp
   public class ProductController : Controller
   {
       public IActionResult Details()
       {
           var product = new Product { Id = 1, Name = "Laptop", Price = 999.99m };
           return View(product);
       }
   }
   ```

3. **Access Model Data in View**:
   - Use the `@model` directive to specify the model type at the top of the view and then access its properties.

   ```html
   @model Product

   <h2>Product Details</h2>
   <p>Id: @Model.Id</p>
   <p>Name: @Model.Name</p>
   <p>Price: @Model.Price</p>
   ```

### What is the Use of Strongly Typed Views?

- **Strongly typed views** are views that are tied to a specific model type, allowing compile-time checking of the model properties. This reduces errors and provides IntelliSense support in Visual Studio, improving development speed and reliability.

- By specifying a model type using the `@model` directive, you can access model properties directly within the view:

  ```html
  @model Product

  <p>Product Name: @Model.Name</p>
  ```

### Explain the Concept of ViewModel in MVC

- A **ViewModel** is a class that contains properties needed by a specific view. It is a model tailored to the needs of the view, often combining data from multiple sources or entities.

- ViewModels help keep views simple and focused, avoiding passing entire domain models directly to views. They ensure that only the necessary data is available to the view.

- **Example of a ViewModel**:
  
  ```csharp
  public class ProductViewModel
  {
      public string ProductName { get; set; }
      public decimal ProductPrice { get; set; }
      public string CategoryName { get; set; }
  }
  ```

- **Usage in Controller**:
  
  ```csharp
  public IActionResult Details()
  {
      var viewModel = new ProductViewModel
      {
          ProductName = "Laptop",
          ProductPrice = 999.99m,
          CategoryName = "Electronics"
      };
      return View(viewModel);
  }
  ```

### What is Kestrel Web Server?

- **Kestrel** is a cross-platform web server for ASP.NET Core applications. It is included by default when you create a new ASP.NET Core project.

- **Key features of Kestrel**:
  - **Cross-platform**: Runs on Windows, Linux, and macOS.
  - **High-performance

**: Designed for high-performance scenarios.
  - **Flexible**: Can be used as a reverse proxy behind a more feature-rich web server like IIS or Nginx.
  - **Integration**: Works seamlessly with ASP.NET Core to handle HTTP requests and responses.

- **Example Configuration**:
  
  ```csharp
  public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
          .ConfigureWebHostDefaults(webBuilder =>
          {
              webBuilder.UseStartup<Startup>();
          });
  ```

### Why Kestrel When We Have IIS Server?

Kestrel and IIS serve different purposes in an ASP.NET Core application deployment:

1. **Kestrel**:
   - **Cross-Platform**: Works on Windows, Linux, and macOS.
   - **High Performance**: Optimized for high-performance scenarios and built to be lightweight.
   - **Hosting**: Often used as a development server and in production behind a reverse proxy.

2. **IIS (Internet Information Services)**:
   - **Feature-Rich**: Offers extensive features like URL rewriting, application pools, and security configurations.
   - **Windows-Specific**: Runs on Windows and integrates tightly with the Windows Server environment.
   - **Reverse Proxy**: Can act as a reverse proxy to forward requests to Kestrel or other backend servers.

**Why Use Both**:
- **Kestrel** is often used as a lightweight, high-performance web server for handling HTTP requests and responses.
- **IIS** or other reverse proxies (e.g., Nginx) can be used in front of Kestrel to handle additional concerns like load balancing, SSL termination, and more advanced security features.

### What is the Concept of Reverse Proxy?

A **reverse proxy** is a server that sits between client devices and a web server (like Kestrel). It forwards client requests to the backend server and then sends the responses from the backend server back to the clients. Key purposes of a reverse proxy include:

- **Load Balancing**: Distributes incoming requests across multiple servers to balance the load.
- **Security**: Hides the backend server details and can provide SSL termination.
- **Caching**: Caches responses from the backend server to reduce load and improve performance.
- **Compression**: Compresses responses before sending them to the client to reduce bandwidth usage.

### What Are Cookies?

**Cookies** are small pieces of data sent by a server and stored on the client's browser. They are used to maintain state and track user sessions across HTTP requests. Common uses for cookies include:

- **Session Management**: Storing session identifiers to manage user sessions.
- **User Preferences**: Remembering user preferences or settings between visits.
- **Authentication**: Storing authentication tokens for user login sessions.

### What Is the Need for Session Management?

**Session management** is essential for maintaining state and user-specific data across multiple HTTP requests. Because HTTP is a stateless protocol, it doesn’t retain information between requests. Session management allows applications to:

- **Track User Activity**: Maintain user-specific information such as login status, shopping cart contents, or preferences.
- **Store User Data**: Temporarily store user data during interactions with the application.
- **Enhance User Experience**: Provide a seamless experience by remembering user data across different pages and requests.

### What Are the Various Ways of Doing Session Management in ASP.NET?

ASP.NET provides several ways to manage sessions:

1. **In-Process Session State**:
   - **Description**: Stores session data in the memory of the web server.
   - **Advantages**: Fast access to session data.
   - **Limitations**: Not suitable for web farms or high availability setups because session data is not shared across servers.

2. **StateServer Session State**:
   - **Description**: Stores session data in a separate process called the ASP.NET State Service.
   - **Advantages**: Session data is shared across web servers.
   - **Limitations**: Requires configuration and may introduce latency.

3. **SQL Server Session State**:
   - **Description**: Stores session data in a SQL Server database.
   - **Advantages**: Session data is persistent and can be shared across web servers.
   - **Limitations**: Introduces database overhead and requires SQL Server setup.

4. **Distributed Cache**:
   - **Description**: Stores session data in distributed caching systems like Redis or Azure Cache.
   - **Advantages**: Scalable and suitable for web farms.
   - **Limitations**: Requires additional infrastructure and configuration.

5. **Custom Session State Providers**:
   - **Description**: Implement custom storage solutions for session data.
   - **Advantages**: Tailored to specific needs or third-party systems.
   - **Limitations**: Requires custom implementation and maintenance.

### What Exactly Is a Session?

A **session** is a temporary and unique interaction between a user and a web application that lasts for the duration of the user's visit. During a session, data can be stored and retrieved to maintain continuity and state. Sessions typically start when a user first interacts with the application and end when the user closes the browser or after a certain period of inactivity.

### Explain "HTTP Is a Stateless Protocol"

**HTTP (Hypertext Transfer Protocol)** is considered a stateless protocol because each request from a client to a server is independent and does not retain any information about previous requests. This means:

- **No Built-In Memory**: HTTP does not inherently keep track of user interactions or session information between requests.
- **New Request Context**: Each HTTP request is processed in isolation, without knowledge of previous interactions.

To overcome this, web applications use mechanisms like cookies, sessions, or tokens to maintain state and track user interactions.

### Are Sessions Enabled by Default?

No, sessions are not enabled by default in ASP.NET Core. ASP.NET Core provides a more modular approach to session management, allowing developers to enable and configure session state as needed.

### How to Enable Sessions in MVC Core?

To enable sessions in ASP.NET Core MVC:

1. **Install Required Package**:
   - Ensure that you have the `Microsoft.AspNetCore.Session` package installed.

2. **Configure Services**:
   - In `Startup.cs`, add session services in the `ConfigureServices` method:

   ```csharp
   public void ConfigureServices(IServiceCollection services)
   {
       services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
       services.AddSession(options =>
       {
           options.IdleTimeout = TimeSpan.FromMinutes(20); // Set session timeout
           options.Cookie.HttpOnly = true; // Protects the session cookie from client-side scripts
           options.Cookie.IsEssential = true; // Makes the session cookie essential for the application
       });
       services.AddControllersWithViews();
   }
   ```

3. **Configure Middleware**:
   - In `Startup.cs`, add session middleware in the `Configure` method:

   ```csharp
   public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
   {
       if (env.IsDevelopment())
       {
           app.UseDeveloperExceptionPage();
       }
       else
       {
           app.UseExceptionHandler("/Home/Error");
           app.UseHsts();
       }

       app.UseHttpsRedirection();
       app.UseStaticFiles();

       app.UseRouting();

       app.UseSession(); // Add this line to enable session middleware

       app.UseAuthorization();

       app.UseEndpoints(endpoints =>
       {
           endpoints.MapControllerRoute(
               name: "default",
               pattern: "{controller=Home}/{action=Index}/{id?}");
       });
   }
   ```

4. **Use Session in Controllers**:
   - Access and manipulate session data using `HttpContext.Session` in your controllers:

   ```csharp
   public class HomeController : Controller
   {
       public IActionResult Index()
       {
           HttpContext.Session.SetString("UserName", "John Doe");
           var userName = HttpContext.Session.GetString("UserName");
           ViewBag.UserName = userName;
           return View();
       }
   }
   ```

### Are Session Variables Shared (Global) Between Users?

No, session variables are not shared between users. Each user has a unique session, and session variables are isolated to the individual user’s session. This isolation ensures that data stored in one user’s session is not accessible to another user, maintaining privacy and security.

### Do Session Variables Use Cookies?

Yes, session variables often use cookies to track sessions. The session cookie typically contains a unique session identifier (session ID) that the server uses to associate the cookie with the corresponding session data stored on the server. This allows the server to retrieve the correct session data for each request from the same user.

### What Is a Cookie?

A **cookie** is a small piece of data sent by a server to a client (browser) and stored on the client’s device. Cookies are used for various purposes, such as:

- **Session Management**: Tracking user sessions and storing session identifiers.
- **Personalization**: Saving user preferences and settings.
- **Tracking**: Monitoring user behavior and interactions across websites.

Cookies have attributes such as name, value, expiration date, and domain, which determine how they are used and when they expire.

### Explain Idle Timeout in Sessions

**Idle timeout** (or session timeout) is the period of inactivity after which a session is considered expired. If a user does not interact with the application for the duration of the idle timeout, the session is terminated, and the user may need to log in again or reinitialize their session. This helps to enhance security by reducing the risk of session hijacking or unauthorized access after a period of inactivity.

Example configuration:

```csharp
services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20); // Session expires after 20 minutes of inactivity
});
```

### What Does a Context Mean in HTTP?

In the context of HTTP, **context** typically refers to the **HTTP context**, which contains information about the current request and response. It provides details such as:

- **Request**: Information about the incoming request, including headers, query strings, and request body.
- **Response**: Methods and properties for configuring the response, such as setting headers and content.

In ASP.NET Core, the `HttpContext` object provides access to both request and response details, allowing you to interact with and manipulate them.

### When Should We Use ViewData?

**ViewData** is a dictionary that is used to pass data from a controller to a view in ASP.NET MVC. You might use `ViewData` when:

- You need to pass data that does not require strong typing.
- You want to pass temporary data that is only needed for a single request.
- You need a simple way to transfer data to a view without using a strongly-typed model.

Example:

```csharp
public IActionResult Index()
{
    ViewData["Message"] = "Hello, World!";
    return View();
}
```

### How to Pass Data from Controller to View?

There are several ways to pass data from a controller to a view:

1. **ViewData**: Use the `ViewData` dictionary to pass data.

   ```csharp
   public IActionResult Index()
   {
       ViewData["Message"] = "Hello, World!";
       return View();
   }
   ```

2. **ViewBag**: Use `ViewBag`, a dynamic property, to pass data.

   ```csharp
   public IActionResult Index()
   {
       ViewBag.Message = "Hello, World!";
       return View();
   }
   ```

3. **Strongly Typed Models**: Pass a model object to the view.

   ```csharp
   public IActionResult Index()
   {
       var model = new MyModel { Message = "Hello, World!" };
       return View(model);
   }
   ```

4. **TempData**: Pass data between actions or across redirects.

   ```csharp
   public IActionResult Index()
   {
       TempData["Message"] = "Hello, World!";
       return RedirectToAction("OtherAction");
   }

   public IActionResult OtherAction()
   {
       var message = TempData["Message"];
       return View();
   }
   ```

### In Same Request, Can ViewData Persist Across Actions?

No, `ViewData` does not persist across different actions within the same request. `ViewData` is only available for the current request and is typically used to pass data from the controller to a view. If you need to pass data between actions, consider using `TempData`, which persists across redirects.

### ViewData vs. ViewBag

- **ViewData**:
  - **Type**: Dictionary (type-safe).
  - **Syntax**: `ViewData["Key"]`.
  - **Access**: Requires casting to the appropriate type.
  - **Usage**: Suitable for scenarios where you need a dictionary-based approach.

- **ViewBag**:
  - **Type**: Dynamic property.
  - **Syntax**: `ViewBag.Property`.
  - **Access**: No need for casting; type safety is not enforced.
  - **Usage**: Provides a more flexible, dynamic approach, but lacks compile-time checking.

### How Does ViewBag Work Internally?

**ViewBag** is a dynamic wrapper around `ViewData`. It uses the dynamic type feature in C# to allow adding properties to it on the fly. Internally, `ViewBag` is backed by the `ViewDataDictionary`, which stores data as a dictionary with string keys. When you set a property on `ViewBag`, it is actually stored in the underlying `ViewDataDictionary` and retrieved through dynamic member access.

Example:

```csharp
public IActionResult Index()
{
    ViewBag.Message = "Hello, World!";
    return View();
}
```

Internally, this translates to:

```csharp
ViewData["Message"] = "Hello, World!";
```

### What Is a ViewModel?

A **ViewModel** is a class specifically designed to hold data that is used by a view. It is part of the Model-View-Controller (MVC) pattern and serves as a container for data that the view needs to display. Unlike domain models, which represent data and business logic, ViewModels are tailored to the needs of the view and can include data from multiple sources or entities.

**Key Characteristics of a ViewModel**:
- **Tailored Data**: Contains only the data needed for a specific view.
- **Combines Data**: May aggregate data from multiple models or services.
- **Facilitates Data Binding**: Simplifies data binding in views, especially with complex data structures.

**Example**:

```csharp
public class ProductViewModel
{
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public string CategoryName { get; set; }
}
```

### ViewBag vs. ViewModel: What's the Best Practice?

**ViewBag** and **ViewModel** serve different purposes:

- **ViewBag**:
  - **Dynamic**: Uses dynamic typing, making it flexible but less type-safe.
  - **Temporary Data**: Useful for passing simple data from controllers to views, especially when the data is not part of a model.
  - **Short-Lived**: Typically used for passing data within a single request.

- **ViewModel**:
  - **Strongly Typed**: Provides compile-time checking and IntelliSense support.
  - **Structured Data**: Holds data in a structured, type-safe manner, making it ideal for complex views and scenarios.
  - **Best Practice**: Preferred for passing data to views, especially when the data is complex or needs validation.

**Best Practice**: Use ViewModels for passing data to views when you need strong typing and a structured approach. Use ViewBag for simple, temporary data or when you need a dynamic solution.

### Explain TempData

**TempData** is a mechanism for storing data that persists across redirects and multiple requests. It is used to pass data between actions, often after a redirect or when you need to maintain data temporarily.

**Key Features of TempData**:
- **Persistence Across Redirects**: Data stored in TempData is available across redirects and multiple requests.
- **Cleared After Retrieval**: TempData is removed from the storage after it has been read unless explicitly kept.

**Example**:

```csharp
public IActionResult Create()
{
    TempData["Message"] = "Item created successfully!";
    return RedirectToAction("Index");
}

public IActionResult Index()
{
    var message = TempData["Message"];
    return View();
}
```

### Can TempData Persist Across Action Redirects?

Yes, TempData is designed to persist data across action redirects. It is particularly useful for passing data from one action to another, especially after a redirect.

### How Is TempData Different from ViewData?

- **TempData**:
  - **Persistence**: Data is available across redirects and multiple requests.
  - **Lifetime**: Data is cleared after being read unless explicitly kept.
  - **Use Case**: Ideal for passing data between actions or after a redirect.

- **ViewData**:
  - **Scope**: Data is only available for the duration of a single request.
  - **Lifetime**: Data is not persisted beyond the current request.
  - **Use Case**: Suitable for passing data from controllers to views within the same request.

### If TempData Is Read, Is It Available for the Next Request?

No, TempData is typically cleared after being read. However, you can use the `Keep` method to retain the data for the next request if needed.

### How to Persist TempData?

To persist TempData across requests, you can use the `Keep` method, which retains the data for the next request:

```csharp
public IActionResult Create()
{
    TempData["Message"] = "Item created successfully!";
    TempData.Keep("Message"); // Keeps the "Message" key for the next request
    return RedirectToAction("Index");
}
```

### What Does `Keep` Do in TempData?

The `Keep` method is used to retain the TempData values for the next request. It ensures that the data remains available even after it has been read in the current request, allowing it to be accessed in subsequent requests.

### Explain `Peek` in TempData

The `Peek` method allows you to read the value of a TempData key without removing it from storage. This means the data remains available for subsequent requests. It is useful when you want to access the data without clearing it.

**Example**:

```csharp
public IActionResult Index()
{
    var message = TempData.Peek("Message"); // Read without clearing
    return View();
}
```

### How Is TempData Different from Session Variables?

- **TempData**:
  - **Lifetime**: Designed for short-term storage, available across redirects but cleared after being read unless kept.
  - **Scope**: Ideal for temporary data that needs to persist across redirects.
  - **Use Case**: Passing data between actions or after a redirect.

- **Session Variables**:
  - **Lifetime**: Persistent for the duration of the user’s session until it expires or is explicitly cleared.
  - **Scope**: Suitable for maintaining user-specific data throughout the session.
  - **Use Case**: Storing data like user preferences, authentication information, or other stateful information.

### If I Restart the Server, Do TempData and Session Stay?

- **TempData**: No, TempData does not persist through a server restart. TempData is stored temporarily, and its data is typically lost if the server is restarted or if the application pool is recycled.

- **Session**: Session data is generally lost if the server is restarted unless you are using a distributed session state provider, such as SQL Server or a distributed cache like Redis. In-memory session state (default) is stored on the server’s memory, so a server restart will clear it.

### Is TempData Private to a User?

Yes, TempData is private to a user. Each user's TempData is isolated from other users. TempData is designed to pass data between actions or requests for the same user, and the data is not shared with other users.

### ViewData vs. ViewBag vs. TempData vs. Session Variables

Here’s a comparison:

- **ViewData**:
  - **Scope**: Available only for the duration of a single request.
  - **Type**: Dictionary-based (requires casting).
  - **Usage**: Passes data from controllers to views within the same request.

- **ViewBag**:
  - **Scope**: Same as ViewData, available only for the current request.
  - **Type**: Dynamic property.
  - **Usage**: Similar to ViewData but provides a dynamic approach.

- **TempData**:
  - **Scope**: Persists across redirects and multiple requests.
  - **Type**: Dictionary-based but designed to be temporary.
  - **Usage**: Passes data between actions, especially after redirects. Data is cleared after it is read unless explicitly kept.

- **Session Variables**:
  - **Scope**: Persistent for the duration of the user’s session.
  - **Type**: Key-value pairs stored in server-side memory or distributed storage.
  - **Usage**: Maintains user-specific data across multiple requests during the session.

### What Is Web API?

**Web API** is a framework for building HTTP-based services that can be consumed by various clients such as browsers, mobile apps, and other web services. It is part of ASP.NET and is designed for creating RESTful services that follow standard HTTP methods (GET, POST, PUT, DELETE).

### What Is the Advantage of Web API?

**Advantages of Web API** include:

- **Stateless**: Web API adheres to REST principles, which promote stateless interactions and scalability.
- **Cross-Platform**: Can be accessed from different platforms and devices, including web, mobile, and desktop.
- **HTTP Methods**: Utilizes standard HTTP methods (GET, POST, PUT, DELETE) for CRUD operations.
- **Flexible Data Formats**: Supports various data formats like JSON, XML, and more.
- **Ease of Integration**: Easily integrates with client-side technologies and third-party services.
- **Scalability**: Designed to handle a large number of clients and requests efficiently.

### Explain REST and Architectural Constraints of REST

**REST (Representational State Transfer)** is an architectural style for designing networked applications. It uses standard HTTP methods and emphasizes stateless interactions between clients and servers.

**Architectural Constraints of REST**:

1. **Stateless**: Each request from a client to a server must contain all the information the server needs to fulfill the request. The server does not store any state about the client session.

2. **Client-Server Architecture**: Separates the client (user interface) from the server (data storage and processing), allowing for scalability and independent development.

3. **Uniform Interface**: A consistent and standard interface between client and server, simplifying the interaction. This includes standardized methods and data formats.

4. **Resource-Based**: Resources (data entities) are identified by URLs. Clients interact with resources using standard HTTP methods.

5. **Layered System**: The architecture can be composed of multiple layers, with each layer having a specific responsibility. This allows for scalability and flexibility in system design.

6. **Code on Demand (Optional)**: Servers can extend client functionality by transferring executable code (e.g., JavaScript). This is optional and not always used.

### Can We Use TCP/IP Protocol with Web API?

Web API typically uses HTTP/HTTPS protocols over TCP/IP. While Web API is designed to work with HTTP/HTTPS, TCP/IP itself is a lower-level protocol that provides the underlying transport layer. Web API does not directly use raw TCP/IP but relies on HTTP/HTTPS, which operates over TCP/IP.

### How Is Web API Different from MVC Controller?

- **Web API**:
  - **Purpose**: Designed for building HTTP services that can be consumed by various clients.
  - **Methods**: Typically uses HTTP methods (GET, POST, PUT, DELETE) to handle CRUD operations.
  - **Return Types**: Can return various data formats like JSON, XML, etc.
  - **Routing**: Uses attribute-based routing or convention-based routing for endpoints.

- **MVC Controller**:
  - **Purpose**: Designed for handling web requests and rendering HTML views in a web application.
  - **Methods**: Typically handles requests via actions that return views or other data.
  - **Return Types**: Primarily returns views, partial views, or content (HTML).
  - **Routing**: Uses route configurations to map URLs to controller actions.

### What Is Content Negotiation in Web API?

**Content Negotiation** is the process by which a Web API determines the format of the response to be sent back to the client based on the request headers. It allows clients to specify the desired media type (e.g., JSON, XML) in the `Accept` header, and the server responds in the format that the client requested.

**Example**:

```http
GET /api/products HTTP/1.1
Accept: application/json
```

The server will respond with JSON data if it supports the requested media type.

### Web API vs. WCF

**Web API** and **WCF (Windows Communication Foundation)** are both frameworks for building services, but they have different focuses:

- **Web API**:
  - **Protocol**: Primarily uses HTTP/HTTPS.
  - **Usage**: Ideal for creating RESTful services and APIs consumed by web, mobile, and other clients.
  - **Data Formats**: Supports JSON, XML, and other formats.
  - **Lightweight**: Simpler and lighter-weight compared to WCF, with a focus on web-based services.

- **WCF**:
  - **Protocol**: Supports multiple protocols, including HTTP, TCP, Named Pipes, and MSMQ.
  - **Usage**: Suitable for building a wide range of service-oriented applications, including enterprise-level services.
  - **Data Formats**: Supports various serialization formats, including XML and JSON.
  - **Feature-Rich**: Provides extensive features like reliable messaging, security, and transactions.

### WCF REST vs. Web API REST

**WCF REST**:
- **Framework**: Part of Windows Communication Foundation (WCF).
- **Protocol**: Can use multiple protocols (HTTP, TCP, Named Pipes, MSMQ).
- **Data Formats**: Supports XML, JSON, and other formats.
- **Configuration**: Requires configuration in the `web.config` or `app.config` file.
- **Flexibility**: More complex setup and configuration for REST services.

**Web API REST**:
- **Framework**: Part of ASP.NET.
- **Protocol**: Primarily uses HTTP/HTTPS.
- **Data Formats**: Supports JSON, XML, and other formats.
- **Configuration**: Configured through attributes and conventions in code.
- **Simplicity**: Designed for easy creation of RESTful services with minimal configuration.

### How to Return HTTP Status Codes

In both Web API and WCF REST, you can return HTTP status codes by setting the response in your action methods or service operations. 

**In Web API**:

```csharp
public IHttpActionResult Get()
{
    if (someCondition)
    {
        return Ok(data); // 200 OK
    }
    else
    {
        return NotFound(); // 404 Not Found
    }
}
```

**In WCF REST**:

```csharp
public HttpResponseMessage Get()
{
    if (someCondition)
    {
        return Request.CreateResponse(HttpStatusCode.OK, data); // 200 OK
    }
    else
    {
        return Request.CreateResponse(HttpStatusCode.NotFound); // 404 Not Found
    }
}
```

### For Error, Which Status Code Is Returned?

Common HTTP status codes for errors:

- **400 Bad Request**: The request is invalid or cannot be processed.
- **401 Unauthorized**: Authentication is required or has failed.
- **403 Forbidden**: The client does not have permission to access the resource.
- **404 Not Found**: The resource could not be found.
- **500 Internal Server Error**: An unexpected error occurred on the server.

### How Did You Secure Your Web API?

Securing a Web API typically involves:

1. **Authentication**: Ensuring that clients are who they claim to be (e.g., using tokens, OAuth).
2. **Authorization**: Ensuring that authenticated clients have permission to access specific resources.
3. **HTTPS**: Encrypting data in transit using HTTPS to protect against eavesdropping and tampering.
4. **Input Validation**: Validating and sanitizing input to prevent attacks like SQL injection or XSS.
5. **Rate Limiting**: Implementing rate limiting to protect against abuse and denial-of-service attacks.
6. **Logging and Monitoring**: Keeping track of access and errors to detect and respond to security issues.

### How Do Current JS Frameworks Work with Web API?

Current JavaScript frameworks (like Angular, React, Vue.js) interact with Web APIs primarily through HTTP requests. They use libraries or built-in methods to send requests to APIs and handle responses. 

- **Angular**: Uses `HttpClient` service for making HTTP requests.
- **React**: Often uses `fetch` API or libraries like `axios` for HTTP requests.
- **Vue.js**: Can use `axios` or the built-in `fetch` API for HTTP communication.

These frameworks typically handle asynchronous operations, manage state, and update the user interface based on data retrieved from APIs.

### How Does Token-Based Authentication Work?

**Token-Based Authentication** involves:

1. **Client Request**: The client sends login credentials to an authentication server.
2. **Token Issuance**: If credentials are valid, the server issues a token (e.g., JWT) to the client.
3. **Token Storage**: The client stores the token (typically in local storage or cookies).
4. **Token Transmission**: For subsequent requests, the client includes the token in the `Authorization` header (e.g., `Bearer <token>`).
5. **Token Validation**: The server verifies the token and processes the request if valid.

### Why Is It Called JWT Token?

**JWT (JSON Web Token)** is named for the format it uses:

- **JSON**: The token is formatted as JSON, making it easy to work with in web applications.
- **Web Token**: It is used in web environments to securely transmit information between parties.

### Explain the 3 Sections of JWT Token

A JWT consists of three parts, separated by dots (`.`):

1. **Header**: Contains metadata about the token, including the type of token and the signing algorithm used (e.g., `{"alg": "HS256", "typ": "JWT"}`).
2. **Payload**: Contains the claims or the data to be transmitted, such as user ID, roles, and other information.
3. **Signature**: Used to verify the authenticity of the token. It is created by encoding the header and payload, then signing it with a secret key.

### What Are Identity and Claims?

- **Identity**: Refers to the representation of a user or client in the system. It is often linked to authentication and user profiles.
- **Claims**: Pieces of information or attributes about the user or context encoded within a JWT. Claims can include user roles, permissions, and other metadata.

### Differentiate Between Authentication vs. Authorization

- **Authentication**: The process of verifying the identity of a user or system. It answers the question, "Who are you?" Common methods include username/password, tokens, and multi-factor authentication.
  
- **Authorization**: The process of determining what an authenticated user or system is allowed to do. It answers the question, "What can you do?" It involves checking user permissions and roles to control access to resources.

In summary:
- **Authentication** ensures users are who they claim to be.
- **Authorization** ensures users have the appropriate permissions for the actions they are attempting to perform.

### Claims vs. Roles

- **Claims**:
  - **Definition**: Claims are pieces of information about the user, such as name, email, or permissions. They are key-value pairs stored within a token and can represent any attribute related to the user or context.
  - **Usage**: Claims can be used to store user-specific data and can include custom attributes. For example, a claim might represent a user's subscription level or department.

- **Roles**:
  - **Definition**: Roles are a type of claim specifically used to categorize users based on their access levels or responsibilities. Common roles might include `Admin`, `User`, `Manager`, etc.
  - **Usage**: Roles are often used to control access to specific resources or functionalities within an application. They are usually simpler than claims and are focused on authorization.

### Principal vs. Identity

- **Identity**:
  - **Definition**: Represents the actual user or entity, encapsulating information about the user, such as username and authentication details.
  - **Usage**: The `IIdentity` interface in .NET represents the identity of a user and provides methods to access user-related data like the user’s name and authentication status.

- **Principal**:
  - **Definition**: Represents the security context of the user, including the identity and any associated roles or claims. It is the overarching object that combines both identity and roles/claims.
  - **Usage**: The `IPrincipal` interface in .NET represents the user’s context, including their `IIdentity` and their roles or claims. It allows the system to determine what the user is allowed to do.

### Can We Put Critical Information in JWT Token?

**No**, you should not put highly sensitive or critical information in a JWT token. JWT tokens are often sent in plain text (though encrypted in some cases), and they are accessible to anyone who intercepts them. Instead, use JWTs to convey non-sensitive information or identifiers and keep critical data secure in a more secure environment.

### How Do You Create a JWT Token in MVC?

**To create a JWT token in an ASP.NET MVC application**:

1. **Install Required Packages**: Ensure you have the necessary packages for JWT handling, such as `System.IdentityModel.Tokens.Jwt` and `Microsoft.IdentityModel.Tokens`.

2. **Configure JWT Settings**: Set up JWT settings in your `appsettings.json` or another configuration source.

   ```json
   {
       "Jwt": {
           "Key": "your_secret_key_here",
           "Issuer": "your_issuer",
           "Audience": "your_audience"
       }
   }
   ```

3. **Create the Token**:

   ```csharp
   public string GenerateToken(string userId)
   {
       var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
       var tokenHandler = new JwtSecurityTokenHandler();
       var tokenDescriptor = new SecurityTokenDescriptor
       {
           Subject = new ClaimsIdentity(new Claim[]
           {
               new Claim(ClaimTypes.Name, userId)
           }),
           Expires = DateTime.UtcNow.AddHours(1),
           Issuer = _configuration["Jwt:Issuer"],
           Audience = _configuration["Jwt:Audience"],
           SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
       };
       var token = tokenHandler.CreateToken(tokenDescriptor);
       return tokenHandler.WriteToken(token);
   }
   ```

4. **Add Token to Response**:

   ```csharp
   public IActionResult Login()
   {
       var token = GenerateToken(userId);
       return Ok(new { Token = token });
   }
   ```

### What HTTP Status Code Do You Send for Unauthorized Access?

For unauthorized access (when the user is not authenticated), you typically send:

- **401 Unauthorized**: Indicates that authentication is required or has failed.

### Where Is the Token Checked in ASP.NET MVC?

In ASP.NET MVC or ASP.NET Core, the token is usually checked in the middleware pipeline. You configure authentication middleware to validate the token and set the user’s identity.

**ASP.NET Core Example**:

- **Configure Middleware in `Startup.cs`**:

   ```csharp
   public void ConfigureServices(IServiceCollection services)
   {
       services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = Configuration["Jwt:Issuer"],
                   ValidAudience = Configuration["Jwt:Audience"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
               };
           });
   }

   public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
   {
       app.UseAuthentication();
       app.UseAuthorization();
       // other middleware
   }
   ```

- **Authorize Attribute**: The `[Authorize]` attribute is used to restrict access to controllers or actions based on authentication and authorization policies.

### What Is the Use of the Authorize Attribute?

The `[Authorize]` attribute is used to enforce authorization policies on controllers or actions. It ensures that only authenticated users (or users with specific roles or claims) can access the decorated resource. 

**Example**:

```csharp
[Authorize(Roles = "Admin")]
public IActionResult AdminOnly()
{
    return View();
}
```

### How Did You Implement JWT Token Security?

JWT token security is typically implemented by:

1. **Generating Tokens Securely**: Use strong algorithms (e.g., HS256) and secure keys for token generation.
2. **Validating Tokens**: Ensure tokens are validated for signature, issuer, audience, and expiration.
3. **Using HTTPS**: Protect token transmission with HTTPS to prevent interception.
4. **Storing Tokens Securely**: On the client side, use secure storage methods (e.g., HTTP-only cookies) to prevent token theft.

### How Do We Send Tokens from the Client Side?

Tokens are generally sent from the client side in the `Authorization` header of HTTP requests:

```javascript
fetch('https://api.example.com/data', {
    method: 'GET',
    headers: {
        'Authorization': `Bearer ${token}`
    }
});
```

**Other Methods**:
- **Cookies**: Tokens can also be sent in HTTP-only cookies for added security, preventing access via JavaScript.

### From etc., How Is the Token Passed?

Tokens are passed from the client to the server in different ways, such as:

- **HTTP Headers**: Most common method using the `Authorization` header with the `Bearer` scheme.
- **Cookies**: Tokens can be stored in cookies and sent with each request.
- **Query Parameters**: Although less secure, tokens can be included in URL query parameters (not recommended due to exposure in logs and referrer headers).

**Example of Passing Token in HTTP Header**:

```http
GET /api/resource HTTP/1.1
Host: example.com
Authorization: Bearer <your_jwt_token>
```

### Increase UX Experience in Mobile Apps to Avoid Relogin

To enhance user experience and reduce the need for frequent re-login in mobile apps, you can implement:

1. **Token Expiration Management**: Use refresh tokens to obtain new access tokens without requiring the user to log in again.
2. **Session Management**: Implement longer session durations and remember users on devices securely.
3. **Secure Storage**: Store tokens securely in device storage with encryption.
4. **Background Refresh**: Automatically refresh tokens in the background before they expire, ensuring a seamless user experience.
5. **Persistent Login**: Provide options for users to stay logged in across sessions, but make sure to secure the app to prevent unauthorized access.

### What Are Refresh Tokens?

**Refresh tokens** are credentials used to obtain new access tokens after the original access token has expired. They have a longer lifespan than access tokens and are used to maintain user sessions without requiring the user to reauthenticate.

### How Does a Refresh Token Work?

1. **Initial Authentication**: The user logs in and receives both an access token and a refresh token.
2. **Access Token Expiry**: When the access token expires, the app uses the refresh token to request a new access token from the authentication server.
3. **Token Renewal**: The authentication server validates the refresh token and, if valid, issues a new access token (and sometimes a new refresh token).
4. **Continued Access**: The app uses the new access token to access protected resources.

### Access Tokens vs. Refresh Tokens

- **Access Tokens**:
  - **Purpose**: Used to access protected resources.
  - **Lifespan**: Short-lived (e.g., minutes to hours).
  - **Usage**: Sent with each request in the `Authorization` header.

- **Refresh Tokens**:
  - **Purpose**: Used to obtain new access tokens when the current one expires.
  - **Lifespan**: Longer-lived (e.g., days to months).
  - **Usage**: Sent to the authentication server to get new access tokens.

### Whose Expiry Time Is More: Access Tokens or Refresh Tokens?

**Refresh tokens** have a longer expiry time compared to access tokens. Access tokens are short-lived to limit the impact of token theft, while refresh tokens are long-lived to allow users to stay logged in without frequent reauthentication.

### Explain Revocation of Refresh Token

**Revocation of a refresh token** involves invalidating the token so that it can no longer be used to obtain new access tokens. This can be done by:

1. **Server-Side Tracking**: Maintaining a list of revoked tokens on the server and checking this list during token renewal requests.
2. **Token Expiry**: Setting expiration policies for refresh tokens so they naturally become invalid after a certain period.
3. **User Logout**: Revoking the refresh token when the user logs out or changes their credentials.

### How to Extract Principal from a Token

To extract the principal (user identity) from a token:

1. **Parse the Token**: Decode the JWT to extract claims and other information.
2. **Validate the Token**: Ensure the token is valid and has not expired.
3. **Extract Claims**: Retrieve user information (such as user ID, roles) from the token’s claims.

**Example in ASP.NET Core**:

```csharp
public ClaimsPrincipal GetPrincipalFromToken(string token)
{
    var tokenHandler = new JwtSecurityTokenHandler();
    var principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out _);
    return principal;
}
```

### What Is the Best Practice to Store Tokens on the Client Side?

Best practices for storing tokens on the client side include:

1. **Secure Storage**: Use secure mechanisms like HTTP-only cookies for storage to prevent access via JavaScript.
2. **Encryption**: Encrypt tokens to protect them from unauthorized access.
3. **Short Lifespan**: Use short-lived access tokens and refresh tokens to minimize exposure.
4. **Regular Rotation**: Regularly rotate tokens and keys to enhance security.

### If We Store JWT in Cookies, How to Save from XSS Attacks?

To protect cookies from XSS attacks:

1. **HTTP-Only Flag**: Set the `HttpOnly` flag on cookies to prevent client-side scripts from accessing them.
2. **Secure Flag**: Set the `Secure` flag to ensure cookies are only sent over HTTPS.
3. **SameSite Attribute**: Use the `SameSite` attribute to prevent cookies from being sent in cross-site requests.

**Example**:

```csharp
HttpCookie cookie = new HttpCookie("token", token);
cookie.HttpOnly = true;
cookie.Secure = true; // only for HTTPS
cookie.SameSite = SameSiteMode.Strict;
Response.Cookies.Add(cookie);
```

### What Are OAuth and OpenID?

- **OAuth**:
  - **Definition**: An authorization framework that allows third-party applications to access user resources without exposing credentials. It defines how tokens are used to grant access to resources.
  - **Usage**: Commonly used for authorization in applications, allowing users to grant limited access to their resources.

- **OpenID Connect**:
  - **Definition**: An authentication layer built on top of OAuth 2.0. It provides a standardized way to authenticate users and retrieve their identity information.
  - **Usage**: Adds user authentication on top of OAuth, allowing single sign-on (SSO) and user profile retrieval.

### When Should We Use What?

- **OAuth**: Use OAuth when you need to authorize third-party applications to access user resources without handling user credentials. It’s primarily for authorization.
- **OpenID Connect**: Use OpenID Connect when you need to authenticate users and obtain user identity information in addition to authorization.

### What Is Identity Server?

**Identity Server** is a framework for implementing authentication and authorization solutions. It supports protocols like OAuth 2.0 and OpenID Connect to manage user identities and access control.

- **Features**: Provides support for single sign-on (SSO), multi-factor authentication, and user management.
- **Usage**: Often used in enterprise applications to manage user authentication and authorization across different systems.

### How to Achieve Single Sign-On (SSO)?

To achieve Single Sign-On (SSO):

1. **Use Identity Server or Similar Solutions**: Implement an identity provider like Identity Server that supports SSO protocols (e.g., OpenID Connect).
2. **Configure Federated Authentication**: Set up federated authentication across multiple applications or services.
3. **Share Authentication Tokens**: Ensure that applications share and validate tokens issued by the SSO provider.

### What Are Scopes in Identity Server?

**Scopes** define the access levels or permissions that are requested by applications when obtaining access tokens. They specify the range of access granted to the client application.

- **Usage**: Scopes allow clients to request specific permissions and control the extent of access granted.
- **Example**: A scope might include `read`, `write`, or `admin` permissions, defining what actions the client can perform on behalf of the user. 

**Example**:

```json
{
    "scope": "read write",
    "client_id": "your_client_id",
    "response_type": "token"
}
```
