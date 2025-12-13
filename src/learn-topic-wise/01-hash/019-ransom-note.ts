export const url = '[Ransom Note](https://leetcode.com/problems/ransom-note/)';

function canConstruct(ransomNote: string, magazine: string): boolean {
  const m = magazine.length,
    mMap = new Map<string, number>();
  for (let i = 0; i < m; ++i) {
    const c = magazine[i];
    mMap.set(c, (mMap.get(c) || 0) + 1);
  }

  const n = ransomNote.length;
  for (let i = 0; i < n; ++i) {
    const c = ransomNote[i];

    const count = mMap.get(c);
    if (count) {
      mMap.set(c, count - 1);
    } else {
      return false;
    }
  }

  return true;
}

var r = 'aa',
  m = 'acb';
var out = canConstruct(r, m);

console.log(out);
