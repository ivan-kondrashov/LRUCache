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
            if (_cacheMap.Count >= _capacity)
            {
                var lastNode = _cacheOrder.Last;

                _cacheMap.Remove(lastNode.Value.Key);

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
