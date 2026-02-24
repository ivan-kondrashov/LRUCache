using LRUCache.Core;
using System.Diagnostics;

int[] sizes = { 1000, 10000, 100000, 1000000 };
Console.WriteLine($"{"Size",-10} | {"Put (avg ns)",-15} | {"Get (avg ns)",-15}");
Console.WriteLine(new string('-', 45));

foreach (int size in sizes)
{
    var lru = new LRUCacheEngine(size);
    var sw = new Stopwatch();

    sw.Start();
    for (int i = 0; i < size; i++)
    {
        lru.Put(i, i);
    }
    sw.Stop();
    double avgPut = (double)sw.ElapsedTicks / size * (1000000000.0 / Stopwatch.Frequency);

    sw.Restart();
    for (int i = 0; i < size; i++)
    {
        lru.Get(i);
    }
    sw.Stop();
    double avgGet = (double)sw.ElapsedTicks / size * (1000000000.0 / Stopwatch.Frequency);

    Console.WriteLine($"{size,-10} | {avgPut,-15:F2} | {avgGet,-15:F2}");
}
