using System;
using System.Collections.Generic;

namespace learning_dsa_csharp._12_advanced_graphs._002_swim_in_rising_water
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

    public class Solution
    {
        // fails at TC 21/43 - TLE
        // [[26,99,80,1,89,86,54,90,47,87],[9,59,61,49,14,55,77,3,83,79],[42,22,15,5,95,38,74,12,92,71],[58,40,64,62,24,85,30,6,96,52],[10,70,57,19,44,27,98,16,25,65],[13,0,76,32,29,45,28,69,53,41],[18,8,21,67,46,36,56,50,51,72],[39,78,48,63,68,91,34,4,11,31],[97,23,60,17,66,37,43,33,84,35],[75,88,82,20,7,73,2,94,93,81]]
        public int SwimInWater_my_own_minPQ_BFS(int[][] grid)
        {
            int rLen = grid.Length;
            int cLen = grid[0].Length;

            int[] directionX = new[] { 1, -1, 0, 0 };
            int[] directionY = new[] { 0, 0, 1, -1 };

            Dictionary<(int, int), int> dp = new Dictionary<(int, int), int>();

            int dfs(int r, int c, int time, List<(int, int)> visited)
            {
                if (r == rLen - 1 && c == cLen - 1)
                {
                    return time;
                }

                if (dp.ContainsKey((r, c)))
                {
                    var currdp = dp[(r, c)];
                    if (time < currdp && time > grid[r][c]) { }
                    else
                    {
                        return currdp;
                    }
                }

                visited.Add((r, c));

                MinValueQueue<(int, int)> q = new MinValueQueue<(int, int)>();
                q.CompareFunction = (x, y) =>
                {
                    var (r1, c1) = x;
                    var (r2, c2) = y;

                    return grid[r1][c1].CompareTo(grid[r2][c2]);
                };

                for (int i = 0; i < 4; ++i)
                {
                    int nextR = r + directionX[i];
                    int nextC = c + directionY[i];

                    if (
                        nextR < 0
                        || nextC < 0
                        || nextR == rLen
                        || nextC == cLen
                        || visited.Contains((nextR, nextC))
                    )
                    {
                        continue;
                    }
                    else
                    {
                        q.Enqueue((nextR, nextC));
                    }
                }

                int min = int.MaxValue;
                while (q.Count > 0)
                {
                    var (potentialR, potentialC) = q.Dequeue();
                    int t;
                    if (time >= grid[potentialR][potentialC])
                    {
                        t = time;
                    }
                    else
                    {
                        t = grid[potentialR][potentialC];
                    }

                    min = Math.Min(min, dfs(potentialR, potentialC, t, visited));
                }

                visited.Remove((r, c));
                dp[(r, c)] = min;
                return min;
            }

            return dfs(0, 0, grid[0][0], new List<(int, int)>());
        }

        // solution - https://leetcode.com/problems/swim-in-rising-water/solutions/1285099/easy-solution-w-explanation-optimization-from-brute-force-to-binary-search-beats-100/
        public int SwimInWater_lowest_water_level(int[][] grid)
        {
            var moves = new int[][]
            {
                new int[] { 1, 0 },
                new int[] { -1, 0 },
                new int[] { 0, 1 },
                new int[] { 0, -1 }
            };

            int n = grid.Length;
            int minReq = Math.Max(2 * (n - 1), Math.Max(grid[0][0], grid[n - 1][n - 1]));
            for (int w_lvl = minReq; w_lvl < n * n; w_lvl++)
            {
                if (dfs(0, 0, w_lvl, new List<(int, int)>()))
                    return w_lvl;
            }

            return n * n;

            bool dfs(int i, int j, int w_lvl, List<(int, int)> vis)
            {
                if (
                    i < 0
                    || j < 0
                    || i >= n
                    || j >= n
                    || vis.Contains((i, j))
                    || grid[i][j] > w_lvl
                )
                    return false; // out-of-bound / already visited / cell value > max w_lvl allowed

                if (i == n - 1 && j == n - 1)
                    return true;

                vis.Add((i, j));

                for (int k = 0; k < 4; k++)
                {
                    // search all available option till any of it leads us to the end
                    if (dfs(i + moves[k][0], j + moves[k][1], w_lvl, vis))
                        return true;
                }

                return false;
            }
        }

        public int SwimInWater_lowest_water_level_binary_search(int[][] grid)
        {
            var moves = new int[][]
            {
                new int[] { 1, 0 },
                new int[] { -1, 0 },
                new int[] { 0, 1 },
                new int[] { 0, -1 }
            };

            int n = grid.Length;
            int l = Math.Max(2 * (n - 1), Math.Max(grid[0][0], grid[n - 1][n - 1]));
            int r = n * n - 1;

            while (l <= r)
            {
                int mid = (l + r) / 2;
                if (dfs(0, 0, mid, new List<(int, int)>()))
                    r = mid - 1;
                else
                    l = mid + 1;
            }

            return l;

            bool dfs(int i, int j, int w_lvl, List<(int, int)> vis)
            {
                if (
                    i < 0
                    || j < 0
                    || i >= n
                    || j >= n
                    || vis.Contains((i, j))
                    || grid[i][j] > w_lvl
                )
                    return false; // out-of-bound / already visited / cell value > max w_lvl allowed

                if (i == n - 1 && j == n - 1)
                    return true;

                vis.Add((i, j));

                for (int k = 0; k < 4; k++)
                {
                    // search all available option till any of it leads us to the end
                    if (dfs(i + moves[k][0], j + moves[k][1], w_lvl, vis))
                        return true;
                }

                return false;
            }
        }
    }
}
