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
        _cache = new Dictionary<int, CustomLRUCacheNode>();

        _head = new CustomLRUCacheNode(0, 0);
        _tail = new CustomLRUCacheNode(0, 0);
        _head.Next = _tail;
        _tail.Prev = _head;
    }

    public int Get(int key)
    {
        if (_cache.TryGetValue(key, out var node))
        {
            RemoveCustomLRUCacheNode(node);
            AddToFront(node);
            return node.Value;
        }
        return -1;
    }

    public void Put(int key, int value)
    {
        if (_cache.TryGetValue(key, out var node))
        {
            RemoveCustomLRUCacheNode(node);
            node.Value = value;
            AddToFront(node);
        }
        else
        {
            if (_cache.Count >= _capacity)
            {
                var lruCustomLRUCacheNode = _tail.Prev;
                _cache.Remove(lruCustomLRUCacheNode.Key);
                RemoveCustomLRUCacheNode(lruCustomLRUCacheNode);
            }

            var newCustomLRUCacheNode = new CustomLRUCacheNode(key, value);
            _cache[key] = newCustomLRUCacheNode;
            AddToFront(newCustomLRUCacheNode);
        }
    }

    private void RemoveCustomLRUCacheNode(CustomLRUCacheNode node)
    {
        node.Prev.Next = node.Next;
        node.Next.Prev = node.Prev;
    }

    private void AddToFront(CustomLRUCacheNode node)
    {
        node.Next = _head.Next;
        node.Prev = _head;
        _head.Next.Prev = node;
        _head.Next = node;
    }
}
