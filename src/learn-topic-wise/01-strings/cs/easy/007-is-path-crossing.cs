using System.Collections.Generic;

namespace learning_dsa_csharp._01_strings_arrays_hash._007_is_path_crossing
{
    internal class Solution
    {
        public bool IsPathCrossing(string path)
        {
            List<(int, int)> pathHash = new List<(int, int)>() { (0, 0) };
            int x = 0,
                y = 0;
            for (int i = 0; i < path.Length; i++)
            {
                switch (path[i])
                {
                    case 'N':
                        y += 1;
                        break;

                    case 'S':
                        y -= 1;
                        break;

                    case 'E':
                        x += 1;
                        break;

                    case 'W':
                        x -= 1;
                        break;
                }

                if (pathHash.Contains((x, y)))
                {
                    return true;
                }
                else
                {
                    pathHash.Add((x, y));
                }
            }

            return false;
        }
    }
}
