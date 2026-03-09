namespace learning_dsa_csharp._01_strings_arrays_hash._010_redistribute_chars_make_all_strings_equal
{
    // problem - https://leetcode.com/problems/redistribute-characters-to-make-all-strings-equal/description/
    internal class Solution
    {
        public bool MakeEqual(string[] words)
        {
            // keep total count of all the chars across all words in one common dictionary
            // example
            // "abc","aabc","bc"
            // dictionary a: 3, b: 3, c: 3
            // check below comment to see why we are doing so
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            foreach (var word in words)
            {
                foreach (var c in word)
                {
                    if (!charCount.ContainsKey(c))
                    {
                        charCount[c] = 0;
                    }
                    charCount[c] += 1;
                }
            }

            foreach (var item in charCount)
            {
                // now divinding the count by total length of the words array tells us all the words
                // can be made equal after char rearrange
                if (item.Value % words.Length != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
