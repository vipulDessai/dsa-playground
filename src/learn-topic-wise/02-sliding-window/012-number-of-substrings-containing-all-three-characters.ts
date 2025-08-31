export const url =
  '[Number of Substrings Containing All Three Characters](https://leetcode.com/problems/number-of-substrings-containing-all-three-characters/)';

function numberOfSubstrings(s: string): number {
  let count = { a: 0, b: 0, c: 0 };
  let left = 0,
    result = 0;

  for (let right = 0; right < s.length; right++) {
    count[s[right]]++;

    while (count.a > 0 && count.b > 0 && count.c > 0) {
      // Let’s say s = "abcabc" and right = 2 (we just hit "abc"):
      // Valid substrings: "abc", "abca", "abcab", "abcabc"
      // Count: s.length - right = 6 - 2 = 4
      // But r - l + 1 = 3, which only counts the window itself — not the suffixes that extend beyond right.
      result += s.length - right;
      count[s[left]]--;
      left++;
    }
  }

  return result;
}

var input = 'abcabc';
var out = numberOfSubstrings(input);

console.log(out);
