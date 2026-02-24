using LRUCache.CrossUI.Models;

namespace LRUCache.CrossUI.Services;

public interface ICsvService
{
    Task<List<BenchmarkInfo>> LoadBenchmarkDataAsync(string filePath);
}
