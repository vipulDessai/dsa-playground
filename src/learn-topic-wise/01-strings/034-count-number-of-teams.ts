export const url =
    '[Count Number of Teams](https://leetcode.com/problems/count-number-of-teams/description/)';

function numTeams(rating: number[]): number {
    const n = rating.length;
    let res = 0;

    for (let j = 1; j < n - 1; j++) {
        let lS = 0,
            lL = 0,
            rS = 0,
            rL = 0;

        for (let i = 0; i < j; ++i) {
            if (rating[i] < rating[j]) ++lS;
            else ++lL;
        }

        for (let k = j + 1; k < n; ++k) {
            if (rating[k] < rating[j]) ++rS;
            else ++rL;
        }

        res += lS * rL + lL * rS;
    }

    return res;
}

var input = [2, 5, 3, 4, 1];
console.log(numTeams(input));
