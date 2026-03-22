namespace learning_dsa_csharp._04_stack._004_daily_temperature;

public class MySoln
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        int n = temperatures.Length;
        int[] ans = new int[n];
        Stack<int> s = new Stack<int>();
        for (int i = n - 1; i >= 0; --i)
        {
            while (s.Count > 0 && temperatures[s.Peek()] <= temperatures[i])
            {
                s.Pop();
            }

            if (s.Count == 0)
            {
                ans[i] = 0;
            }
            else
            {
                ans[i] = s.Peek() - i;
            }

            s.Push(i);
        }

        return ans;
    }
}
