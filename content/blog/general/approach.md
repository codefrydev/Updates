---
title: "Framework for Answering Interview Questions"
author: ["PrashantUnity"]
weight: 101
date: 2024-07-12T00:00:00-07:00
lastmod: 2024-07-19T23:59:59-07:00
dateString: July 2024
description: "A comprehensive framework for approaching coding interview questions with systematic problem-solving strategies" 
tags: ["Interview"]
keywords: ["CFD","CodefryDev","Code Fry Dev","Interview" ]

cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  #display caption under cover 
---



## Define Input and Output Requirements

* How is the input stored?
* What kind of values are there?
* Are there any negative values?
* Will there be any empty data?
* Can I assume there is always valid input?
* Will the size/number of data be greater than integer max value?
* Are we returning indexes/data?
* What if there are multiple answers?

---

## Analyze Data Size, Range, and Scale

* How big is the size of input?
* Do we take into account integer overflow?
* Size of array or N or Length
* What should we do if the size of data count is greater than Integer range?  
  * Suggest we can use linked list
  * own custom data type

---

## Consider the Runtime Environment

* What type of environment will the algorithm be running in?
* Can I modify the original data?
* Can I use the latest language features?

---

## Walk Through Your Solution Approach

* Start writing comments in the editor.

  * Outline step by step
  * What it is and what you will be doing
* Let them give feedback before you even start programming

---

## Best Practices During Implementation

* Always speak what you are thinking
* See if you can divide the problem into subproblems
* Separate code into logical units
* Discuss tradeoffs

  * Consider pros and cons
* Are we favoring time complexity over space complexity?
* Discuss the memory footprint because of recursion calls
* Come with your own test cases and test on them
* Explain time complexity and space complexity
