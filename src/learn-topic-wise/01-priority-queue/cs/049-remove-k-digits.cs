// https://leetcode.com/problems/remove-k-digits/description/
using System.Text;

namespace learning_dsa_csharp._01_strings_arrays_hash._049_remove_k_digits
{
    internal class MySoln
    {
        // fails for k = 3 and "111111" i.e. all same digits
        public string RemoveKdigits(string num, int k)
        {
            int n = num.Length;
            if (n == k)
                return "0";

            num = num + '0';

            StringBuilder sB = new StringBuilder();
            for (int i = 0; i < n; ++i)
            {
                if (num[i] > num[i + 1] & k > 0)
                {
                    --k;
                }
                else
                {
                    sB.Append(num[i]);
                }
            }

            var res = sB.ToString();
            sB = new StringBuilder();

            bool f = false;
            for (int i = 0; i < res.Length; ++i)
            {
                if (res[i] != '0' && !f)
                {
                    f = true;
                }

                if (f)
                {
                    sB.Append(res[i]);
                }
            }

            res = sB.ToString();
            return res == "" ? "0" : res;
        }
    }
}
