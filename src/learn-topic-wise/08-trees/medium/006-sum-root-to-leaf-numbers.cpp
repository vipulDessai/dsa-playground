// https://leetcode.com/problems/sum-root-to-leaf-numbers/

#include <optional>
#include <vector>

#include "generate-trees.h";

using namespace utils;

namespace _010_sum_root_to_leaf_numbers {
class Solution {
   private:
    int dfs(TreeNode* n, int pS) {
        if (!n) {
            return 0;
        }

        int cur = (pS * 10) + n->val;
        if (n->left == nullptr && n->right == nullptr)
            return cur;

        return dfs(n->left, cur) + dfs(n->right, cur);
    }

   public:
    int SumNumbers(TreeNode* root) {
        return dfs(root, 0);
    }
};

}  // namespace _010_sum_root_to_leaf_numbers

class Execute {
   public:
    static void Main() {
        _010_sum_root_to_leaf_numbers::Solution s;
        vector<optional<int>> arr = {1, 2, 3};
        TreeNode* root = TreeOperations::generate(arr);
        s.SumNumbers(root);
    }
};

int main() {
    Execute::Main();
    return 0;
}