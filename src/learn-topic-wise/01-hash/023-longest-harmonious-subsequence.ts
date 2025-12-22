export const url = '';

function findLHS(nums: number[]): number {
  const uMap = new Map<number, number>();

  for (const num of nums) {
    uMap.set(num, (uMap.get(num) || 0) + 1);
  }

  let res = 0;
  for (const [k, v] of uMap) {
    if (uMap.has(k + 1)) {
      res = Math.max(res, uMap.get(k) + uMap.get(k + 1));
    }
  }

  return res;
}

var input = [1, 3, 2, 2, 5, 2, 3, 7];
var out = findLHS(input);

console.log(out);
