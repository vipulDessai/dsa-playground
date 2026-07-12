// [Maximum Difference Between Node and Ancestor](https://leetcode.com/problems/maximum-difference-between-node-and-ancestor/description/)

#include <iostream>
#include <limits>

#include "generate-trees.h"

using namespace std;
using namespace utils;

namespace _007_max_diff_btw_node_and_ancestor {
class Solution {
   private:
    int _max = 0;
    void dfs(TreeNode* n, int greatAncestor, int weakAncestor) {
        if (!n) {
            return;
        }

        int v = n->val;

        if (greatAncestor - v > _max) {
            _max = greatAncestor - v;
        }

        if (v - weakAncestor > _max) {
            _max = v - weakAncestor;
        }

        greatAncestor = max(v, greatAncestor);
        weakAncestor = min(v, weakAncestor);

        dfs(n->left, greatAncestor, weakAncestor);
        dfs(n->right, greatAncestor, weakAncestor);
    }

   public:
    int maxAncestorDiff(TreeNode* root) {
        int MAX_INT = numeric_limits<int>::max();

        dfs(root, -1, MAX_INT);

        return _max;
    }
};

}  // namespace _007_max_diff_btw_node_and_ancestor

class Execute {
   public:
    static void Main() {
        _007_max_diff_btw_node_and_ancestor::Solution s;

        vector<optional<int>> input = {8, 3, 10, 1, 6, nullopt, 14, nullopt, nullopt, 4, 7, 13};
        TreeNode* root = TreeOperations::generate(input);

        cout << s.maxAncestorDiff(root);
    }
};

int main() {
    Execute::Main();
    return 0;
}
