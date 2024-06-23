---
title: "Loop In C# | Chapter 7"
author: ["PrashantUnity"]
weight: 107
dateString: June 2024  
description: "Loops are used to execute a block of code repeatedly based on a condition. C# provides several looping constructs: `for`, `while`, `do-while`, and `foreach`. Each serves different use cases and provides flexibility in iteration."
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  #display caption under cover 

tags: [ "NET","C Sharp", "Chapter 7","Loops"]
keywords: [ "Code Fry Dev", "codefrydev", "CFD","NET","C Sharp","Chapter 7","Loops"]
draft: false #make this false to publicly Available
---

## C# Looping 

### For Loop

The `for` loop is used when you know in advance how many times you want to execute a statement or a block of statements.

#### Example: For Loop

```csharp
for (int i = 0; i < 5; i++)
{
    Console.WriteLine(i);
}
```

#### Explanation

1. **Initialization**: `int i = 0` sets the starting point of the loop.
2. **Condition**: `i < 5` determines how long the loop will run.
3. **Iteration**: `i++` updates the loop counter after each iteration.

#### Output

![for Loop](./for.png)

### While Loop

The `while` loop executes a block of code as long as a specified condition is true. It is useful when the number of iterations is not known in advance.

#### Example: While Loop

```csharp
int count = 0;
while (count < 5)
{
    Console.WriteLine(count);
    count++;
}
```

#### Explanation

1. **Condition**: `count < 5` is checked before each iteration.
2. **Body**: `Console.WriteLine(count)` and `count++` are executed as long as the condition is true.

#### Output

![While Loop](./while.png)

### Do-While Loop

The `do-while` loop is similar to the `while` loop, but it guarantees that the loop body is executed at least once.

#### Example: Do-While Loop

```csharp
int value = 0;
do
{
    Console.WriteLine(value);
    value++;
} while (value < 0);
```

#### Explanation

1. **Body**: `Console.WriteLine(value)` and `value++` are executed first.
2. **Condition**: `value < 0` is checked after the loop body is executed.

#### Output

![While Loop](./dowhile.png)

### Foreach Loop

The `foreach` loop iterates over a collection or array ( We will talk about array in next chapter). It is useful when you want to iterate over each element without worrying about the index.

#### Example: Foreach Loop

```csharp
int[] numbers = { 1, 2, 3, 4, 5 };
foreach (int number in numbers)
{
    Console.WriteLine(number);
}
```

#### Explanation

1. **Collection**: `int[] numbers = { 1, 2, 3, 4, 5 }` is the array to iterate over.
2. **Body**: `Console.WriteLine(number)` is executed for each element in the array.

#### Output

![While Loop](./foreach.png)

### [Previous Chapter]({{< relref "/blog/csharp/ifelse.md" >}}) If Else

### [Next Chapter]({{< relref "/blog/csharp/function.md" >}}) function