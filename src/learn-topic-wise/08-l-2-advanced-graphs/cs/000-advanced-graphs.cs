using System;
using System.Collections.Generic;

namespace learning_dsa_csharp._12_advanced_graphs
{
    class MinValueQueue<T>
    {
        List<T> _q;
        public Comparison<T> CompareFunction;
        public int Count
        {
            get { return _q.Count; }
        }

        public MinValueQueue()
        {
            _q = new List<T>();
        }

        public void Enqueue(T val)
        {
            _q.Add(val);
            _q.Sort(
                (x, y) =>
                {
                    return CompareFunction(x, y);
                }
            );

            var qq = _q;
        }

        public T Dequeue()
        {
            var val = _q[0];
            List<T> q = new List<T>();
            for (int i = 1; i < _q.Count; i++)
            {
                q.Add(_q[i]);
            }
            _q = q;
            return val;
        }
    }

    internal class AdvancedGraphs
    {
        public static void Main(string[] args)
        {
            var g = new AdvancedGraphs();

            // problem - https://leetcode.com/problems/reconstruct-itinerary/?envType=list&envId=ph3blvae
            //g.ReconstructItinerary();

            // problem - https://leetcode.com/problems/swim-in-rising-water/
            g.SwimInRisingWater();
        }

        private void ReconstructItinerary()
        {
            var s = new _001_reconstruct_itinerary.Solution();

            IList<IList<string>> array = new List<IList<string>>()
            {
                new List<string>() { "JFK", "SFO" },
                new List<string>() { "JFK", "ATL" },
                new List<string>() { "SFO", "ATL" },
                new List<string>() { "ATL", "SFO" },
                new List<string>() { "ATL", "JFK" }
            };

            //array = new List<IList<string>>() {
            //    new List<string>() { "TIA", "JFK" },
            //    new List<string>() { "EZE", "HBA" },
            //    new List<string>() { "JFK", "TIA" },
            //    //new List<string>() { "JFK", "TIA" },
            //    new List<string>() { "JFK", "EZE" },
            //};

            //array = new List<IList<string>>(){
            //    new List<string>() {"EZE","TIA" },
            //    new List<string>() {"EZE","HBA"},
            //    new List<string>() {"AXA","TIA"},
            //    new List<string>() {"JFK","AXA"},
            //    new List<string>() {"ANU","JFK"},
            //    new List<string>() {"ADL","ANU"},
            //    new List<string>() {"TIA","AUA"},
            //    new List<string>() {"ANU","AUA"},
            //    new List<string>() {"ADL","EZE"},
            //    new List<string>() {"ADL","EZE"},
            //    new List<string>() {"EZE","ADL"},
            //    new List<string>() {"AXA","EZE"},
            //    new List<string>() {"AUA","AXA"},
            //    new List<string>() {"JFK","AXA"},
            //    new List<string>() {"AXA","AUA"},
            //    new List<string>() {"AUA","ADL"},
            //    new List<string>() {"ANU","EZE"},
            //    new List<string>() {"TIA","ADL"},
            //    new List<string>() {"EZE","ANU"},
            //    new List<string>() {"AUA","ANU"},
            //};

            //array = new List<IList<string>>(){
            //    new List<string>() { "JFK", "SFO" },
            //    new List<string>() { "JFK", "ATL" },
            //    new List<string>() { "SFO", "JFK" },
            //    new List<string>() { "ATL", "AAA" },
            //    new List<string>() { "AAA", "BBB" },
            //    new List<string>() { "BBB", "ATL" },
            //    new List<string>() { "ATL", "AAA" },
            //    new List<string>() { "AAA", "BBB" },
            //    new List<string>() { "BBB", "ATL" },
            //    new List<string>() { "ATL", "AAA" },
            //    new List<string>() { "AAA", "BBB" },
            //    new List<string>() { "BBB", "ATL" },
            //    new List<string>() { "ATL", "AAA" },
            //    new List<string>() { "AAA", "BBB" },
            //    new List<string>() { "BBB", "ATL" },
            //    new List<string>() { "ATL", "AAA" },
            //    new List<string>() { "AAA", "BBB" },
            //    new List<string>() { "BBB", "ATL" },
            //    new List<string>() { "ATL", "AAA" },
            //    new List<string>() { "AAA", "BBB" },
            //    new List<string>() { "BBB", "ATL" },
            //    new List<string>() { "ATL", "AAA" },
            //    new List<string>() { "AAA", "BBB" },
            //    new List<string>() { "BBB", "ATL" },
            //    new List<string>() { "ATL", "AAA" },
            //    new List<string>() { "AAA", "BBB" },
            //    new List<string>() { "BBB", "ATL" },
            //    new List<string>() { "ATL", "AAA" },
            //    new List<string>() { "AAA", "BBB" },
            //    new List<string>() { "BBB", "ATL" },
            //    new List<string>() { "ATL", "AAA" },
            //    new List<string>() { "AAA", "BBB" },
            //    new List<string>() { "BBB", "ATL" },
            //    new List<string>() { "ATL", "AAA" },
            //    new List<string>() { "AAA", "BBB" },
            //    new List<string>() { "BBB", "ATL" },
            //    new List<string>() { "ATL", "AAA" },
            //    new List<string>() { "AAA", "BBB" },
            //    new List<string>() { "BBB", "ATL" },
            //    new List<string>() { "ATL", "AAA" },
            //    new List<string>() { "AAA", "BBB" },
            //    new List<string>() { "BBB", "ATL" },
            //    new List<string>() { "ATL", "AAA" },
            //    new List<string>() { "AAA", "BBB" },
            //    new List<string>() { "BBB", "ATL" },
            //    new List<string>() { "ATL", "AAA" },
            //    new List<string>() { "AAA", "BBB" },
            //    new List<string>() { "BBB", "ATL" },
            //    new List<string>() { "ATL", "AAA" },
            //    new List<string>() { "AAA", "BBB" },
            //    new List<string>() { "BBB", "ATL" },
            //    new List<string>() { "ATL", "AAA" },
            //    new List<string>() { "AAA", "BBB" },
            //    new List<string>() { "BBB", "ATL" },
            //    new List<string>() { "ATL", "AAA" },
            //    new List<string>() { "AAA", "BBB" },
            //    new List<string>() { "BBB", "ATL" },
            //    new List<string>() { "ATL", "AAA" },
            //    new List<string>() { "AAA", "BBB" },
            //    new List<string>() { "BBB", "ATL" },
            //    new List<string>() { "ATL", "AAA" },
            //    new List<string>() { "AAA", "BBB" },
            //    new List<string>() { "BBB", "ATL" },
            //    new List<string>() { "ATL", "AAA" },
            //    new List<string>() { "AAA", "BBB" },
            //    new List<string>() { "BBB", "ATL" },
            //    new List<string>() { "ATL", "AAA" },
            //    new List<string>() { "AAA", "BBB" },
            //    new List<string>() { "BBB", "ATL" },
            //    new List<string>() { "ATL", "AAA" },
            //    new List<string>() { "AAA", "BBB" },
            //    new List<string>() { "BBB", "ATL" },
            //    new List<string>() { "ATL", "AAA" },
            //    new List<string>() { "AAA", "BBB" },
            //    new List<string>() { "BBB", "ATL" },
            //    new List<string>() { "ATL", "AAA" },
            //    new List<string>() { "AAA", "BBB" },
            //    new List<string>() { "BBB", "ATL" },
            //    new List<string>() { "ATL", "AAA" },
            //    new List<string>() { "AAA", "BBB" },
            //    new List<string>() { "BBB", "ATL" },
            //};

            // solution - own
            //var res = s.FindItinerary_my_own(array);
            var res = s.findItinerary_dfs(array);

            for (int i = 0; i < res.Count; ++i)
            {
                Console.WriteLine(res[i]);
            }
        }

        private void SwimInRisingWater()
        {
            var grid = new int[][]
            {
                new int[] { 0, 10, 2 },
                new int[] { 4, 5, 7 },
                new int[] { 3, 20, 8 },
            };

            grid = new int[][] { new int[] { 0, 2 }, new int[] { 1, 3 }, };

            grid = new int[][]
            {
                new int[] { 0, 1, 2, 3, 4 },
                new int[] { 24, 23, 22, 21, 5 },
                new int[] { 12, 13, 14, 15, 16 },
                new int[] { 11, 17, 18, 19, 20 },
                new int[] { 10, 9, 8, 7, 6 }
            };

            grid = new int[][]
            {
                new int[] { 10, 12, 4, 6 },
                new int[] { 9, 11, 3, 5 },
                new int[] { 1, 7, 13, 8 },
                new int[] { 2, 0, 15, 14 }
            };

            grid = new int[][]
            {
                new int[] { 11, 15, 3, 2 },
                new int[] { 6, 4, 0, 13 },
                new int[] { 5, 8, 9, 10 },
                new int[] { 1, 14, 12, 7 }
            };

            grid = new int[][]
            {
                new int[] { 6, 22, 3, 23, 1 },
                new int[] { 14, 8, 7, 16, 5 },
                new int[] { 11, 0, 9, 15, 18 },
                new int[] { 24, 4, 2, 13, 19 },
                new int[] { 20, 10, 17, 21, 12 }
            };

            var s = new _002_swim_in_rising_water.Solution();
            var res = s.SwimInWater_lowest_water_level_binary_search(grid);

            Console.WriteLine(res);
        }
    }
}
