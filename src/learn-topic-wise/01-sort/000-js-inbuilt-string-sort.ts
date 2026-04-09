export const url = 'Common sort string - JS in built';

// single string
function sortString(s: string) {
    const sortFunc = (a: string, b: string) => {
        return a.toLowerCase() < b.toLowerCase() ? -1 : 1;
    };

    const iterableString = [...s];

    // note: argument in .join is the delimiter, default delimiter is comma
    // therefore passing an empty string
    return iterableString.sort(sortFunc).join('');
}

var input = 'badgamerbad';
var out = sortString(input);

console.log(out);

// array of strings
export function sortStringArray(strArr: string[]) {
    return strArr.sort((a, b) => a.localeCompare(b));
}

console.log(sortStringArray(['xxx', 'yyy', 'aaa', 'bbb', 'ccc']));
