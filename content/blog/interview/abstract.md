---
title: "Abstract Class Interview Questions"
author: "PrashantUnity"
weight: 210
date: 2024-08-03
lastmod: 2024-10-22
dateString: August 2024  
description: "Common interview questions about abstract classes in C# with detailed explanations and code examples"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "NET", "codefrydev", "C sharp", "CFD"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD"]
---

## Abstract Class Interview Questions

- Can an abstract class have non-abstract methods?
> Yes, see the example below

- Method hiding principle (use of New keyword)


```csharp
public abstract class Animal
{
    public abstract void MakeSound();
    public void Eat()
    {
        Console.WriteLine("Eating...");
    }

    public void IsAlive()
    {
        Console.WriteLine("Yes");
    }
    public virtual void Sleep()
    {
        Console.WriteLine("Sleeping...");
    }
}

public class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("The dog barks.");
    }
    public void Bark()
    {
        Console.WriteLine("Barking...");
    }
    public new void IsAlive()
    {
        Console.WriteLine("NO");
    }
    public override void Sleep()
    {
        Console.WriteLine("The dog barks Sleeping.");
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Create an instance of the Dog class
        Dog myDog = new Dog();

        // Call methods from the abstract class (Animal)
        myDog.Eat();    // Output: Eating...
        myDog.Sleep();      // Output: The dog barks Sleeping.
    }
}

```