// https://leetcode.com/problems/create-binary-tree-from-descriptions/?envType=daily-question&envId=2024-07-15

#include <iostream>
#include <queue>
#include <unordered_map>
#include <unordered_set>
#include <vector>

#include "generate-trees.h"

using namespace std;
using namespace utils;

namespace _001_contruct_a_binary_tree {

class Solution {
   private:
    unordered_map<int, vector<int>> adjList;
    TreeNode* dfs(int nVal) {
        TreeNode* curNode = new TreeNode(nVal);
        if (adjList.count(nVal)) {
            if (adjList[nVal][0] != -1) {
                curNode->left = dfs(adjList[nVal][0]);
            }

            if (adjList[nVal][1] != -1) {
                curNode->right = dfs(adjList[nVal][1]);
            }
        }

        return curNode;
    }

   public:
    TreeNode* createBinaryTree(vector<vector<int>>& descriptions) {
        unordered_set<int> rootFinder;

        for (auto d : descriptions) {
            int p = d[0];
            int c = d[1];
            bool isLeft = d[2] == 1;

            if (!adjList.count(p)) {
                adjList[p] = {-1, -1};
            }

            if (isLeft) {
                adjList[p][0] = c;
            } else {
                adjList[p][1] = c;
            }

            rootFinder.insert(p);
        }

        for (auto [k, v] : adjList) {
            auto lC = v[0];
            auto rC = v[1];

            if (rootFinder.count(lC)) {
                rootFinder.erase(lC);
            }
            if (rootFinder.count(rC)) {
                rootFinder.erase(rC);
            }
        }

        int rootVal = *rootFinder.begin();

        TreeNode* root = dfs(rootVal);

        return root;
    }
};

}  // namespace _001_contruct_a_binary_tree

class Execute {
   public:
    static void Main() {
        _001_contruct_a_binary_tree::Solution s;

        vector<vector<int>> des = {{20, 15, 1}, {20, 17, 0}, {50, 20, 1}, {50, 80, 0}, {80, 19, 1}};

        TreeNode* out = s.createBinaryTree(des);

        queue<TreeNode*> q;
        q.push(out);

        while (q.size()) {
            int qLen = q.size();

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

            cout << endl;
        }
    }
};

int main() {
    Execute::Main();
    return 0;
}