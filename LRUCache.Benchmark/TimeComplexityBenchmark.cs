using BenchmarkDotNet.Attributes;
using LRUCache.Core;

namespace LRUCache.Benchmark;

[MemoryDiagnoser]
public class TimeComplexityBenchmark
{
    private CustomLRUCache _cache = null!;
    private LRUCacheEngine _engine = null!;
    private int[] _keys = null!;
    private int[] _updateKeys = null!;
    private int[] _newKeys = null!;
    private int _index;

    [Params(1000, 10000, 100000, 1000000)]
    public int ItemsCount { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        _cache = new CustomLRUCache(ItemsCount);
        _engine = new LRUCacheEngine(ItemsCount);
        _keys = new int[ItemsCount];
        _updateKeys = new int[1000];
        _newKeys = new int[1000];
        
        var random = new Random(42);

        for (int i = 0; i < ItemsCount; i++)
        {
            _keys[i] = i;
            _cache.Put(i, i);
            _engine.Put(i, i);
        }

        for (int i = 0; i < 1000; i++)
        {
            _updateKeys[i] = random.Next(0, ItemsCount);
            _newKeys[i] = ItemsCount + i;
        }

        _index = 0;
    }

    [Benchmark]
    public int Get_Hit_Custom()
    {
        int key = _keys[_index++ % ItemsCount];
        return _cache.Get(key);
    }

    [Benchmark]
    public int Get_Miss_Custom()
    {
        return _cache.Get(-1);
    }

    [Benchmark]
    public void Put_Update_Custom()
    {
        int key = _updateKeys[_index++ % 1000];
        _cache.Put(key, _index);
    }

    [Benchmark]
    public void Put_New_WithEviction_Custom()
    {
        int key = _newKeys[_index++ % 1000];
        _cache.Put(key, _index);
    }

    [Benchmark]
    public int Get_Hit_Builtin()
    {
        int key = _keys[_index++ % ItemsCount];
        return _engine.Get(key);
    }

    [Benchmark]
    public int Get_Miss_Builtin()
    {
        return _engine.Get(-1);
    }

    [Benchmark]
    public void Put_Update_Builtin()
    {
        int key = _updateKeys[_index++ % 1000];
        _engine.Put(key, _index);
    }

    [Benchmark]
    public void Put_New_WithEviction_Builtin()
    {
        int key = _newKeys[_index++ % 1000];
        _engine.Put(key, _index);
    }
}
