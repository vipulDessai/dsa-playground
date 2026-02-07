namespace learning_dsa_csharp._07_trees._019_all_ancestors_of_a_node_in_a_directed_acyclic_graph
{
    internal class MySoln
    {
        public IList<IList<int>> GetAncestors(int n, int[][] edges)
        {
            List<IList<int>> ans = new List<IList<int>>();
            List<IList<int>> g = new List<IList<int>>();
            for (int i = 0; i < n; i++)
            {
                ans.Add([]);
                g.Add([]);
            }

            // create adjacency list
            foreach (int[] e in edges)
                g[e[0]].Add(e[1]);

            for (int i = 0; i < n; i++)
                dfs(i, i, ans, g);

            return ans;
        }

        private void dfs(int x, int curr, List<IList<int>> ans, List<IList<int>> dc)
        {
            foreach (int ch in dc[curr])
            {
                if (ans[ch].Count == 0 || ans[ch][ans[ch].Count() - 1] != x)
                {
                    ans[ch].Add(x);
                    dfs(x, ch, ans, dc);
                }
            }
        }
    }
}
