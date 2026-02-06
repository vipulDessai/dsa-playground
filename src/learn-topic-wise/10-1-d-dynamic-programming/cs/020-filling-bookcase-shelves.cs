namespace learning_dsa_csharp._13_1_d_dynamic_programming._020_filling_bookcase_shelves
{
    internal class OthersSoln
    {
        public int MinHeightShelves(int[][] books, int shelfWidth)
        {
            int[][] memo = new int[books.Length][];
            for (int i = 0; i < memo.Length; ++i)
            {
                memo[i] = new int[shelfWidth + 1];
            }

            int helper(int currWidth, int height, int index)
            {
                if (index == books.Length)
                    return height;
                else if (memo[index][currWidth] != 0)
                    return memo[index][currWidth];
                if (currWidth < books[index][0])
                {
                    return memo[index][currWidth] =
                        helper(shelfWidth - books[index][0], books[index][1], index + 1) + height;
                }

                int include = helper(
                    currWidth - books[index][0],
                    Math.Max(books[index][1], height),
                    index + 1
                );
                int exclude =
                    helper(shelfWidth - books[index][0], books[index][1], index + 1) + height;

                return memo[index][currWidth] = Math.Min(include, exclude);
            }

            return helper(shelfWidth, 0, 0);
        }
    }
}
