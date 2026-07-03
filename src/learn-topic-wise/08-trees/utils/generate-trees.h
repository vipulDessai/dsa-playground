#ifndef COMMON_UTILS_H
#define COMMON_UTILS_H

namespace utils {

struct TreeNode {
    int val;
    TreeNode* left;
    TreeNode* right;
    TreeNode();
    TreeNode(int x);
    TreeNode(int x, TreeNode* left, TreeNode* right);
};

}  // namespace utils

#endif