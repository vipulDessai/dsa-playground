// https://leetcode.com/problems/count-triplets-that-can-form-two-arrays-of-equal-xor
namespace learning_dsa_csharp._17_bit_manipulation._008_count_triplets_that_can_form_two_arrays_of_equal_xor
{
    // https://leetcode.com/problems/count-triplets-that-can-form-two-arrays-of-equal-xor/solutions/623747/java-c-python-one-pass-o-n-4-to-o-n
    internal class OthersSoln
    {
        public int CountTriplets(int[] arr)
        {
            int n = arr.Length,
                res = 0;

            int[] prefix = new int[n + 1];

            for (int i = 1; i < n + 1; ++i)
            {
                prefix[i] = arr[i - 1] ^ prefix[i - 1];
            }

            for (int i = 0; i < n + 1; ++i)
            {
                for (int j = i + 1; j < n + 1; ++j)
                {
                    if (prefix[i] == prefix[j])
                    {
                        res += j - i - 1;
                    }
                }
            }

            return res;
        }
    }
}
