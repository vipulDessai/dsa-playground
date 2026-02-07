namespace learning_dsa_csharp._07_trees._017_find_center_of_star_graph
{
    internal class OthersSoln
    {
        public int FindCenter(int[][] edges)
        {
            int n = edges.Length;
            Dictionary<int, int> g = new Dictionary<int, int>();
            for (int i = 0; i < n; ++i)
            {
                var e = edges[i];
                if (!g.ContainsKey(e[0]))
                {
                    g.Add(e[0], 0);
                }
                ++g[e[0]];

                if (!g.ContainsKey(e[1]))
                {
                    g.Add(e[1], 0);
                }
                ++g[e[1]];
            }

            foreach (var (k, v) in g)
            {
                if (v == n)
                {
                    return k;
                }
            }

            return -1;
        }
    }
}
