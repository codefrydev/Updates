---
title: "Set Five"
author: "PrashantUnity"
weight: 215
date: 2024-08-03
lastmod: 2024-10-22
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

### ASP.NET MVC Overview

1. **What is ASP.NET MVC?**
   - **ASP.NET MVC** is a framework for building web applications using the Model-View-Controller (MVC) architectural pattern. It allows developers to create scalable, testable, and maintainable web applications. ASP.NET MVC provides a clear separation of concerns between the presentation layer (views), the business logic (controllers), and the data model (models).

2. **What are the Three Main Components of an ASP.NET MVC Application?**
   - **Model**: Represents the application’s data and the business rules that govern access to and updates of this data. Models are typically used to retrieve data from the database.
   - **View**: Responsible for displaying the data to the user. It represents the UI of the application.
   - **Controller**: Handles user input and interaction. It reads data from the view, controls user input, and sends input data to the model.

3. **Explain about ASP.NET MVC 5.**
   - **ASP.NET MVC 5** is a version of the ASP.NET MVC framework that includes several new features:
     - **Attribute Routing**: Allows developers to define routes using attributes directly on controller actions.
     - **Authentication Filters**: New filters that can be applied globally or to specific controllers or actions to control user access.
     - **ASP.NET Identity**: A membership system for adding login functionality to your application.
     - **Bootstrap Support**: Default templates are now integrated with Bootstrap for responsive design.
     - **Filter Overrides**: Provides more granular control over action filters.

### Routing and Areas

4. **What is Routing in ASP.NET MVC?**
   - **Routing** is the mechanism in ASP.NET MVC that maps URL requests to a specific controller action. It defines how the URLs in your application are structured and how they correspond to the controller actions. Routing is typically defined in the `RouteConfig.cs` file.

5. **When to Use Attribute Routing?**
   - **Attribute Routing** is useful when you want more control over the routing mechanism at the level of individual controller actions. It allows routes to be specified directly using attributes above the action methods and is particularly useful for:
     - Complex or custom routing requirements.
     - Organizing routes in a more readable and maintainable way.
     - Defining routes directly on controller methods for clarity.

6. **What is an Area in ASP.NET MVC?**
   - An **Area** is a way to partition a large MVC application into smaller functional groupings, each with its own set of controllers, views, and models. Areas help to manage and organize related functionality within a project, which can be useful in applications with multiple modules or sections (e.g., admin, user, customer support).

### JSON and Filters

7. **What is JsonResultType (JavaScript Object Notation Result Type) in ASP.NET MVC?**
   - **JsonResult** is a type of action result in ASP.NET MVC that returns JSON data to the client. It is commonly used in AJAX-based applications where the client expects data in JSON format.
     ```csharp
     public JsonResult GetUserData() {
         var data = new { Name = "John", Age = 30 };
         return Json(data, JsonRequestBehavior.AllowGet);
     }
     ```

8. **Explain about ASP.NET MVC Filters.**
   - **Filters** are custom attributes that provide a way to execute logic before or after a controller action runs. They are used for tasks like logging, authorization, error handling, and caching. ASP.NET MVC provides several built-in filter types:
     - **Authorization Filters**: e.g., `AuthorizeAttribute`
     - **Action Filters**: e.g., `OnActionExecuting`
     - **Result Filters**: e.g., `OnResultExecuting`
     - **Exception Filters**: e.g., `HandleErrorAttribute`

9. **What are Action Filters in ASP.NET MVC?**
   - **Action Filters** are a type of filter that execute before or after an action method runs. They are used to implement cross-cutting concerns, such as logging, exception handling, and validation logic. Action filters can be applied globally, at the controller level, or at the action level.

### Advantages and Data Passing

10. **What are the Advantages of ASP.NET MVC?**
    - **Separation of Concerns**: Clear separation between the data (model), UI (view), and logic (controller).
    - **Testability**: Facilitates test-driven development by making the code more modular and easier to test.
    - **Extensibility**: ASP.NET MVC is highly extensible using dependency injection, custom filters, and view engines.
    - **Control over HTML**: Provides full control over the generated HTML, making it easier to implement standards-compliant markup and custom UI elements.

11. **What is ViewBag and ViewData in ASP.NET MVC?**
    - **ViewBag**: A dynamic property that provides a convenient way to pass data from a controller to a view. It does not require type casting and is less prone to null reference errors.
    - **ViewData**: A dictionary object used to pass data from the controller to the view. It requires type casting when retrieving data in the view.
      ```csharp
      ViewBag.Message = "Hello, World!";
      ViewData["Message"] = "Hello, World!";
      ```

### Optimization and Views

12. **What are Bundling and Minification in ASP.NET MVC?**
    - **Bundling**: Combines multiple files into a single file, which reduces the number of HTTP requests needed for a web page.
    - **Minification**: Reduces the size of the bundled files by removing unnecessary characters, such as white spaces and comments, to improve load times.

13. **What is View Engine?**
    - A **View Engine** in ASP.NET MVC is responsible for rendering the HTML from the views. It interprets the code written in the view templates and converts it into HTML that can be sent to the client's browser.

14. **What is Razor View Engine in ASP.NET MVC?**
    - The **Razor View Engine** is a powerful view engine that allows you to write C# or VB.NET code directly in the HTML markup using `@` syntax. It is designed to be lightweight and easy to use, making it the default choice for ASP.NET MVC applications.

15. **Explain about TempData in ASP.NET MVC.**
    - **TempData** is used to pass data from one action to another, or from one request to another. It stores data in the session, which means it's available only for the duration of a single redirect. TempData is useful for scenarios like displaying confirmation messages after a redirect.

### Development Practices and State Management

16. **Explain TDD (Test Driven Development) in ASP.NET MVC.**
    - **TDD** is a software development approach where test cases are written before the actual code is implemented. In ASP.NET MVC, TDD involves writing unit tests for controller actions and models, ensuring that each part of the application behaves as expected before any development is done.

17. **Explain State Management in ASP.NET MVC.**
    - State management refers to preserving the state of the application across multiple requests. In ASP.NET MVC, state management can be achieved using:
      - **Session State**: Stores data server-side across multiple requests.
      - **Cookies**: Stores small amounts of data on the client-side.
      - **Hidden Fields**: Stores data in hidden form fields to persist state between requests.
      - **TempData and ViewData**: Used for temporary data storage during the lifecycle of a request.

### Authentication and Scaffolding

18. **How to Implement Forms Authentication in ASP.NET MVC?**
    - Forms authentication in ASP.NET MVC is implemented using the `Authorize` attribute, configuring the authentication mode in `web.config`, and handling login and logout actions within a controller.
      ```csharp
      [Authorize]
      public ActionResult SecureAction() {
          // Secure action logic
      }
      ```

19. **What are the Advantages of Using Scaffolding in ASP.NET MVC?**
    - **Scaffolding** automates the creation of CRUD (Create, Read, Update, Delete) operations for database models. Advantages include:
      - Speeds up development by generating boilerplate code.
      - Reduces repetitive tasks.
      - Provides a quick way to set up data-driven views and controllers.

### Lifecycle and Rendering

20. **Explain about ASP.NET MVC Lifecycle.**
    - The ASP.NET MVC lifecycle involves several steps:
      - **Request Routing**: Incoming request mapped to a specific route.
      - **Controller Initialization**: Controller class is instantiated.
      - **Action Execution**: Action method on the controller is called.
      - **Result Execution**: The action method returns a result, such as a view, JSON, or a file.
      - **View Rendering**: If the result is a view, it is rendered and returned to the client.

21. **Explain RenderSection() in Detail.**
    - `RenderSection()` is used in layout pages to define optional sections that can be overridden in views that use the layout. It helps in organizing content specific to a view but within the layout structure.
      ```csharp
      @RenderSection("scripts", required: false)
      ```

### HTML Helpers and Validation

22. **What are HTML Helper Methods?**
    - **HTML Helpers** are methods that generate HTML markup for the view. Examples include `Html.TextBoxFor()`, `Html.LabelFor()`, `Html.ActionLink()`, etc. They help streamline HTML generation and provide model binding support.

23. **What is the Use of Validation Summary?**
    - **ValidationSummary** displays a summary of validation messages for the entire model. It is typically used at the top of a

 form to show error messages for all validation failures in a user-friendly format.
      ```csharp
      @Html.ValidationSummary()
      ```

### Tools, Models, and Namespaces

24. **What is Glimpse in ASP.NET MVC?**
    - **Glimpse** is a web diagnostics tool for ASP.NET applications. It provides insights into the execution of your application, showing detailed information about the request lifecycle, routing, views, models, and database queries.

25. **How to Use Multiple Models to a Single View in ASP.NET MVC?**
    - You can use a **ViewModel** that contains multiple models or use the `Tuple` class to pass multiple models to a view.
      ```csharp
      public ActionResult Index() {
          var viewModel = new MyViewModel {
              Model1 = model1,
              Model2 = model2
          };
          return View(viewModel);
      }
      ```

26. **Discuss a Few Necessary Namespaces Used in ASP.NET MVC.**
    - `System.Web.Mvc`: Core MVC functionalities.
    - `System.Web.Routing`: Defines routing classes and functions.
    - `System.Web.Helpers`: Provides helper classes for views and HTML rendering.
    - `System.Web.Optimization`: Bundling and minification support.

### Filters and Entity Framework

27. **What is the Purpose of ”beforeRender()”, “beforeFilter()”, and “afterFilter()” Functions in Controller?**
    - These methods are hooks in the MVC request pipeline:
      - `beforeRender()`: Code to execute before a view is rendered.
      - `beforeFilter()`: Code that runs before an action method is executed.
      - `afterFilter()`: Code that runs after an action method is executed.

28. **Explain Different Development Approaches with the Entity Framework.**
    - **Code First**: Define the model classes first, then generate the database schema from the models.
    - **Database First**: Start with an existing database and generate model classes based on the database schema.
    - **Model First**: Create a conceptual model using a designer, then generate both the database and code.

### Miscellaneous

29. **What is a Postback?**
    - **Postback** refers to the process of submitting an HTTP request from a client to the server and getting a response back, often used to refresh or update part of the web page.

30. **Consider You Are Developing an Application That Uses Forms Authentication in ASP.NET MVC.**
    - Implement login, logout, and session management features. Use the `Authorize` attribute to protect actions and controllers. Configure forms authentication settings in `web.config`.

31. **Consider You Want to Restrict Users from Requesting the Method or Action Directly in the URL of the Browser. How Can It Be Done?**
    - Use the `NonAction` attribute to prevent a method from being invoked as an action method:
      ```csharp
      [NonAction]
      public void HelperMethod() {
          // Code that cannot be accessed as an action
      }
      ```

32. **Can We Overload the Action Methods?**
    - Yes, action methods can be overloaded. However, they should be differentiated by their method signatures, such as parameters. Use route constraints to handle different overloads.

33. **How Do You Manage Unhandled Exceptions in the Action Method?**
    - Use `try-catch` blocks within the action method or configure global exception handling using the `Application_Error` method in `Global.asax` or custom exception filters.

### Creating and Configuring ASP.NET MVC Projects

34. **Explain How to Create an ASP.NET MVC Project with Source Code.**
    - Use Visual Studio to create a new ASP.NET MVC project:
      1. Open Visual Studio and select **Create a new project**.
      2. Choose **ASP.NET Web Application** and select **MVC**.
      3. Configure authentication as needed.
      4. Click **Create**.
      5. Implement controllers, models, and views following the MVC pattern.
      6. Configure routing in `RouteConfig.cs`.
      7. Run the project to test the application.
