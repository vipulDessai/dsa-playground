export const url =
    '[Custom Sort String](https://leetcode.com/problems/custom-sort-string/)';

function customSortString(order: string, s: string): string {
    const freq = Array(26).fill(0);

    for (let i = 0; i < s.length; ++i) {
        ++freq[s.charCodeAt(i) - 97];
    }

    let res = '';
    for (let i = 0; i < order.length; ++i) {
        const index = order.charCodeAt(i) - 97;
        if (freq[index] > 0) {
            while (freq[index] > 0) {
                res += order[i];
                --freq[index];
            }
        }
    }

    for (let i = 0; i < 26; ++i) {
        let c = freq[i];

        if (c > 0) {
            const char = String.fromCharCode(97 + i);
            while (c > 0) {
                res += char;
                --c;
            }
        }
    }

    return res;
}

var o = 'cba',
    s = 'abcabcabcddff';
console.log(customSortString(o, s));
