export const url =
  '[Interval List Intersections](https://leetcode.com/problems/interval-list-intersections/description/)';

function intervalIntersection(
  firstList: number[][],
  secondList: number[][],
): number[][] {
  let i = 0,
    j = 0;

  const res: number[][] = [];

  while (i < firstList.length && j < secondList.length) {
    const [aStart, aEnd] = firstList[i];
    const [bStart, bEnd] = secondList[j];

    const s = Math.max(aStart, bStart);
    const e = Math.min(aEnd, bEnd);

    if (s <= e) {
      res.push([s, e]);
    }

    if (aEnd < bEnd) {
      ++i;
    } else {
      ++j;
    }
  }

  return res;
}

var f = [
    [0, 2],
    [5, 10],
    [13, 23],
    [24, 25],
  ],
  s = [
    [1, 5],
    [8, 12],
    [15, 24],
    [25, 26],
  ];
var out = intervalIntersection(f, s);

console.log(out);
