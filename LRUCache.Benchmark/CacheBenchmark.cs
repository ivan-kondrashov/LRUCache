using BenchmarkDotNet.Attributes;
using LRUCache.Core;

namespace LRUCache.Benchmark;

[MemoryDiagnoser]
public class CacheBenchmark
{
    private LRUCacheEngine _cache;
    private CustomLRUCache _customLRUCache;
    private int[] _keys;
    private int _index;

    [Params(1000, 10000, 100000, 1000000)]
    public int ItemsCount { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        _cache = new LRUCacheEngine(ItemsCount);
        _customLRUCache = new CustomLRUCache(ItemsCount);
        _keys = new int[ItemsCount];

        for (int i = 0; i < ItemsCount; i++)
        {
            _keys[i] = i;
            _cache.Put(i, i);
            _customLRUCache.Put(i, i);
        }
        _index = 0;
    }

    [Benchmark]
    public int Get_Builtin()
    {
        int key = _keys[_index++ % ItemsCount];
        return _cache.Get(key);
    }

    [Benchmark]
    public void Put_Builtin()
    {
        int key = _index++ % (ItemsCount * 2);
        _cache.Put(key, key);
    }

    [Benchmark]
    public int Get_Custom()
    {
        int key = _keys[_index++ % ItemsCount];
        return _customLRUCache.Get(key);
    }

    [Benchmark]
    public void Put_Custom()
    {
        int key = _index++ % (ItemsCount * 2);
        _customLRUCache.Put(key, key);
    }
}
