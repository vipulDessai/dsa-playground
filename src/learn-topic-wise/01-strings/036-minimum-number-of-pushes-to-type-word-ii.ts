export const url =
    '[Minimum Number of Pushes to Type Word II](https://leetcode.com/problems/minimum-number-of-pushes-to-type-word-ii/description/)';

function minimumPushes(word: string): number {
    const n = 26;
    const freq: [number, string][] = Array.from({ length: n }, (_, i) => {
        return [0, String.fromCharCode(97 + i)];
    });

    for (let i = 0; i < word.length; ++i) {
        const curI = word.charCodeAt(i) - 97;
        const [count, ch] = freq[curI];
        freq[curI] = [count + 1, ch];
    }

    freq.sort((a, b) => b[0] - a[0]); // descending sort

    const p = Array(n).fill(0);
    let v = 0;
    for (let i = 0; i < n; ++i) {
        if (i % 8 === 0) {
            ++v;
        }

        const [count, ch] = freq[i];

        if (count === 0) break; // no need to go further

        p[ch.charCodeAt(0) - 97] = v;
    }

    let res = 0;
    for (let i = 0; i < word.length; ++i) {
        const curI = word.charCodeAt(i) - 97;
        res += p[curI];
    }

    return res;
}

var input = 'hiknogatpyjzcdbe';
// var input = 'abcdefghi';
// var input = 'abcdefghijklmnopqrstuvwxyz';
console.log(minimumPushes(input));

function minimumPushes_formula(word: string): number {
    const freq = new Map<string, number>();
    for (const ch of word) {
        freq.set(ch, (freq.get(ch) || 0) + 1);
    }

    const counts = Array.from(freq.values()).sort((a, b) => b - a);

    let total = 0;
    for (let i = 0; i < counts.length; i++) {
        const tier = Math.floor(i / 8) + 1; // push cost
        total += counts[i] * tier;
    }
    return total;
}

var input = 'hiknogatpyjzcdbe';
var input = 'abcdefghi';
// var input = 'abcdefghijklmnopqrstuvwxyz';
console.log(minimumPushes_formula(input));
