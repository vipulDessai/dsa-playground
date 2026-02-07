namespace learning_dsa_csharp._15_greedy._006_lemonade_change
{
    internal class OthersSoln
    {
        public bool LemonadeChange(int[] bills)
        {
            int five = 0,
                ten = 0;
            foreach (var cur in bills)
            {
                if (cur == 5)
                {
                    five++;
                }
                else if (cur == 10)
                {
                    five--;
                    ten++;
                }
                else if (cur == 20)
                {
                    if (ten > 0)
                    {
                        ten--;
                        five--;
                    }
                    else
                    {
                        five -= 3;
                    }
                }

                if (five < 0)
                    return false;
            }

            return true;
        }
    }
}
