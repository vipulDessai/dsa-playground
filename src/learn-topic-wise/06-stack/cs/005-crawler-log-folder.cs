namespace learning_dsa_csharp._04_stack._005_crawler_log_folder
{
    internal class MySoln
    {
        public int MinOperations(string[] logs)
        {
            int n = logs.Length;
            Stack<string> s = new Stack<string>();

            for (int i = 0; i < n; ++i)
            {
                switch (logs[i])
                {
                    case "../":

                        {
                            if (s.Count > 0)
                                s.Pop();
                        }
                        break;
                    case "./":
                         { }
                        break;

                    default:

                        {
                            s.Push(logs[i]);
                        }
                        break;
                }
            }

            return s.Count;
        }
    }
}
