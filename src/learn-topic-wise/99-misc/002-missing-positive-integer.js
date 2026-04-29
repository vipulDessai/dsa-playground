/**
 * This is a demo task.
 * Write a function: function solution(A);
 * that, given an array A of N integers, returns the smallest positive integer (greater than 0) that does not occur in A.
 * For example, given A = [1, 3, 6, 4, 1, 2], the function should return 5.
 * Given A = [1, 2, 3], the function should return 4.
 * Given A = [−1, −3], the function should return 1.
 * Write an efficient algorithm for the following assumptions:
 * N is an integer within the range [1..100,000];
 * each element of array A is an integer within the range [−1,000,000..1,000,000].
 */

function solution(array) {
    const unsortedSet = new Set();
    for (let i = 0; i < array.length; i++) {
        if (!unsortedSet.has(array[i]) && array[i] > 0) {
            unsortedSet.add(array[i]);
        }
    }

    if (unsortedSet.size === 0) return 1;

    const sortedArray = [...unsortedSet].sort((a, b) => a - b);

    if (sortedArray[0] === 1) {
        sortedArray.push(sortedArray[sortedArray.length - 1] + 2);

        for (let i = 0; i < sortedArray.length - 1; i++) {
            // skip
            if (sortedArray[i] < 0) {
                continue;
            }

            const subtractionResult = sortedArray[i + 1] - sortedArray[i];
            if (subtractionResult > 1) {
                return sortedArray[i] + 1;
            }
        }
    } else {
        return 1;
    }
}

// const res = solution([-1, -3]);
// const res = solution([1, 3, 6, 4, 1, 2]);
const res = solution([2]);
// const res = solution([-3, -1, 0]);

console.log(res);
