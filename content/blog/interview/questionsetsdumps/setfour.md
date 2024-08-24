---
title: "Set Four"
author: "PrashantUnity"
weight: 213
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

### General MVC Concepts

1. **What is Model-View-Controller?**
   - **Model-View-Controller (MVC)** is a software architectural pattern that separates an application into three main logical components: the Model, the View, and the Controller. Each of these components is responsible for handling different aspects of the application.

2. **What does Model-View-Controller represent in an MVC application?**
   - **Model**: Represents the data and business logic. It directly manages the data, logic, and rules of the application.
   - **View**: Represents the user interface. It displays the data from the model to the user and sends user commands to the controller.
   - **Controller**: Handles user input, manipulates the model, and updates the view as needed. It acts as an intermediary between the model and the view.

3. **Name the Assembly to Define MVC**
   - The ASP.NET MVC framework is defined in the `System.Web.Mvc` assembly.

### Controllers and Routing

4. **What are the Different Return Types of a Controller Action Method?**
   - `ViewResult`: Returns a view.
   - `PartialViewResult`: Returns a partial view.
   - `JsonResult`: Returns JSON-formatted data.
   - `RedirectResult`: Redirects to a new URL.
   - `RedirectToRouteResult`: Redirects to a specified route.
   - `ContentResult`: Returns plain text content.
   - `FileResult`: Returns a file for download.
   - `EmptyResult`: Returns no result (used to return nothing).

5. **What is the Difference Between Adding Routes to a WebForm Application and an MVC Application?**
   - **WebForm Application**: Routing is less commonly used, and requests are usually mapped directly to file paths.
   - **MVC Application**: Routing is central, mapping URL patterns to specific controller actions using route definitions in `RouteConfig.cs`.

6. **What are the Two Ways to Add Constraints to a Route?**
   - **Inline Constraints**: Directly specifying constraints in the route URL pattern, e.g., `{id:int}`.
   - **Custom Constraints**: Using a custom class that implements `IRouteConstraint` to define more complex constraints.

### MVC Features and Benefits

7. **What are the Advantages of MVC?**
   - **Separation of Concerns**: Divides application logic into three interconnected components, making the application more modular and maintainable.
   - **Testability**: Easy to test each component independently.
   - **Scalability**: Suitable for large-scale applications due to its modularity.
   - **Flexibility**: Supports multiple views for a model, promoting reusability.

8. **What “beforeFilter()”, “beforeRender()”, and “afterFilter()” Functions Do in Controller?**
   - These functions are common in frameworks like CakePHP:
     - **beforeFilter()**: Executes code before any action in the controller.
     - **beforeRender()**: Executes code before rendering the view.
     - **afterFilter()**: Executes code after the controller action and view have been rendered.

9. **What is the Role of Components Presentation, Abstraction, and Control in MVC?**
   - **Presentation**: Handles displaying the UI to the user (View).
   - **Abstraction**: Manages the data and business logic (Model).
   - **Control**: Acts as a bridge between the model and the view, handling user input and updating the model/view (Controller).

10. **What are the Drawbacks of the MVC Model?**
    - **Complexity**: MVC can introduce complexity for small applications.
    - **Learning Curve**: Developers need to understand the MVC structure, which can take time.
    - **Overhead**: Can lead to over-separation of logic in small applications, making it unnecessarily complex.

### Action Filters, Routing, and Execution

11. **What is the Role of “ActionFilters” in MVC?**
    - Action filters are used to execute code before or after an action method executes. Examples include authentication checks, logging, or error handling.

12. **What are the Steps for the Execution of an MVC Project?**
    - **Step 1**: Configure routing in `RouteConfig.cs`.
    - **Step 2**: Instantiate the controller based on the route.
    - **Step 3**: Invoke the action method.
    - **Step 4**: Process and execute any filters.
    - **Step 5**: Generate the result (e.g., view or JSON).
    - **Step 6**: Render the view and send the response to the client.

13. **What is Routing and Three Segments?**
    - **Routing** is the process of mapping URLs to specific controller actions.
    - The three segments in routing typically represent:
      - **Controller**: Name of the controller.
      - **Action**: Name of the action method.
      - **Parameters**: Additional parameters for the action method.

14. **How Routing is Done in the MVC Pattern?**
    - Routes are defined in a route configuration file (e.g., `RouteConfig.cs`), mapping URL patterns to controller actions using `MapRoute()` method.

### View Navigation and Session Management

15. **How Can You Navigate from One View to Another View Using a Hyperlink?**
    - Use the `Html.ActionLink` helper method to create hyperlinks between views:
      ```html
      @Html.ActionLink("Go to About Page", "About", "Home")
      ```

16. **How are Sessions Maintained in MVC?**
    - Sessions can be maintained using the `Session` object, which stores key-value pairs, or by using cookies, hidden fields, or query strings for more secure or customized session management.

### Data Passing Between Components

17. **What is the Difference Between TempData, ViewData, and ViewBag?**
    - **TempData**: Stores data temporarily and is available for the next request only.
    - **ViewData**: A dictionary object to pass data from the controller to the view within the same request.
    - **ViewBag**: A dynamic property wrapper around `ViewData` to pass data from the controller to the view within the same request.

18. **What is a Partial View in MVC?**
    - A partial view is a reusable component of a view, like a user control in traditional ASP.NET. It renders a part of the HTML and can be included in multiple views.

### AJAX and Result Types

19. **How Can You Implement Ajax in MVC?**
    - Use jQuery `$.ajax()` for custom AJAX calls.
    - Use `Ajax.BeginForm()` for form submissions.
    - Use `@Ajax.ActionLink()` for asynchronous hyperlink calls.

20. **What is the Difference Between “ActionResult” and “ViewResult”?**
    - **ActionResult**: A base class for all action results. It allows returning different result types like views, JSON, redirects, etc.
    - **ViewResult**: A subclass of `ActionResult` specifically for rendering views.

21. **How Can You Send the Result Back in JSON Format in MVC?**
    - Use the `JsonResult` class by returning `Json(object)` from the action method.
      ```csharp
      return Json(new { name = "John", age = 30 });
      ```

22. **What is the Difference Between View and Partial View?**
    - **View**: Represents a full HTML page with layout.
    - **Partial View**: Represents a part of the page, used to render reusable sections of the UI.

### Additional MVC Concepts

23. **What are the Types of Results in MVC?**
    - `ViewResult`, `PartialViewResult`, `JsonResult`, `RedirectResult`, `RedirectToRouteResult`, `ContentResult`, `FileResult`, `EmptyResult`.

24. **What is the Importance of NonActionAttribute?**
    - The `NonAction` attribute prevents a public method in a controller from being treated as an action method, marking it as non-action.

25. **What is the Use of the Default Route `{resource}.axd/{*pathinfo}`?**
    - This route prevents requests for web resources such as WebResource.axd or ScriptResource.axd from being passed to controllers, as these are handled by the system.

26. **What is the Order of the Filters that Get Executed, if Multiple Filters are Implemented?**
    - Filters execute in this order:
      1. Authorization filters
      2. Action filters
      3. Result filters
      4. Exception filters

27. **What ASP.NET Filters are Executed in the End?**
    - **Exception filters** are executed last to handle any exceptions that occur during the action execution or result rendering.

28. **What are the File Extensions for Razor Views?**
    - `.cshtml` for C# Razor views.
    - `.vbhtml` for VB.NET Razor views.

29. **What are the Two Ways for Adding Constraints to a Route?**
    - **Inline Constraints** in the route definition, e.g., `{id:int}`.
    - **Custom Constraint Classes** implementing `IRouteConstraint`.

30. **What are Two Instances Where Routing is Not Implemented or Required?**
    - **Static File Requests**: Direct requests for static files (e.g., images, CSS) don't need routing.
    - **WebForm Pages**: In hybrid projects with WebForm pages, those pages don't follow MVC routing.

### Features, Real-Life Examples, and Comparisons

31. **What are the Features of MVC?**
    - **Separation of Concerns**, **Modularity**, **Testability**, **Pluggable Framework**, **Extensibility**, **Support for Multiple View Engines** (R

azor, ASPX).

32. **What are Real-Life Examples of MVC?**
    - **E-commerce websites**: Separate models for products, views for product listings, and controllers to manage user requests and responses.
    - **Blog platforms**: Using MVC to separate content management (models) from the front-end design (views) and logic (controllers).

33. **What is the Difference Between 3-tier Architecture and MVC Architecture?**
    - **3-tier Architecture**: Divides application into Presentation, Business Logic, and Data Access layers.
    - **MVC Architecture**: Focuses on separating application logic from the user interface, with a more refined interaction between its components.

34. **How Can You Use MVC Architecture in JSP?**
    - Use JSP for the view layer, JavaBeans for the model, and servlets for the controller to manage user input and application flow.

### MVC in Other Frameworks

35. **How MVC Works in Spring?**
    - In Spring MVC, a controller processes incoming requests, interacts with the model, and returns a view to be rendered. Spring provides built-in support for dependency injection, making it easier to manage components.

36. **What are the Important Points to Remember While Creating an MVC Application?**
    - Properly configure routing.
    - Ensure clear separation between models, views, and controllers.
    - Use action filters for cross-cutting concerns like logging or authorization.
    - Utilize partial views for reusability.
    - Maintain session and data flow effectively.

37. **What is the Difference Between Web Forms and MVC?**
    - **Web Forms**: Event-driven, uses a code-behind model, and relies on postbacks and view state.
    - **MVC**: Follows the MVC pattern, uses routing for URL management, and does not rely on view state, offering more control over HTML and client-side behavior.

38. **How Can You Display Something in CodeIgniter?**
    - Load a view using the `load->view()` method in a controller:
      ```php
      $this->load->view('welcome_message');
      ```

39. **Write a Code to Demonstrate Model, View, and Controller in CodeIgniter.**
    - **Model**: `application/models/User_model.php`
      ```php
      class User_model extends CI_Model {
          public function get_users() {
              return $this->db->get('users')->result_array();
          }
      }
      ```
    - **Controller**: `application/controllers/User.php`
      ```php
      class User extends CI_Controller {
          public function index() {
              $this->load->model('User_model');
              $data['users'] = $this->User_model->get_users();
              $this->load->view('user_view', $data);
          }
      }
      ```
    - **View**: `application/views/user_view.php`
      ```php
      <?php foreach($users as $user): ?>
          <p><?php echo $user['name']; ?></p>
      <?php endforeach; ?>
      ```

### Mixing Web Forms and MVC

40. **Can You Create a Web Application with Both WebForms and MVC?**
    - Yes, you can create a hybrid application that includes both WebForms and MVC. Use routing to separate the requests meant for WebForms from those meant for MVC.

41. **How Can You Assign an Alias Name for ASP.NET Web API Action?**
    - Use the `ActionName` attribute:
      ```csharp
      [ActionName("GetById")]
      public IHttpActionResult Get(int id) {
          // Action method logic
      }
      ```

### Differences and Use Cases

42. **What is the Main Difference Between MVC and WebAPI?**
    - **MVC**: Designed for creating web applications with views and HTML.
    - **WebAPI**: Designed for building RESTful services that return data (like JSON or XML).

43. **How Can You Ensure that Web API Returns JSON Data Only?**
    - Configure the `GlobalConfiguration` to remove the XML formatter:
      ```csharp
      config.Formatters.Remove(config.Formatters.XmlFormatter);
      ```

### MVVM and AngularJS

44. **What is the Difference Between MVVM and MVC?**
    - **MVVM (Model-View-ViewModel)**: Designed for two-way data binding between the view and viewmodel, making it suitable for data-driven UIs.
    - **MVC**: Focuses on a clear separation between UI, business logic, and data, suitable for structured applications.

45. **What is MVC in AngularJS?**
    - In AngularJS, MVC refers to the way Angular handles data binding (Model), templates (View), and controller (Controller) components.

46. **What is the Role of MVC in AngularJS?**
    - AngularJS utilizes a form of MVC for structuring client-side applications. The model represents the data, the view is the HTML template, and the controller manages the logic and data flow.

47. **How to Build a Basic Controller in AngularJS?**
    - Define a module and a controller:
      ```javascript
      var app = angular.module('myApp', []);
      app.controller('myCtrl', function($scope) {
          $scope.message = 'Hello, World!';
      });
      ```

48. **What is the Use of ng-controller in External Files in AngularJS?**
    - `ng-controller` is used to bind a specific section of the HTML to a controller, allowing dynamic content manipulation using AngularJS.

49. **Write Code to Define Methods in AngularJS Controller.**
    ```javascript
    var app = angular.module('myApp', []);
    app.controller('myCtrl', function($scope) {
        $scope.greet = function(name) {
            return 'Hello, ' + name + '!';
        };
    });
    ```

50. **Write Code Using ng-model to Display Multi-Line Input Control in AngularJS.**
    ```html
    <textarea ng-model="userInput"></textarea>
    <p>{{ userInput }}</p>
    ```

51. **Write Code to Demonstrate the Use of Input Elements.**
    ```html
    <input type="text" ng-model="userName" placeholder="Enter your name">
    <p>Hello, {{ userName }}</p>
    ```