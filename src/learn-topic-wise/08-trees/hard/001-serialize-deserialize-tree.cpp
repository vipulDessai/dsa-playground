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
class Codec_OthersSoln {
   private:
    string bfsSerialize(TreeNode* root) {
        queue<optional<TreeNode*>> q;

        string s = "";

        q.push(root);

        while (q.size() > 0) {
            int qLen = q.size();

            for (int i = 0; i < qLen; ++i) {
                optional<TreeNode*> cur = q.front();
                q.pop();

                if (!cur.has_value()) {
                    s += "#,";
                    continue;
                }

                TreeNode* validCur = cur.value();

                s += to_string(validCur->val) + ',';

                if (validCur->left != nullptr) {
                    q.push(validCur->left);
                } else {
                    q.push(nullopt);
                }

                if (validCur->right != nullptr) {
                    q.push(validCur->right);
                } else {
                    q.push(nullopt);
                }
            }
        }

        return s;
    }
    TreeNode* dfsDesirialize(queue<string> q) {
        string nodeValue = q.front();
        q.pop();
        if (nodeValue == "#") {
            return nullptr;
        }

        // stoi converts string to int
        TreeNode* node = new TreeNode(stoi(nodeValue));
        node->left = dfsDesirialize(q);
        node->right = dfsDesirialize(q);

        return node;
    }

   public:
    // Encodes a tree to a single string.
    string serialize(TreeNode* root) {
        if (root == nullptr)
            return "";

        string s = bfsSerialize(root);

        if (!s.empty() && s.back() == ',') {
            s.pop_back();
        }

        return s;
    }

    // Decodes your encoded data to tree.
    TreeNode* deserialize(string data) {
        if (data == "")
            return nullptr;

        queue<string> q;

        stringstream ss(data);
        string token;

        // split the string by , like in JS arr.split(',')
        while (getline(ss, token, ',')) {
            q.push(token);
        }

        return dfsDesirialize(q);
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
        _001_serialize_deserialize_tree::Codec_OthersSoln s;

        vector<optional<int>> input = {1, 2, 3, nullopt, nullopt, 4, 5};
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