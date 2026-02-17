export const url =
  '[Different Ways to Add Parentheses](https://leetcode.com/problems/different-ways-to-add-parentheses/description/)';

function diffWaysToCompute(expression: string): number[] {
  let curNum = '';
  const expStrArr: (string | number)[] = [];
  for (let i = 0; i < expression.length; ++i) {
    if (
      expression[i] === '+' ||
      expression[i] === '-' ||
      expression[i] === '*'
    ) {
      expStrArr.push(parseInt(curNum));
      expStrArr.push(expression[i]);
      curNum = '';
    } else {
      curNum = curNum.concat(expression[i]);
    }
  }

  expStrArr.push(parseInt(curNum));

  const res = [];
  const dfs = () => {};

  dfs();

  return res;
}

var inStr = '2*3-4*5';
var inStr = '2*33-4*59';
console.log(diffWaysToCompute(inStr));
