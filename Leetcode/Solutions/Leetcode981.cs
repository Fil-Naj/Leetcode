using Leetcode.Extensions;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Security;

namespace Leetcode.Solutions
{
    [ToBeContinued("TIme exceeded and cba fixing it. Not optimal")]
    public class Leetcode981 : ISolution
    {
        public string Name => "Time Based Key-Value Store\r\n";
        public string Description => "Design a time-based key-value data structure that can store multiple values for the same key at different time stamps and retrieve the key's value at a certain timestamp.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            Stopwatch sw = new();
            // TODO
            sw.Start();
            var tm = new TimeMap();
            for (int i = 0; i < 100; i++)
            {
                tm.Set("love", "high", 10 + i*5);
                //tm.Set("love", "low", 20 + i*5);
                tm.Get("love", 5 + i*5);
                tm.Get("love", 10 + i*5);
                tm.Get("love", 15 + i*5);
                tm.Get("love", 20 + i*5);
                tm.Get("love", 25 + i*5);
            }
            sw.Stop();
            Console.WriteLine($"Linq took: {sw.ElapsedMilliseconds}ms");

            sw.Reset();

            //sw.Start();
            //var tm1 = new TimeMap();
            //for (int i = 0; i < 100; i++)
            //{
            //    tm1.Set("love", "high", 10 + i*5);
            //    tm1.Get("love", 5 + i * 5);
            //    tm1.Get("love", 10 + i * 5);
            //    tm1.Get("love", 15 + i * 5);
            //    tm1.Get("love", 20 + i * 5);
            //    tm1.Get("love", 25 + i * 5);
            //}
            //sw.Stop();
            //Console.WriteLine($"For took: {sw.ElapsedMilliseconds}ms");

            // Prettify
            // Console.WriteLine($"Input: data = {data.GetString()}, target = {target}");
            // Console.WriteLine($"Output: {result.GetString()}");
        }

        public class TimeMap
        {
            Dictionary<string, List<(int TimeStamp, string val)>> keyValuePairs;

            public TimeMap()
            {
                keyValuePairs = new();
            }

            public void Set(string key, string value, int timestamp)
            {
                if (keyValuePairs.TryGetValue(key, out var editions))
                    editions.Add((timestamp, value));
                else
                    keyValuePairs.Add(key, new List<(int TimeStamp, string val)> { (timestamp, value) });
            }

            public string Get(string key, int timestamp)
            {
                var result = string.Empty;

                int left = 0;
                int right = keyValuePairs.Count;

                while (left < right)
                {
                    int mid = (left + right) / 2;
                    if (keyValuePairs[key][mid].TimeStamp <= timestamp)
                        left = mid + 1;
                    else
                        right = mid;
                }

                if (right == 0)
                    return result;
                    
                return keyValuePairs[key][right - 1].val;
            }

            //public string Get(string key, int timestamp)
            //{
            //    var result = string.Empty;
            //    foreach (var pair in keyValuePairs)
            //    {
            //        if (pair.Key.Key == key && pair.Key.TimeStamp <= timestamp)
            //            result = pair.Value;
            //    }
            //    return result;
            //}
        }
    }
}
