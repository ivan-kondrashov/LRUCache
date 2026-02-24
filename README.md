# LRU Cache Performance Analysis 🚀

A high-performance **LRU (Least Recently Used) Cache** implementation in C#, featuring automated performance benchmarking and a rich WPF visualization dashboard.

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=flat-square&logo=dotnet)
![Windows](https://img.shields.io/badge/Platform-Windows-0078D6?style=flat-square&logo=windows)
![LiveCharts](https://img.shields.io/badge/Charts-LiveCharts2-FF69B4?style=flat-square)

## 🌟 Overview

This project provides a robust LRU Cache with O(1) complexity for both `Get` and `Put` operations. It includes two primary components:
1. **LRUCache.Benchmark**: A `BenchmarkDotNet` suite to measure performance at various scales (1k to 1M items).
2. **LRUCache.UI**: A modern WPF dashboard to visualize and compare benchmark results.

## 🛠️ Tech Stack

- **Core**: .NET 10
- **Benchmarking**: BenchmarkDotNet
- **UI Framework**: WPF (Windows Presentation Foundation)
- **MVVM**: CommunityToolkit.Mvvm
- **Data Visualization**: LiveCharts2 (SkiaSharp)
- **Data Handling**: CsvHelper

## 🚀 Getting Started

### Prerequisites
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- Windows OS (for WPF UI)

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

## 📈 Features

- **Grouped Analysis**: Compare `Put` vs `Get` performance side-by-side.
- **Scalability Testing**: Measures execution time and memory allocation across different item counts.
- **Modern UI**: Dark-themed, responsive charts powered by SkiaSharp.

---
*Built with ❤️ for performance analysis.*
