---
title: "Use of Sqlite in Maui"
author: "PrashantUnity"
weight: 106
date: 2025-06-19
lastmod: 2024-06-19
dateString: July 2025  
description: "Code snippet for maui sqlite implementation"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "NET", "codefrydev", "C sharp", "CFD","maui" , "controls","entry"]
keywords: [ "NET", "codefrydev", "C sharp", "CFD","maui" , "controls"]
---

## Step to implement

### Install/ Add Microsoft.EntityFrameworkCore.Sqlite to Project

```xml
    <PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="9.0.7" />
```

### Register App db Context before    `var app = builder.Build();` in MauiProgram.cs

```cs
var dbPath = Path.Combine(FileSystem.AppDataDirectory, "waterreminder.db3");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite($"Filename={dbPath}"));
```

### Just Before app run add this Command

```cs
// Initialize the database 
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();
}

return app;
```

### Create Add Db Context

```cs
namespace WaterReminder.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Reminder> Reminders { get; set; }
}
```

### Below is service or uses 

```cs
public class ReminderService : IReminderService
{
    private readonly AppDbContext _context;

    public ReminderService(AppDbContext context)
    {
        _context = context; 
    }

    public Task<List<Reminder>> GetRemindersAsync() => _context.Reminders.ToListAsync();
}
```