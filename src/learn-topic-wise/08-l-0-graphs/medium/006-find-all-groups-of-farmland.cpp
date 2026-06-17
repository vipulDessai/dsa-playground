// [](https://leetcode.com/problems/find-all-groups-of-farmland/description/)

#include <array>
#include <iostream>
#include <vector>

using namespace std;

namespace _012_find_all_groups_of_farmland {
class Solution {
   private:
    int dfsCol(vector<vector<int>>& land, int r, int c) {
        int m = land.size(), n = land[0].size();
        if (c > m - 1 || land[r][c] == 0) {
            return c - 1;
        }

        return dfsCol(land, r, c + 1);
    }

    int dfsRow(vector<vector<int>>& land, int r, int c) {
        int m = land.size(), n = land[0].size();
        if (r > n - 1 || land[r][c] == 0) {
            return r - 1;
        }

        return dfsRow(land, r + 1, c);
    }

   public:
    vector<vector<int>> findFarmland(vector<vector<int>>& land) {
        int n = land.size();
        int m = land[0].size();

        vector<vector<int>> res;
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < m; ++j) {
                if (land[i][j] == 1) {
                    int mC = dfsCol(land, i, j);
                    int mR = dfsRow(land, i, j);

                    // mark the land as visited
                    for (int k = i; k <= mR; ++k) {
                        for (int l = j; l <= mC; ++l) {
                            land[k][l] = -1;
                        }
                    }

                    res.push_back({i, j, mR, mC});
                }
            }
        }

        return res;
    }
};

class MySoln {
   private:
    array<int, 2> dfs(vector<vector<int>>& land, int r, int c) {
        int m = land.size(), n = land[0].size();

        land[r][c] = -1;

        array<array<int, 2>, 2> directions = {{{1, 0}, {0, 1}}};

        array<bool, 2> nei = {{false, false}};
        for (int i = 0; i < 2; ++i) {
            int nR = r + directions[i][0], nC = c + directions[i][1];

            if (nR < 0 || nR >= m || nC < 0 || nC >= n) continue;

            if (land[nR][nC] != 1) continue;

            nei[i] = true;
            land[nR][nC] = -1;
        }

        if (nei[0] && nei[1]) {
            return dfs(land, r + 1, c + 1);
        } else {
            return {{r, c}};
        }
    }

   public:
    vector<vector<int>> findFarmland(vector<vector<int>>& land) {
        int m = land.size(), n = land[0].size();

        vector<vector<int>> res;
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (land[i][j] == 1) {
                    auto [x, y] = dfs(land, i, j);

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
        _012_find_all_groups_of_farmland::MySoln s;

        vector<vector<int>> input = {{1, 0, 0}, {0, 1, 1}, {0, 1, 1}};
        input = {{{1, 1}, {0, 0}}};

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