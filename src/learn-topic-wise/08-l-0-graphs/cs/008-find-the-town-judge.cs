// https://leetcode.com/problems/find-the-town-judge/

namespace learning_dsa_csharp._11_graphs._008_find_the_town_judge;

internal class MySoln
{
    public int FindJudge(int n, int[][] trust)
    {
        int[] inDegree = new int[n];
        int[] outDegree = new int[n];
        for (int i = 0; i < trust.Length; ++i)
        {
            var a = trust[i][0];
            var b = trust[i][1];

            inDegree[b - 1]++;
            outDegree[a - 1]++;
        }

        for (int i = 0; i < n; ++i)
        {
            if (inDegree[i] == n - 1 && outDegree[i] == 0)
            {
                return i + 1;
            }
        }

        return -1;
    }
}

public class OthersSoln
{
    public int FindJudge(int n, int[][] trust)
    {
        var m = new int[n];

        foreach (var t in trust)
        {
            m[t[0] - 1]--;
            m[t[1] - 1]++;
        }

        for (int i = 0; i <= n; i++)
        {
            if (m[i] == n - 1)
            {
                return i;
            }
        }

        return -1;
    }
}
