export const url =
  '[Find Common Characters](https://leetcode.com/problems/find-common-characters/)';

function commonChars(words: string[]): string[] {
  const wMap: number[] = Array(26).fill(Infinity);

  for (const w of words) {
    const temp: number[] = new Array(26).fill(0);
    for (let i = 0; i < w.length; ++i) {
      ++temp[w.charCodeAt(i) - 'a'.charCodeAt(0)];
    }

    // Update global frequency with minimum counts
    for (let i = 0; i < 26; i++) {
      wMap[i] = Math.min(wMap[i], temp[i]);
    }
  }

  const res: string[] = [];
  for (let i = 0; i < 26; ++i) {
    for (let j = 0; j < wMap[i]; j++) {
      res.push(String.fromCharCode(97 + i));
    }
  }
  return res;
}

var input = ['bella', 'label', 'roller'];
// var input = [
//   'acabcddd',
//   'bcbdbcbd',
//   'baddbadb',
//   'cbdddcac',
//   'aacbcccd',
//   'ccccddda',
//   'cababaab',
//   'addcaccd',
// ];
var out = commonChars(input);

console.log(out);
