using System.Collections.Generic;
using System.Text;

namespace learning_dsa_csharp._10_backtracking._009_n_queens
{
    internal class Solution
    {
        IList<IList<string>> res;
        int boardSize;

        public IList<IList<string>> SolveNQueens(int n)
        {
            res = new List<IList<string>>();

            char[][] exists = new char[n][];
            for (int i = 0; i < n; ++i)
            {
                exists[i] = new char[n];
                for (int j = 0; j < n; ++j)
                {
                    exists[i][j] = '.';
                }
            }

            boardSize = n;
            ClearHelper(exists, boardSize);

            return res;
        }

        private void ClearHelper(char[][] exists, int num)
        {
            if (num == 0)
            {
                IList<string> list = new List<string>();

                #region diff
                for (int i = 0; i < exists.Length; ++i)
                {
                    StringBuilder builder = new StringBuilder();
                    for (int j = 0; j < exists.Length; ++j)
                    {
                        builder.Append(exists[i][j]);
                    }
                    list.Add(builder.ToString());
                }

                res.Add(list);
                #endregion

                return;
            }

            int currentRowIndex = boardSize - num;
            for (int j = 0; j < boardSize; ++j)
            {
                bool flag = true;

                for (int c = 1; c <= currentRowIndex; ++c)
                {
                    if (exists[currentRowIndex - c][j] == 'Q')
                    {
                        flag = false;
                        break;
                    }
                    if (j - c >= 0 && exists[currentRowIndex - c][j - c] == 'Q')
                    {
                        flag = false;
                        break;
                    }
                    if (j + c < boardSize && exists[currentRowIndex - c][j + c] == 'Q')
                    {
                        flag = false;
                        break;
                    }
                }

                if (!flag)
                    continue;

                exists[currentRowIndex][j] = 'Q';
                ClearHelper(exists, num - 1);
                exists[currentRowIndex][j] = '.';
            }
        }
    }
}
