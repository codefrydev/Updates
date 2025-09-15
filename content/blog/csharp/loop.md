---
title: "Loops in C# | Chapter 7"
author: ["PrashantUnity"]
weight: 107
date: 2024-06-19T00:00:00-07:00
lastmod: 2024-06-19T23:59:59-07:00
dateString: June 2024  
description: "Comprehensive guide to C# looping constructs including for, while, do-while, and foreach loops with practical examples and use cases"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  #display caption under cover 

tags: [ "NET","C Sharp", "Chapter 7","Loops"]
keywords: [ "Code Fry Dev", "codefrydev", "CFD","NET","C Sharp","Chapter 7","Loops"]
draft: false #make this false to publicly Available
---

## Understanding Loops in C#

Loops are fundamental programming constructs that allow you to execute a block of code repeatedly. They're essential for:
- **Processing collections** of data
- **Repeating operations** until a condition is met
- **Automating repetitive tasks**
- **Iterating through arrays and lists**

Think of loops as a way to tell the computer: "Do this task over and over again until I tell you to stop."

## Types of Loops in C#

C# provides four main types of loops:
1. **for loop** - When you know the exact number of iterations
2. **while loop** - When you don't know the number of iterations in advance
3. **do-while loop** - When you need to execute at least once
4. **foreach loop** - For iterating through collections

## 1. For Loop

The `for` loop is perfect when you know exactly how many times you want to repeat an action.

### Basic Syntax
```csharp
for (initialization; condition; iteration)
{
    // code to be executed
}
```

### How It Works
1. **Initialization**: Sets up the loop variable (runs once)
2. **Condition**: Checks if the loop should continue (runs before each iteration)
3. **Iteration**: Updates the loop variable (runs after each iteration)

### Basic Example
```csharp
for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"Iteration {i + 1}: Hello World!");
}
```

**Output:**
```
Iteration 1: Hello World!
Iteration 2: Hello World!
Iteration 3: Hello World!
Iteration 4: Hello World!
Iteration 5: Hello World!
```

### Practical Examples

#### Example 1: Countdown Timer
```csharp
Console.WriteLine("Starting countdown...");
for (int i = 10; i >= 1; i--)
{
    Console.WriteLine($"{i}...");
    Thread.Sleep(1000); // Wait 1 second
}
Console.WriteLine("Blast off! 🚀");
```

#### Example 2: Multiplication Table
```csharp
int number = 7;
Console.WriteLine($"Multiplication table for {number}:");
for (int i = 1; i <= 10; i++)
{
    int result = number * i;
    Console.WriteLine($"{number} × {i} = {result}");
}
```

#### Example 3: Sum of Numbers
```csharp
int sum = 0;
for (int i = 1; i <= 100; i++)
{
    sum += i;
}
Console.WriteLine($"Sum of numbers from 1 to 100: {sum}");
```

### Advanced For Loop Patterns

#### Pattern 1: Step by Different Amounts
```csharp
// Count by 2s
for (int i = 0; i <= 20; i += 2)
{
    Console.WriteLine(i); // 0, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20
}

// Count backwards by 3s
for (int i = 30; i >= 0; i -= 3)
{
    Console.WriteLine(i); // 30, 27, 24, 21, 18, 15, 12, 9, 6, 3, 0
}
```

#### Pattern 2: Multiple Variables
```csharp
for (int i = 0, j = 10; i < 5 && j > 5; i++, j--)
{
    Console.WriteLine($"i = {i}, j = {j}");
}
```

#### Pattern 3: Nested Loops
```csharp
// Create a simple pattern
for (int row = 1; row <= 5; row++)
{
    for (int col = 1; col <= row; col++)
    {
        Console.Write("*");
    }
    Console.WriteLine(); // Move to next line
}
```

**Output:**
```
*
**
***
****
*****
```

## 2. While Loop

The `while` loop repeats a block of code as long as a condition is true. It's perfect when you don't know how many times you need to repeat something.

### Basic Syntax
```csharp
while (condition)
{
    // code to be executed
}
```

### How It Works
1. **Check condition** - If true, execute the loop body
2. **Execute body** - Run the code inside the loop
3. **Check condition again** - Repeat until condition becomes false

### Basic Example
```csharp
int count = 0;
while (count < 5)
{
    Console.WriteLine($"Count: {count}");
    count++;
}
```

**Output:**
```
Count: 0
Count: 1
Count: 2
Count: 3
Count: 4
```

### Practical Examples

#### Example 1: User Input Validation
```csharp
string userInput;
do
{
    Console.Write("Enter 'yes' to continue: ");
    userInput = Console.ReadLine();
} while (userInput.ToLower() != "yes");

Console.WriteLine("Thank you! Continuing...");
```

#### Example 2: Number Guessing Game
```csharp
Random random = new Random();
int secretNumber = random.Next(1, 101);
int guess;
int attempts = 0;

Console.WriteLine("I'm thinking of a number between 1 and 100. Can you guess it?");

while (true)
{
    Console.Write("Enter your guess: ");
    if (int.TryParse(Console.ReadLine(), out guess))
    {
        attempts++;
        
        if (guess == secretNumber)
        {
            Console.WriteLine($"🎉 Congratulations! You guessed it in {attempts} attempts!");
            break;
        }
        else if (guess < secretNumber)
        {
            Console.WriteLine("Too low! Try again.");
        }
        else
        {
            Console.WriteLine("Too high! Try again.");
        }
    }
    else
    {
        Console.WriteLine("Please enter a valid number.");
    }
}
```

#### Example 3: Reading File Line by Line
```csharp
string filePath = "data.txt";
if (File.Exists(filePath))
{
    using (StreamReader reader = new StreamReader(filePath))
    {
        string line;
        int lineNumber = 1;
        
        while ((line = reader.ReadLine()) != null)
        {
            Console.WriteLine($"Line {lineNumber}: {line}");
            lineNumber++;
        }
    }
}
```

### Common While Loop Patterns

#### Pattern 1: Menu System
```csharp
bool continueRunning = true;
while (continueRunning)
{
    Console.WriteLine("\n=== Main Menu ===");
    Console.WriteLine("1. Option 1");
    Console.WriteLine("2. Option 2");
    Console.WriteLine("3. Exit");
    Console.Write("Choose an option: ");
    
    string choice = Console.ReadLine();
    
    switch (choice)
    {
        case "1":
            Console.WriteLine("You selected Option 1");
            break;
        case "2":
            Console.WriteLine("You selected Option 2");
            break;
        case "3":
            Console.WriteLine("Goodbye!");
            continueRunning = false;
            break;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}
```

#### Pattern 2: Data Processing
```csharp
List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
int index = 0;
int sum = 0;

while (index < numbers.Count)
{
    sum += numbers[index];
    Console.WriteLine($"Added {numbers[index]}, running sum: {sum}");
    index++;
}

Console.WriteLine($"Total sum: {sum}");
```

### Important Notes About While Loops

⚠️ **Watch out for infinite loops!** Always ensure your condition will eventually become false:

```csharp
// ❌ BAD - This will run forever!
int i = 0;
while (i < 10)
{
    Console.WriteLine(i);
    // Forgot to increment i!
}

// ✅ GOOD - This will eventually stop
int i = 0;
while (i < 10)
{
    Console.WriteLine(i);
    i++; // Increment the counter
}
```

## 3. Do-While Loop

The `do-while` loop is similar to the `while` loop, but it **guarantees that the loop body executes at least once**. The condition is checked after the first execution.

### Basic Syntax
```csharp
do
{
    // code to be executed
} while (condition);
```

### How It Works
1. **Execute body** - Run the code inside the loop (at least once)
2. **Check condition** - If true, repeat the loop
3. **Repeat** - Continue until condition becomes false

### Basic Example
```csharp
int value = 0;
do
{
    Console.WriteLine($"Value: {value}");
    value++;
} while (value < 5);
```

**Output:**
```
Value: 0
Value: 1
Value: 2
Value: 3
Value: 4
```

### Key Difference: Do-While vs While

```csharp
// While loop - might not execute at all
int count = 10;
while (count < 5)  // This condition is false from the start
{
    Console.WriteLine("This will never print");
    count++;
}

// Do-while loop - executes at least once
int count = 10;
do
{
    Console.WriteLine("This will print once: " + count);
    count++;
} while (count < 5);  // Even though condition is false, body runs once
```

**Output:**
```
This will print once: 10
```

### Practical Examples

#### Example 1: User Menu with Validation
```csharp
string userChoice;
do
{
    Console.WriteLine("\n=== Calculator Menu ===");
    Console.WriteLine("1. Add");
    Console.WriteLine("2. Subtract");
    Console.WriteLine("3. Multiply");
    Console.WriteLine("4. Divide");
    Console.WriteLine("5. Exit");
    Console.Write("Choose an option (1-5): ");
    
    userChoice = Console.ReadLine();
    
    if (userChoice == "1")
    {
        Console.WriteLine("Addition selected");
        // Add calculation logic here
    }
    else if (userChoice == "2")
    {
        Console.WriteLine("Subtraction selected");
        // Subtract calculation logic here
    }
    // ... other options
    
} while (userChoice != "5");

Console.WriteLine("Thank you for using the calculator!");
```

#### Example 2: Password Validation
```csharp
string password;
bool isValidPassword = false;

do
{
    Console.Write("Enter your password: ");
    password = Console.ReadLine();
    
    if (string.IsNullOrEmpty(password))
    {
        Console.WriteLine("Password cannot be empty. Please try again.");
    }
    else if (password.Length < 8)
    {
        Console.WriteLine("Password must be at least 8 characters long. Please try again.");
    }
    else
    {
        isValidPassword = true;
        Console.WriteLine("Password accepted!");
    }
    
} while (!isValidPassword);
```

#### Example 3: Number Input with Validation
```csharp
int number;
bool isValidNumber = false;

do
{
    Console.Write("Enter a number between 1 and 100: ");
    string input = Console.ReadLine();
    
    if (int.TryParse(input, out number))
    {
        if (number >= 1 && number <= 100)
        {
            isValidNumber = true;
            Console.WriteLine($"You entered: {number}");
        }
        else
        {
            Console.WriteLine("Number must be between 1 and 100. Please try again.");
        }
    }
    else
    {
        Console.WriteLine("Please enter a valid number. Please try again.");
    }
    
} while (!isValidNumber);
```

### When to Use Do-While

Use `do-while` when you need to:
- **Execute at least once** regardless of the initial condition
- **Validate user input** (always ask at least once)
- **Show menus** (always display the menu first)
- **Process data** where you need to check the first item

## 4. Foreach Loop

The `foreach` loop is specifically designed for iterating through collections like arrays, lists, and other data structures.

### Basic Syntax
```csharp
foreach (type variable in collection)
{
    // code to be executed
}
```

### How It Works
1. **Iterate through each item** in the collection
2. **Assign current item** to the loop variable
3. **Execute body** with the current item
4. **Move to next item** automatically
5. **Repeat** until all items are processed

### Basic Example
```csharp
string[] fruits = { "apple", "banana", "orange", "grape" };

foreach (string fruit in fruits)
{
    Console.WriteLine($"I like {fruit}");
}
```

**Output:**
```
I like apple
I like banana
I like orange
I like grape
```

### Practical Examples

#### Example 1: Processing a List of Numbers
```csharp
List<int> numbers = new List<int> { 10, 25, 30, 45, 50 };
int sum = 0;
int count = 0;

foreach (int number in numbers)
{
    sum += number;
    count++;
    Console.WriteLine($"Number: {number}, Running sum: {sum}");
}

Console.WriteLine($"\nTotal numbers: {count}");
Console.WriteLine($"Sum: {sum}");
Console.WriteLine($"Average: {(double)sum / count:F2}");
```

#### Example 2: Working with Custom Objects
```csharp
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
}

// Create a list of people
List<Person> people = new List<Person>
{
    new Person { Name = "Alice", Age = 25, City = "New York" },
    new Person { Name = "Bob", Age = 30, City = "Los Angeles" },
    new Person { Name = "Charlie", Age = 35, City = "Chicago" }
};

// Process each person
foreach (Person person in people)
{
    Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, City: {person.City}");
}
```

#### Example 3: Dictionary Iteration
```csharp
Dictionary<string, int> scores = new Dictionary<string, int>
{
    { "Alice", 95 },
    { "Bob", 87 },
    { "Charlie", 92 },
    { "Diana", 88 }
};

foreach (var kvp in scores)
{
    Console.WriteLine($"{kvp.Key}: {kvp.Value} points");
}

// Or using KeyValuePair explicitly
foreach (KeyValuePair<string, int> kvp in scores)
{
    Console.WriteLine($"{kvp.Key}: {kvp.Value} points");
}
```

### Foreach with Different Collection Types

#### Arrays
```csharp
int[] numbers = { 1, 2, 3, 4, 5 };
foreach (int num in numbers)
{
    Console.WriteLine(num * 2);
}
```

#### Lists
```csharp
List<string> colors = new List<string> { "red", "green", "blue" };
foreach (string color in colors)
{
    Console.WriteLine($"Color: {color.ToUpper()}");
}
```

#### Strings (character by character)
```csharp
string text = "Hello";
foreach (char c in text)
{
    Console.WriteLine($"Character: {c}");
}
```

### Important Notes About Foreach

⚠️ **You cannot modify the collection** while iterating with foreach:

```csharp
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

// ❌ This will throw an exception!
foreach (int num in numbers)
{
    if (num == 3)
    {
        numbers.Remove(num); // InvalidOperationException!
    }
}

// ✅ Use a for loop or while loop instead
for (int i = numbers.Count - 1; i >= 0; i--)
{
    if (numbers[i] == 3)
    {
        numbers.RemoveAt(i);
    }
}
```

### Foreach Loop

## Loop Control Statements

### Break Statement
The `break` statement immediately exits the loop:

```csharp
for (int i = 1; i <= 10; i++)
{
    if (i == 5)
    {
        Console.WriteLine("Found 5! Breaking out of loop.");
        break;
    }
    Console.WriteLine(i);
}
// Output: 1, 2, 3, 4, Found 5! Breaking out of loop.
```

### Continue Statement
The `continue` statement skips the rest of the current iteration and moves to the next one:

```csharp
for (int i = 1; i <= 10; i++)
{
    if (i % 2 == 0) // Skip even numbers
    {
        continue;
    }
    Console.WriteLine(i);
}
// Output: 1, 3, 5, 7, 9
```

## Choosing the Right Loop

### When to Use Each Loop Type

| Loop Type | When to Use | Example |
|-----------|-------------|---------|
| **for** | Known number of iterations | Processing arrays, counting |
| **while** | Unknown iterations, condition-based | User input validation, file reading |
| **do-while** | Must execute at least once | Menu systems, input validation |
| **foreach** | Iterating through collections | Processing lists, arrays, dictionaries |

### Decision Flowchart

```
Do you know how many times to repeat?
├─ YES → Do you need to execute at least once?
│   ├─ YES → Use do-while
│   └─ NO → Use for
└─ NO → Are you iterating through a collection?
    ├─ YES → Use foreach
    └─ NO → Use while
```

## Best Practices

### 1. **Choose the Right Loop for the Job**
```csharp
// ✅ Good - Use foreach for collections
foreach (var item in collection)
{
    ProcessItem(item);
}

// ❌ Avoid - Using for when foreach is more appropriate
for (int i = 0; i < collection.Count; i++)
{
    ProcessItem(collection[i]);
}
```

### 2. **Avoid Infinite Loops**
```csharp
// ❌ Bad - This will run forever
int i = 0;
while (i < 10)
{
    Console.WriteLine(i);
    // Forgot to increment i!
}

// ✅ Good - Always update the condition
int i = 0;
while (i < 10)
{
    Console.WriteLine(i);
    i++; // Increment the counter
}
```

### 3. **Use Meaningful Variable Names**
```csharp
// ❌ Bad
for (int i = 0; i < users.Count; i++)
{
    ProcessUser(users[i]);
}

// ✅ Good
for (int userIndex = 0; userIndex < users.Count; userIndex++)
{
    ProcessUser(users[userIndex]);
}
```

### 4. **Keep Loop Bodies Small**
```csharp
// ❌ Bad - Too much logic in the loop
foreach (var user in users)
{
    // 50+ lines of complex logic
    ValidateUser(user);
    SaveUser(user);
    SendWelcomeEmail(user);
    LogUserCreation(user);
    UpdateStatistics(user);
    // ... more code
}

// ✅ Good - Extract to methods
foreach (var user in users)
{
    ProcessNewUser(user);
}

private void ProcessNewUser(User user)
{
    ValidateUser(user);
    SaveUser(user);
    SendWelcomeEmail(user);
    LogUserCreation(user);
    UpdateStatistics(user);
}
```

### 5. **Consider Performance**
```csharp
// ❌ Bad - Inefficient for large collections
List<string> result = new List<string>();
foreach (var item in largeCollection)
{
    if (item.IsValid)
    {
        result.Add(item.ProcessedValue);
    }
}

// ✅ Good - Use LINQ for better performance and readability
var result = largeCollection
    .Where(item => item.IsValid)
    .Select(item => item.ProcessedValue)
    .ToList();
```

## Common Mistakes to Avoid

### 1. **Modifying Collections During Iteration**
```csharp
// ❌ Bad - Will throw exception
foreach (var item in list)
{
    if (item.ShouldRemove)
    {
        list.Remove(item); // InvalidOperationException!
    }
}

// ✅ Good - Use a for loop or create a new list
for (int i = list.Count - 1; i >= 0; i--)
{
    if (list[i].ShouldRemove)
    {
        list.RemoveAt(i);
    }
}
```

### 2. **Off-by-One Errors**
```csharp
// ❌ Bad - Will miss the last element
for (int i = 0; i < array.Length - 1; i++)
{
    Process(array[i]);
}

// ✅ Good - Include the last element
for (int i = 0; i < array.Length; i++)
{
    Process(array[i]);
}
```

### 3. **Not Handling Empty Collections**
```csharp
// ❌ Bad - Might cause issues with empty collections
int sum = 0;
foreach (var number in numbers)
{
    sum += number;
}
double average = sum / numbers.Count; // Division by zero if empty!

// ✅ Good - Check for empty collections
if (numbers.Count > 0)
{
    int sum = numbers.Sum();
    double average = (double)sum / numbers.Count;
}
else
{
    Console.WriteLine("No numbers to process.");
}
```

## Summary

Loops are essential tools in C# programming that allow you to:

- **Repeat code** efficiently
- **Process collections** of data
- **Handle user input** validation
- **Automate repetitive tasks**

### Key Takeaways:

1. **for loop**: Use when you know the exact number of iterations
2. **while loop**: Use when you don't know how many iterations you need
3. **do-while loop**: Use when you need to execute at least once
4. **foreach loop**: Use for iterating through collections

### Remember:
- Always ensure your loop condition will eventually become false
- Choose the most appropriate loop for your specific use case
- Keep loop bodies small and focused
- Use meaningful variable names
- Be careful when modifying collections during iteration

Practice with different types of loops and you'll become comfortable choosing the right one for each situation!

---

### [Previous Chapter: If-Else Statements]({{< relref "/blog/csharp/ifelse.md" >}})
### [Next Chapter: Functions and Methods]({{< relref "/blog/csharp/function.md" >}})