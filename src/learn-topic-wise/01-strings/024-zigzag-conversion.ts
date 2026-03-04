export const url =
  '[](https://leetcode.com/problems/zigzag-conversion/description/)';

function convert(s: string, numRows: number): string {
  const sLen = s.length;

  if (numRows === 1 || sLen === 1 || sLen <= numRows) return s;

  const res = Array(numRows).fill('');

  let r = 0,
    dir = false;
  for (const c of s) {
    res[r] += c;

    if (r === 0 || r === numRows - 1) {
      dir = !dir;
    }

    r += dir ? 1 : -1;
  }

  return res.join('');
}

var inStr = 'AB',
  r = 1;
console.log(convert(inStr, r));
