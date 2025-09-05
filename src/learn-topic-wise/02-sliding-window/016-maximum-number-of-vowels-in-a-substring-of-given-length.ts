export const url =
  '[Maximum Number of Vowels in a Substring of Given Length](https://leetcode.com/problems/maximum-number-of-vowels-in-a-substring-of-given-length/description/)';

function isVowel(c: string) {
  return c === 'a' || c === 'e' || c === 'i' || c === 'o' || c === 'u';
}

function maxVowels(s: string, k: number): number {
  const n = s.length;
  let l = 0,
    r = 0,
    res = 0,
    sum = 0;

  while (r < k) {
    if (isVowel(s[r])) {
      ++sum;
    }

    ++r;
  }

  --r;

  while (r < n) {
    res = Math.max(res, sum);

    if (isVowel(s[l])) {
      --sum;
    }
    ++l;

    ++r;
    if (isVowel(s[r])) {
      ++sum;
    }
  }

  return res;
}

var input = 'abciiidef',
  k = 3;
var out = maxVowels(input, k);

console.log(out);
