# LRU Cache Performance Analysis 🚀

A high-performance **LRU (Least Recently Used) Cache** implementation in C#, featuring automated performance benchmarking and a rich WPF visualization dashboard.

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=flat-square&logo=dotnet)
![Windows](https://img.shields.io/badge/Platform-Windows-0078D6?style=flat-square&logo=windows)
![Multi-platform](https://img.shields.io/badge/Platform-Android%20%7C%20iOS%20%7C%20macOS-brightgreen?style=flat-square)
![LiveCharts](https://img.shields.io/badge/Charts-LiveCharts2-FF69B4?style=flat-square)

## 🌟 Overview

This project provides a robust LRU Cache with O(1) complexity for both `Get` and `Put` operations. It includes two primary components:
1. **LRUCache.Benchmark**: A `BenchmarkDotNet` suite to measure performance at various scales (1k to 1M items).
2. **LRUCache.UI**: A modern WPF dashboard to visualize and compare benchmark results.
3. **LRUCache.CrossUI**: A cross-platform **.NET MAUI** dashboard for mobile and desktop visualization.

## 🛠️ Tech Stack

- **Core**: .NET 10
- **Benchmarking**: BenchmarkDotNet
- **UI Frameworks**: WPF (Windows), .NET MAUI (Cross-platform)
- **MVVM**: CommunityToolkit.Mvvm
- **Data Visualization**: LiveCharts2 (SkiaSharp)
- **Data Handling**: CsvHelper

## 🚀 Getting Started

### Prerequisites
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- MAUI workloads (`dotnet workload install maui`)
- Windows OS (for WPF), or Android/iOS/macOS (for MAUI)

### 1. Run Benchmarks 📊
To generate performance data, run the benchmark project in Release mode:

```powershell
dotnet run -c Release --project .\LRUCache.Benchmark\LRUCache.Benchmark.csproj
```
*The results will be saved in `BenchmarkDotNet.Artifacts/results` as a CSV file.*

### 2. Run UI Dashboard 🖥️
To visualize the results, launch the WPF application:

```powershell
dotnet run -c Release --project .\LRUCache.UI\LRUCache.UI.csproj
```
*Once launched, click **"Select Benchmark CSV"** and choose the generated CSV file.*

### 3. Run MAUI Dashboard (Cross-Platform) 📱
To run the MAUI dashboard on various platforms:

**Windows 10/11 (WinUI 3):**
```powershell
dotnet run -f net10.0-windows10.0.19041.0 -c Release --project .\LRUCache.CrossUI\LRUCache.CrossUI.csproj
```

**Android:**
```powershell
dotnet run -f net10.0-android -c Release --project .\LRUCache.CrossUI\LRUCache.CrossUI.csproj
```

**iOS:**
```powershell
dotnet run -f net10.0-ios -c Release --project .\LRUCache.CrossUI\LRUCache.CrossUI.csproj
```

**macOS (Catalyst):**
```powershell
dotnet run -f net10.0-maccatalyst -c Release --project .\LRUCache.CrossUI\LRUCache.CrossUI.csproj
```

## 📈 Features

- **Grouped Analysis**: Compare `Put` vs `Get` performance side-by-side.
- **Scalability Testing**: Measures execution time and memory allocation across different item counts.
- **Modern UI**: Dark-themed, responsive charts powered by SkiaSharp.

---
*Built with ❤️ for performance analysis.*
