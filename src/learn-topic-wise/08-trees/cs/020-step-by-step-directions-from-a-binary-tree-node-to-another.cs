using System.Text;

namespace learning_dsa_csharp._07_trees._020_step_by_step_directions_from_a_binary_tree_node_to_another
{
    internal class MySoln
    {
        public string GetDirections(TreeNode root, int startValue, int destValue)
        {
            List<char> dfs(TreeNode n, List<char> p, int t)
            {
                if (n == null)
                {
                    return [];
                }

                if (n.val == t)
                    return p;

                p.Add('L');
                var res = dfs(n.left, p, t);
                if (res.Count > 0)
                    return res;

                // because the path is passed by reference
                p.RemoveAt(p.Count - 1);
                p.Add('R');
                res = dfs(n.right, p, t);
                if (res.Count > 0)
                    return res;

                // because the path is passed by reference
                p.RemoveAt(p.Count - 1);
                return [];
            }

            var sPath = dfs(root, [], startValue);
            var dPath = dfs(root, [], destValue);

            // the repeated charactors in both array indicates a common ancestor
            // and that does not belong in a path
            //    1
            //   2 3
            // 4 5 6 7
            // s = 4, d = 5
            // sPath is LL and dPath is LR but answer is suppose to be UR
            int startInd = 0;
            while (startInd < Math.Min(sPath.Count, dPath.Count))
            {
                if (sPath[startInd] != dPath[startInd])
                {
                    break;
                }

                startInd++;
            }

            // replace the start path array with 'U', because they all will
            // be up
            StringBuilder sr = new StringBuilder();
            for (int i = startInd; i < sPath.Count; ++i)
            {
                sr.Append('U');
            }

            // keep the destination path as it is
            for (int i = startInd; i < dPath.Count; ++i)
            {
                sr.Append(dPath[i]);
            }

            return sr.ToString();
        }
    }
}
