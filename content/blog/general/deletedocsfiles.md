---
title: "Aumatically Bulk Delete 'Recent Documents' Shared with You on Google Docs Homescreen Using JavaScript"
author: "PrashantUnity"
weight: 109
date: 2026-02-24
lastmod: 2025-02-24
dateString: February 2026  
description: ""
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg"
    alt: "Docs" # alt text
    #caption: "Microsoft Dev Tunnels"  display caption under cover 

tags: [ "google docs", "automation", "javascript", "productivity" ]
keywords: [ "Google Docs", "automation", "JavaScript", "productivity", "bulk delete", "recent documents", "shared files", "codefrydev", "CFD"]
---

# How to Bulk Delete "Recent Documents" shared with you on the Google Docs Homescreen Using JavaScript

If you've ever tried to clean up your Google Docs homescreen by removing old or shared documents, you know how tedious it can be. Google doesn't provide a built-in way to bulk delete files from the "Recent Documents" section, and the interface is designed to make it difficult to accidentally delete files. This means you have to click through each file's 3-dot menu and select "Remove" one by one.

## The Solution: A Robust Automation Script

To get around these hurdles, the script needs to simulate a heavy, deliberate human mouse click, scroll elements into view so they are actually clickable, and strictly filter out any hidden HTML elements.

Here is the final, working script.

### How to use it

1. Go to your [Google Docs homescreen](https://docs.google.com) or Google Sheets.
2. Open your browser's Developer Tools (Press `F12` or `Ctrl + Shift + J` on Windows / `Cmd + Option + J` on Mac).
3. Navigate to the **Console** tab.
4. Paste the code below and hit **Enter**.

```javascript
async function removeAllDocs() {
  const delay = ms => new Promise(r => setTimeout(r, ms));

  // Simulates a heavy, deliberate human mouse click
  const triggerClick = (element) => {
    // Bring element into view first
    element.scrollIntoView({ behavior: 'smooth', block: 'center' });
    
    ['pointerdown', 'mousedown', 'pointerup', 'mouseup', 'click'].forEach(eventType => {
      element.dispatchEvent(new MouseEvent(eventType, { 
        view: window, 
        bubbles: true, 
        cancelable: true, 
        buttons: 1 
      }));
    });
  };

  let total = 0;

  while (true) {
    // 1. Find VISIBLE 3-dot menus
    const menuButtons = Array.from(document.querySelectorAll('[role="button"]'))
      .filter(btn => {
        const label = (btn.getAttribute('aria-label') || btn.getAttribute('data-tooltip') || "").toLowerCase();
        return label.includes("rename, remove") || label.includes("more options") || label.includes("more actions");
      })
      .filter(btn => btn.offsetParent !== null && btn.style.display !== 'none'); 

    if (menuButtons.length === 0) {
      console.log("No visible menus found. Scrolling down...");
      window.scrollBy(0, 1000);
      await delay(2500); 
      
      const retryButtons = Array.from(document.querySelectorAll('[role="button"]'))
        .filter(btn => {
          const label = (btn.getAttribute('aria-label') || btn.getAttribute('data-tooltip') || "").toLowerCase();
          return label.includes("rename, remove") || label.includes("more options") || label.includes("more actions");
        })
        .filter(btn => btn.offsetParent !== null && btn.style.display !== 'none');
        
      if (retryButtons.length === 0) {
        console.log("No more files left to process.");
        break;
      }
      continue; 
    }

    const menuBtn = menuButtons[0]; 
    console.log("Opening menu...");
    triggerClick(menuBtn); 
    
    // Wait for the menu to fully pop up
    await delay(1200); 

    // 2. Find the "Remove" button that is ACTUALLY VISIBLE on the screen right now
    const removeBtn = Array.from(document.querySelectorAll('[role="menuitem"], .goog-menuitem'))
      .filter(el => el.offsetParent !== null) // CRITICAL: Only grab the visible one
      .find(el => {
        const text = (el.innerText || "").toLowerCase();
        return text.includes("remove") || text.includes("move to trash") || text.includes("delete");
      });

    if (!removeBtn) {
      console.log("Visible 'Remove' option not found. Closing menu and skipping...");
      document.dispatchEvent(new KeyboardEvent('keydown', { key: 'Escape', bubbles: true }));
      menuBtn.style.display = 'none'; 
      await delay(1000);
      continue;
    }

    // 3. Click remove
    console.log("Clicking remove...");
    triggerClick(removeBtn); 
    total++;
    console.log(`Total removed so far: ${total}`);

    // Hide the button we just clicked so the loop doesn't catch it again
    menuBtn.style.display = 'none';
    
    // Give the server time to process the deletion
    await delay(2000); 
  }

  console.log(`DONE. Successfully removed ${total} files.`);
}

removeAllDocs();
```

### Important Notes

- This script is designed to work on the Google Docs homescreen and may not work on other Google Drive interfaces.
- It simulates human-like interactions, so it may take some time to process all files, especially if you have many documents.
- Be cautious when using this script, as it will permanently remove files from your "Recent Documents" list. Make sure you have backups of any important files before running it.
- The script may need adjustments if Google updates their interface, as it relies on specific HTML structures and attributes to identify buttons and menu items.
- Always test the script on a small number of files first to ensure it works as expected before running it on a larger scale.

- if you encounter any issues or have suggestions for improvement, feel free to comment below or you could use ai by proving this script. and problem you are facing!