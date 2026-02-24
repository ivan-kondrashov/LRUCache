using LRUCache.UI.Models;

namespace LRUCache.UI.Services;

public interface ICsvService
{
    Task<List<BenchmarkInfo>> LoadBenchmarkDataAsync(string filePath);
}
