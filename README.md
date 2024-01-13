<a name="readme-top"></a>
<h1 align="center">streamdeck-gpu</h1>

<h1 align="center">
  <a href="" target="_blank">
    <img src="streamdeck-gpu/gpu/Images/pluginAction@2x.png" alt="Logo" width="125" height="125">
  </a>
</h1>

<p align="center">A Stream Deck plugin that displays the current GPU temperature.</p>

<p align="center"><a href="https://github.com/nicolasluckie/streamdeck-gpu/actions/workflows/main.yml"><img src="https://github.com/nicolasluckie/streamdeck-gpu/actions/workflows/main.yml/badge.svg" alt="Build Status"></a></p>

<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about">About</a>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
        <li><a href="#building-from-source">Building from Source</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#change-log">Change Log</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>

## About

An open-source Stream Deck plugin, written in C#. It uses the [OpenHardwareMonitor](https://openhardwaremonitor.org/) library to monitor and display the current GPU temperature every second.

## Getting Started

### Prerequisites

Before you begin, ensure the following are installed:

- [.NET Framework 4.7.2](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net472) or later
- [.NET Core 3.1 SDK](https://dotnet.microsoft.com/en-us/download/dotnet) or later
- [Visual Studio](https://visualstudio.microsoft.com/downloads/)
- [Stream Deck software](https://www.elgato.com/ca/en/s/downloads)

### Installation

1. Download the [latest release](https://github.com/nicolasluckie/streamdeck-gpu/releases/) and extract it.

2. Quit Stream Deck.

3. Copy the **"com.nicolasluckie.gpu.sdPlugin"** folder to **"C:\Users\User\AppData\Roaming\Elgato\StreamDeck\Plugins\"**

4. Launch Stream Deck. You should now see the GPU plugin in the action menu on the right.

5. To see plugin information open **Preferences > Plugins > GPU**

### Building from Source

1. Clone the repository to your local machine:

    ```
    git clone https://github.com/nicolasluckie/streamdeck-gpu.git
    ```

2. Open the solution file (`streamdeck-gpu.sln`) in Visual Studio.

3. Right-click on the solution in the Solution Explorer and select **"Restore NuGet Packages"** to download OpenHardwareMonitor and other dependencies.
   
4. Right-click on the solution in the Solution Explorer and select **"Manage NuGet Packages for Solution"**, click the **"Select all packages"** checkbox, then click **"Update"** to update all dependencies.

5. Build the solution by clicking on **"Build" > "Build Solution"** in the menu.

6. Once the build is successful, the plugin will be available in the `bin/Debug` directory by default. You can change this to `bin/Release` in the build configuration settings.

7. Follow steps 2-5 of the [Installation](#installation) instructions to load the plugin into Stream Deck.

## Usage

![usage](/usage.gif)

## Change Log

### Version 1.0.0
- Initial commit

## License

[License](/LICENSE)

## Acknowledgments

Plugin template from [BarRaider/streamdeck-tools](https://github.com/BarRaider/streamdeck-tools)

<p align="right">(<a href="#readme-top">back to top</a>)</p>
