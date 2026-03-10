export const url =
  '[Number of Laser Beams in a Bank](https://leetcode.com/problems/number-of-laser-beams-in-a-bank/)';

function numberOfBeams(bank: string[]): number {
  const m = bank.length,
    n = bank[0].length,
    emptyStr = '0'.repeat(n);

  const mappedNonEmptyCount: number[] = [];
  for (let i = 0; i < m; ++i) {
    if (bank[i] !== emptyStr) {
      let c = 0;
      for (let j = 0; j < n; ++j) {
        if (bank[i][j] === '1') {
          ++c;
        }
      }

      mappedNonEmptyCount.push(c);
    }
  }

  let res = 0;
  for (let i = 1; i < mappedNonEmptyCount.length; ++i) {
    res += mappedNonEmptyCount[i - 1] * mappedNonEmptyCount[i];
  }
  return res;
}

var input = ['011001', '000000', '010100', '001000'];
console.log(numberOfBeams(input));
