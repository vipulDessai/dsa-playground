// [Rotting Oranges](https://leetcode.com/problems/rotting-oranges/description/)

#include <array>
#include <iostream>
#include <queue>
#include <unordered_set>
#include <vector>

using namespace std;

namespace _005_rotting_oranges {
class Solution {
    int fresh = 0;

   public:
    int orangesRotting(vector<vector<int>>& grid) {
        queue<vector<int>> q;

        int rLen = grid.size(), cLen = grid[0].size();

        for (int i = 0; i < rLen; ++i) {
            bool bFlag = false;
            for (int j = 0; j < cLen; ++j) {
                if (grid[i][j] == 2) {
                    q.push({i, j});
                }

                if (grid[i][j] == 1) {
                    ++fresh;
                }
            }
        }

        int res = 0;
        while (q.size()) {
            int qLen = q.size();

            for (int i = 0; i < qLen; ++i) {
                vector<int> node = q.front();
                q.pop();

                array<array<int, 2>, 4> directions = {{{-1, 0}, {0, 1}, {1, 0}, {0, -1}}};

                for (int i = 0; i < 4; ++i) {
                    int nR = node[0] + directions[i][0];
                    int nC = node[1] + directions[i][1];

                    if (nR < 0 || nC < 0 || nR >= rLen || nC >= cLen) {
                        continue;
                    }

                    /// if the next grid item is fresh and available
                    if (grid[nR][nC] == 1) {
                        grid[nR][nC] = 2;
                        --fresh;
                        q.push({nR, nC});
                    }
                }
            }

            if (q.size())
                ++res;
        }

        return fresh == 0 ? res : -1;
    }
};
}  // namespace _005_rotting_oranges

class Execute {
   public:
    static void Main() {
        _005_rotting_oranges::Solution s;

        vector<vector<int>> input = {{2, 1, 1}, {1, 1, 0}, {0, 1, 1}};

        cout << s.orangesRotting(input) << endl;
    }
};

int main() {
    Execute::Main();

    return 0;
};