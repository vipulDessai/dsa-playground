// https://leetcode.com/problems/open-the-lock/
using System.Text;

namespace learning_dsa_csharp._11_graphs._014_open_the_lock
{
    // https://leetcode.com/problems/open-the-lock/solutions/1250656/short-easy-solution-bfs-traversal-explained-w-commented-code
    internal class OthersSoln
    {
        public int OpenLock(string[] deadends, string target)
        {
            HashSet<string> dead = new HashSet<string>(deadends);
            HashSet<string> visited = new HashSet<string>(["0000"]);

            if (dead.Contains("0000"))
                return -1; // if start string itself is a deadend
            if (target == "0000")
                return 0;

            Queue<string> q = new Queue<string>();
            q.Enqueue("0000");

            int res = 0;
            while (q.Count > 0)
            {
                ++res;
                int qLen = q.Count;
                for (int i = 0; i < qLen; i++)
                {
                    string cur = q.Dequeue();

                    for (int j = 0; j < 4; j++)
                    {
                        foreach (string adjStr in turn(cur, j))
                        {
                            if (!visited.Contains(adjStr) && !dead.Contains(adjStr))
                            {
                                if (adjStr == target)
                                {
                                    return res;
                                }
                                else
                                {
                                    q.Enqueue(adjStr);
                                    visited.Add(adjStr);
                                }
                            }
                        }
                    }
                }
            }

            return -1;
        }

        private string[] turn(string s, int i)
        {
            StringBuilder sb1 = new StringBuilder(s);
            sb1[i] = (char)('0' + (sb1[i] - '0' + 1) % 10);

            StringBuilder sb2 = new StringBuilder(s);
            sb2[i] = (char)('0' + (sb2[i] - '0' - 1 + 10) % 10);

            return [sb1.ToString(), sb2.ToString()];
        }
    }
}
