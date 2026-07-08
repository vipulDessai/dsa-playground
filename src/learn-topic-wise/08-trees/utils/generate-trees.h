#ifndef COMMON_UTILS_H
#define COMMON_UTILS_H

#include <optional>
#include <vector>

using namespace std;

namespace utils {

struct TreeNode {
    int val;
    TreeNode* left;
    TreeNode* right;
    TreeNode();
    TreeNode(int x);
    TreeNode(int x, TreeNode* left, TreeNode* right);
};

class TreeOperations {
   public:
    static TreeNode* generate(vector<optional<int>> inArr);
    static void print(TreeNode* root);
};

}  // namespace utils

#endif