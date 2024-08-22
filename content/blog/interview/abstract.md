---
title: "Abstract Class Interview Questions"
author: "PrashantUnity"
weight: 210
date: 2024-08-03
lastmod: 2024-10-22
dateString: August 2024  
description: "Guide of How To Create Blog Post, Categories And Etc"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "NET", "codefrydev", "C sharp", "CFD"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD"]
---

## Abstract Class Question

- Can abstract class will have non abstract method
> Yes Below Example

- Method hiding principal ( use of New KeyWord)


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