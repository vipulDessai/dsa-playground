namespace learning_dsa_csharp._01_strings_arrays_hash._034_least_number_of_unique_integers_after_k_removals;

internal class MySoln
{
    public int FindLeastNumOfUniqueInts(int[] arr, int k)
    {
        int n = arr.Length;
        Dictionary<int, int> m = new Dictionary<int, int>();

        for (int i = 0; i < n; ++i)
        {
            int cur = arr[i];
            if (!m.ContainsKey(cur))
            {
                m[cur] = 0;
            }

            m[cur]++;
        }

        List<(int, int)> c = new List<(int, int)>();
        foreach (var (key, val) in m)
        {
            c.Add((key, val));
        }
        c.Sort(
            (x, y) =>
            {
                var (k1, v1) = x;
                var (k2, v2) = y;

                return v1.CompareTo(v2);
            }
        );

        for (int i = 0; i < c.Count; ++i)
        {
            var (key, val) = c[i];
            if (val > k)
            {
                break;
            }
            else
            {
                k -= val;
                c[i] = (key, 0);
            }
        }

        int res = 0;
        for (int i = 0; i < c.Count; ++i)
        {
            var (key, val) = c[i];
            if (val > 0)
            {
                res++;
            }
        }

        return res;
    }
}
