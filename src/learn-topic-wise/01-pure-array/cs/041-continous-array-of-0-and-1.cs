namespace learning_dsa_csharp._01_strings_arrays_hash._041_continous_array_of_0_and_1
{
    internal class MySoln
    {
        public int FindMaxLength(int[] nums)
        {
            int n = nums.Length;
            for (int i = 0; i < n; ++i)
            {
                if (nums[i] == 0)
                {
                    nums[i] = -1;
                }
            }

            Dictionary<int, int> m = new();

            int res = 0;
            int s = 0;
            for (int i = 0; i < n; ++i)
            {
                s += nums[i];

                if (s == 0)
                {
                    res = i + 1;
                }
                else
                {
                    if (m.ContainsKey(s))
                    {
                        var cur = i - m[s];
                        if (cur > res)
                        {
                            res = cur;
                        }
                    }
                    else
                    {
                        m[s] = i;
                    }
                }
            }

            return res;
        }
    }
}
