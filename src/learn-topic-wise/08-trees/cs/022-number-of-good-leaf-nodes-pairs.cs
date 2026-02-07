// https://leetcode.com/problems/number-of-good-leaf-nodes-pairs
namespace learning_dsa_csharp._07_trees._022_number_of_good_leaf_nodes_pairs
{
    // https://leetcode.com/problems/number-of-good-leaf-nodes-pairs/solutions/5493689/detailed-easy-java-python3-c-solution-189-ms/?envType=daily-question&envId=2024-07-18
    internal class OthersSoln
    {
        private void FindLeaves(
            TreeNode node,
            List<TreeNode> trail,
            List<TreeNode> leaves,
            Dictionary<TreeNode, List<TreeNode>> map
        )
        {
            if (node == null)
                return;
            List<TreeNode> tmp = trail.ToList();
            tmp.Add(node);
            if (node.left == null && node.right == null)
            {
                map.Add(node, tmp);
                leaves.Add(node);
                return;
            }
            FindLeaves(node.left, tmp, leaves, map);
            FindLeaves(node.right, tmp, leaves, map);
        }

        public int CountPairs(TreeNode root, int distance)
        {
            Dictionary<TreeNode, List<TreeNode>> map = new();
            List<TreeNode> leaves = new();
            FindLeaves(root, new(), leaves, map);
            int res = 0;
            for (int i = 0; i < leaves.Count(); i++)
            {
                for (int j = i + 1; j < leaves.Count(); j++)
                {
                    List<TreeNode> list_i = map[leaves[i]];
                    List<TreeNode> list_j = map[leaves[j]];

                    for (int k = 0; k < Math.Min(list_i.Count(), list_j.Count); k++)
                    {
                        if (list_i[k] != list_j[k])
                        {
                            int dist = list_i.Count - k + list_j.Count - k;
                            if (dist <= distance)
                                res++;
                            break;
                        }
                    }
                }
            }

            return res;
        }
    }
}
