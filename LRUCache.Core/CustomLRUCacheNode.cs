namespace LRUCache.Core;

public class CustomLRUCacheNode
{
    public int Key { get; }
    public int Value { get; set; }
    public CustomLRUCacheNode Prev { get; set; }
    public CustomLRUCacheNode Next { get; set; }
    public CustomLRUCacheNode(int key, int value)
    {
        Key = key;
        Value = value;
    }
}
