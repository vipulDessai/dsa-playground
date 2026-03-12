export const url =
    '[Determine if Two Strings Are Close](https://leetcode.com/problems/determine-if-two-strings-are-close/description/)';

function closeStrings(word1: string, word2: string): boolean {
    if (word1.length !== word2.length) return false;

    const w1Map = Array(26).fill(0),
        w2Map = Array(26).fill(0);

    for (let i = 0; i < word1.length; ++i) {
        w1Map[word1.charCodeAt(i) - 97]++;
        w2Map[word2.charCodeAt(i) - 97]++;
    }

    // see if all letter is present in both
    // atleast 1 letter should be there between the 2 strings
    for (let i = 0; i < 26; ++i) {
        if (w1Map[i] > 0 && w2Map[i] === 0) return false;

        if (w2Map[i] > 0 && w1Map[i] === 0) return false;
    }

    // there should be sufficient letter for transform
    w1Map.sort((a, b) => a - b);
    w2Map.sort((a, b) => a - b);

    if (w1Map.join() !== w2Map.join()) return false;

    return true;
}

var w1 = 'cabbba',
    w2 = 'abbccc';
console.log(closeStrings(w1, w2));
