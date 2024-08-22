---
title: "ViewBag, ViewData, TempData ?"
author: "PrashantUnity"
weight: 210
date: 2024-08-03
lastmod: 2024-10-22
dateString: August 2024  
description: "Data Flow In Asp Net Core MVC via ViewBag ViewData TempData and From"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "NET", "codefrydev", "C sharp", "CFD", "DataFlow","Interview"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD","Interview"]
---

## How Do we pass data from view to Controller

- Using Form Like POST Method

- ViewBag.Number and (int)ViewData["Number"] from controller to View

- Controller to Controller TempData

```csharp
public ActionResult SubmitForm(MyModel model)
{
    if (ModelState.IsValid)
    {
        // Process the form data
        
        // Store a success message in TempData
        TempData["Message"] = "Form submitted successfully!";
        
        // Redirect to another action
        return RedirectToAction("Confirmation");
    }
    
    return View(model);
}

public ActionResult Confirmation()
{
    // Retrieve the message from TempData
    ViewBag.Message = TempData["Message"];
    return View();
}
```

### 1. **Using `ViewData`**

`ViewData` is a dictionary-based way to pass data to the view. It uses the `ViewDataDictionary` class and is accessed by string keys.

**Example:**

**Controller:**

```csharp
public class HomeController : Controller
{
    public ActionResult Index()
    {
        // Use ViewData to pass data to the view
        ViewData["Message"] = "Hello from ViewData!";
        ViewData["Date"] = DateTime.Now;
        return View();
    }
}
```

**View (Index.cshtml):**

```html
@{
    ViewBag.Title = "Index";
}

<h2>@ViewData["Message"]</h2>
<p>Date: @ViewData["Date"]</p>
```

### 2. **Using `ViewBag`**

`ViewBag` is a dynamic wrapper around `ViewData`. It allows you to set and retrieve data using dynamic properties. `ViewBag` uses the `dynamic` keyword, which provides a more flexible and convenient way to pass data.

**Example:**

**Controller:**

```csharp
public class HomeController : Controller
{
    public ActionResult Index()
    {
        // Use ViewBag to pass data to the view
        ViewBag.Message = "Hello from ViewBag!";
        ViewBag.Date = DateTime.Now;
        return View();
    }
}
```

**View (Index.cshtml):**

```html
@{
    ViewBag.Title = "Index";
}

<h2>@ViewBag.Message</h2>
<p>Date: @ViewBag.Date</p>
```

### Key Differences

- **Type:** `ViewData` is a dictionary (`ViewDataDictionary`) and requires type casting when retrieving data. `ViewBag` is a dynamic object, which provides a more straightforward syntax.
  
  **Using ViewData:**

  ```csharp
  string message = (string)ViewData["Message"];
  DateTime date = (DateTime)ViewData["Date"];
  ```

  **Using ViewBag:**

  ```csharp
  string message = ViewBag.Message;
  DateTime date = ViewBag.Date;
  ```

- **Performance:** `ViewBag` can be slightly less performant than `ViewData` because `ViewBag` relies on the dynamic type and runtime binding, whereas `ViewData` uses a strongly typed dictionary.

- **Functionality:** Both `ViewData` and `ViewBag` are used for similar purposes, but `ViewBag` offers a more concise syntax due to its dynamic nature.
