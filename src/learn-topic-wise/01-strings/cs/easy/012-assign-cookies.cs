using System.Collections.Generic;

namespace learning_dsa_csharp._01_strings_arrays_hash._012_assign_cookies
{
    internal class Solution
    {
        public int FindContentChildren(int[] g, int[] s)
        {
            if (s.Length == 0)
                return 0;

            int[] sortArray(int[] inputArray)
            {
                List<int> sorted = new List<int>();
                for (int i = 0; i < inputArray.Length; i++)
                {
                    sorted.Add(inputArray[i]);
                }

                sorted.Sort((a, b) => a.CompareTo(b));

                int[] res = new int[sorted.Count];
                for (int i = 0; i < sorted.Count; i++)
                {
                    res[i] = sorted[i];
                }

                return res;
            }

            var gSorted = sortArray(g);
            var sSorted = sortArray(s);

            int c = 0;
            int sI = 0,
                gI = 0;
            while (sI < sSorted.Length && gI < gSorted.Length)
            {
                if (sSorted[sI] >= gSorted[gI])
                {
                    c++;
                    gI++;
                }

                sI++;
            }

            return c;
        }
    }
}
