export const url =
    '[Compare Version Numbers](https://leetcode.com/problems/compare-version-numbers/)';

function compareVersion(version1: string, version2: string): number {
    const r1Data = version1.split('.').map((r) => parseInt(r)),
        r2Data = version2.split('.').map((r) => parseInt(r));

    const n = Math.max(r1Data.length, r2Data.length);

    for (let i = 0; i < n; ++i) {
        const r1 = r1Data[i] || 0,
            r2 = r2Data[i] || 0;

        if (r1 > r2) return 1;
        if (r1 < r2) return -1;
    }

    return 0;
}

var input1 = '1.0.0.1',
    input2 = '1';
console.log(compareVersion(input1, input2));
