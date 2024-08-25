---
title: "Set Seven"
author: "PrashantUnity"
weight: 217
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


1. **Mention what does Model-View-Controller represent in an MVC application?**  
   - **Model**: Represents the data and business logic of the application.
   - **View**: Represents the UI or presentation layer that displays the model's data.
   - **Controller**: Handles user input, processes it, and updates the model or view accordingly.

2. **Explain what is MVC?**  
   MVC (Model-View-Controller) is a software architectural pattern for developing web applications. It divides an application into three interconnected components (Model, View, Controller) to separate internal representations of information from how that information is presented and accepted from the user.

3. **List out a few different return types of a controller action method?**  
   - **ViewResult**: Returns a view to the user.
   - **JsonResult**: Returns JSON-formatted data.
   - **RedirectResult**: Redirects to a different URL.
   - **ContentResult**: Returns plain text content.
   - **PartialViewResult**: Returns a partial view.
   - **FileResult**: Returns a file.
   - **EmptyResult**: Returns no result.

4. **What are the advantages of MVC?**  
   - **Separation of Concerns**: Separates business logic, UI, and input handling.
   - **Testability**: Easier to write unit tests for the components separately.
   - **Scalability**: Promotes maintainable and scalable application development.
   - **Extensibility**: Provides flexibility to extend and customize components.
   - **SEO-friendly URLs**: Facilitates creating SEO-friendly URLs.

5. **Explain the role of components Presentation, Abstraction, and Control in MVC?**  
   - **Presentation (View)**: Manages the display of information to the user.
   - **Abstraction (Model)**: Encapsulates the data and business rules.
   - **Control (Controller)**: Handles input, updates the model, and returns a view.

6. **How to maintain session in MVC?**  
   Sessions can be maintained in MVC using:
   - **Session State**: `Session["key"] = value;`
   - **TempData**: For short-lived data that needs to be persisted across requests.
   - **Cookies**: To store small amounts of data on the client's side.

7. **What is MVC Application life cycle?**  
   The MVC application lifecycle includes:
   - **Application Start**: Initialization (e.g., `Global.asax`).
   - **Routing**: Maps incoming requests to controller actions.
   - **Instantiate and Execute Controller**: Controller is instantiated, and the action method is called.
   - **Action Execution**: Action method logic is executed.
   - **Result Execution**: The action result (view, redirect, etc.) is executed.
   - **View Rendering**: The view is rendered and sent to the client.

8. **What does the MVC Pattern define with 3 logical layers?**  
   - **Model**: Data and business logic.
   - **View**: Presentation and user interface.
   - **Controller**: Handles input, controls interaction between Model and View.

9. **What is ASP.NET MVC?**  
   ASP.NET MVC is a framework by Microsoft for building web applications using the MVC pattern. It provides a structured way to separate concerns in the application and offers features such as routing, model binding, and view rendering.

10. **What is MVC Routing?**  
    MVC routing is a mechanism that maps incoming requests to specific controller actions based on URL patterns. It defines how URLs are interpreted and which controller action to invoke.

11. **What are the Filters?**  
    Filters are attributes that provide a way to execute code before or after specific stages in the request processing pipeline. Types of filters include:
    - **Authorization Filters**: Execute before any action is invoked.
    - **Action Filters**: Execute before and after an action method is called.
    - **Result Filters**: Execute before and after a view result is executed.
    - **Exception Filters**: Handle errors raised during controller actions or other filters.

12. **What is Partial View in MVC?**  
    A Partial View is a reusable view component that can be embedded inside other views. It helps to modularize the user interface and reduce code duplication.

13. **Can you explain the page life cycle of MVC?**  
    The MVC page lifecycle includes:
    - **Application Initialization**: Application starts, and route configuration is set up.
    - **Routing**: Maps request URLs to corresponding controllers and actions.
    - **Controller Instantiation**: The controller object is created.
    - **Action Execution**: The specified action method is invoked.
    - **Result Execution**: Result (e.g., a view) is executed.
    - **View Rendering**: HTML content is generated and sent to the client.

14. **What is the use of ViewModel in MVC?**  
    A ViewModel is a model specifically tailored to contain the data and logic required for a specific view. It is used to pass data from a controller to a view.

15. **What is Database first approach in MVC using Entity Framework?**  
    The Database First approach involves creating the database first and then generating the Entity Framework models based on the existing database schema. This approach is suitable when the database is already defined and cannot be altered.

16. **What do you mean by MVC Scaffolding?**  
    MVC Scaffolding is an automated code generation tool that creates basic CRUD (Create, Read, Update, Delete) operations for a model. It generates controllers, views, and data access code.

17. **Explain the concept of Razor in ASP.NET MVC?**  
    Razor is a view engine in ASP.NET MVC that uses a simple and clean syntax to write server-side code using C#. It allows embedding C# code directly within HTML using `@` syntax.

18. **Explain the concept of Default Route in MVC.**  
    The Default Route in MVC is a predefined route pattern that handles most common cases. It is typically defined as:
    ```csharp
    routes.MapRoute(
        name: "Default",
        url: "{controller}/{action}/{id}",
        defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
    );
    ```

19. **What is GET and POST Action types?**  
    - **GET**: Requests data from the server. Used to retrieve and display information without modifying the state.
    - **POST**: Submits data to be processed by the server. Used to send data and can modify the server state.

20. **How does View Data differ from View Bag in MVC?**  
    - **ViewData**: A dictionary object (`ViewData["key"]`) for passing data from a controller to a view. It requires casting.
    - **ViewBag**: A dynamic object (`ViewBag.PropertyName`) for passing data without requiring casting.

21. **Mention the Benefits of Area in MVC.**  
    - **Organizes**: Large applications into manageable sections.
    - **Modularization**: Allows different teams to work on separate areas independently.
    - **URL Structuring**: Helps define and manage complex URL structures.

22. **Which filters are executed in the end?**  
    - **Exception Filters**: These are executed last to handle any exceptions raised during the execution of other filters or controller actions.

23. **Mention what are the two ways for adding constraints to a route?**  
    - **Inline Constraints**: Adding constraints directly within the route pattern (e.g., `{id:int}`).
    - **Custom Constraints**: Using a custom route constraint class implementing `IRouteConstraint`.

24. **How can we implement validation in MVC?**  
    Validation can be implemented using:
    - **Data Annotations**: Apply validation attributes to model properties (e.g., `[Required]`, `[StringLength]`).
    - **Custom Validation**: Implement custom validation logic in model or controller.
    - **Client-side Validation**: Using jQuery Unobtrusive validation.

25. **Mention two instances where routing is not implemented or required?**  
    - **Static Files**: Routing is not required for static files like CSS, JavaScript, or images.
    - **Direct URL Access**: Routing is not needed for files accessed directly by URL.

26. **Explain how you can implement Ajax in MVC?**  
    - Use `Ajax.BeginForm()` helper to create an AJAX-enabled form.
    - Use jQuery's `$.ajax()` method to make AJAX requests to controller actions.
    - Return partial views or JSON data in response to AJAX calls.

27. **What is the use of Keep and Peek in “TempData”?**  
    - **Keep**: Retains the value in `TempData` for subsequent requests.
    - **Peek**: Reads the value from `TempData` without marking it for deletion.

28. **What is WebAPI?**  
    WebAPI is a framework that makes it easy to build HTTP services that reach a broad range of clients, including browsers, mobile devices, and desktop applications. It is used for building RESTful services.

29. **How can we detect that an MVC controller is called by POST or GET?**  
    - Use `[HttpGet]` and `[HttpPost]` attributes to define methods that respond to GET and POST requests, respectively.
    - Check the `Request.HttpMethod` property within the action method.

30. **What are the main Razor Syntax Rules?**  
    - Use `@` to switch from HTML to C#.
    - Use `@{ }` for multi-line C#

 code blocks.
    - Use `@* *@` for comments.
    - Razor automatically encodes output to HTML.

31. **How do you implement Forms authentication in MVC?**  
    - Configure authentication settings in `web.config`.
    - Use `[Authorize]` attribute to restrict access to controllers or actions.
    - Use `FormsAuthentication.SetAuthCookie(username, createPersistentCookie)` to log in users.

32. **Can you explain RenderBody and RenderPage in MVC?**  
    - **RenderBody**: Placeholder in a layout view that will be replaced with content from the view.
    - **RenderPage**: Includes the content of a view page into another view or layout.

33. **What are Non-Action methods in MVC?**  
    Methods in a controller marked with `[NonAction]` attribute that are not intended to be callable as action methods. They are used internally within the controller.

34. **How to perform Exception Handling in MVC?**  
    - Use `try-catch` blocks within action methods.
    - Use custom error handling filters.
    - Configure global error handling in `Web.config`.
    - Use the `HandleError` attribute on controllers.

35. **Which is a better fit, Razor or ASPX?**  
    Razor is generally preferred over ASPX for its cleaner syntax, better performance, and integration with C#.

36. **What is Code Blocks in Views?**  
    Code blocks in Razor are enclosed in `@{ }` and allow multiple lines of server-side code to be written.

37. **Why use Html.Partial in MVC?**  
    `Html.Partial` is used to render a partial view directly in the current view, which is useful for reusing components or layouts.

38. **What is a glimpse?**  
    Glimpse is a tool used for real-time diagnostics and debugging in ASP.NET applications. It provides insights into server execution, performance, and more.

39. **How can we navigate from one view to another using a hyperlink?**  
    Use `@Html.ActionLink("Link Text", "ActionName", "ControllerName")` to create a hyperlink that navigates to a specific action in a controller.
