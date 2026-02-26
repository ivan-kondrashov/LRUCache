namespace LRUCache.Core;

public class CustomLRUCache
{
    private readonly int _capacity;
    private readonly Dictionary<int, CustomLRUCacheNode> _cache;
    private readonly CustomLRUCacheNode _head;
    private readonly CustomLRUCacheNode _tail;

    public CustomLRUCache(int capacity)
    {
        _capacity = capacity;
        _cache = new Dictionary<int, CustomLRUCacheNode>(capacity);

        _head = new CustomLRUCacheNode(0, 0);
        _tail = new CustomLRUCacheNode(0, 0);
        _head.Next = _tail;
        _tail.Prev = _head;
    }

    public int Get(int key)
    {
        if (!_cache.TryGetValue(key, out var node))
        {
            return -1;
        }

        MoveToHead(node);
        return node.Value;
    }

    public void Put(int key, int value)
    {
        if (_cache.TryGetValue(key, out var node))
        {
            node.Value = value;
            MoveToHead(node);
        }
        else
        {
            if (_cache.Count >= _capacity)
            {
                var lru = _tail.Prev;
                RemoveNode(lru);
                _cache.Remove(lru.Key);
            }

            var newNode = new CustomLRUCacheNode(key, value);
            AddNode(newNode);
            _cache[key] = newNode;
        }
    }

    private void AddNode(CustomLRUCacheNode node)
    {
        node.Prev = _head;
        node.Next = _head.Next;

        _head.Next.Prev = node;
        _head.Next = node;
    }

    private void RemoveNode(CustomLRUCacheNode node)
    {
        var prev = node.Prev;
        var next = node.Next;

        prev.Next = next;
        next.Prev = prev;
    }

    private void MoveToHead(CustomLRUCacheNode node)
    {
        RemoveNode(node);
        AddNode(node);
    }
}
