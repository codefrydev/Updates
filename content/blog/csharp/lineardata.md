---
title: "Linear Data C# | Chapter 9"
author: ["PrashantUnity"]
weight: 109
dateString: June 2024  
description: "Linear data structures store elements in a sequential manner and provide various ways to access, add, or remove elements. C# offers several built-in linear data structures, including arrays, lists, queues, stacks, and linked lists."
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  #display caption under cover 

tags: [ "NET","C Sharp", "Chapter 9","Linear Data"]
keywords: [ "Code Fry Dev", "codefrydev", "CFD","NET","C Sharp","Chapter 9","Linear Data"]
draft: false #make this false to publicly Available
---

## C# Linear Data Structures

### Arrays

Arrays are fixed-size collections of elements of the same type. They allow direct access to elements via index.

#### Example: Arrays

```csharp
int[] numbers = new int[] { 1, 2, 3, 4, 5 };
```

### Lists

Lists are dynamic arrays that can grow in size. They provide methods to add, remove, and access elements.

#### Example: Lists

```csharp
List<string> names = new List<string>();
names.Add("Alice");
names.Add("Bob");
```

### Queues

Queues follow the First-In-First-Out (FIFO) principle. Elements are added at the end and removed from the front.

#### Example: Queues

```csharp
Queue<int> queue = new Queue<int>();
queue.Enqueue(10);
queue.Enqueue(20);
int value = queue.Dequeue(); // Removes and returns the first element (10)
```

### Stacks

Stacks follow the Last-In-First-Out (LIFO) principle. Elements are added and removed from the top.

#### Example: Stacks

```csharp
Stack<string> stack = new Stack<string>();
stack.Push("A");
stack.Push("B");
string item = stack.Pop(); // Removes and returns the top element ("B")
```

### Linked Lists

Linked lists consist of nodes where each node contains a value and a reference to the next node. They allow efficient insertions and deletions.

#### Example: Linked Lists

```csharp
LinkedList<int> linkedList = new LinkedList<int>();
linkedList.AddLast(1);
linkedList.AddLast(2);
```

### Explanation of Data Structures

1. **Arrays**
    - Fixed-size
    - Direct access via index
    - Suitable for simple collections with known size

    ```csharp
    int[] numbers = new int[] { 1, 2, 3, 4, 5 };
    Console.WriteLine(numbers[0]); // Outputs: 1
    ```

2. **Lists**
    - Dynamic size
    - Methods to add, remove, and access elements
    - Suitable for collections where size may change

    ```csharp
    List<string> names = new List<string>();
    names.Add("Alice");
    names.Add("Bob");
    Console.WriteLine(names[0]); // Outputs: Alice
    ```

3. **Queues**
    - FIFO principle
    - `Enqueue` to add elements
    - `Dequeue` to remove and return elements from the front

    ```csharp
    Queue<int> queue = new Queue<int>();
    queue.Enqueue(10);
    queue.Enqueue(20);
    int value = queue.Dequeue(); // Outputs: 10
    ```

4. **Stacks**
    - LIFO principle
    - `Push` to add elements
    - `Pop` to remove and return elements from the top

    ```csharp
    Stack<string> stack = new Stack<string>();
    stack.Push("A");
    stack.Push("B");
    string item = stack.Pop(); // Outputs: B
    ```

5. **Linked Lists**
    - Consist of nodes with values and references to next nodes
    - Efficient insertions and deletions
    - Suitable for collections where frequent insertions and deletions are required

    ```csharp
    LinkedList<int> linkedList = new LinkedList<int>();
    linkedList.AddLast(1);
    linkedList.AddLast(2);
    Console.WriteLine(linkedList.First.Value); // Outputs: 1
    ```
For More visit [Officaial Documentation](https://learn.microsoft.com/en-us/dotnet/standard/collections/)

### [Previous Chapter]({{< relref "/blog/csharp/function.md" >}}) Loop 
