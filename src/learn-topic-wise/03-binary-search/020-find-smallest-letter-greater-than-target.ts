export const url =
  '[find smallest letter greater than target](https://leetcode.com/problems/find-smallest-letter-greater-than-target/)';

function nextGreatestLetter(letters: string[], target: string): string {
  const n = letters.length;

  let l = 0,
    r = n - 1;
  while (l < r) {
    const m = Math.floor(l + (r - l) / 2);

    if (letters[m].charAt(0) > target.charAt(0)) {
      r = m;
    } else {
      l = m + 1;
    }
  }

  return letters[l] > target ? letters[l] : letters[0];
}

var input = ['c', 'f', 'j'],
  t = 'a';
var out = nextGreatestLetter(input, t);

console.log(out);
