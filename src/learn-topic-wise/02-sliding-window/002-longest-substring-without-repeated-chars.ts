export const url =
    '[longest substring without repeating characters](https://leetcode.com/problems/longest-substring-without-repeating-characters/description/)';

function lengthOfLongestSubstring(s: string): number {
    const charSet = new Set();
    let l = 0;
    let result = 0;
    for (let r = 0; r < s.length; r++) {
        while (charSet.has(s[r])) {
            charSet.delete(s[l]);
            ++l;
        }

        charSet.add(s[r]);
        result = Math.max(result, r - l + 1);
    }

    return result;
}

console.log(lengthOfLongestSubstring('abcabcbb'));
