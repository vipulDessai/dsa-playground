export const url =
  '[Boats to Save People](https://leetcode.com/problems/boats-to-save-people/description/)';

// fails for [5, 1, 4, 2] limit = 6 out should be 2, but below solution give 3
// why 1 + 5 = 6 and 4 + 2 = 6 so 2
function numRescueBoats_my_pure_array(people: number[], limit: number): number {
  const n = people.length;
  people.sort((a, b) => a - b);

  let res = 0,
    sum = 0,
    l = 0,
    r = 0;
  while (r < n) {
    sum += people[r];

    if (sum > limit) {
      sum = 0;
      ++res;
      l = r;
    } else if (sum === limit || r - l + 1 >= 2) {
      sum = 0;
      ++res;
      ++r;
      l = r;
    } else {
      ++r;
    }
  }

  if (sum > 0) {
    ++res;
  }

  return res;
}

var p = [1, 2],
  l = 3;
var out = numRescueBoats_my_pure_array(p, l);

console.log(out);

function numRescueBoats_ai_soln(people: number[], limit: number): number {
  const n = people.length;
  people.sort((a, b) => a - b);

  let l = 0,
    r = n - 1,
    res = 0;
  while (l <= r) {
    if (people[l] + people[r] <= limit) {
      l++; // pair lightest with heaviest
    }
    r--; // heaviest always boards
    res++; // one boat used
  }

  return res;
}

var p = [5, 1, 4, 2],
  l = 6;
var out = numRescueBoats_ai_soln(p, l);

console.log(out);
