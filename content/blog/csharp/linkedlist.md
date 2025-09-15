---
title: "Linked List | Chapter 13"
author: ["PrashantUnity"]
weight: 1013
date: 2024-06-24T00:00:00-07:00
lastmod: 2024-06-26T23:59:59-07:00
dateString: June 2024  
description: "Learn about linked list data structure implementation in C# with step-by-step examples using Polyglot Notebook for better visualization"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  #display caption under cover 

tags: [ "NET","C Sharp","Chapter 13","Data Structure","Linked List"]
keywords: [ "Code Fry Dev", "codefrydev", "CFD","NET","C Sharp","Chapter 13","Linked List","Data Structure"]
draft: false #make this false to publicly Available
---

## Linked List

- I will use VS Code with Polyglot Notebook.
- Why? It is easier to show and visualize to others using Polyglot Notebook.
- You are free to use any code editor or IDE of your choice.
- I recommend VS Code because it allows for direct code execution without adhering strictly to C# syntax, facilitating easier visualization. Attempting to implement the same code in another editor may result in compile-time errors.
- I will identify lines that cause errors, and you can remove those specific lines of code.

### Create One Class Name **CodeFrydev**

- If you are not familiar with classes, please follow this post first; only then will you be able to understand.
- Create a property named **UserName** of data type string.
- Create another property named **Rank** of data type int.
- Your class will look as follows:

    ```csharp
    public class CodefryDev
    {
        public string UserName {get;set;}
        public int Rank {get;set;}
    }
    ```

#### Create An **Object** of the **Codefrydev**

- The code below demonstrates how to create an instance of the `Codefrydev` class:

    ```csharp
    var myself = new CodefryDev(); 
    // Below line of Code will only work on VS Code Using Polyglot Notebook. 
    // You can Remove this line for other IDE
    myself
    ```

    ![Object Of Codefrydev With no any assigneed value](./1.png)

- In an instance, we see that the object has two fields: one string with a null (default value in C#) and another int with a value of 0, as it should be.
- Now, assign some values to the object:

    ```csharp
    Codefrydev myself = new Codefrydev();
    myself.Rank = 1;
    myself.UserName = "firstUser";

    // The line below will only work in VS Code using Polyglot Notebook.
    // You can remove this line for other IDEs.
    myself
    ```

- We will have an object with the `UserName` value **firstUser** and the `Rank` value 1.

    ![Object Of Codefrydev With assigned value](./2.png)

### Modifications in the Codefrydev Class

- Introduce a field/property whose data type will be `Codefrydev`.

    ```csharp
    public class CodefryDev
    {
        public string UserName { get; set; }
        public int Rank { get; set; }
        public CodefryDev RelatedPerson { get; set; }
    }
    ```
#### Create an **Object** of the **CodefryDev** Class Again

- Code for creating an instance of the CodefryDev class:

    ```csharp
    var myself = new CodefryDev(); 
    // The line below will only work in VS Code using Polyglot Notebook.
    // You can remove this line for other IDEs.
    myself
    ```

- It will show something like this:

    ![Object Of Codefrydev With assigned value](./4.png)

- As we see, the result is similar to before but with one extra field `RelatedPerson` having a null value since no value has been assigned.

#### Create Another User of CodefryDev

- Code for the second user, which doesn't interact with the first user:

    ```csharp
    var otherPerson = new CodefryDev(); 
    // The line below will only work in VS Code using Polyglot Notebook.
    // You can remove this line for other IDEs.
    otherPerson
    ```

- In VS Code, running the code will show something like this:

    ![Object Of Codefrydev With assigned value](./6.png)

- On assigning some values:

    ```csharp
    otherPerson.Rank = 2;
    otherPerson.UserName = "secondUser";
    // The line below will only work in VS Code using Polyglot Notebook.
    // You can remove this line for other IDEs.
    otherPerson
    ```

- In VS Code, the output will look something like the image below:

    ![Object Of Codefrydev With assigned value](./7.png)
### Linking One Object to Another

- Now, assign the `otherPerson` instance to the `myself` object's `RelatedPerson` field as follows:

    ```csharp
    myself.RelatedPerson = otherPerson;
    // The line below will only work in VS Code using Polyglot Notebook.
    // You can remove this line for other IDEs.
    myself
    ```

- In VS Code, it will show something like this:

    ![Object Of Codefrydev With assigned value](./8.png)

- You will find that the `myself` value is not null and it points to `RelatedPerson`.
- This, in a nutshell, is the main logic behind a linked list.
- One object points to another object, which in turn points to another object, and so on.
- For example, consider the snippet below:

    - Creating another **instance** of the **CodefryDev** class with the name **thirdPerson**.
    - Assigning values and linking to **otherPerson**.

        ```csharp
        var thirdPerson = new CodefryDev(); 
        thirdPerson.Rank = 3;
        thirdPerson.UserName = "thirdUser";
        otherPerson.RelatedPerson = thirdPerson;
        myself
        ```

    - In VS Code, it will show something like this:

    ![Object Of Codefrydev With assigned value](./9.png)

    - This means the third user is linked with the second user, and the second user is linked with the first user.
    - In a similar fashion, you can create another instance and link it.

### Understanding the Main Logic of Linking Objects

Now that we understand the main logic of linking one object with another object, it's clear that manually creating and linking instances repeatedly isn't feasible. To solve this issue, I'll introduce you to a new class that will handle all heavy lifting automatically.

### Create a Class Named **Node** which will be the Data Type of LinkedList

This class will have two fields and a constructor. For more details about classes, you can follow class tutorials.

```csharp
public class Node
{
    public int value;
    public Node next;

    public Node(int value)
    {
        this.value = value;
    }
}
```
### Create Another Class Named **LinkedList** which will hold the Data Type **Node**

This class will handle all the methods and fields required for a linked list to perform all the heavy lifting.

```csharp
public class LinkedList
{
    public Node Head;
    private Node Tail;
    private int size;

    public void AddLast(int item)
    {
        var node = new Node(item); 
        if (Head == null) 
        {    
            Head = Tail = node;
        }
        else
        {
            Tail.next = node;
            Tail = node;
        } 
        size++;
    } 
}
```

In this example:

- `LinkedList` class manages a linked list structure.
- It includes a `Head` and `Tail` pointer of type `Node` to manage the start and end of the list.
- `AddLast` method adds a new `Node` containing an `int` item to the end of the list, adjusting `Tail` and `size` accordingly.

This class has a `Head` field which points to the first object instance, similar to the `myself` or `firstPerson` object we had in the earlier example. `Tail` points to another instance of the `Node` class object if any, or it will be null by default. `Size` holds how many values have been added to the linked list. The `AddLast` method takes one parameter. Upon calling this method:

- It creates a new object of the `Node` class with a specified value.
- If it is the first time called (when `Head` is null), it assigns the new object to `Head`.
- If it is not the first call, it assigns the new object to the `Tail`'s `Next` value and updates `Tail` to point to this newly created object.

#### Creating an Instance of the LinkedList Class

Let's create an instance and add values to the linked list:

```csharp
var ll = new LinkedList();
ll.AddLast(1);
ll.AddLast(2);
ll.AddLast(3);
ll.AddLast(4);
ll.AddLast(5);
// The line below will only work in VS Code using Polyglot Notebook.
// You can remove this line for other IDEs.
ll
```

In VS Code, it will show something like this:

![Real LinkedList](./10.png)

This image represents a real linked list where each node (represented by `Node` objects) points to the next node, starting from the `Head`. Each node contains a value (`Item`) and a reference (`Next`) to the next node in the sequence.

#### AddFirst Method

To add a method `AddFirst` to the `LinkedList` class that inserts data at the beginning of the linked list, you can introduce the following code. This method is straightforward and operates similarly to `AddLast`, but instead of modifying the `Tail` to add at the end, it modifies the `Head` to add at the beginning:

```csharp
public void AddFirst(int item)
{
    var node = new Node(item);

    if (Head == null)
        Head = Tail = node;
    else
    {
        node.next = Head;
        Head = node;
    }

    size++;
}
```

##### Explanation

- **node**: Creates a new `Node` object with the specified item value.
- **if (Head == null)**: Checks if the linked list is empty. If so, sets both `Head` and `Tail` to the new node.
- **else**: If the linked list is not empty:
  - Sets the `next` field of the new node to point to the current `Head`.
  - Updates the `Head` to be the new node.
- **size++**: Increments the `size` of the linked list to keep track of the number of elements.

This method efficiently adds a new node at the beginning of the linked list, adjusting the `Head` pointer accordingly.

#### Similary Adding another methods To LinkedList class

- For Removing First element of LinkedList

    ```csharp
    public void RemoveFirst()
    {
        if (Head == null)
            return;

        if (Head == Tail)
            Head = Tail = null;
        else
        {
            var second = Head.next;
            Head.next = null;
            Head = second;
        }

        size--;
    }
    ```

- Removing last Element

    ```csharp
    public void RemoveLast()
    {
        if (Head == null)
            return;

        if (Head == Tail)
            Head = Tail = null;
        else
        {
            var previous = GetPrevious(Tail);
            Tail = previous;
            Tail.next = null;
        }

        size--;
    }
    ```

- Get Previous Element

    ```csharp
    public Node GetPrevious(Node node)
    {
        var current = Head;
        while (current != null)
        {
            if (current.next == node) return current;
            current = current.next;
        }
        return null;
    }
    ```

- To Reverse Linked List

    ```csharp
    public void Reverse()
    {
        if (Head == null) return;

        var previous = Head;
        var current = Head.next;
        while (current != null)
        {
            var next = current.next;
            current.next = previous;
            previous = current;
            current = next;
        }

        Tail = Head;
        Tail.next = null;
        Head = previous;
    }
    ```

- Find if there is any loop

    ```csharp
    public bool HasLoop()
    {
        var slow = Head;
        var fast = Head;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;

            if (slow == fast)
                return true;
        }

        return false;
    }
    ```

- Get Kth Element from End of Linked List

    ```csharp
    public int GetKthFromTheEnd(int k)
    {
        if (Head == null) return;

        var a = Head;
        var b = Head;
        for (int i = 0; i < k - 1; i++)
        {
            b = b.next;
            if (b == null)
                throw new InvalidOperationException();
        }
        while (b != Tail)
        {
            a = a.next;
            b = b.next;
        }
        return a.value;
    }
    ```

## Full Source Code should look like this.

- Souce Code

    ```csharp
    using System;
    public class LinkedList
    {
        public Node Head;
        private Node Tail;
        private int size;

        public void AddLast(int item)
        {
            var node = new Node(item); 
            if (Head == null) 
            {    
                Head = Tail = node;
            }
            else
            {
                Tail.next = node;
                Tail = node;
            } 
            size++;
        } 
        public void AddFirst(int item)
        {
            var node = new Node(item);

            if (Head == null)
                Head = Tail = node;
            else
            {
                node.next = Head;
                Head = node;
            }

            size++;
        }
        public void RemoveFirst()
        {
            if (Head == null)
                return;

            if (Head == Tail)
                Head = Tail = null;
            else
            {
                var second = Head.next;
                Head.next = null;
                Head = second;
            }

            size--;
        }
        public void RemoveLast()
        {
            if (Head == null)
                return;

            if (Head == Tail)
                Head = Tail = null;
            else
            {
                var previous = GetPrevious(Tail);
                Tail = previous;
                Tail.next = null;
            }

            size--;
        }
        public Node GetPrevious(Node node)
        {
            var current = Head;
            while (current != null)
            {
                if (current.next == node) return current;
                current = current.next;
            }
            return null;
        }
        public void Reverse()
        {
            if (Head == null) return;

            var previous = Head;
            var current = Head.next;
            while (current != null)
            {
                var next = current.next;
                current.next = previous;
                previous = current;
                current = next;
            }

            Tail = Head;
            Tail.next = null;
            Head = previous;
        }
        public bool HasLoop()
        {
            var slow = Head;
            var fast = Head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

                if (slow == fast)
                    return true;
            }

            return false;
        }
        public int GetKthFromTheEnd(int k)
        {
            if (Head == null) throw new InvalidOperationException();

            var a = Head;
            var b = Head;
            for (int i = 0; i < k - 1; i++)
            {
                b = b.next;
                if (b == null)
                    throw new InvalidOperationException();
            }
            while (b != Tail)
            {
                a = a.next;
                b = b.next;
            }
            return a.value;
        } 
    }
    ```

Thats all for now Will see you any another post.

### [Previous Chapter]({{< relref "/blog/csharp/class.md" >}}) Class
