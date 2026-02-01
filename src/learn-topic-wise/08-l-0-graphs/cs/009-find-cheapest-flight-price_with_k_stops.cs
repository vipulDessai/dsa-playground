namespace learning_dsa_csharp._11_graphs._009_find_cheapest_flight_price_with_k_stops
{
    internal class OtherSoln_BFS
    {
        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K)
        {
            Dictionary<int, List<(int, int)>> map = new Dictionary<int, List<(int, int)>>();
            foreach (var f in flights)
            {
                if (!map.ContainsKey(f[0]))
                    map[f[0]] = [];

                map[f[0]].Add((f[1], f[2]));
            }

            int l = -1;
            int mP = int.MaxValue;
            Queue<(int, int)> q = new();
            q.Enqueue((src, 0));

            // since we have to stop if the stops are more than K
            // we add to BFS level order traversal check only
            while (q.Count > 0 && l <= K)
            {
                int size = q.Count();
                for (int i = 0; i < size; i++)
                {
                    var (d, p) = q.Dequeue();
                    if (d == dst)
                        mP = Math.Min(mP, p);

                    if (!map.ContainsKey(d))
                        continue;

                    for (int j = 0; j < map[d].Count; ++j)
                    {
                        var (nxtD, nxtP) = map[d][j];
                        if (p + nxtP > mP) // Pruning
                            continue;
                        q.Enqueue((nxtD, p + nxtP));
                    }
                }

                l++;
            }

            return mP == int.MaxValue ? -1 : mP;
        }
    }

    public class Soln_bellman_ford
    {
        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
        {
            var distance = new int[n];
            var res = Int32.MaxValue;

            Array.Fill(distance, Int32.MaxValue);

            distance[src] = 0;
            for (var i = 0; i <= k; i++)
            {
                var cur = new int[n];
                Array.Fill(cur, Int32.MaxValue);

                foreach (var flight in flights)
                {
                    int from = flight[0],
                        to = flight[1],
                        cost = flight[2];

                    if (distance[from] == Int32.MaxValue)
                        continue;

                    cur[to] = Math.Min(cur[to], distance[from] + cost);
                }

                distance = cur;
                res = Math.Min(res, distance[dst]);
            }

            return res == Int32.MaxValue ? -1 : res;
        }
    }
}
