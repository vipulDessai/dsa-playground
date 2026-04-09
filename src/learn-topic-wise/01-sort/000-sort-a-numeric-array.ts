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

function recursiveInsertionSort(arr: number[]) {
    const n = arr.length,
        compareFn = (a: number, b: number) => (a < b ? -1 : a > b ? 1 : 0);

    function dfs(arr: number[], n: number) {
        // Base case: single element is already sorted
        if (n <= 1) return arr;

        // Sort first n-1 elements recursively
        dfs(arr, n - 1);

        // Insert nth element into the sorted subarray
        const last = arr[n - 1];
        let j = n - 2;

        while (j >= 0 && compareFn(arr[j], last) > 0) {
            arr[j + 1] = arr[j];
            j--;
        }
        arr[j + 1] = last;

        return arr;
    }

    dfs(arr, n);
}

var input = [5, 2, 9, 1, 5, 6];
console.log(sortArray(input));
