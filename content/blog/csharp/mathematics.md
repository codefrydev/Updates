---
title: "Mathematical Operations in C# | Chapter 4"
author: ["PrashantUnity"]
weight: 104
date: 2024-06-18T00:00:00-07:00
lastmod: 2024-06-18T23:59:59-07:00
dateString: June 2024  
description: "Learn about mathematical operations, type conversions, and arithmetic operators in C# with practical examples and best practices"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  #display caption under cover 

tags: [ "NET","C Sharp","Chapter 4","Mathematics"]
keywords: [ "Code Fry Dev", "codefrydev", "CFD","NET","C Sharp","Chapter 4","Mathematics","operation"]
draft: false #make this false to publicly Available
---
  
## C# Basic Operations and Type Conversions

### Basic Operations

In C#, you can perform various arithmetic operations using standard operators. Here are some examples:

```csharp
int additionResult = 10 + 5;     // result will be 15
int subtractionResult = 20 - 8;  // result will be 12
int multiplicationResult = 7 * 4; // result will be 28
int divisionResult = 15 / 3;     // result will be 5
int remainder = 17 % 5;          // remainder will be 2
float floatDivisionResult = 15f / 4f; // result will be 3.75
```

### Understanding Assignment in Programming

In general mathematics, equality signifies that the expression on the left side of the `=` is equivalent to the expression on the right side:
```plaintext
3 + 2 = 5
```
However, in programming, the `=` sign is an assignment operator. The expression on the right side is evaluated and assigned to the variable on the left side:
```csharp
int result = 3 + 2; // result will be assigned the value 5
```

### Data Types and Static Typing

C# is a statically typed language, meaning you must declare the data type of a variable before assigning a value to it, and the value must match the declared data type:
```csharp
int num = 0;
string name = "CFD";

// This will give a compile-time error because 'num' is an int and 'name' is a string
num = name;

// This is valid because we convert the int to a string
name = num.ToString();
```

### Handling Console Input

By default, any input taken from the console is a string. You can convert this input to the appropriate data type using various methods:

```csharp
int k = 56;
var convertedToString = k.ToString();
Console.WriteLine(convertedToString.GetType()); // Outputs: System.String
Console.WriteLine(convertedToString);

var toNumber = Convert.ToInt32(convertedToString);
Console.WriteLine(toNumber.GetType()); // Outputs: System.Int32
Console.WriteLine(toNumber);

var intParse = int.Parse(convertedToString);
Console.WriteLine(intParse.GetType()); // Outputs: System.Int32
Console.WriteLine(intParse);

var intTryParse = int.TryParse(convertedToString, out int result);
Console.WriteLine(intTryParse); // Outputs: True
Console.WriteLine(result.GetType()); // Outputs: System.Int32
Console.WriteLine(result);
```

![Type](./type.png)

### Type Casting

Type casting allows you to convert a variable from one data type to another:
```csharp
int num = 65;
Console.WriteLine(num); 
Console.WriteLine(num.GetType()); // Outputs: System.Int32

long longNum = (long)num;
Console.WriteLine(longNum); 
Console.WriteLine(longNum.GetType()); // Outputs: System.Int64
```

![Type](./casting.png)

### Useful Conversion Methods

- `int.Parse()`
- `Convert.ToInt32()`
- `int.TryParse()`

### Additional Resources

For more detailed information on type conversions and casting, visit the [Official Documentation](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/types/casting-and-type-conversions).

### [Previous Chapter]({{< relref "/blog/csharp/basic.md" >}}) Basic

### [Next Chapter]({{< relref "/blog/csharp/string.md" >}}) String