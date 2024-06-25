---
title: "Function In C# | Chapter 8"
author: ["PrashantUnity"]
weight: 108
date: 2024-06-20T00:00:00-07:00
lastmod: 2024-06-20T23:59:59-07:00
dateString: June 2024  
description: "Function : It Is Series of statement contained inside code block which execute top down manner when called.It can also be call by name Method"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  #display caption under cover 

tags: [ "NET","C Sharp", "Chapter 8","Function"]
keywords: [ "Code Fry Dev", "codefrydev", "CFD","NET","C Sharp","Chapter 8","Function"]
draft: false #make this false to publicly Available
---
## C# Method/function Concepts and Advanced Features
- Why
    - Suppose we want to calculate sum of two number say a, b we can implement by direct implementation like a + b.
        ```csharp
        var a = 7;
        var b = 50;
        var c = a+b;
        ```
    - Now Take The Cases
        - number should be positive
        - Maxium value of number cant be greater than 100
        - Sum of Both number should be less than 100 and greater than 30
        - ans aso on.
        ```csharp
        var a = 7;
        var b = 50;
        if (a>0 && b>0)
        {
            if(Math.Max(a,b)<100)
            {
                var c = a+b;
                if(c<100 && c>=30)
                {
                    Console.WriteLine($"Sum Of Number is {c}");
                }
                else
                {
                    Console.WriteLine("Sum of Both number should be less than 100 and greater than 30");
                }
            }
            else
            {
                Console.WriteLine("Number Should Be less Than 100");
            }
        }
        else
        {
            Console.WriteLine("Number Should Be Positive");
        }
        ```
    - Imagine this validation is require in more than one place then our code will be Explode Exponentially
    - It Will be Hard TO Main tain Also
    - To Solve this Issue We Use Function. Like this for Above example

        ```csharp
        public string Sum(int a, int b)
        {
            if (a>0 && b>0)
            {
                if(Math.Max(a,b)<100)
                {
                    var c = a+b;
                    if(c<100 && c>=30)
                    {
                       return $"Sum Of Number is {c}";
                    }
                    else
                    {
                         return "Sum of Both number should be less than 100 and greater than 30";
                    }
                }
                else
                {
                     return  "Number Should Be less Than 100";
                }
            }
            else
            {
                 return "Number Should Be Positive";
            }
        } 
        ```
    - More Detailed Explanation Below With Different Cases And Example

### Return Type

A method can return a value. The return type of the method must be specified. it dosen't return any value than void is used

#### Example: Return Type

```csharp
int Add(int a, int b)
{
    return a + b;
}
```

```csharp
void Add(int a, int b)
{
    Console.WriteLine( a + b);
}
```

### Parameters

Methods can take parameters to perform operations with input values.

#### Example: Parameters

```csharp
void Greet(string name)
{
    Console.WriteLine("Hello, " + name);
}
```

### Default Parameters

Methods can have default parameters, which are used if no arguments are provided when the method is called.

#### Example: Default Parameters

```csharp
void GreetWithDefault(string name = "Guest")
{
    Console.WriteLine("Hello, " + name);
}
```

### Method Overloading

Method overloading allows multiple methods with the same name but different parameters.

#### Example: Method Overloading

```csharp
int Add(int a, int b)
{
    return a + b;
}

double Add(double a, double b)
{
    return a + b;
}
```

### Optional Parameters

Optional parameters have default values and can be omitted when the method is called.

#### Example: Optional Parameters

```csharp
void PrintName(string firstName, string lastName = "")
{
    Console.WriteLine(firstName + " " + lastName);
}
```

## More Adavanced

### Ref and Out Parameters

The `ref` and `out` keywords allow passing parameters by reference or returning multiple values.

#### Example: Ref and Out Parameters

```csharp
void Modify(ref int number)
{
    number += 10; // Modify the original value
}

void Retrieve(out int number)
{
    number = 42; // Assign a value to the out parameter
}
```

### Lambda Expressions

Lambda expressions provide a concise way to define anonymous methods using the `=>` syntax.

#### Example: Lambda Expressions

```csharp
Func<int, int, int> add = (a, b) => a + b;
```

### Delegate Methods

Delegates are types that represent references to methods. They are used to pass methods as arguments to other methods.

#### Example: Delegate Methods

```csharp
delegate int MathOperation(int a, int b);
MathOperation add = (a, b) => a + b;
```

### Async Methods

Asynchronous methods allow operations to run asynchronously, improving performance for I/O-bound operations.

#### Example: Async Methods

```csharp
async Task<int> GetDataAsync()
{
    // Asynchronous operations
    return await SomeAsyncOperation();
}
```

### Extension Methods

Extension methods allow you to add new methods to existing types without modifying the original type.

#### Example: Extension Methods

```csharp
public static class StringExtensions
{
    public static bool IsNullOrEmpty(this string str)
    {
        return string.IsNullOrEmpty(str);
    }
}
```

### [Previous Chapter]({{< relref "/blog/csharp/loop.md" >}}) Loop

### [Next Chapter]({{< relref "/blog/csharp/lineardata.md" >}}) Linear Data
