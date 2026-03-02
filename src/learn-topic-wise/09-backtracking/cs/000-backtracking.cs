namespace learning_dsa_csharp._10_backtracking
{
    class Backtracking
    {
        public static void Main(string[] args)
        {
            var b = new Backtracking();

            // b.Permutations();

            // b.PalindromicPartitioning();

            //b.NQueens();

            //b.IncremovableSubarrayCount();

            // b.NumberOfBeautifulSubsets();

            // b.MaximumScoreWordsFormedByLetters();

            b.CombinationSumII();
        }

        private void Permutations()
        {
            var s = new _003_permutations.Solution();
            var res = s.Permute(new List<int>() { 1, 2, 3 });

            Console.WriteLine(res);
        }

        private void PalindromicPartitioning()
        {
            var s = new _004_palindromic_partitioning.MySoln();
            var inStr = "aab";
            var r = s.Partition(inStr);

            Console.WriteLine(r);
        }

        private void NQueens()
        {
            var s = new _009_n_queens.Solution();
            var res = s.SolveNQueens(4);

            for (int i = 0; i < res.Count; ++i)
            {
                var combination = res[i];
                for (int j = 0; j < combination.Count; ++j)
                {
                    Console.WriteLine(combination[j]);
                }

                Console.WriteLine();
            }
        }

        private void IncremovableSubarrayCount()
        {
            var s = new _010_incremovable_subarray_count_i.Solution();
            var r = s.IncremovableSubarrayCount(new int[] { 1, 2, 3 });

            Console.WriteLine(r);
        }

        private void NumberOfBeautifulSubsets()
        {
            var s = new _011_number_of_beautiful_subset.MySoln_optimized();

            int[] arrIn = [2, 4, 6];
            arrIn = [10, 4, 5, 7, 2, 1];
            int k = 2;
            k = 3;
            var r = s.BeautifulSubsets(arrIn, k);

            Console.WriteLine(r);
        }

        private void MaximumScoreWordsFormedByLetters()
        {
            var s = new _012_maximum_scrore_words_formed_by_letters.MySoln();

            string[] words = ["dog", "cat", "dad", "good"];
            char[] letters = ['a', 'a', 'c', 'd', 'd', 'd', 'g', 'o', 'o'];
            int[] score =
            [
                1,
                0,
                9,
                5,
                0,
                0,
                3,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                2,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0
            ];
            var r = s.MaxScoreWords(words, letters, score);

            Console.WriteLine(r);
        }

        private void CombinationSumII()
        {
            var s = new _005_combination_sum_ii.MySoln();

            int[] candidates = [10, 1, 2, 7, 6, 1, 5];
            int t = 8;
            var r = s.CombinationSum2(candidates, t);

            Console.WriteLine(r);
        }
    }
}
