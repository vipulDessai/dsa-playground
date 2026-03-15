namespace learning_dsa_csharp._01_strings_arrays_hash._023_minimize_array_using_mod_operation
{
    internal class MyOwnSoln
    {
        public int MinimumArrayLength(int[] nums)
        {
            List<int> nList = nums.ToList();

            while (true)
            {
                int i1 = -1,
                    i2 = -1;
                for (int i = 0; i < nList.Count; i++)
                {
                    bool stop = false;
                    for (int j = i + 1; j < nList.Count; j++)
                    {
                        if (nList[j] != 0 && nList[i] % nList[j] != 0)
                        {
                            i1 = i;
                            i2 = j;

                            stop = true;
                            break;
                        }
                    }

                    if (stop)
                    {
                        break;
                    }
                }

                if (i1 == -1 && i2 == -1)
                {
                    break;
                }

                int m = nList[i1] % nList[i2];

                nList.Add(m);
                nList.RemoveAt(i1);
                nList.RemoveAt(i2);
            }

            return nList.Count;
        }
    }
}
