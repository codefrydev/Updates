---
title: "ASP.NET MVC Interview Questions - Set 10"
author: "PrashantUnity"
weight: 220
date: 2024-08-03
lastmod: 2024-10-25
dateString: August 2024  
description: "Complete tutorial-style ASP.NET MVC interview questions covering MVC 4 features, asynchronous controllers, and practical implementation examples"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "NET", "codefrydev", "C sharp", "CFD"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD"]
---

1. **What is ASP.NET MVC?**  
   ASP.NET MVC (Model-View-Controller) is a web application framework developed by Microsoft. It implements the MVC pattern to separate an application into three main components: Model (data and business logic), View (user interface), and Controller (handles user input and updates the Model). This separation helps in managing complexity, improving testability, and making code more maintainable.

2. **Tell us something about Model, View, and Controllers in ASP.NET MVC?**  
   - **Model**: Represents the data and business logic of the application. It interacts with the database and provides data to the View.
   - **View**: The presentation layer. It renders the model data to the user and generates HTML based on the data.
   - **Controller**: Manages the user input, interacts with the Model, and selects a View to display. It processes incoming requests, updates the Model, and returns a View.

3. **Do you know about the new features in ASP.NET MVC 4?**  
   ASP.NET MVC 4 introduced several new features including:
   - **Asynchronous Controller Actions**: Allows for improved scalability and performance by enabling asynchronous operations.
   - **Razor View Engine Enhancements**: Improved syntax and performance.
   - **Mobile Application Development**: Includes support for mobile application development with features like mobile-specific views.
   - **Web API**: A framework for building HTTP services that can be consumed by various clients, including browsers and mobile devices.

4. **How does the 'page lifecycle' of ASP.NET MVC work?**  
   The ASP.NET MVC page lifecycle involves:
   - **Routing**: Mapping incoming requests to controllers and actions.
   - **Controller Initialization**: Creating an instance of the controller.
   - **Action Execution**: Invoking the appropriate action method.
   - **Result Execution**: Processing the result, which could be a View, JSON, or other types.
   - **View Rendering**: Generating HTML for the view and sending it to the client.

5. **Explain the advantages of ASP.NET MVC over ASP.NET Web Forms?**  
   - **Separation of Concerns**: Clear separation between business logic, UI, and user input.
   - **Testability**: Easier to write unit tests for MVC applications due to separation of components.
   - **Control Over HTML**: Greater control over the generated HTML, making it easier to create cleaner and more SEO-friendly pages.
   - **Support for Asynchronous Programming**: Improved scalability with asynchronous controller actions.

6. **What is Separation of Concerns in ASP.NET MVC?**  
   Separation of Concerns (SoC) is a design principle where different parts of an application handle distinct responsibilities. In ASP.NET MVC, this means:
   - **Model**: Manages data and business logic.
   - **View**: Handles presentation and UI logic.
   - **Controller**: Manages user input and application flow.

7. **What is Razor View Engine?**  
   Razor is a view engine that allows embedding C# code in HTML markup. It provides a clean syntax with `@` to switch between HTML and C# code, making it easier to generate dynamic content.

8. **What is the meaning of Unobtrusive JavaScript? Explain us by any practical example.**  
   Unobtrusive JavaScript refers to a design approach where JavaScript code is kept separate from HTML markup. This approach ensures that JavaScript is added in a way that doesn’t mix with the HTML content. For example, using jQuery to attach event handlers instead of inline `onclick` attributes:
   ```html
   <button id="myButton">Click me</button>
   ```
   ```javascript
   $(document).ready(function() {
       $('#myButton').click(function() {
           alert('Button clicked!');
       });
   });
   ```

9. **What is the use of ViewModel in ASP.NET MVC?**  
   A ViewModel is a model designed specifically for use in views. It encapsulates the data required for a view and may combine data from multiple models. It helps in passing data to the view and organizing it in a way that is tailored for the view's requirements.

10. **What do you mean by Routing in ASP.NET MVC?**  
    Routing is the process of mapping incoming URL requests to specific controllers and actions. It is configured in the `RouteConfig` class and allows the application to handle URLs in a user-friendly and SEO-friendly manner.

11. **What are Actions in ASP.NET MVC?**  
    Actions are methods within a controller that handle incoming HTTP requests. They process input, interact with the model, and return a result, such as a view or JSON data.

12. **What is Attribute Routing in ASP.NET MVC?**  
    Attribute Routing allows developers to define routes directly on controller actions using attributes. This provides a more flexible and readable way to define routes compared to conventional routing.

13. **How to enable Attribute Routing?**  
    Attribute Routing can be enabled by calling `RouteConfig.RegisterRoutes(RouteTable.Routes);` in the `RouteConfig` class and adding `[Route]` attributes to controller actions.

14. **Explain JSON Binding?**  
    JSON Binding refers to the process of deserializing JSON data sent in an HTTP request into .NET objects. It is commonly used to handle data sent from JavaScript or other clients to the server.

15. **Explain Dependency Resolution?**  
    Dependency Resolution refers to the process of providing required dependencies to components at runtime. In ASP.NET MVC, this is often achieved using Dependency Injection (DI) containers to manage service lifetimes and resolve dependencies.

16. **Explain Bundle.Config in ASP.NET MVC4?**  
    `BundleConfig` is a configuration class used for bundling and minification of CSS and JavaScript files. Bundling combines multiple files into a single file, and minification reduces file size by removing unnecessary characters.

17. **How is the route table created in ASP.NET MVC?**  
    The route table is created in the `RouteConfig` class in `App_Start` folder. It is populated using the `RouteCollection` object and its `MapRoute` method to define how URL patterns map to controller actions.

18. **Which are the important namespaces used in ASP.NET MVC?**  
    - **System.Web.Mvc**: Contains core MVC classes like `Controller`, `ActionResult`, etc.
    - **System.Web.Routing**: Provides routing functionality.
    - **System.Web.Http**: Contains classes for Web API functionality.

19. **What is ViewData?**  
    `ViewData` is a dictionary object that allows passing data from a controller to a view. It is used to share data between the controller and view in a strongly typed way.

20. **What is the difference between ViewBag and ViewData in ASP.NET MVC?**  
    - **ViewData**: A dictionary object that requires type casting and checks for null values.
    - **ViewBag**: A dynamic property that allows for more flexible data passing without needing type casting.

21. **Explain TempData in ASP.NET MVC?**  
    `TempData` is a dictionary used to store data for the duration of a single request or until it is read. It is useful for passing data between actions during redirects.

22. **What are HTML Helpers in ASP.NET MVC?**  
    HTML Helpers are methods used in views to generate HTML elements. They simplify rendering form fields, links, and other HTML elements, making it easier to build dynamic content.

23. **What are AJAX Helpers in ASP.NET MVC?**  
    AJAX Helpers provide methods to create AJAX-enabled elements, such as form submissions and partial page updates, without full-page reloads.

24. **What are the options that can be configured in AJAX helpers?**  
    Options include specifying URL, HTTP method, data to send, success and error callbacks, and data type for responses.

25. **What is Layout in ASP.NET MVC?**  
    Layouts provide a common structure for multiple views in an application, such as headers, footers, and navigation menus. They ensure a consistent look and feel across different views.

26. **Explain Sections in ASP.NET MVC?**  
    Sections allow defining placeholders in a layout view that can be filled by content from specific views. Sections provide a way to inject content into a layout dynamically.

27. **Can you explain RenderBody and RenderPage in ASP.NET MVC?**  
    - **RenderBody**: A placeholder in the layout view where the content of child views is rendered.
    - **RenderPage**: Allows rendering other views (partial views) within a view or layout.

28. **What is ViewStart Page in ASP.NET MVC?**  
    `_ViewStart.cshtml` is a special view used to define settings or layout for all views in a folder. It is executed before any view in that folder is rendered.

29. **Explain the methods used to render the views in ASP.NET MVC?**  
    - **Return View()**: Renders a view associated with the action method.
    - **PartialView()**: Renders a partial view.
    - **RedirectToAction()**: Redirects to another action method.
    - **Json()**: Returns JSON-formatted data.

30. **What are the sub-types of ActionResult?**  
    - **ViewResult**: Renders a view.
    - **PartialViewResult**: Renders a partial view.
    - **JsonResult**: Returns JSON data.
    - **RedirectResult**: Redirects to a different URL.
    - **ContentResult**: Returns raw content.
    - **FileResult**: Returns a file.

31. **What are Non Action methods in ASP.NET

 MVC?**  
    Non-action methods are methods within a controller that cannot be accessed directly via URL routing. They are marked with the `[NonAction]` attribute.

32. **How to change the action name in ASP.NET MVC?**  
    You can change the action name using the `[ActionName("NewName")]` attribute, which specifies an alternative name for the action method.

33. **What are Code Blocks in Views?**  
    Code blocks are sections in Razor views enclosed in `@{ ... }`, used to write C# code for generating dynamic content.

34. **What is the "HelperPage.IsAjax" Property?**  
    `HelperPage.IsAjax` is a property used to determine if the current request is an AJAX request, allowing for different handling based on the request type.

35. **How can we call a JavaScript function on the change of a Dropdown List in ASP.NET MVC?**  
    Use JavaScript or jQuery to attach an `onchange` event handler to the dropdown list:
    ```javascript
    $('#myDropdown').change(function() {
        myFunction();
    });
    ```

36. **What are Validation Annotations?**  
    Validation annotations are attributes applied to model properties to enforce validation rules (e.g., `[Required]`, `[Range]`, `[EmailAddress]`).

37. **Why use Html.Partial in ASP.NET MVC?**  
    `Html.Partial` is used to render a partial view within a view. It allows for reusable components and separation of UI elements into smaller, manageable parts.

38. **What is Html.RenderPartial?**  
    `Html.RenderPartial` is similar to `Html.Partial` but writes the output directly to the response stream, which can be more efficient for large partial views.

39. **What is RouteConfig.cs in ASP.NET MVC 4?**  
    `RouteConfig.cs` is a configuration class that defines the routing rules for an ASP.NET MVC application. It specifies how URLs are mapped to controllers and actions.

40. **What are Scaffold templates in ASP.NET MVC?**  
    Scaffold templates are pre-defined templates used to generate code for CRUD operations based on the model. They help speed up development by providing ready-to-use code.

41. **Explain the types of Scaffolding.**  
    - **Empty**: Creates an empty controller or view.
    - **MVC Controller with Views**: Generates a controller with CRUD views.
    - **Web API Controller**: Generates a Web API controller with CRUD actions.

42. **Can a view be shared across multiple controllers? If Yes, How can we do that?**  
    Yes, a view can be shared across multiple controllers by placing it in the `Shared` folder within the `Views` directory. This allows all controllers to access it.

43. **What are the components required to create a route in ASP.NET MVC?**  
    - **URL Pattern**: Defines the structure of the URL.
    - **Default Values**: Specifies default values for route parameters.
    - **Constraints**: Limits the URL parameters to specific values.

44. **Why use "{resource}.axd/{*pathInfo}" in routing in ASP.NET MVC?**  
    This route is used to handle requests for web resource files (like `.axd` files) that are used by ASP.NET for various purposes, such as tracing and web resources.

45. **Can we add constraints to the route? If yes, explain how we can do it?**  
    Yes, constraints can be added to routes to ensure that URL parameters match specific patterns. For example:
    ```csharp
    routes.MapRoute(
        name: "Default",
        url: "{controller}/{action}/{id}",
        defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
        constraints: new { id = @"\d+" } // id must be a number
    );
    ```

46. **What are the possible Razor view extensions?**  
    Razor view extensions include `.cshtml` for C# and `.vbhtml` for VB.NET.

47. **What is PartialView in ASP.NET MVC?**  
    `PartialView` is a view that renders a portion of a view, such as a user control or a reusable component. It is used to break down complex views into smaller, manageable parts.

48. **How can we add CSS in ASP.NET MVC?**  
    CSS can be added to an ASP.NET MVC application by including stylesheets in the layout view or specific views using the `<link>` HTML tag.

49. **Can I add ASP.NET MVC Testcases in Visual Studio Express?**  
    Yes, Visual Studio Express editions support unit testing. You can write and run unit tests using frameworks like NUnit, xUnit, or MSTest.

50. **What is the use of Glimpse in ASP.NET MVC?**  
    Glimpse is a diagnostic tool that provides detailed insights into the server-side execution of your application, including routing, performance, and other diagnostics.

51. **What is the need for Action Filters in ASP.NET MVC?**  
    Action Filters provide a way to execute code before or after an action method runs. They are used for tasks such as logging, authentication, and performance measurement.

52. **Mention some action filters which are used regularly in ASP.NET MVC?**  
    - **[Authorize]**: Restricts access to authenticated users.
    - **[ValidateAntiForgeryToken]**: Protects against Cross-Site Request Forgery (CSRF) attacks.
    - **[HandleError]**: Provides a way to handle exceptions and display error views.

53. **How can we determine if an action was invoked from HTTP GET or HTTP POST?**  
    By checking the `Request.HttpMethod` property in the action method, you can determine if the request is GET or POST:
    ```csharp
    if (Request.HttpMethod == "POST")
    {
        // Handle POST request
    }
    else
    {
        // Handle GET request
    }
    ```

54. **In Server, how to check whether the model has errors or not in ASP.NET MVC?**  
    Use the `ModelState.IsValid` property to check if the model passed validation:
    ```csharp
    if (!ModelState.IsValid)
    {
        // Handle model validation errors
    }
    ```

55. **How to make sure Client Validation is enabled in ASP.NET MVC?**  
    Ensure that client-side validation is enabled by including the necessary scripts in your view:
    ```html
    @Scripts.Render("~/bundles/jqueryval")
    ```

56. **What are Model Binders in ASP.NET MVC?**  
    Model Binders are components that convert HTTP request data into .NET types and bind them to action method parameters. They handle the conversion and validation of data.

57. **How can we handle exceptions at the controller level in ASP.NET MVC?**  
    Use the `[HandleError]` attribute on controllers or action methods to handle exceptions and display custom error views. Alternatively, handle exceptions in the `Application_Error` method in `Global.asax`.

58. **Does TempData hold the data for other requests in ASP.NET MVC?**  
    `TempData` holds data for a single request and the next request. It is designed for passing data during redirects.

59. **Explain Keep method in TempData in ASP.NET MVC?**  
    The `Keep` method retains `TempData` values for the duration of the next request, allowing the data to persist through redirects.

60. **Explain Peek method in TempData in ASP.NET MVC?**  
    The `Peek` method allows accessing the value of `TempData` without marking it for deletion, so it can still be accessed in subsequent requests.

61. **What is Area in ASP.NET MVC?**  
    Areas provide a way to partition a large ASP.NET MVC application into smaller, manageable sections. Each area can have its own controllers, views, and models.

62. **How can we register the Area in ASP.NET MVC?**  
    Register an area in the `AreaRegistration` class and add it to the `RegisterRoutes` method in `RouteConfig.cs`:
    ```csharp
    public class MyAreaRegistration : AreaRegistration
    {
        public override string AreaName => "MyArea";
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MyArea_default",
                "MyArea/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
    ```

63. **What are child actions in ASP.NET MVC?**  
    Child actions are actions that can be invoked from other actions or views to render partial content. They are defined using the `[ChildActionOnly]` attribute.

64. **How can we invoke child actions in ASP.NET MVC?**  
    Child actions can be invoked using the `Html.Action` or `Html.RenderAction` HTML helper methods:
    ```html
    @Html.Action("ChildAction", "Home")
    ```

65. **What is Dependency Injection in ASP.NET MVC?**  
    Dependency Injection (DI) is a design pattern used to inject dependencies into classes rather than creating them internally. It promotes loose coupling and improves testability.

66. **Explain the advantages of Dependency Injection (DI) in ASP.NET MVC?**  
    - **Improved Testability**: Easier to write unit tests by injecting mock dependencies.
    - **Decoupling**: Reduces dependencies between components.
    - **Flexibility**: Allows changing implementations without modifying the dependent classes.

67. **Explain Test Driven Development (TDD)?**  
    Test Driven Development (TDD) is a software development process where tests are

 written before the actual code. The process involves writing a test, writing code to pass the test, and then refactoring.

68. **Explain the tools used for unit testing in ASP.NET MVC?**  
    Tools for unit testing in ASP.NET MVC include:
    - **MSTest**: Microsoft’s testing framework.
    - **NUnit**: A popular open-source testing framework.
    - **xUnit**: Another widely used testing framework.

69. **What is Representational State Transfer (REST)?**  
    REST is an architectural style for designing networked applications. It relies on stateless, client-server communication, using standard HTTP methods like GET, POST, PUT, and DELETE.

70. **How to use jQuery Plugins in ASP.NET MVC validation?**  
    To use jQuery plugins for validation, include the plugin scripts and configure validation rules in your views or JavaScript files. For example, using the jQuery Validation plugin:
    ```html
    <script src="~/Scripts/jquery.validate.min.js"></script>
    <script src="~/Scripts/jquery.validate.unobtrusive.min.js"></script>
    ```

71. **How can we handle multiple submit buttons in ASP.NET MVC?**  
    Use different `name` attributes for each submit button and check their values in the action method to determine which button was clicked:
    ```html
    <input type="submit" name="action" value="Save" />
    <input type="submit" name="action" value="Delete" />
    ```
    ```csharp
    public ActionResult MyAction(FormCollection form)
    {
        var action = form["action"];
        if (action == "Save")
        {
            // Handle Save
        }
        else if (action == "Delete")
        {
            // Handle Delete
        }
    }
    ```

72. **What are the differences between Partial View and Display Template and Edit Templates in ASP.NET MVC?**  
    - **Partial View**: A reusable view that can be included in other views.
    - **Display Template**: A view used to render a specific model type, often used for rendering data in a consistent manner.
    - **Edit Template**: Similar to display templates but used for rendering forms for editing data.

73. **Can I set an unlimited length for the "maxJsonLength" property in config?**  
    Setting an unlimited length is not recommended. The `maxJsonLength` property limits the length of JSON responses to prevent excessive memory usage. It's better to handle large data sets with pagination or other techniques.

74. **Can I use Razor code in JavaScript in ASP.NET MVC?**  
    Yes, Razor code can be embedded within JavaScript code blocks in Razor views. However, it's important to ensure that the Razor syntax is properly escaped to avoid syntax errors.

75. **How can I return a string result from an Action in ASP.NET MVC?**  
    Return a `ContentResult` with the string result:
    ```csharp
    public ActionResult MyAction()
    {
        return Content("Hello, World!");
    }
    ```

76. **How to return JSON from an action method in ASP.NET MVC?**  
    Return a `JsonResult` with the data:
    ```csharp
    public ActionResult GetJson()
    {
        var data = new { Name = "John", Age = 30 };
        return Json(data, JsonRequestBehavior.AllowGet);
    }
    ```
