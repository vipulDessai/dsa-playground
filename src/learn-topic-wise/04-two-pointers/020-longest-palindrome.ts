export const url =
    '[Longest Palindromic Substring](https://leetcode.com/problems/longest-palindromic-substring/)';

function longestPalindrome(s: string): string {
    const n = s.length;
    let _l = 0,
        _r = 0;

    function findPal(l: number, r: number) {
        while (l >= 0 && r < n && s[l] === s[r]) {
            if (r - l + 1 > _r - _l + 1) {
                _l = l;
                _r = r;
            }

            --l;
            ++r;
        }
    }

    for (let i = 0; i < n; i++) {
        // finding any odd palidromic string
        findPal(i, i);
        // finding any even palidromic string
        findPal(i, i + 1);
    }

    return s.substring(_l, _r + 1);
}

var input = 'babad';
console.log(longestPalindrome(input));
