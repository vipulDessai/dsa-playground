export const url =
    '[Minimum Number of Steps to Make Two Strings Anagram](https://leetcode.com/problems/minimum-number-of-steps-to-make-two-strings-anagram/)';

function minSteps(s: string, t: string): number {
    const freqS: number[] = new Array(26).fill(0);
    const freqT: number[] = new Array(26).fill(0);

    for (let i = 0; i < s.length; i++) {
        freqS[s.charCodeAt(i) - 97]++;
        freqT[t.charCodeAt(i) - 97]++;
    }

    let steps = 0;
    for (let i = 0; i < 26; i++) {
        // since the ask is to replace letters in t
        // we only care letters freq count of s > of those in t
        if (freqS[i] > freqT[i]) {
            steps += freqS[i] - freqT[i];
        }
    }

    return steps;
}

var inS = 'leetcode',
    inT = 'practice';
console.log(minSteps(inS, inT));
