// https://www.interviewcake.com/concept/java/dijkstras-algorithm
// https://www.geeksforgeeks.org/problems/implementing-dijkstra-set-1-adjacency-matrix/1
export class pQDijkstra {
    q: { priority: number; value: number }[] = [];

    getParent(i: number) {
        return Math.floor((i - 1) / 2);
    }

    getLeftChild(i: number) {
        return i * 2 + 1;
    }

    getRightChild(i: number) {
        return i * 2 + 2;
    }

    enqueue(value: number, priority: number) {
        this.q.push({ value, priority });

        const n = this.q.length;

        let i = n - 1,
            pI = this.getParent(i);

        while (pI >= 0 && this.q[i].priority < this.q[pI].priority) {
            [this.q[pI], this.q[i]] = [this.q[i], this.q[pI]];
            i = pI;
            pI = this.getParent(i);
        }
    }

    dequeue() {
        if (this.q.length === 0) return null;

        if (this.q.length === 1) return this.q.pop()!;

        const root = this.q[0];
        this.q[0] = this.q.pop()!;

        let i = 0,
            j = this.getLeftChild(i);

        const n = this.q.length;
        while (j < n) {
            const rI = this.getRightChild(i);

            if (rI < n && this.q[rI].priority < this.q[j].priority) {
                j = rI;
            }

            if (this.q[i].priority > this.q[j].priority) {
                [this.q[j], this.q[i]] = [this.q[i], this.q[j]];

                i = j;
                j = this.getLeftChild(i);
            } else {
                break;
            }
        }

        return root;
    }

    get length() {
        return this.q.length;
    }
}

// TEST PQ
// const pQ = new pQDijkstra();
// const input = [3, 1, 2];
// for (let i = 0; i < input.length; ++i) {
//   const cur = input[i];
//   pQ.enqueue(cur, cur);
// }
// while (pQ.length) {
//   console.log(pQ.dequeue());
// }

// here the edges are bidirectional
export function dijkstra(v: number, edges: number[][], src: number) {
    const adjList = new Map<number, { dst: number; w: number }[]>();
    for (const e of edges) {
        const [s, d, w] = e;

        if (!adjList.has(s)) {
            adjList.set(s, []);
        }

        if (!adjList.has(d)) {
            adjList.set(d, []);
        }

        adjList.get(s)?.push({ dst: d, w });
        adjList.get(d)?.push({ dst: s, w });
    }

    const res = Array(v).fill(Infinity);
    function bfs() {
        const pQ = new pQDijkstra();
        pQ.enqueue(src, 0);
        res[src] = 0;

        while (pQ.length > 0) {
            const q: { value: number; priority: number }[] = [];

            while (pQ.length) {
                q.push(pQ.dequeue()!);
            }

            for (const { value, priority: distance } of q) {
                const dstList = adjList.get(value);
                if (dstList) {
                    for (const { dst, w } of dstList) {
                        const curDistance = distance + w;
                        if (curDistance < res[dst]) {
                            pQ.enqueue(dst, curDistance);
                            res[dst] = curDistance;
                        }
                    }
                }
            }
        }
    }

    bfs();

    return res;
}

// console.log(
//   dijkstra(
//     3,
//     [
//       [0, 1, 1],
//       [1, 2, 3],
//       [0, 2, 6],
//     ],
//     2,
//   ),
// );

// console.log(
//   dijkstra(
//     4,
//     [
//       [0, 1, 1],
//       [0, 2, 20],
//       [1, 3, 1],
//       [2, 3, 1],
//     ],
//     0,
//   ),
// );

// console.log(
//   dijkstra(
//     5,
//     [
//       [0, 1, 4],
//       [0, 2, 8],
//       [1, 4, 6],
//       [2, 3, 2],
//       [3, 4, 10],
//     ],
//     0,
//   ),
// );
