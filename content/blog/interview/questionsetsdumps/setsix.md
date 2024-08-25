---
title: "Set Six"
author: "PrashantUnity"
weight: 216
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

1. **What is MVC?**  
   MVC stands for **Model-View-Controller**, which is a software architectural pattern used to develop web applications. It separates an application into three main components:
   - **Model**: Represents the application's data and business logic. It directly manages the data, logic, and rules of the application.
   - **View**: Represents the UI of the application. It displays the data to the user and sends user commands to the controller.
   - **Controller**: Acts as an intermediary between the Model and the View. It listens to user input from the View, processes it (possibly changing the Model's state), and returns the output display to the View.

2. **What is ASP.NET MVC?**  
   **ASP.NET MVC** is a framework provided by Microsoft to build web applications using the MVC design pattern. It is a part of the ASP.NET web application framework, which provides a powerful, patterns-based way to build dynamic websites.

3. **What are the advantages of ASP.NET MVC?**  
   - **Separation of Concerns**: By separating application logic into different components (Model, View, Controller), it promotes organized and manageable code.
   - **Testability**: Due to the separation of concerns, it becomes easier to unit test different parts of the application.
   - **Extensibility**: ASP.NET MVC is highly customizable and extensible.
   - **Fine-grained Control**: Provides greater control over HTML, JavaScript, and CSS.
   - **Support for RESTful URLs**: Facilitates SEO-friendly URLs and is well-suited for RESTful web services.

4. **What is Routing in ASP.NET MVC?**  
   **Routing** is the mechanism in ASP.NET MVC that maps URLs to the respective controller actions. It defines the rules that match incoming requests to the route handler (i.e., controller actions). It helps in creating user-friendly and search-engine-optimized URLs.

5. **When to use Attribute Routing?**  
   **Attribute Routing** is used when you want to define routes directly on controller actions using attributes. It offers greater control over the routes, makes them easier to maintain, and is ideal for complex routing scenarios or when routes need to be highly customized.

6. **How to enable Attribute Routing in ASP.NET MVC?**  
   To enable attribute routing in an ASP.NET MVC application, you need to call `routes.MapMvcAttributeRoutes()` method inside the `RouteConfig.cs` file, usually in the `RegisterRoutes` method.
   ```csharp
   public static void RegisterRoutes(RouteCollection routes)
   {
       routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
       routes.MapMvcAttributeRoutes(); // Enables attribute routing
       // Other route configurations
   }
   ```

7. **What is the difference between Routing and URL Rewriting?**  
   - **Routing**: It is used to map incoming requests to a specific controller action. It works by inspecting the URL and matching it against predefined patterns to direct the request.
   - **URL Rewriting**: It changes the URL before it reaches the routing mechanism, often used to make the URL more user-friendly or for backward compatibility.

8. **What is View Engine?**  
   A **View Engine** is responsible for rendering the HTML from the views in an MVC application. It converts the server-side view templates into HTML markup that is sent to the client.

9. **What is Razor View Engine?**  
   **Razor View Engine** is a markup syntax used to create dynamic web pages using C#. Razor allows you to embed C# code directly within HTML. It is the default view engine for ASP.NET MVC, providing a clean and simple way to integrate code and content.

10. **What are HTML Helpers in ASP.NET MVC?**  
    **HTML Helpers** are methods in ASP.NET MVC that help you generate HTML content in a more dynamic and reusable way. Examples include `Html.TextBox()`, `Html.DropDownList()`, and `Html.BeginForm()`.

11. **What are Url Helpers?**  
    **URL Helpers** are methods in ASP.NET MVC that help generate URLs to different controller actions. Examples include `Url.Action()` and `Url.RouteUrl()`.

12. **When to use _ViewStart?**  
    The **_ViewStart** file is used to define common settings or code that should be run at the start of each view's rendering. It helps to reduce repetition and keeps the views consistent by centralizing settings like layout pages.

13. **Can you change the action method name?**  
    Yes, you can change the action method name using the `[ActionName("NewActionName")]` attribute. This allows you to map a different name for the action method in the URL without changing the method name in your code.

14. **What are Data Annotations in ASP.NET MVC?**  
    **Data Annotations** are attributes that provide a way to define validation rules and display properties directly in the model classes. Examples include `[Required]`, `[StringLength]`, and `[Range]`.

15. **How to determine there is no error in Model State?**  
    You can check the `ModelState.IsValid` property to determine if there are no validation errors. It returns `true` if all the validation checks pass and `false` if any check fails.

16. **What is the jQuery Validation Unobtrusive plugin?**  
    The **jQuery Validation Unobtrusive** plugin is a Microsoft library that uses data-* attributes to perform client-side validation without having to write any custom JavaScript.

17. **Can we use Bundling and Minification in ASP.NET MVC3 or ASP.NET4.0?**  
    Yes, Bundling and Minification features are available in ASP.NET MVC 4 and later versions. For MVC 3 and .NET 4.0, you can use third-party libraries or custom scripts to achieve similar results.

18. **What is Scaffolding?**  
    **Scaffolding** is an automated code generation framework used in ASP.NET MVC to quickly generate CRUD (Create, Read, Update, Delete) operations for a data model. It helps developers to rapidly create views and controllers.

19. **How to persist data in TempData?**  
    You can persist data in `TempData` by storing key-value pairs in it. `TempData` is used to pass data from one controller action to another. To persist `TempData` across multiple requests, use the `TempData.Keep()` method.

20. **Can you change the action method name?**  
    Yes, using the `[ActionName("NewActionName")]` attribute, you can map a different name for the action method in the URL without changing the method name in your code.

21. **Mention the types of results in MVC?**  
    - **ViewResult**: Returns a View.
    - **PartialViewResult**: Returns a partial view.
    - **RedirectResult**: Redirects to another URL.
    - **RedirectToRouteResult**: Redirects to another action.
    - **JsonResult**: Returns JSON data.
    - **ContentResult**: Returns plain text content.
    - **FileResult**: Returns a file.
    - **EmptyResult**: Returns nothing.

22. **What do the 3 logic layers define about the MVC Pattern?**  
    - **Model**: Data and business logic.
    - **View**: Presentation and UI.
    - **Controller**: Handles user input, updates the model, and returns views.

23. **What does Database First approach in MVC through Entity Framework?**  
    The **Database First** approach is a development workflow in which the database schema is created first, and the Entity Framework models are generated based on the existing database structure.

24. **Explain GET and POST Action types:**  
    - **GET**: Requests data from the server. It is used for reading data and does not alter the server state.
    - **POST**: Submits data to be processed to the server. It is used for sending data and can modify the server state.

25. **How to execute validation in MVC?**  
    Validation is executed in MVC using model validation attributes (Data Annotations) and client-side validation with the help of jQuery Unobtrusive Validation.

26. **How do Views and Partial Views differ?**  
    - **View**: A complete HTML markup that is sent as a response to a request.
    - **Partial View**: A reusable segment of a view, which can be embedded in other views.

27. **What basic folders use the MVC template without Areas in the ASP.NET Core project?**  
    - **Controllers**: Stores controller classes.
    - **Models**: Stores application models.
    - **Views**: Stores view files.
    - **wwwroot**: Stores static files (CSS, JavaScript, images).

28. **Why is WebAPI technology introduced?**  
    WebAPI was introduced to facilitate the creation of HTTP services that reach a broad range of clients, including browsers, mobile devices, and desktop applications. It helps in building RESTful services.

29. **What steps need to be followed when you have an ASP.NET Core MVC application wherein you have to use some cache solution as well as support running across multiple servers?**  
    - Implement distributed caching (e.g., using Redis or SQL Server).
    - Configure the application to use the distributed cache.
    - Ensure that the cache configuration supports scalability and high availability.

30. **Discuss the vital namespaces used in ASP.NET MVC?**  
    - `System.Web.Mvc`: Core functionalities of MVC.
    - `System.Web.Routing`: Used for routing-related functionalities.
    - `System.Web.Optimization`: Used for bundling and minification.
   

 - `System.ComponentModel.DataAnnotations`: Used for model validation and data annotations.
