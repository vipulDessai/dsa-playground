using System.Linq;

namespace learning_dsa_csharp._11_graphs._004_surrounded_regions
{
    internal class Solution
    {
        public void Solve(char[][] board)
        {
            int rLength = board.Length;
            int cLength = board[0].Length;

            int[] directionX = new[] { 1, -1, 0, 0 };
            int[] directionY = new[] { 0, 0, 1, -1 };

            void capture(int r, int c)
            {
                if (r < 0 || c < 0 || r == rLength || c == cLength || board[r][c] != 'O')
                    return;

                board[r][c] = 'T';

                for (int i = 0; i < 4; i++)
                {
                    int nextRow = r + directionX[i];
                    int nextCol = c + directionY[i];
                    capture(nextRow, nextCol);
                }
            }

            int[] rBorder = new[] { 0, rLength - 1 };
            int[] cBorder = new[] { 0, cLength - 1 };
            // capture unsurrounded regions (O - T)
            for (int i = 0; i < rLength; i++)
            {
                for (int j = 0; j < cLength; j++)
                {
                    if (board[i][j] == 'O' && (rBorder.Contains(i) || cBorder.Contains(j)))
                    {
                        capture(i, j);
                    }
                }
            }

            // now after O -> T conversion, the remaining O can be just converted to X i.e. simply capture them
            for (int i = 0; i < rLength; i++)
            {
                for (int j = 0; j < cLength; j++)
                {
                    if (board[i][j] == 'O')
                    {
                        board[i][j] = 'X';
                    }
                }
            }

            // Now restore the T back to O
            for (int i = 0; i < rLength; i++)
            {
                for (int j = 0; j < cLength; j++)
                {
                    if (board[i][j] == 'T')
                    {
                        board[i][j] = 'O';
                    }
                }
            }
        }
    }
}
