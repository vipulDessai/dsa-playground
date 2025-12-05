export const url =
  '[Happy Numbers](https://leetcode.com/problems/happy-number/)';

function isHappy(n: number): boolean {
  const getNext = (num: number): number => {
    let total = 0;
    while (num > 0) {
      let digit = num % 10;
      total += digit * digit;

      // Math floor is very important, otherwise
      // the cur will always be > 0, i.e. 0.0001 or something
      // but not 0
      num = Math.floor(num / 10);
    }
    return total;
  };

  let slow = n;
  let fast = getNext(n);

  while (fast !== 1 && slow !== fast) {
    slow = getNext(slow);
    fast = getNext(getNext(fast));
  }

  return fast === 1;
}

var input = 443;
var out = isHappy(input);

console.log(out);
