export const url =
    '[Sort a Numeric Array](https://leetcode.com/problems/sort-an-array/)';

enum SortType {
    'insertionSortRecursive',
    'insertionSortIterative',
    'quickSortStandardAndRandom',
}

const sType: SortType = SortType.quickSortStandardAndRandom;

function sortArray(nums: number[]): number[] {
    switch (sType) {
        case SortType.insertionSortRecursive:
            insertionSortRecursive(nums);
            break;
        case SortType.insertionSortIterative:
            insertionSortIterative(nums);
            break;
        case SortType.quickSortStandardAndRandom:
            quickSortStandardAndRandom(nums);
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

function quickSortStandardAndRandom(arr: number[]) {
    function partition(low: number, high: number) {
        // random - START

        // Pick a random pivot index between low and high
        // let randInd = Math.floor(Math.random() * (high - low + 1)) + low;

        // // Swap pivot with the last element, as per the
        // [arr[randInd], arr[high]] = [arr[high], arr[randInd]];

        // random - END

        // choose the pivot
        let pivot = arr[high];

        // index of smaller element and indicates
        // the right position of pivot found so far
        let i = low - 1;

        // traverse arr[low..high] and move all smaller
        // elements to the left side. Elements from low to
        // i are smaller after every iteration
        for (let j = low; j < high; ++j) {
            if (arr[j] <= pivot) {
                i++;
                [arr[i], arr[j]] = [arr[j], arr[i]];
            }
        }

        // move pivot after smaller elements and
        // return its position
        // the i + 1 is likely the position of a value > arr[high] or pivot
        [arr[i + 1], arr[high]] = [arr[high], arr[i + 1]];
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
var input = [2, 5, 9, 1, 0];
console.log(sortArray(input));
