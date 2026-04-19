export const url =
    '[Sort a Numeric Array](https://leetcode.com/problems/sort-an-array/)';

enum SortType {
    'insertionSortRecursive',
    'insertionSortIterative',
    'selectionSort',
    'bubbleSort',
    'quickSortStandardAndRandom',
    'mergeSort',
    'radixSortdigitPlace',
    'radixSortPartitioning',
    'countSort',
}

const sType: SortType = SortType.radixSortPartitioning;

function sortArray(nums: number[]): number[] {
    switch (sType) {
        case SortType.insertionSortRecursive:
            insertionSortRecursive(nums);
            break;
        case SortType.insertionSortIterative:
            insertionSortIterative(nums);
            break;
        case SortType.selectionSort:
            selectionSort(nums);
            break;
        case SortType.bubbleSort:
            bubbleSort(nums);
            break;
        case SortType.quickSortStandardAndRandom:
            quickSortStandardAndRandom(nums);
            break;
        case SortType.mergeSort:
            mergeSort(nums);
            break;
        case SortType.radixSortdigitPlace:
            radixSortdigitPlace(nums);
            break;
        case SortType.radixSortPartitioning:
            radixSortPartitioning(nums);
            break;
        case SortType.countSort:
            countSort(nums);
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

function radixSortdigitPlace(arr: number[]) {
    function count(nums: number[], exp: number): number[] {
        const n = nums.length;
        const output = new Array(n);
        const count = Array(10).fill(0);

        for (let i = 0; i < n; i++) {
            const digit = Math.floor(nums[i] / exp) % 10;
            count[digit]++;
        }

        // transforms raw digit frequencies into placement indices for the output array
        for (let i = 1; i < 10; i++) {
            count[i] += count[i - 1];
        }

        for (let i = n - 1; i >= 0; i--) {
            const digit = Math.floor(nums[i] / exp) % 10;
            output[count[digit] - 1] = nums[i];
            count[digit]--;
        }

        return output;
    }

    function sort(nums: number[]): number[] {
        if (nums.length === 0) return nums;

        const max = Math.max(...nums);

        let exp = 1,
            sorted = [...nums];

        while (Math.floor(max / exp) > 0) {
            sorted = count(sorted, exp);
            exp *= 10;
        }
        return sorted;
    }

    // since classic radix only works for +ve, map the -ve to absolute value
    // and apply radix
    const negatives = arr.filter((v) => v < 0).map((v) => -v);
    const positives = arr.filter((v) => v >= 0);

    // revert the -ve numbers
    const sortedNegatives = sort(negatives)
        .reverse()
        .map((v) => -v);
    const sortedPositives = sort(positives);

    const sortedArr = [...sortedNegatives, ...sortedPositives];

    for (let i = 0; i < arr.length; ++i) {
        arr[i] = sortedArr[i];
    }
}

// same as radixSortdigitPlace, but using the same nums array, in place manipulation
function radixSortPartitioning(nums: number[]) {
    function sort(l: number, h: number, s: number, isAsc: boolean) {
        function count(e: number) {
            const freq = Array(10).fill(0);

            for (let i = l; i <= h; ++i) {
                const d = Math.floor(Math.abs(nums[i]) / e) % 10;
                ++freq[d];
            }

            // +ve numbers
            if (isAsc) {
                for (let i = 1; i < 10; ++i) {
                    freq[i] += freq[i - 1];
                }
            }
            // -ve numbers are reversed sorted
            else {
                for (let i = 8; i >= 0; --i) {
                    freq[i] += freq[i + 1];
                }
            }

            const out = new Array(s);
            for (let i = h; i >= l; --i) {
                const d = Math.floor(Math.abs(nums[i]) / e) % 10;
                out[freq[d] - 1] = nums[i];
                --freq[d];
            }

            for (let i = 0; i < s; ++i) {
                nums[l + i] = out[i];
            }
        }

        let m = -Infinity;
        for (let i = l; i <= h; ++i) {
            m = Math.max(m, Math.abs(nums[i]));
        }

        let e = 1;
        while (Math.floor(m / e) > 0) {
            count(e);
            e *= 10;
        }
    }

    const n = nums.length;

    let piInd = 0;
    for (let i = 0; i < n; ++i) {
        if (nums[i] < 0) {
            [nums[i], nums[piInd]] = [nums[piInd], nums[i]];
            ++piInd;
        }
    }

    // -ve exists
    if (piInd > 0) {
        sort(0, piInd - 1, piInd, false);
    }

    // +ve exists
    if (piInd < n) {
        sort(piInd, n - 1, n - piInd, true);
    }
}

function countSort(nums: number[]) {
    const n = nums.length;

    if (n === 0) return [];

    const min = Math.min(...nums);
    const max = Math.max(...nums);

    const freq = Array(max - min + 1).fill(0);

    for (const num of nums) {
        ++freq[num - min];
    }

    for (let i = 1; i < freq.length; ++i) {
        freq[i] += freq[i - 1];
    }

    const out = new Array(n);
    for (let i = n - 1; i >= 0; --i) {
        const num = nums[i];
        const ind = freq[num - min];
        out[ind - 1] = num;
        --freq[num - min];
    }

    for (let i = 0; i < n; ++i) {
        nums[i] = out[i];
    }
}

var input = [5, 2, 9, 1, 5, 6];
var input = [2, 5, 9, 1, 0];
var input = [2, 50, -1, -17, 3];
console.log(sortArray(input));
