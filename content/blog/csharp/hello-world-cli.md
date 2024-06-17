---
title: "Hello World Terminal(CLI) | Chapter 2"
author: ["PrashantUnity"]
weight: 102
dateString: June 2024  
description: "Write First Program in C# using Terminal(CLI)"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "logo.png" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  #display caption under cover 

tags: [ "Code Fry Dev", "codefrydev", "CFD","NET","C Sharp", "First Program","Hello World","Chapter 2"]
draft: false #make this false to publicly Available
---

## Create a C# Console Application Using the CLI

Follow these steps to create and run a simple C# console application using the command line.

### Step 1: Open Terminal and Create a New Project
Open your terminal and type the following command to create a new console application project named "HelloWorld":
```sh
dotnet new console -o HelloWorld
```
![Create C# Console App via CLI](./cli1.png)

### Step 2: Confirm Project Creation
After pressing Enter, the command will generate a new project. You should see a confirmation message similar to the image below.

![Project Created](./cli2.png)

### Step 3: Navigate to Your Project Directory
Change your directory to the new project folder. For this example, the folder is named "HelloWorld". Use the `cd` command to navigate into the directory, and then list the files with the `ls` command:
```sh
cd HelloWorld
ls
```
You should see the contents of your project directory, similar to the image below.

![Project Directory](./cli3.png)

### Step 4: Run Your Application
Now that you have created the console application, the final step is to run it using the following command:
```sh
dotnet run
```
You will see the output of your application in the terminal, similar to the image below.

![Run Application](./cli4.png)

### Additional Note:
Your terminal may look different because I am using "Oh My Posh" to customize my terminal's appearance. For more details on how to set up and customize your terminal, check out this amazing video by **Scott Hanselman**.

{{< youtube VT2L1SXFq9U >}}

 
Congratulations! You have successfully created and run your first C# console application using the CLI. This guide provides you with the essential steps to get started with .NET development through the terminal.
 
