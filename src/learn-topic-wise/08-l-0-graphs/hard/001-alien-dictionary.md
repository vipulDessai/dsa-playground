# [Alien Dictionary — LeetCode #269 (Hard) 🔒 Premium](https://leetcode.com/problems/alien-dictionary/)

## Problem

There's a new alien language using the lowercase English letters, but the
**order of the letters is unknown** to you. You're given a list of words
`words` from the alien language's dictionary, **sorted lexicographically** by
the rules of this unknown language.

Return a string of the unique letters in the new alien language, sorted in the
alien language's order. If there is no valid ordering, return `""`. If there are
multiple valid orderings, return **any** of them.

## Examples

```
Input:  words = ["wrt","wrf","er","ett","rftt"]
Output: "wertf"

Input:  words = ["z","x"]
Output: "zx"

Input:  words = ["z","x","z"]
Output: ""        // invalid ordering — contradiction
```

## Constraints

- `1 <= words.length <= 100`
- `1 <= words[i].length <= 100`
- `words[i]` consists of only lowercase English letters.
