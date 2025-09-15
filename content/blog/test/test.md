---
title: "How To"
author: "PrashantUnity"
weight: 1
date: 2024-06-09T00:00:00-07:00
lastmod: 2024-06-24T23:59:59-07:00
dateString: June 2024  
description: "Guide of How To Create Blog Post, Categories And Etc"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "logo.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "NET", "codefrydev", "C sharp", "CFD", "Download File","Downloader","httpclient"]
draft: true
---
## Some Of Common Commands

### Run the Application In development Mode where draft is also visible

```sh
hugo server -D
```

### For Creating New Sites
```sh
hugo new site blog
```

## While Creating Folder Or New Category Follow This Structure
```yaml
├──_index.md 
├──categoryOne
│  ├──_index.md
│  ├──post.md
│  ├──post
│     ├──image.png
│     ├──video.mp4
│  ├──anotherpost.md
│  ├──anotherpost
│     ├──image.png
├──categoryTwo
│  ├──_index.md
│  ├──post.md
│  ├──post
│     ├──image.png
│     ├──video.mp4 
```

## Embedding Image in website

- Created post test.md
- Then Create Folder at same Directory with ssame Name i.e. test
- Place File which are need in that folder.

Taking Image Case 
- One Inside Top Of Head Or For Cover Image 

```yaml
cover:
    image: "folder.png" # image path/url
    alt: "folder Logo" # alt text
```
- Others part of page

```md
![images](./folder.png)
```
#### Example
![images](./folder.png)

For Video Implementation Use Below Snippet.
```
  <video width="640" height="360" controls>
    <source src="./test.mp4" type="video/mp4">
    Your browser does not support the video tag.
  </video>
```
<video width="640" height="360" controls>
  <source src="./test.mp4" type="video/mp4">
  Your browser does not support the video tag.
</video>

### _index.md Is Used to replesent/ View List Of Post On that Categories /Folder
template
```yaml
---
title: "Name Of Page"
author: "Codefrydev"
weight: 100
date: 2024-06-10T11:57:15+05:30
dateString: June 2024
description: "Description Of Page" 
---
```

#### General Post Head Template

```yaml
---
title: "Replace Me With Actual Title"
author: ["Replace Author Name","Another Author Name"]
weight: 100
dateString: June 2024  
description: "Guide of How TO Create Blog Post, Categories AND Etc"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "logo.png" # image path/url
    alt: "Download Logo" # alt text
    caption: "Optical Character Recognition"  #display caption under cover 

tags: [ "Code Fry Dev", "codefrydev", "CFD","NET","C Sharp", "Download File","Downloader","httpclient"]
draft: true #make this false to publicly Available
---
```

#### for related Linking of another page use below code for reference [SKiaSharp]({{< relref "blog/skiasharp/basic.md" >}})

```md
[Basic Setup]({{< relref "blog/skiasharp/basic.md" >}})
```

### Inside _index.md introduced following code

```yaml
keywords: ["Blog", "CFD", "NET" ,"Tutorials","Design","Games"]
```
