---
title: "Set Two"
author: "PrashantUnity"
weight: 211
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

### 1. **What is MVC (Model View Controller)?**
   - MVC is a design pattern used for developing web applications. It separates the application into three interconnected components:
     - **Model**: Represents the application's data and business logic.
     - **View**: The user interface that displays data from the model to the user.
     - **Controller**: Handles user input, manipulates the model, and updates the view accordingly.

### 2. **What are the Advantages of MVC?**
   - **Separation of Concerns**: MVC separates the application into three components, making it easier to manage and test.
   - **Scalability**: The separation allows for scalability since each component can be developed and tested independently.
   - **Reusability**: Components of the application can be reused, which reduces code duplication.
   - **Maintainability**: Changes in one part (like the view) do not affect the others, making the application easier to maintain.

### 3. **Explain MVC Application Life Cycle**
   - **Application Start**: Initializes application configurations (e.g., routes, filters).
   - **Routing**: The routing module maps the URL to a specific controller and action method.
   - **Controller Initialization**: Instantiates the appropriate controller.
   - **Action Execution**: The action method is executed, and any data is processed.
   - **Result Execution**: The result (typically a view) is executed, which generates the HTML output.
   - **Response**: The generated output is sent back to the client's browser.

### 4. **List Out Different Return Types of a Controller Action Method**
   - `ViewResult` (returns a view)
   - `PartialViewResult` (returns a partial view)
   - `JsonResult` (returns JSON-formatted data)
   - `RedirectResult` (redirects to another action or URL)
   - `RedirectToRouteResult` (redirects to a specified route)
   - `ContentResult` (returns raw string content)
   - `FileResult` (returns a file download)
   - `EmptyResult` (returns no content)

### 5. **What are the Filters in MVC?**
   - Filters are used to execute code before or after an action method runs. Types of filters:
     - **Authorization Filters**: Handle authorization logic.
     - **Action Filters**: Run before and after an action method is called.
     - **Result Filters**: Run before and after the view result is executed.
     - **Exception Filters**: Handle exceptions thrown by action methods.

### 6. **What are Action Filters in MVC?**
   - **Action Filters** are a specific type of filter that allow logic to be run before and after an action method execution. Examples include logging, authentication checks, and caching.

### 7. **Explain What is Routing in MVC? What are the Three Segments for Routing Important?**
   - **Routing** is the process of mapping a URL to a controller and action method. 
   - The three segments of a typical route are:
     - **Controller**: Determines which controller to instantiate.
     - **Action**: Determines which action method of the controller to call.
     - **Parameters**: Any additional parameters required by the action method.

### 8. **What is Route in MVC? What is Default Route in MVC?**
   - A **Route** is a URL pattern that is mapped to a controller action. 
   - The **Default Route** is typically defined in `RouteConfig.cs` and looks like this:
     ```csharp
     routes.MapRoute(
         name: "Default",
         url: "{controller}/{action}/{id}",
         defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
     );
     ```

### 9. **Difference Between TempData, ViewData, and ViewBag?**
   - **TempData**: Stores data temporarily during a redirect. It uses session storage and can only persist between two requests.
   - **ViewData**: Stores data in key-value pairs, accessible only for the current request.
   - **ViewBag**: Similar to ViewData but uses dynamic properties, making it easier to use. It is also request-scoped.

### 10. **What is Partial View in MVC?**
   - A partial view is a reusable piece of a user interface that can be rendered inside another view. It is commonly used for components like headers, footers, and widgets.

### 11. **Difference Between View and Partial View?**
   - **View**: A complete page that renders the full layout, including `_Layout.cshtml`.
   - **Partial View**: A segment of a page that does not render the full layout. It is intended to be used within other views.

### 12. **What are HTML Helpers in MVC?**
   - HTML Helpers are methods that generate HTML markup for use in views. Examples include `Html.TextBoxFor()`, `Html.DropDownListFor()`, etc.

### 13. **Explain Attribute-Based Routing in MVC?**
   - Attribute-based routing allows routes to be defined directly on controller actions using attributes. It provides fine-grained control over routing.
   ```csharp
   [Route("products/details/{id:int}")]
   public ActionResult Details(int id) { ... }
   ```

### 14. **What is TempData in MVC?**
   - TempData is used to pass data from one action to another. It stores data temporarily, and it uses the session state to persist data across requests.

### 15. **What is Razor in MVC?**
   - Razor is a view engine that provides a streamlined syntax for embedding server-side code into HTML using C#. It uses `@` as a marker for code.

### 16. **Differences Between Razor and ASPX View Engine in MVC?**
   - **Razor View Engine**:
     - Uses `@` syntax.
     - Cleaner and less verbose.
     - Supports IntelliSense.
   - **ASPX View Engine**:
     - Uses `<%= %>` syntax.
     - More verbose.
     - No modern features like Razor.

### 17. **Main Razor Syntax Rules**
   - Use `@` to transition from HTML to C#.
   - Use `@{ ... }` for inline C# code blocks.
   - Use `@model` to specify the type of the model.
   - Use `@Html` helpers to generate HTML markup.

### 18. **Implement Forms Authentication in MVC**
   - Configure forms authentication in `web.config`.
   - Use the `[Authorize]` attribute on controllers or actions.
   - Redirect users to a login page if not authenticated.

### 19. **Explain Areas in MVC**
   - Areas allow you to partition an MVC application into multiple sections. Each area can have its own controllers, views, and models. They are useful for organizing large applications into smaller modules.

### 20. **Explain the Need of Display Mode in MVC**
   - Display modes allow the application to select different views based on the browser or device type. This is useful for creating mobile-optimized views.

### 21. **Explain the Concept of MVC Scaffolding**
   - MVC scaffolding is a code generation tool that automatically creates CRUD operations and views for models, speeding up the development process.

### 22. **What is Route Constraints in MVC?**
   - Route constraints restrict the type of data that parameters can accept in a route. Example:
     ```csharp
     routes.MapRoute(
         name: "Default",
         url: "{controller}/{action}/{id}",
         defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
         constraints: new { id = @"\d+" } // id must be numeric
     );
     ```

### 23. **What is Razor View Engine in MVC?**
   - The Razor View Engine is a templating engine that allows embedding C# code within HTML. It uses a `.cshtml` file extension.

### 24. **What is Output Caching in MVC?**
   - Output caching stores the rendered HTML of a page so that subsequent requests can be served from the cache rather than regenerating the page. This improves performance.

### 25. **What is Bundling and Minification in MVC?**
   - **Bundling** combines multiple CSS or JavaScript files into a single file.
   - **Minification** removes unnecessary characters (like whitespace) from code to reduce file size.
   - Both techniques improve page load time.

### 26. **What is Validation Summary in MVC?**
   - The `ValidationSummary` helper displays a summary of all validation errors on the page. It collects errors from all fields and displays them at the top of the form.

### 27. **What is Database First Approach in MVC using Entity Framework?**
   - The Database First approach generates model classes and a `DbContext` from an existing database schema. It is useful when you have a pre-existing database that you want to use.

### 28. **What are the Folders in MVC Application Solutions?**
   - **Controllers**: Contains controller classes.
   - **Models**: Contains model classes.
   - **Views**: Contains view files (`.cshtml`).
   - **wwwroot**: Stores static files like images, CSS, and JavaScript.
   - **Areas**: Contains sub-folders for modular parts of the application.

### 29. **Difference Between MVC and Web Forms**
   - **MVC**:
     - Uses the MVC pattern (Model-View-Controller).
     - Promotes separation of concerns.
     - Does not use ViewState.
   - **Web Forms**:
     - Follows an event-driven programming model.


     - Uses ViewState and server controls.
     - Less separation of concerns.

### 30. **Methods of Handling an Error in MVC**
   - Use the `try-catch` block in code.
   - Override `OnException` method in the controller.
   - Use exception filters like `HandleErrorAttribute`.
   - Configure custom error pages in `web.config`.

### 31. **How Can We Pass Data From Controller To View In MVC?**
   - **ViewData**: Passes data using a dictionary.
   - **ViewBag**: Passes data using dynamic properties.
   - **Model**: Passes strongly typed data.
   - **TempData**: Passes data across requests.

### 32. **What is Scaffolding in MVC?**
   - Scaffolding automatically generates code for CRUD operations based on the model. It includes creating controllers, views, and data access code.

### 33. **What is ViewStart?**
   - `_ViewStart.cshtml` is a file that runs before every view is rendered. It sets common settings, like layout, that should be applied to all views.

### 34. **What is JsonResultType in MVC?**
   - `JsonResult` is a return type that serializes an object to JSON format. It is often used in APIs to return data to JavaScript clients.

### 35. **What is TempData?**
   - `TempData` stores temporary data, primarily used for redirection scenarios. It is stored in session state.

### 36. **How to Use ViewBag?**
   - `ViewBag` is used to pass data from the controller to the view. It is a dynamic type:
     ```csharp
     ViewBag.Message = "Hello, World!";
     ```

### 37. **Difference Between ViewBag & ViewData?**
   - Both are used to pass data from the controller to the view.
   - **ViewBag**: Uses dynamic properties, easier to use but less type-safe.
   - **ViewData**: Uses a dictionary with string keys, more explicit but requires casting.

### 38. **What is Data Annotation Validator Attributes in MVC?**
   - Data annotations are attributes applied to model properties to enforce validation rules. Examples include `[Required]`, `[StringLength]`, `[Range]`, etc.

### 39. **How Can We Do Custom Error Page in MVC?**
   - Configure custom error pages in `web.config` or by using the `HandleError` attribute with a custom view:
     ```csharp
     [HandleError(View = "Error")]
     ```

### 40. **Server-Side Validation in MVC?**
   - Implement validation logic using data annotations on the model.
   - Use model state checks in the controller (`ModelState.IsValid`).
   - Return validation messages to the view.

### 41. **What is the Use of Remote Validation in MVC?**
   - Remote validation allows validating user input on the server side via an AJAX call. It is useful for checking data uniqueness, like usernames or email addresses.

### 42. **What are Exception Filters in MVC?**
   - Exception filters handle exceptions raised by actions. They can log exceptions, return error views, or perform custom error handling.

### 43. **What is MVC HTML Helpers and its Methods?**
   - HTML Helpers are methods that generate HTML elements. Common helpers include:
     - `Html.TextBoxFor()`
     - `Html.DropDownListFor()`
     - `Html.BeginForm()`
     - `Html.ValidationMessageFor()`

### 44. **Define Controller in MVC?**
   - A **Controller** handles user input and interaction. It processes incoming requests, handles user actions, interacts with the model, and returns the appropriate view.

### 45. **Explain Model in MVC?**
   - A **Model** represents the data and business logic of the application. It directly manages data and enforces rules and behaviors related to that data.

### 46. **Explain View in MVC?**
   - A **View** displays the data to the user. It is the user interface part of the application and is responsible for rendering the model data as HTML.

### 47. **What is Attribute Routing in MVC?**
   - Attribute routing uses attributes to define routes directly on actions and controllers. It offers more flexibility and clarity than convention-based routing.

### 48. **Explain RenderSection in MVC?**
   - `RenderSection` is used in layout files to define sections that can be filled in by specific views. It is useful for adding scripts or styles that are unique to certain views.

### 49. **What is GET and POST Action Types?**
   - **GET**: Retrieves data from the server. It is used to display data without modifying it.
   - **POST**: Submits data to the server. It is used to create or update data.

### 50. **What's New in MVC 6?**
   - MVC 6, part of ASP.NET Core, introduced several changes:
     - Unified MVC and Web API frameworks.
     - Built-in support for dependency injection.
     - Improved cross-platform support.
     - New configuration and hosting models.
     - Tag Helpers for server-side rendering.