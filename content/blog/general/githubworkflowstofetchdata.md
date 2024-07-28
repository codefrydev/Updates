---
title: "Github Workfows to Run Program"
author: "PrashantUnity"
weight: 103
date: 2024-07-28T00:00:00-07:00
lastmod: 2024-07-28T23:59:59-07:00
dateString: July 2024  
description: "How Run Server Side Code on GitHub CICD to do Some Task for Free and store in same Repository"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Google Dive Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "C sharp", "CICD","GitHub"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD", "CICD","GitHub"]
---

## Create new Console Project

I am going to create dotnet project to demonstrate this but applicable for all ather programming also

- Open any folder, In there Open Terminal
- In Terminal Create new dotnet console Project using below command

```yaml
dotnet new console -n GitCiCd
cd .\GitCiCd\
code .
mkdir .github
cd .\.github\
mkdir workflows
cd .\workflows\
echo "" > "dotnet.yaml"
```

- In dotnet.yaml file Paste Below Code

```yaml
name: workflows

on:
  push:
    branches: [ "master" ]
    
jobs:
  scrape_videos:
    runs-on: ubuntu-latest

    steps:
    - name: Checkout code
      uses: actions/checkout@v2

    - name: Set up .NET
      uses: actions/setup-dotnet@v2
      with:
        dotnet-version: '8.0.x'  # Use the latest .NET version

    - name: Restore dependencies
      run: dotnet restore

    - name: Build the project
      run: dotnet build --configuration Release

    - name: Run the scraping script
      run: dotnet run --project GetYoutubeVideo.csproj

    - name: Commit and Push Changes
      run: |
        git config --local user.email "action@github.com"
        git config --local user.name "GitHub Action"
        git add Text.txt
        git commit -m "Update Text.txt list"
        git push
```

- Inside Program.cs file paste below code for.

```csharp
var ls = Enumerable.Range(1,8).Select(i => i.ToString() + DateTime.Now).ToList();

SaveToFile(ls, "Text.txt");
static void SaveToFile(List<string> videos, string filePath)
{
    using StreamWriter file = new(filePath);
    foreach (var video in videos)
    {
        file.WriteLine(video);
    }
}
```

- The code Responsible for operation is below code

```yaml
- name: Commit and Push Changes
    run: |
    git config --local user.email "action@github.com"
    git config --local user.name "GitHub Action"
    git add Text.txt
    git commit -m "Update Text.txt list"
    git push
```

- Push to github
- Now Go to Repository Setting Tab

![setting](./1.png)

- Then Expand Action and click on General

![action](./2.png)

- Now then Scroll To Bottom And Select Read and Write Permission and Tick Allow Github action to create and approve pull request

![general](./3.png)

- then Ater go to action tab

![workflows](./4.png)

- Open Any WorkFlows File and Click On Re Run XXX

![rerun](./5.png)
