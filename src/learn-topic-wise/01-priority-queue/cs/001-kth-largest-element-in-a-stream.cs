namespace learning_dsa_csharp._01_strings_arrays_hash._067_kth_largest_element_in_a_stream
{
    internal class OthersSoln_PriorityQueueBased
    {
        PriorityQueue<int, int> q;
        int max = 0;

        public OthersSoln_PriorityQueueBased(int k, int[] nums)
        {
            max = k;
            q = new PriorityQueue<int, int>();
            foreach (var num in nums)
                Add(num);
        }

        public int Add(int val)
        {
            q.Enqueue(val, val);

            if (q.Count > max)
                q.Dequeue();

            return q.Peek();
        }
    }
}
