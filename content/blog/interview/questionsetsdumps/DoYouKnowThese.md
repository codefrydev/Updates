---
title: "If Yoy Know These Then You are prepared"
author: "PrashantUnity"
weight: 215
date: 2024-08-03
lastmod: 2024-10-25
dateString: August 2024  
description: "See If can Answer all the Question, Only Then You are prepared for Dotnet Interview "
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "NET", "codefrydev", "C sharp", "CFD"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD"]
---

### Q1. What is C#? What is the difference between C# and .NET?

**C# (C-Sharp)** is a modern, object-oriented programming language developed by Microsoft. It is part of the .NET framework and is used for developing a wide range of applications, from web and mobile apps to desktop applications.

**.NET** is a framework developed by Microsoft that provides a comprehensive platform for building and running applications. It includes a runtime environment (CLR), a large class library, and support for various programming languages, including C#, VB.NET, and F#.

**Difference:**

- **C#** is a programming language.
- **.NET** is a framework that provides the runtime and libraries for C# and other languages.

**Example:**

```csharp
// C# code example
using System;

namespace HelloWorldApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
```

This code runs on the .NET framework.

### Q2. What is OOPS? What are the main concepts of OOPS?

**OOPS (Object-Oriented Programming System)** is a programming paradigm based on the concept of "objects," which are instances of "classes." It is designed to improve code modularity, reusability, and maintainability.

**Main Concepts:**

1. **Encapsulation:** Bundling data and methods that operate on the data within a class and restricting access to some of the object's components.
   - *Example:* In C#, encapsulation is achieved using access modifiers.

   ```csharp
   public class Person
   {
       private string name;
       public string Name
       {
           get { return name; }
           set { name = value; }
       }
   }
   ```

2. **Inheritance:** Mechanism by which one class can inherit fields and methods from another class.
   - *Example:*

   ```csharp
   public class Animal
   {
       public void Eat() { }
   }

   public class Dog : Animal
   {
       public void Bark() { }
   }
   ```

3. **Polymorphism:** The ability for different classes to be treated as instances of the same class through a common interface.
   - *Example:*

   ```csharp
   public class Animal
   {
       public virtual void MakeSound() { }
   }

   public class Dog : Animal
   {
       public override void MakeSound() { Console.WriteLine("Bark"); }
   }

   public class Cat : Animal
   {
       public override void MakeSound() { Console.WriteLine("Meow"); }
   }
   ```

4. **Abstraction:** The concept of hiding the complex implementation details and showing only the essential features.
   - *Example:*

   ```csharp
   public abstract class Shape
   {
       public abstract void Draw();
   }

   public class Circle : Shape
   {
       public override void Draw() { Console.WriteLine("Drawing Circle"); }
   }
   ```

### Q3. What are the advantages of OOPS?

1. **Modularity:** Code is organized into classes and objects, which makes it easier to manage and understand.
2. **Reusability:** Classes can be reused across different programs, reducing code duplication.
3. **Scalability:** Code can be scaled more easily by adding new classes or modifying existing ones without affecting other parts of the system.
4. **Maintainability:** Changes can be made to one part of the code without impacting others, making it easier to maintain and update.

### Q4. What are the limitations of OOPS?

1. **Complexity:** It can be complex to design and implement systems using OOPS principles, especially for beginners.
2. **Performance Overhead:** The abstraction and encapsulation can introduce performance overhead due to additional layers of abstraction.
3. **Inheritance Issues:** Overusing inheritance can lead to a rigid and less flexible code structure.

### Q5. What are Classes and Objects?

- **Class:** A blueprint or template for creating objects. It defines properties and methods that the objects created from the class can use.
  - *Example:*

  ```csharp
  public class Car
  {
      public string Make { get; set; }
      public string Model { get; set; }
      
      public void Start()
      {
          Console.WriteLine("Car started.");
      }
  }
  ```

- **Object:** An instance of a class. It contains actual data and can use the methods defined in the class.
  - *Example:*

  ```csharp
  Car myCar = new Car();
  myCar.Make = "Toyota";
  myCar.Model = "Corolla";
  myCar.Start();
  ```

### Q6. What are the types of classes in C#?

1. **Concrete Classes:** Regular classes that can be instantiated.
   - *Example:* `public class Car { }`

2. **Abstract Classes:** Classes that cannot be instantiated and are used to provide a base for other classes.
   - *Example:*

   ```csharp
   public abstract class Shape
   {
       public abstract void Draw();
   }
   ```

3. **Sealed Classes:** Classes that cannot be inherited.
   - *Example:*

   ```csharp
   public sealed class FinalClass { }
   ```

4. **Static Classes:** Classes that cannot be instantiated and only contain static members.
   - *Example:*

   ```csharp
   public static class Utility
   {
       public static void DoSomething() { }
   }
   ```

### Q7. Is it possible to prevent object creation of a class in C#?

Yes, you can prevent object creation by making the class `abstract` or by providing a private constructor.

- **Abstract Class:**

  ```csharp
  public abstract class AbstractClass
  {
      public abstract void Method();
  }
  ```

- **Private Constructor:**

  ```csharp
  public class Singleton
  {
      private Singleton() { }
  }
  ```

### Q8. What is Property?

A property is a member of a class that provides a mechanism to read, write, or compute the value of a private field indirectly. It encapsulates a field and provides access through `get` and `set` accessors.

- *Example:*

  ```csharp
  public class Person
  {
      private string name;
      public string Name
      {
          get { return name; }
          set { name = value; }
      }
  }
  ```

### Q9. What is the difference between Property and Function?

- **Property:** Used to access or modify the value of a field. It appears like a field but is actually a method behind the scenes.
  - *Example:* `public string Name { get; set; }`

- **Function (Method):** Performs an operation and may return a value or perform a task. Methods can take parameters and may include logic that properties generally do not.
  - *Example:*

  ```csharp
  public int Add(int a, int b)
  {
      return a + b;
  }
  ```

### Q10. What are Namespaces?

Namespaces are used to organize and provide a way to group related classes, interfaces, and other types. They help avoid naming conflicts and make the code more readable.

- *Example:*

  ```csharp
  namespace MyApplication.Models
  {
      public class User
      {
          public string Username { get; set; }
      }
  }

  namespace MyApplication.Services
  {
      public class UserService
      {
          public void CreateUser(User user) { }
      }
  }
  ```

### Q11. What is Inheritance? When to use Inheritance?

**Inheritance** is an object-oriented programming concept where one class (called the derived or child class) inherits the properties and methods of another class (called the base or parent class). This allows the derived class to reuse code from the base class and extend or override its functionality.

**When to use Inheritance:**

- **Code Reusability:** To reuse code from an existing class.
- **Extensibility:** To add new functionalities to an existing class without modifying it.
- **Hierarchy Representation:** To model a hierarchical relationship between classes.

**Example:**

```csharp
public class Animal
{
    public void Eat() { Console.WriteLine("Animal eats"); }
}

public class Dog : Animal
{
    public void Bark() { Console.WriteLine("Dog barks"); }
}
```

In this example, `Dog` inherits the `Eat` method from `Animal` and has its own method `Bark`.

### Q12. What are the different types of Inheritance?

1. **Single Inheritance:** A class inherits from a single base class.
   - *Example:* `class Derived : Base { }`

2. **Multiple Inheritance:** A class inherits from multiple base classes. (Not supported in C# directly, but can be achieved using interfaces.)
   - *Example:* `class Derived : IInterface1, IInterface2 { }`

3. **Multilevel Inheritance:** A class inherits from a derived class which itself inherits from another class.
   - *Example:* `class Grandparent { } class Parent : Grandparent { } class Child : Parent { }`

4. **Hierarchical Inheritance:** Multiple classes inherit from a single base class.
   - *Example:* `class Base { } class Derived1 : Base { } class Derived2 : Base { }`

5. **Hybrid Inheritance:** A combination of more than one type of inheritance.
   - *Example:* Combining hierarchical and multilevel inheritance.

### Q13. Does C# support Multiple Inheritance?

C# does not support multiple inheritance of classes. This means a class cannot inherit from more than one class. However, C# supports multiple inheritance through interfaces.

**Example:**

```csharp
public interface IFlyable
{
    void Fly();
}

public interface IDriveable
{
    void Drive();
}

public class FlyingCar : IFlyable, IDriveable
{
    public void Fly() { Console.WriteLine("Flying"); }
    public void Drive() { Console.WriteLine("Driving"); }
}
```

### Q14. How to prevent a class from being Inherited?

To prevent a class from being inherited, you can mark it as `sealed`.

**Example:**

```csharp
public sealed class SealedClass
{
    // Class members
}
```

A `sealed` class cannot be used as a base class.

### Q15. Are private class members inherited to the derived class?

No, private class members are not inherited by derived classes. Private members are only accessible within the class they are defined in.

**Example:**

```csharp
public class Base
{
    private int privateValue = 10;
}

public class Derived : Base
{
    // privateValue is not accessible here
}
```

### Q16. What is Abstraction? How to implement abstraction?

**Abstraction** is the concept of hiding the complex implementation details and exposing only the essential features of an object. It allows you to work with complex systems in a simplified manner.

**How to implement abstraction:**

- Using **abstract classes** which cannot be instantiated and can contain abstract methods that derived classes must implement.
- Using **interfaces** which define a contract for classes to implement.

**Example with Abstract Class:**

```csharp
public abstract class Shape
{
    public abstract void Draw();
}

public class Circle : Shape
{
    public override void Draw() { Console.WriteLine("Drawing Circle"); }
}
```

**Example with Interface:**

```csharp
public interface IShape
{
    void Draw();
}

public class Rectangle : IShape
{
    public void Draw() { Console.WriteLine("Drawing Rectangle"); }
}
```

### Q17. What is Encapsulation? How to implement encapsulation?

**Encapsulation** is the concept of bundling the data (fields) and methods (functions) that operate on the data into a single unit (class) and restricting access to some of the object's components. It protects the internal state of the object from unintended interference and misuse.

**How to implement encapsulation:**

- Using **access modifiers** (`private`, `protected`, `public`) to control access to class members.
- Providing **public properties** to access private fields.

**Example:**

```csharp
public class Person
{
    private string name; // Private field

    public string Name // Public property
    {
        get { return name; }
        set { name = value; }
    }
}
```

### Q18. What is the difference between Abstraction and Encapsulation?

- **Abstraction** is about hiding complex implementation details and exposing only the necessary parts.
- **Encapsulation** is about bundling the data and methods together and restricting access to some of the object's components.

**Abstraction** focuses on *what* an object does, while **Encapsulation** focuses on *how* it does it.

### Q19. What is Polymorphism and what are its types? When to use polymorphism?

**Polymorphism** is the ability of a single function, operator, or method to work in different ways depending on the context. It allows objects of different types to be treated as objects of a common super type.

**Types:**

1. **Compile-time Polymorphism (Static Binding):** Achieved through method overloading and operator overloading.
2. **Runtime Polymorphism (Dynamic Binding):** Achieved through method overriding using inheritance and virtual/override keywords.

**When to use polymorphism:**

- When you want to use a unified interface to interact with different types of objects.
- To simplify code and reduce complexity by allowing the same method to operate on different types of objects.

**Example of Compile-time Polymorphism (Method Overloading):**

```csharp
public class MathOperations
{
    public int Add(int a, int b) { return a + b; }
    public double Add(double a, double b) { return a + b; }
}
```

**Example of Runtime Polymorphism (Method Overriding):**

```csharp
public class Animal
{
    public virtual void MakeSound() { Console.WriteLine("Animal sound"); }
}

public class Dog : Animal
{
    public override void MakeSound() { Console.WriteLine("Bark"); }
}
```

### Q20. What is Method Overloading? In how many ways can a method be overloaded?

**Method Overloading** is a feature in C# where multiple methods can have the same name but different parameters (different type, number, or both). It allows methods to perform similar functions with different types of inputs.

**Ways to overload a method:**

1. **By Changing the Number of Parameters:**

   ```csharp
   public void Display(int a) { }
   public void Display(int a, int b) { }
   ```

2. **By Changing the Type of Parameters:**

   ```csharp
   public void Display(int a) { }
   public void Display(string a) { }
   ```

3. **By Changing the Order of Parameters:**

   ```csharp
   public void Display(int a, string b) { }
   public void Display(string a, int b) { }
   ```

### Q21. When should you use method overloading in real applications?

**Method Overloading** is useful in scenarios where you need to perform similar operations but with different types or numbers of inputs. It improves code readability and usability by allowing a single method name to handle various types of input.

**When to use:**

1. **When performing similar operations:** If you have multiple ways to perform a similar operation with different input types, use overloading.
   - *Example:* A `Print` method that handles different types of data (e.g., `Print(string message)`, `Print(int number)`).

2. **When you want to provide a cleaner API:** Overloading allows you to use the same method name, making the API more intuitive.
   - *Example:* A class with methods to calculate area for different shapes: `CalculateArea(double radius)`, `CalculateArea(double width, double height)`.

3. **When simplifying method names:** Using overloading can reduce the number of method names and improve clarity.
   - *Example:* `Add(int a, int b)` and `Add(double a, double b)` in a calculator class.

### Q22. If two methods are the same except return type, then methods are overloaded or what will happen?

Methods cannot be overloaded based solely on return type. In C#, method overloading requires differences in parameter types, number of parameters, or both. If two methods have the same name and parameter list but differ only in return type, it will result in a compilation error.

**Example of Incorrect Overloading:**

```csharp
public class Example
{
    public int GetValue() { return 1; }
    public double GetValue() { return 1.0; } // Error: Method with the same name and parameters
}
```

### Q23. What is the difference between Overloading and Overriding?

**Method Overloading** and **Method Overriding** are two different concepts:

- **Method Overloading:** Refers to defining multiple methods with the same name but different parameters within the same class. It is a compile-time polymorphism.
  - *Example:*

    ```csharp
    public class Printer
    {
        public void Print(string message) { }
        public void Print(int number) { }
    }
    ```

- **Method Overriding:** Refers to redefining a method in a derived class that was originally defined in a base class. It is a run-time polymorphism and requires the method in the base class to be marked as `virtual` and the method in the derived class to be marked as `override`.
  - *Example:*

    ```csharp
    public class BaseClass
    {
        public virtual void Display() { Console.WriteLine("BaseClass Display"); }
    }

    public class DerivedClass : BaseClass
    {
        public override void Display() { Console.WriteLine("DerivedClass Display"); }
    }
    ```

### Q24. What is the use of Overriding?

**Method Overriding** allows a derived class to provide a specific implementation of a method that is already defined in its base class. It is used to:

- **Customize behavior:** Provide specific behavior in a derived class while using a common interface.
- **Implement polymorphism:** Allow methods to be called on base class references but execute derived class implementations.

**Example:**

```csharp
public class Animal
{
    public virtual void MakeSound() { Console.WriteLine("Animal sound"); }
}

public class Dog : Animal
{
    public override void MakeSound() { Console.WriteLine("Bark"); }
}
```

### Q25. If a method is marked as virtual, do we must have to "override" it from the child class?

No, you are not required to override a `virtual` method in a derived class. If you do not override it, the base class implementation will be used.

**Example:**

```csharp
public class BaseClass
{
    public virtual void Display() { Console.WriteLine("BaseClass Display"); }
}

public class DerivedClass : BaseClass
{
    // Not overriding the Display method
}
```

In this case, calling `Display()` on an instance of `DerivedClass` will use the `BaseClass` implementation.

### Q26. What is the difference between Method Overriding and Method Hiding?

**Method Overriding** and **Method Hiding** have distinct differences:

- **Method Overriding:** Allows a derived class to provide a specific implementation for a method that is already defined in the base class. It requires the base class method to be marked as `virtual` and the derived class method to be marked as `override`.
  - *Example:*

    ```csharp
    public class BaseClass
    {
        public virtual void Display() { Console.WriteLine("BaseClass Display"); }
    }

    public class DerivedClass : BaseClass
    {
        public override void Display() { Console.WriteLine("DerivedClass Display"); }
    }
    ```

- **Method Hiding:** Allows a derived class to hide a method from the base class using the `new` keyword. This does not use polymorphism, and the method that gets called depends on the reference type.
  - *Example:*

    ```csharp
    public class BaseClass
    {
        public void Display() { Console.WriteLine("BaseClass Display"); }
    }

    public class DerivedClass : BaseClass
    {
        public new void Display() { Console.WriteLine("DerivedClass Display"); }
    }
    ```

### Q27. What is the difference between Abstract class and an Interface?

**Abstract Class:**

- Can contain implementation (fields, methods).
- Can have constructors and destructors.
- Supports access modifiers (public, protected, private).
- Can provide default behavior and state.

**Interface:**

- Can only contain method signatures (until C# 8.0, which allows default implementations).
- Cannot have constructors or destructors.
- Members are implicitly public.
- Represents a contract that classes must follow.

**Example:**

```csharp
// Abstract Class
public abstract class Vehicle
{
    public abstract void Start();
    public void Stop() { Console.WriteLine("Vehicle stopped"); }
}

// Interface
public interface IVehicle
{
    void Start();
}
```

### Q28. When to use Interface and when Abstract class in real applications?

**Use Interface when:**

- You need to define a contract that multiple classes can implement, regardless of their position in the class hierarchy.
- You want to achieve multiple inheritance.

**Use Abstract Class when:**

- You want to provide a common base with shared implementation and fields.
- You need to define some default behavior for the derived classes.

**Example:**

- **Interface:** Implementing a `IDriveable` interface for different types of vehicles (cars, bikes).
- **Abstract Class:** Creating a base `Vehicle` class with common functionality and abstract methods for specific vehicle types.

### Q29. Why to create Interfaces in real applications?

Interfaces provide a way to define a contract that multiple classes can adhere to. They are useful for:

- **Decoupling:** Allows different parts of a system to interact with each other without needing to know the specific implementations.
- **Multiple Inheritance:** Enables a class to implement multiple interfaces.
- **Testability:** Facilitates mocking and stubbing in unit testing.

**Example:**

```csharp
public interface IEngine
{
    void Start();
    void Stop();
}

public class Car : IEngine
{
    public void Start() { Console.WriteLine("Car engine started"); }
    public void Stop() { Console.WriteLine("Car engine stopped"); }
}
```

### Q30. Can we define body of Interfaces methods? When to define methods in Interfaces?

In C# 8.0 and later, you can define default implementations for methods in interfaces. Before C# 8.0, interfaces could only contain method signatures.

**When to define methods in Interfaces:**

- Use default methods in interfaces when you want to provide a default behavior but still allow classes to override it if needed.

**Example:**

```csharp
public interface ILogger
{
    void Log(string message);

    // Default implementation
    void LogError(string message)
    {
        Console.WriteLine($"Error: {message}");
    }
}

public class ConsoleLogger : ILogger
{
    public void Log(string message) { Console.WriteLine(message); }
}
```

### Q31. Can you create an instance of an Abstract class or an Interface?

**No**, you cannot create an instance of an abstract class or an interface directly. They are meant to provide a common base or contract for derived classes to implement or extend.

- **Abstract Class:** It can be instantiated only through a derived class that implements its abstract methods.
- **Interface:** It can be implemented by a class, which can then be instantiated.

**Example:**

```csharp
public abstract class Animal
{
    public abstract void MakeSound();
}

public class Dog : Animal
{
    public override void MakeSound() { Console.WriteLine("Bark"); }
}

// Animal animal = new Animal(); // Error: Cannot create an instance of the abstract class 'Animal'
Animal dog = new Dog(); // Valid
```

### Q32. Do Interfaces have Constructors?

**No**, interfaces cannot have constructors. They only define method signatures and properties that classes must implement. Constructors are used to initialize class instances, which is not applicable to interfaces.

**Example:**

```csharp
public interface IExample
{
    // No constructors allowed here
}
```

### Q33. Do Abstract classes have Constructors in C#?

**Yes**, abstract classes can have constructors. These constructors can be used to initialize fields or perform setup operations when a derived class instance is created. However, abstract classes cannot be instantiated directly.

**Example:**

```csharp
public abstract class BaseClass
{
    public BaseClass() { Console.WriteLine("BaseClass constructor"); }
}

public class DerivedClass : BaseClass
{
    public DerivedClass() { Console.WriteLine("DerivedClass constructor"); }
}
```

### Q34. What is the difference between abstraction and an abstract class?

- **Abstraction:** It is a broader concept that involves hiding the complex implementation details and showing only the essential features. Abstraction can be achieved through abstract classes or interfaces.
- **Abstract Class:** It is a specific implementation of abstraction that can include abstract methods (without implementation) and concrete methods (with implementation). Abstract classes are used to provide a common base for other classes.

**Example:**

- **Abstraction:** Abstracting the concept of a `Shape` which might include different types like `Circle`, `Rectangle`, etc.
- **Abstract Class:** Defining a `Shape` abstract class with an abstract method `Draw()`.

### Q35. Can Abstract classes be Sealed or Static in C#?

**No**, abstract classes cannot be `sealed` or `static`:

- **Sealed:** A `sealed` class cannot be inherited. Since an abstract class is intended to be inherited, marking it as `sealed` is contradictory.
- **Static:** A `static` class cannot be instantiated, and since abstract classes are meant to be extended, marking them as `static` is not allowed.

### Q36. Can Abstract methods be private in C#?

**No**, abstract methods cannot be private. Abstract methods must be accessible to derived classes so they can override them. Typically, abstract methods are declared `public` or `protected`.

**Example:**

```csharp
public abstract class BaseClass
{
    // Abstract method must be public or protected
    public abstract void Display();
}
```

### Q37. Does an Abstract class support multiple Inheritance?

**No**, an abstract class does not support multiple inheritance directly. C# does not allow a class (abstract or otherwise) to inherit from more than one class. However, an abstract class can implement multiple interfaces.

**Example:**

```csharp
public abstract class BaseClass
{
    // Abstract class cannot inherit from multiple classes
}

public interface IFirst { }
public interface ISecond { }

public abstract class ConcreteClass : IFirst, ISecond
{
    // Can implement multiple interfaces
}
```

### Q38. What are Access Specifiers?

**Access specifiers** (or access modifiers) are keywords used to define the visibility and accessibility of classes, methods, and other members in C#. They determine how and where a class or member can be accessed.

- **`public`**: Accessible from anywhere.
- **`private`**: Accessible only within the class or struct in which it is declared.
- **`protected`**: Accessible within its own class and by derived classes.
- **`internal`**: Accessible within the same assembly.
- **`protected internal`**: Accessible within the same assembly and also by derived classes.

### Q39. What is the internal access modifier? Show an example

**`internal`** access modifier specifies that the member is accessible only within the same assembly. It is used to restrict access to types and members to within the project (or assembly) where they are defined.

**Example:**

```csharp
// File: InternalExample.cs
internal class InternalClass
{
    internal void InternalMethod() { Console.WriteLine("Internal method"); }
}

// File: AnotherClass.cs (same assembly)
public class AnotherClass
{
    public void Test()
    {
        InternalClass ic = new InternalClass();
        ic.InternalMethod(); // Accessible
    }
}
```

### Q40. What is the default access modifier in a class?

**The default access modifier** for a class in C# is `internal`. If no access modifier is specified, the class is accessible only within the same assembly.

**Example:**

```csharp
// Default access modifier for this class is 'internal'
class DefaultClass
{
    public void Show() { Console.WriteLine("Default access modifier"); }
}
```

### Q41. What is Boxing and Unboxing?

**Boxing** is the process of converting a value type (e.g., `int`, `float`) to an object type or to an interface type that the value type implements. This involves wrapping the value in an object.

**Unboxing** is the reverse process where an object type or an interface type is converted back to a value type.

**Example:**

```csharp
int number = 123; // Value type
object obj = number; // Boxing

int unboxedNumber = (int)obj; // Unboxing
```

### Q42. Which one is explicit, Boxing or Unboxing?

**Unboxing** is explicit. You must explicitly cast the object back to its original value type during unboxing. Boxing is implicit, occurring automatically when a value type is assigned to an object type.

**Example:**

```csharp
object obj = 123; // Implicit boxing
int number = (int)obj; // Explicit unboxing
```

### Q43. Is Boxing and Unboxing good for performance?

**Boxing and Unboxing** can be costly in terms of performance. Boxing involves allocating memory on the heap and copying the value type into an object, which can be slower than working with value types directly. Unboxing requires a type conversion and is also less efficient.

**In performance-critical applications**, minimizing boxing and unboxing operations is advised.

### Q44. What are the basic string operations in C#?

Basic string operations in C# include:

- **Concatenation:** Combining strings using `+` or `String.Concat`.

  ```csharp
  string fullName = firstName + " " + lastName;
  ```

- **Substring:** Extracting a part of a string.

  ```csharp
  string sub = fullName.Substring(0, 5);
  ```

- **Length:** Getting the length of a string.

  ```csharp
  int length = fullName.Length;
  ```

- **IndexOf:** Finding the position of a character or substring.

  ```csharp
  int index = fullName.IndexOf("Smith");
  ```

- **Replace:** Replacing a substring with another string.

  ```csharp
  string newString = fullName.Replace("Smith", "Johnson");
  ```

- **ToUpper/ToLower:** Converting to uppercase or lowercase.

  ```csharp
  string upper = fullName.ToUpper();
  string lower = fullName.ToLower();
  ```

- **Trim:** Removing leading and trailing whitespace.

  ```csharp
  string trimmed = fullName.Trim();
  ```

### Q45. What is the difference between `String` and `StringBuilder`?

- **`String`:** Immutable. Every modification creates a new string instance, which can be inefficient if many changes are made to the string.

- **`StringBuilder`:** Mutable. Designed for scenarios where the string is modified frequently, as it allows modifications without creating new instances each time.

**Example:**

```csharp
// String (Immutable)
string str = "Hello";
str += " World"; // New string is created

// StringBuilder (Mutable)
StringBuilder sb = new StringBuilder("Hello");
sb.Append(" World"); // Modifies existing instance
```

### Q46. When to use `String` and when `StringBuilder` in real applications?

- **Use `String`:** When dealing with a small number of string operations or when the string is not modified frequently. It is simpler and more straightforward for constant or infrequently changing strings.

- **Use `StringBuilder`:** When performing many modifications on a string, such as in loops or when concatenating many strings. It improves performance by reducing the number of intermediate string instances created.

### Q47. What is String Interpolation in C#?

**String Interpolation** is a feature that allows you to embed expressions within string literals. It uses the `$` symbol before the string and `{}` braces to include variables and expressions directly within the string.

**Example:**

```csharp
string name = "John";
int age = 30;
string message = $"Hello, my name is {name} and I am {age} years old.";
```

### Q48. What are the Loop types in C#? When to use what in real applications?

The main loop types in C# are:

1. **`for` Loop:** Best for when the number of iterations is known beforehand or you need to use a loop counter.

   ```csharp
   for (int i = 0; i < 10; i++)
   {
       Console.WriteLine(i);
   }
   ```

2. **`while` Loop:** Use when the number of iterations is not known in advance and you want to continue looping until a condition is met.

   ```csharp
   int i = 0;
   while (i < 10)
   {
       Console.WriteLine(i);
       i++;
   }
   ```

3. **`do-while` Loop:** Similar to `while`, but ensures the loop body is executed at least once.

   ```csharp
   int i = 0;
   do
   {
       Console.WriteLine(i);
       i++;
   } while (i < 10);
   ```

4. **`foreach` Loop:** Best for iterating over collections or arrays.

   ```csharp
   string[] names = { "Alice", "Bob", "Charlie" };
   foreach (string name in names)
   {
       Console.WriteLine(name);
   }
   ```

### Q49. What is the difference between `continue` and `break` statement?

- **`continue`:** Skips the remaining code inside the loop for the current iteration and proceeds to the next iteration.

  ```csharp
  for (int i = 0; i < 10; i++)
  {
      if (i % 2 == 0) continue; // Skip even numbers
      Console.WriteLine(i);
  }
  ```

- **`break`:** Exits the loop entirely, regardless of the iteration or condition.

  ```csharp
  for (int i = 0; i < 10; i++)
  {
      if (i == 5) break; // Exit the loop when i is 5
      Console.WriteLine(i);
  }
  ```

### Q50. What are the alternative ways of writing if-else conditions? When to use what?

- **`if-else if-else` Statement:** Standard way of branching based on multiple conditions.

  ```csharp
  if (x < 0)
  {
      Console.WriteLine("Negative");
  }
  else if (x == 0)
  {
      Console.WriteLine("Zero");
  }
  else
  {
      Console.WriteLine("Positive");
  }
  ```

- **`switch` Statement:** Useful for handling multiple discrete values of a variable.

  ```csharp
  switch (day)
  {
      case "Monday":
          Console.WriteLine("Start of the week");
          break;
      case "Friday":
          Console.WriteLine("End of the work week");
          break;
      default:
          Console.WriteLine("Regular day");
          break;
  }
  ```

- **Ternary Operator:** Short-hand for simple `if-else` conditions. Useful for inline conditional assignments.

  ```csharp
  int max = (a > b) ? a : b;
  ```

- **Null-Coalescing Operator:** Provides a default value when an expression evaluates to `null`.

  ```csharp
  string name = userName ?? "Guest";
  ```

### Q51. How to implement Exception Handling in C#?

**Exception Handling** in C# is implemented using `try`, `catch`, `finally`, and `throw` blocks. Here’s a brief overview:

- **`try` Block:** Contains code that may throw an exception.
- **`catch` Block:** Catches and handles the exception. You can have multiple `catch` blocks to handle different types of exceptions.
- **`finally` Block:** Executes code regardless of whether an exception was thrown or not, typically used for cleanup operations.
- **`throw` Statement:** Used to throw an exception explicitly.

**Example:**

```csharp
try
{
    int[] numbers = { 1, 2, 3 };
    int number = numbers[5]; // This will throw an IndexOutOfRangeException
}
catch (IndexOutOfRangeException ex)
{
    Console.WriteLine("An index out of range error occurred: " + ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine("A general error occurred: " + ex.Message);
}
finally
{
    Console.WriteLine("This will always be executed.");
}
```

### Q52. Can we execute multiple Catch blocks?

**Yes**, you can have multiple `catch` blocks to handle different types of exceptions. Each `catch` block can handle a different exception type, allowing for more granular error handling.

**Example:**

```csharp
try
{
    // Code that may throw exceptions
}
catch (FileNotFoundException ex)
{
    // Handle file not found exceptions
}
catch (IOException ex)
{
    // Handle general IO exceptions
}
catch (Exception ex)
{
    // Handle all other exceptions
}
```

### Q53. When to use Finally in real applications?

**`finally`** is used to ensure that specific code runs regardless of whether an exception was thrown or not. It is commonly used for cleanup tasks such as closing file handles, releasing resources, or resetting states.

**Example:**

```csharp
FileStream fileStream = null;
try
{
    fileStream = new FileStream("file.txt", FileMode.Open);
    // Perform file operations
}
catch (IOException ex)
{
    Console.WriteLine("File error: " + ex.Message);
}
finally
{
    if (fileStream != null)
    {
        fileStream.Close(); // Ensure the file stream is closed
    }
}
```

### Q54. Can we have only “Try” block without “Catch” block in real applications?

**Yes**, you can have a `try` block without a `catch` block, but you must include a `finally` block if you are omitting `catch`. This is used to guarantee that certain code will be executed regardless of whether an exception occurs.

**Example:**

```csharp
try
{
    // Code that may throw an exception
}
finally
{
    // Code that will always run
}
```

### Q55. What is the difference between Finally and Finalize?

- **`finally`:** Part of exception handling, used to execute code regardless of whether an exception was thrown. It ensures cleanup and resource deallocation.

- **`Finalize`:** A method called by the garbage collector before an object is reclaimed. It is used for resource cleanup when an object is being collected. It is not part of exception handling.

**Example of Finalize:**

```csharp
public class MyClass
{
    ~MyClass() // Finalizer
    {
        // Cleanup code
    }
}
```

### Q56. What is the difference between “throw ex” and “throw”? Which one to use in real applications?

- **`throw ex`:** Re-throws the exception but resets the stack trace, making it harder to trace where the exception originated from.

- **`throw`:** Re-throws the current exception while preserving the original stack trace, providing more accurate debugging information.

**Use `throw`** in real applications to maintain the stack trace and aid in debugging.

**Example:**

```csharp
try
{
    // Code that may throw an exception
}
catch (Exception ex)
{
    // Log the exception
    throw; // Preserve the original stack trace
}
```

### Q57. Explain Generics in C#? When and why to use?

**Generics** allow you to define classes, interfaces, and methods with a placeholder for the type of data they store or operate on. They provide type safety and performance improvements by allowing code to be reused with different types without boxing/unboxing or type casting.

**When and Why to Use:**

- **Type Safety:** Avoid runtime errors by catching type mismatches at compile-time.
- **Performance:** Avoid boxing/unboxing and type conversions.
- **Code Reuse:** Write more flexible and reusable code.

**Example:**

```csharp
public class GenericClass<T>
{
    private T _value;

    public void SetValue(T value)
    {
        _value = value;
    }

    public T GetValue()
    {
        return _value;
    }
}
```

### Q58. What are Collections in C# and what are their types?

**Collections** are classes that hold and manage groups of objects. They provide a way to store and manipulate data.

**Types of Collections:**

1. **`Array`:** Fixed-size collection of elements of the same type.

   ```csharp
   int[] numbers = { 1, 2, 3 };
   ```

2. **`ArrayList`:** Non-generic collection that can store any type of object.

   ```csharp
   ArrayList list = new ArrayList();
   list.Add(1);
   list.Add("string");
   ```

3. **`List<T>`:** Generic collection that stores elements of the same type.

   ```csharp
   List<int> list = new List<int>();
   list.Add(1);
   ```

4. **`Dictionary<TKey, TValue>`:** Generic collection that stores key-value pairs.

   ```csharp
   Dictionary<string, int> dictionary = new Dictionary<string, int>();
   dictionary.Add("key", 1);
   ```

5. **`Queue<T>`:** Generic collection for storing objects in a FIFO (first-in, first-out) manner.

   ```csharp
   Queue<int> queue = new Queue<int>();
   queue.Enqueue(1);
   ```

6. **`Stack<T>`:** Generic collection for storing objects in a LIFO (last-in, first-out) manner.

   ```csharp
   Stack<int> stack = new Stack<int>();
   stack.Push(1);
   ```

### Q59. What is the difference between Array and ArrayList (at least 2)?

1. **Type Safety:**
   - **Array:** Type-safe; can store only elements of the same type.
   - **ArrayList:** Not type-safe; can store elements of any type, which may lead to runtime errors.

2. **Performance:**
   - **Array:** Generally better performance because it is a fixed-size collection and avoids boxing/unboxing.
   - **ArrayList:** Slower because it involves boxing/unboxing of value types and has additional overhead due to its ability to store any type.

**Example:**

```csharp
int[] numbersArray = { 1, 2, 3 }; // Type-safe
ArrayList list = new ArrayList();
list.Add(1);
list.Add("string"); // Not type-safe
```

### Q60. What is the difference between ArrayList and Hashtable?

1. **Purpose:**
   - **ArrayList:** Stores a collection of objects in a list format, allowing for index-based access.
   - **Hashtable:** Stores key-value pairs, providing a way to quickly look up values based on keys.

2. **Indexing:**
   - **ArrayList:** Accesses elements by index.
   - **Hashtable:** Accesses elements by key.

**Example:**

```csharp
// ArrayList
ArrayList list = new ArrayList();
list.Add("Item1");
list.Add(2);
Console.WriteLine(list[0]); // Access by index

// Hashtable
Hashtable hashtable = new Hashtable();
hashtable.Add("key1", "value1");
hashtable.Add("key2", "value2");
Console.WriteLine(hashtable["key1"]); // Access by key
```

### Q61. What is the difference between List and Dictionary Collections?

**`List<T>`** and **`Dictionary<TKey, TValue>`** are both generic collections in C#, but they have different purposes and characteristics:

1. **Purpose:**
   - **`List<T>`:** A collection that stores a sequence of elements. Elements are accessed by their index.
   - **`Dictionary<TKey, TValue>`:** A collection that stores key-value pairs. Values are accessed by their associated keys.

2. **Access:**
   - **`List<T>`:** Access elements by index (e.g., `list[0]`).
   - **`Dictionary<TKey, TValue>`:** Access elements by key (e.g., `dictionary["key"]`).

3. **Ordering:**
   - **`List<T>`:** Maintains the order of elements based on their insertion.
   - **`Dictionary<TKey, TValue>`:** Does not guarantee order; the order of elements is based on the hashing of keys.

**Example:**

```csharp
// List<T>
List<int> numbers = new List<int> { 1, 2, 3 };
int firstNumber = numbers[0]; // Access by index

// Dictionary<TKey, TValue>
Dictionary<string, int> ageMap = new Dictionary<string, int>
{
    { "Alice", 30 },
    { "Bob", 25 }
};
int aliceAge = ageMap["Alice"]; // Access by key
```

### Q62. What is `IEnumerable` in C#?

**`IEnumerable<T>`** is an interface that defines a collection that can be enumerated. It is the base interface for all non-generic collections that can be iterated over. It provides the `GetEnumerator` method, which returns an `IEnumerator<T>` that allows for iteration over the collection.

**Example:**

```csharp
public IEnumerable<int> GetNumbers()
{
    return new List<int> { 1, 2, 3 };
}
```

### Q63. What is the difference between `IEnumerable` and `IEnumerator` in C#?

- **`IEnumerable<T>`:** An interface that defines a collection that can be iterated over. It provides the `GetEnumerator` method which returns an `IEnumerator<T>`. `IEnumerable<T>` is used to represent a collection of items that can be enumerated.

- **`IEnumerator<T>`:** An interface that provides the mechanism to iterate over the collection. It includes methods like `MoveNext` to advance to the next element and `Current` to access the current element.

**Example:**

```csharp
// IEnumerable<T>
public IEnumerable<int> GetNumbers()
{
    return new List<int> { 1, 2, 3 };
}

// IEnumerator<T>
public void PrintNumbers(IEnumerable<int> numbers)
{
    IEnumerator<int> enumerator = numbers.GetEnumerator();
    while (enumerator.MoveNext())
    {
        Console.WriteLine(enumerator.Current);
    }
}
```

### Q64. What is the difference between `IEnumerable` and `IQueryable` in C#?

- **`IEnumerable<T>`:** Represents a collection of objects that can be enumerated. It is best used for in-memory collections where the query is executed locally.

- **`IQueryable<T>`:** Represents a collection of objects that can be queried using LINQ to SQL or LINQ to Entities. It is used for querying data from external sources like databases, where the query is translated into a query expression (e.g., SQL).

**Example:**

```csharp
// IEnumerable<T>
public IEnumerable<int> GetNumbers()
{
    return new List<int> { 1, 2, 3 };
}

// IQueryable<T>
public IQueryable<int> GetNumbersQuery()
{
    var numbers = new List<int> { 1, 2, 3 }.AsQueryable();
    return numbers.Where(n => n > 1); // The query is translated to SQL when executed
}
```

### Q65. What is a Constructor? When to use constructor in real applications?

A **constructor** is a special method used to initialize objects of a class. It is called when an instance of the class is created. Constructors can be used to set default values, establish connections, or perform other initialization tasks.

**When to Use:**

- To initialize object properties when the object is created.
- To perform setup tasks or validations before the object is used.
- To enforce certain invariants or conditions on object creation.

**Example:**

```csharp
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    // Constructor
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
```

### Q66. What are the types of constructors?

1. **Default Constructor:** A constructor with no parameters. Automatically provided if no other constructors are defined.

   ```csharp
   public Person()
   {
   }
   ```

2. **Parameterized Constructor:** A constructor that takes parameters to initialize object properties.

   ```csharp
   public Person(string name, int age)
   {
       Name = name;
       Age = age;
   }
   ```

3. **Static Constructor:** A constructor that initializes static members of the class. It cannot take parameters and is called once for the class, not for instances.

   ```csharp
   static Person()
   {
       // Initialize static members
   }
   ```

### Q67. What is Default Constructor?

A **default constructor** is a constructor that takes no parameters. If no constructors are defined in a class, the compiler provides a default constructor automatically. It initializes all instance fields to their default values.

**Example:**

```csharp
public class Person
{
    public string Name;
    public int Age;

    // Default constructor
    public Person()
    {
        Name = "Unknown";
        Age = 0;
    }
}
```

### Q68. What is Parameterized Constructor?

A **parameterized constructor** is a constructor that takes one or more parameters. It is used to initialize object properties with specific values provided at the time of object creation.

**Example:**

```csharp
public class Person
{
    public string Name;
    public int Age;

    // Parameterized constructor
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
```

### Q69. What is Static Constructor? What is the use in real applications?

A **static constructor** is a constructor used to initialize static members of a class. It is called once, before any static members are accessed or any static methods are called. Static constructors cannot take parameters and are useful for setting up static resources or initializing static fields.

**Use in Real Applications:**

- To initialize static fields or properties.
- To perform setup tasks that are needed once for the class, rather than for each instance.

**Example:**

```csharp
public class Logger
{
    public static string LogFilePath;

    // Static constructor
    static Logger()
    {
        LogFilePath = "logfile.txt";
    }
}
```

### Q70. Can we have parameters or access modifiers in static constructor?

- **Parameters:** No, static constructors cannot have parameters.
- **Access Modifiers:** Static constructors cannot have access modifiers. They are always private by default.

**Example:**

```csharp
public class Example
{
    static Example()
    {
        // Static constructor
    }
}
```

### Q71. What is a Copy Constructor?

A **copy constructor** is a special constructor used to create a new object as a copy of an existing object. It initializes the new object with the values from the existing object.

**Example:**

```csharp
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    // Copy constructor
    public Person(Person other)
    {
        Name = other.Name;
        Age = other.Age;
    }
}

// Usage
Person original = new Person { Name = "Alice", Age = 30 };
Person copy = new Person(original);
```

### Q72. What is a Private Constructor? What is the use?

A **private constructor** is a constructor that cannot be accessed from outside the class. It is used to restrict object creation from outside the class and can be useful for implementing singleton patterns or factory methods.

**Example:**

```csharp
public class Singleton
{
    private static Singleton instance;

    // Private constructor
    private Singleton()
    {
    }

    public static Singleton GetInstance()
    {
        if (instance == null)
        {
            instance = new Singleton();
        }
        return instance;
    }
}
```

### Q73. What is Constructor Overloading?

**Constructor overloading** occurs when a class has multiple constructors with different parameter lists. It allows for different ways to initialize objects of the class.

**Example:**

```csharp
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    // Default constructor
    public Person()
    {
    }

    // Parameterized constructor
    public Person(string name)
    {
        Name = name;
    }

    // Another parameterized constructor
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
```

### Q74. What is a Destructor?

A **destructor** is a special method used to clean up resources before an object is reclaimed by the garbage collector. In C#, destructors are not called explicitly but are automatically invoked by the garbage collector.

**Example:**

```csharp
public class Resource
{
    ~Resource() // Destructor
    {
        // Cleanup code
    }
}
```

### Q75. Can you create an object of a class with a private constructor in C#?

**No**, you cannot create an instance of a class with a private constructor from outside the class. However, you can create instances from within the class itself or through static methods or properties.

**Example:**

```csharp
public class MyClass
{
    private MyClass()
    {
    }

    public static MyClass CreateInstance()
    {
        return new MyClass();
    }
}

// Usage
MyClass obj = MyClass.CreateInstance(); // Allowed
```

### Q76. If the base class and child class both have constructors, which one will be called first when a derived class object is created?

When creating an object of a derived class, the base class constructor is called first, followed by the derived class constructor. This ensures that the base class is properly initialized before the derived class initialization.

**Example:**

```csharp
public class BaseClass
{
    public BaseClass()
    {
        Console.WriteLine("BaseClass constructor");
    }
}

public class DerivedClass : BaseClass
{
    public DerivedClass()
    {
        Console.WriteLine("DerivedClass constructor");
    }
}

// Usage
DerivedClass obj = new DerivedClass();
// Output:
// BaseClass constructor
// DerivedClass constructor
```

### Q77. What is a Method in C#?

A **method** is a block of code that performs a specific task. Methods can take parameters, perform operations, and return a result. They are used to define the behavior of a class.

**Example:**

```csharp
public class Calculator
{
    // Method to add two numbers
    public int Add(int a, int b)
    {
        return a + b;
    }
}
```

### Q78. What is the difference between Pass by Value and Pass by Reference Parameters?

- **Pass by Value:** A copy of the argument is passed to the method. Changes made to the parameter inside the method do not affect the original argument.

- **Pass by Reference:** The reference to the original argument is passed to the method. Changes made to the parameter inside the method affect the original argument.

**Example:**

```csharp
// Pass by Value
public void PassByValue(int x)
{
    x = 10;
}

// Pass by Reference
public void PassByReference(ref int x)
{
    x = 10;
}

int a = 5;
PassByValue(a);
Console.WriteLine(a); // Output: 5

int b = 5;
PassByReference(ref b);
Console.WriteLine(b); // Output: 10
```

### Q79. How to return more than one value from a method in C#?

You can return more than one value from a method using various approaches:

1. **Using Tuples:**

   ```csharp
   public (int, string) GetPersonDetails()
   {
       return (30, "Alice");
   }

   var details = GetPersonDetails();
   Console.WriteLine(details.Item1); // 30
   Console.WriteLine(details.Item2); // Alice
   ```

2. **Using Out Parameters:**

   ```csharp
   public void GetPersonDetails(out int age, out string name)
   {
       age = 30;
       name = "Alice";
   }

   GetPersonDetails(out int age, out string name);
   Console.WriteLine(age); // 30
   Console.WriteLine(name); // Alice
   ```

3. **Using Custom Classes:**

   ```csharp
   public class PersonDetails
   {
       public int Age { get; set; }
       public string Name { get; set; }
   }

   public PersonDetails GetPersonDetails()
   {
       return new PersonDetails { Age = 30, Name = "Alice" };
   }

   PersonDetails details = GetPersonDetails();
   Console.WriteLine(details.Age); // 30
   Console.WriteLine(details.Name); // Alice
   ```

### Q80. What is the difference between `out` and `ref` parameters?

- **`out` Parameters:** Used to return multiple values from a method. Variables passed as `out` parameters do not need to be initialized before being passed to the method, but they must be assigned a value before the method exits.

- **`ref` Parameters:** Used to pass variables by reference, allowing the method to modify the variable's value. Variables passed as `ref` parameters must be initialized before being passed to the method.

**Example:**

```csharp
// Out Parameter
public void GetDetails(out int age, out string name)
{
    age = 30;
    name = "Alice";
}

// Ref Parameter
public void UpdateValue(ref int value)
{
    value = 100;
}

int a;
GetDetails(out a, out string name); // `a` is not initialized before use

int b = 10;
UpdateValue(ref b); // `b` must be initialized before use
```

### Q81. What is the `params` keyword? When to use the `params` keyword in real applications?

The **`params`** keyword in C# allows a method to accept a variable number of arguments. It is used to pass an arbitrary number of arguments to a method in the form of an array.

**When to Use:**

- When you want to provide flexibility in method parameters without requiring the caller to create an array explicitly.
- Useful for methods that need to handle a variable number of inputs, such as logging, formatting, or aggregating values.

**Example:**

```csharp
public void PrintNumbers(params int[] numbers)
{
    foreach (var number in numbers)
    {
        Console.WriteLine(number);
    }
}

// Usage
PrintNumbers(1, 2, 3, 4, 5); // No need to create an array
```

### Q82. What are Optional Parameters in a Method?

**Optional parameters** allow you to omit arguments when calling a method. They are specified with default values in the method definition. If no value is provided, the default value is used.

**Example:**

```csharp
public void Greet(string name, string greeting = "Hello")
{
    Console.WriteLine($"{greeting}, {name}!");
}

// Usage
Greet("Alice"); // Uses default greeting
Greet("Bob", "Hi"); // Uses specified greeting
```

### Q83. What are Named Parameters in a Method?

**Named parameters** allow you to specify arguments by name when calling a method, making the code more readable and allowing you to pass arguments in any order.

**Example:**

```csharp
public void RegisterUser(string username, string email, bool isAdmin = false)
{
    // Method implementation
}

// Usage
RegisterUser(email: "alice@example.com", username: "alice", isAdmin: true);
```

### Q84. What are Extension Methods in C#? When to use extension methods?

**Extension methods** allow you to add new methods to existing types without modifying the original type. They are defined as static methods in a static class but are called as if they were instance methods on the extended type.

**When to Use:**

- To add utility methods to existing types, especially when you do not have access to modify the original class.
- To improve code readability and encapsulation by providing additional methods in a fluent style.

**Example:**

```csharp
public static class StringExtensions
{
    public static bool IsPalindrome(this string str)
    {
        string reversed = new string(str.Reverse().ToArray());
        return str.Equals(reversed, StringComparison.OrdinalIgnoreCase);
    }
}

// Usage
bool result = "madam".IsPalindrome(); // Uses extension method
```

### Q85. What are Delegates in C#? When to use delegates in real applications?

**Delegates** are types that represent references to methods. They are used to pass methods as arguments, implement event handling, and define callback methods.

**When to Use:**

- To implement event handling.
- For defining callback methods or methods to be executed asynchronously.
- To create custom implementations of certain functionalities that are interchangeable.

**Example:**

```csharp
public delegate void Notify(string message);

public class Notification
{
    public event Notify OnNotify;

    public void SendNotification(string message)
    {
        OnNotify?.Invoke(message);
    }
}

// Usage
Notification notification = new Notification();
notification.OnNotify += msg => Console.WriteLine(msg);
notification.SendNotification("Hello, World!");
```

### Q86. What are Multicast Delegates?

**Multicast delegates** are delegates that can hold references to more than one method. When the delegate is invoked, all methods in the delegate's invocation list are called.

**Example:**

```csharp
public delegate void Notify(string message);

public class Notification
{
    public Notify OnNotify;

    public void SendNotification(string message)
    {
        OnNotify?.Invoke(message);
    }
}

// Usage
Notification notification = new Notification();
notification.OnNotify += msg => Console.WriteLine($"Message 1: {msg}");
notification.OnNotify += msg => Console.WriteLine($"Message 2: {msg}");
notification.SendNotification("Hello, World!");
// Output:
// Message 1: Hello, World!
// Message 2: Hello, World!
```

### Q87. What are Anonymous Delegates in C#?

**Anonymous delegates** are delegates defined inline without a named method. They are typically used for short-lived, one-off delegate implementations.

**Example:**

```csharp
public delegate void PrintDelegate(string message);

public class Example
{
    public void PrintMessage()
    {
        PrintDelegate print = delegate (string msg)
        {
            Console.WriteLine(msg);
        };
        print("Hello, World!");
    }
}
```

### Q88. What are the differences between Events and Delegates?

- **Delegates:** Are types that represent references to methods. They can be used to invoke methods directly.
- **Events:** Are a special kind of delegate that follow a publish-subscribe pattern. They provide a mechanism for notifying subscribers when an action occurs. Events encapsulate delegates, preventing direct invocation from outside the class that defines the event.

**Example:**

```csharp
public delegate void Notify(string message);

public class Publisher
{
    public event Notify OnNotify;

    public void RaiseEvent(string message)
    {
        OnNotify?.Invoke(message);
    }
}

public class Subscriber
{
    public void OnEventReceived(string message)
    {
        Console.WriteLine($"Event received: {message}");
    }
}

// Usage
Publisher publisher = new Publisher();
Subscriber subscriber = new Subscriber();
publisher.OnNotify += subscriber.OnEventReceived;
publisher.RaiseEvent("Hello, World!");
```

### Q89. What is the `this` keyword in C#? When to use it in real applications?

The **`this`** keyword refers to the current instance of the class. It is used to access instance members, differentiate between instance and local variables, and pass the current instance to other methods.

**When to Use:**

- To refer to the current instance's members when there is a name conflict.
- To pass the current object as a parameter to another method or constructor.

**Example:**

```csharp
public class Person
{
    public string Name { get; set; }

    public void SetName(string name)
    {
        this.Name = name; // Disambiguates between the instance field and parameter
    }
}
```

### Q90. What is the purpose of the `using` keyword in C#?

The **`using`** keyword serves two purposes:

1. **Resource Management:** Ensures that `IDisposable` objects are properly disposed of. The `using` statement automatically calls the `Dispose` method when the block of code is exited, either normally or due to an exception.

   **Example:**

   ```csharp
   using (var file = new StreamWriter("file.txt"))
   {
       file.WriteLine("Hello, World!");
   } // file.Dispose() is automatically called here
   ```

2. **Namespace Importing:** Imports namespaces to make the types in those namespaces available without fully qualifying them. This simplifies the code and improves readability.

   **Example:**

   ```csharp
   using System;
   using System.Collections.Generic;

   public class Example
   {
       public void PrintList(List<string> list)
       {
           foreach (var item in list)
           {
               Console.WriteLine(item);
           }
       }
   }
   ```

### Q91. Can we use the `using` keyword with other classes apart from `DbConnection`?

**Yes**, the `using` keyword can be used with any class that implements the `IDisposable` interface, not just `DbConnection`. The `using` statement ensures that the `Dispose` method is called on the object, releasing any resources it holds.

**Example:**

```csharp
public class MyResource : IDisposable
{
    public void Dispose()
    {
        // Cleanup resources
    }
}

// Usage
using (var resource = new MyResource())
{
    // Use resource
} // Dispose() is automatically called here
```

### Q92. What is the difference between `is` and `as` operators?

- **`is` Operator:** Checks if an object is of a specific type and returns a boolean value (`true` or `false`). It does not change the type of the object.

  **Example:**

  ```csharp
  object obj = "Hello";
  bool isString = obj is string; // true
  ```

- **`as` Operator:** Tries to cast an object to a specific type. If the cast fails, it returns `null` instead of throwing an exception.

  **Example:**

  ```csharp
  object obj = "Hello";
  string str = obj as string; // str will be "Hello"
  
  object num = 10;
  string result = num as string; // result will be null
  ```

### Q93. What is the difference between `Read-only` and `Constant` variables?

- **`const`:** Defines a compile-time constant. The value is set at compile time and cannot be changed. `const` fields are implicitly static.

  **Example:**

  ```csharp
  public const int MaxValue = 100;
  ```

- **`readonly`:** Defines a runtime constant. The value can be set at runtime (e.g., in a constructor) and cannot be modified after initialization. `readonly` fields can be instance-level or static.

  **Example:**

  ```csharp
  public readonly int MaxValue;

  public MyClass(int value)
  {
      MaxValue = value;
  }
  ```

### Q94. What is a `static` class? When to use a `static` class in a real application?

A **`static` class** is a class that cannot be instantiated and can only contain static members. It is used to group related utility or helper methods and properties that do not depend on instance data.

**When to Use:**

- To provide utility functions that do not need to maintain state.
- To group methods that are logically related but do not require object instantiation.

**Example:**

```csharp
public static class MathHelper
{
    public static int Add(int a, int b)
    {
        return a + b;
    }
}

// Usage
int result = MathHelper.Add(5, 10);
```

### Q95. What is the difference between `var` and `dynamic` in C#?

- **`var`:** Statically typed. The type of the variable is inferred at compile time based on the assigned value. `var` variables are strongly typed once assigned.

  **Example:**

  ```csharp
  var number = 10; // type inferred as int
  ```

- **`dynamic`:** Dynamically typed. The type of the variable is resolved at runtime. It allows operations and method calls that may not be checked at compile time.

  **Example:**

  ```csharp
  dynamic value = 10;
  value = "Hello"; // Allowed
  ```

### Q96. What is the `enum` keyword used for?

The **`enum`** keyword defines a set of named constants. Enums are used to represent a collection of related values in a type-safe way, improving code readability and maintainability.

**Example:**

```csharp
public enum DayOfWeek
{
    Sunday,
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday
}

// Usage
DayOfWeek today = DayOfWeek.Monday;
```

### Q97. Is it possible to inherit `enum` in C#?

**No**, enums cannot be inherited in C#. Enums are final types and cannot be extended or inherited. If you need to create related enums, you can define separate enums and use them together.

### Q98. What is the use of the `yield` keyword in C#?

The **`yield`** keyword is used in iterators to provide a value to the enumerator and then pause the method's execution. It allows you to create custom iterators for collections, making it easy to implement lazy evaluation.

**Example:**

```csharp
public IEnumerable<int> GetNumbers()
{
    yield return 1;
    yield return 2;
    yield return 3;
}

// Usage
foreach (var number in GetNumbers())
{
    Console.WriteLine(number);
}
```

### Q99. What is LINQ? When to use LINQ in real applications?

**LINQ** (Language Integrated Query) is a set of methods and syntax in C# that allows you to perform queries on collections of data (like arrays, lists, or databases) in a declarative manner. LINQ queries can be written using query syntax or method syntax.

**When to Use:**

- When you need to query collections or data sources in a readable and concise manner.
- To perform operations like filtering, sorting, and grouping on data collections.

**Example:**

```csharp
var numbers = new List<int> { 1, 2, 3, 4, 5 };
var evenNumbers = from number in numbers
                  where number % 2 == 0
                  select number;

foreach (var number in evenNumbers)
{
    Console.WriteLine(number);
}
```

### Q100. What are the advantages and disadvantages of LINQ?

**Advantages:**

- **Declarative Syntax:** Provides a readable and concise way to query and manipulate data.
- **Type Safety:** Offers compile-time checking of queries, reducing runtime errors.
- **Integration:** Works seamlessly with various data sources like arrays, collections, and databases.
- **Deferred Execution:** LINQ queries are executed only when the data is actually needed, improving performance.

**Disadvantages:**

- **Performance Overhead:** LINQ can introduce performance overhead compared to more direct data access methods.
- **Complexity:** LINQ queries can become complex and hard to understand if not used carefully, especially with advanced features like joins and grouping.
- **Limited to Supported Data Sources:** LINQ queries can only be used with data sources that support LINQ, which may require additional libraries or configurations.

### Q101. What are Lambda Expressions? What is their use in real applications?

**Lambda expressions** are a concise way to represent anonymous methods using a special syntax. They are often used to create inline delegate instances, particularly in LINQ queries and event handlers.

**Syntax:**

```csharp
(parameters) => expression_or_statement_block
```

**Example:**

```csharp
// Lambda expression to add two numbers
Func<int, int, int> add = (a, b) => a + b;
int result = add(5, 10); // result is 15
```

**Use in Real Applications:**

- **LINQ Queries:** Lambda expressions are frequently used in LINQ to perform operations like filtering, projection, and aggregation.
- **Event Handling:** They can simplify event handling by providing inline method definitions.
- **Functional Programming:** Useful in functional programming scenarios where methods are passed as arguments.

**Example in LINQ:**

```csharp
var numbers = new List<int> { 1, 2, 3, 4, 5 };
var evenNumbers = numbers.Where(n => n % 2 == 0);
```

### Q102. What is the difference between `First` and `FirstOrDefault` methods in LINQ?

- **`First`:** Returns the first element of a sequence. Throws an exception if the sequence is empty.

  **Example:**

  ```csharp
  var numbers = new List<int> { 1, 2, 3 };
  int firstNumber = numbers.First(); // Returns 1
  ```

- **`FirstOrDefault`:** Returns the first element of a sequence or a default value if the sequence is empty. For reference types, the default value is `null`. For value types, it is the default value of the type (e.g., 0 for integers).

  **Example:**

  ```csharp
  var numbers = new List<int> { 1, 2, 3 };
  int firstNumber = numbers.FirstOrDefault(); // Returns 1

  var emptyList = new List<int>();
  int defaultNumber = emptyList.FirstOrDefault(); // Returns 0
  ```

### Q103. What are the important components of the .NET framework?

The .NET Framework consists of several key components:

- **Common Language Runtime (CLR):** Manages memory, handles exceptions, and provides a runtime environment for executing .NET applications.
- **Framework Class Library (FCL):** Provides a large set of libraries and APIs for various functionalities like file I/O, network communication, and database access.
- **ASP.NET:** A framework for building web applications and services.
- **Windows Forms:** Provides a platform for developing desktop applications.
- **WPF (Windows Presentation Foundation):** A framework for building graphical user interfaces.
- **Entity Framework:** An Object-Relational Mapping (ORM) framework for database operations.
- **Base Class Library (BCL):** A subset of FCL, including fundamental classes like collections, I/O, and threading.

### Q104. What is an Assembly? What are the different types of assemblies?

An **assembly** is a compiled code library used by .NET applications. It contains code, resources, and metadata and is the fundamental unit of deployment and versioning in .NET.

**Types of Assemblies:**

- **Private Assembly:** Used by a single application and stored in the application’s directory.
- **Shared Assembly:** Intended to be shared by multiple applications and typically installed in the Global Assembly Cache (GAC).
- **Satellite Assembly:** Contains culture-specific resources used for localization.

**Example of Assembly:**

```csharp
// A simple class in an assembly
public class Greeting
{
    public string GetMessage() => "Hello, World!";
}
```

### Q105. What is the GAC?

The **Global Assembly Cache (GAC)** is a machine-wide cache used to store assemblies that are intended to be shared among multiple applications. It allows for the central management of shared assemblies, ensuring versioning and avoiding conflicts.

**Example:**

- Assemblies registered in GAC can be accessed by multiple applications on the same machine, avoiding the need to distribute multiple copies of the same assembly.

### Q106. What is Reflection?

**Reflection** is a feature in .NET that allows you to inspect and interact with the metadata of types, methods, properties, and other elements at runtime. It enables dynamic type discovery, method invocation, and object creation.

**Example:**

```csharp
Type type = typeof(String);
Console.WriteLine(type.FullName); // Outputs: System.String

MethodInfo method = type.GetMethod("ToUpper");
string result = (string)method.Invoke("hello", null);
Console.WriteLine(result); // Outputs: HELLO
```

### Q107. What are Serialization and Deserialization?

- **Serialization:** The process of converting an object into a format (e.g., JSON, XML, binary) that can be easily stored or transmitted. It is used to persist object state or communicate between systems.

  **Example:**

  ```csharp
  [Serializable]
  public class Person
  {
      public string Name { get; set; }
      public int Age { get; set; }
  }
  
  // Serialization
  var person = new Person { Name = "Alice", Age = 30 };
  var formatter = new BinaryFormatter();
  using (var stream = new FileStream("person.bin", FileMode.Create))
  {
      formatter.Serialize(stream, person);
  }
  ```

- **Deserialization:** The process of converting serialized data back into an object.

  **Example:**

  ```csharp
  // Deserialization
  Person deserializedPerson;
  using (var stream = new FileStream("person.bin", FileMode.Open))
  {
      deserializedPerson = (Person)formatter.Deserialize(stream);
  }
  ```

### Q108. What is meant by Globalization and Localization?

- **Globalization:** The process of designing and preparing applications to be adaptable to various cultures and regions. It involves creating software that can be easily adapted to different languages and formats.

- **Localization:** The process of adapting software for a specific culture or region by translating text and adjusting formats (e.g., date, currency).

**Example:**

- **Globalization:** Creating a software application that can be easily translated into different languages.
- **Localization:** Translating the user interface and messages of an application into French, German, etc.

### Q109. What are Windows Services?

**Windows Services** are long-running applications that run in the background on Windows operating systems. They can be configured to start automatically when the computer starts and run without user interaction.

**Example:**

- **File Monitoring Service:** A service that monitors changes in a directory and processes files as they are added or modified.

**Example Code:**

```csharp
public partial class MyService : ServiceBase
{
    protected override void OnStart(string[] args)
    {
        // Code to start the service
    }

    protected override void OnStop()
    {
        // Code to stop the service
    }
}
```

### Q110. What is Garbage Collection (GC)?

**Garbage Collection (GC)** is an automatic memory management feature in .NET that reclaims memory occupied by objects that are no longer in use. It helps to prevent memory leaks and manage memory efficiently by periodically freeing up memory that is no longer needed.

**Key Points:**

- **Generational Collection:** GC organizes objects into generations (young, middle-aged, old) to optimize the collection process.
- **Automatic:** The .NET runtime manages garbage collection, reducing the need for manual memory management.

**Example:**

- When objects are no longer referenced by any part of the application, the GC will eventually reclaim their memory to be reused.

### Q111. What are Generations in garbage collection?

In .NET, **generations** are used in the garbage collection process to optimize memory management. The idea is to segregate objects based on their age and frequency of allocation:

- **Generation 0:** Holds newly allocated objects. These objects are short-lived and are collected most frequently.
- **Generation 1:** Contains objects that have survived one garbage collection. These objects are considered to have a longer lifetime.
- **Generation 2:** Contains objects that have survived multiple garbage collections and are considered long-lived. Collection in this generation is less frequent but more comprehensive.

**Example:**
Objects that have been allocated and survived several garbage collection cycles will eventually end up in Generation 2, where they are collected less frequently to optimize performance.

### Q112. What is the difference between `Dispose` and `Finalize`?

- **`Dispose`:** Part of the `IDisposable` interface. It is used to release unmanaged resources deterministically (i.e., resources are released as soon as `Dispose` is called). It’s a method that should be explicitly called when you’re done using an object.

  **Example:**

  ```csharp
  public class MyResource : IDisposable
  {
      public void Dispose()
      {
          // Release unmanaged resources here
      }
  }
  ```

- **`Finalize`:** A method in the base `Object` class (also known as a destructor in C#). It is called by the garbage collector before an object is reclaimed to release unmanaged resources. It is non-deterministic, meaning you cannot control when it will be called.

  **Example:**

  ```csharp
  ~MyResource()
  {
      // Cleanup code
  }
  ```

### Q113. What is the difference between `Finalize` and `Finally` methods?

- **`Finalize`:** A special method (destructor) used to clean up unmanaged resources before an object is destroyed. It is called by the garbage collector and is non-deterministic.

- **`Finally`:** A block used in exception handling to ensure that code executes regardless of whether an exception occurs or not. It is used in `try-catch-finally` blocks.

  **Example:**

  ```csharp
  try
  {
      // Code that may throw an exception
  }
  catch (Exception ex)
  {
      // Handle exception
  }
  finally
  {
      // Code that always runs
  }
  ```

### Q114. Can we force Garbage Collector to run?

**Yes**, you can force garbage collection using the `GC.Collect` method, but it’s generally not recommended. The .NET garbage collector is optimized to determine the best time to collect objects, and manually forcing a collection can impact performance negatively.

**Example:**

```csharp
GC.Collect(); // Forces garbage collection
GC.WaitForPendingFinalizers(); // Waits for finalizers to complete
```

### Q115. What is the difference between Process and Thread?

- **Process:** A process is an independent program running in its own memory space. It has its own resources and execution context.

- **Thread:** A thread is a lightweight sub-process that shares the same memory space and resources with other threads in the same process. Threads within a process can execute concurrently and communicate with each other more efficiently.

**Example:**
A web server might have multiple processes handling different tasks (e.g., serving different users), and each process might use multiple threads to handle requests concurrently.

### Q116. Explain Multithreading

**Multithreading** is the concurrent execution of two or more threads within a single process. It allows a program to perform multiple operations simultaneously, making better use of CPU resources and improving application performance.

**Example:**

- A web browser can use one thread to handle user interface interactions and another thread to download files in the background.

### Q117. What is the difference between synchronous and asynchronous programming? What is the role of Task?

- **Synchronous Programming:** Tasks are executed one after another. Each task waits for the previous one to complete before starting.

  **Example:**

  ```csharp
  void SynchronousMethod()
  {
      var result1 = DoTask1();
      var result2 = DoTask2();
  }
  ```

- **Asynchronous Programming:** Tasks can start before others complete, allowing for operations to run concurrently. It helps improve responsiveness and efficiency.

  **Example:**

  ```csharp
  async Task AsynchronousMethod()
  {
      var task1 = DoTask1Async();
      var task2 = DoTask2Async();
      await Task.WhenAll(task1, task2);
  }
  ```

**Role of Task:**
`Task` represents an asynchronous operation. It provides a way to handle operations that run concurrently and helps manage asynchronous code more efficiently.

### Q118. What is the difference between Threads and Tasks? What are the advantages of Tasks over Threads?

- **Threads:** Represent individual paths of execution within a process. They are lower-level and require more manual management of concurrency.

- **Tasks:** Higher-level abstractions that represent asynchronous operations. They are part of the `System.Threading.Tasks` namespace and provide better support for managing concurrency and asynchronous operations.

**Advantages of Tasks:**

- **Simplified Syntax:** Easier to write and manage compared to raw threads.
- **Built-in Exception Handling:** Better support for handling exceptions in asynchronous operations.
- **Task Parallel Library (TPL):** Provides more efficient and scalable parallelism and concurrency management.

**Example:**

```csharp
// Using Task
Task.Run(() => DoWork());

// Using Thread
new Thread(() => DoWork()).Start();
```

### Q119. What is the role of `async` and `await`?

- **`async`:** A modifier used to declare a method as asynchronous. It allows the use of `await` within the method and enables the method to run asynchronously.

- **`await`:** An operator used to pause the execution of an `async` method until the awaited task completes. It helps write asynchronous code in a more readable and maintainable manner.

**Example:**

```csharp
public async Task<string> GetDataAsync()
{
    var data = await FetchDataFromWebAsync();
    return data;
}
```

### Q120. What is the difference between DBMS and RDBMS?

- **DBMS (Database Management System):** A system for managing databases that provides basic functions for storing and retrieving data. It may not enforce relationships between data or support complex queries.

- **RDBMS (Relational Database Management System):** A type of DBMS that stores data in tables with relationships between them. It supports complex queries, constraints, and transactions, and enforces data integrity through normalization.

**Examples:**

- **DBMS:** Microsoft Access, dBASE
- **RDBMS:** MySQL, PostgreSQL, Oracle Database

**Key Differences:**

- **Data Structure:** RDBMS uses tables with rows and columns, while DBMS may use various structures.
- **Relationships:** RDBMS supports relationships between tables, while DBMS may not.
- **Integrity Constraints:** RDBMS enforces data integrity constraints, while DBMS may not.

### Q121. What is a Constraint in SQL? What are the types of constraints?

**Constraint**: A constraint in SQL is a rule applied to columns in a table to enforce data integrity and restrict the types of data that can be inserted or updated. Constraints ensure that the data entered into a database conforms to certain rules and is valid.

**Types of Constraints:**

1. **PRIMARY KEY**: Uniquely identifies each record in a table. A table can have only one primary key, and it cannot contain NULL values.

   **Example:**

   ```sql
   CREATE TABLE Employees (
       EmployeeID INT PRIMARY KEY,
       Name VARCHAR(100)
   );
   ```

2. **FOREIGN KEY**: Ensures referential integrity between tables. It is a field (or collection of fields) in one table that refers to the primary key in another table.

   **Example:**

   ```sql
   CREATE TABLE Orders (
       OrderID INT PRIMARY KEY,
       EmployeeID INT,
       FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
   );
   ```

3. **UNIQUE**: Ensures all values in a column (or a group of columns) are unique across the table. Unlike the primary key, a table can have multiple unique constraints, and the columns can contain NULL values.

   **Example:**

   ```sql
   CREATE TABLE Users (
       UserID INT PRIMARY KEY,
       Email VARCHAR(255) UNIQUE
   );
   ```

4. **CHECK**: Ensures that all values in a column satisfy a specific condition.

   **Example:**

   ```sql
   CREATE TABLE Products (
       ProductID INT PRIMARY KEY,
       Price DECIMAL(10, 2) CHECK (Price > 0)
   );
   ```

5. **DEFAULT**: Provides a default value for a column when no value is specified.

   **Example:**

   ```sql
   CREATE TABLE Orders (
       OrderID INT PRIMARY KEY,
       OrderDate DATE DEFAULT GETDATE()
   );
   ```

6. **NOT NULL**: Ensures that a column cannot have NULL values.

   **Example:**

   ```sql
   CREATE TABLE Customers (
       CustomerID INT PRIMARY KEY,
       Name VARCHAR(100) NOT NULL
   );
   ```

### Q122. What is the difference between Primary Key and Unique Key?

- **Primary Key**:
  - Uniquely identifies each record in a table.
  - Cannot contain NULL values.
  - A table can have only one primary key.
  
- **Unique Key**:
  - Ensures that all values in a column or a combination of columns are unique.
  - Can contain NULL values, but only one NULL value per column (depending on the database).
  - A table can have multiple unique keys.

**Example:**

```sql
-- Primary Key
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    Name VARCHAR(100)
);

-- Unique Key
CREATE TABLE Users (
    UserID INT PRIMARY KEY,
    Email VARCHAR(255) UNIQUE
);
```

### Q123. What are Triggers and types of triggers?

**Triggers**: A trigger is a special type of stored procedure that is automatically executed or fired when certain events occur on a table or view.

**Types of Triggers:**

1. **BEFORE Trigger**: Executes before an `INSERT`, `UPDATE`, or `DELETE` operation on a table. It is used to validate or modify data before it is committed.

   **Example:**

   ```sql
   CREATE TRIGGER trgBeforeInsert
   ON Employees
   BEFORE INSERT
   AS
   BEGIN
       -- Code to execute before insert
   END;
   ```

2. **AFTER Trigger**: Executes after an `INSERT`, `UPDATE`, or `DELETE` operation. It is used to perform actions after the data has been modified.

   **Example:**

   ```sql
   CREATE TRIGGER trgAfterUpdate
   ON Employees
   AFTER UPDATE
   AS
   BEGIN
       -- Code to execute after update
   END;
   ```

3. **INSTEAD OF Trigger**: Executes instead of the `INSERT`, `UPDATE`, or `DELETE` operation. It can be used to modify the default behavior of these operations.

   **Example:**

   ```sql
   CREATE TRIGGER trgInsteadOfDelete
   ON Employees
   INSTEAD OF DELETE
   AS
   BEGIN
       -- Code to execute instead of delete
   END;
   ```

### Q124. What is a View?

**View**: A view is a virtual table based on the result of a SQL query. It contains rows and columns just like a real table, but it does not store data itself. Instead, it provides a way to represent data from one or more tables in a specific format.

**Example:**

```sql
CREATE VIEW EmployeeDetails AS
SELECT EmployeeID, Name, Department
FROM Employees
WHERE Active = 1;
```

### Q125. What is the difference between `HAVING` clause and `WHERE` clause?

- **`WHERE` Clause**: Filters records before any groupings are made. It is used with `SELECT`, `UPDATE`, and `DELETE` statements to filter rows based on a condition.

  **Example:**

  ```sql
  SELECT * FROM Employees
  WHERE Department = 'Sales';
  ```

- **`HAVING` Clause**: Filters groups of records after the `GROUP BY` clause has been applied. It is used with aggregate functions (e.g., `COUNT`, `SUM`) to filter results based on group conditions.

  **Example:**

  ```sql
  SELECT Department, COUNT(*)
  FROM Employees
  GROUP BY Department
  HAVING COUNT(*) > 10;
  ```

### Q126. What is a Subquery or Nested Query or Inner Query in SQL?

**Subquery (Nested Query)**: A subquery is a query embedded within another query. It can be used in `SELECT`, `INSERT`, `UPDATE`, or `DELETE` statements to provide data for the outer query.

**Example:**

```sql
SELECT Name
FROM Employees
WHERE DepartmentID = (
    SELECT DepartmentID
    FROM Departments
    WHERE DepartmentName = 'Sales'
);
```

### Q127. What is Auto Increment/ Identity column in SQL Server?

**Auto Increment (Identity Column)**: An auto-incrementing column automatically generates a unique value for each new row inserted into a table. In SQL Server, this is achieved using the `IDENTITY` property.

**Example:**

```sql
CREATE TABLE Employees (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100)
);
```

- `IDENTITY(1,1)` starts the value at 1 and increments it by 1 for each new row.

### Q128. What are Joins in SQL?

**Joins**: Joins are used to combine rows from two or more tables based on a related column between them. They allow you to query and retrieve data from multiple tables in a single query.

**Example:**

```sql
SELECT Employees.Name, Departments.DepartmentName
FROM Employees
INNER JOIN Departments ON Employees.DepartmentID = Departments.DepartmentID;
```

### Q129. What are the types of Joins in SQL Server?

1. **INNER JOIN**: Returns rows when there is a match in both tables.

   **Example:**

   ```sql
   SELECT * FROM Employees
   INNER JOIN Departments ON Employees.DepartmentID = Departments.DepartmentID;
   ```

2. **LEFT JOIN (or LEFT OUTER JOIN)**: Returns all rows from the left table and matched rows from the right table. Rows from the left table with no match in the right table will have NULLs for columns from the right table.

   **Example:**

   ```sql
   SELECT * FROM Employees
   LEFT JOIN Departments ON Employees.DepartmentID = Departments.DepartmentID;
   ```

3. **RIGHT JOIN (or RIGHT OUTER JOIN)**: Returns all rows from the right table and matched rows from the left table. Rows from the right table with no match in the left table will have NULLs for columns from the left table.

   **Example:**

   ```sql
   SELECT * FROM Employees
   RIGHT JOIN Departments ON Employees.DepartmentID = Departments.DepartmentID;
   ```

4. **FULL JOIN (or FULL OUTER JOIN)**: Returns rows when there is a match in one of the tables. It combines the results of both LEFT JOIN and RIGHT JOIN.

   **Example:**

   ```sql
   SELECT * FROM Employees
   FULL JOIN Departments ON Employees.DepartmentID = Departments.DepartmentID;
   ```

5. **CROSS JOIN**: Returns the Cartesian product of both tables. Each row in the first table is combined with each row in the second table.

   **Example:**

   ```sql
   SELECT * FROM Employees
   CROSS JOIN Departments;
   ```

### Q130. What is Self-Join?

**Self-Join**: A self-join is a regular join, but the table is joined with itself. It is useful for querying hierarchical or recursive data.

**Example:**

```sql
SELECT E1.Name AS Employee, E2.Name AS Manager
FROM Employees E1
INNER JOIN Employees E2 ON E1.ManagerID = E2.EmployeeID;
```

Here, `E1` and `E2` are aliases for the same `Employees` table, and the join is used to find the managers of employees.

### Q131. What are Indexes in SQL Server?

**Indexes**: An index in SQL Server is a database object that improves the speed of data retrieval operations on a table at the cost of additional space and reduced performance on data modification operations (like `INSERT`, `UPDATE`, and `DELETE`). Indexes can be thought of as a lookup table that helps SQL Server find the desired data more quickly.

**Types of Indexes**: The main types are Clustered Indexes and Non-Clustered Indexes.

### Q132. What is a Clustered Index?

**Clustered Index**: A clustered index determines the physical order of data in a table. In other words, it sorts and stores the table data rows based on the index key. Each table can have only one clustered index because the data rows themselves can be sorted in only one order.

**Example**:

```sql
CREATE CLUSTERED INDEX idx_EmployeeID
ON Employees (EmployeeID);
```

In this example, the `EmployeeID` column is used to sort and store the rows of the `Employees` table.

### Q133. What is a Non-Clustered Index?

**Non-Clustered Index**: A non-clustered index does not alter the physical order of the data in the table. Instead, it creates a separate structure (a B-tree) that points to the data rows in the table. A table can have multiple non-clustered indexes.

**Example**:

```sql
CREATE NONCLUSTERED INDEX idx_LastName
ON Employees (LastName);
```

Here, the `LastName` column is indexed separately from the physical storage of data in the `Employees` table.

### Q134. What is the difference between Clustered and Non-Clustered Index?

- **Clustered Index**:
  - Determines the physical order of data in the table.
  - There can be only one clustered index per table.
  - The data rows are stored in the index structure.
  - Typically used on columns that are frequently used in `ORDER BY` clauses or as primary keys.

- **Non-Clustered Index**:
  - Does not affect the physical order of data in the table.
  - Can have multiple non-clustered indexes per table.
  - Contains a separate structure with pointers to the actual data rows.
  - Useful for columns used in search conditions, joins, or filters.

### Q135. How to create Clustered and Non-Clustered Index in a table?

**Clustered Index Creation**:

```sql
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    Name VARCHAR(100),
    DepartmentID INT
);

CREATE CLUSTERED INDEX idx_EmployeeID
ON Employees (EmployeeID);
```

**Non-Clustered Index Creation**:

```sql
CREATE NONCLUSTERED INDEX idx_DepartmentID
ON Employees (DepartmentID);
```

### Q136. In which column you will apply the indexing to optimize this query?

To determine which column to index, you need to analyze the query patterns. Generally, you should index columns that are used in `WHERE` clauses, join conditions, or `ORDER BY` clauses.

**Example Query**:

```sql
SELECT * FROM Employees
WHERE DepartmentID = 3;
```

In this case, indexing the `DepartmentID` column would help optimize the query.

### Q137. What is the difference between Stored Procedure and Functions?

- **Stored Procedure**:
  - A stored procedure is a precompiled collection of one or more SQL statements.
  - Can perform operations like modifying database objects and handling transactions.
  - Can return zero or more values.
  - Does not return a value directly (instead, it uses `OUT` parameters or result sets).
  
  **Example**:

  ```sql
  CREATE PROCEDURE GetEmployeeDetails
  @EmployeeID INT
  AS
  BEGIN
      SELECT * FROM Employees WHERE EmployeeID = @EmployeeID;
  END;
  ```

- **Function**:
  - A function is a database object that performs calculations and returns a single value or a table.
  - Cannot perform operations like modifying database objects.
  - Must return a value directly.
  - Can be used in a `SELECT` statement or other expressions.

  **Example**:

  ```sql
  CREATE FUNCTION GetEmployeeName(@EmployeeID INT)
  RETURNS VARCHAR(100)
  AS
  BEGIN
      DECLARE @Name VARCHAR(100);
      SELECT @Name = Name FROM Employees WHERE EmployeeID = @EmployeeID;
      RETURN @Name;
  END;
  ```

### Q138. How to optimize a Stored Procedure or SQL Query?

**Optimization Tips**:

1. **Indexing**: Ensure appropriate indexes are in place for columns used in `WHERE`, `JOIN`, and `ORDER BY` clauses.
2. **Query Execution Plan**: Analyze and optimize the execution plan using SQL Server Management Studio (SSMS).
3. **Avoid Cursors**: Replace cursors with set-based operations if possible.
4. **Reduce the Number of Rows Returned**: Use appropriate filters and select only necessary columns.
5. **Avoid Nested Queries**: Use joins instead of subqueries when possible.
6. **Update Statistics**: Ensure database statistics are up-to-date.

### Q139. What is a Cursor? Why avoid them?

**Cursor**: A cursor is a database object used to retrieve, manipulate, and navigate through a result set row by row. It allows for more granular control over data retrieval and manipulation.

**Why Avoid Cursors**:

- Cursors can be slow and resource-intensive because they process data row by row.
- Set-based operations (e.g., joins) are generally more efficient than row-by-row processing.
- Use set-based queries whenever possible to improve performance.

**Example**:

```sql
DECLARE cursor_example CURSOR FOR
SELECT EmployeeID FROM Employees;

OPEN cursor_example;

FETCH NEXT FROM cursor_example INTO @EmployeeID;

-- Process each row

CLOSE cursor_example;
DEALLOCATE cursor_example;
```

### Q140. What is the difference between `scope_identity` and `@@identity`?

- **`SCOPE_IDENTITY()`**:
  - Returns the last identity value generated for any table in the current scope.
  - Is limited to the current session and scope, which avoids potential issues with triggers that might generate additional identity values.
  
  **Example**:

  ```sql
  INSERT INTO Employees (Name) VALUES ('John Doe');
  SELECT SCOPE_IDENTITY();
  ```

- **`@@IDENTITY`**:
  - Returns the last identity value generated for any table in the current session, regardless of scope.
  - Can be affected by triggers that generate additional identity values, so it might return unexpected results if multiple tables have identity columns.

  **Example**:

  ```sql
  INSERT INTO Employees (Name) VALUES ('Jane Doe');
  SELECT @@IDENTITY;
  ```

### Q141. What is CTE in SQL Server?

**CTE (Common Table Expression)**: A CTE is a temporary result set that you can reference within a `SELECT`, `INSERT`, `UPDATE`, or `DELETE` statement. It is defined using the `WITH` clause and is useful for simplifying complex queries, especially those involving hierarchical data or recursive queries.

**Example**:

```sql
WITH EmployeeCTE AS (
    SELECT EmployeeID, Name, ManagerID
    FROM Employees
)
SELECT *
FROM EmployeeCTE
WHERE ManagerID IS NOT NULL;
```

### Q142. What is the difference between Delete, Truncate, and Drop commands?

- **`DELETE`**:
  - Removes rows from a table based on a condition.
  - Can be rolled back if within a transaction.
  - Triggers can be activated.
  - Example: `DELETE FROM Employees WHERE EmployeeID = 1;`

- **`TRUNCATE`**:
  - Removes all rows from a table without logging individual row deletions.
  - Cannot be rolled back if not within a transaction.
  - Does not activate triggers.
  - Faster than `DELETE` for large tables.
  - Example: `TRUNCATE TABLE Employees;`

- **`DROP`**:
  - Removes the table structure and its data from the database.
  - Cannot be rolled back.
  - Example: `DROP TABLE Employees;`

### Q143. How to get the Nth highest salary of an employee?

**Using a Subquery**:

```sql
SELECT DISTINCT Salary
FROM Employees
ORDER BY Salary DESC
OFFSET N-1 ROWS FETCH NEXT 1 ROW ONLY;
```

**Using ROW_NUMBER()**:

```sql
WITH SalaryRank AS (
    SELECT Salary, ROW_NUMBER() OVER (ORDER BY Salary DESC) AS Rank
    FROM Employees
)
SELECT Salary
FROM SalaryRank
WHERE Rank = N;
```

### Q144. What are ACID properties?

**ACID** stands for **Atomicity, Consistency, Isolation, and Durability**:

- **Atomicity**: Ensures that all operations in a transaction are completed; if not, the transaction is aborted.
- **Consistency**: Ensures that the database remains in a consistent state before and after the transaction.
- **Isolation**: Ensures that transactions are executed in isolation from one another.
- **Durability**: Ensures that once a transaction is committed, it remains permanent even in the event of a system failure.

### Q145. What are Magic Tables in SQL Server?

**Magic Tables**: In SQL Server, the term "magic tables" refers to the special tables named `inserted` and `deleted` used in triggers. These tables allow you to access the data before and after a modification (insert, update, delete).

- **`inserted` Table**: Holds the new values for `INSERT` and `UPDATE` operations.
- **`deleted` Table**: Holds the old values for `DELETE` and `UPDATE` operations.

**Example**:

```sql
CREATE TRIGGER trg_UpdateEmployee
ON Employees
AFTER UPDATE
AS
BEGIN
    SELECT * FROM inserted;  -- New values
    SELECT * FROM deleted;   -- Old values
END;
```

### Q146. What is MVC? Explain MVC Life Cycle

**MVC (Model-View-Controller)**: A design pattern used for creating web applications by separating an application into three main components:

- **Model**: Manages the data and business logic.
- **View**: Displays the data to the user.
- **Controller**: Handles user input and updates the model and view accordingly.

**MVC Life Cycle**:

1. **Request**: The user makes a request via a URL.
2. **Routing**: The URL is matched to a route defined in the routing table.
3. **Controller Creation**: The controller specified by the route is instantiated.
4. **Action Execution**: The appropriate action method of the controller is executed.
5. **Result Processing**: The action method returns a result (e.g., a view).
6. **Rendering**: The view is rendered and sent to the browser.

### Q147. What are the advantages of MVC over Web Forms?

- **Separation of Concerns**: MVC provides a clearer separation of concerns, making code easier to manage and test.
- **Testability**: MVC allows for better testability of applications, particularly with unit testing.
- **Control Over HTML**: MVC provides more control over the HTML and the rendering process.
- **Flexibility**: MVC is more flexible and adaptable to different kinds of applications compared to Web Forms.
- **Performance**: MVC generally has better performance due to less overhead compared to Web Forms.

### Q148. What are the different return types of a controller Action method?

- **`ActionResult`**: The base type for all result types.
- **`ViewResult`**: Renders a view.
- **`PartialViewResult`**: Renders a partial view.
- **`JsonResult`**: Returns JSON-formatted data.
- **`RedirectToRouteResult`**: Redirects to another action or route.
- **`RedirectResult`**: Redirects to a URL.
- **`ContentResult`**: Returns plain text content.
- **`FileResult`**: Returns a file.
- **`HttpStatusCodeResult`**: Returns a specific HTTP status code.

**Example**:

```csharp
public ActionResult Index()
{
    return View(); // Returns a view
}
```

### Q149. What are Filters and their types in MVC?

**Filters**: In ASP.NET MVC, filters are used to execute code before or after certain stages in the request processing pipeline.

**Types of Filters**:

- **Authorization Filters**: Determine if the user is authorized to access the resource. (e.g., `[Authorize]`)
- **Action Filters**: Execute before or after an action method runs. (e.g., `[ActionFilter]`)
- **Result Filters**: Execute before or after the result is executed. (e.g., `[ResultFilter]`)
- **Exception Filters**: Handle exceptions thrown by action methods. (e.g., `[HandleError]`)

**Example**:

```csharp
[Authorize]
public ActionResult SecureAction()
{
    return View();
}
```

### Q150. What is Authentication and Authorization in ASP.NET MVC?

- **Authentication**: The process of verifying the identity of a user. It ensures that users are who they claim to be.
  - **Example**: Logging in with a username and password.

- **Authorization**: The process of determining whether a user has permission to access a resource. It checks if the authenticated user has the rights to perform certain actions.
  - **Example**: Checking if a logged-in user is allowed to access a specific page or perform a specific action.

**Example of Authentication**:

```csharp
[Authorize]
public ActionResult Index()
{
    return View();
}
```

**Example of Authorization**:

```csharp
[Authorize(Roles = "Admin")]
public ActionResult AdminOnly()
{
    return View();
}
```

Let me know if you need more details or have other questions!

Here’s an overview of these ASP.NET MVC concepts:

### Q151. What are the types of Authentication in ASP.NET MVC?

**Types of Authentication**:

1. **Forms Authentication**:
   - A method where users are authenticated using a login form. After successful login, the user is issued a cookie that is used to authenticate subsequent requests.
   - Configuration is typically done in `Web.config`.

   **Example**:

   ```xml
   <authentication mode="Forms">
       <forms loginUrl="~/Account/Login" timeout="30" />
   </authentication>
   ```

2. **Windows Authentication**:
   - Authenticates users based on their Windows credentials. Typically used in intranet environments.
   - Configured in `Web.config` and IIS.

   **Example**:

   ```xml
   <authentication mode="Windows" />
   ```

3. **OAuth and OpenID Connect**:
   - Allows authentication via third-party providers like Google, Facebook, or Azure AD.
   - Requires configuring authentication providers in the startup class and using middleware.

   **Example**:

   ```csharp
   services.AddAuthentication()
       .AddGoogle(options =>
       {
           options.ClientId = "your-client-id";
           options.ClientSecret = "your-client-secret";
       });
   ```

4. **Identity Server**:
   - A more complex authentication mechanism that supports OpenID Connect and OAuth 2.0. It's commonly used in enterprise applications for secure authentication.

### Q152. What is Output Caching in MVC? How to implement it?

**Output Caching**: Output caching stores the rendered output of a controller action or a view so that subsequent requests for the same resource can be served faster without re-rendering.

**Implementation**:

- **In Controller**:

  ```csharp
  [OutputCache(Duration = 60, VaryByParam = "None")]
  public ActionResult Index()
  {
      return View();
  }
  ```

- **In View**:

  ```html
  @Html.Partial("_PartialViewName")
  ```

  Ensure caching is enabled in the web.config or app settings.

### Q153. What is Routing in MVC?

**Routing**: Routing is the process of mapping incoming requests to the appropriate controller action. It defines the URL patterns and maps them to controllers and actions.

**Example**:

```csharp
public class RouteConfig
{
    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        );
    }
}
```

### Q154. Explain Attribute Based Routing in MVC?

**Attribute-Based Routing**: Allows developers to specify routing information directly on controller actions using attributes. This makes it easier to manage routes and avoid configuration in the `RouteConfig` class.

**Example**:

```csharp
public class HomeController : Controller
{
    [Route("home/about")]
    public ActionResult About()
    {
        return View();
    }
}
```

This route will match `http://yourdomain/home/about`.

### Q155. What is the difference between ViewData, ViewBag & TempData?

- **`ViewData`**:
  - A dictionary that stores data to be used in the view.
  - Requires type casting when retrieving data.
  - Data is lost after the request is complete.

  **Example**:

  ```csharp
  ViewData["Message"] = "Hello, World!";
  ```

- **`ViewBag`**:
  - A dynamic wrapper around `ViewData` that allows you to add properties without type casting.
  - Data is lost after the request is complete.

  **Example**:

  ```csharp
  ViewBag.Message = "Hello, World!";
  ```

- **`TempData`**:
  - Used to pass data between actions and persists data for a single request or until it is read.
  - Data is stored in session and can be accessed in the subsequent request.

  **Example**:

  ```csharp
  TempData["Message"] = "Hello, World!";
  ```

### Q156. How can we pass data from controller to view in MVC?

**Methods to Pass Data**:

- **`ViewData`**: Use `ViewData` dictionary to pass data from the controller to the view.

  ```csharp
  ViewData["Message"] = "Hello, World!";
  ```

- **`ViewBag`**: Use `ViewBag` to pass data dynamically.

  ```csharp
  ViewBag.Message = "Hello, World!";
  ```

- **`Model`**: Pass a strongly-typed model object from the controller to the view.

  ```csharp
  public ActionResult Index()
  {
      var model = new MyModel { Name = "John" };
      return View(model);
  }
  ```

- **`TempData`**: Use `TempData` to pass data between actions.

  ```csharp
  TempData["Message"] = "Hello, World!";
  ```

### Q157. What is Partial View?

**Partial View**: A partial view is a reusable view component that can be used within other views. It helps in breaking down complex views into simpler components and reusing code.

**Example**:

```html
@Html.Partial("_PartialViewName", model)
```

### Q158. What are Areas in MVC?

**Areas**: Areas are used to partition large web applications into smaller, more manageable sections. Each area can have its own controllers, views, and models.

**Example**:

1. **Create an Area**:

   ```bash
   dotnet new area -n Admin
   ```

2. **Register Area** in `RouteConfig`:

   ```csharp
   public class RouteConfig
   {
       public static void RegisterRoutes(RouteCollection routes)
       {
           routes.MapRoute(
               name: "Admin",
               url: "Admin/{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "MyApp.Areas.Admin.Controllers" }
           );
       }
   }
   ```

### Q159. How Validation works in MVC? What is Data Annotation?

**Validation in MVC**: MVC provides built-in support for validation using data annotations and model validation.

- **Data Annotations**: Attributes used to enforce validation rules on model properties.

**Example**:

```csharp
public class UserModel
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [EmailAddress]
    public string Email { get; set; }
}
```

- **Model Validation**: When a model is submitted, MVC automatically validates it based on the data annotations and displays validation messages.

**Example in View**:

```html
@Html.ValidationSummary(true)
@Html.TextBoxFor(m => m.Name)
@Html.ValidationMessageFor(m => m.Name)
```

### Q160. Explain the concept of MVC Scaffolding?

**MVC Scaffolding**: Scaffolding is a code generation framework that automatically generates code for CRUD (Create, Read, Update, Delete) operations based on the model and database schema. It helps in quickly setting up a basic structure for your application.

**Example**:

1. **Right-click on the Controllers folder** in Visual Studio.
2. **Select "Add" > "Controller..."**.
3. **Choose "MVC Controller with views, using Entity Framework"**.
4. **Configure the options** and click "Add".

Scaffolding generates controller actions and views based on the selected model and context.

### Q161. What is Bundling and Minification in MVC?

**Bundling**:

- Bundling is the process of combining multiple CSS or JavaScript files into a single file. This reduces the number of HTTP requests made by the browser, improving load times.

**Minification**:

- Minification is the process of removing unnecessary characters from code (like whitespace, comments) to reduce its size, which also improves load times.

**Implementation**:

- In MVC, you typically configure bundling and minification in the `BundleConfig.cs` file.

**Example**:

```csharp
public class BundleConfig
{
    public static void RegisterBundles(BundleCollection bundles)
    {
        bundles.Add(new StyleBundle("~/Content/css").Include(
                  "~/Content/bootstrap.css",
                  "~/Content/site.css"));
        
        bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                  "~/Scripts/jquery-{version}.js"));
        
        bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                  "~/Scripts/modernizr-*"));
        
        bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                  "~/Scripts/bootstrap.js",
                  "~/Scripts/respond.js"));
    }
}
```

### Q162. How to implement Security in web applications in MVC?

**Implementing Security**:

1. **Authentication and Authorization**:
   - Use built-in authentication mechanisms (Forms, Windows, OAuth, etc.).
   - Implement role-based or policy-based authorization to restrict access.

2. **Input Validation**:
   - Validate all input data to prevent injection attacks (SQL Injection, XSS).

3. **HTTPS**:
   - Enforce HTTPS to secure data in transit.

4. **Anti-Forgery Tokens**:
   - Use anti-forgery tokens to prevent Cross-Site Request Forgery (CSRF).

   **Example**:

   ```csharp
   [HttpPost]
   [ValidateAntiForgeryToken]
   public ActionResult Login(LoginModel model)
   {
       // Login logic
   }
   ```

5. **Secure Headers**:
   - Use security headers like Content Security Policy (CSP), X-Frame-Options, etc.

6. **Data Protection**:
   - Protect sensitive data at rest and in transit.

7. **Exception Handling**:
   - Handle exceptions properly and avoid exposing sensitive information.

### Q163. What are the events in Page Life Cycle?

**Page Life Cycle Events**:

1. **Page Request**: A page request is initiated.
2. **Start**: Page initialization starts, where you can check if the request is a postback.
3. **Initialization**: Controls on the page are initialized.
4. **Load**: The page and its controls are loaded with data.
5. **Postback Event Handling**: If the request is a postback, event handling occurs.
6. **Rendering**: The page calls the `Render` method of each control to generate HTML.
7. **Unload**: Cleanup and resource release occur after the page has been fully rendered.

### Q164. What is the difference between Server.Transfer() and Response.Redirect()?

**`Server.Transfer()`**:

- Performs a server-side transfer to another page without changing the URL in the browser.
- The transfer happens within the server, so it’s more efficient in terms of performance.

**Example**:

```csharp
Server.Transfer("TargetPage.aspx");
```

**`Response.Redirect()`**:

- Performs a client-side redirect to a new URL, causing the browser to make a new request.
- The URL in the browser address bar changes to the new page.

**Example**:

```csharp
Response.Redirect("TargetPage.aspx");
```

### Q165. What are the different types of Caching?

**Types of Caching**:

1. **Output Caching**:
   - Caches the dynamic page output to improve performance for frequently requested pages.

   **Example**:

   ```csharp
   [OutputCache(Duration = 60)]
   public ActionResult Index()
   {
       return View();
   }
   ```

2. **Data Caching**:
   - Caches data objects or results of expensive operations in memory.

   **Example**:

   ```csharp
   Cache["myData"] = expensiveDataOperation();
   ```

3. **Application Caching**:
   - Stores data across different requests and users.

   **Example**:

   ```csharp
   Application["AppData"] = data;
   ```

4. **Distributed Caching**:
   - Used in distributed environments to cache data across multiple servers.

   **Example**:

   ```csharp
   services.AddDistributedRedisCache(options =>
   {
       options.Configuration = "localhost";
       options.InstanceName = "SampleInstance";
   });
   ```

### Q166. What are the types of state management?

**Types of State Management**:

1. **Client-Side**:
   - **Cookies**: Small pieces of data stored on the client’s browser.
   - **ViewState**: Stores page and control values in a hidden field on the page.
   - **Query Strings**: Data appended to the URL.
   - **Hidden Fields**: Stores data within hidden fields in HTML forms.

2. **Server-Side**:
   - **Session State**: Stores user data on the server between requests.
   - **Application State**: Stores global data accessible by all users.

### Q167. Where is the ViewState stored after the page postback?

**ViewState**:

- ViewState is stored as a hidden field in the HTML form sent to the client’s browser. When the page is posted back, ViewState data is sent back to the server with the request and used to restore the state of controls.

### Q168. What are the different ways to store session state in ASP.NET?

**Session State Storage Options**:

1. **InProc**: Stores session state in the memory of the web server. Fast but not suitable for web farms.
2. **StateServer**: Stores session state in a separate process on a different server.
3. **SQLServer**: Stores session state in a SQL Server database.
4. **Custom**: Uses a custom storage mechanism defined by the developer.

**Configuration Example** (`Web.config`):

```xml
<sessionState mode="SQLServer" connectionString="your-connection-string" />
```

### Q169. What is cookie-less session?

**Cookie-less Session**:

- Refers to storing session data without using cookies by embedding the session ID in the URL. This is useful when cookies are disabled or not supported.

**Configuration Example**:

```xml
<sessionState cookieless="true" />
```

### Q170. How to force all the validation controls to run in a page in Web Forms?

**Forcing Validation**:

- Use the `Page.Validate()` method to trigger validation on the page.
- To ensure all validation controls run, call `Page.IsValid` to check if the page is valid.

**Example**:

```csharp
protected void Button_Click(object sender, EventArgs e)
{
    Page.Validate();
    if (Page.IsValid)
    {
        // Proceed with form processing
    }
}
```

Let me know if you need more details on any of these topics!

Here’s a detailed look at the concepts related to ADO.NET and Entity Framework:

### Q171. What are the main components of ADO.NET?

**Main Components of ADO.NET**:

1. **Data Providers**:
   - **SqlConnection**: Represents a connection to a SQL Server database.
   - **SqlCommand**: Represents a SQL command or stored procedure to execute against a SQL Server database.
   - **SqlDataAdapter**: Populates a `DataSet` and updates the data source.
   - **SqlDataReader**: Provides a forward-only, read-only cursor for reading data from a SQL Server database.
   - **SqlParameter**: Represents a parameter to be used with a `SqlCommand`.

2. **DataSets**:
   - **DataSet**: In-memory cache of data that can hold multiple tables and their relationships.
   - **DataTable**: Represents a single table in a `DataSet`.
   - **DataRow**: Represents a row in a `DataTable`.
   - **DataColumn**: Represents a column in a `DataTable`.

3. **DataAdapters**:
   - **DataAdapter**: Provides a bridge between a `DataSet` and a data source, filling the `DataSet` and updating the data source.

### Q172. What is Connected architecture and Disconnected architecture?

**Connected Architecture**:

- **Characteristics**: Involves maintaining an open connection to the database for the duration of the data operation.
- **Components**: Utilizes `SqlConnection`, `SqlCommand`, `SqlDataReader`.
- **Usage**: Suitable for applications where continuous connection to the database is feasible and needed for real-time data operations.

**Disconnected Architecture**:

- **Characteristics**: Involves working with a data source in a disconnected mode. The connection to the database is opened only for the duration of filling or updating data.
- **Components**: Utilizes `DataSet`, `DataTable`, `DataAdapter`.
- **Usage**: Suitable for applications where working offline or with a local cache of data is necessary.

### Q173. What are the different Execute Methods of ADO.NET?

**Execute Methods**:

1. **ExecuteNonQuery**:
   - Executes a command that does not return any result (e.g., `INSERT`, `UPDATE`, `DELETE`).
   - Returns the number of rows affected.

   **Example**:

   ```csharp
   SqlCommand cmd = new SqlCommand("UPDATE Employees SET Salary = @Salary WHERE Id = @Id", conn);
   cmd.Parameters.AddWithValue("@Salary", 5000);
   cmd.Parameters.AddWithValue("@Id", 1);
   int rowsAffected = cmd.ExecuteNonQuery();
   ```

2. **ExecuteReader**:
   - Executes a command that returns a `SqlDataReader`, used for reading data.
   - Returns a `SqlDataReader` object.

   **Example**:

   ```csharp
   SqlCommand cmd = new SqlCommand("SELECT * FROM Employees", conn);
   SqlDataReader reader = cmd.ExecuteReader();
   while (reader.Read())
   {
       Console.WriteLine(reader["Name"].ToString());
   }
   reader.Close();
   ```

3. **ExecuteScalar**:
   - Executes a command that returns a single value (e.g., an aggregate value).
   - Returns the first column of the first row in the result set.

   **Example**:

   ```csharp
   SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Employees", conn);
   int count = (int)cmd.ExecuteScalar();
   ```

4. **ExecuteXmlReader**:
   - Executes a command that returns an XML data stream.
   - Returns an `XmlReader` object.

   **Example**:

   ```csharp
   SqlCommand cmd = new SqlCommand("SELECT * FROM Employees FOR XML AUTO", conn);
   XmlReader reader = cmd.ExecuteXmlReader();
   ```

### Q174. What are the Authentication techniques used to connect to SQL Server?

**Authentication Techniques**:

1. **Windows Authentication**:
   - Uses the credentials of the current Windows user to authenticate with SQL Server.

   **Example**:

   ```csharp
   SqlConnection conn = new SqlConnection("Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;");
   ```

2. **SQL Server Authentication**:
   - Uses a SQL Server login and password for authentication.

   **Example**:

   ```csharp
   SqlConnection conn = new SqlConnection("Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;");
   ```

### Q175. What is ORM? What are the different types of ORM?

**Object-Relational Mapping (ORM)**:

- ORM is a programming technique used to convert data between incompatible type systems in object-oriented programming languages.

**Types of ORM**:

1. **Entity Framework**: An ORM framework by Microsoft that provides a higher-level abstraction for database access.
2. **NHibernate**: An open-source ORM for .NET that provides a powerful and flexible way to map domain models to the database.
3. **Dapper**: A lightweight ORM for .NET that provides fast and simple mapping.

### Q176. What is Entity Framework?

**Entity Framework (EF)**:

- Entity Framework is an ORM framework by Microsoft for .NET applications. It provides an abstraction layer that allows developers to work with databases using .NET objects rather than raw SQL queries.

**Features**:

- **Code First**: Define your model using C# code and EF will create the database schema.
- **Database First**: Generate model classes from an existing database.
- **Model First**: Design your model visually and generate the database schema from the model.

### Q177. How will you differentiate ADO.NET from Entity Framework?

**ADO.NET vs Entity Framework**:

- **ADO.NET**:
  - Works directly with database connections and commands.
  - Requires manual data manipulation and updates.
  - Provides more control over SQL queries and database interactions.

- **Entity Framework**:
  - Provides an abstraction layer over ADO.NET.
  - Uses LINQ to query data and provides automatic change tracking.
  - Simplifies database interactions by allowing developers to work with high-level objects.

### Q178. How Entity Framework works? OR How to setup EF?

**How Entity Framework Works**:

1. **Define Models**: Create C# classes that represent the database entities.
2. **Configure Context**: Define a `DbContext` class that manages entity objects and database connections.
3. **Perform Operations**: Use LINQ to query and manipulate data.

**Setting Up Entity Framework**:

1. **Install EF**: Add Entity Framework to your project using NuGet Package Manager.

   ```shell
   Install-Package EntityFramework
   ```

2. **Create Models**: Define your entity classes.

   ```csharp
   public class Product
   {
       public int ProductId { get; set; }
       public string Name { get; set; }
   }
   ```

3. **Define DbContext**:

   ```csharp
   public class MyDbContext : DbContext
   {
       public DbSet<Product> Products { get; set; }
   }
   ```

4. **Perform CRUD Operations**:

   ```csharp
   using (var context = new MyDbContext())
   {
       var product = new Product { Name = "Laptop" };
       context.Products.Add(product);
       context.SaveChanges();
   }
   ```

### Q179. What is meant by DBContext and DBSet?

**DbContext**:

- Represents a session with the database. It manages entity objects during runtime, including querying and saving data.

**DbSet**:

- Represents a collection of entities of a specific type that can be queried from the database. It is used to perform CRUD operations on entities.

**Example**:

```csharp
public class MyDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
}
```

### Q180. What are the different types of application development approaches used with EF?

**Application Development Approaches with EF**:

1. **Code First**:
   - Define model classes and context in code, and EF will generate the database schema.

2. **Database First**:
   - Generate model classes based on an existing database schema using EF’s designer tools.

3. **Model First**:
   - Create a conceptual model using EF’s designer tools and generate the database schema from the model.

### Q181. What is the difference between LINQ to SQL and Entity Framework?

**LINQ to SQL**:

- **Overview**: A simpler ORM framework provided by Microsoft for querying and managing SQL Server databases using LINQ.
- **Features**:
  - Supports only SQL Server.
  - Provides a mapping between SQL Server database tables and .NET classes.
  - Limited support for complex queries and relationships.
- **Usage**: Suitable for applications that work exclusively with SQL Server and have relatively simple data access needs.

**Entity Framework**:

- **Overview**: A more powerful and flexible ORM framework that supports multiple database providers and advanced data access features.
- **Features**:
  - Supports multiple databases (SQL Server, SQLite, PostgreSQL, etc.).
  - Provides Code First, Database First, and Model First approaches.
  - Supports more complex relationships and querying capabilities.
- **Usage**: Suitable for applications requiring advanced data access features and support for multiple database systems.

### Q182. What is Web API? What is the purpose of Web API?

**Web API**:

- **Definition**: A framework for building HTTP-based services that can be consumed by a variety of clients, including browsers, mobile apps, and other web services.
- **Purpose**:
  - To provide a standardized way to create and consume RESTful services.
  - To enable communication between different systems and platforms over HTTP.
  - To facilitate integration between different applications and services.

### Q183. What are Web API advantages over WCF and web services?

**Advantages of Web API**:

1. **Simpler and Lightweight**:
   - Web API is designed specifically for HTTP and is more lightweight compared to WCF.
2. **Supports Multiple Formats**:
   - Web API supports multiple formats like JSON, XML, and others, whereas WCF typically focuses on SOAP.
3. **Better for RESTful Services**:
   - Web API is better suited for RESTful services and follows REST principles more naturally.
4. **Easier Integration with Modern Web Technologies**:
   - Web API integrates seamlessly with modern web frameworks and tools.
5. **More Flexible Routing**:
   - Provides more flexible and customizable routing compared to WCF.

### Q184. What are HTTP verbs or HTTP methods?

**HTTP Verbs (Methods)**:

1. **GET**: Retrieve data from a server. It is idempotent (repeated requests have the same effect).
2. **POST**: Send data to the server to create or update a resource. It is not idempotent.
3. **PUT**: Update a resource or create a new resource if it does not exist. It is idempotent.
4. **DELETE**: Remove a resource from the server. It is idempotent.
5. **PATCH**: Apply partial modifications to a resource. It is not necessarily idempotent.
6. **OPTIONS**: Retrieve the allowed HTTP methods for a resource.
7. **HEAD**: Retrieve the headers of a resource without the body.

### Q185. What is the difference between REST API and Web API?

**REST API**:

- **Definition**: An architectural style for designing networked applications based on stateless, client-server communication, usually over HTTP.
- **Principles**: Uses HTTP methods, URLs, and status codes to perform CRUD operations.
- **Format**: Often uses JSON or XML for data exchange.

**Web API**:

- **Definition**: A broader term for APIs that are accessible over HTTP, including RESTful services and other types of HTTP-based APIs.
- **Flexibility**: Can be RESTful or use other protocols or formats.

**Difference**:

- REST API is a specific implementation of a Web API that adheres to REST principles. Web API encompasses REST APIs but can also include other types of HTTP-based services.

### Q186. What are REST guidelines? What is the difference between REST and RESTful?

**REST Guidelines**:

1. **Stateless**: Each request from a client to the server must contain all the information needed to understand and process the request.
2. **Client-Server Architecture**: The client and server should be separate, allowing them to evolve independently.
3. **Cacheable**: Responses should explicitly define whether they are cacheable to improve performance.
4. **Uniform Interface**: A uniform interface between clients and servers should be maintained to simplify and decouple the architecture.
5. **Layered System**: The architecture should be layered, with each layer having specific responsibilities.
6. **Code on Demand (Optional)**: Servers may extend client functionality by providing executable code (e.g., JavaScript).

**REST vs. RESTful**:

- **REST**: Refers to the architectural style itself.
- **RESTful**: Describes an implementation that adheres to REST principles. "RESTful" is used to denote APIs or services that follow REST guidelines.

### Q187. Is it possible to use WCF as RESTful services?

**Yes**, WCF can be used to create RESTful services by configuring WCF to use web HTTP binding (`WebHttpBinding`). While WCF is more commonly associated with SOAP services, it can also support RESTful services if configured properly.

**Example**:

```xml
<system.serviceModel>
  <services>
    <service name="MyService">
      <endpoint address="" binding="webHttpBinding" contract="IMyService" behaviorConfiguration="web">
        <identity>
          <dns value="localhost" />
        </identity>
      </endpoint>
    </service>
  </services>
  <behaviors>
    <endpointBehaviors>
      <behavior name="web">
        <webHttp />
      </behavior>
    </endpointBehaviors>
  </behaviors>
</system.serviceModel>
```

### Q188. How to consume Web API from a .NET MVC application?

**Consuming Web API from .NET MVC**:

1. **Using `HttpClient`**:

   ```csharp
   public async Task<ActionResult> GetData()
   {
       using (HttpClient client = new HttpClient())
       {
           client.BaseAddress = new Uri("https://api.example.com/");
           HttpResponseMessage response = await client.GetAsync("endpoint");
           if (response.IsSuccessStatusCode)
           {
               var data = await response.Content.ReadAsAsync<MyDataType>();
               return View(data);
           }
           return View("Error");
       }
   }
   ```

2. **Using `HttpClientFactory` (ASP.NET Core)**:

   ```csharp
   public class MyService
   {
       private readonly HttpClient _httpClient;

       public MyService(HttpClient httpClient)
       {
           _httpClient = httpClient;
       }

       public async Task<MyDataType> GetDataAsync()
       {
           HttpResponseMessage response = await _httpClient.GetAsync("endpoint");
           response.EnsureSuccessStatusCode();
           return await response.Content.ReadAsAsync<MyDataType>();
       }
   }
   ```

### Q189. What is the difference between Web API and MVC Controller?

**Web API**:

- Designed specifically for creating HTTP-based services that can be accessed by a variety of clients.
- Typically returns data in formats such as JSON or XML.
- Uses HTTP verbs to define operations (GET, POST, PUT, DELETE).

**MVC Controller**:

- Part of the ASP.NET MVC framework for building web applications.
- Designed to handle requests and return views (HTML) to the user.
- Typically involves view rendering, model binding, and response generation.

**Difference**:

- Web API is used for creating services that provide data to clients, while MVC Controllers are used for building web applications with server-side rendered pages.

### Q190. What are the types of authentication techniques in Web API?

**Authentication Techniques in Web API**:

1. **Basic Authentication**:
   - Transmits credentials as base64 encoded strings in the HTTP header.
   - Simple but not secure unless used with HTTPS.

2. **Bearer Token Authentication**:
   - Uses OAuth tokens for authenticating requests.
   - Commonly used with JSON Web Tokens (JWT).

3. **OAuth 2.0**:
   - An authorization framework that allows third-party applications to obtain limited access to a user’s resources without exposing credentials.

4. **API Key Authentication**:
   - Uses a unique key to authenticate API requests.
   - Often used for API access control.

5. **Custom Authentication**:
   - Implement custom authentication schemes tailored to specific needs.

### Q191. What is Basic Authentication in Web API?

**Basic Authentication**:

- **Definition**: A simple authentication scheme built into the HTTP protocol. It transmits credentials as a base64 encoded string in the HTTP header.
- **How It Works**:
  - The client sends an HTTP request with an `Authorization` header that contains the base64 encoded credentials (username and password).
  - Example of the header: `Authorization: Basic dXNlcjpwYXNzd29yZA==` (where `dXNlcjpwYXNzd29yZA==` is the base64 encoded "user:password").
- **Security**: Basic Authentication is not secure on its own because the credentials are encoded but not encrypted. It should always be used over HTTPS to ensure security.

### Q192. What is API Key Authentication in Web API?

**API Key Authentication**:

- **Definition**: A method of authenticating requests by including a unique key (API key) in the request.
- **How It Works**:
  - The API key is typically included in the HTTP request header, query string, or request body.
  - Example header: `Authorization: ApiKey YOUR_API_KEY_HERE`.
- **Security**: API keys are simple and easy to implement but can be less secure if not properly managed. They should be kept secret and rotated regularly.

### Q193. What is Token-Based Authentication?

**Token-Based Authentication**:

- **Definition**: A method of authentication where a token is used to access resources. The token is generated by the server and sent to the client after a successful login.
- **How It Works**:
  - The client first authenticates with the server (e.g., using username and password).
  - The server issues a token (e.g., JWT) to the client.
  - The client includes this token in the `Authorization` header of subsequent requests to access protected resources.
- **Advantages**: Tokens can be stateless, scalable, and can carry additional metadata. They are often used in RESTful APIs.

### Q194. What is JWT Authentication?

**JWT Authentication**:

- **Definition**: A specific implementation of token-based authentication using JSON Web Tokens (JWT).
- **How It Works**:
  - After the client successfully authenticates, the server issues a JWT containing encoded information.
  - The client includes the JWT in the `Authorization` header for accessing protected resources.
  - The server validates the JWT to authorize the client.
- **Benefits**: JWTs are self-contained, allowing the server to verify the token’s integrity and extract user information without needing to query a database.

### Q195. What are the parts of JWT Token?

**JWT Structure**:
A JWT is composed of three parts, separated by dots (`.`):

1. **Header**:
   - Contains metadata about the token, including the type of token and the signing algorithm.
   - Example: `{ "alg": "HS256", "typ": "JWT" }`

2. **Payload**:
   - Contains the claims or information about the user and the token. Claims can be registered, public, or private.
   - Example: `{ "sub": "1234567890", "name": "John Doe", "iat": 1516239022 }`

3. **Signature**:
   - Generated by signing the encoded header and payload with a secret key (or a private key in case of asymmetric algorithms).
   - Ensures the token's integrity and authenticity.
   - Example signature: `HMACSHA256(base64UrlEncode(header) + "." + base64UrlEncode(payload), secret)`

### Q196. Where does the JWT Token reside in the request?

**JWT Token Locations**:

- **Authorization Header**: Commonly included in the `Authorization` header of the HTTP request as `Authorization: Bearer YOUR_JWT_TOKEN_HERE`.
- **Query String**: Less common but sometimes used, e.g., `https://api.example.com/resource?token=YOUR_JWT_TOKEN_HERE`.
- **Cookies**: Can be stored in cookies (though this is less common for REST APIs).

### Q197. How to test Web API? What are the tools?

**Testing Web APIs**:

1. **Postman**:
   - A popular tool for testing and interacting with APIs. Allows you to create, send, and inspect HTTP requests and responses.

2. **cURL**:
   - A command-line tool for making HTTP requests. Useful for quick tests and scripting.

3. **Swagger**:
   - Provides interactive documentation and testing capabilities for APIs. Often integrated with API projects.

4. **Fiddler**:
   - A web debugging proxy that can capture and modify HTTP requests and responses.

5. **JUnit/ NUnit (for automated tests)**:
   - Frameworks for writing and executing automated tests for APIs, especially in conjunction with libraries like RestSharp for .NET.

### Q198. What are main Return Types supported in Web API?

**Main Return Types in Web API**:

1. **`IHttpActionResult`**: Represents the result of an action method and allows for more flexible responses.
2. **`HttpResponseMessage`**: Represents the entire HTTP response including status code, headers, and content.
3. **POCO (Plain Old CLR Object)**: Returns the data model directly, and Web API automatically serializes it to JSON or XML.

### Q199. What is the difference between `HttpResponseMessage` and `IHttpActionResult`?

**`HttpResponseMessage`**:

- **Type**: Represents the entire HTTP response, including status code, headers, and body.
- **Flexibility**: Provides full control over the response but requires more manual setup.

**`IHttpActionResult`**:

- **Type**: Represents the result of an action method and abstracts away the details of the HTTP response.
- **Flexibility**: Allows for a more declarative approach, making it easier to return standard responses and handle common scenarios.

**Example**:

```csharp
// Using HttpResponseMessage
public HttpResponseMessage Get()
{
    return Request.CreateResponse(HttpStatusCode.OK, new { Name = "John" });
}

// Using IHttpActionResult
public IHttpActionResult Get()
{
    return Ok(new { Name = "John" });
}
```

### Q200. What is the difference between `IActionResult` and `IHttpActionResult`?

**`IActionResult`** (ASP.NET Core):

- **Type**: Represents the result of an action method in ASP.NET Core MVC or Web API.
- **Features**: Allows for a wide range of result types such as `Ok()`, `NotFound()`, `Redirect()`, etc.

**`IHttpActionResult`** (ASP.NET Web API):

- **Type**: Represents the result of an action method in ASP.NET Web API.
- **Features**: Provides a set of built-in results like `Ok()`, `NotFound()`, and `BadRequest()`, but is specific to the Web API framework.

**Differences**:

- `IActionResult` is used in ASP.NET Core and is more versatile, supporting MVC and Web API. It is designed to work with the newer ASP.NET Core framework.
- `IHttpActionResult` is specific to ASP.NET Web API and was used in the older ASP.NET Web API framework.

### Q201. What is Content Negotiation in Web API?

**Content Negotiation**:

- **Definition**: A mechanism in Web API that allows the server to respond with different content types based on the client’s request. It helps in providing data in various formats like JSON, XML, or HTML.
- **How It Works**:
  - The client specifies the desired format via the `Accept` header in the HTTP request.
  - The server selects the appropriate format based on the `Accept` header and returns the response accordingly.
- **Example**:

  ```http
  Accept: application/json
  ```

  The server will return a JSON response if it supports it.

### Q202. What is `MediaTypeFormatter` class in Web API?

**`MediaTypeFormatter` Class**:

- **Definition**: A class in ASP.NET Web API that handles the serialization and deserialization of data to and from various media types.
- **Role**: It converts data to the format requested by the client and vice versa.
- **Usage**: It is used for defining how content is formatted based on the `Content-Type` or `Accept` headers.
- **Example**: `JsonMediaTypeFormatter` and `XmlMediaTypeFormatter` are built-in formatters for JSON and XML respectively.

### Q203. What are Response Codes in Web API?

**Response Codes**:

- **Definition**: HTTP status codes returned by a Web API to indicate the result of the request.
- **Common Codes**:
  - **200 OK**: Request succeeded.
  - **201 Created**: Resource created successfully.
  - **204 No Content**: Request succeeded, but no content to return.
  - **400 Bad Request**: Client-side error, invalid request.
  - **401 Unauthorized**: Authentication required or failed.
  - **403 Forbidden**: Server understands the request, but refuses to authorize it.
  - **404 Not Found**: Resource not found.
  - **500 Internal Server Error**: Server encountered an error.

### Q204. What is .NET Core?

**.NET Core**:

- **Definition**: A cross-platform, open-source framework developed by Microsoft for building modern, high-performance applications.
- **Features**:
  - **Cross-Platform**: Runs on Windows, macOS, and Linux.
  - **Modular**: Allows for including only the necessary components.
  - **Performance**: Optimized for high performance and scalability.
  - **Support**: Used for web applications, APIs, microservices, and more.

### Q205. What is .NET Standard?

**.NET Standard**:

- **Definition**: A specification that defines a set of APIs that all .NET implementations (like .NET Core, .NET Framework, and Xamarin) should implement.
- **Purpose**: To enable code sharing across different .NET platforms by providing a common set of APIs.
- **Usage**: Libraries targeting .NET Standard can be used across multiple .NET implementations without modification.

### Q206. What are the advantages of .NET Core over .NET Framework?

**Advantages of .NET Core**:

1. **Cross-Platform**: Runs on Windows, macOS, and Linux.
2. **Performance**: Improved performance and scalability compared to .NET Framework.
3. **Modular**: Smaller runtime footprint with a modular design, allowing inclusion of only necessary components.
4. **Open Source**: Actively developed and maintained by the .NET community on GitHub.
5. **Modern Features**: Supports new features and technologies faster than .NET Framework.

### Q207. What is the role of `Program.cs` file in ASP.NET Core?

**`Program.cs`**:

- **Role**: The entry point of an ASP.NET Core application. It contains the `Main` method that sets up and runs the application.
- **Responsibilities**:
  - **CreateHostBuilder**: Configures and builds the web host.
  - **Run**: Starts the application.
- **Example**:

  ```csharp
  public class Program
  {
      public static void Main(string[] args)
      {
          CreateHostBuilder(args).Build().Run();
      }

      public static IHostBuilder CreateHostBuilder(string[] args) =>
          Host.CreateDefaultBuilder(args)
              .ConfigureWebHostDefaults(webBuilder =>
              {
                  webBuilder.UseStartup<Startup>();
              });
  }
  ```

### Q208. What is the role of `ConfigureServices` method?

**`ConfigureServices` Method**:

- **Role**: Configures the services required by the application, including services needed for dependency injection.
- **Responsibilities**:
  - **Add Services**: Registers services such as MVC, Entity Framework, and Identity.
  - **Configure Options**: Sets up application configuration options.
- **Example**:

  ```csharp
  public void ConfigureServices(IServiceCollection services)
  {
      services.AddControllersWithViews();
      services.AddDbContext<ApplicationDbContext>(options =>
          options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
  }
  ```

### Q209. What is the role of `Configure` method?

**`Configure` Method**:

- **Role**: Sets up the HTTP request pipeline and middleware components.
- **Responsibilities**:
  - **Configure Middleware**: Adds middleware components like routing, authentication, and error handling.
  - **Define Pipeline**: Specifies how requests are processed and responses are generated.
- **Example**:

  ```csharp
  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
      if (env.IsDevelopment())
      {
          app.UseDeveloperExceptionPage();
      }
      else
      {
          app.UseExceptionHandler("/Home/Error");
          app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseRouting();
      app.UseAuthorization();
      app.UseEndpoints(endpoints =>
      {
          endpoints.MapControllerRoute(
              name: "default",
              pattern: "{controller=Home}/{action=Index}/{id?}");
      });
  }
  ```

### Q210. Describe the complete Request Processing Pipeline for ASP.NET Core MVC?

**Request Processing Pipeline**:

1. **Request Reception**: The ASP.NET Core server receives the HTTP request.
2. **Middleware Pipeline**: The request passes through a series of middleware components configured in the `Configure` method of `Startup.cs`. Middleware components can handle tasks like authentication, logging, error handling, and more.
3. **Routing**: The routing middleware matches the request to an endpoint (usually a controller action) based on the URL pattern.
4. **MVC Middleware**: If the request matches an MVC route, the MVC middleware invokes the appropriate controller action.
5. **Action Execution**: The selected action method is executed, and it generates a response, often by rendering a view.
6. **Response Generation**: The response is passed back through the middleware pipeline, which can modify or handle the response (e.g., adding headers).
7. **Response Sent**: The final response is sent back to the client.

### Q211. What is the difference between .NET Core and .NET 5?

**.NET Core vs .NET 5**:

- **.NET Core**:
  - **Definition**: A cross-platform framework for building modern, high-performance applications. Versions include .NET Core 1.0, 2.0, and 3.1.
  - **Support**: Supported until .NET 5 was released.
  - **Focus**: Primarily designed to run on multiple platforms (Windows, macOS, Linux).

- **.NET 5**:
  - **Definition**: The successor to .NET Core and the first release in the unified .NET platform that combines .NET Core and .NET Framework into a single product.
  - **Support**: Supports modern application development across platforms and is a step towards the future .NET 6 and beyond.
  - **Focus**: Unifies .NET Core, .NET Framework, and Xamarin into one platform, enhancing cross-platform support and performance.

### Q212. What is a Metapackage? What is the name of the Metapackage provided by ASP.NET Core?

**Metapackage**:

- **Definition**: A package that includes a collection of other packages. It simplifies the management of dependencies by providing a single package that includes everything needed for a specific functionality or platform.

**ASP.NET Core Metapackage**:

- **Name**: `Microsoft.AspNetCore.App`
  - **Purpose**: Provides a comprehensive set of libraries needed for developing ASP.NET Core applications. It includes libraries for MVC, Razor, Identity, and more.

### Q213. What is Dependency Injection?

**Dependency Injection (DI)**:

- **Definition**: A design pattern used to manage dependencies between objects by injecting them rather than having the object create them. It promotes loose coupling and enhances testability.
- **Example**: Instead of an object creating its dependencies internally, they are provided by an external source (like a DI container).

### Q214. How to implement Dependency Injection in .NET Core?

**Implementing DI in .NET Core**:

1. **Register Services**: Add services to the DI container in the `ConfigureServices` method in `Startup.cs`.

   ```csharp
   public void ConfigureServices(IServiceCollection services)
   {
       services.AddTransient<IMyService, MyService>();
   }
   ```

2. **Inject Services**: Use constructor injection to get the service in your class.

   ```csharp
   public class MyController : Controller
   {
       private readonly IMyService _myService;

       public MyController(IMyService myService)
       {
           _myService = myService;
       }

       public IActionResult Index()
       {
           var data = _myService.GetData();
           return View(data);
       }
   }
   ```

### Q215. What are the advantages of Dependency Injection in .NET Core?

**Advantages**:

1. **Loose Coupling**: Reduces the dependencies between classes, making the system more modular.
2. **Improved Testability**: Facilitates unit testing by allowing dependencies to be mocked or stubbed.
3. **Enhanced Flexibility**: Makes it easier to swap implementations or configure dependencies.
4. **Centralized Configuration**: Services are configured in one place (`Startup.cs`), simplifying management and changes.

### Q216. How to use Dependency Injection in Views in ASP.NET Core?

**Using DI in Views**:

- **Method**: Inject services into views using the `@inject` directive.

  ```csharp
  @using MyApp.Services
  @inject IMyService MyService

  <h1>@MyService.GetData()</h1>
  ```

- **Requirements**: Ensure that the service is registered in the DI container and that the view is a Razor view where `@inject` is supported.

### Q217. What are the types of Service Lifetimes of an object in ASP.NET Core?

**Service Lifetimes**:

1. **Singleton**:
   - **Definition**: Creates a single instance of the service throughout the application's lifetime.
   - **Usage**: For services that are stateless and can be shared.
   - **Method**: `services.AddSingleton<TService, TImplementation>();`

2. **Scoped**:
   - **Definition**: Creates one instance per request (or per scope in some cases).
   - **Usage**: For services that need to maintain state within a request.
   - **Method**: `services.AddScoped<TService, TImplementation>();`

3. **Transient**:
   - **Definition**: Creates a new instance each time it is requested.
   - **Usage**: For lightweight, stateless services.
   - **Method**: `services.AddTransient<TService, TImplementation>();`

### Q218. What is `AddSingleton`, `AddScoped`, and `AddTransient` method?

**`AddSingleton`, `AddScoped`, and `AddTransient`**:

- **`AddSingleton`**: Registers a service with a single instance for the application's lifetime.

  ```csharp
  services.AddSingleton<IMyService, MyService>();
  ```

- **`AddScoped`**: Registers a service with one instance per request or scope.

  ```csharp
  services.AddScoped<IMyService, MyService>();
  ```

- **`AddTransient`**: Registers a service with a new instance each time it is requested.

  ```csharp
  services.AddTransient<IMyService, MyService>();
  ```

### Q219. What is Middleware in ASP.NET Core? What is custom middleware?

**Middleware**:

- **Definition**: Software components that handle HTTP requests and responses in an ASP.NET Core application. They form the request processing pipeline.
- **Purpose**: Can perform tasks like logging, authentication, error handling, and response modification.

**Custom Middleware**:

- **Definition**: Middleware that you create to handle specific tasks not covered by built-in middleware.
- **Implementation**:

  ```csharp
  public class CustomMiddleware
  {
      private readonly RequestDelegate _next;

      public CustomMiddleware(RequestDelegate next)
      {
          _next = next;
      }

      public async Task InvokeAsync(HttpContext context)
      {
          // Custom logic
          await _next(context);
      }
  }
  ```

  - **Registration**:

    ```csharp
    public void Configure(IApplicationBuilder app)
    {
        app.UseMiddleware<CustomMiddleware>();
    }
    ```

### Q220. How ASP.NET Core Middleware is different from HttpModule?

**ASP.NET Core Middleware vs HttpModule**:

- **Middleware**:
  - **Platform**: Used in ASP.NET Core applications.
  - **Design**: Part of a request pipeline; each middleware component can process the request and pass it to the next component.
  - **Configuration**: Configured in the `Startup.cs` file using `UseMiddleware<T>()`.

- **HttpModule**:
  - **Platform**: Used in ASP.NET (Web Forms and MVC).
  - **Design**: A component that can handle events in the HTTP request pipeline, such as `BeginRequest` and `EndRequest`.
  - **Configuration**: Configured in `web.config` and used to hook into the request lifecycle.

Middleware in ASP.NET Core is designed to be more modular and composable compared to HttpModules in the older ASP.NET framework.

### Q221. What is Request Delegate in .NET Core?

**Request Delegate**:

- **Definition**: A delegate that handles HTTP requests in the ASP.NET Core middleware pipeline. It is a function that takes an `HttpContext` and returns a `Task`.
- **Usage**: Used to process HTTP requests and responses, and to pass the request through the middleware pipeline.
- **Example**:

  ```csharp
  public class RequestDelegateExample
  {
      private readonly RequestDelegate _next;

      public RequestDelegateExample(RequestDelegate next)
      {
          _next = next;
      }

      public async Task InvokeAsync(HttpContext context)
      {
          // Custom logic before next middleware
          await _next(context);
          // Custom logic after next middleware
      }
  }
  ```

### Q222. What are the `Run()`, `Use()`, and `Map()` methods?

**`Run()`**:

- **Definition**: Adds a terminal middleware to the pipeline. It handles the request and does not call the next middleware.
- **Usage**: Ends the pipeline processing.
- **Example**:

  ```csharp
  app.Run(async context =>
  {
      await context.Response.WriteAsync("Hello, World!");
  });
  ```

**`Use()`**:

- **Definition**: Adds a middleware to the pipeline. It can call the next middleware in the pipeline.
- **Usage**: Used for adding middleware components that can process requests and responses.
- **Example**:

  ```csharp
  app.Use(async (context, next) =>
  {
      // Custom logic before next middleware
      await next();
      // Custom logic after next middleware
  });
  ```

**`Map()`**:

- **Definition**: Maps a middleware to a specific path in the pipeline. It creates a new branch in the pipeline for that path.
- **Usage**: Allows you to apply middleware only for specific URL paths.
- **Example**:

  ```csharp
  app.Map("/admin", adminApp =>
  {
      adminApp.Run(async context =>
      {
          await context.Response.WriteAsync("Admin area");
      });
  });
  ```

### Q223. What are the types of Hosting in ASP.NET Core? What is In-process and Out-of-process hosting?

**Types of Hosting**:

1. **In-process Hosting**:
   - **Definition**: The ASP.NET Core application runs inside the IIS worker process (`w3wp.exe`).
   - **Advantages**: Lower latency and better performance as it avoids the overhead of inter-process communication.
   - **Setup**: Enabled by default when using IIS with ASP.NET Core.

2. **Out-of-process Hosting**:
   - **Definition**: The ASP.NET Core application runs in a separate process from IIS (using Kestrel), and IIS acts as a reverse proxy to forward requests to the application.
   - **Advantages**: Greater flexibility and isolation of the application process.
   - **Setup**: Requires configuration in `web.config` for IIS to forward requests to the Kestrel server.

### Q224. What is Kestrel? What is the difference between Kestrel and IIS?

**Kestrel**:

- **Definition**: A cross-platform, high-performance web server used to host ASP.NET Core applications. It is the default server used in .NET Core applications.
- **Function**: Handles HTTP requests directly and can be used as a standalone web server or behind a reverse proxy.

**Difference between Kestrel and IIS**:

- **Kestrel**:
  - **Platform**: Cross-platform, lightweight, and designed for high performance.
  - **Use**: Can be used as a standalone server or behind a reverse proxy.

- **IIS (Internet Information Services)**:
  - **Platform**: Windows-specific web server.
  - **Use**: Often used as a reverse proxy for Kestrel in out-of-process hosting, providing additional features like security and management.

### Q225. What is Routing? Explain attribute routing in ASP.NET Core?

**Routing**:

- **Definition**: The process of mapping incoming HTTP requests to the appropriate controller actions or endpoints in an ASP.NET Core application.
- **Purpose**: Directs requests to the correct handler based on the URL and HTTP method.

**Attribute Routing**:

- **Definition**: A way to define routes using attributes directly on controller actions and controllers.
- **Usage**: Allows for more control over routing, making it easier to define complex routes.
- **Example**:

  ```csharp
  [Route("api/[controller]")]
  public class ProductsController : Controller
  {
      [HttpGet("{id}")]
      public IActionResult Get(int id)
      {
          // Get product by id
      }

      [HttpPost]
      public IActionResult Create([FromBody] Product product)
      {
          // Create a new product
      }
  }
  ```

### Q226. Explain default project structure in ASP.NET Core application?

**Default Project Structure**:

1. **`Program.cs`**: Contains the `Main` method which is the entry point of the application. Sets up and runs the host.
2. **`Startup.cs`**: Configures services and the application's request pipeline. Contains `ConfigureServices` and `Configure` methods.
3. **`appsettings.json`**: Configuration file for application settings (e.g., connection strings, app settings).
4. **`Controllers/`**: Contains MVC controller classes.
5. **`Models/`**: Contains model classes used in the application.
6. **`Views/`**: Contains Razor views for rendering HTML (if using MVC).
7. **`wwwroot/`**: The web root directory for static files like CSS, JavaScript, and images.
8. **`Properties/`**: Contains project properties and configuration files (e.g., `launchSettings.json`).

### Q227. How does ASP.NET Core serve static files?

**Serving Static Files**:

- **Definition**: Static files are served directly to the client without any server-side processing.
- **Implementation**: Use the `UseStaticFiles` middleware in the `Configure` method of `Startup.cs`.
- **Example**:

  ```csharp
  public void Configure(IApplicationBuilder app)
  {
      app.UseStaticFiles(); // Enables static file serving
  }
  ```

- **File Location**: Typically located in the `wwwroot` folder.

### Q228. What are the roles of `appsettings.json` and `launchSettings.json` files?

**`appsettings.json`**:

- **Role**: Contains configuration settings for the application, such as connection strings, logging configuration, and application-specific settings.
- **Usage**: Configured and accessed using the configuration API.

**`launchSettings.json`**:

- **Role**: Contains settings used when debugging or running the application from the development environment. Defines profiles for IIS Express and Kestrel.
- **Usage**: Configures how the application should be launched during development.

### Q229. What are the various techniques to save configuration settings in .NET Core?

**Techniques to Save Configuration Settings**:

1. **`appsettings.json`**: For general application settings.
2. **Environment Variables**: For settings that vary by deployment environment.
3. **User Secrets**: For storing sensitive settings during development (using `dotnet user-secrets`).
4. **Command-line Arguments**: For passing settings at runtime.
5. **Azure Key Vault**: For managing secrets in Azure.

### Q230. What is CORS? Why is CORS restriction required? How to fix CORS error?

**CORS (Cross-Origin Resource Sharing)**:

- **Definition**: A security feature implemented by browsers to prevent web pages from making requests to a different domain than the one that served the web page.
- **Purpose**: To protect users from potential malicious actions that could occur when web pages request data from another domain without proper permissions.

**Fixing CORS Errors**:

- **Configuration**: Configure CORS in ASP.NET Core by using the `AddCors` method in `Startup.cs`.
- **Example**:

  ```csharp
  public void ConfigureServices(IServiceCollection services)
  {
      services.AddCors(options =>
      {
          options.AddPolicy("AllowSpecificOrigin",
              builder => builder.WithOrigins("https://example.com")
                                .AllowAnyMethod()
                                .AllowAnyHeader());
      });
  }

  public void Configure(IApplicationBuilder app)
  {
      app.UseCors("AllowSpecificOrigin");
  }
  ```

### Q231. What is In-Memory Caching & Distributed Caching?

**In-Memory Caching**:

- **Definition**: A caching mechanism where data is stored directly in the memory of the server process. It is used to store data temporarily and quickly access it without requiring a database or external service.
- **Characteristics**:
  - **Scope**: Data is available only to the application instance that stores it.
  - **Performance**: High performance due to fast access times.
  - **Lifetime**: Data is lost if the application restarts or the server process stops.
- **Usage Example**:

  ```csharp
  public class Startup
  {
      public void ConfigureServices(IServiceCollection services)
      {
          services.AddMemoryCache();
      }

      public void Configure(IApplicationBuilder app, IMemoryCache memoryCache)
      {
          // Example of storing and retrieving data from in-memory cache
          memoryCache.Set("myKey", "myValue");
          var value = memoryCache.Get("myKey");
      }
  }
  ```

**Distributed Caching**:

- **Definition**: A caching mechanism where data is stored in a distributed cache server (e.g., Redis, SQL Server). It allows multiple application instances to share the same cache, providing a central caching solution.
- **Characteristics**:
  - **Scope**: Data is available across multiple application instances.
  - **Performance**: Generally good performance, but may introduce network latency.
  - **Lifetime**: Data persists beyond application restarts and server processes.
- **Usage Example** (Using Redis):

  ```csharp
  public class Startup
  {
      public void ConfigureServices(IServiceCollection services)
      {
          services.AddStackExchangeRedisCache(options =>
          {
              options.Configuration = "localhost:6379"; // Redis server configuration
              options.InstanceName = "SampleInstance:";
          });
      }

      public void Configure(IApplicationBuilder app, IDistributedCache distributedCache)
      {
          // Example of storing and retrieving data from distributed cache
          distributedCache.SetString("myKey", "myValue");
          var value = distributedCache.GetString("myKey");
      }
  }
  ```

### Q232. How to Handle Errors in ASP.NET Core?

**Handling Errors**:

1. **Use Exception Middleware**:
   - **Purpose**: Provides a generic error handling middleware to catch exceptions and handle them.
   - **Example**:

     ```csharp
     public void Configure(IApplicationBuilder app)
     {
         app.UseExceptionHandler("/Home/Error");
         app.UseHsts();
     }
     ```

2. **Use Custom Exception Handling Middleware**:
   - **Purpose**: Allows custom logic for error handling.
   - **Example**:

     ```csharp
     public class ExceptionMiddleware
     {
         private readonly RequestDelegate _next;

         public ExceptionMiddleware(RequestDelegate next)
         {
             _next = next;
         }

         public async Task InvokeAsync(HttpContext context)
         {
             try
             {
                 await _next(context);
             }
             catch (Exception ex)
             {
                 // Log exception and handle error response
                 context.Response.StatusCode = 500;
                 await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
             }
         }
     }
     ```

3. **Use `Try-Catch` in Controllers**:
   - **Purpose**: Handle exceptions within action methods.
   - **Example**:

     ```csharp
     public IActionResult MyAction()
     {
         try
         {
             // Code that may throw an exception
         }
         catch (Exception ex)
         {
             // Handle exception and return an appropriate response
             return StatusCode(500, "Internal server error.");
         }
     }
     ```

4. **Use Error Pages**:
   - **Purpose**: Display user-friendly error pages.
   - **Example**:

     ```csharp
     public void Configure(IApplicationBuilder app)
     {
         app.UseStatusCodePagesWithReExecute("/Error/{0}");
     }
     ```

### Q233. What are Razor Pages in .NET Core?

**Razor Pages**:

- **Definition**: A page-based programming model for building web applications in ASP.NET Core. Razor Pages make it easy to build dynamic web pages with a simple, page-focused approach.
- **Characteristics**:
  - **Page-Centric**: Each Razor Page is a single file with a `.cshtml` extension containing both the markup and the logic.
  - **Model Binding**: Pages use a model class to handle form data and other inputs.
  - **Separation of Concerns**: Provides a clear separation between the UI (markup) and the logic (C# code).
- **File Structure**:
  - **`.cshtml`**: Contains the HTML markup and Razor syntax.
  - **`.cshtml.cs`**: Contains the page model with C# code.
- **Usage Example**:
  - **Page** (`Index.cshtml`):

    ```html
    @page
    @model MyApp.Pages.IndexModel
    <h2>@Model.Message</h2>
    ```

  - **Page Model** (`Index.cshtml.cs`):

    ```csharp
    public class IndexModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Hello, Razor Pages!";
        }
    }
    ```

### Q234. What are SOLID Principles? What is the difference between SOLID Principles and Design Patterns?

**SOLID Principles**:

- **Definition**: A set of five design principles aimed at making software designs more understandable, flexible, and maintainable.
- **Components**:
  1. **Single Responsibility Principle (SRP)**: A class should have only one reason to change, meaning it should have only one job or responsibility.
  2. **Open-Closed Principle (OCP)**: Software entities (classes, modules, functions) should be open for extension but closed for modification.
  3. **Liskov Substitution Principle (LSP)**: Objects of a superclass should be replaceable with objects of a subclass without altering the correctness of the program.
  4. **Interface Segregation Principle (ISP)**: Clients should not be forced to depend on interfaces they do not use. Interfaces should be specific to the client’s needs.
  5. **Dependency Inversion Principle (DIP)**: High-level modules should not depend on low-level modules. Both should depend on abstractions. Abstractions should not depend on details. Details should depend on abstractions.

**Difference between SOLID Principles and Design Patterns**:

- **SOLID Principles**:
  - Focus on improving the design and architecture of code to make it more maintainable, scalable, and robust.
  - Serve as guidelines for writing better object-oriented code.
  - **Example**: SRP is about ensuring a class has a single responsibility, while OCP is about allowing changes through extensions without modifying existing code.

- **Design Patterns**:
  - Proven solutions to common software design problems.
  - Provide templates for solving specific problems in a reusable and adaptable way.
  - **Example**: The Singleton pattern ensures a class has only one instance, while the Factory pattern provides a way to create objects without specifying the exact class.

### Q235. What is Single Responsibility Principle?

**Single Responsibility Principle (SRP)**:

- **Definition**: A class should have only one reason to change, meaning it should have only one job or responsibility.
- **Objective**: Improve maintainability and reduce the impact of changes by ensuring each class has a single responsibility.
- **Example**:
  - **Violation**:

    ```csharp
    public class Report
    {
        public void GenerateReport() { /* generate report */ }
        public void PrintReport() { /* print report */ }
        public void SaveToDatabase() { /* save report to database */ }
    }
    ```

    - **Problem**: The `Report` class has multiple responsibilities (generating, printing, saving). Changes in any of these areas affect the class.

  - **Adhering**:

    ```csharp
    public class ReportGenerator
    {
        public void GenerateReport() { /* generate report */ }
    }

    public class ReportPrinter
    {
        public void PrintReport() { /* print report */ }
    }

    public class ReportSaver
    {
        public void SaveToDatabase() { /* save report to database */ }
    }
    ```

    - **Solution**: Separate classes handle distinct responsibilities, making them easier to maintain and modify.

### Q236. What is Open-Closed Principle?

**Open-Closed Principle (OCP)**:

- **Definition**: Software entities (classes, modules, functions) should be open for extension but closed for modification.
- **Objective**: Allow the behavior of a module to be extended without modifying its source code.
- **Example**:
  - **Violation**:

    ```csharp
    public class Shape
    {
        public enum ShapeType { Circle, Rectangle }
        public ShapeType Type { get; set; }
    }

    public class AreaCalculator
    {
        public double CalculateArea(Shape shape)
        {
            if (shape.Type == Shape.ShapeType.Circle)
            {
                return /* calculate area of circle */;
            }
            else if (shape.Type == Shape.ShapeType.Rectangle)
            {
                return /* calculate area of rectangle */;
            }
            return 0;
        }
    }
    ```

  - **Adhering**:

    ```csharp
    public interface IShape
    {
        double CalculateArea();
    }

    public class Circle : IShape
    {
        public double Radius { get; set; }
        public double CalculateArea() => /* calculate area of circle */;
    }

    public class Rectangle : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double CalculateArea() => /* calculate area of rectangle */;
    }

    public class AreaCalculator
    {
        public double CalculateArea(IShape shape) => shape.CalculateArea();
    }
    ```

  - **Solution**: `IShape` interface allows new shapes to be added without modifying `AreaCalculator`.

### Q237. What is Liskov Substitution Principle?

**Liskov Substitution Principle (LSP)**:

- **Definition**: Objects of a superclass should be replaceable with objects of a subclass without altering the correctness of the program.
- **Objective**: Ensure that subclasses extend the functionality of a base class without changing its behavior.
- **Example**:
  - **Violation**:

    ```csharp
    public class Bird
    {
        public virtual void Fly() { /* fly */ }
    }

    public class Penguin : Bird
    {
        public override void Fly() { throw new NotSupportedException(); }
    }
    ```

  - **Adhering**:

    ```csharp
    public interface IBird
    {
        void Move();
    }

    public class Sparrow : IBird
    {
        public void Move() { /* fly */ }
    }

    public class Penguin : IBird
    {
        public void Move() { /* walk */ }
    }
    ```

  - **Solution**: Use an interface (`IBird`) that allows both flying and walking birds, adhering to LSP by ensuring subclasses don’t alter the base behavior inappropriately.

### Q238. What is Interface Segregation Principle?

**Interface Segregation Principle (ISP)**:

- **Definition**: Clients should not be forced to depend on interfaces they do not use. Interfaces should be specific to the client’s needs.
- **Objective**: Prevent a class from implementing methods it doesn’t need, improving modularity and reducing the impact of changes.
- **Example**:
  - **Violation**:

    ```csharp
    public interface IWorker
    {
        void Work();
        void Eat();
    }

    public class Worker : IWorker
    {
        public void Work() { /* work */ }
        public void Eat() { /* eat */ }
    }

    public class Manager : IWorker
    {
        public void Work() { /* work */ }
        public void Eat() { /* not relevant for Manager */ }
    }
    ```

  - **Adhering**:

    ```csharp
    public interface IWorkable
    {
        void Work();
    }

    public interface IEatable
    {
        void Eat();
    }

    public class Worker : IWorkable, IEatable
    {
        public void Work() { /* work */ }
        public void Eat() { /* eat */ }
    }

    public class Manager : IWorkable
    {
        public void Work() { /* work */ }
    }
    ```

  - **Solution**: Separate interfaces for different responsibilities, allowing classes to implement only the interfaces they need.

### Q239. What is Dependency Inversion Principle?

**Dependency Inversion Principle (DIP)**:

- **Definition**: High-level modules should not depend on low-level modules. Both should depend on abstractions. Abstractions should not depend on details. Details should depend on abstractions.
- **Objective**: Reduce coupling between high-level and low-level modules by depending on abstractions.
- **Example**:
  - **Violation**:

    ```csharp
    public class FileManager
    {
        public void Save(string data) { /* save to file */ }
    }

    public class DataProcessor
    {
        private FileManager fileManager;

        public DataProcessor()
        {
            fileManager = new FileManager();
        }

        public void ProcessData(string data)
        {
            fileManager.Save(data);
        }
    }
    ```

  - **Adhering**:

    ```csharp
    public interface IStorage
    {
        void Save(string data);
    }

    public class FileStorage : IStorage
    {
        public void Save(string data) { /* save to file */ }
    }

    public class DataProcessor
    {
        private readonly IStorage storage;

        public DataProcessor(IStorage storage)
        {
            this.storage = storage;
        }

        public void ProcessData(string data)
        {
            storage.Save(data);
        }
    }
    ```

  - **Solution**: Use dependency injection to pass an abstraction (`IStorage`) to `DataProcessor`, decoupling it from specific storage implementations.

### Q240. What is DRY Principle?

**DRY Principle**:

- **Definition**: Don’t Repeat Yourself. Aim to reduce duplication of code by abstracting common functionality into reusable components.
- **Objective**: Improve maintainability and reduce redundancy by ensuring that every piece of knowledge or logic is represented in only one place.
- **Example**:
  - **Violation**:

    ```csharp
    public class OrderProcessor
    {
        public void ProcessOrder(Order order)
        {
            // Order processing logic
            SendOrderConfirmation(order);
        }

        public void SendOrderConfirmation(Order order)
        {
            // Sending email logic
        }
    }

    public class CustomerSupport
    {
        public void SendOrderConfirmation(Order order)
        {
            // Sending email logic
        }


    }
    ```

  - **Adhering**:

    ```csharp
    public class EmailService
    {
        public void SendOrderConfirmation(Order order)
        {
            // Sending email logic
        }
    }

    public class OrderProcessor
    {
        private readonly EmailService emailService;

        public OrderProcessor(EmailService emailService)
        {
            this.emailService = emailService;
        }

        public void ProcessOrder(Order order)
        {
            // Order processing logic
            emailService.SendOrderConfirmation(order);
        }
    }

    public class CustomerSupport
    {
        private readonly EmailService emailService;

        public CustomerSupport(EmailService emailService)
        {
            this.emailService = emailService;
        }

        public void HandleCustomerInquiries(Order order)
        {
            emailService.SendOrderConfirmation(order);
        }
    }
    ```

  - **Solution**: Extract the common functionality into a separate class (`EmailService`), eliminating redundancy and centralizing the logic.

### Q241. What are Design Patterns and What Problems Do They Solve?

**Design Patterns**:

- **Definition**: Design patterns are reusable solutions to common problems that occur during software design. They provide a template for solving specific design issues and help improve code structure, maintainability, and readability.
- **Problems Solved**:
  - **Code Reusability**: Promote reuse of design solutions across different parts of an application or different projects.
  - **Maintainability**: Enhance the ability to modify and extend the software without introducing bugs.
  - **Readability**: Improve code clarity by providing standard solutions to common problems.
  - **Flexibility**: Allow changes to be made to a system with minimal impact on existing code.

### Q242. What Are the Types of Design Patterns?

Design patterns are generally categorized into three types:

1. **Creational Patterns**: Concerned with the process of object creation, providing solutions to instantiate objects in a manner suitable to the situation.
2. **Structural Patterns**: Deal with the composition of classes or objects, focusing on creating relationships between entities to form larger structures.
3. **Behavioral Patterns**: Focus on the interaction and responsibility between objects, facilitating communication and assignment of responsibilities.

### Q243. What Are Creational Design Patterns?

**Creational Design Patterns**:

- **Definition**: These patterns are used to create objects in a manner that enhances flexibility and reuse of the code. They abstract the instantiation process and provide a way to create objects that can be adapted to different scenarios.
- **Examples**:
  1. **Singleton Pattern**
  2. **Factory Method Pattern**
  3. **Abstract Factory Pattern**
  4. **Builder Pattern**
  5. **Prototype Pattern**

### Q244. What Are Structural Design Patterns?

**Structural Design Patterns**:

- **Definition**: These patterns deal with object composition, defining the way objects and classes interact and how they are combined to form larger structures. They help ensure that if one part of a system changes, the entire system doesn’t need to change.
- **Examples**:
  1. **Adapter Pattern**
  2. **Decorator Pattern**
  3. **Facade Pattern**
  4. **Composite Pattern**
  5. **Bridge Pattern**
  6. **Flyweight Pattern**

### Q245. What Are Behavioral Design Patterns?

**Behavioral Design Patterns**:

- **Definition**: These patterns focus on communication between objects, defining how objects interact, distribute responsibilities, and perform tasks. They help to manage algorithms, relationships, and responsibilities among objects.
- **Examples**:
  1. **Observer Pattern**
  2. **Strategy Pattern**
  3. **Command Pattern**
  4. **State Pattern**
  5. **Mediator Pattern**
  6. **Iterator Pattern**
  7. **Template Method Pattern**

### Q246. What Is the Singleton Design Pattern?

**Singleton Design Pattern**:

- **Definition**: The Singleton pattern ensures that a class has only one instance and provides a global point of access to that instance. It is used when exactly one instance of a class is needed to coordinate actions across the system.
- **Problem Solved**: Prevents the creation of multiple instances of a class, ensuring that only one instance exists and is accessible throughout the application.

**Example**:

**1. Singleton Pattern Implementation**:

```csharp
public class Singleton
{
    private static Singleton _instance;
    private static readonly object _lock = new object();

    // Private constructor to prevent instantiation
    private Singleton() { }

    public static Singleton Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
                return _instance;
            }
        }
    }

    public void DoSomething()
    {
        // Method implementation
    }
}
```

**Usage**:

```csharp
public class Program
{
    public static void Main()
    {
        // Get the singleton instance and use its method
        Singleton singleton = Singleton.Instance;
        singleton.DoSomething();
    }
}
```

- **Explanation**:
  - **Private Constructor**: Prevents direct instantiation from outside the class.
  - **Static Instance**: Holds the single instance of the class.
  - **Lock**: Ensures thread safety in a multi-threaded environment.
  - **Instance Property**: Provides a global point of access to the single instance.

**Use Case**:

- **Configuration Manager**: Ensures that configuration settings are consistent and loaded only once during the application’s lifecycle.
- **Logging**: A logging service that ensures a single instance is used across the application to manage logs efficiently.

### Q247. How to Make Singleton Pattern Thread-Safe?

**Thread Safety in Singleton Pattern**:
To ensure that the Singleton pattern is thread-safe, you need to manage concurrent access to the instance creation process. There are several methods to achieve this:

1. **Eager Initialization**:
   - **Approach**: Create the singleton instance at the time of class loading.
   - **Pros**: Simple and thread-safe.
   - **Cons**: The instance is created even if it might not be used, potentially wasting resources.

   ```csharp
   public class Singleton
   {
       private static readonly Singleton _instance = new Singleton();
       
       // Private constructor to prevent instantiation
       private Singleton() { }
       
       public static Singleton Instance => _instance;
       
       public void DoSomething()
       {
           // Method implementation
       }
   }
   ```

2. **Lazy Initialization with Locking**:
   - **Approach**: Use a `lock` statement to ensure that only one thread can create the instance.
   - **Pros**: Ensures that the instance is created only when needed.
   - **Cons**: Slight overhead due to locking.

   ```csharp
   public class Singleton
   {
       private static Singleton _instance;
       private static readonly object _lock = new object();
       
       // Private constructor to prevent instantiation
       private Singleton() { }
       
       public static Singleton Instance
       {
           get
           {
               lock (_lock)
               {
                   if (_instance == null)
                   {
                       _instance = new Singleton();
                   }
                   return _instance;
               }
           }
       }
       
       public void DoSomething()
       {
           // Method implementation
       }
   }
   ```

3. **Double-Checked Locking**:
   - **Approach**: Use a `lock` statement but only check for the instance being `null` within the locked section. This minimizes locking overhead.
   - **Pros**: Optimizes performance by reducing the number of lock operations.
   - **Cons**: More complex implementation.

   ```csharp
   public class Singleton
   {
       private static Singleton _instance;
       private static readonly object _lock = new object();
       
       // Private constructor to prevent instantiation
       private Singleton() { }
       
       public static Singleton Instance
       {
           get
           {
               if (_instance == null)
               {
                   lock (_lock)
                   {
                       if (_instance == null)
                       {
                           _instance = new Singleton();
                       }
                   }
               }
               return _instance;
           }
       }
       
       public void DoSomething()
       {
           // Method implementation
       }
   }
   ```

4. **Lazy<T> Initialization** (Recommended):
   - **Approach**: Use `Lazy<T>` to handle thread-safe lazy initialization.
   - **Pros**: Simple and handles multi-threading issues automatically.

   ```csharp
   public class Singleton
   {
       private static readonly Lazy<Singleton> _instance = 
           new Lazy<Singleton>(() => new Singleton());
       
       // Private constructor to prevent instantiation
       private Singleton() { }
       
       public static Singleton Instance => _instance.Value;
       
       public void DoSomething()
       {
           // Method implementation
       }
   }
   ```

### Q248. What Is the Factory Pattern? Why Use the Factory Pattern?

**Factory Pattern**:

- **Definition**: The Factory Pattern provides a way to create objects without specifying the exact class of the object that will be created. It defines an interface for creating an object but allows subclasses to alter the type of objects that will be created.
- **Purpose**:
  - **Encapsulate Object Creation**: Separate the creation logic from the actual usage of the object.
  - **Promote Loose Coupling**: Decouple the client code from the specific classes it needs to instantiate.
  - **Enhance Code Maintainability**: Simplify code changes related to object creation.

**Example**:

```csharp
// Product interface
public interface IProduct
{
    string GetName();
}

// Concrete Products
public class ConcreteProductA : IProduct
{
    public string GetName() => "Product A";
}

public class ConcreteProductB : IProduct
{
    public string GetName() => "Product B";
}

// Creator Class
public abstract class Creator
{
    public abstract IProduct FactoryMethod();
}

// Concrete Creator
public class ConcreteCreatorA : Creator
{
    public override IProduct FactoryMethod() => new ConcreteProductA();
}

public class ConcreteCreatorB : Creator
{
    public override IProduct FactoryMethod() => new ConcreteProductB();
}

// Client Code
public class Client
{
    public void DoSomething(Creator creator)
    {
        IProduct product = creator.FactoryMethod();
        Console.WriteLine(product.GetName());
    }
}

// Usage
var client = new Client();
var creatorA = new ConcreteCreatorA();
var creatorB = new ConcreteCreatorB();

client.DoSomething(creatorA); // Output: Product A
client.DoSomething(creatorB); // Output: Product B
```

### Q249. How to Implement Factory Method Pattern?

**Factory Method Pattern**:

- **Definition**: A creational design pattern that defines an interface for creating objects, but allows subclasses to alter the type of objects that will be created. The Factory Method Pattern lets a class delegate the responsibility of creating objects to its subclasses.

**Example**:

```csharp
// Product interface
public interface IProduct
{
    string GetName();
}

// Concrete Products
public class ProductA : IProduct
{
    public string GetName() => "Product A";
}

public class ProductB : IProduct
{
    public string GetName() => "Product B";
}

// Creator Class
public abstract class Creator
{
    public abstract IProduct FactoryMethod();
}

// Concrete Creator Classes
public class CreatorA : Creator
{
    public override IProduct FactoryMethod() => new ProductA();
}

public class CreatorB : Creator
{
    public override IProduct FactoryMethod() => new ProductB();
}

// Client Code
public class Client
{
    public void UseProduct(Creator creator)
    {
        IProduct product = creator.FactoryMethod();
        Console.WriteLine(product.GetName());
    }
}

// Usage
var client = new Client();
var creatorA = new CreatorA();
var creatorB = new CreatorB();

client.UseProduct(creatorA); // Output: Product A
client.UseProduct(creatorB); // Output: Product B
```

### Q250. What Is the Abstract Factory Pattern?

**Abstract Factory Pattern**:

- **Definition**: The Abstract Factory Pattern provides an interface for creating families of related or dependent objects without specifying their concrete classes. It allows for the creation of multiple types of objects that belong to a family or suite, ensuring that the objects are compatible with each other.

**Example**:

```csharp
// Abstract Products
public interface IButton
{
    string GetButtonType();
}

public interface ICheckbox
{
    string GetCheckboxType();
}

// Concrete Products
public class WindowsButton : IButton
{
    public string GetButtonType() => "Windows Button";
}

public class WindowsCheckbox : ICheckbox
{
    public string GetCheckboxType() => "Windows Checkbox";
}

public class MacButton : IButton
{
    public string GetButtonType() => "Mac Button";
}

public class MacCheckbox : ICheckbox
{
    public string GetCheckboxType() => "Mac Checkbox";
}

// Abstract Factory
public interface IGUIFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}

// Concrete Factories
public class WindowsFactory : IGUIFactory
{
    public IButton CreateButton() => new WindowsButton();
    public ICheckbox CreateCheckbox() => new WindowsCheckbox();
}

public class MacFactory : IGUIFactory
{
    public IButton CreateButton() => new MacButton();
    public ICheckbox CreateCheckbox() => new MacCheckbox();
}

// Client Code
public class Application
{
    private IButton _button;
    private ICheckbox _checkbox;

    public Application(IGUIFactory factory)
    {
        _button = factory.CreateButton();
        _checkbox = factory.CreateCheckbox();
    }

    public void Run()
    {
        Console.WriteLine(_button.GetButtonType());
        Console.WriteLine(_checkbox.GetCheckboxType());
    }
}

// Usage
IGUIFactory factory = new WindowsFactory();
Application app = new Application(factory);
app.Run(); // Output: Windows Button, Windows Checkbox

factory = new MacFactory();
app = new Application(factory);
app.Run(); // Output: Mac Button, Mac Checkbox
```

**Explanation**:

- **Abstract Factory**: `IGUIFactory` provides methods to create related products.
- **Concrete Factories**: `WindowsFactory` and `MacFactory` implement the abstract factory to produce products specific to their platforms.
- **Client Code**: `Application` uses the factory to create products without knowing their concrete classes.
