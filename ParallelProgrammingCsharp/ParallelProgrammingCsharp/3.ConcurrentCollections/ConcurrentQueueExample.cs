﻿using System.Collections.Concurrent;

namespace ParallelProgrammingCsharp._3.ConcurrentCollections;

public class ConcurrentQueueExample : IExample
{
    public static void Run()
    {
        var q = new ConcurrentQueue<int>();
        q.Enqueue(1);
        q.Enqueue(2);

        int result;
        if (q.TryDequeue(out result))
        {
            Console.WriteLine($"Removed element {result}");
        }

        if (q.TryPeek(out result))
        {
            Console.WriteLine($"Front element is {result}");
        }
    }
}