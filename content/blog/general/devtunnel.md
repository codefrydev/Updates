---
title: "How to use devtunnel using cli"
author: "PrashantUnity"
weight: 100
date: 2026-01-22
lastmod: 2025-12-23
dateString: January 2026  
description: "Complete guide to installing and setting up Microsoft devtunnel CLI on Windows, macOS, and Linux. Learn how to create secure development tunnels for local services."
#canonicalURL: "https://canonical.url/to/page"
cover:
    # image: "devtunnel.png" # image path/url
    alt: "Dev Tunnel Logo" # alt text
    #caption: "Microsoft Dev Tunnels"  display caption under cover 

tags: [ "devtunnel", "tunneling", "development", "CLI", "Microsoft", "Azure"]
keywords: [ "devtunnel", "Microsoft", "tunneling", "CLI", "development", "Azure", "codefrydev", "CFD", "local development"]
---

## Overview

Microsoft devtunnel is a CLI tool that allows you to create secure tunnels to expose your local development services to the internet. This guide provides comprehensive setup instructions for installing and configuring devtunnel on Windows, macOS, and Linux.

## Prerequisites

Before installing devtunnel, ensure you meet the following requirements:

### System Requirements

- **Windows:**
  - Windows 10 (version 1809 or later) or Windows 11
  - `winget` package manager (included in Windows 10/11) or PowerShell 5.1+
  - Administrator privileges (for some installation methods)

- **macOS:**
  - macOS 10.15 (Catalina) or later
  - Homebrew (optional, for easier installation)
  - Terminal access

- **Linux:**
  - Most modern Linux distributions (Ubuntu, Debian, Fedora, etc.)
  - Bash shell
  - `curl` or `wget` installed
  - Write permissions to `/usr/local/bin` or user's local bin directory

### Account Requirements

- **Microsoft Account or Azure AD account:** Required for authenticated tunnels (recommended)
- **Internet connection:** Required for tunnel creation and management

## Quick Windows

```ps
winget install --id Microsoft.devtunnel
devtunnel --version
devtunnel login
devtunnel host -p 6001

```

## Installation

### Windows

#### Method 1: Using winget (Recommended)

The easiest way to install devtunnel on Windows is using the Windows Package Manager:

```cmd
winget install --id Microsoft.devtunnel
```

After installation, verify it's working:

```cmd
devtunnel --version
```

#### Method 2: Using PowerShell Script

If winget is not available, you can use the PowerShell installation script:

```powershell
# Download and run the installation script
Invoke-WebRequest -Uri "https://aka.ms/devtunnels/download" -OutFile "$env:TEMP\devtunnel-install.ps1"
& "$env:TEMP\devtunnel-install.ps1"
```

#### Method 3: Direct Download

1. Visit the [Microsoft devtunnel releases page](https://github.com/microsoft/dev-tunnels/releases)
2. Download the Windows executable (`.exe`) for your architecture (x64, ARM64)
3. Extract the executable to a directory in your PATH (e.g., `C:\Program Files\devtunnel\`)
4. Add the directory to your system PATH environment variable if needed

#### Verification (Windows)

After installation, verify the installation:

```cmd
devtunnel --version
```

Expected output:
```
devtunnel version 2.x.x
```

If the command is not recognized:
- Restart your terminal/command prompt
- Verify the installation path is in your system PATH
- Try using the full path to the executable

### macOS

#### Method 1: Using Homebrew (Recommended)

If you have Homebrew installed:

```bash
brew install --cask devtunnel
```

After installation, verify:

```bash
devtunnel --version
```

#### Method 2: Using Installation Script

Run the official installation script:

```bash
curl -fsSL https://aka.ms/devtunnels/download | bash
```

This script will:
- Download the appropriate binary for your Mac architecture
- Install it to `/usr/local/bin/devtunnel`
- Make it executable

#### Method 3: Manual Installation

1. Visit the [Microsoft devtunnel releases page](https://github.com/microsoft/dev-tunnels/releases)
2. Download the macOS binary for your architecture (Intel or Apple Silicon)
3. Extract the binary
4. Move it to a directory in your PATH:

```bash
sudo mv devtunnel /usr/local/bin/
sudo chmod +x /usr/local/bin/devtunnel
```

#### Verification (macOS)

Verify the installation:

```bash
devtunnel --version
```

If you get a "command not found" error:
- Check that `/usr/local/bin` is in your PATH: `echo $PATH`
- Add it if needed: `export PATH=$PATH:/usr/local/bin`
- Restart your terminal

### Linux

#### Method 1: Using Installation Script (Recommended)

Run the official installation script:

```bash
curl -fsSL https://aka.ms/devtunnels/download | bash
```

This will install devtunnel to `/usr/local/bin/devtunnel`.

#### Method 2: Manual Installation

1. Visit the [Microsoft devtunnel releases page](https://github.com/microsoft/dev-tunnels/releases)
2. Download the Linux binary for your architecture (x64, ARM64, etc.)
3. Extract and install:

```bash
# Download (replace with latest version and architecture)
wget https://github.com/microsoft/dev-tunnels/releases/latest/download/devtunnel-linux-x64.tar.gz

# Extract
tar -xzf devtunnel-linux-x64.tar.gz

# Move to system path
sudo mv devtunnel /usr/local/bin/
sudo chmod +x /usr/local/bin/devtunnel
```

#### Method 3: Using Package Managers

Some Linux distributions may have devtunnel in their repositories. Check your distribution's package manager:

**For Debian/Ubuntu:**
```bash
# Check if available
apt search devtunnel
```

**For Fedora/RHEL:**
```bash
# Check if available
dnf search devtunnel
```

#### Verification (Linux)

Verify the installation:

```bash
devtunnel --version
```

If the command is not found:
- Check PATH: `echo $PATH`
- Verify the binary exists: `ls -la /usr/local/bin/devtunnel`
- Add to PATH if needed: `export PATH=$PATH:/usr/local/bin`

## Verification

After installation on any platform, perform these verification steps:

### 1. Check Version

```bash
devtunnel --version
```

This confirms the installation and shows the installed version.

### 2. Check Help

```bash
devtunnel --help
```

This displays available commands and confirms the CLI is functional.

### 3. Verify Authentication Status

```bash
devtunnel user show
```

This shows your current authentication status (will prompt login if not authenticated).

### Common Verification Issues

- **Command not found:** 
  - Restart your terminal
  - Verify PATH includes the installation directory
  - Use full path to executable

- **Permission denied (Linux/macOS):**
  - Ensure the binary is executable: `chmod +x /usr/local/bin/devtunnel`
  - Use `sudo` if installing to system directories

- **Version check fails:**
  - Reinstall using the recommended method for your platform
  - Check for network connectivity issues

## Authentication

Authentication is required for most devtunnel operations, especially for private tunnels. Here's how to set it up:

### Initial Login

Run the login command:

```bash
devtunnel login
```

This will:
1. Open your default web browser
2. Prompt you to sign in with your Microsoft account or Azure AD account
3. Complete the authentication flow
4. Store credentials locally for future use

### Login Options

**Interactive login (default):**
```bash
devtunnel login
```

**Login with specific account:**
```bash
devtunnel login --allow-no-browser
```

This allows manual entry of authentication code if browser doesn't open.

### Verify Authentication

Check your authentication status:

```bash
devtunnel user show
```

This displays:
- Your authenticated user account
- Account type (Microsoft Account or Azure AD)
- Authentication status

### Logout

To sign out:

```bash
devtunnel logout
```

This removes stored credentials. You'll need to log in again for authenticated operations.

### Authentication Notes

- Credentials are stored securely on your local machine
- Authentication persists across terminal sessions
- You may need to re-authenticate if credentials expire
- For anonymous/public tunnels, authentication is optional but not recommended for security

## Basic Usage

### Creating a Simple Tunnel

Expose a local service running on port `6001`:

```bash
devtunnel host -p 6001
```

This creates a private tunnel that requires authentication to access.

### Creating a Public Tunnel

To create a tunnel accessible without authentication (use with caution):

```bash
devtunnel host -p 6001 -a
```

**Flags explained:**
- `-p 6001`: Forwards local port 6001
- `-a`: Makes tunnel accessible without authentication (anonymous/public)

### Tunnel Output

When a tunnel starts successfully, you'll see output like:

```
Tunnel created: https://abc123-def456-ghi789.trafficmanager.net
```

You can now access your local service via this public URL.

### Stopping a Tunnel

Press `Ctrl+C` in the terminal where the tunnel is running.

### Common Usage Examples

**Expose a web application:**
```bash
# Your app runs on localhost:3000
devtunnel host -p 3000
```

**Expose multiple ports:**
```bash
devtunnel host -p 3000 -p 5000
```

**Create a named tunnel:**
```bash
devtunnel host -p 6001 --tunnel-id my-tunnel-name
```

**Set tunnel protocol:**
```bash
devtunnel host -p 6001 --protocol https
```

## Advanced Usage

### Managing Tunnels

**List all tunnels:**
```bash
devtunnel list
```

**Delete a tunnel:**
```bash
devtunnel delete <tunnel-id>
```

**Show tunnel details:**
```bash
devtunnel show <tunnel-id>
```

### Tunnel Configuration

**Set tunnel access:**
```bash
# Private tunnel (requires authentication)
devtunnel host -p 6001

# Public tunnel (no authentication required)
devtunnel host -p 6001 -a
```

**Configure port forwarding:**
```bash
# Forward to different host
devtunnel host -p 6001 --host localhost
```

### Environment Variables

You can configure devtunnel using environment variables:

```bash
# Set default region
export DEVTUNNEL_REGION=eastus

# Set log level
export DEVTUNNEL_LOG_LEVEL=debug
```

## Troubleshooting

### Installation Issues

#### Windows

**winget not found:**
- Update Windows to the latest version
- Install winget manually from [Microsoft Store](https://aka.ms/getwinget)
- Use alternative installation methods (PowerShell script or direct download)

**Permission denied:**
- Run terminal as Administrator
- Check antivirus software isn't blocking installation

#### macOS

**Homebrew not found:**
- Install Homebrew: `/bin/bash -c "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/HEAD/install.sh)"`
- Use the installation script method instead

**Binary not executable:**
```bash
chmod +x /usr/local/bin/devtunnel
```

#### Linux

**Permission denied:**
```bash
sudo chmod +x /usr/local/bin/devtunnel
```

**Binary architecture mismatch:**
- Download the correct binary for your CPU architecture
- Check architecture: `uname -m`
- Use x64 for 64-bit Intel/AMD, ARM64 for ARM processors

### Authentication Issues

**Login fails:**
- Ensure you have an active internet connection
- Try logging out and logging back in: `devtunnel logout` then `devtunnel login`
- Clear browser cache and cookies
- Check if your organization requires specific Azure AD permissions

**Browser doesn't open:**
- Use `--allow-no-browser` flag: `devtunnel login --allow-no-browser`
- Manually copy the authentication URL from terminal output

**Authentication expired:**
- Re-authenticate: `devtunnel login`
- Check system time is correct (authentication relies on accurate time)

### Tunnel Creation Issues

**No public endpoint printed:**
- Verify your local service is running on the specified port
- Check firewall settings aren't blocking connections
- Ensure you have internet connectivity
- Try a different port number

**Port already in use:**
- Find the process using the port:
  - **Windows:** `netstat -ano | findstr :6001`
  - **macOS/Linux:** `lsof -i :6001` or `netstat -tulpn | grep 6001`
- Stop the conflicting process or use a different port

**Connection refused:**
- Verify your local service is listening on `localhost` or `127.0.0.1`
- Check if your service binds to `0.0.0.0` (all interfaces)
- Ensure the service is actually running

**Tunnel disconnects frequently:**
- Check network stability
- Verify firewall/antivirus isn't interfering
- Check for proxy settings that might affect connections

### Platform-Specific Issues

#### Windows

**Firewall blocking:**
- Add devtunnel to Windows Firewall exceptions
- Allow inbound connections for the tunnel port

**Antivirus interference:**
- Add devtunnel to antivirus exclusions
- Temporarily disable to test if it's the cause

#### macOS

**Gatekeeper blocking:**
```bash
# Remove quarantine attribute
xattr -d com.apple.quarantine /usr/local/bin/devtunnel
```

**System Integrity Protection (SIP):**
- If installing to protected directories, you may need to disable SIP (not recommended)
- Install to user directory instead: `~/bin/devtunnel`

#### Linux

**Missing dependencies:**
- Install required libraries: `sudo apt-get install libssl-dev` (Debian/Ubuntu)
- Check distribution-specific requirements

**SELinux blocking:**
- Configure SELinux policies if needed
- Or set SELinux to permissive mode for testing (not recommended for production)

## Security Best Practices

### General Security

1. **Use Authenticated Tunnels:**
   - Avoid using `-a` (anonymous) flag unless absolutely necessary
   - Authenticated tunnels provide better access control

2. **Limit Tunnel Lifetime:**
   - Don't leave tunnels running indefinitely
   - Stop tunnels when not in use: `Ctrl+C` or `devtunnel delete <tunnel-id>`

3. **Monitor Active Tunnels:**
   - Regularly check active tunnels: `devtunnel list`
   - Delete unused or old tunnels

4. **Use HTTPS:**
   - Prefer HTTPS protocol for tunnels when available
   - Ensures encrypted communication

### Development vs Production

- **Never use devtunnel for production services**
- Devtunnel is designed for development and testing only
- Use proper hosting solutions (Azure App Service, AWS, etc.) for production

### Access Control

- **Private tunnels:** Require Microsoft/Azure AD authentication
- **Public tunnels:** Accessible to anyone with the URL (use with extreme caution)
- **Port restrictions:** Only expose necessary ports

### Data Protection

- **Don't expose sensitive services:**
  - Databases with real data
  - Services with authentication tokens
  - Production APIs or services

- **Use test/development data only:**
  - Never use production credentials
  - Use isolated test environments

### Network Security

- **Firewall configuration:**
  - Ensure local firewall rules are appropriate
  - Don't disable security features

- **VPN considerations:**
  - Be aware of VPN routing that might affect tunnel connectivity
  - Test tunnel behavior with VPN enabled/disabled

### Credential Management

- **Secure authentication:**
  - Use strong Microsoft/Azure AD passwords
  - Enable multi-factor authentication (MFA) on your account
  - Don't share authentication credentials

- **Logout when done:**
  - Use `devtunnel logout` on shared machines
  - Clear credentials when switching accounts

### Best Practices Summary

- ✅ Always use authenticated tunnels for private development
- ✅ Stop tunnels when not actively developing
- ✅ Regularly review and delete unused tunnels
- ✅ Never expose production services or sensitive data
- ✅ Use HTTPS when available
- ✅ Keep devtunnel CLI updated to latest version
- ✅ Monitor tunnel access and usage
- ❌ Don't use public tunnels (`-a`) for sensitive services
- ❌ Don't leave tunnels running unattended
- ❌ Don't share tunnel URLs publicly without authentication

## Additional Resources

- [Microsoft Dev Tunnels Documentation](https://learn.microsoft.com/en-us/azure/developer/dev-tunnels/)
- [Dev Tunnels GitHub Repository](https://github.com/microsoft/dev-tunnels)
- [Dev Tunnels FAQ](https://learn.microsoft.com/en-us/azure/developer/dev-tunnels/faq)