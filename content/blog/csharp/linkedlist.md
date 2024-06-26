---
title: "Linked List | Chapter 13"
author: ["PrashantUnity"]
weight: 104
date: 2024-06-24T00:00:00-07:00
lastmod: 2024-06-26T23:59:59-07:00
dateString: June 2024  
description: "In this post we will look Linked List Data Structure"
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

- I Will Use Vs Code With Polyglot.
- Why ? => I Easier to Show/Visualise to other With Polyglot Notebook
- You are Free to use any of Code Editor or IDE of your choice.
- I will recomment VS Code. Because to Visualize Code i can Directly call code without any following c# Syntax. I will give you compile time error if you imple same code in Other Editor.
- I Will Point out which will give error and you can remove that specific line of Code.

### Create One Class Name **CodeFrydev**

- If You Don't Know About Class Please Follow this Post then only you will able to understand.
- Give One Property **UserName** of data type string
- Give Another Property **Rank** of data type int
- You will have Class as Following

    ```csharp
    public class CodefryDev
    {
        public string UserName {get;set;}
        public int Rank {get;set;}
    }
    ```

#### Create An **Object** of the **Codefrydev**

- Below Code Shows Creating an Instance of Codefrydev Class Object/Instance

    ```csharp
    var myself = new CodefryDev(); 
    // Below line of Code will only work on VS Code Using Polyglot Notebook. 
    // You can Remove this line for other IDE
    myself
    ```

    ![Object Of Codefrydev With no any assigneed value](./1.png)

- In An Instance we See That Object Have two field on string with null(default value in c#) value and another int with 0 as it should be.
- Now asssign Some Value To Object.

    ```csharp
    myself.Rank=1;
    myself.UserName="firstUser";

    // Below line of Code will only work on VS Code Using Polyglot Notebook. 
    // You can Remove this line for other IDE
    myself
    ```

- We will have object UserName value **firstUser** and Rank value 1

    ![Object Of Codefrydev With with assigned value](./2.png)

### Modification in Codefrydev class

- Introduction a field/ properties whose data type will be Codefrydev.

    ```csharp
    public class CodefryDev
    {
        public string UserName {get;set;}
        public int Rank {get;set;}
        public CodefryDev RelatedPerson {get;set;}
    }
    ```

#### Again Create An **Object** of the **Codefrydev**

- Code Of Creating An instance of Codefrydev calss

    ```csharp
    var myself = new CodefryDev(); 
    // Below line of Code will only work on VS Code Using Polyglot Notebook. 
    // You can Remove this line for other IDE
    myself
    ```

- It will Show Something like this

    ![Object Of Codefrydev With with assigned value](./4.png)

- See we have result as earlier but one extra field RelatedPerson will null value. As value are not assigned.

#### Lets Create another user of Codefrydev 

- Code for second user. It dosen't have anything to do with first user

    ```csharp
    var otherPerson = new CodefryDev(); 
    // Below line of Code will only work on VS Code Using Polyglot Notebook. 
    // You can Remove this line for other IDE
    otherPerson
    ```

- And in vs Code On running code it will Show Some thing like this

![Object Of Codefrydev With with assigned value](./6.png)

- On assigning some values.

    ```csharp
    otherPerson.Rank=2;
    otherPerson.UserName="secondUser";
    // Below line of Code will only work on VS Code Using Polyglot Notebook. 
    // You can Remove this line for other IDE
    otherPerson
    ```

- In vs Code it will Output Some thing like below image

    ![Object Of Codefrydev With with assigned value](./7.png)

### Liking One Object To Another Data

- Now Assign otherperson Instance to myself object RelatedPerson Field as follow

    ```csharp
    myself.RelatedPerson = otherPerson;
    // Below line of Code will only work on VS Code Using Polyglot Notebook. 
    // You can Remove this line for other IDE
    myself
    ```

- In Vs Code it will show Some thing like this image
    ![Object Of Codefrydev With with assigned value](./7.png)

- You Will find that myself value is not null and it point to RelatedPerson.
- This in nutshell is Main Logic Behing Linked List.
- i.e. One Object point to another object which in turn points another object. and So on..
- For Example take below snippet.

    - Creating another **intance** of **Codefrydev** calss with name **thirdPerson**
    - Assigning Value And Linking to **otherPerson**

        ```csharp
        var thirdPerson = new CodefryDev(); 
        thirdPerson.Rank=3;
        thirdPerson.UserName="thirdUser";
        otherPerson.RelatedPerson=thirdPerson;
        myself
        ```

    - In VS Code it Will Show Some thing Like This.
        ![Object Of Codefrydev With with assigned value](./9.png)
    - i.e third user is linked with second user and seconduser is Linked with firstuser.
    - In Similar Fasion You can Created another inatance and link.

### So now we know main logic  linking one object with another Object.

- As as this will not be fesiable to work with creating again and again instace And Link to previous.
- To Solve this Issue I will Introdce you to new Class Will do all heavy stuff Automagically.

### Create A Class name **Node** which will be the Data type of LinkedList.

- This Will have two fields and on constructor. For More about class follow calss Tutorials post.

    ```csharp {linenos=true}
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

### Create Another Class name **LinkedList** which will hold the Data type **Node**.

- This Class will have all the method and field for the thing required for linked list to do all heavy lifting.

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

- This Class have field **Head** which will point first object instance similar to myself/firstperson object we had in Earlier example.
- **Tail** will point to another instance of **Node** class object if any or it will null by default
- **size** will hold how many value have been added to the linkd list
- **AddLast** method takes one parameter.
    - On calling this method it will
        - Create a new onject of Node Class with value 
        - if it is first time called means the head value will be null so it will assign new object to head
        - If it is not first call it will assign value to the tail Next value. and Update tail to point to this newly created object.
     

#### Creating Instance of LinkedList Class

- Creating an Instace and adding value to Linked List

    ```csharp
    var ll = new LinkedList();
    ll.AddLast(1);
    ll.AddLast(2);
    ll.AddLast(3);
    ll.AddLast(4);
    ll.AddLast(5);
    // Below line of Code will only work on VS Code Using Polyglot Notebook. 
    // You can Remove this line for other IDE
    ll
    ```

- In Vs Code it will show something like this

    ![Real LinkedList](./10.png)

#### Adding another method which will add Data To First of Linked List

- Introduce below code to the Linked List Class
- Code is staright Forward similar to prevous
- Instead of changing tail object we are changing head object

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