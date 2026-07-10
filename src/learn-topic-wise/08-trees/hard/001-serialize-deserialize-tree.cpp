// [Serialize and Deserialize Binary Tree](https://leetcode.com/problems/serialize-and-deserialize-binary-tree/description/)

#include <iostream>
#include <optional>
#include <queue>
#include <sstream>
#include <string>

#include "generate-trees.h"

using namespace std;
using namespace utils;

namespace _001_serialize_deserialize_tree {
class Codec {
   private:
    string bfsSerialize(TreeNode* root) {
        queue<TreeNode*> q;

        string s = "";

        q.push(root);

        while (q.size() > 0) {
            int qLen = q.size();

            for (int i = 0; i < qLen; ++i) {
                TreeNode* cur = q.front();
                q.pop();

                if (!cur) {
                    s += "#,";
                    continue;
                }

                s += to_string(cur->val) + ',';

                q.push(cur->left);
                q.push(cur->right);
            }
        }

        return s;
    }

    TreeNode* bfsDeserialize(string s) {
        int n = s.size();

        stringstream ss(s);
        string token;

        getline(ss, token, ',');

        TreeNode* root = new TreeNode(stoi(token));

        queue<TreeNode*> q;
        q.push(root);

        while (q.size() > 0) {
            TreeNode* cur = q.front();
            q.pop();

            if (getline(ss, token, ',')) {
                if (token != "#") {
                    auto l = new TreeNode(stoi(token));
                    cur->left = l;
                    q.push(l);
                }
            }

            if (getline(ss, token, ',')) {
                if (token != "#") {
                    auto r = new TreeNode(stoi(token));
                    cur->right = r;
                    q.push(r);
                }
            }
        }

        return root;
    }

   public:
    // Encodes a tree to a single string.
    string serialize(TreeNode* root) {
        if (root == nullptr)
            return "";

        string s = bfsSerialize(root);

        while (!s.empty() && (s.back() == ',' || s.back() == '#')) {
            s.pop_back();
        }

        return s;
    }

    // Decodes your encoded data to tree.
    TreeNode* deserialize(string data) {
        if (data == "")
            return nullptr;

        return bfsDeserialize(data);
    }
};

// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// TreeNode ans = deser.deserialize(ser.serialize(root));
}  // namespace _001_serialize_deserialize_tree

class Execute {
   public:
    static void Main() {
        _001_serialize_deserialize_tree::Codec s;

        vector<optional<int>> input = {1, 2, 3, nullopt, nullopt, 4, 5};
        input = {1, nullopt, 2, 3};
        auto root = TreeOperations::generate(input);

        string r = s.serialize(root);
        cout << r;

        TreeNode* rNode = s.deserialize(r);

        TreeOperations::print(rNode);
    }
};

int main() {
    Execute::Main();
    return 0;
}