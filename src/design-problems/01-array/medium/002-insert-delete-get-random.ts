export const url =
    '[Insert Delete GetRandom O(1)](https://leetcode.com/problems/insert-delete-getrandom-o1/description/)';

class RandomizedSet {
    valInfo: Map<number, number>;
    v: number[];
    constructor() {
        this.valInfo = new Map<number, number>();
        this.v = [];
    }

    insert(val: number): boolean {
        if (this.valInfo.has(val)) {
            return false;
        } else {
            const i = this.v.length;
            this.valInfo.set(val, i);
            this.v.push(val);
            return true;
        }
    }

    remove(val: number): boolean {
        if (this.valInfo.has(val)) {
            const index = this.valInfo.get(val)!;

            if (index === this.v.length - 1) {
                this.v.pop();
            } else {
                const lastElem = this.v.pop()!;
                this.v[index] = lastElem;
                this.valInfo.set(lastElem, index);
            }

            this.valInfo.delete(val);
            return true;
        } else {
            return false;
        }
    }

    getRandom(): number {
        const rInd = Math.floor(Math.random() * this.v.length);
        return this.v[rInd];
    }
}

var action = [
    'RandomizedSet',
    'insert',
    'remove',
    'insert',
    'getRandom',
    'remove',
    'insert',
    'getRandom',
];
var value = [[], [1], [2], [2], [], [1], [2], []];

var res: (boolean | number)[] = [];
var rS = new RandomizedSet();
for (let i = 0; i < action.length; ++i) {
    switch (action[i]) {
        case 'insert':
            res.push(rS.insert(value[i][0]));
            break;

        case 'remove':
            res.push(rS.remove(value[i][0]));
            break;

        case 'getRandom':
            res.push(rS.getRandom());
            break;

        default:
            break;
    }
}

console.log(res);
