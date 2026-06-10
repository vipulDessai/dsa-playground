#include <iostream>
#include <set>
#include <vector>

using namespace std;

namespace _003_pacific_atlantic_water_flow {
class Solution {
    vector<vector<int>> h;
    int rLength;
    int cLength;

   public:
    vector<vector<int>> pacificAtlantic(vector<vector<int>>& heights) {
        // auto pac = new HashSet<(int, int)>();
        // auto atl = new HashSet<(int, int)>();

        // rLength = heights.Length;
        // cLength = heights[0].Length;

        // h = heights;

        // for (int c = 0; c < cLength; c++)
        // {
        //     dfs(0, c, pac, h[0][c]);
        //     dfs(rLength - 1, c, atl, h[rLength - 1][c]);
        // }

        // for (int r = 0; r < rLength; r++)
        // {
        //     dfs(r, 0, pac, h[r][0]);
        //     dfs(r, cLength - 1, atl, h[r][cLength - 1]);
        // }

        // var res = new List<IList<int>>();
        // for (int r = 0; r < rLength; r++)
        // {
        //     for (int c = 0; c < cLength; c++)
        //     {
        //         if (pac.Contains((r, c)) && atl.Contains((r, c)))
        //         {
        //             res.Add(new List<int>() { r, c });
        //         }
        //     }
        // }
        // return res;

        return heights;
    }

   private:
    void dfs(int r, int c, set<pair<int, int>> visit, int prevHeight) {
        if (
            visit.count({r, c}) || r < 0 || c < 0 || r == rLength || c == cLength || h[r][c] < prevHeight) {
            return;
        }

        visit.insert({r, c});

        dfs(r + 1, c, visit, h[r][c]);
        dfs(r - 1, c, visit, h[r][c]);
        dfs(r, c + 1, visit, h[r][c]);
        dfs(r, c - 1, visit, h[r][c]);
    }
};
}  // namespace _003_pacific_atlantic_water_flow

class Execute {
   public:
    static void Main() {
        _003_pacific_atlantic_water_flow::Solution s;

        vector<vector<int>> input = {{1, 2, 2, 3, 5}, {3, 2, 3, 4, 4}, {2, 4, 5, 3, 1}, {6, 7, 1, 4, 5}, {5, 1, 1, 2, 4}};

        auto output = s.pacificAtlantic(input);

        int rLen = output.size(), cLen = output[0].size();

        for (int i = 0; i < rLen; ++i) {
            for (int j = 0; j < cLen; ++j) {
                cout << output[i][j] << " ";
            }

            cout << endl;
        }
    }
};

int main() {
    Execute::Main();
    return 0;
}