// https://leetcode.com/problems/partition-labels/
namespace learning_dsa_csharp._15_greedy._001_partition_labels
{
    internal class SolutionMyOwn
    {
        public IList<int> PartitionLabels(string s)
        {
            int n = s.Length;

            (int, int)[] cUnion = new (int, int)[26];
            Array.Fill(cUnion, (-1, -1));

            for (int i = 0; i < n; ++i)
            {
                int cI = s[i] - 'a';
                var (sC, eC) = cUnion[cI];
                if (sC == -1)
                {
                    cUnion[cI] = (i, i);
                }
                else
                {
                    cUnion[cI] = (sC, i);
                }
            }

            IList<int> getPartitions(char c)
            {
                var (sC, eC) = cUnion[c - 'a'];

                int cLastI = eC;
                int i = sC;
                while (i < cLastI)
                {
                    char cur = s[i];
                    var (sI, eI) = cUnion[cur - 'a'];

                    if (eI > cLastI)
                    {
                        cLastI = eI;
                    }

                    ++i;
                }

                if (cLastI == n - 1)
                {
                    return new List<int>() { cLastI + 1 - sC };
                }
                else
                {
                    var _r = getPartitions(s[cLastI + 1]);
                    var _rList = new List<int>() { cLastI + 1 - sC };

                    for (int j = 0; j < _r.Count; ++j)
                    {
                        _rList.Add(_r[j]);
                    }

                    return _rList;
                }
            }

            return getPartitions(s[0]);
        }
    }
}
