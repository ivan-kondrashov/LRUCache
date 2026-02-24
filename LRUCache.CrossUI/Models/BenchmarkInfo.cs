using CsvHelper.Configuration.Attributes;

namespace LRUCache.CrossUI.Models;

public class BenchmarkInfo
{
    [Name("Method")]
    public string Method { get; set; } = string.Empty;

    [Name("Mean")]
    public string MeanRaw { get; set; } = string.Empty;

    [Name("ItemsCount")]
    public int ItemsCount { get; set; }

    [Name("Allocated")]
    public string AllocatedRaw { get; set; } = string.Empty;

    [Ignore]
    public double TimeNs { get; set; }

    [Ignore]
    public double MemoryBytes { get; set; }
}
