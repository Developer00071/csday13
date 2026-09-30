namespace Domai;
public static class Cache<T>
{
    private static readonly Dictionary<string, T> _cache = new Dictionary<string, T>();

    
    public static void Add(string key, T value)
    {
        if (!_cache.ContainsKey(key))
        {
            _cache[key] = value;
        }
        else
        {
            throw new ArgumentException($"An item with the key '{key}' already exists in the cache.");
        }
    }

    
    public static T Get(string key)
    {
        if (_cache.TryGetValue(key, out T value))
        {
            return value;
        }
        else
        {
            throw new KeyNotFoundException($"No item found in the cache with the key '{key}'.");
        }
    }

    
    public static void Remove(string key)
    {
        if (!_cache.Remove(key))
        {
            throw new KeyNotFoundException($"No item found in the cache with the key '{key}' to remove.");
        }
    }
}
