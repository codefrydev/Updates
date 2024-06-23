---
title: "String in C# | Chapter 5"
author: ["PrashantUnity"]
weight: 105
dateString: June 2024  
description: "A string is an object of type String whose value is text. Internally, the text is stored as a sequential read-only collection of Char objects."
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  #display caption under cover 

tags: [ "NET","C Sharp","Chapter 5","string"]
keywords: [ "Code Fry Dev", "codefrydev", "CFD","NET","C Sharp","Chapter 5","string","string methods"]
draft: false #make this false to publicly Available
---

## C# String & string Manipulation

### String Basics

In C#, a string is a sequence of characters stored as a single data type. Strings are immutable, meaning any operation that appears to modify a string actually creates a new string. **string** and **String** both can be used to represent string bath are same **string** preffered.

### String Concatenation

Concatenation is the process of combining two or more strings into one. You can use the `+` operator to concatenate strings.

```csharp
string name = "CFD";
int age = 0;
string message = "My name is " + name + " and I am " + age + " years old.";
Console.WriteLine(message); // Outputs: My name is CFD and I am 0 years old.
```

### String Interpolation

String interpolation is a more readable way to format strings, introduced in C# 6.0. It allows you to embed expressions inside string literals using the `$` sign.

```csharp
string name = "CFD";
int age = 0;
string message = $"My name is {name} and I am {age} years old.";
Console.WriteLine(message); // Outputs: My name is CFD and I am 30 years old.
```

### Verbatim String

A verbatim string literal is prefixed with `@` and allows you to include escape sequences like `\` as literal characters. It's useful for file paths and multiline strings.

```csharp
string path = @"C:\MyFolder\MyFile.txt";
Console.WriteLine(path); // Outputs: C:\MyFolder\MyFile.txt

string multiline = @"This is a
                   multiline
                   string.";
Console.WriteLine(multiline);
// Outputs:
// This is a
//                    multiline
//                    string.
```

### String Literal

A string literal is prefixed with """ and allows you to write string in mutilple line. It's useful for multiline strings and complex string interpolation.

- starts with tripple quote then new line and the seperate """ ends

```csharp
string multiline = """
This is a
                   multiline
                   string.
""";
Console.WriteLine(multiline); 
```
![stringLiteral](./string.png)

- When we want to interpolate some we can do so by prefixing by $ sign and then we can use {} for injection.

```csharp
var name = "CFD";
string multiline = $"""
This is a
                   multiline
                   string.
                   {name}
""";
Console.WriteLine(multiline); 
```
![stringLiteral](./single.png)

- There may be case when we have to both {} and interpolation the we can do so by prefixing by n number of $ sign and for interpolation we use same number of {} inside string.

```csharp
var name = "CFD";
string multiline = $$"""
This is a
                   multiline
                   string.
                   {ignored}
                   {{name}}
                   {{{name}}}
""";
Console.WriteLine(multiline); 
```
![stringLiteral](./multiple.png)

### Common String Methods

#### Replace

Replaces all occurrences of a specified string or character in the original string with another string or character.

```csharp
string a = "String";
string b = a.Replace("i", "o");
Console.WriteLine(b); // Outputs: Strong
```

#### Insert

Inserts a specified string at a specified index position in the original string.

```csharp
string a = "String";
string b = a.Insert(0, "My ");
Console.WriteLine(b); // Outputs: My String
```

#### Remove

Removes a specified number of characters from a specified index position in the original string.

```csharp
string a = "String";
string b = a.Remove(0, 3);
Console.WriteLine(b); // Outputs: ing
```

#### Substring

Retrieves a substring from the original string. The substring starts at a specified index position and has a specified length.

```csharp
string a = "String";
string b = a.Substring(0, 3);
Console.WriteLine(b); // Outputs: Str
```

#### ToUpper

Converts the string to uppercase.

```csharp
string a = "String";
string b = a.ToUpper();
Console.WriteLine(b); // Outputs: STRING
```

#### Length

Gets the number of characters in the string.

```csharp
string a = "String";
int i = a.Length;
Console.WriteLine(i); // Outputs: 6
```

### Additional Resources

For more detailed information on strings and their manipulation in C#, visit the [Official Documentation](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/).

### [Previous Chapter]({{< relref "/blog/csharp/basic.md" >}}) mathematics

### [Next Chapter]({{< relref "/blog/csharp/ifelse.md" >}}) If Else