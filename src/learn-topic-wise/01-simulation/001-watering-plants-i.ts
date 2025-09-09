export const url =
  '[Watering Plants I](https://leetcode.com/problems/watering-plants/description/)';

function wateringPlants(plants: number[], capacity: number): number {
  const n = plants.length;

  let can = capacity,
    res = 0;
  for (let i = 0; i < n; ++i) {
    const cur = plants[i];

    can -= cur;

    if (can < 0) {
      res += 2 * i;
      can = capacity - cur;
    }
    ++res;
  }

  return res;
}

var p = [1, 1, 1, 4, 2, 3],
  c = 4;
var out = wateringPlants(p, c);

console.log(out);
