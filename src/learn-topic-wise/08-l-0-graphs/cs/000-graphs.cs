namespace learning_dsa_csharp._11_graphs
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

    class Graphs
    {
        public static void Main(string[] args)
        {
            var g = new Graphs();

            // Clone graph
            // g.CloneGraph();

            // problem - https://leetcode.com/problems/pacific-atlantic-water-flow/
            // solution - https://www.youtube.com/watch?v=s-VkcjHqkGI
            // PacificAtlanticWaterFlow
            //g.PacificAtlanticWaterFlow();

            // problem - https://leetcode.com/problems/surrounded-regions/
            // solution - https://www.youtube.com/watch?v=9z2BunfoZ5Y
            //g.SurroundedRegions();

            // problem - https://leetcode.com/problems/rotting-oranges/
            // solution - my own
            //g.RottingOranges();

            // problem - https://leetcode.com/problems/network-delay-time/
            // solution - https://leetcode.com/problems/network-delay-time/solutions/1262456/c-simple-solution/
            //g.NetworkDelayTime();

            //g.FindTownJudge();

            // g.FindCheapestFlightPriceWithKStops();

            //g.IslandPerimeter();

            //g.NumberOfIsland();

            //g.FindAllGroupsOfFarmland();

            //g.FindPathInGraph();

            //g.OpenTheLock();

            //g.MinimumHeightTrees();

            //g.PathWithMaxGold();

            g.FindSafestPathInAGrid();
        }

        private void CloneGraph()
        {
            var s = new _002_clone_graph.Solution();

            var n1 = new Node(1);
            var n2 = new Node(2);
            var n3 = new Node(3);
            var n4 = new Node(4);

            n1.neighbors = new List<Node>() { n2, n4 };
            n2.neighbors = new List<Node>() { n1, n3 };
            n3.neighbors = new List<Node>() { n2, n4 };
            n4.neighbors = new List<Node>() { n1, n3 };

            var res = s.CloneGraph(n1);
            Console.WriteLine(res.val);
        }

        private void PacificAtlanticWaterFlow()
        {
            var s = new _003_pacific_atlantic_water_flow.Solution();

            int[][] heights = new int[5][];
            heights[0] = new int[5] { 1, 2, 2, 3, 5 };
            heights[1] = new int[5] { 3, 2, 3, 4, 4 };
            heights[2] = new int[5] { 2, 4, 5, 3, 1 };
            heights[3] = new int[5] { 6, 7, 1, 4, 5 };
            heights[4] = new int[5] { 5, 1, 1, 2, 4 };

            //int[][] heights = new int[4][];
            //heights[0] = new int[4] { 1, 2, 2, 3, };
            //heights[1] = new int[4] { 3, 2, 3, 4, };
            //heights[2] = new int[4] { 2, 4, 5, 3, };
            //heights[3] = new int[4] { 6, 7, 1, 4, };

            var res = s.PacificAtlantic(heights);

            foreach (var r in res)
            {
                Console.WriteLine(r[0] + " " + r[1]);
            }
        }

        private void SurroundedRegions()
        {
            var s = new _004_surrounded_regions.Solution();

            char[][] heights = new char[4][];
            heights[0] = new char[4] { 'x', 'x', 'x', 'x' };
            heights[1] = new char[4] { 'x', 'o', 'o', 'x' };
            heights[2] = new char[4] { 'x', 'x', 'o', 'x' };
            heights[3] = new char[4] { 'x', 'o', 'x', 'x' };

            s.Solve(heights);
        }

        private void RottingOranges()
        {
            var s = new _005_rotting_oranges.Solution();

            int[][] grid = new int[3][];
            grid[0] = new int[] { 2, 1, 1 };
            grid[1] = new int[] { 0, 1, 1 };
            grid[2] = new int[] { 1, 0, 2 };

            var res = s.OrangesRotting_BFS(grid);

            Console.WriteLine(res);
        }

        private void WordLadder()
        {
            var s = new _006_word_ladder.Solution();
            //var res = s.LadderLength();

            //Console.WriteLine(res);
        }

        private void NetworkDelayTime()
        {
            var s = new _007_network_delay_time_dijkstra_algorithm.Solution();

            //int[][] grid = new int[3][];
            //grid[0] = new int[] { 2, 1, 1 };
            //grid[1] = new int[] { 2, 3, 1 };
            //grid[2] = new int[] { 3, 4, 1 };
            //int n = 4, k = 2;

            //int[][] grid = new int[1][];
            //grid[0] = new int[] { 1, 2, 1 };
            //int n = 2, k = 2;

            int[][] grid = new int[][]
            {
                new int[] { 4, 2, 76 },
                new int[] { 1, 3, 79 },
                new int[] { 3, 1, 81 },
                new int[] { 4, 3, 30 },
                new int[] { 2, 1, 47 },
                new int[] { 1, 5, 61 },
                new int[] { 1, 4, 99 },
                new int[] { 3, 4, 68 },
                new int[] { 3, 5, 46 },
                new int[] { 4, 1, 6 },
                new int[] { 5, 4, 7 },
                new int[] { 5, 3, 44 },
                new int[] { 4, 5, 19 },
                new int[] { 2, 3, 13 },
                new int[] { 3, 2, 18 },
                new int[] { 1, 2, 0 },
                new int[] { 5, 1, 25 },
                new int[] { 2, 5, 58 },
                new int[] { 2, 4, 77 },
                new int[] { 5, 2, 74 }
            };
            int n = 5,
                k = 3;

            //var res = s.NetworkDelayTime_Dijkstra_PriorityQueue(grid, n, k);
            var res = s.NetworkDelayTime_BruteForce(grid, n, k);

            Console.WriteLine(res);
        }

        private void FindTownJudge()
        {
            var s = new _008_find_the_town_judge.OthersSoln();
            var r = s.FindJudge(
                3,
                [
                    [1, 3],
                    [2, 3]
                ]
            );

            Console.WriteLine(r);
        }

        private void FindCheapestFlightPriceWithKStops()
        {
            var s = new _009_find_cheapest_flight_price_with_k_stops.Soln_bellman_ford();
            var r = s.FindCheapestPrice(
                4,
                [
                    [0, 1, 100],
                    [1, 2, 100],
                    [2, 0, 100],
                    [1, 3, 600],
                    [2, 3, 200],
                ],
                0,
                3,
                1
            );

            Console.WriteLine(r);
        }

        private void IslandPerimeter()
        {
            // var s = new _010_island_perimeter.MySoln();
            var s = new _010_island_perimeter.OthersSoln_iterative();

            int[][] gridInput =
            [
                [0, 1, 0, 0],
                [1, 1, 1, 0],
                [0, 1, 0, 0],
                [1, 1, 0, 0]
            ];
            var r = s.IslandPerimeter(gridInput);

            Console.WriteLine(r);
        }

        private void NumberOfIsland()
        {
            var s = new _011_number_of_islands.MySoln();

            char[][] gridInput =
            [
                ['1', '1', '1', '1', '0'],
                ['1', '1', '0', '1', '0'],
                ['1', '1', '0', '0', '0'],
                ['0', '0', '1', '0', '1'],
                ['1', '0', '0', '1', '0']
            ];
            var r = s.NumIslands(gridInput);

            Console.WriteLine(r);
        }

        private void FindAllGroupsOfFarmland()
        {
            var s = new _012_find_all_groups_of_farmland.MySoln();

            int[][] gridInput =
            [
                [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1],
                [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1],
                [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1],
                [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1],
                [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1],
                [0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1],
                [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1],
                [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1],
                [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1],
                [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
            ];
            var r = s.FindFarmland(gridInput);

            Console.WriteLine(r);
        }

        private void FindPathInGraph()
        {
            var s = new _013_find_path_in_graph.YouTubeTakeYouForward_Soln();

            int n = 10;
            int[][] edges =
            [
                [0, 7],
                [0, 8],
                [6, 1],
                [2, 0],
                [0, 4],
                [5, 8],
                [4, 7],
                [1, 3],
                [3, 5],
                [6, 5]
            ];
            int source = 7;
            int des = 5;

            n = 6;
            edges =
            [
                [0, 1],
                [0, 2],
                [3, 5],
                [5, 4],
                [4, 3]
            ];
            source = 0;
            des = 5;

            var r = s.ValidPath(n, edges, source, des);

            Console.WriteLine(r);
        }

        private void OpenTheLock()
        {
            var s = new _014_open_the_lock.OthersSoln();

            string[] input = ["0201", "0101", "0102", "1212", "2002"];
            string t = "0202";

            var r = s.OpenLock(input, t);

            Console.WriteLine(r);
        }

        private void MinimumHeightTrees()
        {
            var s = new _015_minimum_height_trees.OthersSoln_remove_leaf_nodes();

            int n = 4;
            int[][] edges =
            [
                [1, 0],
                [1, 2],
                [1, 3],
                [3, 4],
                [2, 5],
                [5, 6],
            ];

            n = 7;
            edges =
            [
                [3, 0],
                [3, 1],
                [3, 2],
                [3, 4],
                [5, 4],
                [1, 6]
            ];

            var r = s.FindMinHeightTrees(n, edges);

            Console.WriteLine(r);
        }

        private void PathWithMaxGold()
        {
            var s = new _016_path_with_max_gold.MySoln();
            int[][] input =
            [
                [0, 6, 0],
                [5, 8, 7],
                [0, 9, 0]
            ];

            var r = s.GetMaximumGold(input);

            Console.WriteLine(r);
        }

        private void FindSafestPathInAGrid()
        {
            var s = new _017_find_a_safest_path_in_a_grid.OtherSoln_WithoutBinarySearch();
            int[][] input =
            [
                [0, 0, 0, 1],
                [0, 0, 0, 0],
                [0, 0, 0, 0],
                [1, 0, 0, 0]
            ];

            input =
            [
                [0, 0, 1, 1],
                [0, 0, 0, 0],
                [1, 0, 0, 0],
            ];

            var r = s.MaximumSafenessFactor(input);

            Console.WriteLine(r);
        }
    }
}
