// [Find the Safest Path in a Grid](https://leetcode.com/problems/find-the-safest-path-in-a-grid/)
namespace learning_dsa_csharp._11_graphs._017_find_a_safest_path_in_a_grid
{
    internal class Solution_Linear_Search
    {
        readonly int[,] dir = { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } };

        bool IsSafe(int[,] safe, int m)
        {
            int n = safe.GetLength(0);

            if (safe[0, 0] < m || safe[n - 1, n - 1] < m) return false;

            Queue<(int, int)> q = new();
            q.Enqueue((0, 0));
            bool[,] v = new bool[n, n];
            v[0, 0] = true;

            while (q.Count > 0)
            {
                int qLen = q.Count;

                for (int i = 0; i < qLen; ++i)
                {
                    var (r, c) = q.Dequeue();

                    if (r == n - 1 && c == n - 1) return true;

                    for (int j = 0; j < 4; ++j)
                    {
                        int nR = r + dir[j, 0];
                        int nC = c + dir[j, 1];

                        if (nR < 0 || nR >= n || nC < 0 || nC >= n) continue;

                        if (safe[nR, nC] < m) continue;

                        if (v[nR, nC]) continue;

                        q.Enqueue((nR, nC));
                        v[nR, nC] = true;
                    }
                }
            }

            return false;
        }

        public int MaximumSafenessFactor(IList<IList<int>> grid)
        {
            int n = grid.Count;

            Queue<(int, int)> q = new();
            int[,] safe = new int[n, n];

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (grid[i][j] == 1)
                    {
                        safe[i, j] = 0;
                        q.Enqueue((i, j));
                    }
                    else
                    {
                        safe[i, j] = -1;
                    }
                }
            }

            while (q.Count > 0)
            {
                int qLen = q.Count;

                for (int i = 0; i < qLen; ++i)
                {
                    var (r, c) = q.Dequeue();

                    for (int j = 0; j < 4; ++j)
                    {
                        int nR = r + dir[j, 0];
                        int nC = c + dir[j, 1];

                        if (nR < 0 || nR >= n || nC < 0 || nC >= n) continue;

                        if (safe[nR, nC] != -1) continue;

                        q.Enqueue((nR, nC));
                        safe[nR, nC] = safe[r, c] + 1;
                    }
                }
            }

            // Get all the safeness factor values, and ignores 
            // any repeated values
            HashSet<int> hashMaxSF = new();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    hashMaxSF.Add(safe[i, j]);
                }
            }

            // Sort it in decreasing order
            List<int> maxSF = [.. hashMaxSF];
            maxSF.Sort((x, y) => y.CompareTo(x));

            for (int i = 0; i < maxSF.Count; ++i)
            {
                int cur = maxSF[i];
                if (IsSafe(safe, cur))
                {
                    return cur;
                }
            }

            return -1;
        }
    }

    public class Solution_Binary_Search
    {
        readonly int[,] dir = { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } };

        bool IsSafe(int[,] safe, int m)
        {
            int n = safe.GetLength(0);

            if (safe[0, 0] < m || safe[n - 1, n - 1] < m) return false;

            Queue<(int, int)> q = new();
            q.Enqueue((0, 0));
            bool[,] v = new bool[n, n];
            v[0, 0] = true;

            while (q.Count > 0)
            {
                int qLen = q.Count;

                for (int i = 0; i < qLen; ++i)
                {
                    var (r, c) = q.Dequeue();

                    if (r == n - 1 && c == n - 1) return true;

                    for (int j = 0; j < 4; ++j)
                    {
                        int nR = r + dir[j, 0];
                        int nC = c + dir[j, 1];

                        if (nR < 0 || nR >= n || nC < 0 || nC >= n) continue;

                        if (safe[nR, nC] < m) continue;

                        if (v[nR, nC]) continue;

                        q.Enqueue((nR, nC));
                        v[nR, nC] = true;
                    }
                }
            }

            return false;
        }

        public int MaximumSafenessFactor(IList<IList<int>> grid)
        {
            int n = grid.Count;

            Queue<(int, int)> q = new();
            int[,] safe = new int[n, n];

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (grid[i][j] == 1)
                    {
                        safe[i, j] = 0;
                        q.Enqueue((i, j));
                    }
                    else
                    {
                        safe[i, j] = -1;
                    }
                }
            }

            while (q.Count > 0)
            {
                int qLen = q.Count;

                for (int i = 0; i < qLen; ++i)
                {
                    var (r, c) = q.Dequeue();

                    for (int j = 0; j < 4; ++j)
                    {
                        int nR = r + dir[j, 0];
                        int nC = c + dir[j, 1];

                        if (nR < 0 || nR >= n || nC < 0 || nC >= n) continue;

                        if (safe[nR, nC] != -1) continue;

                        q.Enqueue((nR, nC));
                        safe[nR, nC] = safe[r, c] + 1;
                    }
                }
            }

            int _l = 0, _r = 0;
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    _r = Math.Max(_r, safe[i, j]);
                }
            }

            // so that _l != _r
            // and cases like _1 = 0 and _r = 1 with mid = 0 and mid = 1, both get checked
            _r += 1;

            while (_l < _r)
            {
                int m = _l + (_r - _l) / 2;
                if (IsSafe(safe, m))
                {
                    _l = m + 1;
                }
                else
                {
                    _r = m;
                }
            }

            return _l - 1;
        }
    }

    class Solution_PQ_Based
    {
        readonly int[,] dir = { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } };
        public int MaximumSafenessFactor(IList<IList<int>> grid)
        {
            int n = grid.Count;

            Queue<(int, int)> q = new();
            int[,] safe = new int[n, n];

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (grid[i][j] == 1)
                    {
                        safe[i, j] = 0;
                        q.Enqueue((i, j));
                    }
                    else
                    {
                        safe[i, j] = -1;
                    }
                }
            }

            while (q.Count > 0)
            {
                int qLen = q.Count;

                for (int i = 0; i < qLen; ++i)
                {
                    var (r, c) = q.Dequeue();

                    for (int j = 0; j < 4; ++j)
                    {
                        int nR = r + dir[j, 0];
                        int nC = c + dir[j, 1];

                        if (nR < 0 || nR >= n || nC < 0 || nC >= n) continue;

                        if (safe[nR, nC] != -1) continue;

                        q.Enqueue((nR, nC));
                        safe[nR, nC] = safe[r, c] + 1;
                    }
                }
            }

            // priority = -safeness  (negate: .NET PriorityQueue is a min-heap)
            var pq = new PriorityQueue<(int r, int c, int s), int>();
            var visited = new bool[n, n];
            pq.Enqueue((0, 0, safe[0, 0]), -safe[0, 0]);

            while (pq.Count > 0)
            {
                var (r, c, cur) = pq.Dequeue();

                if (visited[r, c]) continue;   // stale duplicate — already finalized

                visited[r, c] = true;

                if (r == n - 1 && c == n - 1) return cur;   // first pop of target is optimal

                for (int i = 0; i < 4; ++i)
                {
                    int nR = r + dir[i, 0], nC = c + dir[i, 1];

                    if (nR < 0 || nC < 0 || nR >= n || nC >= n)
                        continue;

                    if (visited[nR, nC])
                        continue;

                    int nD = Math.Min(cur, safe[nR, nC]);
                    pq.Enqueue((nR, nC, nD), -nD);
                }
            }

            return 0;
        }
    }

    class Execute
    {
        static void Main(string[] args)
        {
            Solution_PQ_Based s = new();
            IList<IList<int>> grid = [[1, 0, 0], [0, 0, 0], [0, 0, 1]];
            grid = [[0, 0, 1], [0, 0, 0], [0, 0, 0]];
            // grid = [[1]];
            // grid = [[0, 1, 1], [0, 0, 1], [1, 0, 0]];

            var output = s.MaximumSafenessFactor(grid);
            Console.WriteLine(output);
        }
    }
}
