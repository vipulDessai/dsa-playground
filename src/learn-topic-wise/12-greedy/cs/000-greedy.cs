namespace learning_dsa_csharp._15_greedy
{
    internal class DS
    {
        public static void Main(string[] args)
        {
            var ds = new DS();

            // ds.PartitionLabels();

            // ds.MinMoveSeatEveryone();

            // ds.MostProfitAssigningWork();

            //ds.MinDiffBtwLargestAndSmallestValueIn3Moves();

            ds.LemonadeChange();
        }

        private void PartitionLabels()
        {
            var s = new _001_partition_labels.SolutionMyOwn();

            string inStr = "ababcbacadefegdehijhklij";
            inStr = "ababcbacadefegdehijhklij";
            inStr = "caedbdedda";

            var r = s.PartitionLabels(inStr);

            Console.WriteLine(r);
        }

        private void MinMoveSeatEveryone()
        {
            var s = new _002_min_no_of_moves_to_seat_everyone.MySoln();

            int[] seats = [3, 1, 5],
                students = [2, 7, 4];

            var r = s.MinMovesToSeat(seats, students);

            Console.WriteLine(r);
        }

        private void MostProfitAssigningWork()
        {
            var s = new _004_most_profit_assigning_work.MySoln();

            int[] difficulty = [2, 4, 6, 8, 10],
                profit = [10, 20, 30, 40, 50],
                worker = [4, 5, 6, 7];

            difficulty = [13, 37, 58];
            profit = [4, 90, 96];
            worker = [34, 73, 45];

            var r = s.MaxProfitAssignment(difficulty, profit, worker);

            Console.WriteLine(r);
        }

        private void MinDiffBtwLargestAndSmallestValueIn3Moves()
        {
            var s =
                new _005_minimum_difference_between_largest_and_smallest_value_in_three_moves.OthersSoln();

            int[] nums = [5, 3, 2, 4];
            nums = [6, 6, 0, 1, 1, 4, 6];
            var r = s.MinDifference(nums);

            Console.WriteLine(r);
        }

        private void LemonadeChange()
        {
            var s = new _006_lemonade_change.OthersSoln();

            int[] nums = [5, 5, 5, 10, 20];
            var r = s.LemonadeChange(nums);

            Console.WriteLine(r);
        }
    }
}
