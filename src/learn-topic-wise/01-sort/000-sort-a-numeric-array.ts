export const url =
    '[Sort a Numeric Array](https://leetcode.com/problems/sort-an-array/)';

enum SortType {
    'insertionSortRecursive',
}

const sType = SortType.insertionSortRecursive;

function sortArray(nums: number[]): number[] {
    switch (sType) {
        case SortType.insertionSortRecursive:
            recursiveInsertionSort(nums);
            break;

        default:
            break;
    }

    return nums;
}

function compareFn(a: number, b: number) {
    if (a === b) {
        return 0;
    } else if (a > b) {
        return 1;
    } else {
        return -1;
    }
}

function recursiveInsertionSort(arr: number[]) {
    const n = arr.length;

    function dfs(n: number) {
        // Base case: single element is already sorted
        if (n <= 1) return;

        // Sort first n-1 elements recursively
        dfs(n - 1);

        const l = arr[n - 1];
        let j = n - 2;
        while (j >= 0 && compareFn(arr[j], l) > 0) {
            // shift arr[j] to arr[j + 1]
            arr[j + 1] = arr[j];

            j--;
        }
        arr[j + 1] = l;
    }

    dfs(n);
}

var input = [5, 2, 9, 1, 5, 6];
var input = [3, 2, 1];
console.log(sortArray(input));
