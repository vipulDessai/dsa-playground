export const url =
  '[Expressive Words](https://leetcode.com/problems/expressive-words/description/)';

function expressiveWords(s: string, words: string[]): number {
  const tMap = new Map<string, number>();

  for (const c of s) {
    tMap.set(c, (tMap.get(c) || 0) + 1);
  }

  let res = 0;
  for (const w of words) {
    const wMap = new Map<string, number>();

    for (const c of w) {
      wMap.set(c, (wMap.get(c) || 0) + 1);
    }

    if (wMap.size === tMap.size) {
      let valid = true;
      for (const [k, v] of tMap) {
        if (v >= 3) {
          if (wMap.has(k)) {
            const count = wMap.get(k)!;
            if (count > v) {
              valid = false;
            }
          } else {
            valid = false;
          }
        } else {
          if (v !== wMap.get(k)) {
            valid = false;
          }
        }
      }

      if (valid) {
        ++res;
      }
    }
  }

  return res;
}

var s = '',
  w = ['hello', 'hi', 'helo'];
console.log(expressiveWords(s, w));
