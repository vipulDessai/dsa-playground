public class Bit32
{
    public static int BitCount(int n)
    {
        int c = 0;
        while (n != 0)
        {
            c++;
            n &= n - 1;
        }

        return c;
    }
}

namespace learning_dsa_csharp._17_bit_manipulation
{
    internal class DS
    {
        public static void Main(string[] args)
        {
            var ds = new DS();

            ds.DecToBin();

            ds.NumberComplement();

            //b.PowerOfTwo();

            // b.FindMissing();

            //b.BitwiseAndNumbersRange();

            //b.FindDuplicateNumber();

            //b.SubarraysWithKDifferentIntegers();

            // b.MinimumOperationsToMakeArrayXOREqualToK();

            //b.SumOfAllSubsetXorTotals();

            //b.CountTripletsThatCanFormTwoArraysOfEqualXor();

            //ds.SingleNumberIII();
        }

        private void DecToBin()
        {
            var s = new _001_dec_to_bin.MySoln();

            int num = 15;
            var r = s.DecToBin(num);

            Console.WriteLine(r);
        }

        private void NumberComplement()
        {
            var s = new _001_number_complement.MySoln();

            int num = 5;
            var r = s.FindComplement(num);

            Console.WriteLine(r);
        }

        private void PowerOfTwo()
        {
            var s = new _001_power_of_2.Others_Soln_Power();
            var r = s.IsPowerOfTwo(88);

            Console.WriteLine(r);
        }

        private void FindMissing()
        {
            var s = new _002_find_missing.Soln();
            var r = s.MissingNumber([3, 2, 1, 5, 0]);

            Console.WriteLine(r);
        }

        private void BitwiseAndNumbersRange()
        {
            var s = new _003_bitwise_and_of_numbers_range.MySoln();
            var r = s.RangeBitwiseAnd(5, 7);

            Console.WriteLine(r);
        }

        private void FindDuplicateNumber()
        {
            var s = new _004_find_the_duplicate_number.MySoln();
            var arr = new int[] { 1, 3, 4, 2, 2 };
            arr = [1, 2, 3, 3, 4];
            var r = s.FindDuplicate(arr);

            Console.WriteLine(r);
        }

        private void SubarraysWithKDifferentIntegers()
        {
            var s = new _005_Shortest_subarray_with_or_at_least_k_ii.OthersSoln();
            int[] input = [1, 2, 12, 22];
            int k = 6;

            input = [1, 2, 3];
            k = 2;

            input = [1, 12, 2, 5];
            k = 43;

            input = [32, 1, 25, 11, 2];
            k = 59;

            input = [11, 25, 1];
            k = 15;

            var r = s.MinimumSubarrayLength(input, k);

            Console.WriteLine(r);
        }

        private void MinimumOperationsToMakeArrayXOREqualToK()
        {
            var s = new _006_minimum_number_of_operations_to_make_array_xor_equal_to_k.OthersSoln();

            int[] input = [2, 1, 3, 4];
            int k = 1;
            var r = s.MinOperations(input, k);

            Console.WriteLine(r);
        }

        private void SumOfAllSubsetXorTotals()
        {
            var s = new _007_sum_of_all_subset_xor_totals.MySoln();

            int[] input = [5, 1, 6];
            var r = s.SubsetXORSum(input);

            Console.WriteLine(r);
        }

        private void CountTripletsThatCanFormTwoArraysOfEqualXor()
        {
            var s = new _008_count_triplets_that_can_form_two_arrays_of_equal_xor.OthersSoln();

            int[] input = [2, 3, 1, 6, 7];
            var r = s.CountTriplets(input);

            Console.WriteLine(r);
        }

        private void SingleNumberIII()
        {
            var s = new _009_single_number_3.OthersSoln();

            int[] input = [1, 2, 1, 3, 2, 5];
            var r = s.SingleNumber(input);

            Console.WriteLine(r);
        }
    }
}
