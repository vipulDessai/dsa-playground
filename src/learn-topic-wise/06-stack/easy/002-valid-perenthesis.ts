export const url = "[Valid Parentheses](https://leetcode.com/problems/valid-parentheses/description/)"

function isValid(s: string): boolean {
  const closeToOpen = new Map<string, string>();
  closeToOpen.set(')', '(');
  closeToOpen.set(']', '[');
  closeToOpen.set('}', '{');

  const stack: string[] = [];

  for (let c = 0; c < s.length; ++c) {
    const char = s[c];
    if (closeToOpen.has(char)) {
      if (stack.length && stack[stack.length - 1] === closeToOpen.get(char)) {
        stack.pop();
      } else {
        return false;
      }
    } else {
      stack.push(char);
    }
  }

  return stack.length === 0 ? true : false;
}

console.log(isValid('(((({{}}{}))))'));
