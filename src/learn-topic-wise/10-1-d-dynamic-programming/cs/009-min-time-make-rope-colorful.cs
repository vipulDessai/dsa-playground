namespace learning_dsa_csharp._13_1_d_dynamic_programming._009_min_time_make_rope_colorful
{
    internal class Solution
    {
        public int MinCost_dp(string colors, int[] neededTime)
        {
            int dfs()
            {
                char prevColorChar = colors[0];
                int prevColorRemoveCost = neededTime[0];
                int t = 0;
                for (int i = 1; i < colors.Length; i++)
                {
                    if (colors[i] == prevColorChar)
                    {
                        int curNeededTime = neededTime[i];

                        // take the min out of cur and prev color
                        if (prevColorRemoveCost > curNeededTime)
                        {
                            t += curNeededTime;
                        }
                        else
                        {
                            t += prevColorRemoveCost;

                            prevColorChar = colors[i];
                            prevColorRemoveCost = curNeededTime;
                        }
                    }
                    else
                    {
                        prevColorChar = colors[i];
                        prevColorRemoveCost = neededTime[i];
                    }
                }

                return t;
            }

            return dfs();
        }
    }
}
