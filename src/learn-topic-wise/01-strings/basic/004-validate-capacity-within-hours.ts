/**
 * Problem statement
 * given a array
 * find if its possible to process the given set of items within given hours
 * each array item represent set of items
 * for given capacity per hour and total hours find if all the set of items can be processed
 * or NOT
 *
 * if items are less than the current capacity then all are processed, but next batch will only start with next hour
 *
 * if items are more than the capcaity then will processed in chunks
 */

function validateCapacityPerHour(capacity: number, items: number[], h: number) {
  let i = 0,
    j = 0;
  while (i < h) {
    i += Math.ceil(items[j] / capacity);
    ++j;
  }

  if (i <= h && j == items.length) {
    return true;
  }

  return false;
}

console.log(validateCapacityPerHour(17, [30, 11, 23, 4, 20], 5));
console.log(validateCapacityPerHour(2, [30], 2));
console.log(validateCapacityPerHour(13, [7, 12], 2));
