namespace learning_dsa_csharp._14_2_d_dynamic_programming
{
    internal class DS
    {
        public static void Main(string[] args)
        {
            var ds = new DS();

            // 001 longest common subsequence
            //d.LongestCommonSubsequence();

            // 002 Best Time to Buy and Sell Stock with Cooldown
            // d.BestTimeBuySellStockWithCooldown();

            // Palindrome Partitioning IV
            // leetcode - https://leetcode.com/problems/palindrome-partitioning-iv/description/
            // solution - https://leetcode.com/problems/palindrome-partitioning-iv/solutions/1043180/java-python-bottom-up-dp-clean-concise-o-n-2/
            // d.PalidromicPartioningIV();

            // Longest Increasing Path in a Matrix
            // leetcode - https://leetcode.com/problems/longest-increasing-path-in-a-matrix/
            // solution - https://www.youtube.com/watch?v=wCc_nd-GiEc
            // d.LongestIncreasingPathMatrix();

            // Burst Balloons
            // leetcode - https://leetcode.com/problems/burst-balloons/
            // solution - https://www.youtube.com/watch?v=VFskby7lUbw
            //d.BurstBalloons();

            // leetcode link - https://leetcode.com/problems/distinct-subsequences/
            // d.DistinctSubsequences();

            // 1000. Minimum Cost to Merge Stones
            // leetcode link - https://leetcode.com/problems/minimum-cost-to-merge-stones/description/
            // solution - own
            //d.MinimumCostToMergeStones();

            //d.OutOfBoundaryPaths();

            //d.CherryPickupII();

            //d.ValidParenthesisString();

            ds.MaxNumOfPointsWithCost();
        }

        private void LongestCommonSubsequence()
        {
            //var s = new _001_longest_common_subsequence.Solution_Others_Brute_to_Bottoms_Up();
            var s = new _001_longest_common_subsequence.MySoln_Bottoms_up();

            Console.WriteLine(s.LongestCommonSubsequence("aece", "ace"));
        }

        private void BestTimeBuySellStockWithCooldown()
        {
            // 002 Best Time to Buy and Sell Stock with Cooldown
            var s = new _002_best_time_buy_sell_with_cooldown.Solution();

            int[] prices = new int[] { 1, 2, 3, 0, 2 };

            Console.WriteLine(s.MaxProfit(prices).ToString());
        }

        private void PalidromicPartioningIV()
        {
            var s = new _004_palindromic_partitioning_iv.Solution();
            var result = s.CheckPartitioning("abbc");

            Console.WriteLine(result);
        }

        private void LongestIncreasingPathMatrix()
        {
            var s = new _005_longest_increasing_path_in_a_matrix.Solution();

            int[][] matrix = new int[3][];
            matrix[0] = new int[3] { 9, 9, 4 };
            matrix[1] = new int[3] { 6, 6, 8 };
            matrix[2] = new int[3] { 2, 1, 1 };

            int max = s.LongestIncreasingPath(matrix);
            Console.WriteLine(max);
        }

        private void BurstBalloons()
        {
            var s = new _006_burst_balloons.Solution();

            int[] nums = new[] { 3, 1, 5 };
            Console.WriteLine(s.MaxCoins(nums));

            Console.WriteLine(s.MaxCoins_BottomUp(nums));
        }

        private void DistinctSubsequences()
        {
            var s = new _007_distinct_subsequences.Solution();
            //var res = s.NumDistinct("babgbag", "bag");
            var res = s.NumDistinct("rbbbt", "rbbt");
            //var res = s.NumDistinct("ccc", "c");
            //var res = s.NumDistinct("raaaab", "aa");
            //var res = s.NumDistinct("a", "c");
            //var res = s.NumDistinct("adbdadeecadeadeccaeaabdabdbcdabddddabcaaadbabaaedeeddeaeebcdeabcaaaeeaeeabcddcebddebeebedaecccbdcbcedbdaeaedcdebeecdaaedaacadbdccabddaddacdddc", "bcddceeeebecbc");
            //var res = s.NumDistinct("aaarbtaaarb", "rbt");

            Console.WriteLine(res);
        }

        private void MinimumCostToMergeStones()
        {
            var arr = new int[] { 3, 2, 4, 1 };
            var k = 2;

            //arr = new int[] { 3, 2, 4, 1 };
            //k = 3;

            //arr = new int[] { 3, 5, 1, 2, 6 };
            //k = 3;

            //arr = new int[] { 69, 39, 79, 78, 16, 6, 36, 97, 79, 27, 14, 31, 4 };
            //k = 2;

            arr = new int[] { 9, 8, 3, 2 };
            k = 2;

            arr = new int[] { 6, 4, 9, 3, 1 };
            k = 3;

            var s = new _009_min_cost_merge_stones.Solution();
            var res = s.MergeStones_Top_down_solution_2(arr, k);

            Console.WriteLine(res);
        }

        private void OutOfBoundaryPaths()
        {
            var s = new _010_out_of_boundary_path.MySoln();

            var r = s.FindPaths(3, 3, 1, 1, 1); // output should be 0 ? HOW?

            Console.WriteLine(r);
        }

        private void CherryPickupII()
        {
            var s = new _011_cherry_pick_2.MySoln();

            var inGrid = new int[][] { [3, 1, 1], [2, 5, 1], [1, 5, 5], [2, 1, 1] };
            var r = s.CherryPickup(inGrid);

            Console.WriteLine(r);
        }

        private void ValidParenthesisString()
        {
            var s = new _012_valid_parenthesis_string.OthersSoln_dp_tabulation();
            var inStr =
                "((((()(()()()*()(((((*)()*(**(())))))(())()())(((())())())))))))(((((())*)))()))(()((*()*(*)))(*)()";
            var r = s.CheckValidString(inStr);

            Console.WriteLine(r);
        }

        private void MaxNumOfPointsWithCost()
        {
            var s = new _013_maximum_number_of_points_with_cost.OthersSoln();
            int[][] points =
            [
                [1, 2, 3],
                [1, 5, 1],
                [3, 1, 1]
            ];
            var r = s.MaxPoints(points);

            Console.WriteLine(r);
        }
    }
}
