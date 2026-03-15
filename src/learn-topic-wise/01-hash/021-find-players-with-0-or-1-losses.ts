export const url =
    '[Find Players With Zero or One Losses](https://leetcode.com/problems/find-players-with-zero-or-one-losses/)';

function findWinners(matches: number[][]): number[][] {
    const lMap = new Map<number, number>();

    for (const [w, l] of matches) {
        lMap.set(w, lMap.get(w) || 0);
        lMap.set(l, (lMap.get(l) || 0) + 1);
    }

    const wArr: number[] = [],
        lArr: number[] = [];
    for (const [k, v] of lMap) {
        if (v === 0) {
            wArr.push(k);
        }
        if (v === 1) {
            lArr.push(k);
        }
    }

    wArr.sort((a, b) => a - b);
    lArr.sort((a, b) => a - b);

    return [wArr, lArr];
}

var input = [
    [1, 3],
    [2, 3],
    [3, 6],
    [5, 6],
    [5, 7],
    [4, 5],
    [4, 8],
    [4, 9],
    [10, 4],
    [10, 9],
];
console.log(findWinners(input));
