namespace learning_dsa_csharp._05_binary_Search
{
    internal class Binary_search
    {
        public static void Main(string[] args)
        {
            var b = new Binary_search();

            // b.GeneralizedBinarySearchTemplate();

            // problem - https://leetcode.com/problems/search-in-rotated-sorted-array/description/
            // solution
            //b.SearchInRotatedSortedArray();

            // problem - https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/description/
            //b.SearchMinimumInRotatedSortedArray();

            // b.CapacityToShipPacakgesWithinDDays();

            //b.SplitArrayLargestSum();

            //b.MinNumberOfDaysToMakeMBouquets();

            b.KokoEatingBananas();
        }

        // https://leetcode.com/problems/minimum-number-of-days-to-make-m-bouquets/solutions/769703/python-clear-explanation-powerful-ultimate-binary-search-template-solved-many-problems
        void GeneralizedBinarySearchTemplate()
        {
            int BinarySearchTemplate(int[] array)
            {
                bool condition(int mid)
                {
                    // perform some check for mid popint in an array
                    return true;
                }

                int l = 0,
                    r = array.Length;
                while (l < r)
                {
                    int mid = l + (r - l) / 2;
                    if (condition(mid))
                    {
                        r = mid;
                    }
                    else
                    {
                        l = mid + 1;
                    }
                }

                return l;
            }

            Console.WriteLine(BinarySearchTemplate([]));
        }

        void SearchInRotatedSortedArray()
        {
            var s = new _001_search_rotatated_sorted_array.Solution();
            var n = new int[] { 4, 5, 6, 7, 0, 1, 2 };
            var t = 3;

            n = new int[] { 1 };
            t = 0;

            n = new int[] { 5, 1, 2, 3, 4 };
            t = 1;

            var res = s.Search(n, t);

            Console.WriteLine(res);
        }

        void SearchMinimumInRotatedSortedArray()
        {
            var s = new _002_min_value_in_rotated_sorted_array.SolutionUsingPivotDirection();
            var n = new int[] { 4, 5, 6, 7, 0, 1, 2 };

            var res = s.FindMin(n);

            Console.WriteLine(res);
        }

        void CapacityToShipPacakgesWithinDDays()
        {
            var s = new _004_capacity_to_ship_packages_within_d_days.OthersSoln();
            int[] weights = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            int days = 5;
            var res = s.ShipWithinDays(weights, days);

            Console.WriteLine(res);
        }

        void SplitArrayLargestSum()
        {
            var s = new _006_split_array_largest_sum.OthersSoln();
            int[] nums = [7, 2, 5, 10, 8];
            int k = 2;

            var res = s.SplitArray(nums, k);

            Console.WriteLine(res);
        }

        void MinNumberOfDaysToMakeMBouquets()
        {
            var s = new _005_minimum_number_of_days_to_make_m_bouquets.OthersSoln();
            int[] bloomDay = [1, 10, 3, 10, 2];
            int m = 3,
                k = 1;
            var res = s.MinDays(bloomDay, m, k);

            Console.WriteLine(res);
        }

        void KokoEatingBananas()
        {
            var s = new _007_koko_eating_bananas.OthersSoln();
            int[] piles = [3, 6, 7, 11];
            int h = 8;
            var res = s.MinEatingSpeed(piles, h);

            Console.WriteLine(res);
        }
    }
}
