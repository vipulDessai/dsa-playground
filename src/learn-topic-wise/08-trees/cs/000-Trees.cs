namespace learning_dsa_csharp._07_trees
{
    public class TreeNode
    {
        public int? val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int? x)
        {
            val = x;
        }

        public TreeNode(int? v, TreeNode? l, TreeNode? r)
        {
            val = v;
            left = l;
            right = r;
        }
    }

    internal class DS
    {
        public static void Main(string[] args)
        {
            var ds = new DS();

            // basic tree traversal
            //t.TreaverTree();

            //t.ContructBST();

            // problem - https://leetcode.com/problems/serialize-and-deserialize-binary-tree/
            // solution - https://www.youtube.com/watch?v=-YbXySKJsX8
            //t.SerializeDeserializeTree();

            // problem - https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree
            // solution - own
            //t.LowestCommonAncestor();

            // problem - https://leetcode.com/problems/range-sum-of-bst/?envType=daily-question&envId=2024-01-08
            // solution - own
            //t.RangeSumBST();

            // problem - https://leetcode.com/problems/leaf-similar-trees/
            // solution - own
            //t.LeafSimilarTrees();

            // problem - https://leetcode.com/problems/leaf-similar-trees/
            //t.AmountOfTImeForBinaryTreeToBeInfected();

            // problem - https://leetcode.com/problems/maximum-difference-between-node-and-ancestor/
            //t.MaxAncestorDiff();

            // t.PseudoPalindromicPathsInBinaryTree();

            //t.DiameterOfBinaryTree();

            //t.SumRootToLeafNumbers();

            // t.AddOneRowToTree();

            // t.SmallestStringStartingFromLeaf();

            //t.DeleteLeavesWithGivenValue();

            // t.DistributeCoinInATree();

            // t.BST2GST();

            //t.BalanceBST();

            // t.FindCenterStarGraph();

            // t.MaxTotalImportanceOfRaoads();

            //t.AllAncestorsOfANodeInADAG();

            //t.StepByStepDirectionsFromABinaryTreeNodeToAnother();

            //t.DeleteNodesAndReturnForest();

            // t.NumberOfGoodNodes();

            ds.PathWithMaxProbability();
        }

        // TODO: fix the failing AC
        // InitTree(new int?[] { 1, 5, 3, null, 4, 10, 6, 9, 2 });
        // the left child of the 5 has null, so no need to add 2 null at 7,8 indexes
        // InitTree(new int?[] { 1, 5, 3, null, 4, 10, 6, null, null, 9, 2 });
        private TreeNode InitTree(int?[] treeList)
        {
            if (treeList.Length == 0)
            {
                return null;
            }

            return Bfs(new TreeNode(treeList[0]), 0);

            TreeNode Bfs(TreeNode n, int level)
            {
                var nextL_index = 2 * level + 1;
                var nextR_index = 2 * level + 2;

                var l = nextL_index < treeList.Length ? treeList[nextL_index] : null;
                var r = nextR_index < treeList.Length ? treeList[nextR_index] : null;

                if (l != null)
                {
                    n.left = Bfs(new TreeNode(l), nextL_index);
                }

                if (r != null)
                {
                    n.right = Bfs(new TreeNode(r), nextR_index);
                }

                return n;
            }
        }

        private void ContructBST()
        {
            var s = new _001_contruct_a_binary_tree.MySoln();
            int[][] edges =
            [
                [20, 15, 1],
                [20, 17, 0],
                [50, 20, 1],
                [50, 80, 0],
                [80, 19, 1]
            ];
            var res = s.CreateBinaryTree(edges);
            Console.WriteLine(res);
        }

        private void TreaverTree()
        {
            var t = InitTree(new int?[] { 1, 2, 3, 4, 5 });

            //var dfs = new _001_dfs_bfs.DFS_Inorder_Preorder_PostOrder();
            //dfs.traverseTree(t);

            var bfs = new _001_dfs_bfs.BFS_Level_order_traversal();
            bfs.traverseTree(t);
        }

        private void SerializeDeserializeTree()
        {
            var s = new _001_serialize_deserialize_tree.Codec();

            var t = InitTree(new int?[] { 1, 2, 3, null, null, 4, 5 });
            t = InitTree(new int?[] { 3, 5, 1, 6, 2, 0, 8, null, null, 7, 4, });

            var treeSerialized = s.serialize(t);
            var treeDeSeriazlized = s.deserialize(treeSerialized);

            Console.WriteLine(treeDeSeriazlized.val);
        }

        private void LowestCommonAncestor()
        {
            var s = new _002_lowest_common_ancester.Solution();

            TreeNode t = null;
            //t = InitTree(new int?[] { 3, 5, 1, 6, 2, 0, 8, null, null, 7, 4 });
            t = InitTree(
                new int?[]
                {
                    6,
                    2,
                    8,
                    0,
                    4,
                    7,
                    9,
                    null,
                    null,
                    3,
                    5,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    10,
                    11,
                    null,
                    null,
                    13,
                    12
                }
            );
            t = InitTree(
                new int?[]
                {
                    3,
                    5,
                    1,
                    6,
                    2,
                    0,
                    8,
                    null,
                    null,
                    7,
                    4,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    9,
                    10
                }
            );

            var p = new TreeNode(7);
            var q = new TreeNode(4);
            var r = s.LowestCommonAncestor(t, p, q);

            Console.WriteLine(r);
        }

        private void RangeSumBST()
        {
            var s = new _003_range_sum_of_bst.Solution();

            var t = InitTree(new int?[] { 10, 5, 15, 3, 7, null, 18 });
            int l = 7;
            int h = 15;

            var r = s.RangeSumBST(t, l, h);

            Console.WriteLine(r);
        }

        private void LeafSimilarTrees()
        {
            var s = new _004_leaf_similar_trees.Solution();

            var r1 = InitTree(new int?[] { 3, 5, 1, 6, 2, 9, 8, null, null, 7, 4 });
            var r2 = InitTree(
                new int?[] { 3, 5, 1, 6, 7, 4, 2, null, null, null, null, null, null, 9, 8 }
            );

            //r1 = InitTree(new int?[] { 1, 2, 3 });
            //r2 = InitTree(new int?[] { 1, 3, 2 });

            var r = s.LeafSimilar_queue(r1, r2);

            Console.WriteLine(r);
        }

        private void AmountOfTImeForBinaryTreeToBeInfected()
        {
            var s = new _006_amount_of_time_to_infect_tree.DFS_Graph_Hash_My_Own_Solution();

            var t = InitTree(new int?[] { 1, 5, 3, null, 4, 10, 6, null, null, 9, 2 });
            int start = 3;
            var res = s.AmountOfTime(t, start);

            Console.WriteLine(res);
        }

        private void MaxAncestorDiff()
        {
            var s = new _007_max_diff_btw_node_and_ancestor.Solution();

            var t = InitTree(
                new int?[] { 8, 3, 10, 1, 6, null, 14, null, null, 4, 7, null, null, 13 }
            );
            t = InitTree(new int?[] { 1, null, 2, null, null, null, 0, null, null, null, null, 3 });
            var res = s.MaxAncestorDiff(t);

            Console.WriteLine(res);
        }

        private void PseudoPalindromicPathsInBinaryTree()
        {
            var s = new _008_pseudo_palindromic_paths_in_binary_tree.Soln_Bit_manipulation();

            var t = InitTree(new int?[] { 2, 3, 1, 3, 1, null, 1 });
            var res = s.PseudoPalindromicPaths(t);

            Console.WriteLine(res);
        }

        private void DiameterOfBinaryTree()
        {
            var s = new _009_diameter_of_binary_tree.OthersSoln();

            var t = InitTree([1, 2, 3, 4, 5]);
            var res = s.DiameterOfBinaryTree(t);

            Console.WriteLine(res);
        }

        private void SumRootToLeafNumbers()
        {
            var s = new _010_sum_root_to_leaf_numbers.MySoln();

            var t = InitTree([1, 2, 3]);
            var res = s.SumNumbers(t);

            Console.WriteLine(res);
        }

        private void AddOneRowToTree()
        {
            var s = new _011_add_one_row_to_a_tree.MySoln();

            var t = InitTree([4, 2, 6, 3, 1, 5]);
            int val = 1;
            int depth = 2;

            t = InitTree([4, 2, null, 3, 1]);
            val = 1;
            depth = 3;

            var res = s.AddOneRow(t, val, depth);

            Console.WriteLine(res);
        }

        private void SmallestStringStartingFromLeaf()
        {
            var s = new _012_smallest_string_starting_from_leaf.MySoln();

            var t = InitTree([0, 1, 2, 3, 4, 3, 4]);

            var res = s.SmallestFromLeaf(t);
            Console.WriteLine(res);
        }

        private void DeleteLeavesWithGivenValue()
        {
            var s = new _013_delete_leaves_with_a_given_values.MySoln();

            var t = InitTree([1, 2, 3, 2, null, 2, 4]);
            var target = 2;

            var res = s.RemoveLeafNodes(t, target);
            Console.WriteLine(res);
        }

        private void DistributeCoinInATree()
        {
            var s = new _014_distribute_coins_in_a_tree.OthersSoln();

            var t = InitTree([0, 3, 0, 0, 1, 0, 2]);

            var res = s.DistributeCoins(t);
            Console.WriteLine(res);
        }

        private void BST2GST()
        {
            var s = new _015_binary_search_tree_to_greater_sum_tree.MySoln();

            var t = InitTree([4, 1, 6, 0, 2, 5, 7, null, null, null, 3, null, null, null, 8]);

            var res = s.BstToGst(t);
            Console.WriteLine(res);
        }

        private void BalanceBST()
        {
            var s = new _016_balance_a_binary_search_tree.OthersSoln();

            var t = InitTree([1, null, 2, null, 3, null, 4]);

            var res = s.BalanceBST(t);
            Console.WriteLine(res);
        }

        private void FindCenterStarGraph()
        {
            var s = new _017_find_center_of_star_graph.OthersSoln();

            var res = s.FindCenter(
                [
                    [1, 2],
                    [2, 3],
                    [4, 2]
                ]
            );
            Console.WriteLine(res);
        }

        private void MaxTotalImportanceOfRaoads()
        {
            var s = new _018_maximum_total_importance_of_roads.MySoln();
            int n = 5;
            int[][] roads =
            [
                [0, 1],
                [1, 2],
                [2, 3],
                [0, 2],
                [1, 3],
                [2, 4]
            ];
            var res = s.MaximumImportance(n, roads);
            Console.WriteLine(res);
        }

        private void AllAncestorsOfANodeInADAG()
        {
            var s = new _019_all_ancestors_of_a_node_in_a_directed_acyclic_graph.MySoln();
            int n = 8;
            int[][] edges =
            [
                [0, 3],
                [0, 4],
                [1, 3],
                [2, 4],
                [2, 7],
                [3, 5],
                [3, 6],
                [3, 7],
                [4, 6]
            ];
            var res = s.GetAncestors(n, edges);
            Console.WriteLine(res);
        }

        private void StepByStepDirectionsFromABinaryTreeNodeToAnother()
        {
            var s = new _020_step_by_step_directions_from_a_binary_tree_node_to_another.MySoln();
            int startValue = 3,
                destValue = 6;
            TreeNode inTree = InitTree([5, 1, 2, 3, null, 6, 4]);
            var res = s.GetDirections(inTree, startValue, destValue);

            Console.WriteLine(res);
        }

        private void DeleteNodesAndReturnForest()
        {
            var s = new _021_delete_nodes_and_return_forest.MySoln();
            int[] to_delete = [3, 5];
            TreeNode inTree = InitTree([1, 2, 3, 4, 5, 6, 7]);
            var res = s.DelNodes(inTree, to_delete);

            Console.WriteLine(res);
        }

        private void NumberOfGoodNodes()
        {
            var s = new _022_number_of_good_leaf_nodes_pairs.OthersSoln();
            int distance = 3;
            TreeNode inTree = InitTree([1, 2, 3, null, 4]);
            var res = s.CountPairs(inTree, distance);

            Console.WriteLine(res);
        }

        private void PathWithMaxProbability()
        {
            var s = new _023_path_with_maximum_probability.MySoln();
            int n = 3,
                start = 0,
                end = 2;
            int[][] edges =
            [
                [0, 1],
                [1, 2],
                [0, 2]
            ];
            double[] succProb = [0.5, 0.5, 0.2];

            var res = s.MaxProbability(n, edges, succProb, start, end);

            Console.WriteLine(res);
        }
    }
}
