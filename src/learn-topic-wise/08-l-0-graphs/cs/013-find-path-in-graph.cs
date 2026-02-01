// https://leetcode.com/problems/find-if-path-exists-in-graph
namespace learning_dsa_csharp._11_graphs._013_find_path_in_graph
{
    internal class MySoln
    {
        public bool ValidPath(int n, int[][] edges, int source, int destination)
        {
            Dictionary<int, List<int>> g = new Dictionary<int, List<int>>();

            // form the graph
            for (int i = 0; i < edges.Length; ++i)
            {
                int[] cur = edges[i];

                if (!g.ContainsKey(cur[0]))
                {
                    g.Add(cur[0], []);
                }
                if (!g.ContainsKey(cur[1]))
                {
                    g.Add(cur[1], []);
                }

                g[cur[0]].Add(cur[1]);
                g[cur[1]].Add(cur[0]);
            }

            HashSet<int> visited = new HashSet<int>();
            bool dfs(int curN)
            {
                if (visited.Contains(curN))
                    return false;

                visited.Add(curN);

                if (curN == destination)
                {
                    return true;
                }
                else
                {
                    if (!g.ContainsKey(curN))
                    {
                        return false;
                    }
                    else
                    {
                        var nList = g[curN];
                        foreach (var item in nList)
                        {
                            if (dfs(item))
                            {
                                return true;
                            }
                        }

                        return false;
                    }
                }
            }

            return dfs(source);
        }
    }

    // https://leetcode.com/problems/find-if-path-exists-in-graph/solutions/1406774/java-4-solutions-union-find-9ms-union-by-rank-14-ms-dfs-88-ms-bfs-90-ms
    class OthersSoln
    {
        public bool ValidPath(int n, int[][] edges, int start, int end)
        {
            DisjointSetUnion_non_rank set = new DisjointSetUnion_non_rank(n);
            foreach (var edge in edges)
            {
                set.union(edge[0], edge[1]);
            }

            return set.areConnected(start, end);
        }
    }

    // https://www.youtube.com/watch?v=aBxjDBC4M1U
    class YouTubeTakeYouForward_Soln
    {
        public bool ValidPath(int n, int[][] edges, int start, int end)
        {
            DisjointSet_size_based set = new DisjointSet_size_based(n);
            foreach (var edge in edges)
            {
                set.UnionByRank(edge[0], edge[1]);
            }

            return set.AreConnected(start, end);
        }
    }
}
