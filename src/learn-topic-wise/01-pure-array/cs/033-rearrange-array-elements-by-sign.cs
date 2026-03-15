namespace learning_dsa_csharp._01_strings_arrays_hash._033_rearrange_array_elements_by_sign;

// looping over the result array and use another loop
// to find track and traverse over the nums array and
// find the positive/negetive number index
internal class MySoln
{
    public int[] RearrangeArray(int[] nums)
    {
        int n = nums.Length;
        int[] res = new int[n];

        int nI = 0,
            pI = 0;
        for (int i = 0; i < n; ++i)
        {
            if (i % 2 == 0)
            {
                // positive
                if (nums[pI] < 0)
                {
                    while (nums[pI] < 0)
                    {
                        ++pI;
                    }
                }
                res[i] = nums[pI];
                ++pI;
            }
            else
            {
                // negetive
                if (nums[nI] > 0)
                {
                    while (nums[nI] > 0)
                    {
                        ++nI;
                    }
                }
                res[i] = nums[nI];
                ++nI;
            }
        }

        return res;
    }
}

// loop over the nums array and simply
internal class OthersSoln
{
    public int[] RearrangeArray(int[] nums)
    {
        int n = nums.Length;
        int pI = 0;
        int nI = 1;
        int[] arr = new int[n];

        for (int i = 0; i < n; i++)
        {
            if (nums[i] < 0)
            {
                arr[nI] = nums[i];
                nI += 2;
            }
            else
            {
                arr[pI] = nums[i];
                pI += 2;
            }
        }
        return arr;
    }
}
