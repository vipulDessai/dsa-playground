namespace learning_dsa_csharp._06_linked_list._010_find_the_duplicate_number
{
    internal class Solution
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

            int slow2 = 0;
            while (true)
            {
                slow = nums[slow];
                slow2 = nums[slow2];
                if (slow == slow2)
                {
                    return slow;
                }
            }
        }
    }
}
