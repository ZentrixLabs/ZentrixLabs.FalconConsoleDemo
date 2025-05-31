
# ZentrixLabs Falcon SDK Console Demo

[![Release](https://img.shields.io/github/v/release/ZentrixLabs/ZentrixLabs.FalconConsoleDemo?label=Release)](https://github.com/ZentrixLabs/ZentrixLabs.FalconConsoleDemo/releases/latest)
[![.NET](https://img.shields.io/badge/.NET-9.0-blue?logo=dotnet)](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)

Welcome to the **ZentrixLabs Falcon SDK Console Demo**! This console app is designed to showcase how to use the **ZentrixLabs.FalconSdk** to interact with the CrowdStrike Falcon API. It’s a hands-on, interactive playground that lets you authenticate, fetch device data, and query vulnerabilities—all from the console.

---

## ✨ Features

✅ Interactive menus for:
- **Authentication** (OAuth2)  
- **Device Service** (get device IDs, details)  
- **Spotlight Service** (get vulnerability IDs and details)

✅ Friendly explanations and code samples for each service

✅ Emoji support (with graceful fallback in older terminals)

✅ Consistent, structured output with clear instructions

---

## 🚀 Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- A CrowdStrike API client ID and secret with appropriate permissions

> **Note:** For the best experience (including emoji support), use **Windows Terminal** or a modern console that supports UTF-8. If you’re on PowerShell 5, cmd.exe, or a non-Unicode-friendly console, emojis will gracefully fallback to plain text.

---

## 🛠️ Getting Started

1. **Clone the Repository**

   ```bash
   git clone https://github.com/ZentrixLabs/ZentrixLabs.FalconSdk.ConsoleDemo.git
   cd ZentrixLabs.FalconSdk.ConsoleDemo
   ```

2. **Build the App**

   ```bash
   dotnet build
   ```

3. **Run the Demo**

   ```bash
   dotnet run
   ```

---

## 🔑 Authentication First!

⚠️ **Important:**  
Before you can run device or vulnerability demos, you must authenticate using the **Authentication Service** in the main menu. This allows the demo to obtain a valid access token for subsequent API calls.

---

## 🖥️ Demo Flow

When you run the app, you’ll see a main menu:

```
[Falcon] Falcon SDK Console Demo
--------------------------------
1. [Auth] Authentication Service
2. [Device] Device Service
3. [Spotlight] Spotlight Service
0. [Exit] Exit
```

- Start with **1. [Auth]** — enter your Base URL, Client ID, and Client Secret.
- Then explore **Device** or **Spotlight** demos.

Each service comes with:
- An explanation page with usage notes and code snippets
- A demo option to try it live

---

## 📦 App Structure

```
ZentrixLabs.FalconConsoleDemo/
│
├── Program.cs                     # Entry point
├── Menus/
│   ├── MainMenu.cs
│   ├── AuthServiceMenu.cs
│   ├── DeviceServiceMenu.cs
│   └── SpotlightServiceMenu.cs
│
├── Demos/
│   └── SdkDemos.cs               # Interactive demos for each service
│
├── Models/
│   ├── ExplainAuthentication.cs
│   ├── ExplainDeviceService.cs
│   └── ExplainSpotlightService.cs
│
├── Utilities/
│   └── ConsoleHelpers.cs         # Emoji fallback and UI helpers
│
└── appsettings.json (optional)    # Users provide values at runtime
```

---

## 🤝 Contributing

We welcome contributions! Feel free to open issues, create pull requests, or suggest enhancements.

---

## 🙏 Acknowledgments

- This project uses the [ZentrixLabs.FalconSdk](https://github.com/ZentrixLabs/ZentrixLabs.FalconSdk) to communicate with the CrowdStrike Falcon API.

- This SDK would not have been possible without the work already done by the team behind the [PSFalcon](https://github.com/CrowdStrike/psfalcon) module and the Falcon SDK.

We extend our thanks to the CrowdStrike API community for their support and documentation.
---

## 📢 Notes

- This demo app is intentionally **educational and developer-friendly**—it’s not intended for production use.
- Always secure your API credentials and never hardcode them in public repos.
- This Sdk will continue to evolve to encompass more features and services from the CrowdStrike Falcon API.

---

Enjoy exploring the Falcon API with the ZentrixLabs Falcon SDK Console Demo! 🦅

If you'd like to support this project:

[![Buy Me A Coffee](https://cdn.buymeacoffee.com/buttons/default-orange.png)](https://www.buymeacoffee.com/Mainframe79)
