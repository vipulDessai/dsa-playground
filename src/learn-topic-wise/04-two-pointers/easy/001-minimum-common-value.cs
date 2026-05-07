namespace learning_dsa_csharp._02_two_pointers._006_minimum_common_value
{
    interface ISolution
    {
        int GetCommon(int[] nums1, int[] nums2);
    }
    internal class MySoln : ISolution
    {
        public int GetCommon(int[] nums1, int[] nums2)
        {
            int m = nums1.Length,
                n = nums2.Length;
            int p1 = 0,
                p2 = 0;

            while (p1 < m && p2 < n)
            {
                if (nums1[p1] == nums2[p2])
                {
                    return nums1[p1];
                }

                if (nums1[p1] > nums2[p2])
                {
                    p2++;
                }
                else
                {
                    p1++;
                }
            }

            return -1;
        }
    }

    internal class Execute
    {
        public static void Main(string[] args)
        {
            ISolution s = new MySoln();

            var input1 = new int[] { 3, 4, 5, 1, 2 };
            var input2 = new int[] { 3, 4, 5, 1, 2 };
            Console.WriteLine(s.GetCommon(input1, input2));

        }
    }
}
