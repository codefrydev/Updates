---
title: "Getting Started with Basic C# Concepts | Chapter 3"
author: ["PrashantUnity"]
weight: 103
date: 2024-06-16T00:00:00-07:00
lastmod: 2024-06-16T23:59:59-07:00
dateString: June 2024  
description: "Welcome to this introductory post on fundamental C# programming concepts. Understanding the basics is crucial. This post covers how to use comments, declare variables, understand data types, and handle user input and output."
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  #display caption under cover 

tags: [ "NET","C Sharp", "Input","output","Chapter 3","Comment","variable"]
keywords: [ "Code Fry Dev", "codefrydev", "CFD","NET","C Sharp", "Input","output","Chapter 3","Comment","variable"]
draft: false #make this false to publicly Available
---


## Comments in C#

Comments are essential for making your code understandable. They can explain what your code does, which is helpful for anyone reading it (including yourself).

- **Inline Comments**: Use `//` for single-line comments.

    ```csharp
    // This is an inline comment.
    ```

- **Multi-line Comments**: Use `/* */` for comments that span multiple lines.

    ```csharp
    /*
    This is a multi-line comment.
    It spans multiple lines.
    */
    ```

## Semicolons

In C#, every statement ends with a semicolon (`;`). This tells the compiler where a statement ends.

- Example:

    ```csharp
    Console.WriteLine("Hello World");
    ```

## Writing to the Console

Printing messages to the console is straightforward with `Console.Write` and `Console.WriteLine`.

- **Console.WriteLine**: Prints the message followed by a newline.
- **Console.Write**: Prints the message without a newline.

    ```csharp
    Console.WriteLine("This prints with a newline.");
    Console.Write("This prints without a newline.");
    ```

## Taking Input from the User

To take input from the user, use `Console.ReadLine`. By default, this method reads input as a string.

```csharp
Console.WriteLine("Enter your name: ");
string name = Console.ReadLine();
Console.WriteLine(name);
```

## Data Types in C#

Data types specify the kind of data a variable can hold. Understanding data types is key to using variables effectively.

- **Value Types**: Store actual values. Common value types include:
  - `int`, `float`, `double`, `bool`, `char`, `byte`, `short`, `long`, `decimal`

- **Reference Types**: Store references to the actual data. Common reference types include:
  - `string`, arrays (`type[]`)

## Declaring Variables

Variables are containers for storing data values. To declare a variable, you need to specify its type and assign it a value.

- Syntax: `type variableName = value;`

    ```csharp
    string name = "CodeFryDev";
    Console.WriteLine(name);
    ```

## Common Data Types and Their Usage

Here are some common data types in C# and their typical usage:

- `int`: Integer values

    ```csharp
    int myInteger = 10;
    ```

- `float`: Single-precision floating-point numbers

    ```csharp
    float myFloat = 3.14f;
    ```

- `double`: Double-precision floating-point numbers

    ```csharp
    double myDouble = 3.14159;
    ```

- `bool`: Boolean values (`true` or `false`)

    ```csharp
    bool isTrue = true;
    ```

- `char`: Single character

    ```csharp
    char myChar = 'A';
    ```

- `byte`: Unsigned integers (0 to 255)

    ```csharp
    byte myByte = 255;
    ```

- `short`: Small integers

    ```csharp
    short myShort = 1000;
    ```

- `long`: Large integers

    ```csharp
    long myLong = 1000000000;
    ```

- `decimal`: Precise decimal numbers, often used in financial calculations

    ```csharp
    decimal myDecimal = 123.456m;
    ```

## Example: Classifying Data Types

Let's see how different types of data can be classified and stored in variables:

- **User Age**: Age is a number, so we can use an integer type.

    ```csharp
    int userAge = 24;
    ```

- **User Name**: Names are text, so we use a string type.

    ```csharp
    string userName = "CodeFryDev";
    ```

- **User Favourite Games**: A list of favorite games can be stored in an array of strings.

    ```csharp
    string[] favoriteGames = { "Chain Reaction", "Snake", "Chess", "Tomb Raider" };
    ```

Understanding comments, semicolons, console I/O, and data types will give you a solid foundation to build upon. Happy coding!
