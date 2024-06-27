---
title: "Class in C# | Chapter 11"
author: ["PrashantUnity"]
weight: 111
date: 2024-06-24T00:00:00-07:00
lastmod: 2024-06-27T23:59:59-07:00
dateString: June 2024  
description: "Understanding Classes in Programming: Foundations of Object-Oriented Design"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  #display caption under cover 

tags: [ "NET","C Sharp", "Chapter 11","Class","oops"]
keywords: [ "Code Fry Dev", "codefrydev", "CFD","NET","C Sharp","Chapter 11","class","oops"]
draft: false #make this false to publicly Available
---

## Class

A class represents a blueprint of an object.

- Currently, we know some basic data types:
  - For representing numbers, we use types like `int`, `long`, `byte`, `decimal`, etc.
  - For representing words, we use `string` or arrays of characters (`char[]`).
  - For storing collections of numbers, we use arrays (`int[]`, `float[]`, etc.).

However, what about storing complex objects like **Person**, **Planet**, etc.?

- For example, a **Person** object might have properties like `Name` (a string), `Age` (an integer), and methods like `IsCoding()`.

{{< mermaid >}}
    classDiagram
        class Person{
            +Name
            +Age
            +IsCoding()
        } 
{{< /mermaid >}}

From the diagram above, we see that a class named `Person` encapsulates a contextual representation driven by developers. It defines properties and behaviors specific to a person, allowing us to model and work with such complex entities in code.

### Requirement

To proceed with this, you'll need Visual Studio Community Edition for easier coding with auto-suggestion. Let's create a brand new console project in Visual Studio.

### Understanding Class Syntax in C#

In C#, we represent a **Person** using the `class` keyword, encapsulating related properties and methods inside the class body. Below is a basic representation of a **Person** in terms of a class:

```csharp
public class Person
{
    public string Name;
    public string From = "Earth";
    public int Age;

    public void IsWalking()
    {
        // Method body will be added later
    }
}
```

Now, let me explain each line step by step:

- **public**: This keyword in C# determines the accessibility level of something (class, field, or method). Here, it allows the `Person` class, `Name` field, `From` field, and `IsWalking` method to be accessible from other classes.
- We'll delve deeper into programming concepts as you gain more confidence, or you'll learn about them automatically as we progress.

### Now we know that what class is and how to represent real thing in form of class

## Question Now is How to use this class ?

In C#, we create an **instance** or **object** of a class and then utilize it. Let's clarify what these terms mean:

- **Instance/Object**: Imagine you're an artist.
  - Your task is to download the image below:
  
  ![Unfilled Class](./class.jpg)
  
  - Once downloaded, your next task is to fill the CFD (Codefrydev 😁) with any color your artistic mind suggests.
  
  - Here's how my programmer mind sees it:
  
  ![Filled Class](./classfilled.jpg)
  
- Downloading the image is akin to creating an instance or object.
- You can then manipulate the downloaded image as you wish, which won't affect the version available on the website.
- Filling the color is like assigning different values to the fields or properties of an instance in programming.

### Create Instance Syntax

- To create an instance of the `Person` class in C#, follow the syntax:

```csharp
Person myself = new Person();
```

Here, `myself` is an instance of the `Person` class, possessing all the characteristics defined within the class by default.

### Visual Representation

![Default Person Object](./1.png)

- The `Name` field is `null` because it hasn't been assigned a value in the class definition.
- The `From` field has the value `"Earth"` because it is initialized to this value in the class.

#### Now we know the syntax of how to create instance of class

### Question now comes in mind that how do we modify ?

If you type `myself.` and use IntelliSense in Visual Studio, you will see options related to the fields and methods defined in the `Person` class. Here's how you can modify the code to assign values to the object's fields:

```csharp
myself.Age = 0;
myself.From = "CodefryDev Website";
myself.Name = "CodefryDev User";
```

- you will have object with modified value as per above code.

![assigning value](./3.png)

- you can view in Visual Studio by using below code and pressing 5 key

```csharp
Console.WriteLine("From {0}",myself.From);
Console.WriteLine("Name {0}", myself.Name);
Console.WriteLine("Age {0}", myself.Age);
```

- it  will output somting like this

![assigning value](./4.png)

- using Terminal Command

```yaml
dotnet run --property WarningLevel=0
```

![assigning value](./5.png)

### Modification in class

changes in the class method IsWalking

```csharp
public class Person
{
    public string Name;
    public string From ="Earth";
    public int Age;

    public void IsWalking()
    {
        Console.WriteLine("No I Learing on CFD");
    }
} 
```

- Calling a method in C# involves using the instance name followed by a period (`.`), the method name, opening and closing parentheses `()`, and ending with a semicolon `;`. This syntax executes the behavior defined within the method.

You can call this method on an instance of the `Person` class like this:

```csharp
myself.IsWalking();
```

- Source code Upto this point
- you can use new c# syntax **Person myself = new();**  instead of **Person myself = new Person();**

```csharp
// creating instance of object
Person myself = new Person(); 

// assigning value
myself.Age = 0;
myself.From = "CodefryDev Website";
myself.Name = "CodefryDev User";
// printing to console
Console.WriteLine("From {0}",myself.From);
Console.WriteLine("Name {0}", myself.Name);
Console.WriteLine("Age {0}", myself.Age);
myself.IsWalking();
```

- now Run the application an you will have following.

![assigning value](./6.png)

### Another Object

- Create another instance of the class `Person` and observe its default values.
- Guess if the value will be the same as `myself` or something else.
- Let's solve this mystery by creating another instance of the class.

```csharp
Person friend = new Person();
```

![Assigning value](./7.png)

- Surprisingly, its value is not the same as `myself`. Wait, what? Why?
- Okay, let me explain using the analogy of downloading an image.
- If creating an instance is like downloading the image again,
- Obviously, no matter how many times you modify or paint it with different colors, it's still the same downloaded image.
- A similar concept applies to modifying object instances as well.

- Now, modify the object value of `friend` with a different value and see what happens. 

```csharp
friend.Age = 1;
friend.From = "Mars";
friend.Name = "Terminal";
```

- Now this data is held by a different object.

![Assigning value](./8.png)

- Using the terminal:

![Assigning value](./9.png)

- Source code upto this point

```csharp
Person myself = new Person();
myself.Age = 0;
myself.From = "CodefryDev Website";
myself.Name = "CodefryDev User";


Person freind = new Person();
freind.Age = 1;
freind.From = "Mars";
freind.Name = "Terminal";

Console.WriteLine("Freind Object Holding value");
Console.WriteLine("From {0}", freind.From);
Console.WriteLine("Name {0}", freind.Name);
Console.WriteLine("Age {0}", freind.Age);

Console.WriteLine("myself Object Holding value");
Console.WriteLine("From {0}",myself.From);
Console.WriteLine("Name {0}", myself.Name);
Console.WriteLine("Age {0}", myself.Age);
```

### More about Object/Instance

Coming back to the analogy of downloading an image on your PC:

- Whenever you download an image, it will be stored somewhere on your PC.
- Each image will have a unique name in its specific folder.
- This means no two images can have the same name in the same folder.
- Each image will take up some space.
- Each downloaded image will have separate properties from other images.
- See the image below for demonstration:

![assigning value](./10.png)

- another image

![assigning value](./11.png)

- Similar to this, each instance of a class will:
  - Have a separate location in memory where it is stored.
  - Occupy a specific amount of space on your PC.
  - Cannot have the same name as another instance.
  - A folder is analogous to a namespace in C#.

For more information about classes, please refer to the [Official documentation](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/classes).

### [Previous Chapter]({{< relref "/blog/csharp/lineardata.md" >}}) Linear Data

### [Next Chapter]({{< relref "/blog/csharp/linkedlist.md" >}}) Linked List
