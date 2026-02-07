// https://leetcode.com/problems/create-binary-tree-from-descriptions/?envType=daily-question&envId=2024-07-15
namespace learning_dsa_csharp._07_trees._001_contruct_a_binary_tree
{
    internal class MySoln
    {
        public TreeNode CreateBinaryTree(int[][] descriptions)
        {
            Dictionary<int, int?[]> adjList = new Dictionary<int, int?[]>();
            HashSet<int> rootFinder = new HashSet<int>();
            foreach (var d in descriptions)
            {
                int p = d[0];
                int c = d[1];
                bool isLeft = d[2] == 1;

                if (!adjList.ContainsKey(p))
                {
                    adjList.Add(p, [null, null]);
                }

                if (isLeft)
                {
                    adjList[p][0] = c;
                }
                else
                {
                    adjList[p][1] = c;
                }

                rootFinder.Add(p);
            }

            foreach (var (k, v) in adjList)
            {
                var lC = v[0];
                var rC = v[1];

                if (lC != null && rootFinder.Contains((int)lC))
                {
                    rootFinder.Remove((int)lC);
                }
                if (rC != null && rootFinder.Contains((int)rC))
                {
                    rootFinder.Remove((int)rC);
                }
            }

            int rootVal = rootFinder.ToArray()[0];

            TreeNode dfs(int nVal)
            {
                TreeNode curNode = new TreeNode(nVal);
                if (adjList.ContainsKey(nVal))
                {
                    if (adjList[nVal][0] != null)
                    {
                        curNode.left = dfs((int)adjList[nVal][0]);
                    }

                    if (adjList[nVal][1] != null)
                    {
                        curNode.right = dfs((int)adjList[nVal][1]);
                    }
                }

                return curNode;
            }

            TreeNode root = dfs(rootVal);

            return root;
        }
    }
}
