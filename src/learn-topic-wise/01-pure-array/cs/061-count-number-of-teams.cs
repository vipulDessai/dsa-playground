namespace learning_dsa_csharp._01_strings_arrays_hash._061_count_number_of_teams
{
    // https://leetcode.com/problems/count-number-of-teams/solutions/554795/c-java-o-n-n-and-o-n-log-n
    internal class OthersSoln
    {
        public int NumTeams(int[] rating)
        {
            int res = 0;
            for (int i = 1; i < rating.Length - 1; ++i)
            {
                int[] less = new int[2],
                    greater = new int[2];
                for (int j = 0; j < rating.Length; ++j)
                {
                    if (rating[i] < rating[j])
                        ++less[j > i ? 1 : 0];
                    if (rating[i] > rating[j])
                        ++greater[j > i ? 1 : 0];
                }
                res += less[0] * greater[1] + greater[0] * less[1];
            }

            return res;
        }
    }

    // TODO - implement BST solution - https://leetcode.com/problems/count-number-of-teams/solutions/554795/c-java-o-n-n-and-o-n-log-n
    internal class OthersSoln_BST
    {
        public int NumTeams(int[] rating)
        {
            return 0;
        }
    }
}
