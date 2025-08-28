namespace learning_dsa_csharp._02_two_pointers._007_find_the_duplicate_number
{
    internal class Soln
    {
        public int FindDuplicate(int[] nums)
        {
            int slow = 0,
                fast = 0;

            while (true)
            {
                slow = nums[slow];
                fast = nums[nums[fast]];

                if (slow == fast)
                {
                    break;
                }
            }

            fast = 0;
            while (true)
            {
                slow = nums[slow];
                fast = nums[fast];
                if (slow == fast)
                {
                    return slow;
                }
            }
        }
    }
}
