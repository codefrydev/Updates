---
title: "Dynamically Update Youtube Video Title and Description using YouTube Data API in .NET Applications"
author: "PrashantUnity"
weight: 106
date: 2025-12-23
lastmod: 2025-12-23
dateString: December 2025  
description: "Learn how to dynamically update YouTube video titles and descriptions using the YouTube Data API in .NET applications. This guide provides step-by-step instructions and code examples to help you manage your YouTube content programmatically."
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "NET", "codefrydev", "C sharp", "CFD", "YouTube API", "YouTube Data API", "Video Management", "API Integration", "Programming", "Software Development" ]
keywords: [ "NET", "codefrydev", "C sharp", "CFD", "YouTube API", "YouTube Data API", "Video Management", "API Integration", "Programming", "Software Development" ]
---

## YouTube Data API Sample in .NET Interactive Notebooks

This sample demonstrates how to use the YouTube Data API to update video metadata (title, description, tags, etc.) in bulk using .NET Interactive Notebooks. It covers OAuth2 authentication, fetching uploaded videos, generating new metadata using an AI model, and updating the videos via the API.

[Get Gemini API Key](https://aistudio.google.com/app/api-keys)
[Google Cloud Console for creating secret credentials](https://console.cloud.google.com/)


```csharp
#r "nuget: Google.Apis.YouTube.v3"
#r "nuget: Google.Apis.Auth"
```

This cell loads the NuGet package references required to use the YouTube Data API and Google authentication in a polyglot/.NET Interactive notebook.

```csharp
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
```

These `using` statements import the Google APIs namespaces used for OAuth2, the YouTube service, and data models.

```csharp
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System.Text.Json;
```

Standard .NET imports for file I/O, async/threading, HTTP requests, text handling, and JSON serialization used by the sample.

```csharp
// 1️⃣ OAuth
UserCredential credential;
using (var stream = new FileStream("client_secret.json", FileMode.Open))
{
    credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
        GoogleClientSecrets.FromStream(stream).Secrets,
        new[] { YouTubeService.Scope.Youtube },
        "user",
        CancellationToken.None,
        new FileDataStore("YouTubeAuth")
    );
}
```

This snippet performs OAuth2 authorization using the `client_secret.json` file and stores the resulting user credential locally.

```csharp
var youtube = new YouTubeService(new BaseClientService.Initializer
{
    HttpClientInitializer = credential,
    ApplicationName = "Channel Bulk Metadata Updater"
});
```

Create a `YouTubeService` client instance initialized with the authorized credentials to call the YouTube Data API.

```csharp
// 2️⃣ Get channel uploads playlist
var channelRequest = youtube.Channels.List("contentDetails");
channelRequest.Mine = true;
var channelResponse = await channelRequest.ExecuteAsync();

var uploadsPlaylistId =
    channelResponse.Items[0].ContentDetails.RelatedPlaylists.Uploads;

Console.WriteLine($"Uploads playlist: {uploadsPlaylistId}");

```

Request the authenticated user's channel content details and extract the uploads playlist ID (where all uploaded videos are listed).

```csharp
// 3️⃣ Get ALL video IDs
var videoIds = new List<string>();
string nextPageToken = null;

do
{
    var playlistRequest = youtube.PlaylistItems.List("contentDetails");
    playlistRequest.PlaylistId = uploadsPlaylistId;
    playlistRequest.MaxResults = 50;
    playlistRequest.PageToken = nextPageToken;

    var playlistResponse = await playlistRequest.ExecuteAsync();

    videoIds.AddRange(
        playlistResponse.Items.Select(i => i.ContentDetails.VideoId)
    );

    nextPageToken = playlistResponse.NextPageToken;

} while (nextPageToken != null);

Console.WriteLine($"Found {videoIds.Count} videos");
// save video Ids in file for later use
File.WriteAllLines("video_ids.txt", videoIds);
```

Iterate the uploads playlist pages to gather all video IDs and save them to `video_ids.txt` for later processing.

```csharp

class AiMetadata
{
    public string Title { get; set; }
    public string Description { get; set; }
    public List<string> Tags { get; set; }
    public string CategoryId { get; set; }
    public string Language { get; set; }
}
static void ApplyAiMetadata(Video video, AiMetadata ai)
{
    video.Snippet.Title = ai.Title;
    video.Snippet.Description = ai.Description;
    video.Snippet.Tags = ai.Tags;
    video.Snippet.CategoryId = ai.CategoryId;
    video.Snippet.DefaultLanguage = ai.Language;
}
// Generate AI Metadata using Gemeini API if dosent work Plese take a look at https://aistudio.google.com for more details how their curl works and upage below code snippet accordingly
static async Task<AiMetadata?> GenerateMetadataFromTitle(string videoTitle)
{
    var apiKey = "you api key here";

    var prompt = $$$"""
You are an assistant that generates YouTube metadata.

Given this video title:
"{{{videoTitle}}}"

Generate optimized YouTube metadata.

Rules:
- Return ONLY valid JSON
- No markdown
- No explanations
- English language only

JSON format:
{{
  "title": "",
  "description": "",
  "tags": [],
  "categoryId": "",
  "language": ""
}}
""";

    var requestBody = new
    {
        contents = new[]
        {
            new
            {
                parts = new[]
                {
                    new { text = prompt }
                }
            }
        },
        generationConfig = new
        {
            temperature = 0.6,
            maxOutputTokens = 512
        }
    };

    using var client = new HttpClient();

    var request = new HttpRequestMessage(
        HttpMethod.Post,
        "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent"
    );

    request.Headers.Add("X-goog-api-key", apiKey);
    request.Content = new StringContent(
        JsonSerializer.Serialize(requestBody),
        Encoding.UTF8,
        "application/json"
    );

    var response = await client.SendAsync(request);
    if (!response.IsSuccessStatusCode)
    {
        Console.WriteLine($"Gemini error: {response.StatusCode}");
        return null;
    }

    var json = await response.Content.ReadAsStringAsync();

    using var doc = JsonDocument.Parse(json);

    if (!doc.RootElement.TryGetProperty("candidates", out var candidates))
        return null;

    var text = candidates[0]
        .GetProperty("content")
        .GetProperty("parts")[0]
        .GetProperty("text")
        .GetString();

    if (string.IsNullOrWhiteSpace(text))
        return null;

    // Parse AI JSON safely
    return JsonSerializer.Deserialize<AiMetadata>(
        text,
        new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
    );
}
```


Defines an `AiMetadata` model, a helper to apply metadata to a `Video` object, and a function that calls a Generative API to produce metadata JSON from a video title.


```csharp
// 4️⃣ Process videos in batches

var videoIdsList = File.ReadAllLines("video_ids.txt");
foreach (var batch in videoIdsList.Chunk(50))
{
    var listRequest = youtube.Videos.List("snippet");
    listRequest.Id = string.Join(",", batch);

    var listResponse = await listRequest.ExecuteAsync();

    foreach (var video in listResponse.Items)
    {
        try
        {
            // 5️⃣ UPDATE ONLY REQUIRED FIELDS
            var aiMetadata = await GenerateMetadataFromTitle(video.Snippet.Title);

            // Optional safety checks
            if (string.IsNullOrWhiteSpace(aiMetadata.Title))
                throw new Exception("AI returned empty title");

            ApplyAiMetadata(video, aiMetadata);

            var updateRequest = youtube.Videos.Update(video, "snippet");
            await updateRequest.ExecuteAsync();


            Console.WriteLine($"✔ Updated {video.Id}");

            // 7️⃣ Throttle
            await Task.Delay(1200);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ {video.Id} failed: {ex.Message}");
        }
    }
}
Console.WriteLine("Done.");
```

Process videos in batches: fetch each video's snippet, generate AI metadata, apply updates via the YouTube API, and throttle requests to respect quotas.
