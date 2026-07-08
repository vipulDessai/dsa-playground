// https://leetcode.com/problems/serialize-and-deserialize-binary-tree/description/

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
    string bfsSerialize(TreeNode* root, string s) {
        if (root != nullptr) {
            s += root->val + ',';
            s += bfsSerialize(root->left, s);
            s += bfsSerialize(root->right, s);
        } else {
            s += "#,";
        }

        return s;
    }
    TreeNode* bfsDesirialize(queue<string> q) {
        string nodeValue = q.front();
        q.pop();
        if (nodeValue == "#") {
            return nullptr;
        }

        TreeNode* node = new TreeNode(stoi(nodeValue));
        node->left = bfsDesirialize(q);
        node->right = bfsDesirialize(q);

        return node;
    }
    
   public:
    // Encodes a tree to a single string.
    string serialize(TreeNode* root) {
        if (root == nullptr)
            return "";

        string s = bfsSerialize(root, "");

        if(!s.empty() && s.back() == ',') {
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
        while (getline(ss, token, ',')) {
            q.push(token);
        }

        return bfsDesirialize(q);
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