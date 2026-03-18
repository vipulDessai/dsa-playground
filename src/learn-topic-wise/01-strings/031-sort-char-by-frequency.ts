export const url =
    '[Sort Characters By Frequency](https://leetcode.com/problems/sort-characters-by-frequency/description/)';

function frequencySort(s: string): string {
    const upper: [string, number][] = Array.from({ length: 26 }, (_, i) => [
        String.fromCharCode(65 + i),
        0,
    ]);
    const lower: [string, number][] = Array.from({ length: 26 }, (_, i) => [
        String.fromCharCode(97 + i),
        0,
    ]);
    const digits: [string, number][] = Array.from({ length: 10 }, (_, i) => [
        i.toString(),
        0,
    ]);

    for (const c of s) {
        const code = c.charCodeAt(0);

        if (code >= 48 && code <= 57) {
            const i = code - 48; // 48 is `0`
            digits[i] = [digits[i][0], ++digits[i][1]];
        } else if (code >= 65 && code <= 90) {
            const i = code - 65; // 65 is `A`
            upper[i] = [upper[i][0], ++upper[i][1]];
        } else {
            const i = code - 97; // 97 s `a`
            lower[i] = [lower[i][0], ++lower[i][1]];
        }
    }

    const freq = [...digits, ...upper, ...lower];

    freq.sort((a, b) => {
        return b[1] - a[1];
    });

    let res = '';
    for (const [char, count] of freq) {
        for (let i = 0; i < count; ++i) {
            res += char;
        }
    }

    return res;
}

var input = 'tree';
console.log(frequencySort(input));
