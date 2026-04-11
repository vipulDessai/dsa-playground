export const url =
    '[Sort a Numeric Array](https://leetcode.com/problems/sort-an-array/)';

enum SortType {
    'insertionSortRecursive',
    'insertionSortIterative',
    'quickSortStandard',
}

const sType: SortType = SortType.quickSortStandard;

function sortArray(nums: number[]): number[] {
    switch (sType) {
        case SortType.insertionSortRecursive:
            insertionSortRecursive(nums);
            break;
        case SortType.insertionSortIterative:
            insertionSortIterative(nums);
            break;
        case SortType.quickSortStandard:
            quickSortStandard(nums);
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

function insertionSortRecursive(arr: number[]) {
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

function insertionSortIterative(arr: number[]) {
    const n = arr.length;

    for (let i = 1; i < n; ++i) {
        const l = arr[i];
        let j = i - 1;
        while (j >= 0 && compareFn(arr[j], l) > 0) {
            arr[j + 1] = arr[j];
            --j;
        }

        arr[j + 1] = l;
    }
}

function quickSortStandard(arr: number[]) {
    // swap function
    function swap(i: number, j: number) {
        let temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    function partition(low: number, high: number) {
        // choose the pivot
        let pivot = arr[high];

        // index of smaller element and indicates
        // the right position of pivot found so far
        let i = low - 1;

        // traverse arr[low..high] and move all smaller
        // elements to the left side. Elements from low to
        // i are smaller after every iteration
        for (let j = low; j < high; ++j) {
            if (arr[j] < pivot) {
                i++;
                swap(i, j);
            }
        }

        // move pivot after smaller elements and
        // return its position
        swap(i + 1, high);
        return i + 1;
    }

    // the QuickSort function implementation
    function quickSort(low: number, high: number) {
        if (low < high) {
            // pi is the partition return index of pivot
            let pi = partition(low, high);

            // recursion calls for smaller elements
            // and greater or equals elements
            quickSort(low, pi - 1);
            quickSort(pi + 1, high);
        }
    }

    quickSort(0, arr.length - 1);
}

var input = [5, 2, 9, 1, 5, 6];
var input = [3, 2, 1];
console.log(sortArray(input));
