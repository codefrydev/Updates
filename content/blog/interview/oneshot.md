---
title: "Quick Interview Preparation Guide"
author: "PrashantUnity"
weight: 210
date: 2024-08-03
lastmod: 2024-10-23
dateString: August 2024  
description: "Essential programming and technical interview questions for last-minute preparation covering arrays, strings, algorithms, and system design"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "NET", "codefrydev", "C sharp", "CFD"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD"]
---


### **Programming Questions**

#### 1. Array Manipulation:
   - Move all zeros to the end of a given array.
   - Solve the problem of buying and selling a product to maximize profit, given its prices on different days from a given price array.
   - Find the 3rd highest element in an array.
   - Find the 2nd duplicate number in an array.

#### 2. String Manipulation:
   - Given a string `s`, find the length of the longest substring without repeating characters. (Example: `s = "abcabcbb"`)
   - Find the first repeating number in an array. (Example: `arr[] = {10, 5, 3, 4, 5, 3, 6}`)
   - Given a `List<string>`: `var list = new List<string> {"Ravi Kumar", "Neha Gupta", "Arti Gupta", "Kamal Rai"};` get the count of the surnames and maintain the order.

#### 3. C# Code Execution:
   - Determine the order of printing in a C# class with static constructors, instance constructors, and regular constructors.

### **General Problem-Solving:**
   - Dry run a piece of code and optimize its complexity.

---

### **C# Core Concepts**

#### 1. **LINQ (Language Integrated Query):**
   - Steps for initializing LINQ queries.
   - How intermediate operations work in LINQ (e.g., `Where`, `Select`).
   - How terminal operations work in LINQ (e.g., `ToList()`, `FirstOrDefault()`).
   - What is a parallel LINQ (PLINQ) query?

#### 2. **Collections Framework:**
   - Difference between `IComparable` and `IComparer`.
   - How `Dictionary<TKey, TValue>` works in C#.
   - Difference between `ICollection` and `IEnumerable`.
   - Overview of the Collection framework starting from the base interface `IEnumerable` and its methods.

#### 3. **Exception Handling:**
   - How to create custom exceptions in C#.
   - Difference between `Thread.Sleep()` and `Task.Delay()` methods.

#### 4. **Polymorphism and OOP Concepts:**
   - Method overloading and method overriding.
   - Difference between `==` and `.Equals()` in string comparison.
   - Multithreading and the use of `lock` statements.
   - Understanding marker interfaces, functional interfaces (like delegates), and design patterns such as Singleton and Factory.
   - SOLID principles.

#### 5. **ASP.NET Core:**
   - Difference between ASP.NET Core MVC and Web API, and which is better and why.
   - ASP.NET Core inbuilt server (Kestrel).
   - Difference between Razor Pages and MVC.
   - Understanding JWT tokens and how they secure applications using HTTPS.

#### 6. **Miscellaneous C#:**
   - Understanding the order of execution in blocks (static constructor, instance constructor, regular constructor).
   - Questions related to classes and methods, such as `Animal` and `Cat` with overridden methods.

---

### **SQL:**

#### 1. **Complex Queries:**
   - Find the third-highest salary in SQL.
   - Understanding the order of execution in SQL queries (e.g., `Empid`, `dept`, `manager id`).

#### 2. **Data Structures and Algorithms (DSA):**

   - Array and String Problems:
     - Find the 3rd highest element in an array.
     - Find the 2nd duplicate number in an array.
     - Given an array and an integer `x`, return true if any two values in the array sum to `x`.
     - Move all zeros to the end of a given array.
     - Solve the problem of buying and selling a product to maximize profit from a given price array.
     - Find the length of the longest substring without repeating characters.
     - Find the first repeating number in an array.
     - Get the count of surnames from a list of names and maintain the order.
     - Determine the order of printing blocks in a class.

   - Graph Problems:
     - Questions related to graph traversal, shortest path, and other medium-level DSA problems involving graphs.

---

### **Interview Evaluation Focus**

1. **Core C# Proficiency:**
   - **Object-Oriented Programming (OOP):** The panel is assessing the candidates' understanding of fundamental OOP concepts such as polymorphism (method overloading and overriding), inheritance, and the use of interfaces.
   - **C# Language Features:** Questions about `IComparable` vs. `IComparer`, LINQ, exception handling, and the inner workings of `Dictionary<TKey, TValue>` indicate a focus on how well candidates understand and can apply core C# features.

2. **Problem-Solving and Algorithmic Thinking:**
   - **Data Structures & Algorithms (DSA):** The panel is testing candidates' ability to solve common DSA problems, particularly those involving arrays and strings. Questions about finding elements in arrays, manipulating arrays, and solving string problems are key indicators.
   - **Coding Challenges:** Coding questions like moving zeros in an array, finding the longest substring without repeating characters, and calculating profits suggest a focus on assessing problem-solving skills under time constraints.

3. **Practical Application of C#:**
   - **Real-World Scenarios:** Questions related to coding execution order, LINQ processing, and custom exceptions are designed to gauge how candidates apply C# in practical, real-world scenarios.
   - **ASP.NET Core Knowledge:** The inclusion of ASP.NET Core-related questions indicates that the panel is looking for experience in building enterprise-level applications, particularly using frameworks that are standard in the industry.

4. **SQL Proficiency:**
   - **Complex Query Handling:** SQL questions, especially those requiring knowledge of advanced query techniques like finding the third-highest salary or understanding execution order, show that the panel values candidates who can handle database-related tasks effectively.

5. **Understanding of Design Patterns and Best Practices:**
   - **Design Patterns:** Questions about Singleton and Factory design patterns, as well as SOLID principles, suggest the panel is interested in candidates who not only write code but also understand the architecture and design of scalable and maintainable software systems.

6. **Multithreading and Concurrency:**
   - **Concurrency Control:** Questions about `Thread.Sleep()` vs. `Task.Delay()`, locking mechanisms, and PLINQ indicate an interest in candidates who understand how to write efficient, thread-safe code, which is crucial for high-performance applications.

7. **Communication and Explanation Skills:**
   - **Code Explanation:** The panel seems to place importance on the candidates' ability to explain their thought process, as seen in questions where candidates are asked to dry run code or discuss the impact of their coding decisions.

8. **Experience with Specific Technologies and Tools:**
   - **ASP.NET Core & Security:** Understanding of ASP.NET Core, JWT, and HTTPS indicates a preference for candidates with experience in modern web application development and security practices.
   - **Full-Stack Awareness:** While primarily focused on backend (C#), the questions also touch on front-end (Angular/React) and cloud technologies (Azure/AWS), hinting at a preference for candidates with full-stack experience or at least a good understanding of related technologies.

9. **Cultural Fit and Adaptability:**
   - **Startup Experience:** Questions like thriving in a fast-paced environment and understanding of Agile/SAFe methodologies suggest the panel is looking for candidates who are adaptable and can thrive in dynamic settings.

---
---
---

### **Programming Questions**

#### 1. Array Manipulation:

- **Move all zeros to the end of a given array.**
  
    ```csharp
    int[] arr = {0, 1, 0, 3, 12};
    int[] result = arr.Where(x => x != 0).Concat(arr.Where(x => x == 0)).ToArray();
    // Output: {1, 3, 12, 0, 0}
    ```

- **Solve the problem of buying and selling a product to maximize profit, given its prices on different days from a given price array.**
  
    ```csharp
    int[] prices = {7, 1, 5, 3, 6, 4};
    int maxProfit = 0;
    int minPrice = int.MaxValue;

    foreach (int price in prices)
    {
        if (price < minPrice)
        {
            minPrice = price;
        }
        else if (price - minPrice > maxProfit)
        {
            maxProfit = price - minPrice;
        }
    }
    // Output: maxProfit = 5
    ```

- **Find the 3rd highest element in an array.**
  
    ```csharp
    int[] arr = {3, 2, 1, 5, 6, 4};
    int thirdHighest = arr.OrderByDescending(x => x).Distinct().Skip(2).FirstOrDefault();
    // Output: thirdHighest = 4
    ```

- **Find the 2nd duplicate number in an array.**
  
    ```csharp
    int[] arr = {1, 2, 3, 4, 5, 3, 6, 5};
    var duplicates = arr.GroupBy(x => x).Where(g => g.Count() > 1).Select(g => g.Key).ToArray();
    int secondDuplicate = duplicates.Length > 1 ? duplicates[1] : -1;
    // Output: secondDuplicate = 5
    ```

#### 2. String Manipulation:

- **Given a string `s`, find the length of the longest substring without repeating characters.**
  
    ```csharp
    string s = "abcabcbb";
    int maxLength = 0;
    Dictionary<char, int> charMap = new Dictionary<char, int>();
    int left = 0;

    for (int right = 0; right < s.Length; right++)
    {
        if (charMap.ContainsKey(s[right]))
        {
            left = Math.Max(charMap[s[right]] + 1, left);
        }
        charMap[s[right]] = right;
        maxLength = Math.Max(maxLength, right - left + 1);
    }
    // Output: maxLength = 3 (substring "abc")
    ```

- **Find the first repeating number in an array.**
  
    ```csharp
    int[] arr = {10, 5, 3, 4, 5, 3, 6};
    HashSet<int> set = new HashSet<int>();
    int firstRepeating = -1;

    foreach (int num in arr)
    {
        if (set.Contains(num))
        {
            firstRepeating = num;
            break;
        }
        set.Add(num);
    }
    // Output: firstRepeating = 5
    ```

- **Given a `List<string>`: `var list = new List<string> {"Ravi Kumar", "Neha Gupta", "Arti Gupta", "Kamal Rai"};` get the count of the surnames and maintain the order.**
  
    ```csharp
    List<string> list = new List<string> { "Ravi Kumar", "Neha Gupta", "Arti Gupta", "Kamal Rai" };
    var surnameCount = list.GroupBy(name => name.Split(' ')[1])
                           .Select(g => new { Surname = g.Key, Count = g.Count() });

    foreach (var item in surnameCount)
    {
        Console.WriteLine($"{item.Surname}: {item.Count}");
    }
    // Output:
    // Kumar: 1
    // Gupta: 2
    // Rai: 1
    ```

#### 3. C# Code Execution:

- **Determine the order of printing in a C# class with static constructors, instance constructors, and regular constructors.**

    ```csharp
    class Program
    {
        static Program()
        {
            Console.WriteLine("Static constructor");
        }

        public Program()
        {
            Console.WriteLine("Instance constructor");
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Main method start");
            Program p = new Program();
            Console.WriteLine("Main method end");
        }
    }
    // Output:
    // Static constructor
    // Main method start
    // Instance constructor
    // Main method end
    ```

### **General Problem-Solving:**

- **Dry run a piece of code and optimize its complexity.**

    Let's consider optimizing a bubble sort implementation:

    ```csharp
    // Original Bubble Sort
    void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    // Swap arr[j] and arr[j + 1]
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
    // Optimized Bubble Sort
    void OptimizedBubbleSort(int[] arr)
    {
        int n = arr.Length;
        bool swapped;
        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    // Swap arr[j] and arr[j + 1]
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    swapped = true;
                }
            }
            if (!swapped)
                break;
        }
    }
    // Complexity is still O(n^2), but may be faster in practice when the array is nearly sorted.
    ```

---

### **C# Core Concepts**

#### 1. **LINQ (Language Integrated Query):**

- **Steps for initializing LINQ queries:**
  
    ```csharp
    var numbers = new List<int> { 1, 2, 3, 4, 5 };
    var evenNumbers = numbers.Where(n => n % 2 == 0).ToList();
    // evenNumbers = {2, 4}
    ```

- **How intermediate operations work in LINQ (e.g., `Where`, `Select`):**

    - `Where`: Filters elements based on a condition.
    - `Select`: Projects each element into a new form.

    ```csharp
    var results = numbers.Where(n => n > 2).Select(n => n * n).ToList();
    // Output: results = {9, 16, 25}
    ```

- **How terminal operations work in LINQ (e.g., `ToList()`, `FirstOrDefault()`):**

    - `ToList()`: Converts the result to a list.
    - `FirstOrDefault()`: Returns the first element or a default value if no elements are found.

    ```csharp
    var first = numbers.FirstOrDefault(n => n > 3);
    // Output: first = 4
    ```

- **What is a parallel LINQ (PLINQ) query?**
  
    - PLINQ allows for parallel processing of data using multiple threads to improve performance.

    ```csharp
    var parallelQuery = numbers.AsParallel().Where(n => n % 2 == 0).ToList();
    ```

#### 2. **Collections Framework:**

- **Difference between `IComparable` and `IComparer`:**

    - `IComparable`: Used for natural ordering of objects. Implemented by the class itself.
    - `IComparer`: Defines a custom comparison logic external to the object.

    ```csharp
    public class Student : IComparable<Student>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(Student other)
        {
            return this.Age.CompareTo(other.Age);
        }
    }
    ```

    ```csharp
    public class AgeComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return x.Age.CompareTo(y.Age);
        }
    }
    ```

- **How `Dictionary<TKey, TValue>` works in C#:**

    - Uses a hash table to store key-value pairs. Keys are hashed, and the hash code determines the bucket location.

    ```csharp
    Dictionary<int, string> dict = new Dictionary<int, string>();
    dict.Add(1, "One");
    dict.Add(2, "Two");
    ```

- **Difference between `ICollection` and `IEnumerable`:**

    - `IEnumerable`: Basic iteration over a collection.
    - `ICollection`: Extends `IEnumerable` with methods like `

Add`, `Remove`, `Count`.

#### 3. **Exception Handling:**

- **How to create custom exceptions in C#:**

    ```csharp
    public class MyCustomException : Exception
    {
        public MyCustomException(string message) : base(message) { }
    }
    ```

- **Difference between `Thread.Sleep()` and `Task.Delay()`:**

    - `Thread.Sleep()`: Blocks the current thread for a specified time.
    - `Task.Delay()`: Non-blocking, asynchronous wait, suitable for async methods.

#### 4. **Polymorphism and OOP Concepts:**

- **Method overloading and method overriding:**

    - **Overloading:** Multiple methods with the same name but different parameters.

        ```csharp
        public void Print(int num) { }
        public void Print(string text) { }
        ```

    - **Overriding:** Redefining a method in a derived class.

        ```csharp
        public class Animal
        {
            public virtual void Speak() { Console.WriteLine("Animal speaks"); }
        }

        public class Dog : Animal
        {
            public override void Speak() { Console.WriteLine("Dog barks"); }
        }
        ```

- **Difference between `==` and `.Equals()` in string comparison:**

    - `==`: Compares references for objects; values for strings.
    - `.Equals()`: Compares the actual values.

#### 5. **ASP.NET Core:**

- **Difference between ASP.NET Core MVC and Web API:**

    - MVC: Used for building web applications with views (HTML + logic).
    - Web API: Focused on RESTful services and returns data (JSON/XML).

- **ASP.NET Core inbuilt server (Kestrel):**
  
    - Kestrel is a cross-platform web server for ASP.NET Core applications, known for high performance and lightweight architecture.

- **Understanding JWT tokens and HTTPS:**

    - JWT: JSON Web Token, used for securely transmitting information between parties as a JSON object.
    - HTTPS: Secures communication over the network using SSL/TLS.

#### 6. **Miscellaneous C#:**

- **Order of execution in blocks (static constructor, instance constructor, regular constructor):**

    - Static constructor → Main method → Instance constructor.

### **SQL:**

- **Find the third-highest salary in SQL:**

    ```sql
    SELECT DISTINCT salary
    FROM employees
    ORDER BY salary DESC
    LIMIT 1 OFFSET 2;
    ```

- **Understanding order of execution in SQL queries:**

    - **Example:** Identify the order of execution in a query.

    ```sql
    SELECT * FROM employees WHERE dept = 'Sales' ORDER BY empid;
    ```
    
    - **Execution Order:**
        1. FROM
        2. WHERE
        3. SELECT
        4. ORDER BY

### **Data Structures and Algorithms (DSA):**

- **Graph Problems:** 

    - **Example:** Implementing graph traversal using BFS.

    ```csharp
    public void BFS(int start, List<int>[] adjList)
    {
        bool[] visited = new bool[adjList.Length];
        Queue<int> queue = new Queue<int>();

        visited[start] = true;
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            Console.Write(node + " ");

            foreach (int neighbor in adjList[node])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }
    }
    ```
