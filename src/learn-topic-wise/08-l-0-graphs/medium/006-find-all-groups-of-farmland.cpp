// [Find All Groups of Farmland](https://leetcode.com/problems/find-all-groups-of-farmland/description/)

#include <array>
#include <iostream>
#include <vector>

using namespace std;

namespace _012_find_all_groups_of_farmland {
class Solution {
   private:
    int dfsCol(vector<vector<int>>& land, int r, int c) {
        int m = land.size(), n = land[0].size();

        int nC = c + 1;

        if (nC >= n || land[r][nC] != 1) {
            return c;
        }

        return dfsCol(land, r, nC);
    }
    int dfsRow(vector<vector<int>>& land, int r, int c) {
        int m = land.size(), n = land[0].size();

        int nR = r + 1;

        if (nR >= m || land[nR][c] != 1) {
            return r;
        }

        return dfsRow(land, nR, c);
    }

   public:
    vector<vector<int>> findFarmland(vector<vector<int>>& land) {
        int m = land.size(), n = land[0].size();

        vector<vector<int>> res;
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (land[i][j] == 1) {
                    int x = dfsRow(land, i, j);
                    int y = dfsCol(land, i, j);

                    for (int k = i; k <= x; ++k) {
                        for (int l = j; l <= y; ++l) {
                            land[k][l] = -1;
                        }
                    }

                    res.push_back({i, j, x, y});
                }
            }
        }

        return res;
    }
};
}  // namespace _012_find_all_groups_of_farmland

class Execute {
   public:
    void static Main() {
        _012_find_all_groups_of_farmland::Solution s;

        vector<vector<int>> input = {{1, 0, 0}, {0, 1, 1}, {0, 1, 1}};
        // input = {{{1, 1}, {0, 0}}};

        auto out = s.findFarmland(input);

        int m = out.size(), n = out[0].size();

        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                cout << out[i][j] << " ";
            }
            cout << endl;
        }
    }
};

int main() {
    Execute::Main();
    return 0;
}