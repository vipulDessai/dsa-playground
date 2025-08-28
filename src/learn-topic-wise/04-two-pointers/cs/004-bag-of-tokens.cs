namespace learning_dsa_csharp._02_two_pointers._004_bag_of_tokens
{
    internal class MySoln
    {
        public int BagOfTokensScore(int[] tokens, int power)
        {
            int n = tokens.Length;

            int l = 0;
            int r = n - 1;

            Array.Sort(tokens);

            int res = 0;

            while (l < r)
            {
                if (power >= tokens[l])
                {
                    power -= tokens[l];
                    ++l;
                    ++res;
                }
                else if (res > 0)
                {
                    power += tokens[r];
                    --r;
                    --res;
                }
                else
                {
                    break;
                }
            }

            if (l == r)
            {
                if (power >= tokens[r])
                {
                    ++res;
                }
            }

            return res;
        }
    }
}
