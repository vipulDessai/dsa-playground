// https://leetcode.com/problems/maximum-score-from-removing-substrings/
namespace learning_dsa_csharp._04_stack._006_maximum_score_from_removing_substrings
{
    // https://leetcode.com/problems/maximum-score-from-removing-substrings/solutions/5464475/stack-easy-and-clean-code-c-java-c
    internal class OthersSoln
    {
        public int MaximumGain(string s, int x, int y)
        {
            char a = 'a';
            char b = 'b';

            if (y > x)
            {
                (x, y) = (y, x);
                (a, b) = (b, a);
            }

            int res = 0;

            // remove 'ab' pairs if possible, adding to the score.
            Stack<char> fSt = new Stack<char>();
            foreach (char c in s)
            {
                if (c == b && fSt.Count > 0 && fSt.Peek() == a)
                {
                    res += x;
                    fSt.Pop();
                }
                else
                {
                    fSt.Push(c);
                }
            }

            // transfer remaining characters to a new stack, removing 'ba' pairs if possible.
            Stack<char> rSt = new Stack<char>();
            while (fSt.Count > 0)
            {
                if (fSt.Peek() == b && rSt.Count > 0 && rSt.Peek() == a)
                {
                    res += y;
                    fSt.Pop();
                    rSt.Pop();
                }
                else
                {
                    rSt.Push(fSt.Pop());
                }
            }

            return res;
        }
    }
}
