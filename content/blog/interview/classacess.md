---
title: "Class Access Level"
author: "PrashantUnity"
weight: 210
date: 2024-08-03
lastmod: 2024-10-22
dateString: August 2024  
description: "In C#, the accessibility level of a class determines how and where the class can be accessed from other parts of your code."
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "NET", "codefrydev", "C sharp", "CFD"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD"]
---


# Class Accessibility Matrix Diagram

![Accessibility](./acess.png)


## What is Default accessibility of class

- Internal

## Difference between Internal and Protected Internal

- Look above image for clarification

### 1. **Public**

- **Accessibility:** The class is accessible from any other class or assembly.
- **Usage:** When you want the class to be widely accessible.

```csharp
// Public class can be accessed from anywhere
public class PublicClass
{
    public string Name { get; set; }
}
```

### 2. **Internal**

- **Accessibility:** The class is accessible only within the same assembly (project).
- **Usage:** When you want to limit access to within the assembly, which is useful for encapsulation.

```csharp
// Internal class can only be accessed within the same assembly
internal class InternalClass
{
    public string Name { get; set; }
}
```

### 3. **Protected**

- **Accessibility:** The class itself cannot be protected, but its members can be. A class can be derived from a base class with protected members.
- **Usage:** When you want to allow access to members only in derived classes.

```csharp
public class BaseClass
{
    protected string Name { get; set; }
}

public class DerivedClass : BaseClass
{
    public void PrintName()
    {
        // Accessing protected member from the base class
        Console.WriteLine(Name);
    }
}
```

### 4. **Private**

- **Accessibility:** A class itself cannot be private, but its members can be. Private members are only accessible within the same class.
- **Usage:** When you want to restrict access to the class members to only within the class itself.

```csharp
public class MyClass
{
    private string Name { get; set; }

    public void SetName(string name)
    {
        Name = name;
    }
    
    public string GetName()
    {
        return Name;
    }
}
```

### 5. **Protected Internal**

- **Accessibility:** The class or member is accessible within the same assembly and also to derived classes in other assemblies.
- **Usage:** Useful for situations where you want to expose class members to derived classes or within the assembly.

```csharp
public class MyClass
{
    protected internal string Name { get; set; }
}
```

### 6. **Private Protected**

- **Accessibility:** The class or member is accessible within the same class or in derived classes that are in the same assembly.
- **Usage:** A more restrictive version of `protected internal`, useful for fine-grained access control.

```csharp
public class MyClass
{
    private protected string Name { get; set; }
}
```