using System.Collections.Generic;
using System.Text;

namespace learning_dsa_csharp._13_1_d_dynamic_programming._010_string_compression
{
    internal class Solution
    {
        // https://leetcode.com/problems/string-compression/
        // own solution
        public int Compress_iterative(char[] chars)
        {
            char prev = chars[0];
            int gLen = 1;
            int writeIndex = 0;
            for (int i = 1; i < chars.Length; i++)
            {
                char currChar = chars[i];
                if (currChar == prev)
                {
                    gLen++;
                }
                else
                {
                    compressCharGroup();
                }

                prev = currChar;
            }

            compressCharGroup();

            return writeIndex;

            void compressCharGroup()
            {
                // for last group
                chars[writeIndex] = prev;
                writeIndex++;

                if (gLen > 1)
                {
                    if (gLen >= 10)
                    {
                        string gLenStr = gLen.ToString();
                        for (int j = 0; j < gLenStr.Length; j++)
                        {
                            chars[writeIndex] = gLenStr[j].ToString()[0];
                            writeIndex++;
                        }
                    }
                    else
                    {
                        chars[writeIndex] = gLen.ToString()[0];
                        writeIndex++;
                    }

                    gLen = 1;
                }
            }
        }

        // https://leetcode.com/problems/string-compression-ii/description/
        public int GetLengthOfOptimalCompression(string s, int k)
        {
            var cGrp = compressString();
            var resStrLen = compressionByRemovingChars(cGrp);
            return resStrLen;

            List<(char, int)> compressString()
            {
                char prev = s[0];
                int gLen = 1;
                List<(char, int)> charGroup = new List<(char, int)>();
                for (int i = 1; i < s.Length; i++)
                {
                    char currChar = s[i];
                    if (currChar == prev)
                    {
                        gLen++;
                    }
                    else
                    {
                        compressCharGroup();
                    }

                    prev = currChar;
                }

                compressCharGroup();

                return charGroup;

                void compressCharGroup()
                {
                    // for last group
                    charGroup.Add((prev, gLen));

                    gLen = 1;
                }
            }

            // fails for the basic case of "aabbaa" where the output should be a4, as all the 'b' should be removed and 'a' should be merged to form string a4
            int compressionByRemovingChars(List<(char, int)> charGroups)
            {
                var charGroupAfterRemovingChars = compressDFS(charGroups, k);
                return charGroupAfterRemovingChars.Length;

                string compressDFS(List<(char, int)> curCharGroups, int l)
                {
                    if (l == 0)
                    {
                        StringBuilder sbRes = new StringBuilder();
                        for (int i = 0; i < curCharGroups.Count; i++)
                        {
                            var (charVal, charCount) = curCharGroups[i];
                            if (charCount != 0)
                            {
                                if (charCount > 1)
                                {
                                    sbRes.Append($"{charVal}{charCount}");
                                }
                                else
                                {
                                    sbRes.Append(charVal);
                                }
                            }
                        }
                        return sbRes.ToString();
                    }

                    string minCharGroupAfterRemovingChars = null;
                    for (int i = 0; i < curCharGroups.Count; i++)
                    {
                        var (charVal, charCount) = curCharGroups[i];

                        if (charCount > 0)
                        {
                            curCharGroups[i] = (charVal, charCount - 1);

                            var curSubSeqAfterRemovingChar = compressDFS(curCharGroups, l - 1);

                            if (minCharGroupAfterRemovingChars == null)
                            {
                                minCharGroupAfterRemovingChars = curSubSeqAfterRemovingChar;
                            }
                            else
                            {
                                if (
                                    minCharGroupAfterRemovingChars.Length
                                    > curSubSeqAfterRemovingChar.Length
                                )
                                {
                                    minCharGroupAfterRemovingChars = curSubSeqAfterRemovingChar;
                                }
                            }

                            curCharGroups[i] = (charVal, charCount);
                        }
                    }

                    return minCharGroupAfterRemovingChars;
                }
            }
        }
    }
}
