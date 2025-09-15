---
title: ".NET Core Framework Interview Questions - Set 18"
author: "PrashantUnity"
weight: 228
date: 2024-08-03
lastmod: 2024-10-25
dateString: August 2024  
description: "Complete tutorial guide to .NET Core framework with step-by-step explanations covering web applications, microservices, IoT development, and modern features"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "NET", "codefrydev", "C sharp", "CFD"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD"]
---

### 1. What is .NET Core Framework?
.NET Core is a free, open-source, cross-platform framework developed by Microsoft for building modern applications. It is a modular framework that can run on Windows, macOS, and Linux, providing the flexibility to develop and deploy applications across various platforms.

### 2. What are the common uses of .NET Core?
- **Web applications**: Using ASP.NET Core for building dynamic web applications.
- **Cloud-based applications**: Suitable for developing cloud apps with Azure.
- **Microservices**: Designed for building microservices architectures.
- **IoT applications**: Supports IoT development for connecting and managing devices.
- **Console applications**: Ideal for simple command-line tools and scripts.

### 3. Mention the latest version of .NET Core and any important features.
As of the latest update:
- The latest version is `.NET 7`, released in November 2022.
- Important features include improved performance, single file applications, reduced container image sizes, support for ARM64, and enhancements in JSON processing.

### 4. List the most important characteristics of .NET Core.
- **Cross-platform**: Runs on Windows, macOS, and Linux.
- **High performance**: Optimized for speed and scalability.
- **Modular**: Uses NuGet packages for modular development.
- **Open-source**: Developed and maintained by the .NET Foundation community.
- **Unified**: Combines the best features of .NET Framework, .NET Core, and Xamarin.

### 5. What is ASP.NET Core?
ASP.NET Core is a cross-platform, high-performance framework for building modern, cloud-based, internet-connected applications. It is a redesign of ASP.NET, combining MVC and Web API into a unified programming model.

### 6. Are ASP.NET Core and .NET Framework compatible?
ASP.NET Core is primarily compatible with .NET Core but can also target the full .NET Framework (Windows only) if needed. However, .NET Core libraries and ASP.NET Core projects usually aim to target .NET Core for cross-platform compatibility.

### 7. What is a Garbage Collector (GC)?
Garbage Collector (GC) is a component of the .NET runtime responsible for automatic memory management. It deallocates memory that is no longer in use by the application, helping to avoid memory leaks and optimizing performance.

### 8. Differentiate between .NET and .NET Core.
- **.NET Framework**: Windows-only, mature, supports legacy applications, includes a large library and Windows-specific APIs.
- **.NET Core**: Cross-platform, modern, optimized for performance, modular, suitable for new development across various platforms.

### 9. What languages can you use on .NET Core?
.NET Core supports multiple programming languages, including C#, F#, and Visual Basic.

### 10. How is Mono different from .NET Core?
- **Mono**: An older implementation of the .NET Framework designed primarily for cross-platform compatibility on Linux, macOS, and mobile devices. It includes a different runtime (Mono runtime).
- **.NET Core**: A newer, modern, high-performance, and fully supported cross-platform runtime for building a wide range of applications.

### 11. What is CoreCLR?
CoreCLR is the runtime for .NET Core, responsible for executing .NET applications. It provides services like garbage collection, exception handling, JIT compilation, and type safety.

### 12. What is CTS?
CTS (Common Type System) defines how types are declared, used, and managed in the .NET runtime, ensuring interoperability between different .NET languages.

### 13. What is Kestrel?
Kestrel is a cross-platform web server for ASP.NET Core applications. It's lightweight, high-performance, and is often used in combination with a reverse proxy server like IIS or Nginx for production deployments.

### 14. What is CoreFX?
CoreFX is the set of foundational libraries (like System.Collections, System.IO) used by .NET Core applications. It provides core functionality like collections, file I/O, and networking.

### 15. Is Garbage collection an ongoing process? When does it occur?
Garbage collection is a background process that occurs periodically. It runs when:
- The system has low physical memory.
- The GC.Collect() method is called explicitly.
- The allocated memory exceeds a threshold.
- The GC determines it's necessary based on its own internal logic.

### 16. What is MSIL?
MSIL (Microsoft Intermediate Language) is a low-level, CPU-independent set of instructions that .NET languages compile into. During execution, MSIL is converted into native code by the JIT compiler.

### 17. What is the key difference between Runtime and SDK in .NET Core?
- **Runtime**: Contains the libraries and components needed to run a .NET Core application.
- **SDK**: Includes the runtime along with tools needed for building and developing .NET Core applications (e.g., compilers, CLI tools).

### 18. What is .NET Core SDK?
The .NET Core SDK is a set of tools and libraries for developing .NET Core applications. It includes the .NET CLI, libraries, and runtime.

### 19. What do you mean by .NET Core middleware?
Middleware in .NET Core are software components assembled into an application pipeline to handle requests and responses. Each component can handle requests, pass them on, and modify the response. Examples include authentication, routing, and logging middleware.

### 20. What is .NET Standard?
.NET Standard is a formal specification of .NET APIs that are available across different .NET implementations (e.g., .NET Core, .NET Framework, Xamarin). It ensures code compatibility across these platforms.

### 21. Mention the main architectural components of .NET Core.
- **CoreCLR**: The runtime for executing applications.
- **CoreFX**: The set of foundational libraries.
- **CLI**: Command-line tools for development.
- **ASP.NET Core**: Framework for building web applications.
- **Language support**: C#, F#, and Visual Basic.

### 22. What is meant by Razor Pages?
Razor Pages is a simplified framework for building dynamic web pages in ASP.NET Core. It uses the Razor syntax to define UI logic, making it easier to create page-focused scenarios without the complexity of MVC.

### 23. What is unit testing?
Unit testing is a software testing method where individual components of the application (called units) are tested in isolation to ensure they function correctly.

### 24. What are NuGet packages?
NuGet packages are reusable components and libraries that developers can add to their .NET projects. They simplify dependency management and provide access to third-party libraries.

### 25. What are Empty migrations?
In Entity Framework, empty migrations are migration classes that do not have any operations defined. They are often used to apply changes to the database schema manually.

### 26. What is Explicit Compilation (Ahead of time)?
Explicit Compilation, or Ahead-of-Time (AOT) compilation, refers to the process of converting high-level code into native machine code before the application runs, rather than at runtime (like JIT). This can lead to faster startup times and improved performance.

### 27. Mention a few benefits of AOT.
- **Reduced startup time**: Pre-compiled native code loads faster.
- **Improved performance**: Optimized for the target architecture.
- **Smaller footprint**: No need to include JIT compiler in runtime.

### 28. Explain Docker in .NET Core.
Docker is a platform for developing, shipping, and running applications in containers. .NET Core's compatibility with Docker allows developers to containerize their applications, making them more portable and easier to deploy across different environments.

### 29. What is the IGCToCLR interface?
IGCToCLR is an interface used internally by the garbage collector to interact with the CLR. It handles tasks like memory allocation, collection scheduling, and providing information about object lifetimes.

### 30. What is a class library? Mention its types and methods.
A class library is a collection of reusable classes and methods that can be shared across different applications. Types of class libraries include:
- **Standard Class Library**: Compatible with .NET Standard.
- **Platform-specific Class Library**: Designed for specific platforms (e.g., .NET Framework or .NET Core).

### 31. What is the purpose of `webHostBuilder()`?
`webHostBuilder()` configures and initializes the web host for an ASP.NET Core application. It sets up services, middleware, server configurations (like Kestrel), and the request pipeline.

### 32. Why would you generate SQL scripts in .NET Core?
Generating SQL scripts is useful for:
- **Database migrations**: To update the schema in a controlled manner.
- **Database backups**: Creating schema snapshots.
- **Deployment**: Applying changes to production databases.

### 33. How do you decide when to use .NET Standard Class Library as against .NET Core Library?
- Use **.NET Standard** if you need cross-platform compatibility and your library should work on different .NET implementations (e.g., .NET Core, Xamarin).
- Use **.NET Core Library** if you're building applications exclusively for .NET Core.

### 34. Explain the difference between Task and Thread in .NET.
- **Thread**: A low-level construct for managing concurrency, representing a separate path of execution.
- **Task**: A higher-level abstraction over threads, used for asynchronous programming, which can represent both background work and parallel execution.

### 35. What's the difference between RyuJIT and Roslyn?
- **RyuJIT**: Just-In-Time (JIT) compiler for the .NET runtime, converting IL code to native machine code at runtime.
- **Roslyn**: A compiler platform for C# and VB.NET, providing APIs for code analysis, generation, and compilation.

### 36.

 Explain the meaning of state management.
State management refers to preserving the state of an application across requests. It can be done on the client-side (cookies, session storage) or server-side (sessions, database).

### 37. Give a brief about Garbage Collection.
Garbage Collection (GC) is an automatic memory management feature that reclaims memory occupied by objects that are no longer in use, helping to prevent memory leaks and optimize application performance.

### 38. What is the hosting environment?
The hosting environment determines how an application is configured and run. It includes aspects like the OS, server type, environment variables, and configuration settings (development, staging, production).

### 39. What is .NET Core CLI?
.NET Core CLI (Command-Line Interface) is a set of command-line tools for building, running, and managing .NET Core applications. Common commands include `dotnet build`, `dotnet run`, and `dotnet publish`.

### 40. What is JIT and how many types of JIT compilations do you know?
- **JIT (Just-In-Time) Compiler**: Converts IL code into native machine code at runtime.
- Types of JIT:
  - **Normal JIT**: Compiles methods as they are called.
  - **Pre-JIT (AOT)**: Compiles the entire code at deployment time.
  - **Econo-JIT**: Compiles only the required methods and removes them when not needed.

### 41. Why is the Startup Class?
The `Startup` class in ASP.NET Core is used to configure services and the app's request processing pipeline. It typically contains methods like `ConfigureServices` and `Configure` to set up dependency injection and middleware.

### 42. What is the purpose of the IDisposable interface?
`IDisposable` provides a standard way to release unmanaged resources (like file handles, database connections) explicitly. It defines the `Dispose()` method, which should be called to free resources.

### 43. What is the difference between 'managed' and 'unmanaged' code?
- **Managed code**: Executed by the .NET runtime, with automatic memory management (e.g., C#, VB.NET).
- **Unmanaged code**: Executed directly by the OS, with manual memory management (e.g., C, C++).

### 44. Is the 'debug' class the same as the 'trace' class?
- Both `Debug` and `Trace` classes are used for logging. The key difference:
  - **Debug**: Used for information only in the debug build.
  - **Trace**: Used for information in both debug and release builds.

### 45. What is MEF in .NET Core?
MEF (Managed Extensibility Framework) is a framework for creating extensible applications. It allows applications to discover and use extensions without knowing them at compile time.

### 46. What are UWP Apps in .Net Core?
UWP (Universal Windows Platform) apps are applications built using .NET Core that can run on any Windows device (PC, tablet, phone) with a single codebase.

### 47. What is MSBuild?
MSBuild (Microsoft Build Engine) is a build system for .NET applications, responsible for compiling source code, packaging, testing, and deploying software.

### 48. What is CoreRT?
CoreRT is a .NET Core runtime optimized for Ahead-of-Time (AOT) compilation, providing a way to compile .NET applications into native machine code, enabling faster startup and reduced runtime overhead.

### 49. Explain response caching.
Response caching is a technique to store server responses to reduce the need for fetching the same information multiple times. It improves performance by reducing server load and network latency.
