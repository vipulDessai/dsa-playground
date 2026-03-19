namespace learning_dsa_csharp._01_strings_arrays_hash._037_maximum_odd_binary_number
{
    internal class OthersSoln
    {
        public string MaximumOddBinaryNumber(string s)
        {
            int c1 = 0,
                c0 = 0,
                i = 0;

            foreach (char ch in s)
            {
                if (ch == '1')
                {
                    c1++;
                }
                else
                {
                    c0++;
                }
            }

            char[] result = new char[s.Length];
            while (i < c1 - 1)
            {
                result[i++] = '1';
            }

            while (i < c1 - 1 + c0)
            {
                result[i++] = '0';
            }

            result[i] = '1';

            return new string(result);
        }
    }
}
