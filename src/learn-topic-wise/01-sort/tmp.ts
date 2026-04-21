function sortArray(nums: number[]): number[] {
    bucketSort(nums);

    return nums;
}

function bucketSort(arr: number[]) {
    const n = arr.length;
    const min = Math.min(...arr);
    const max = Math.max(...arr);

    const bCount = Math.floor((max - min) / n) + 1;
    const b: number[][] = Array.from({ length: bCount }, () => []);

    for (const num of arr) {
        const i = Math.floor((num - min) / n);
        b[i].push(num);
    }

    // perform any sort on all buckets
    let _i = 0;
    for (let curB of b) {
        for (let i = 0; i < curB.length; ++i) {
            let l = i;
            for (let j = i + 1; j < curB.length; ++j) {
                if (curB[j] < curB[l]) {
                    l = j;
                }
            }

            [curB[i], curB[l]] = [curB[l], curB[i]];
            arr[_i++] = curB[i];
        }
    }
}

var input = [2, 50, -1, -17, 3, 0];
input = [5, 2, 3, 1];
console.log(sortArray(input));
