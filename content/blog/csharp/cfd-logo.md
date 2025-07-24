---
title: "Codefrydev Generally used Loading  svg animation"
author: ["PrashantUnity"]
weight: 105
date: 2024-07-24
lastmod: 2024-07-24
dateString: July 2025  
description: "CFD- Animated Loading Animated animation"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  #display caption under cover 

tags: [ "NET","C Sharp", "Input","output","Chapter 3","Comment","variable"]
keywords: [ "Code Fry Dev", "codefrydev", "CFD","NET","C Sharp"]
draft: false #make this false to publicly Available
---

## Loading Animation

```svg
<?xml version="1.0" encoding="UTF-8" standalone="no"?>
<svg width="300" height="300" viewBox="0 0 32 32" xmlns="http://www.w3.org/2000/svg">
    <text x="1" y="29" font-size="7" fill="white" font-family="Ubuntu">CFD AI</text>
    <style>
        .spinner {
        animation: move 2.4s linear infinite;
        }

        .delay1 {
        animation-delay: -2.4s;
        fill: #9BFAFF;
        }

        .delay2 {
        animation-delay: -1.6s;
        fill: #FFBD4D;
        }

        .delay3 {
        animation-delay: -0.8s;
        fill: #FFF8B3;
        }

        @keyframes move {
        0%, 8.33% {
        x: 2px;
        y: 2px;
        }
        25% {
        x: 13px;
        y: 2px;
        }
        33.3%, 50% {
        x: 13px;
        y: 13px;
        }
        58.33%, 75% {
        x: 2px;
        y: 13px;
        }
        83.33%, 100% {
        x: 2px;
        y: 2px;
        }
        }
    </style>

    <rect class="spinner delay1" x="2" y="2" rx="2" width="10" height="10"/>
    <rect class="spinner delay2" x="2" y="2" rx="2" width="10" height="10"/>
    <rect class="spinner delay3" x="2" y="2" rx="2" width="10" height="10"/>
</svg>
```