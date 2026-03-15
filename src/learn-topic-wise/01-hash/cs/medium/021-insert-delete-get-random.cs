namespace learning_dsa_csharp._01_strings_arrays_hash._021_insert_delete_get_random
{
    public class RandomizedSet
    {
        Dictionary<int, int> m;
        List<int> l;
        Random r;

        public RandomizedSet()
        {
            m = new Dictionary<int, int>();
            l = new List<int>();
            r = new Random();
        }

        public bool Insert(int val)
        {
            if (!m.ContainsKey(val))
            {
                l.Add(val);
                m.Add(val, l.Count - 1);

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Remove(int val)
        {
            if (m.ContainsKey(val))
            {
                int i = m[val];
                int lastI = l.Count - 1;
                int valLast = l[lastI];

                // move the last item to place we are removing the item
                l[i] = valLast;

                // update dictionary
                m[valLast] = i;

                l.RemoveAt(lastI);
                m.Remove(val);

                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetRandom()
        {
            int lLen = l.Count;
            int rNumI = r.Next(lLen);

            return l[rNumI];
        }
    }
}
