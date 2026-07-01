// [Find the Safest Path in a Grid](https://leetcode.com/problems/find-the-safest-path-in-a-grid/)
namespace learning_dsa_csharp._11_graphs._017_find_a_safest_path_in_a_grid
{
    internal class OtherSoln_Heap_Based
    {
        int[][] dir =
        [
            [0, 1],
            [0, -1],
            [1, 0],
            [-1, 0]
        ];

        public int MaximumSafenessFactor(IList<IList<int>> grid)
        {
            int n = grid.Count;
            int[,] mat = new int[n, n];
            Queue<int[]> multiSourceQueue = new Queue<int[]>();

            // To make modifications and navigation easier, the grid is converted into a 2-d array.
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        // Push thief coordinates to the queue
                        multiSourceQueue.Enqueue([i, j]);
                        // Mark thief cell with 0
                        mat[i, j] = 0;
                    }
                    else
                    {
                        // Mark empty cell with -1
                        mat[i, j] = -1;
                    }
                }
            }

            // Calculate safeness factor for each cell using BFS
            while (multiSourceQueue.Count > 0)
            {
                int size = multiSourceQueue.Count;
                while (size-- > 0)
                {
                    int[] cur = multiSourceQueue.Dequeue();
                    // Check neighboring cells
                    foreach (var d in dir)
                    {
                        int di = cur[0] + d[0];
                        int dj = cur[1] + d[1];
                        int val = mat[cur[0], cur[1]];
                        // Check if the neighboring cell is valid and unvisited
                        if (IsValidCell(mat, di, dj) && mat[di, dj] == -1)
                        {
                            // Update safeness factor and push to the queue
                            mat[di, dj] = val + 1;
                            multiSourceQueue.Enqueue([di, dj]);
                        }
                    }
                }
            }

            // Get all the safeness factor values
            HashSet<int> hashMaxSF = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    hashMaxSF.Add(mat[i, j]);
                }
            }

            // Sort it in decreasing order
            List<int> maxSF = hashMaxSF.ToList();
            maxSF.Sort((x, y) => y.CompareTo(x));

            for (int i = 0; i < maxSF.Count; ++i)
            {
                int cur = maxSF[i];
                if (IsValidSafeness(mat, cur))
                {
                    return cur;
                }
            }

            return -1;
        }

        // Check if a path exists with given minimum safeness value
        private bool IsValidSafeness(int[,] grid, int minSafeness)
        {
            int n = grid.GetLength(0);

            // Check if the source and destination cells satisfy minimum safeness
            if (grid[0, 0] < minSafeness || grid[n - 1, n - 1] < minSafeness)
            {
                return false;
            }

            Queue<int[]> traversalQueue = new Queue<int[]>();
            traversalQueue.Enqueue([0, 0]);
            bool[,] visited = new bool[n, n];
            visited[0, 0] = true;

            // Breadth-first search to find a valid path
            while (traversalQueue.Count > 0)
            {
                int[] cur = traversalQueue.Dequeue();
                if (cur[0] == n - 1 && cur[1] == n - 1)
                {
                    return true; // Valid path found
                }
                // Check neighboring cells
                foreach (var d in dir)
                {
                    int di = cur[0] + d[0];
                    int dj = cur[1] + d[1];
                    // Check if the neighboring cell is valid, unvisited and satisfying minimum safeness
                    if (
                        IsValidCell(grid, di, dj)
                        && !visited[di, dj]
                        && grid[di, dj] >= minSafeness
                    )
                    {
                        visited[di, dj] = true;
                        traversalQueue.Enqueue([di, dj]);
                    }
                }
            }

            return false; // No valid path found
        }

        // Check if a given cell lies within the grid
        private bool IsValidCell(int[,] mat, int i, int j)
        {
            int n = mat.GetLength(0);
            return i >= 0 && j >= 0 && i < n && j < n;
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

    class Execute
    {
        static void Main(string[] args)
        {
            Solution_Binary_Search s = new();
            IList<IList<int>> grid = [[1, 0, 0], [0, 0, 0], [0, 0, 1]];
            grid = [[0, 0, 1], [0, 0, 0], [0, 0, 0]];
            grid = [[1]];
            grid = [[0, 1, 1], [0, 0, 1], [1, 0, 0]];

            var output = s.MaximumSafenessFactor(grid);
            Console.WriteLine(output);
        }
    }
}
