export const url =
  '[Valid Anagram](https://leetcode.com/problems/valid-anagram/)';

// for O(s + t), space O(s + t)
const checkValidAnagram = (s: string, t: string) => {
  if (s.length !== t.length) {
    return false;
  }

  const countS = {};
  const countT = {};

  for (let index = 0; index < s.length; index++) {
    countS[s[index]] = 1 + (countS[s[index]] || 0);
    countT[s[index]] = 1 + (countT[t[index]] || 0);
  }

  for (const key in countS) {
    if (countS[key] !== countT[key]) return false;
  }

  return true;
};

checkValidAnagram('foo', 'ofo');
checkValidAnagram('bar', 'zba');
