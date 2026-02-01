namespace learning_dsa_csharp._11_graphs._015_minimum_height_trees
{
    // https://leetcode.com/problems/minimum-height-trees/solutions/1631179/c-python-3-simple-solution-w-explanation-brute-force-2x-dfs-remove-leaves-w-bfs
    internal class OthersSoln_brute
    {
        public IList<int> FindMinHeightTrees(int n, int[][] edges)
        {
            if (edges.Length == 0)
                return [0];

            Dictionary<int, List<int>> g = new Dictionary<int, List<int>>();
            HashSet<int> visited = new HashSet<int>();

            // form the adjacency list
            for (int i = 0; i < edges.Length; ++i)
            {
                var e = edges[i];
                if (!g.ContainsKey(e[0]))
                {
                    g.Add(e[0], []);
                }
                g[e[0]].Add(e[1]);

                if (!g.ContainsKey(e[1]))
                {
                    g.Add(e[1], []);
                }
                g[e[1]].Add(e[0]);
            }

            int dfs(int i)
            {
                visited.Add(i);
                int c = 0;
                foreach (var adj in g[i])
                {
                    if (!visited.Contains(adj))
                        c = Math.Max(c, 1 + dfs(adj));
                }
                visited.Remove(i);
                return c;
            }

            List<int> ans = new();
            int mH = 0;
            foreach (var (key, value) in g)
            {
                var p = dfs(key);

                if (p < mH)
                {
                    ans.Clear();
                    mH = p;
                }

                if (p == mH)
                    ans.Add(p);
            }

            return ans.ToArray();
        }
    }

    internal class OthersSoln_2x_dfs
    {
        // 2x dfs
        public IList<int> FindMinHeightTrees(int n, int[][] edges)
        {
            if (edges.Length == 0)
                return [0];

            Dictionary<int, List<int>> g = new Dictionary<int, List<int>>();
            HashSet<int> visited = new HashSet<int>();

            for (int i = 0; i < edges.Length; ++i)
            {
                var e = edges[i];
                if (!g.ContainsKey(e[0]))
                {
                    g.Add(e[0], []);
                }
                g[e[0]].Add(e[1]);

                if (!g.ContainsKey(e[1]))
                {
                    g.Add(e[1], []);
                }
                g[e[1]].Add(e[0]);
            }

            List<int> dfs(int i)
            {
                List<int> lP = [];
                visited.Add(i);

                foreach (var adj in g[i])
                {
                    if (!visited.Contains(adj))
                    {
                        List<int> p = dfs(adj);
                        if (p.Count > lP.Count)
                        {
                            lP = p;
                        }
                    }
                }

                visited.Remove(i);
                lP.Add(i);

                return lP;
            }

            var baseP = dfs(0);
            var res = dfs(baseP[0]);

            // for handling odd even answer
            var r = new HashSet<int>([res[res.Count / 2], res[(res.Count - 1) / 2]]);
            return r.ToArray();
        }
    }

    internal class OthersSoln_remove_leaf_nodes
    {
        public IList<int> FindMinHeightTrees(int n, int[][] edges)
        {
            if (edges.Length == 0)
                return [0];

            // form the adjacency list
            Dictionary<int, List<int>> g = new Dictionary<int, List<int>>();
            for (int i = 0; i < edges.Length; ++i)
            {
                var e = edges[i];
                if (!g.ContainsKey(e[0]))
                {
                    g.Add(e[0], []);
                }
                g[e[0]].Add(e[1]);

                if (!g.ContainsKey(e[1]))
                {
                    g.Add(e[1], []);
                }
                g[e[1]].Add(e[0]);
            }

            List<int> leafs = new List<int>();
            List<int> inDeg = new List<int>();
            for (int i = 0; i < n; ++i)
            {
                if (g[i].Count == 1)
                    leafs.Add(i);

                inDeg.Add(g[i].Count);
            }

            while (n > 2)
            {
                List<int> nL = new List<int>();
                foreach (var l in leafs)
                {
                    foreach (var adj in g[l])
                    {
                        if (--inDeg[adj] == 1)
                        {
                            nL.Add(adj);
                        }
                    }
                }

                n -= leafs.Count;
                leafs = nL.ToList();
            }

            return leafs;
        }
    }
}
