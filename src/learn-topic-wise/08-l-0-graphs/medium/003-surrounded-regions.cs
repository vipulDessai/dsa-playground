// [Surrounded Regions](https://leetcode.com/problems/surrounded-regions/description/)

namespace learning_dsa_csharp._11_graphs._004_surrounded_regions
{
    public class Solution
    {
        private void dfs(char[][] board, int r, int c)
        {
            if (board[r][c] != 'O') return;

            board[r][c] = 'T';

            int m = board.Length, n = board[0].Length;

            int[,] directions = new int[4, 2]
            {
                { -1, 0 },
                {  0, 1 },
                {  1, 0 },
                {  0, -1 }
            };

            for (int i = 0; i < 4; ++i)
            {
                int nR = r + directions[i, 0], nC = c + directions[i, 1];

                if (nR < 0 || nR >= m || nC < 0 || nC >= n) continue;

                dfs(board, nR, nC);
            }
        }

        public void Solve(char[][] board)
        {
            int m = board.Length, n = board[0].Length;

            // mark the edge islands (with 'O') to be 'T'
            // left and right edges
            for (int i = 0; i < m; ++i)
            {
                dfs(board, i, 0);
                dfs(board, i, n - 1);
            }
            // upper and lower edges
            for (int i = 0; i < n; ++i)
            {
                dfs(board, 0, i);
                dfs(board, m - 1, i);
            }

            // mark all remaining 'O' as 'X' (i.e. capture the non edge islands)
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (board[i][j] == 'O')
                    {
                        board[i][j] = 'X';
                    }
                }
            }

            // restore the edge islands from 'T' to 'O'
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (board[i][j] == 'T')
                    {
                        board[i][j] = 'O';
                    }
                }
            }
        }
    }

    class Execute
    {
        public static void Main(string[] ars)
        {
            Solution s = new();
            char[][] input = [
                ['X', 'X', 'X', 'X'],
                ['X', 'O', 'O', 'X'],
                ['X', 'X', 'O', 'X'],
                ['X', 'O', 'X', 'X']
            ];

            input = [
                ['O', 'O', 'O'],
                ['O', 'O', 'O'],
                ['O', 'O', 'O']
            ];

            input = [
                ['O', 'O', 'O', 'O'],
                ['O', 'X', 'X', 'O'],
                ['O', 'X', 'X', 'O'],
                ['O', 'O', 'O', 'O']
            ];

            s.Solve(input);

            for (int i = 0; i < input.Length; ++i)
            {
                for (int j = 0; j < input[0].Length; ++j)
                {
                    Console.Write(input[i][j]);
                }

                Console.WriteLine();
            }
        }
    }
}
