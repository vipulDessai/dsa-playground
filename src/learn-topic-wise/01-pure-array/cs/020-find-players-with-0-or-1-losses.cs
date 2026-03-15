namespace learning_dsa_csharp._01_strings_arrays_hash._020_find_players_with_0_or_1_losses
{
    internal class MyOwnSolution_bruteForce
    {
        public IList<IList<int>> FindWinners(int[][] matches)
        {
            Dictionary<int, int> l = new Dictionary<int, int>();

            int rLen = matches.Length;
            for (int i = 0; i < rLen; ++i)
            {
                var wI = matches[i][0];
                var lI = matches[i][1];

                if (!l.ContainsKey(lI))
                {
                    l[lI] = 0;
                }
                l[lI]++;

                if (!l.ContainsKey(wI))
                {
                    l[wI] = 0;
                }
            }

            List<int> wRes = new List<int>();
            List<int> lRes = new List<int>();
            foreach (var (k, v) in l)
            {
                if (v == 0)
                {
                    wRes.Add(k);
                }

                if (v == 1)
                {
                    lRes.Add(k);
                }
            }

            wRes.Sort((a, b) => a.CompareTo(b));
            lRes.Sort((a, b) => a.CompareTo(b));

            return new List<IList<int>>() { wRes, lRes };
        }
    }

    internal class MyOwnSolution_bruteForce_optimized
    {
        public IList<IList<int>> FindWinners(int[][] matches)
        {
            int[] MAX_PLAYERS_RES = new int[100001];
            Array.Fill(MAX_PLAYERS_RES, -1);

            int rLen = matches.Length;
            for (int i = 0; i < rLen; ++i)
            {
                int wI = matches[i][0];
                int lI = matches[i][1];

                if (MAX_PLAYERS_RES[wI] == -1)
                {
                    MAX_PLAYERS_RES[wI] = 0;
                }

                if (MAX_PLAYERS_RES[lI] == -1)
                {
                    MAX_PLAYERS_RES[lI] = 0;
                }
                MAX_PLAYERS_RES[lI]++;
            }

            List<int> wRes = new List<int>();
            List<int> lRes = new List<int>();

            int n = MAX_PLAYERS_RES.Length;
            for (int i = 0; i < n; ++i)
            {
                if (MAX_PLAYERS_RES[i] == 0)
                {
                    wRes.Add(i);
                }

                if (MAX_PLAYERS_RES[i] == 1)
                {
                    lRes.Add(i);
                }
            }

            return new List<IList<int>>() { wRes, lRes };
        }
    }
}
