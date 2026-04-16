export const url =
    '[Sort a Numeric Array](https://leetcode.com/problems/sort-an-array/)';

enum SortType {
    'insertionSortRecursive',
    'insertionSortIterative',
    'quickSortStandardAndRandom',
    'selectionSort',
    'bubbleSort',
    'mergeSort',
    'radixSort',
}

const sType: SortType = SortType.radixSort;

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
        case SortType.selectionSort:
            selectionSort(nums);
            break;
        case SortType.bubbleSort:
            bubbleSort(nums);
            break;
        case SortType.mergeSort:
            mergeSort(nums);
            break;
        case SortType.radixSort:
            radixSort(nums);
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

function bubbleSort(arr: number[]) {
    const n = arr.length;
    for (let i = 0; i < n - 1; ++i) {
        let swapped = false;

        // with every pass, the largest element gets moved to the right of the array
        // thats why j < n - i - 1
        for (let j = 0; j < n - i - 1; ++j) {
            if (compareFn(arr[j], arr[j + 1]) > 0) {
                [arr[j], arr[j + 1]] = [arr[j + 1], arr[j]];

                swapped = true;
            }
        }

        // no swap meaning array is sorted, so STOP!!!
        if (!swapped) break;
    }
}

function selectionSort(arr: number[]) {
    const n = arr.length;
    for (let i = 0; i < n; ++i) {
        let minI = i;
        for (let j = i + 1; j < n; ++j) {
            if (compareFn(arr[j], arr[minI]) < 0) {
                minI = j;
            }
        }

        [arr[i], arr[minI]] = [arr[minI], arr[i]];
    }
}

function mergeSort(arr: number[]) {
    function mergeOutplace(left: number, mid: number, right: number) {
        const n1 = mid - left + 1;
        const n2 = right - mid;

        // Create temp arrays
        const L = new Array(n1);
        const R = new Array(n2);

        // Copy data to temp arrays L[] and R[]
        for (let i = 0; i < n1; i++) L[i] = arr[left + i];
        for (let j = 0; j < n2; j++) R[j] = arr[mid + 1 + j];

        let i = 0,
            j = 0;
        let k = left;

        // Merge the temp arrays back into arr[left..right]
        while (i < n1 && j < n2) {
            if (L[i] <= R[j]) {
                arr[k] = L[i];
                i++;
            } else {
                arr[k] = R[j];
                j++;
            }
            k++;
        }

        // Copy the remaining elements of L[], if there are any
        while (i < n1) {
            arr[k] = L[i];
            i++;
            k++;
        }

        // Copy the remaining elements of R[], if there are any
        while (j < n2) {
            arr[k] = R[j];
            j++;
            k++;
        }
    }

    function mergeInplace(left: number, mid: number, right: number) {
        let start = mid + 1;

        // If the direct merge is already sorted
        if (arr[mid] <= arr[start]) {
            return;
        }

        // Two pointers to maintain start
        // of both arrays to merge
        while (left <= mid && start <= right) {
            // If element 1 is in right place
            if (arr[left] <= arr[start]) {
                left++;
            } else {
                let value = arr[start];
                let index = start;

                // Shift all the elements right by 1.
                while (index > left) {
                    arr[index] = arr[index - 1];
                    index--;
                }
                arr[left] = value;

                // Update all the pointers
                left++;
                mid++;
                start++;
            }
        }
    }

    function dfs(left: number, right: number) {
        if (left < right) {
            const mid = Math.floor(left + (right - left) / 2);

            dfs(left, mid);
            dfs(mid + 1, right);

            // extra memory
            // mergeOutplace(left, mid, right);

            // no extra memory
            mergeInplace(left, mid, right);
        }
    }

    dfs(0, arr.length - 1);
}

// fails for -ve numbers [3, -1]
function radixSort(arr: number[]) {
    const n = arr.length;
    // A function to do counting sort of arr[] according to
    // the digit represented by exp.
    function countSort(curArr: number[], exp: number) {
        let output = new Array(n); // output array
        let count = Array(10).fill(0);

        // Store count of occurrences in count[]
        for (let i = 0; i < n; i++) {
            const digit = Math.floor(curArr[i] / exp) % 10;
            count[digit]++;
        }

        // Change count[i] so that count[i] now contains
        // actual position of this digit in output[]
        for (let i = 1; i < 10; i++) {
            count[i] += count[i - 1];
        }

        // Build the output array
        for (let i = n - 1; i >= 0; i--) {
            const digit = Math.floor(curArr[i] / exp) % 10;
            output[count[digit] - 1] = curArr[i];
            count[digit]--;
        }

        return output;
    }

    // The main function to that sorts arr[] using Radix Sort
    function radixSort() {
        let maxNumber = arr[0];
        for (let i = 1; i < n; i++) {
            if (arr[i] > maxNumber) maxNumber = arr[i];
        }

        // Create a shallow copy where the sorted values will be kept
        let sortedArr = [...arr];

        // Do counting sort for every digit. Note that
        // instead of passing digit number, exp is passed.
        // exp is 10^i where i is current digit number
        for (let exp = 1; Math.floor(maxNumber / exp) > 0; exp *= 10) {
            // Get the Count sort iteration
            sortedArr = countSort(sortedArr, exp);
        }

        return sortedArr;
    }

    const sortedArr = radixSort();

    for (let i = 0; i < n; ++i) {
        arr[i] = sortedArr[i];
    }
}

var input = [5, 2, 9, 1, 5, 6];
var input = [2, 5, 9, 1, 0];
console.log(sortArray(input));
