export const url =
  '[Convert an Array Into a 2D Array With Conditions](https://leetcode.com/problems/convert-an-array-into-a-2d-array-with-conditions/description/)';

function findMatrix(nums: number[]): number[][] {
  const uMap = nums.reduce((acc, cur) => {
    acc.set(cur, (acc.get(cur) || 0) + 1);
    return acc;
  }, new Map<number, number>());

  const res: number[][] = [];
  while (uMap.size) {
    const cur: number[] = [],
      delKey: number[] = [];
    for (const [k, v] of uMap) {
      uMap.set(k, v - 1);
      cur.push(k);

      if (v - 1 === 0) {
        delKey.push(k);
      }
    }

    for (const k of delKey) {
      uMap.delete(k);
    }

    res.push(cur);
  }
  return res;
}

var input = [1, 3, 4, 1, 2, 3, 1];
console.log(findMatrix(input));
