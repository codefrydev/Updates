---
title: "Bing Index Now Using Api Key text File"
author: "PrashantUnity"
weight: 100
dateString: June 2024  
description: "Bing IndexNow. I Will Guide you How to Do this using program in C# "
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Cover Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "C sharp", "Bing","IndexNow"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD", "Index","IndexNow","indexing","Bing Index","SEO"]
---


## Step

### Generate API Key

- Visit [**bing Index Now**](https://www.bing.com/indexnow/getstarted) for Generating

### Host your API key

- Create a file in Directory of you website
- will look like this

    ```yaml
    d06c191380a74c08a8ef46d9a32e3eec.txt
    ```

- Update website after adding to root of directory


## Send Request via C\#

### Requirement

- VS Code
- PolyGlot Notebook Extension
- .Net Sdk Installed
- if Not Please Follow Installtion step from here will Create Demo for that process.

#### Open VS Code

- Create New Folder
- Inside Folder Create three File
    - **apidetails.json**
    - **data.txt**
    - **indexing.ipynb**
    ![Search Bar New Project](26.png)
- In data.txt File Fill all the URL in Follwing Fasion
    ![Search Bar New Project](27.png)

#### Code in indexing.ipynb

- Make Sure You Selected .Net Interactive 
- Fill these data for Importing Library Fron Nuget Package
    ```csharp {linenos=true}
    #r "nuget: Newtonsoft.Json, 13.0.3"
    ```

- Click on Create next Cell
- Importing relevant namespace which is used

```csharp {linenos=true}
using System;
using System.Net.Http;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization; 
using Newtonsoft.Json;
```

- Creating class for passing credential

```csharp {linenos=true}
public class Data
{
    public string host {get;set;}
    public string key {get;set;}
    public string keyLocation {get;set;}
    public List<string> urlList {get;set;}
}
```

- Replace data.host value with your absolute website url
- Replace data.key value with your generated key
- data.keyLocation value with you generated value

```csharp {linenos=true}
var ls = string.Join(",",File.ReadAllLines("data.txt"));
var httpClient = new HttpClient();
var data = new Data();
data.host =  "www.domain.com";
data.key = "xxxx";
data.keyLocation ="https://www.domain.com/xxxx.txt";
data.urlList = File.ReadAllLines("data.txt").ToList();


var jsondata = JsonConvert.SerializeObject(data);

var senddata = new StringContent(jsondata,Encoding.UTF8,"application/json");

var response = await httpClient.PostAsync("https://api.indexnow.org/indexnow", senddata);


if (response.IsSuccessStatusCode)
{
    Console.WriteLine("Request successful");
    var responseContent = await response.Content.ReadAsStringAsync();
    Console.WriteLine(responseContent);
}
else
{
    Console.WriteLine($"Request failed with status code: {response.StatusCode}");
}
```

### Click On Run All on to of VS Code. Wait for process to Finish