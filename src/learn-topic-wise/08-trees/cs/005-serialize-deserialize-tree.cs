using System.Collections.Generic;
using System.Text;

namespace learning_dsa_csharp._07_trees._001_serialize_deserialize_tree
{
    public class Codec
    {
        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            if (root == null)
                return "";

            StringBuilder sb = new StringBuilder();
            BfsSerialize(root, sb);

            return sb.ToString().TrimEnd(',');
        }

        private void BfsSerialize(TreeNode root, StringBuilder sb)
        {
            if (root != null)
            {
                sb.Append(root.val.ToString() + ',');
                BfsSerialize(root.left, sb);
                BfsSerialize(root.right, sb);
            }
            else
            {
                sb.Append("#,");
                return;
            }
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (data == "")
                return null;

            Queue<string> q = new Queue<string>(data.Split(','));

            return BfsDesirialize(q);
        }

        private TreeNode BfsDesirialize(Queue<string> q)
        {
            string nodeValue = q.Dequeue();
            if (nodeValue == "#")
            {
                return null;
            }

            TreeNode node = new TreeNode(int.Parse(nodeValue));
            node.left = BfsDesirialize(q);
            node.right = BfsDesirialize(q);

            return node;
        }
    }

    // Your Codec object will be instantiated and called as such:
    // Codec ser = new Codec();
    // Codec deser = new Codec();
    // TreeNode ans = deser.deserialize(ser.serialize(root));
}
