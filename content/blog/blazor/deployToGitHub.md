---
title: "Deploy Blazor Webassembly to Github Pages"
author: ["PrashantUnity"]
weight: 100
date: 2024-07-12T00:00:00-07:00
lastmod: 2024-07-12T23:59:59-07:00
dateString: July 2024
description: "Deploy Blazor Webassembly To github pages" 
tags: ["blazor"]
keywords: ["CFD","CodefryDev","Code Fry Dev","Csharp","blazor","webassembly" ]

cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  #display caption under cover 
---


## Steps

- Create Blazor Webassembly Project using cli or using Visual Studio [CLI Source Link](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=cli)
- Create **.github** Folder
- Inside **.github** Folder create another Folder **workflows**
- Inside **workflows** create file **dotnet.yaml**

- Code below for above process

```yaml
dotnet new blazorwasm -o BlazorGitHubPagesDemo
cd .\BlazorGitHubPagesDemo\
code .
mkdir .github
cd .\.github\
mkdir workflows
cd .\workflows\
echo "" > "dotnet.yaml"
```

- Open The created yaml File And Paste The Below Code


```yaml
name: DeployBlazorWebAssembly
on:
  push:
    branches: [ "main" ] 

jobs:
  build:

    runs-on: ubuntu-latest

    steps:
    - uses: actions/checkout@v3
    - name: Setup .NET
      uses: actions/setup-dotnet@v3
      with:
        dotnet-version: 6.0.x
        
    - name: Publish .NET Core Project
      run: dotnet publish BlazorGitHubPagesDemo.csproj -c Release -o release --nologo
    
 
    - name: Change base-tag in index.html from / to BlazorGitHubPagesDemo
      run: sed -i 's/<base href="\/" \/>/<base href="\/BlazorGitHubPagesDemo\/" \/>/g' release/wwwroot/index.html
    
 
    - name: copy index.html to 404.html
      run: cp release/wwwroot/index.html release/wwwroot/404.html

    # (Allow files and folders starting with an underscore)
    - name: Add .nojekyll file
      run: touch release/wwwroot/.nojekyll
      
    - name: Commit wwwroot to GitHub Pages
      uses: JamesIves/github-pages-deploy-action@3.7.1
      with:
        GITHUB_TOKEN: ${{ secrets.GITHUB_TOKEN }}
        BRANCH: gh-pages
        FOLDER: release/wwwroot
```

### Change in above Code Based On Project


- On Line number 16 Change Dotnet version appropriate to you project Version

- On Line Number 19 Change **BlazorGitHubPagesDemo.csproj** to your project name **.csproj**

- on Line Number 23 Change **BlazorGitHubPagesDemo** to your github repository name

- in rest place you can change based on requirement

### Now Push to Github

### After Pushing to Github

- Go to Project Repository Setting

- Then Action Tab

![Action Tab](./action.png)

- Select **Read and write permissions**

- Then Click On Save.

- Click On Action Tab

![Action Tab](./action.png)

- In action tab if any job is failed the Click on that job

- After that Go To Page Tab

![Action Tab](./page.png)

- Make Sure Source is **Deploy from From a branch** is selected
- In Branch section select **gh-pages**


Wait For Few Moment github page will be live.

### Few thing to Consider

- Make sure branch name is matches i.e if Your Current repository branch is "master" then line no 4 should have same name

```yaml
name: DeployBlazorWebAssembly
on:
  push:
    branches: [ "master" ]

```

- If you application require **WasmBuildNative** then include below code after line **dotnet-version: 6.0.x** in original Code
    
    - Case are when you are using Some Library like SkiaSharp , SqliteWasmHelper Etc.
    - Take Like Example Of [**Challenge Repository**](https://github.com/codefrydev/Challenge/blob/master/.github/workflows/dotnet.yml)

```yaml
    #code ...
    steps:
    - uses: actions/checkout@v3
    - name: Setup .NET
      uses: actions/setup-dotnet@v3
      with:
        dotnet-version: 6.0.x
        
    # Install dotnet wasm buildtools workload
    - name: Install .NET WASM Build Tools
      run: dotnet workload install wasm-tools

    - name: Publish .NET Core Project
      run: dotnet publish BlazorGitHubPagesDemo.csproj -c Release -o release --nologo
    # rest Code..
    
```

Live Fast Video Demo of Creating project using code in this webpage

{{< youtube M0oRKErEL6g >}}
