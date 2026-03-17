export const url =
    '[Evaluate Reverse Polish Notation](https://leetcode.com/problems/evaluate-reverse-polish-notation/)';

function evalRPN(tokens: string[]): number {
    const s: number[] = [];

    for (const t of tokens) {
        switch (t) {
            case '+': {
                const n1 = s.pop()!,
                    n2 = s.pop()!;
                s.push(n2 + n1);
                break;
            }
            case '-': {
                const n1 = s.pop()!,
                    n2 = s.pop()!;
                s.push(n2 - n1);
                break;
            }
            case '*': {
                const n1 = s.pop()!,
                    n2 = s.pop()!;
                s.push(n2 * n1);
                break;
            }
            case '/': {
                const n1 = s.pop()!,
                    n2 = s.pop()!;

                // no .round as .round swings between low and high value
                // no .floor as .floor of 6 / -132 = -1 but it should be 0
                s.push(Math.trunc(n2 / n1));
                break;
            }
            default:
                s.push(parseInt(t));
        }
    }

    return s.pop()!;
}

var input = [
    '10',
    '6',
    '9',
    '3',
    '+',
    '-11',
    '*',
    '/',
    '*',
    '17',
    '+',
    '5',
    '+',
];
// var input = ['4', '-2', '/', '2', '-3', '-', '-'];
console.log(evalRPN(input));
