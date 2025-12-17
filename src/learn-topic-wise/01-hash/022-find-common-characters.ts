export const url =
  '[Find Common Characters](https://leetcode.com/problems/find-common-characters/)';

function commonChars(words: string[]): string[] {
  const n = words.length;
  const wMap: number[] = Array(26).fill(0);

  for (const w of words) {
    for (let i = 0; i < w.length; ++i) {
      ++wMap[w.charCodeAt(i) - 'a'.charCodeAt(0)];
    }
  }

  const res: string[] = [];
  for (let i = 0; i < 26; ++i) {
    if (wMap[i] >= n) {
      let count = Math.floor(wMap[i] / n);
      while (count > 0) {
        res.push(String.fromCharCode(97 + i));
        --count;
      }
    }
  }
  return res;
}

var input = ['bella', 'label', 'roller'];
var out = commonChars(input);

console.log(out);
