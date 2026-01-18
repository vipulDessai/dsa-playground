export const url =
  '[Valid Anagram](https://leetcode.com/problems/valid-anagram/)';

const sortingCallback = (a: string, b: string) => {
  const aLower = a.toLowerCase();
  const bLower = b.toLowerCase();

  return aLower < bLower ? -1 : 1;
};
const checkValidAnagramSort = (s: string, t: string) => {
  const sortedS = [...s];
  const sortedT = [...t];

  return (
    sortedS.sort(sortingCallback).join() ===
    sortedT.sort(sortingCallback).join()
  );
};

// console.log(checkValidAnagramSort('foo', 'ofo'));

function isAnagram(s: string, t: string): boolean {
  const sH = Array(26).fill(0);
  const tH = Array(26).fill(0);

  for (const c of s) {
    ++sH[c.charCodeAt(0) - 97];
  }

  for (const c of t) {
    ++tH[c.charCodeAt(0) - 97];
  }

  for (let i = 0; i < 26; ++i) {
    if (sH[i] !== tH[i]) {
      return false;
    }
  }

  return true;
}

console.log(isAnagram('foo', 'ofo'));
