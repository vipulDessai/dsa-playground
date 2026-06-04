// https://leetcode.com/problems/sort-array-by-increasing-frequency/
namespace learning_dsa_csharp._058_sort_array_by_increasing_frequency
{
    internal class MySoln
    {
        public int[] FrequencySort(int[] nums)
        {
            int n = nums.Length;
            Dictionary<int, int> freqD = new Dictionary<int, int>();

            for (int i = 0; i < n; ++i)
            {
                if (!freqD.ContainsKey(nums[i]))
                {
                    freqD.Add(nums[i], 0);
                }

                freqD[nums[i]]++;
            }

            (int Num, int Count)[] freq = new (int, int)[freqD.Count];
            int freqDCount = 0;
            foreach (var (key, val) in freqD)
            {
                freq[freqDCount++] = (key, val);
            }

            Array.Sort(
                freq,
                (a, b) =>
                {
                    return a.Count.CompareTo(b.Count);
                }
            );

            int freqL = 0,
                freqR = 0;
            var curFreqGrp = new List<(int Num, int Count)>();
            // TODO need to figure out grouping of array
            while (freqR < freq.Length)
            {
                curFreqGrp.Add((freq[freqR].Num, freq[freqR].Count));

                if (freq[freqL].Count != freq[freqR].Count)
                {
                    curFreqGrp.Sort(
                        (a, b) =>
                        {
                            return b.Num.CompareTo(a.Num);
                        }
                    );

                    int startI = freqL;
                    int endI = freqR - 1;
                    int grpInd = 0;
                    for (int j = startI; j < endI; ++j)
                    {
                        freq[j] = (curFreqGrp[grpInd].Num, curFreqGrp[grpInd].Count);
                        grpInd++;
                    }

                    curFreqGrp.Clear();
                }

                freqR++;
            }

            int[] res = new int[n];
            int k = 0;
            for (int i = 0; i < freq.Length; ++i)
            {
                int curC = freq[i].Count;
                if (curC > 0)
                {
                    for (int j = 0; j < curC; ++j)
                    {
                        res[k++] = freq[i].Num;
                    }
                }
            }

            return res;
        }
    }
}
