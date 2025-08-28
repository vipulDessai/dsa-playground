namespace learning_dsa_csharp._02_two_pointers
{
    internal class TwoPointers
    {
        public static void Main(string[] args)
        {
            var t = new TwoPointers();

            //t.ThreeSum();

            t.TrapRainWater();

            //t.SquareOfSortedArray();

            //t.BagOfTokens();

            //t.MinimumLengthOfStringAfterDeletingSimilarEnds();

            //t.MinimumCommonValue();
        }

        private void ThreeSum()
        {
            var s = new _001_3_sum.MySoln();

            var inArr = new int[] { -1, 0, 1, 2, -1, -4 };

            var r = s.ThreeSum(inArr);

            Console.WriteLine(r);
        }

        private void TrapRainWater()
        {
            int[] arr = [4, 2, 0, 3, 2, 5];

            var s = new _002_trap_rain_water.OtherSoln_Monotonic_stack();
            var res = s.Trap(arr);

            Console.WriteLine(res);
        }

        private void SquareOfSortedArray()
        {
            var s = new _003_squares_of_a_sorted_array.OthersSoln();
            int[] nums = [-4, -1, 0, 3, 10];
            nums = [-7, -3, 2, 3, 11];
            nums = [0];
            nums = [-1];
            nums = [-10000, -9999, -7, -5, 0, 0, 10000];
            var r = s.SortedSquares(nums);

            for (int i = 0; i < r.Length; ++i)
            {
                Console.WriteLine(r[i]);
            }
        }

        private void BagOfTokens()
        {
            var s = new _004_bag_of_tokens.MySoln();
            int[] tokens = [100];
            tokens = [100, 200, 300, 400];
            int p = 200;
            var r = s.BagOfTokensScore(tokens, p);
            Console.WriteLine(r);
        }

        private void MinimumLengthOfStringAfterDeletingSimilarEnds()
        {
            var s = new _005_minimum_length_of_string_after_deleting_similar_ends.MySoln();

            var inStr = "aabccabba";
            var r = s.MinimumLength(inStr);

            Console.WriteLine(r);
        }

        private void MinimumCommonValue()
        {
            var s = new _006_minimum_common_value.MySoln();

            int[] nums1 = [1, 4, 7, 9, 12, 15];
            int[] nums2 = [0, 2, 8, 10, 15, 20];
            var r = s.GetCommon(nums1, nums2);

            Console.WriteLine(r);
        }

        private void FindDuplicateNumber()
        {
            var s = new _007_find_the_duplicate_number.Soln();
            var arr = new int[] { 1, 3, 4, 2, 2 };
            arr = [1, 2, 3, 3, 4];
            var r = s.FindDuplicate(arr);

            Console.WriteLine(r);
        }
    }
}
