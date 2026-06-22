// [Open the Lock](https://leetcode.com/problems/open-the-lock/)

using System.Text;

namespace learning_dsa_csharp._11_graphs._014_open_the_lock
{
    public class Solution
    {
        private (string up, string down) RotateLock(string s, int i)
        {
            StringBuilder sB1 = new(s);
            sB1[i] = (char)('0' + (sB1[i] - '0' + 1) % 10);
            StringBuilder sB2 = new(s);
            sB2[i] = (char)('0' + (sB2[i] - '0' - 1 + 10) % 10);

            return (sB1.ToString(), sB2.ToString());
        }

        public int OpenLock(string[] deadends, string target)
        {
            HashSet<string> d = [.. deadends];
            HashSet<string> v = ["0000"];

            if (target == "0000") return 0;
            if (d.Contains("0000")) return -1;

            Queue<string> q = new();
            q.Enqueue("0000");

            int res = 0;
            while (q.Count > 0)
            {
                int qLen = q.Count;

                ++res;

                for (int i = 0; i < qLen; ++i)
                {
                    string cur = q.Dequeue();

                    for (int j = 0; j < 4; ++j)
                    {
                        var (up, down) = RotateLock(cur, j);

                        if (target == up) return res;
                        if (target == down) return res;

                        if (!d.Contains(up) && !v.Contains(up))
                        {
                            q.Enqueue(up);
                            v.Add(up);
                        }

                        if (!d.Contains(down) && !v.Contains(down))
                        {
                            q.Enqueue(down);
                            v.Add(down);
                        }
                    }
                }
            }

            return -1;
        }
    }
    class Execute
    {
        public static void Main(string[] args)
        {
            Solution s = new();

            string[] input = { "0201", "0101", "0102", "1212", "2002" };
            string t = "0202";
            Console.WriteLine(s.OpenLock(input, t));
        }
    }
}
