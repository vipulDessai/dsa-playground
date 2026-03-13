export const url =
    '[Maximum Length of a Concatenated String with Unique Characters](https://leetcode.com/problems/maximum-length-of-a-concatenated-string-with-unique-characters/description/)';

function maxLength_branchBacktrack(arr: string[]): number {
    const masks: number[] = [];
    const lengths: number[] = [];

    // Convert strings to bitmasks, skip invalid ones
    for (let s of arr) {
        let mask = 0;
        let valid = true;
        for (let ch of s) {
            const bit = 1 << (ch.charCodeAt(0) - 97);

            if ((mask & bit) !== 0) {
                // duplicate char in string, but how?
                // say string is "ab" -> 0001 & 0010 => 0000, i.e. no char duplicate
                // say string is "aa" -> 0001 & 0001 => 0001, i.e. char duplicate
                valid = false;
                break;
            }
            mask |= bit;
        }

        if (valid) {
            masks.push(mask);
            lengths.push(s.length);
        }
    }

    let maxLen = 0;
    function backtrack(
        i: number,
        cur: number,
        currLen: number,
        curArr: number[],
    ) {
        if (i === masks.length) {
            return (maxLen = Math.max(maxLen, currLen));
        }

        if ((cur & masks[i]) === 0) {
            curArr.push(masks[i]);
            backtrack(i + 1, cur | masks[i], currLen + lengths[i], curArr);

            curArr.pop();
        }

        backtrack(i + 1, cur, currLen, curArr);
    }

    backtrack(0, 0, 0, []);
    return maxLen;
}

var input = ['cha', 'r', 'act', 'ers'];
console.log(maxLength_branchBacktrack(input));

function maxLength_complexAiBacktrack(arr: string[]): number {
    const masks: number[] = [];
    const lengths: number[] = [];

    // Convert strings to bitmasks, skip invalid ones
    for (let s of arr) {
        let mask = 0;
        let valid = true;
        for (let ch of s) {
            const bit = 1 << (ch.charCodeAt(0) - 97);
            if ((mask & bit) !== 0) {
                valid = false; // duplicate char in string
                break;
            }
            mask |= bit;
        }
        if (valid) {
            masks.push(mask);
            lengths.push(s.length);
        }
    }

    let maxLen = 0;

    function backtrack(index: number, currMask: number, currLen: number) {
        maxLen = Math.max(maxLen, currLen);
        for (let i = index; i < masks.length; i++) {
            if ((currMask & masks[i]) === 0) {
                backtrack(i + 1, currMask | masks[i], currLen + lengths[i]);
            }
        }
    }

    backtrack(0, 0, 0);
    return maxLen;
}

var input = ['un', 'ue'];
console.log(maxLength_complexAiBacktrack(input));
