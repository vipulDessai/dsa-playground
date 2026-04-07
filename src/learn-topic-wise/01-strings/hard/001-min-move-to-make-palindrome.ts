export const url =
    '[min move to make palindrome](https://leetcode.com/problems/minimum-number-of-moves-to-make-palindrome/description/)';

function minMovesToMakePalindrome(s: string): number {
    const sArr = [...s];

    let l = 0,
        r = s.length - 1,
        res = 0;
    while (l < r) {
        if (sArr[l] === sArr[r]) {
            ++l;
            --r;
        } else {
            let t = r;
            while (t > l && sArr[t] !== sArr[l]) {
                --t;
            }

            // sArr[l] is likely middle char
            if (t === l) {
                // just swap once, +1 move, but l & r remains same
                [sArr[t], sArr[t + 1]] = [sArr[t + 1], sArr[t]];
                ++res;
            } else {
                // swap and increment moves counter
                while (t < r) {
                    // swaps all the way till `r` and sArr[r] as well
                    [sArr[t], sArr[t + 1]] = [sArr[t + 1], sArr[t]];

                    ++t;
                    ++res;
                }

                ++l;
                --r;
            }
        }
    }

    return res;
}

var input = 'aabb';
console.log(minMovesToMakePalindrome(input));
