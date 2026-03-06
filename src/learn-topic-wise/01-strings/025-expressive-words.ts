export const url =
  '[Expressive Words](https://leetcode.com/problems/expressive-words/description/)';

// faster
function expressiveWords_twoPointers(s: string, words: string[]): number {
  const isStretchy = (word: string): boolean => {
    let i = 0,
      j = 0;
    while (i < s.length && j < word.length) {
      if (s[i] !== word[j]) return false;

      let lenS = 0,
        lenW = 0;
      while (i + lenS < s.length && s[i + lenS] === s[i]) lenS++;
      while (j + lenW < word.length && word[j + lenW] === word[j]) lenW++;

      if (lenS === lenW || (lenS >= 3 && lenW <= lenS)) {
        i += lenS;
        j += lenW;
      } else {
        return false;
      }
    }

    return i === s.length && j === word.length;
  };

  return words.filter(isStretchy).length;
}

var s = 'heeellooo',
  w = ['hello', 'hi', 'helo'];
// console.log(expressiveWords_twoPointers(s, w));

// slower
function expressiveWords_precompute(s: string, words: string[]): number {
  function group(word: string) {
    const wordMap: [string, number][] = [];
    let i = 0;
    while (i < word.length) {
      let gLen = 0;
      while (i < word.length && word[i] === word[i + gLen]) {
        ++gLen;
      }

      wordMap.push([word[i], gLen]);

      i += gLen;
    }

    return wordMap;
  }

  const sMap = group(s),
    sLen = sMap.length;

  let res = 0;
  for (const w of words) {
    const curWordMap = group(w);

    if (curWordMap.length === sLen) {
      let i = 0;
      while (i < sLen) {
        const [sL, sC] = sMap[i];
        const [wL, wC] = curWordMap[i];

        if (sL !== wL) break;

        if (sC === wC || (sC >= 3 && wC < sC)) {
          ++i;
        } else {
          break;
        }
      }

      if (i === sLen) ++res;
    }
  }

  return res;
}

var s = 'heeellooo',
  w = ['hello', 'hi', 'helo'];
console.log(expressiveWords_precompute(s, w));
