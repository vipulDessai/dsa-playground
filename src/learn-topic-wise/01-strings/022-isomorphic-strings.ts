export const url =
  '[Isomorphic Strings](https://leetcode.com/problems/isomorphic-strings/)';

function isIsomorphic(s: string, t: string): boolean {
  let m1 = Array(26).fill(0),
    m2 = Array(26).fill(0);

  // Traverse all elements through the loop...
  for (let i = 0; i < s.length; ++i) {
    // Compare the maps, if not equal, return false...
    if (m1[s[i]] != m2[t[i]]) return false;

    // Insert each character if string s and t into seperate map...
    m1[s[i]] = i + 1;
    m2[t[i]] = i + 1;
  }

  return true;
}

var s1 = 'egg',
  s2 = 'add';
var out = isIsomorphic(s1, s2);

console.log(out);
