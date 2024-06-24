---
title: "Index Now Using Google Api"
author: "PrashantUnity"
weight: 100
dateString: June 2024  
description: "Google Indexing via Google Indexing Api.In this post I Will Guide you How to Do this using program in C# "
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Cover Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "C sharp","IndexNow","Google","SEO"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD", "Index","IndexNow","indexing","Google Index","SEO"]
---


## Google Console

### Go To [Google Console](https://console.cloud.google.com/welcome)

- If its you first Time it Will be Similar to This (As of June 2024). 
    ![Google Console](./1.11.png)

- If Some Project is Slected then may be this. 
    ![Search Bar New Project](1.png)

### On Search Bar Search new Project 

- Select Create a new Project (IAM and admin)
    ![Search Bar New Project](1.1.png)

### On New screen Fill Some Detail

- you can give any name and Click Create
    ![Search Bar New Project](3.png)
- In an Moment On To Left Of Screen will show ssome thing like below Image
![Search Bar New Project](4.png)
- Click On Select Project

### Again Type Service Account On Search Section

- Choose Service Account (IAM and admin)
    ![Search Bar New Project](5.png)
- Then on Following Screen Click Create Service Account
    ![Search Bar New Project](6.png)
- Fill The Details With Anything you like and Click Create and Continue
    ![Search Bar New Project](7.png)
- The in following Section From Drop Down Choose Currently used owner and click continue
    ![Search Bar New Project](8.png)
    ![Search Bar New Project](9.png)
- Then After Click Done
    ![Search Bar New Project](10.png)

### Generate Crediential

- On Following SScreen it will show some thing Like this
![Search Bar New Project](12.png)
- Copy mailing adress which will be like xxx@xxx.iam.gserviceaccount.com and keep some place it will be need later
- In action Click on 3 Vertical dot and thenClick Manage Key
    ![Search Bar New Project](13.png)
- On Following Screen Click on add Key then create new key
    ![Search Bar New Project](14.png)
- A popup will appear select  JSON and Click Create

### Download of JSON File
![Search Bar New Project](15.png)

### Search Library on Search Bar

- Select Library ( APIs and services)
    ![Search Bar New Project](16.png)
- Then On Next Screen Type **Indexing** and press enter or click search 
    ![Search Bar New Project](17.png)
- On Following Screen Select **Web Search Indexing API**
    ![Search Bar New Project](18.png)
- Then On Following Screen Click on Enable
    ![Search Bar New Project](19.png)


## Google search-console

### Go to [Search Console](https://search.google.com/search-console?)

- On Bottom Left Click **Settings**
    ![Search Bar New Project](20.png)
- Then Click on User and Permission
    ![Search Bar New Project](22.png)
- Click on Add User
![Search Bar New Project](23.png)
- Paste Email Address Which we copied Earlier in Google Cloud
![Search Bar New Project](24.png)
- For Referece Email Will Look Like this
    ![Search Bar New Project](21.png)

- In Permission Drop Down Select It As Owner if you Dont you get Error Some thing Like this
    ```yaml
    Error(403 - PERMISSION_DENIED): Permission denied. Failed to verify the URL ownership.
    ```
 
## Code Section

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
- Open apidetails.json and Replace it Content With content of json file which was downloaded during [Creating of Private Key](#download-of-json-file) will look like this

    ```json
    {
    "type": "service_account",
    "project_id": "xxxxx",
    "private_key_id": "xxxxxx45dc588c3c433974e0eda",
    "private_key": "-----BEGIN PRIVATE KEY-----\n\n-----END PRIVATE KEY-----\n",
    "client_email": "xxx@xxx.iam.gserviceaccount.com",
    "client_id": "106002683364xxxxx",
    "auth_uri": "https://accounts.google.com/o/oauth2/auth",
    "token_uri": "https://oauth2.googleapis.com/token",
    "auth_provider_x509_cert_url": "https://www.googleapis.com/oauth2/v1/certs",
    "client_x509_cert_url": "https://www.googleapis.com/robot/v1/metadata/x509/xxxx.iam.gserviceaccount.com",
    "universe_domain": "googleapis.com"
    }
    ```

- In data.txt File Fill all the URL in Follwing Fasion
    ![Search Bar New Project](27.png)
- Google Daily Limit Quata is 200.

### Code in indexing.ipynb

- Make Sure You Selected .Net Interactive
- You don't have to change Anything
- Fill these data for Importing Library Fron Nuget Package

    ```csharp {linenos=true}
    #r "nuget: Google.Apis.Auth"
    #r "nuget: Google.Apis.Indexing.v3"
    #r "nuget: Newtonsoft.Json"
    #r "nuget: CsvHelper"
    ```

- Click on Create next Cell
- Importing relevant namespace which is used

    ```csharp {linenos=true}
    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Indexing.v3;
    using Google.Apis.Services;
    using Newtonsoft.Json;
    using CsvHelper;
    using CsvHelper.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    ```

- Finall Code For Calling Google Api in next cell

    ```csharp {linenos=true}
    string jsonKeyFile = "apidetails.json";
    string[] scopes = { "https://www.googleapis.com/auth/indexing" };

    GoogleCredential credential;
    using (var stream = new FileStream(jsonKeyFile, FileMode.Open, FileAccess.Read))
    {
        credential = GoogleCredential.FromStream(stream).CreateScoped(scopes);
    }

    HttpClient httpClient = new HttpClient(); 
    var oauth = await credential.UnderlyingCredential.GetAccessTokenForRequestAsync();
    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", oauth);
    var urls = File.ReadAllLines("data.txt");

    foreach (var url in urls.Take(1))
    {
        var result = await IndexUrl(url, httpClient);
        if (result.ContainsKey("error"))
        {
            Console.WriteLine($"Error({result["error"]["code"]} - {result["error"]["status"]}): {result["error"]["message"]}");
        }
        else
        {
            var metadata = result["urlNotificationMetadata"];
            var latestUpdate = metadata["latestUpdate"];
            Console.WriteLine($"urlNotificationMetadata.url: {metadata["url"]}");
            Console.WriteLine($"urlNotificationMetadata.latestUpdate.url: {latestUpdate["url"]}");
            Console.WriteLine($"urlNotificationMetadata.latestUpdate.type: {latestUpdate["type"]}");
            Console.WriteLine($"urlNotificationMetadata.latestUpdate.notifyTime: {latestUpdate["notifyTime"]}");
        }
    } 
    
    static async System.Threading.Tasks.Task<Dictionary<string, dynamic>> IndexUrl(string url, HttpClient httpClient)
    {
        string endpoint = "https://indexing.googleapis.com/v3/urlNotifications:publish";
        var content = new
        {
            url = url.Trim(),
            type = "URL_UPDATED"
        };

        var jsonContent = JsonConvert.SerializeObject(content);
        var httpContent = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync(endpoint, httpContent);
        var responseString = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(responseString);
    }
    ```


### Click On Run All on to of VS Code. Wait for process to Finish

In Few Days Your Url Will be Indexed. For Quota limitation you can use Chuck URl by 200 for daily.
[Occial Doc For More or Short tutorial](https://developers.google.com/search/apis/indexing-api/v3/prereqs)
