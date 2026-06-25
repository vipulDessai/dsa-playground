// [Minimum Height Trees](https://leetcode.com/problems/minimum-height-trees/)

#include <climits>
#include <iostream>
#include <unordered_map>
#include <unordered_set>
#include <vector>

using namespace std;

namespace _015_minimum_height_trees {
// https://leetcode.com/problems/minimum-height-trees/solutions/1631179/c-python-3-simple-solution-w-explanation-brute-force-2x-dfs-remove-leaves-w-bfs
class OthersSoln_brute {
   private:
    unordered_map<int, vector<int>> adj;
    unordered_set<int> visited;

    int dfs(int i) {
        visited.insert(i);
        int c = 0;
        for (auto a : adj[i]) {
            if (!visited.count(a)) {
                c = max(c, 1 + dfs(a));
            }
        }

        return c;
    }

   public:
    vector<int> findMinHeightTrees(int n, vector<vector<int>>& edges) {
        if (edges.size() == 0)
            return {0};

        // form the adjacency list
        for (auto e : edges) {
            adj[e[0]].push_back(e[1]);
            adj[e[1]].push_back(e[0]);
        }

        vector<int> ans;
        int mH = INT_MAX;
        for (auto& [key, value] : adj) {
            visited.clear();
            int p = dfs(key);

            if (p < mH) {
                ans.clear();
                mH = p;
            }

            if (p == mH)
                ans.push_back(key);
        }

        return ans;
    }
};

class OthersSoln_2x_dfs {
   private:
    unordered_map<int, vector<int>> adjList;
    unordered_set<int> visited;

    vector<int> dfs(int i) {
        vector<int> longestPath;
        visited.insert(i);

        for (int a : adjList[i]) {
            if (!visited.count(a)) {
                vector<int> p = dfs(a);

                if (p.size() > longestPath.size()) {
                    longestPath = p;
                }
            }
        }

        longestPath.push_back(i);
        return longestPath;
    }

   public:
    // 2x dfs
    vector<int> findMinHeightTrees(int n, vector<vector<int>>& edges) {
        if (edges.size() == 0)
            return {0};

        for (auto e : edges) {
            adjList[e[0]].push_back(e[1]);
            adjList[e[1]].push_back(e[0]);
        }

        auto basePath = dfs(0);
        visited.clear();
        auto path = dfs(basePath[0]);

        if (path.size() & 1)  // 1 mid-node when path length is odd, otherwise 2
            return {path[path.size() / 2]};

        // for handling even answer (2 mid-nodes)
        return {
            path[path.size() / 2], path[(path.size() - 1) / 2]};
    }
};

// class OthersSoln_remove_leaf_nodes {
//    public:
//     vector<int> findMinHeightTrees(int n, vector<vector<int>>& edges) {
//         if (edges.size() == 0)
//             return {0};

//         // form the adjacency list
//         Dictionary<int, List<int>> g = new Dictionary<int, List<int>>();
//         for (int i = 0; i < edges.Length; ++i) {
//             var e = edges[i];
//             if (!g.ContainsKey(e[0])) {
//                 g.Add(e[0], []);
//             }
//             g[e[0]].Add(e[1]);

//             if (!g.ContainsKey(e[1])) {
//                 g.Add(e[1], []);
//             }
//             g[e[1]].Add(e[0]);
//         }

//         List<int> leafs = new List<int>();
//         List<int> inDeg = new List<int>();
//         for (int i = 0; i < n; ++i) {
//             if (g[i].Count == 1)
//                 leafs.Add(i);

//             inDeg.Add(g[i].Count);
//         }

//         while (n > 2) {
//             List<int> nL = new List<int>();
//             foreach (var l in leafs) {
//                 foreach (var adj in g[l]) {
//                     if (--inDeg[adj] == 1) {
//                         nL.Add(adj);
//                     }
//                 }
//             }

//             n -= leafs.Count;
//             leafs = nL.ToList();
//         }

//         return leafs;
//     }
// };
}  // namespace _015_minimum_height_trees

class Execute {
   public:
    void static Main() {
        _015_minimum_height_trees::OthersSoln_2x_dfs s;

        int n = 4;
        vector<vector<int>> edges = {{1, 0}, {1, 2}, {1, 3}};
        edges = {{3, 0}, {3, 1}, {3, 2}, {3, 4}, {5, 4}};

        auto output = s.findMinHeightTrees(n, edges);

        for (int i = 0; i < output.size(); ++i) {
            cout << output[i] << " ";
        }
    };
};

int main() {
    Execute::Main();
    return 0;
}