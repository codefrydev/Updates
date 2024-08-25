---
title: "Set Eight"
author: "PrashantUnity"
weight: 218
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
   MVC (Model-View-Controller) is a design pattern used to separate an application into three main components: the Model, the View, and the Controller. This separation helps manage complex applications by separating the input logic, business logic, and UI logic while providing a clear structure for the development.

2. **What does Model-View-Controller stand for in an MVC application?**  
   - **Model**: Manages the data and business logic of the application.
   - **View**: Displays data to the user and represents the UI.
   - **Controller**: Handles user input, manipulates the model, and updates the view.

3. **State the various controller action ways to return types:**  
   - **ViewResult**: Returns a view as a web page.
   - **JsonResult**: Returns data in JSON format.
   - **RedirectResult**: Redirects to another action method or URL.
   - **ContentResult**: Returns plain text content.
   - **PartialViewResult**: Returns a partial view.
   - **FileResult**: Returns a file to the user.
   - **EmptyResult**: Represents no result.

4. **What sets adding connections to an application developed apart from adding routes to a Web Form application?**  
   In MVC, routing is used to map URLs to controller actions based on predefined patterns, providing more flexibility and control over URL structures compared to Web Forms, which rely on physical file paths and page life cycle events.

5. **Describe the two primary ways that a path can be constrained:**  
   - **Inline Constraints**: Constraints added directly to the route definition (e.g., `{id:int}` for integer constraints).
   - **Custom Route Constraints**: Implementing `IRouteConstraint` to define more complex or custom logic for route validation.

6. **What benefits does MVC offer?**  
   - **Separation of Concerns**: Divides application logic into three distinct layers.
   - **Scalability**: Easier to maintain and extend due to modular design.
   - **Testability**: Improved testability with isolated components.
   - **Reusability**: Views and logic can be reused across different parts of the application.
   - **SEO-Friendly**: URL routing helps create SEO-friendly URLs.

7. **What do the controller's "beforeFilter()", "beforeRender," and "afterFilter" functions perform?**  
   These are hooks commonly used in frameworks like CakePHP:
   - **beforeFilter()**: Executes before any action method is called.
   - **beforeRender()**: Executes before rendering the view.
   - **afterFilter()**: Executes after the action method is completed.

8. **What functions do Presentation, Abstract, and Control perform in MVC?**  
   - **Presentation (View)**: Displays the data and the user interface.
   - **Abstraction (Model)**: Encapsulates data and business rules.
   - **Control (Controller)**: Manages user input and coordinates between the Model and View.

9. **What are the MVC model's shortcomings?**  
   - **Complexity**: Can be more complex to set up initially compared to other patterns.
   - **Overhead**: Introduces some overhead due to abstraction layers.
   - **Learning Curve**: Requires understanding of MVC pattern and frameworks that implement it.
   - **Not Always Necessary**: Might be overkill for simple applications.

10. **What function does "ActionFilters" serve in MVC?**  
    Action Filters allow execution of custom logic before or after an action method runs. They are used for tasks like logging, authentication, caching, and error handling.

11. **What are the procedures for carrying out an MVC project?**  
    - **Set up the project structure**: Define Models, Views, and Controllers.
    - **Define routes**: Configure routing to map URLs to controller actions.
    - **Implement business logic**: Develop Models and Controllers.
    - **Create views**: Design the UI with views.
    - **Test**: Perform unit testing and integration testing.
    - **Deploy**: Deploy the application to a web server.

12. **What are the three segments and routing?**  
    The three segments typically used in MVC routing are:
    - **Controller**: Specifies which controller to handle the request.
    - **Action**: Specifies which action method to call on the controller.
    - **Parameters**: Additional parameters passed to the action method.

13. **How does the MVC pattern handle routing?**  
    MVC uses a routing system to map incoming HTTP requests to specific controller actions based on URL patterns defined in route configurations.

14. **How does using a hyperlink let you move between views?**  
    Using `@Html.ActionLink("Link Text", "ActionName", "ControllerName")` in Razor views allows navigation between different views by generating appropriate URLs.

15. **What distinguishes ViewData, TempData, and ViewBag?**  
    - **ViewData**: Dictionary object used to pass data from controller to view. Requires casting.
    - **ViewBag**: Dynamic object to pass data from controller to view. No need for casting.
    - **TempData**: Stores data temporarily between two requests, typically used for redirection.

16. **What is an incomplete view in MVC?**  
    An incomplete view, also known as a Partial View, is a view that only represents a portion of the web page, designed to be reused within other views.

17. **How may Ajax be used in MVC?**  
    - Use `Ajax.BeginForm()` for AJAX-based form submissions.
    - Use `$.ajax()` in jQuery for making asynchronous requests to the server.
    - Update parts of a page dynamically without reloading the entire page.

18. **What distinguishes "ActionResult" from "ViewResult"?**  
    - **ActionResult**: Base class for all action result types in MVC. It allows returning different types of responses (e.g., JSON, Views, Redirects).
    - **ViewResult**: A specific type of ActionResult that renders a view.

19. **In MVC, how can you return the output in JSON format?**  
    Use `JsonResult` by calling `return Json(data);` from an action method.

20. **What kinds of outcomes are there in MVC?**  
    - **ViewResult**
    - **JsonResult**
    - **PartialViewResult**
    - **RedirectResult**
    - **ContentResult**
    - **FileResult**
    - **EmptyResult**

21. **What function does NonActionAttribute serve?**  
    The `[NonAction]` attribute is used to mark methods in a controller that should not be treated as action methods, even though they are public.

22. **What purpose does the standard route `resource.axd/*pathinfo` serve?**  
    This route is used to handle requests for embedded resources, such as scripts or styles, managed by the framework (e.g., WebResource.axd for Web Forms).

23. **If numerous filters are used, what is the sequence in which they are applied?**  
    Filters are applied in the following order:
    - Authorization Filters
    - Action Filters
    - Result Filters
    - Exception Filters

24. **What file formats do Razor views support?**  
    Razor views typically use `.cshtml` for C# and `.vbhtml` for Visual Basic.

25. **Which are the two primary ways that a route can be constrained?**  
    - **Inline Constraints**: Constraints in the route definition.
    - **Custom Route Constraints**: Constraints defined by implementing `IRouteConstraint`.

26. **What are two situations when routing is either not used or not necessary?**  
    - **Static File Access**: Serving files like images, CSS, and JavaScript directly.
    - **Direct HTTP Handlers**: Direct access to handlers bypassing MVC routing.

27. **What characteristics does MVC have?**  
    - **Separation of Concerns**: Divides application logic into distinct parts.
    - **Testability**: Isolates logic for easier testing.
    - **Modularity**: Allows different parts of the application to be developed independently.
    - **Extensibility**: Supports custom routing, view engines, and more.

28. **How may MVC architecture be used in JSP?**  
    In JSP, MVC can be implemented using:
    - **Model**: JavaBeans or other classes for data handling.
    - **View**: JSP pages for the user interface.
    - **Controller**: Servlets to handle requests and manage the flow.

29. **Can you build a web application using both MVC and Web Forms?**  
    Yes, it's possible to build a hybrid application using both MVC and Web Forms, typically to leverage existing Web Forms components while migrating to MVC.

30. **What distinguishes WebAPI from MVC most significantly?**  
    - **WebAPI**: Primarily used for building RESTful services that return data in formats like JSON or XML.
    - **MVC**: Focuses on returning HTML views for web applications.

31. **What is the ASP.NET MVC Razor concept explained?**  
    Razor is a view engine syntax used in ASP.NET MVC that enables embedding C# code directly within HTML using the `@` symbol. It provides a concise syntax and automatically encodes output for security.

32. **Which filters are available for final execution?**  
    - **Exception Filters**: Executed last to handle exceptions raised during action or other filter execution.

33. **What potential roadblocks might there be?**  
    - **Performance Bottlenecks**: Inefficient data handling or poorly optimized views

.
    - **Scalability Issues**: Managing state and handling increased load.
    - **Security Concerns**: Cross-site scripting, SQL injection.
    - **Complexity**: Managing dependencies and keeping controllers thin.

34. **Why was the introduction of WebAPI technology necessary?**  
    WebAPI was introduced to create RESTful services that can serve data to clients on various platforms like web, mobile, and IoT devices, offering a lighter, more flexible alternative to WCF.

35. **Which stages are involved in creating the request object?**  
    - **Routing**: Mapping the request URL to the controller and action.
    - **Instantiating Controller**: Creating an instance of the controller.
    - **Executing Action**: Calling the action method.
    - **Generating Result**: Generating the response (view, JSON, etc.).

36. **What are the four major components of MVC?**  
    - **Model**: Data and business logic.
    - **View**: Presentation layer.
    - **Controller**: Handles user input.
    - **Router**: Maps URLs to controller actions.

37. **Why is ASP.NET MVC used?**  
    - Offers a clean separation of concerns.
    - Provides a testable and maintainable architecture.
    - Enables building dynamic, scalable, and SEO-friendly web applications.
    - Supports powerful routing and URL mapping.

38. **How many layers are there in MVC?**  
    Typically, there are three layers: Model, View, and Controller.

39. **Is ASP.NET MVC Backend or Frontend?**  
    ASP.NET MVC is a framework that spans both backend (controllers, models) and frontend (views).

40. **What language is ASP.NET MVC?**  
    ASP.NET MVC applications are typically written in C#.

41. **Is ASP.NET MVC Open Source?**  
    Yes, ASP.NET MVC is open source under the Apache License 2.0.

42. **Can we use Web API in MVC?**  
    Yes, Web API can be used within an MVC application to handle RESTful service requests.

43. **Is MVC a REST API?**  
    MVC is not a REST API, but it can be used to build RESTful services.

44. **What is HttpClient in MVC?**  
    `HttpClient` is a class used to send HTTP requests and receive HTTP responses from a resource identified by a URI. It's commonly used to call APIs or external services.

45. **Why is ViewModel used in MVC?**  
    A ViewModel is used to pass data from the controller to the view, combining data from multiple models and adding additional data necessary for the view's logic.