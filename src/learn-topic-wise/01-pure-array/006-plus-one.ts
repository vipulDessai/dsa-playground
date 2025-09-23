export const url = '[Plus One](https://leetcode.com/problems/plus-one/)';

function plusOne(digits: number[]): number[] {
  function inc(i: number) {
    if (i < 0) {
      digits.unshift(1);
    }

    if (digits[i] === 9) {
      digits[i] = 0;
      inc(i - 1);
    } else {
      ++digits[i];
    }
  }

  inc(digits.length - 1);

  return digits;
}

var input = [1, 2, 3];
var input = [9, 9, 9];
var out = plusOne(input);

console.log(out);
