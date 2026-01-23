export const url =
  '[Partition Labels](https://leetcode.com/problems/partition-labels/description/)';

function partitionLabels(s: string): number[] {
  const n = s.length,
    o: number[][] = [],
    res: number[] = [];

  for (let i = 0; i < 26; ++i) {
    o.push([-1, -1]);
  }

  for (let i = 0; i < n; ++i) {
    const curI = s.charCodeAt(i) - 97;
    const [startI, endI] = o[curI];

    if (startI === -1) {
      o[curI][0] = i;
    }

    o[curI][1] = i;
  }

  for (let i = 0; i < n; ++i) {
    const tmpSet = new Set(s[i]);
    let j = i + 1;
    while (j < n) {}

    res.push(j - i + 1);
  }

  return res;
}

var input = 'ababcbacadefegdehijhklij';
// var input = 'ababcc';
var out = partitionLabels(input);
