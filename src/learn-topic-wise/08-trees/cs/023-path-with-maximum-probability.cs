// https://leetcode.com/problems/path-with-maximum-probability/
namespace learning_dsa_csharp._07_trees._023_path_with_maximum_probability
{
    internal class MySoln
    {
        public double MaxProbability(
            int n,
            int[][] edges,
            double[] succProb,
            int start_node,
            int end_node
        )
        {
            int[] visited = new int[n];
            double[] maxProb = new double[n];
            Array.Fill(visited, -1);
            Array.Fill(maxProb, double.MinValue);

            Dictionary<int, List<(int nd, double prob)>> adList =
                new Dictionary<int, List<(int nd, double prob)>>();

            for (int i = 0; i < n; ++i)
            {
                adList.Add(i, []);
            }

            for (int i = 0; i < edges.Length; ++i)
            {
                int src = edges[i][0];
                int dst = edges[i][1];

                adList[src].Add((dst, succProb[i]));
                adList[dst].Add((src, succProb[i]));
            }

            PriorityQueue<(int nd, double prob)> q = new PriorityQueue<(int node, double w)>();
            q.compare = (x, y) => y.prob.CompareTo(x.prob);

            q.Enqueue((start_node, 1));
            maxProb[start_node] = 1;

            while (q.Count > 0)
            {
                var (nd, prob) = q.Dequeue();
                visited[nd] = 1;

                foreach (var (nxtNd, nxtProb) in adList[nd])
                {
                    if (visited[nxtNd] == 1)
                        continue;

                    // since we are trying to find the max prob
                    // in case the next node max probability is less
                    // only then we should update its max probability
                    if (maxProb[nxtNd] < maxProb[nd] * nxtProb)
                    {
                        maxProb[nxtNd] = maxProb[nd] * nxtProb;
                        q.Enqueue((nxtNd, maxProb[nxtNd]));
                    }
                }
            }

            return maxProb[end_node] != double.MinValue ? maxProb[end_node] : 0;
        }
    }
}
