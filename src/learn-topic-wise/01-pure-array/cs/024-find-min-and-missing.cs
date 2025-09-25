namespace learning_dsa_csharp._01_strings_arrays_hash._024_find_min_and_missing
{
    // https://leetcode.com/problems/set-mismatch/description
    internal class MySoln
    {
        public int[] FindErrorNums(int[] nums)
        {
            int n = nums.Length;
            int[] res = new int[2];

            HashSet<int> m = new HashSet<int>();
            for (int i = 0; i < n; ++i)
            {
                if (m.Contains(nums[i]))
                {
                    res[0] = nums[i];
                }
                else
                {
                    m.Add(nums[i]);
                }
            }

            for (int i = 1; i < n + 1; ++i)
            {
                if (!m.Contains(i))
                {
                    res[1] = i;
                    break;
                }
            }

            return res;
        }
    }

    internal class SumSet_Using_Formula
    {
        public int[] FindErrorNums(int[] nums)
        {
            int n = nums.Length;
            int expectedSum = n * (n + 1) / 2;
            int actualSum = 0;
            int uniqueSum = 0;
            HashSet<int> s = new HashSet<int>();

            for (int i = 0; i < n; ++i)
            {
                actualSum += nums[i];
                s.Add(nums[i]);
            }

            foreach (var item in s)
            {
                uniqueSum += item;
            }

            // duplicate, missing
            return new int[] { actualSum - uniqueSum, expectedSum - uniqueSum };
        }
    }

    internal class Soln_pure_XOR_bit_manipulation
    {
        public int[] FindErrorNums(int[] nums)
        {
            int n = nums.Length;
            int xorExpected = 0;
            int xorActual = 0;

            for (int i = 1; i <= n; i++)
            {
                xorExpected ^= i;
            }

            foreach (int num in nums)
            {
                xorActual ^= num;
            }

            int xorResult = xorExpected ^ xorActual;

            int rightmostSetBit = xorResult & -xorResult;

            int xorSet = 0;
            int xorNotSet = 0;

            for (int i = 1; i <= n; i++)
            {
                if ((i & rightmostSetBit) != 0)
                {
                    xorSet ^= i;
                }
                else
                {
                    xorNotSet ^= i;
                }
            }

            foreach (int num in nums)
            {
                if ((num & rightmostSetBit) != 0)
                {
                    xorSet ^= num;
                }
                else
                {
                    xorNotSet ^= num;
                }
            }

            foreach (int num in nums)
            {
                if (num == xorSet)
                {
                    return [xorSet, xorNotSet];
                }
            }

            // duplicate, missing
            return [xorNotSet, xorSet];
        }
    }

    internal class Find_missing_using_XOR_and_duplicate_using_SET
    {
        public int[] FindErrorNums(int[] nums)
        {
            int n = nums.Length;

            int[] count = new int[n];

            var answers = new int[] { 0, 0 };

            int xorSum = 0;
            for (int i = 0; i < n; i++)
            {
                var current = nums[i];

                xorSum ^= (i + 1) ^ current;

                count[current - 1]++;

                if (count[current - 1] == 2)
                    answers[0] = current;
            }

            xorSum ^= answers[0];

            answers[1] = xorSum;

            return answers;
        }
    }
}
