export const url = '[Brick Wall](https://leetcode.com/problems/brick-wall/)';

function leastBricks(wall: number[][]): number {
  const m = new Map<number, number>();
  let max = 0;

  for (let i = 0; i < wall.length; i++) {
    const row = wall[i];

    // finding the prefix sum is finding the edge
    let pSum = 0;
    for (let j = 0; j < row.length - 1; j++) {
      pSum += row[j];

      // find the max occuring edge
      let cur = m.get(pSum) || 0;
      m.set(pSum, ++cur);
      max = Math.max(max, cur);
    }
  }

  // ask is draw a line such that cross the least bricks
  // which is same as saying draw a line that passes through max number of edges
  // `max` represents a point where max edges are there
  // `wall.length - max` gives the bricks which are crossed
  return wall.length - max;
}

var input = [
  [1, 2, 2, 1],
  [3, 1, 2],
  [1, 3, 2],
  [2, 4],
  [3, 1, 2],
  [1, 3, 1, 1],
];
var out = leastBricks(input);

console.log(out);
