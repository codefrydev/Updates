---
title: "Create Your First C# Program in Visual Studio | Chapter 2"
author: ["PrashantUnity"]
weight: 102
date: 2024-06-17T00:00:00-07:00
lastmod: 2024-06-17T23:59:59-07:00
dateString: June 2024  
description: "Step-by-step guide to create and run your first C# console application using Visual Studio Community Edition with detailed screenshots"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  #display caption under cover 

tags: ["NET","C Sharp", "First Program","Hello World","Chapter 2"]
keywords: [ "Code Fry Dev", "codefrydev", "CFD","NET","C Sharp", "First Program","Hello World","Chapter 2"]
draft: false #make this false to publicly Available
---

## Create Your First C# Console Application in Visual Studio

Follow these steps to create and run a simple C# console application in Visual Studio.

### Step 1: Create a New Project
Open Visual Studio and click on **Create a New Project**.

![Choose Template](./vs1.png)

### Step 2: Choose the Console App Template
1. In the search bar, type **Console**.
2. Select **Console App** (C#) from the results.
3. Click **Next** at the bottom right of the window.

![Choose C# Console App Template](./vs2.png)

### Step 3: Configure Your Project
1. Enter your desired **Project Name**.
2. Choose a **Location** to save your project.
3. Click **Next**.

![Configure Your Project](./vs3.png)

### Step 4: Advanced Project Options
1. Tick the checkbox for **Do not use top-level statements**. This allows for a more traditional program structure.
2. Click **Create**.

![Advanced Project Options](./vs4.png)

#### Note:
If your code appears as below, it means you have unticked **Do not use top-level statements**. This doesn't affect the functionality significantly.

![Do not use top-level statements](./vs9.png)

### Step 5: Open the Program.cs File
If not already open, double-click on the **Program.cs** file to open it.

![Open the Program.cs](./vs5.png)

### Step 6: Default File Structure
Visual Studio generates a default file structure similar to the image below.

![Default File Structure](./vs6.png)

### Step 7: Run Your Application
1. Click on the green play button (shown as **2** in the image).
2. Alternatively, press **Ctrl + F5** to run the application.

![Run Your Application](./vs7.png)

### Step 8: View the Output
Your application will run, and you should see an output window similar to the image below.

![View the Output](./vs8.png)

```cs
Console.WriteLine("Hello, World!");
```
Congratulations! You have successfully created and run your first C# console application in Visual Studio. This guide covers the essential steps to get you started with C# development.
