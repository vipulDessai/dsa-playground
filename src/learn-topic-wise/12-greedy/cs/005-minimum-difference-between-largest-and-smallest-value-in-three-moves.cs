// https://leetcode.com/problems/minimum-difference-between-largest-and-smallest-value-in-three-moves
namespace learning_dsa_csharp._15_greedy._005_minimum_difference_between_largest_and_smallest_value_in_three_moves
{
    internal class MySoln
    {
        public int MinDifference(int[] nums)
        {
            if (nums.Length < 5)
                return 0;

            var minH = new MinHeap_from_priority_queue([]);
            var maxH = new MaxHeap_from_priority_queue([]);

            for (int i = 0; i < 4; ++i)
            {
                minH.Add(nums[i]);
                maxH.Add(nums[i]);
            }

            for (int i = 0; i < nums.Length; ++i)
            {
                if (nums[i] > minH.Peek)
                {
                    maxH.Get();
                    minH.Add(nums[i]);
                }

                if (nums[i] < maxH.Peek)
                {
                    maxH.Get();
                    maxH.Add(nums[i]);
                }
            }

            int[] lowest = new int[4];
            int[] highest = new int[4];

            for (int i = 0; i < 4; i++)
            {
                lowest[i] = minH.Get();
                highest[i] = maxH.Get();
            }

            return new int[]
            {
                highest[0] - lowest[3],
                highest[1] - lowest[2],
                highest[2] - lowest[1],
                highest[3] - lowest[0],
            }.Min();
        }
    }

    // https://leetcode.com/problems/minimum-difference-between-largest-and-smallest-value-in-three-moves/solutions/5411994/c-solution-for-minimum-difference-between-largest-and-smallest-value-in-three-moves-problem
    internal class OthersSoln
    {
        public int MinDifference(int[] nums)
        {
            if (nums.Length < 5)
                return 0;

            var minHeap = new PriorityQueue<int, int>();
            var maxHeap = new PriorityQueue<int, int>(
                Comparer<int>.Create((a, b) => b.CompareTo(a))
            );

            // this will make sure there will be always 4 items in the priority queue
            // which the next loop will ensure only the 4 smallest and 4 largest items
            // remain in the priority queue
            for (int i = 0; i < 4; i++)
            {
                minHeap.Enqueue(nums[i], nums[i]);
                maxHeap.Enqueue(nums[i], nums[i]);
            }

            // below loop ensures only 4 items remain in the priority queue
            for (int i = 4; i < nums.Length; i++)
            {
                if (nums[i] > minHeap.Peek())
                {
                    minHeap.Dequeue();
                    minHeap.Enqueue(nums[i], nums[i]);
                }

                if (nums[i] < maxHeap.Peek())
                {
                    maxHeap.Dequeue();
                    maxHeap.Enqueue(nums[i], nums[i]);
                }
            }

            int[] lowest = new int[4];
            int[] highest = new int[4];

            for (int i = 0; i < 4; i++)
            {
                lowest[i] = maxHeap.Dequeue();
                highest[i] = minHeap.Dequeue();
            }

            // We have 4 plans:
            // 1. kill 3 biggest elements
            // 2. kill 2 biggest elements + 1 smallest elements
            // 3. kill 1 biggest elements + 2 smallest elements
            // 4. kill 3 smallest elements
            return new int[]
            {
                highest[0] - lowest[3],
                highest[1] - lowest[2],
                highest[2] - lowest[1],
                highest[3] - lowest[0],
            }.Min();
        }
    }
}
