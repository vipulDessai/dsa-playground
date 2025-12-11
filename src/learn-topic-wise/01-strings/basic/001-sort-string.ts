export const url = "common sort string"

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
