namespace LRUCache.Core;

public class LRUCacheEngine
{
    private Dictionary<int, LinkedListNode<CacheItem>> _cacheMap;
    private LinkedList<CacheItem> _cacheOrder;
    private int _capacity;

    public LRUCacheEngine(int capacity)
    {
        _capacity = capacity;
        _cacheMap = new Dictionary<int, LinkedListNode<CacheItem>>(capacity);
        _cacheOrder = new LinkedList<CacheItem>();
    }

    public int Get(int key)
    {
        if (!_cacheMap.TryGetValue(key, out var node))
        {
            return -1;
        }

        _cacheOrder.Remove(node);
        _cacheOrder.AddFirst(node);

        return node.Value.Value;
    }

    public void Put(int key, int value)
    {
        if (_cacheMap.TryGetValue(key, out var node))
        {
            node.Value.Value = value;
            _cacheOrder.Remove(node);
            _cacheOrder.AddFirst(node);
        }
        else
        {
            // Check if we are at capacity before adding new
            if (_cacheMap.Count >= _capacity)
            {
                // 1. Get the last node (Least Recently Used)
                var lastNode = _cacheOrder.Last;

                // 2. Remove from Dictionary using the stored key
                _cacheMap.Remove(lastNode.Value.Key);

                // 3. Remove from LinkedList
                _cacheOrder.RemoveLast();
            }

            var newNode = new LinkedListNode<CacheItem>(new CacheItem 
            {
                Key = key,
                Value = value 
            });

            _cacheMap[key] = newNode;
            _cacheOrder.AddFirst(newNode);
        }
    }
}
