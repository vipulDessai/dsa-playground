export const url =
  '[Word Pattern](https://leetcode.com/problems/word-pattern/)';

function wordPattern(pattern: string, s: string): boolean {
  const words = s.split(' ');

  if (words.length !== pattern.length) {
    return false;
  }

  const pMap = new Map<string, string>();
  const wMap = new Map<string, string>();

  for (let i = 0; i < pattern.length; ++i) {
    const p = pattern[i];
    const w = words[i];

    if (pMap.has(p) && pMap.get(p) !== w) {
      return false;
    }
    if (wMap.has(w) && wMap.get(w) !== p) {
      return false;
    }

    pMap.set(p, w);
    wMap.set(w, p);
  }

  return true;
}

var p = 'abba',
  s = 'dog cat cat dog';
var out = wordPattern(p, s);

console.log(out);