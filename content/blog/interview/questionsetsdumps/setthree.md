---
title: "Set Three"
author: "PrashantUnity"
weight: 212
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

### 1. **Explain Model, View, and Controller in Brief**
   - **Model**: Represents the data and the business logic of the application. It interacts with the database, retrieves, and stores information.
   - **View**: Responsible for displaying the data provided by the model. It represents the user interface of the application.
   - **Controller**: Handles user input and interaction. It processes incoming requests, performs operations on the model, and returns the appropriate view.

### 2. **What are the Different Return Types Used by the Controller Action Method in MVC?**
   - `ViewResult`: Returns a view.
   - `PartialViewResult`: Returns a partial view.
   - `JsonResult`: Returns JSON data.
   - `RedirectResult`: Redirects to a different URL.
   - `RedirectToRouteResult`: Redirects to a specific route.
   - `ContentResult`: Returns raw content (string).
   - `FileResult`: Returns a file download.
   - `EmptyResult`: Represents no result (no response).

### 3. **Name the Assembly in which the MVC Framework is Typically Defined**
   - The MVC framework is typically defined in the `System.Web.Mvc` assembly.

### 4. **Explain the MVC Application Life Cycle**
   - **Application Start**: The application starts, and configuration settings are loaded.
   - **Routing**: Incoming requests are matched against defined routes to determine the controller and action.
   - **Controller Initialization**: The controller that matches the route is instantiated.
   - **Action Execution**: The controller action method is executed.
   - **Result Execution**: The result of the action (usually a view) is rendered.
   - **Response**: The rendered HTML or other output is sent back to the client.

### 5. **What are the Various Steps to Create the Request Object?**
   - **Filling Route Data**: Matches the URL with the routes defined in `RouteConfig.cs`.
   - **Request Context Creation**: Forms a request context using the matched route data.
   - **Controller Creation**: Instantiates the controller using the request context.

### 6. **Explain Some Benefits of Using MVC**
   - **Separation of Concerns**: Different aspects of the application (input logic, business logic, and UI) are separated into different components.
   - **Testability**: Each component can be tested independently, improving testability.
   - **Scalability**: Applications are easier to scale due to the modular nature.
   - **Flexibility**: MVC architecture makes it easier to implement new technologies or patterns.

### 7. **Explain in Brief the Role of Different MVC Components**
   - **Model**: Manages the application data and enforces business rules.
   - **View**: Displays data from the model and sends user input to the controller.
   - **Controller**: Handles user input, updates the model, and selects the view to display.

### 8. **How Will You Maintain the Sessions in MVC?**
   - Sessions in MVC can be maintained using:
     - `Session` object: Stores data using key-value pairs.
     - Cookies: Store session data on the client side.
     - Query strings or hidden fields.

### 9. **What Do You Mean by Partial View of MVC?**
   - A partial view is a reusable component that renders a portion of a view. It does not have a complete HTML structure (e.g., no `<html>` or `<body>` tags) and is used to encapsulate reusable content.

### 10. **Explain in Brief the Difference Between Adding Routes in a WebForm Application & an MVC Application?**
   - **WebForm Application**: Routes are defined using `RouteTable` in the `Global.asax.cs` file.
   - **MVC Application**: Routes are typically defined in the `RouteConfig.cs` file within the `App_Start` folder, using the `RouteCollection.MapRoute()` method.

### 11. **How Will You Define the 3 Logical Layers of MVC?**
   - **Presentation Layer**: Includes the views that are responsible for the UI.
   - **Business Logic Layer**: Includes controllers that handle user input and business logic.
   - **Data Access Layer**: Includes models that interact with the database.

### 12. **What is the Use of ActionFilters in MVC?**
   - Action filters are used to implement logic that should be executed before or after an action method runs. Examples include authentication checks, logging, or error handling.

### 13. **How to Execute Any MVC Project? Explain its Steps.**
   - **Step 1**: Open the MVC project in Visual Studio.
   - **Step 2**: Set the desired project as the startup project.
   - **Step 3**: Build the project using `Ctrl + Shift + B`.
   - **Step 4**: Run the project by pressing `F5` (debug mode) or `Ctrl + F5` (without debugging).

### 14. **What is the Concept of Routing in MVC?**
   - Routing is a pattern-matching system that maps incoming requests to specific controller actions. It uses route templates defined in the application to determine how URLs are processed.

### 15. **What are the 3 Important Segments for Routing?**
   - **Controller**: Specifies which controller to use.
   - **Action**: Specifies which action method to invoke.
   - **Parameters**: Any additional values required by the action method.

### 16. **What are the Different Properties of MVC Routes?**
   - **Name**: The name of the route.
   - **URL Pattern**: The URL format associated with the route.
   - **Defaults**: Default values for segments that are optional.
   - **Constraints**: Restrict the values that segments can accept.

### 17. **How is the Routing Carried Out in MVC?**
   - When a request is received, the routing engine matches the URL against defined routes. If a match is found, it routes the request to the corresponding controller and action method.

### 18. **How Will You Navigate from One View to Another View in MVC? Explain with a Hyperlink Example.**
   - You can use the `Html.ActionLink` helper to navigate between views.
     ```html
     @Html.ActionLink("Go to About Page", "About", "Home")
     ```
   - This creates a hyperlink that navigates to the `About` action of the `Home` controller.

### 19. **Explain the 3 Concepts in One Line; TempData, View, and ViewBag?**
   - **TempData**: Temporary data storage, persists across requests.
   - **View**: The user interface component that displays data.
   - **ViewBag**: Dynamic object for passing data from controller to view within a single request.

### 20. **Mention & Explain the Different Approaches You Will Use to Implement Ajax in MVC?**
   - **Using jQuery**: Send AJAX requests with jQuery's `$.ajax()` method.
   - **Using AJAX Helpers**: Utilize built-in MVC AJAX helper methods like `Ajax.BeginForm()`.
   - **Using Fetch API**: Use the modern JavaScript Fetch API for making AJAX requests.

### 21. **How Will You Differentiate Between ActionResult and ViewResult?**
   - **ActionResult**: A base class for all action results, allows returning different types of results (e.g., `ViewResult`, `JsonResult`).
   - **ViewResult**: A derived class of `ActionResult` that specifically returns a view.

### 22. **What is Spring MVC?**
   - Spring MVC is a Java-based framework used to build web applications. It follows the MVC design pattern and is part of the larger Spring Framework ecosystem.

### 23. **Explain Briefly What You Understand by Separation of Concern.**
   - **Separation of Concern** means dividing an application into distinct sections, each handling a specific aspect of functionality, reducing interdependencies and making it easier to manage, develop, and test.

### 24. **What is TempData in MVC?**
   - `TempData` is used to store temporary data that needs to be available across multiple requests, such as data used during a redirect.

### 25. **Define Output Caching in MVC.**
   - Output caching stores the content generated by the controller action, so subsequent requests for the same content can be served quickly from the cache without re-processing.

### 26. **Why are Minification and Bundling Introduced in MVC?**
   - **Minification** reduces the size of JavaScript and CSS files by removing unnecessary characters.
   - **Bundling** combines multiple files into one. Both improve performance by reducing the number and size of requests.

### 27. **Describe ASP.NET MVC.**
   - ASP.NET MVC is a framework for building scalable, standards-based web applications using the MVC design pattern, focusing on separation of concerns and providing a testable architecture.

### 28. **Which Class Will You Use for Sending the Result Back in JSON Format in MVC?**
   - The `JsonResult` class is used to send a JSON-formatted response back to the client.

### 29. **Make a Differentiation Between View and Partial View?**
   - **View**: Represents a complete HTML page. Includes layout and full HTML structure.
   - **Partial View**: Represents a segment of the page. Used for reusable components and does not include layout.

### 30. **Define the Concept of Filters in MVC?**
   - Filters allow executing code before or after specific stages in the request processing pipeline, such as authorization checks, error handling, or logging.

### 31. **Mention the Significance of NonAction

Attribute?**
   - The `NonAction` attribute prevents a public method in a controller from being treated as an action method. This is useful for helper methods that should not be accessible via URL.

### 32. **What is Used to Handle an Error in MVC?**
   - Errors in MVC can be handled using:
     - `try-catch` blocks within actions.
     - Global error handling with `Application_Error` in `Global.asax`.
     - Custom error pages defined in `web.config`.
     - Using exception filters like `HandleErrorAttribute`.

### 33. **Define Scaffolding in MVC?**
   - Scaffolding is a feature that automatically generates the code for CRUD operations (Create, Read, Update, Delete) based on the model. It speeds up development by generating controllers, views, and model classes.

### 34. **When Multiple Filters are Used in MVC, How is the Ordering of Execution of the Filters Done?**
   - Filter execution order is determined by:
     - The order in which filters are applied.
     - Using the `Order` property of the filter attribute.
     - Global filters execute before controller and action-specific filters.

### 35. **What is ViewStart?**
   - `_ViewStart.cshtml` is a special view file that executes before each view. It is used to set common settings like layout for all views.

### 36. **Which Type of Filters are Executed in the End While Developing an MVC Application?**
   - **Exception filters** are executed last, allowing handling of unhandled exceptions raised during action method execution.

### 37. **Mention the Possible File Extensions Used for Razor Views?**
   - `.cshtml` for C# Razor views.
   - `.vbhtml` for VB.NET Razor views.

### 38. **Explain Briefly the Two Approaches of Adding Constraints to an MVC Route?**
   - **Inline Constraints**: Define constraints directly in the route definition.
     ```csharp
     routes.MapRoute(
         name: "Default",
         url: "{controller}/{action}/{id:int}"
     );
     ```
   - **Custom Constraints**: Create custom constraint classes implementing `IRouteConstraint`.

### 39. **Point Out the Different Stages a Page Life Cycle of MVC Has?**
   - **Application Start**: Initialization of the application.
   - **Routing**: Matching incoming requests to route definitions.
   - **Controller Initialization**: Instantiation of the controller.
   - **Action Execution**: Execution of the action method.
   - **Result Execution**: Rendering the response (view or other result types).

### 40. **Explain Briefly the Use of ViewModel in MVC?**
   - A `ViewModel` is a model specifically designed for the view, containing only the necessary data and logic to display in the view. It may combine properties from multiple domain models.

### 41. **Define Default Route in MVC?**
   - The default route is a route defined to handle common patterns of URL structures, typically:
     ```csharp
     routes.MapRoute(
         name: "Default",
         url: "{controller}/{action}/{id}",
         defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
     );
     ```

### 42. **Explain Briefly the GET and POST Action Types?**
   - **GET**: Used to request data from the server. It should not modify any state on the server.
   - **POST**: Used to send data to the server, often resulting in a change in server state.

### 43. **What are the Rules of Razor Syntax?**
   - Razor uses `@` to transition from HTML to C#.
   - Code blocks are defined with `{}`.
   - Statements end with a semicolon `;`.
   - Use `@model` to define the type of model passed to the view.

### 44. **How Can You Implement the MVC Forms Authentication?**
   - Configure authentication settings in `web.config`.
   - Use `[Authorize]` attribute on controllers or actions.
   - Use `FormsAuthentication.SetAuthCookie()` to sign in a user.

### 45. **What are the Areas of Benefits in Using MVC?**
   - **Modular Development**: Divides application into discrete components.
   - **Maintainability**: Easier to update and modify due to clear separation.
   - **Testability**: Components can be unit tested independently.
   - **Scalability**: Modular architecture supports scaling.

### 46. **Point Out the Two Instances Where You Cannot Use Routing or Where Routing is Not Necessary**
   - **Static Files**: Direct access to static files like images, CSS, or JS does not require routing.
   - **WebForm Pages**: In hybrid applications, WebForm pages do not use MVC routing.

### 47. **How Will You Explain the Concept of RenderBody and RenderPage of MVC?**
   - **RenderBody**: A placeholder in the layout file where the view content will be injected.
   - **RenderPage**: Renders another page inside a view or layout, useful for including reusable sections like footers or headers.