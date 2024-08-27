---
title: "Set Twelve"
author: "PrashantUnity"
weight: 222
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
Let's go through these ASP.NET MVC concepts one by one:

### 1. What is Layout in MVC?
A **Layout** in MVC is similar to a master page in traditional ASP.NET. It defines a common structure for a web application, such as the header, footer, and navigation sections. Layouts help maintain a consistent look and feel across multiple views by providing a shared template. You can define a layout using the `Layout` property in Razor views.

### 2. What is ASP.NET WC?
There might be a typo, and you probably mean **ASP.NET Web Forms (WC)**. ASP.NET Web Forms is a part of the ASP.NET web application framework and is a traditional event-driven model that uses server controls, ViewState, and postback. It allows developers to build dynamic, data-driven websites using a drag-and-drop approach and server-side logic.

### 3. What is Razor Pages?
**Razor Pages** is a page-based coding model in ASP.NET Core designed to make web UI development easier and more productive. It offers a more straightforward and more organized way of developing web pages. Each page contains its model and view, making the code more modular and maintainable compared to traditional MVC.

### 4. What is the use of ViewModel in MVC?
A **ViewModel** is a model specifically created to pass data from a controller to a view. It acts as a data container, combining properties from different domain models, making it suitable for a specific view. ViewModels help in separating the UI logic from the business logic and can handle data display and input validation.

### 5. Can you explain Model, Controller, and View in MVC?
- **Model**: Represents the application's data and business logic. It is responsible for fetching, storing, and processing data from the database.
- **Controller**: Handles user input and interactions. It processes incoming requests, interacts with the model, and selects a view to render.
- **View**: Represents the UI. It displays data from the model to the user and sends user interactions to the controller.

### 6. What are Scaffold templates in MVC?
**Scaffold templates** are pre-built code templates in ASP.NET MVC that help quickly generate CRUD (Create, Read, Update, Delete) operations. They provide a starting point for building application features by automatically generating models, views, and controllers based on the database schema or predefined specifications.

### 7. Explain Sections in MVC?
**Sections** in MVC are a feature of Razor view engine that allows you to define a part of a layout that can be overridden by content pages. They are optional and can be used to inject specific content into predefined areas of the layout.

### 8. What are the advantages of MVC over ASP.NET?
- **Separation of Concerns**: Better separation between UI, business logic, and data.
- **Testability**: Easier to unit test the application.
- **Extensibility**: More flexible and easily extended with custom features.
- **SEO Friendly**: More control over the rendered HTML and URLs.
- **Lightweight**: No reliance on ViewState or server controls.

### 9. Explain Bundle.config in MVC?
**Bundle.config** is a configuration file used to define bundles of JavaScript and CSS files in ASP.NET MVC. Bundling improves the performance of web applications by reducing the number of HTTP requests made to the server.

### 10. What is Razor View Engine?
**Razor View Engine** is a view engine in ASP.NET MVC that uses the Razor syntax. It provides a lightweight syntax for embedding server-side code (C# or VB.NET) into HTML. Razor syntax uses `@` to embed code.

### 11. What are Actions in MVC?
**Actions** are methods in a controller class that respond to incoming HTTP requests. They process user input, interact with the model, and return a result, typically a view or a data response.

### 12. What are NonAction methods in MVC?
**NonAction** methods are methods in a controller that are not considered as action methods. They cannot be invoked via URL routing. You can mark a method with the `[NonAction]` attribute to prevent it from being treated as an action.

### 13. What do you mean by Routing in MVC?
**Routing** is the mechanism in ASP.NET MVC that maps URLs to controller actions. It is defined in the `RouteConfig.cs` file, specifying patterns for URL paths and the corresponding controllers and actions to handle them.

### 14. Can a view be shared across multiple controllers? If Yes, How can we do that?
Yes, a view can be shared across multiple controllers. To do this, you can place the view in the `Shared` folder under the `Views` directory. Views in the `Shared` folder are accessible to all controllers.

### 15. Can you explain the page life cycle of MVC?
The MVC page life cycle involves:
1. **Routing**: Determines which controller and action to invoke based on the URL.
2. **Controller Initialization**: Creates an instance of the controller.
3. **Action Execution**: Executes the action method.
4. **Result Execution**: Prepares the result (e.g., a view, JSON data).
5. **View Rendering**: Renders the view as HTML.
6. **Response**: Sends the generated HTML back to the client.

### 16. What are HTML Helpers in MVC?
**HTML Helpers** are methods that generate HTML markup. They are used in Razor views to create form elements, links, and other HTML content. Examples include `Html.TextBoxFor()`, `Html.LabelFor()`, and `Html.ActionLink()`.

### 17. Explain ASP.NET WebAPI vs MVC?
- **ASP.NET MVC**: Primarily used for building web applications with views and UI components. It returns HTML or JSON based on the need.
- **ASP.NET Web API**: A framework for building HTTP services that can be consumed by various clients, including browsers, mobile devices, and IoT devices. It focuses on returning data rather than views.

### 18. What is Partial View in MVC?
A **Partial View** is a reusable view component that represents a portion of a web page. It is similar to user controls in traditional ASP.NET. Partial views can be rendered within other views to encapsulate shared HTML content.

### 19. Explain the methods used to render the views in MVC?
- `View()`: Renders a view.
- `PartialView()`: Renders a partial view.
- `Json()`: Returns JSON data.
- `Content()`: Returns raw content.
- `File()`: Returns a file.

### 20. Can you explain RenderBody and RenderPage?
- **RenderBody**: Renders the content of the child view inside the layout. It acts as a placeholder in the layout for the child view's content.
- **RenderPage**: Renders a specific view inside another view. Useful for embedding reusable content like headers and footers.

### 21. What is the difference between ViewBag and ViewData?
- **ViewBag**: A dynamic object that provides a loosely-typed way to pass data from a controller to a view. It uses the `dynamic` keyword.
- **ViewData**: A dictionary object that uses key-value pairs to pass data between a controller and a view. It is strongly typed.

### 22. What is Attribute Routing in MVC?
**Attribute Routing** allows defining routes directly on the action methods or controllers using attributes. This provides more flexibility and control over the route patterns and allows setting up RESTful routes easily.

### 23. What is the HelperPage.IsAjax Property?
`HelperPage.IsAjax` is a property that checks if the current request is an Ajax request. It returns `true` if the request was made using an AJAX call.

### 24. What is the difference between ViewResult() and ActionResult() in ASP.NET WC?
- **ViewResult()**: Returns a view to the browser.
- **ActionResult()**: A base class for different types of action results like `ViewResult`, `JsonResult`, `FileResult`, etc. It allows different response types from a controller action.

### 25. What are some of the advantages of using ASP.NET MVC vs Web Forms?
- **Separation of Concerns**: Better organization of code.
- **Testability**: Easier unit testing.
- **No ViewState**: Lightweight pages.
- **Control Over HTML**: More precise control over rendered HTML.
- **SEO Friendly**: Cleaner URLs and better search engine optimization.

### 26. Explain the difference between MVC vs ASP.NET Web API.
- **MVC**: Used for building web applications with views. Focuses on delivering HTML content and handling user interactions.
- **Web API**: Used for building HTTP services that provide data in formats like JSON or XML, primarily for client applications.

### 27. What about MVC in .NET Core?
MVC in .NET Core continues to provide a robust framework for building web applications. It integrates with Razor Pages, Web API, and SignalR for building scalable, cross-platform applications.

### 28. In OOP, what is the difference between the Repository Pattern and a Service Layer?
- **Repository Pattern**: Abstracts data access logic, providing an interface to interact with data sources.
- **Service Layer**: Encapsulates business logic, orchestrates data access, and calls multiple repositories.

### 29. Describe Flux vs MVC?
- **Flux**: A pattern used in frontend JavaScript applications, focusing on unidirectional data flow. It is commonly used with React.
- **MVC**: A traditional design pattern focusing on separating application concerns into Model, View, and Controller components. It can handle both server-side and client-side interactions.

### 30. Is it possible to create a web application with both WebForms and MVC?
Yes, it's possible to create a

 web application with both WebForms and MVC. This can be done by configuring routing and using different routes to direct requests to either MVC controllers or Web Forms.

### 31. How route table has been created in ASP.NET WC?
In ASP.NET, the route table is typically created in the `RouteConfig.cs` file inside the `App_Start` folder. It defines routes using the `routes.MapRoute` method, specifying URL patterns, default controller actions, and parameter constraints.

### 32. What is the difference between ViewData and TempData?
- **ViewData**: Used to pass data from the controller to the view. Data persists only during the current request.
- **TempData**: Used to pass data between controllers or between actions. Data persists for a single request and can survive redirects.

### 33. What are Validation Annotations?
**Validation Annotations** are attributes applied to model properties to enforce validation rules. Examples include `[Required]`, `[StringLength]`, `[Range]`, and `[RegularExpression]`.

### 34. What is Separation of Concerns in ASP.NET MVC?
**Separation of Concerns** refers to organizing code in such a way that different functionalities are separated into distinct parts. In ASP.NET MVC, this is achieved by separating the data model (Model), UI (View), and user input handling (Controller).

### 35. What are AJAX Helpers in WC?
**AJAX Helpers** are methods in ASP.NET MVC that make it easier to integrate AJAX functionality into applications. Examples include `Ajax.BeginForm()`, `Ajax.ActionLink()`, which create forms or links that submit requests asynchronously.

### 36. Explain Dependency Resolution in MVC?
**Dependency Resolution** in MVC refers to the process of resolving dependencies (services) that a class (like a controller) needs to function. ASP.NET MVC uses Dependency Injection (DI) to inject required services at runtime.

### 37. Why use Html.Partial in MVC?
`Html.Partial` is used to render a partial view directly within a parent view. It is useful for reusing UI components across multiple views, allowing you to include shared content without duplicating code.

### 38. What is the difference between Html.Partial vs Html.RenderPartial vs Html.RenderAction?
- **Html.Partial**: Renders a partial view into the calling view. It returns an HTML string, which you can manipulate before rendering.
- **Html.RenderPartial**: Similar to `Html.Partial`, but writes the output directly to the response stream, which can improve performance.
- **Html.RenderAction**: Calls an action method and renders its result. Useful when you need to execute logic before rendering a view.
