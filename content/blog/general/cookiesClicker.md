---
title: "Automated Mouse Clicker in C#"
author: ["PrashantUnity"]
weight: 999
date: 2024-07-12T00:00:00-07:00
lastmod: 2024-07-19T23:59:59-07:00
dateString: July 2024
description: "Learn how to create an automated mouse clicker application in C# using Windows API for repetitive clicking tasks" 
keywords: ["CFD","CodefryDev","Code Fry Dev","Cookies" ]

cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  #display caption under cover 
---

## Implementation in .NET Console Project

```csharp
using System.Runtime.InteropServices;

namespace MouseClicker;

public class Program
{
    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);
    private const int MOUSEEVENTF_LEFTDOWN = 0x02;
    private const int MOUSEEVENTF_LEFTUP = 0x04;
    private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
    private const int MOUSEEVENTF_RIGHTUP = 0x10;
    public static int Main(string[] args)
    {
        int count = 0;
        while(count++<10000)
        {
            DoMouseClick();
        }
        return 0;
    }
    public static void DoMouseClick()
    {
        mouse_event(MOUSEEVENTF_LEFTDOWN , 0, 0, 0, 0); 
        mouse_event( MOUSEEVENTF_LEFTUP, 0, 0, 0, 0); 
    }
}
```