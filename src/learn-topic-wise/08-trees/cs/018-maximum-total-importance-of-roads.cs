namespace learning_dsa_csharp._07_trees._018_maximum_total_importance_of_roads
{
    internal class MySoln
    {
        public long MaximumImportance(int n, int[][] roads)
        {
            // form the adjacency list to know which cities lead to which other
            // cities
            Dictionary<int, List<int>> g = new();
            for (int i = 0; i < n; ++i)
            {
                g.Add(i, []);
            }
            for (int i = 0; i < roads.Length; ++i)
            {
                int a = roads[i][0];
                int b = roads[i][1];
                g[a].Add(b);
                g[b].Add(a);
            }

            List<(int, int)> deg = new();
            foreach (var (k, v) in g)
            {
                deg.Add((k, v.Count));
            }
            deg.Sort(
                (a, b) =>
                {
                    var (nA, neighboursCountA) = a;
                    var (nB, neighboursCountB) = b;

                    return neighboursCountA.CompareTo(neighboursCountB);
                }
            );

            Dictionary<int, int> citiesRank = new();
            for (int i = 0; i < deg.Count; ++i)
            {
                var (nInd, nC) = deg[i];
                citiesRank.Add(nInd, i + 1);
            }

            int res = 0;
            for (int i = 0; i < roads.Length; ++i)
            {
                var curR = roads[i];

                res += citiesRank[curR[0]] + citiesRank[curR[1]];
            }

            return res;
        }
    }
}
