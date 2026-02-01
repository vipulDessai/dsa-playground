using System;
using System.Collections.Generic;

namespace learning_dsa_csharp._11_graphs._005_rotting_oranges
{
    internal class Solution
    {
        // this wont work because
        // [[2,1,1],[1,1,0],[0,1,2]] output - 5, but expected - 2
        public int OrangesRotting_Recursion(int[][] grid)
        {
            int rL = grid.Length;
            int cL = grid[0].Length;

            int[] directionX = new[] { 1, -1, 0, 0 };
            int[] directionY = new[] { 0, 0, 1, -1 };

            int dfs(int r, int c, int curMin)
            {
                if (r < 0 || c < 0 || r == rL || c == cL || grid[r][c] == 0 || grid[r][c] == 2)
                {
                    return curMin;
                }

                grid[r][c] = 2;

                // now the time increases by +1 minute
                curMin = curMin + 1;

                var lastMin = 0;
                for (int i = 0; i < 4; i++)
                {
                    int nextR = r + directionX[i];
                    int nextC = c + directionY[i];

                    lastMin = Math.Max(lastMin, dfs(nextR, nextC, curMin));
                }

                return lastMin;
            }

            var maxMins = 0;
            for (int i = 0; i < rL; ++i)
            {
                for (int j = 0; j < cL; ++j)
                {
                    // if only we have a rotten orange, then only see
                    // how many more are infected
                    if (grid[i][j] == 2)
                    {
                        // for time being make it unrotten
                        // as it will be imediately set to 2
                        // after just fews checks
                        grid[i][j] = 1;
                        maxMins = Math.Max(maxMins, dfs(i, j, -1));
                    }
                }
            }

            // if any orange state remains 1, i.e. its not rotten
            for (int i = 0; i < rL; ++i)
            {
                for (int j = 0; j < cL; ++j)
                {
                    if (grid[i][j] == 1)
                    {
                        return -1;
                    }
                }
            }

            // else return the minutes it took to rot all the oranges
            return maxMins;
        }

        public int OrangesRotting_BFS(int[][] grid)
        {
            int maxMins = -1;
            int rL = grid.Length;
            int cL = grid[0].Length;
            Queue<int[]> q = new Queue<int[]>();
            int freshCount = 0;

            for (int i = 0; i < rL; ++i)
            {
                for (int j = 0; j < cL; ++j)
                {
                    if (grid[i][j] == 2)
                    {
                        q.Enqueue(new int[] { i, j });
                    }

                    if (grid[i][j] == 1)
                    {
                        ++freshCount;
                    }
                }
            }

            do
            {
                var qLen = q.Count;
                for (int i = 0; i < qLen; ++i)
                {
                    var node = q.Dequeue();
                    var newlyInfectedIndices = infectOrangesInOneMinuteFrom(node[0], node[1]);

                    for (int j = 0; j < newlyInfectedIndices.Count; ++j)
                    {
                        q.Enqueue(newlyInfectedIndices[j]);
                    }
                }

                ++maxMins;
            } while (q.Count > 0);

            return freshCount == 0 ? maxMins : -1;

            List<int[]> infectOrangesInOneMinuteFrom(int r, int c)
            {
                int[] directionX = new int[] { 1, -1, 0, 0 };
                int[] directionY = new int[] { 0, 0, 1, -1 };
                List<int[]> newInfectedIndices = new List<int[]>();
                for (int i = 0; i < 4; ++i)
                {
                    int nextR = r + directionX[i];
                    int nextC = c + directionY[i];

                    if (nextR < 0 || nextC < 0 || nextR == rL || nextC == cL)
                    {
                        continue;
                    }

                    if (grid[nextR][nextC] == 1)
                    {
                        grid[nextR][nextC] = 2;
                        newInfectedIndices.Add(new int[] { nextR, nextC });

                        // lower the fresh oranges count per iteration of infection or rottening
                        --freshCount;
                    }
                }

                return newInfectedIndices;
            }
        }
    }
}
