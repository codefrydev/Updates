---
title: "If Else in C# | Chapter 6"
author: ["PrashantUnity"]
weight: 106
dateString: June 2024  
description: "Conditional statements allow you to make decisions in your code based on certain conditions. The most commonly used conditional statements in C# are **if**, **else if**, and **else**."
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  #display caption under cover 

tags: [ "NET","C Sharp","Chapter 6","ifelse"]
keywords: [ "Code Fry Dev", "codefrydev", "CFD","NET","C Sharp","Chapter 6","ifelse","ifelse"]
draft: false #make this false to publicly Available
---
 
## C# Conditional Statements and Control Flow
 
### Example: If-Else Statement

Here is an example that demonstrates the use of `if`, `else if`, and `else` statements to check the value of a variable and print corresponding messages.

```csharp
int number = 10;

if (number > 10)
{
    Console.WriteLine("The number is greater than 10");
}
else if (number == 10)
{
    Console.WriteLine("The number is equal to 10");
}
else
{
    Console.WriteLine("The number is less than 10");
}
```

### Explanation

1. **If Statement**
    - The `if` statement checks if the condition inside the parentheses is true. 
    - If `number > 10` is true, it executes the code block inside the `if` statement.

    ```csharp
    if (number > 10)
    {
        Console.WriteLine("The number is greater than 10");
    }
    ```

2. **Else If Statement**
    - The `else if` statement provides an additional condition to check if the initial `if` condition is false.
    - If `number == 10` is true, it executes the code block inside the `else if` statement.

    ```csharp
    else if (number == 10)
    {
        Console.WriteLine("The number is equal to 10");
    }
    ```

3. **Else Statement**
    - The `else` statement is executed if none of the preceding `if` or `else if` conditions are true.
    - It provides a fallback action.

    ```csharp
    else
    {
        Console.WriteLine("The number is less than 10");
    }
    ```

### Output

Given `number = 10`, the output will be:
```plaintext
The number is equal to 10
```

### Additional Notes

- **Multiple Conditions:** You can have multiple `else if` conditions to handle more complex scenarios.
- **Logical Operators:** You can use logical operators like `&&` (AND), `||` (OR), and `!` (NOT) to combine multiple conditions in a single `if` statement.

### Example with Logical Operators

```csharp
int number = 10;

if (number > 10)
{
    Console.WriteLine("The number is greater than 10");
}
else if (number == 10)
{
    Console.WriteLine("The number is equal to 10");
}
else if (number < 10 && number > 5)
{
    Console.WriteLine("The number is less than 10 but greater than 5");
}
else
{
    Console.WriteLine("The number is 5 or less");
}
``` 

### Switch Statement

The `switch` statement is another way to control the flow of your program based on the value of a variable. It is often used when you have multiple specific values to compare.

#### Example: Switch Statement

```csharp
int number = 10;

switch (number)
{
    case > 10:
        Console.WriteLine("The number is greater than 10");
        break;
    case 10:
        Console.WriteLine("The number is equal to 10");
        break;
    default:
        Console.WriteLine("The number is less than 10");
        break;
}
```

#### Explanation

1. **Case Statements**
    - Each `case` statement compares the value of `number` to a specific value.
    - If `number` matches the value, the corresponding code block is executed.

    ```csharp
    case 10:
        Console.WriteLine("The number is equal to 10");
        break;
    ```

2. **Default Statement**
    - The `default` statement is executed if none of the `case` conditions match.
    - It serves as a fallback.

    ```csharp
    default:
        Console.WriteLine("The number is less than 10");
        break;
    ```

3. **Break Statement**
    - The `break` statement exits the switch block, preventing the execution of subsequent cases.

    ```csharp
    break;
    ```

#### Output

Given `number = 10`, the output will be:
```plaintext
The number is equal to 10
``` 

### [Previous Chapter]({{< relref "/blog/csharp/string.md" >}}) String

### [Next Chapter]({{< relref "/blog/csharp/loop.md" >}}) Loop
