namespace Utils
{
    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }

    public static class NodeGraph
    {
        public static Node Generate(int[][] arr)
        {
            int n = arr.Length;

            Node[] nodeList = new Node[4];

            for (int i = 0; i < n; ++i)
            {
                nodeList[i] = new Node(i + 1);
            }

            for (int i = 0; i < n; ++i)
            {
                var n1 = arr[i][0];
                var n2 = arr[i][1];

                nodeList[i].neighbors.Add(nodeList[n1 - 1]);
                nodeList[i].neighbors.Add(nodeList[n2 - 1]);
            }

            return nodeList[0];
        }
    }
}