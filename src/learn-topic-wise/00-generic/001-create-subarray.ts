// Output
// i = 0 => 3, 31, 312, 3124
// i = 1 => 1, 12, 124
// i = 2 => 2, 24
// i = 3 => 4

function createSubArray(nums: number[]) {
    const n = nums.length;
    const subSets: string[][] = [];

    for (let i = 0; i < n; i++) {
        let curStr = '';
        const curSubSet: string[] = [];
        for (let j = i; j < n; j++) {
            curStr += nums[j];
            curSubSet.push(curStr);
        }
        subSets.push(curSubSet);
    }

    return subSets;
}

console.log(createSubArray([3, 1, 2, 4]));
