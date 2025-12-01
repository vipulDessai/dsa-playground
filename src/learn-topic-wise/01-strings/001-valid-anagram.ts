export const url = "[Valid Anagram](https://leetcode.com/problems/valid-anagram/)"

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

console.log(checkValidAnagramSort('foo', 'ofo'));
