// [Pacific Atlantic Water Flow](https://leetcode.com/problems/pacific-atlantic-water-flow/)

#include <array>
#include <iostream>
#include <vector>

using namespace std;

namespace _003_pacific_atlantic_water_flow {
class Solution {
   public:
    vector<vector<int>> pacificAtlantic(vector<vector<int>>& heights) {
        int m = heights.size(), n = heights[0].size();
        vector<vector<bool>> pacific(m, vector<bool>(n, false));
        vector<vector<bool>> atlantic(m, vector<bool>(n, false));

        // Run DFS from every border cell, flowing UPHILL
        for (int i = 0; i < m; i++) {
            dfs(heights, pacific, i, 0);       // left edge  -> Pacific
            dfs(heights, atlantic, i, n - 1);  // right edge -> Atlantic
        }
        for (int j = 0; j < n; j++) {
            dfs(heights, pacific, 0, j);       // top edge    -> Pacific
            dfs(heights, atlantic, m - 1, j);  // bottom edge -> Atlantic
        }

        // Cells reachable by BOTH oceans are the answer
        vector<vector<int>> result;
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                if (pacific[i][j] && atlantic[i][j])
                    result.push_back({i, j});

        return result;
    }

   private:
    void dfs(
        vector<vector<int>>& heights,
        vector<vector<bool>>& visited,
        int r,
        int c) {
        if (visited[r][c]) {
            return;
        }

        int m = heights.size(), n = heights[0].size();
        visited[r][c] = true;

        // 4 directions, no diagonals
        array<array<int, 2>, 4> directions = {{{-1, 0}, {0, 1}, {1, 0}, {0, -1}}};

        for (int d = 0; d < 4; d++) {
            int nr = r + directions[d][0], nc = c + directions[d][1];

            if (nr < 0 || nr >= m || nc < 0 || nc >= n) continue;

            if (visited[nr][nc]) continue;

            if (heights[nr][nc] < heights[r][c]) continue;

            // Reverse logic: we move to a neighbor only if it's >= current
            // (because in real flow, water comes DOWN from that higher neighbor)
            dfs(heights, visited, nr, nc);
        }
    }
};
}  // namespace _003_pacific_atlantic_water_flow

class Execute {
   public:
    static void Main() {
        // _003_pacific_atlantic_water_flow::Solution s;
        _003_pacific_atlantic_water_flow::Solution s;

        vector<vector<int>> input = {
            {1, 2, 2, 3, 5},
            {3, 2, 3, 4, 4},
            {2, 4, 5, 3, 1},
            {6, 7, 1, 4, 5},
            {5, 1, 1, 2, 4}};

        input = {
            {1, 2, 3, 4},
            {3, 5, 4, 1},
            {5, 1, 7, 2},
            {4, 1, 1, 3}};

        auto output = s.pacificAtlantic(input);

        int rLen = output.size(), cLen = output[0].size();

        for (int i = 0; i < rLen; ++i) {
            int r = output[i][0];
            int c = output[i][1];

            cout << "[" << r << ", " << c << "] : " << input[r][c] << endl;
        }
    }
};

int main() {
    Execute::Main();
    return 0;
}