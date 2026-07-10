#include "generate-trees.h"

#include <iostream>
#include <optional>
#include <queue>
#include <stdexcept>
#include <vector>

using namespace std;

namespace utils {

// Define constructors
TreeNode::TreeNode() : val(0), left(nullptr), right(nullptr) {}
TreeNode::TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
TreeNode::TreeNode(int x, TreeNode* left, TreeNode* right) : val(x), left(left), right(right) {}

TreeNode* TreeOperations::generate(vector<optional<int>> inArr) {
    int n = inArr.size();

    if (n == 0 || !inArr[0].has_value()) {
        throw invalid_argument("Input must contain a non-null root value.");
    }

    TreeNode* root = new TreeNode(inArr[0].value());

    queue<TreeNode*> q;
    q.push(root);

    int i = 1;
    while (q.size() > 0 && i < n) {
        TreeNode* cur = q.front();
        q.pop();

        if (i < n && inArr[i].has_value()) {
            auto l = new TreeNode(inArr[i].value());
            cur->left = l;
            q.push(l);
        }
        ++i;

        if (i < n && inArr[i].has_value()) {
            auto r = new TreeNode(inArr[i].value());
            cur->right = r;
            q.push(r);
        }
        ++i;
    }

    return root;
};

void TreeOperations::print(TreeNode* root) {
    queue<TreeNode*> q;
    q.push(root);

    while (q.size()) {
        int qLen = q.size();

        cout << endl;

        for (int i = 0; i < qLen; ++i) {
            TreeNode* cur = q.front();
            q.pop();

            if (cur == nullptr) continue;

            cout << cur->val << " ";

            if (cur->left != nullptr) {
                q.push(cur->left);
            }
            if (cur->right != nullptr) {
                q.push(cur->right);
            }
        }
    }
}

}  // namespace utils
