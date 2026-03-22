export const url =
    '[Reveal Cards In Increasing Order](https://leetcode.com/problems/reveal-cards-in-increasing-order/description/)';

function deckRevealedIncreasing(deck: number[]): number[] {
    const n = deck.length;

    // since the condition "You can order the deck in any order you want"
    // but final answer should be increasing order, its better to sort
    deck.sort((a, b) => a - b);

    const q = Array.from({ length: n }, (_, i) => i),
        res = new Array(n);
    for (const d of deck) {
        const i = q.shift()!;

        res[i] = d;

        q.push(q.shift()!);
    }

    return res;
}

var input = [17, 13, 11, 2, 3, 5, 7];
console.log(deckRevealedIncreasing(input));
