// | Operation | Worst Case |
// |-----------|------------|
// | enqueue   | O(log n)   |
// | dequeue   | O(log n)   |
// | peek      | O(1)       |
// | isEmpty   | O(1)       |
// | clear     | O(1)       |
// | size      | O(1)       |
// | toArray   | O(n)       |

interface PriorityQueueItem<T> {
  value: T;
  priority: number;
}

export class BinaryHeapPriorityQueue<T> {
  private heap: PriorityQueueItem<T>[] = [];
  private isMinHeap: boolean;

  /**
   * Creates a new Binary Heap Priority Queue.
   * @param isMinHeap If true, creates a min-priority queue (smallest priority at the top).
   * If false (or omitted), creates a max-priority queue (largest priority at the top).
   */
  constructor(isMinHeap: boolean = false) {
    this.isMinHeap = isMinHeap;
  }

  /**
   * Gets the index of the left child of the node at the given index.
   * @param index The index of the parent node.
   * @returns The index of the left child.
   */
  private getLeftChildIndex(index: number): number {
    return 2 * index + 1;
  }

  /**
   * Gets the index of the right child of the node at the given index.
   * @param index The index of the parent node.
   * @returns The index of the right child.
   */
  private getRightChildIndex(index: number): number {
    return 2 * index + 2;
  }

  /**
   * Gets the index of the parent of the node at the given index.
   * @param index The index of the child node.
   * @returns The index of the parent node.
   */
  private getParentIndex(index: number): number {
    return Math.floor((index - 1) / 2);
  }

  /**
   * Checks if the node at the given index has a left child.
   * @param index The index of the node.
   * @returns True if it has a left child, false otherwise.
   */
  private hasLeftChild(index: number): boolean {
    return this.getLeftChildIndex(index) < this.heap.length;
  }

  /**
   * Checks if the node at the given index has a right child.
   * @param index The index of the node.
   * @returns True if it has a right child, false otherwise.
   */
  private hasRightChild(index: number): boolean {
    return this.getRightChildIndex(index) < this.heap.length;
  }

  /**
   * Checks if the node at the given index has a parent.
   * @param index The index of the node.
   * @returns True if it has a parent, false otherwise.
   */
  private hasParent(index: number): boolean {
    return this.getParentIndex(index) >= 0;
  }

  /**
   * Gets the left child of the node at the given index.
   * @param index The index of the parent node.
   * @returns The left child item.
   */
  private leftChild(index: number): PriorityQueueItem<T> {
    return this.heap[this.getLeftChildIndex(index)];
  }

  /**
   * Gets the right child of the node at the given index.
   * @param index The index of the parent node.
   * @returns The right child item.
   */
  private rightChild(index: number): PriorityQueueItem<T> {
    return this.heap[this.getRightChildIndex(index)];
  }

  /**
   * Gets the parent of the node at the given index.
   * @param index The index of the child node.
   * @returns The parent item.
   */
  private parent(index: number): PriorityQueueItem<T> {
    return this.heap[this.getParentIndex(index)];
  }

  /**
   * Swaps two nodes in the heap.
   * @param indexOne The index of the first node.
   * @param indexTwo The index of the second node.
   */
  private swap(indexOne: number, indexTwo: number): void {
    const temp = this.heap[indexOne];
    this.heap[indexOne] = this.heap[indexTwo];
    this.heap[indexTwo] = temp;
  }

  /**
   * Restores the heap property by moving a node up the tree.
   * @param index The index of the node to heapify up.
   */
  private heapifyUp(index: number): void {
    while (
      this.hasParent(index) &&
      (this.isMinHeap
        ? this.parent(index).priority > this.heap[index].priority
        : this.parent(index).priority < this.heap[index].priority)
    ) {
      this.swap(this.getParentIndex(index), index);
      index = this.getParentIndex(index);
    }
  }

  /**
   * Restores the heap property by moving a node down the tree.
   * @param index The index of the node to heapify down.
   */
  private heapifyDown(): void {
    let index = 0;
    while (this.hasLeftChild(index)) {
      let childIndex = this.getLeftChildIndex(index);
      if (
        this.hasRightChild(index) &&
        (this.isMinHeap
          ? this.rightChild(index).priority < this.leftChild(index).priority // take the smallest out of left and right
          : this.rightChild(index).priority > this.leftChild(index).priority) // take the largest out of left and right
      ) {
        childIndex = this.getRightChildIndex(index);
      }

      if (
        this.isMinHeap
          ? this.heap[index].priority > this.heap[childIndex].priority
          : this.heap[index].priority < this.heap[childIndex].priority
      ) {
        this.swap(index, childIndex);
        index = childIndex;
      } else {
        break;
      }
    }
  }

  /**
   * Adds an item to the priority queue.
   * @param value The value of the item to add.
   * @param priority The priority of the item.
   */
  enqueue(value: T, priority: number): void {
    this.heap.push({ value, priority });
    this.heapifyUp(this.heap.length - 1);
  }

  /**
   * Removes and returns the item with the highest/lowest priority (root of the heap).
   * Returns undefined if the queue is empty.
   * @returns The value of the item with the highest/lowest priority, or undefined if empty.
   */
  dequeue(): T | undefined {
    if (this.isEmpty()) {
      return undefined;
    }

    if (this.heap.length === 1) {
      return this.heap.pop()!.value;
    }

    const root = this.heap[0];
    this.heap[0] = this.heap.pop()!;
    this.heapifyDown();
    return root.value;
  }

  /**
   * Returns the item with the highest/lowest priority without removing it (root of the heap).
   * Returns undefined if the queue is empty.
   * @returns The value of the item with the highest/lowest priority, or undefined if empty.
   */
  peek(): T | undefined {
    if (this.isEmpty()) {
      return undefined;
    }
    return this.heap[0].value;
  }

  /**
   * Returns the number of items in the priority queue.
   * @returns The size of the queue.
   */
  get size(): number {
    return this.heap.length;
  }

  /**
   * Checks if the priority queue is empty.
   * @returns True if the queue is empty, false otherwise.
   */
  isEmpty(): boolean {
    return this.heap.length === 0;
  }

  /**
   * Clears all items from the priority queue.
   */
  clear(): void {
    this.heap = [];
  }

  /**
   * Returns all items in the priority queue as an array (not necessarily in priority order).
   * For debugging or inspection purposes.
   * @returns An array of all items in the queue.
   */
  toArray(): PriorityQueueItem<T>[] {
    return [...this.heap];
  }
}

// Example Usage (Max-Priority Queue):
console.log('\n--- Max-Priority Queue Example ---');
const maxPriorityQueue = new BinaryHeapPriorityQueue<string>();

maxPriorityQueue.enqueue('Low Priority Task 1', 1);
maxPriorityQueue.enqueue('High Priority Task 1', 3);
maxPriorityQueue.enqueue('Medium Priority Task 1', 2);
maxPriorityQueue.enqueue('High Priority Task 2', 3);
maxPriorityQueue.enqueue('Low Priority Task 2', 1);

console.log('Max Priority Queue size:', maxPriorityQueue.size);
console.log('Max Priority Queue is empty:', maxPriorityQueue.isEmpty());
console.log('Max Priority Queue Peek:', maxPriorityQueue.peek());

console.log('Dequeueing from Max Priority Queue:');
while (!maxPriorityQueue.isEmpty()) {
  console.log(maxPriorityQueue.dequeue());
}

// Example Usage (Min-Priority Queue):
// console.log('\n--- Min-Priority Queue Example ---');
// const minPriorityQueue = new BinaryHeapPriorityQueue<string>(true);

// minPriorityQueue.enqueue('Urgent', 1);
// minPriorityQueue.enqueue('Normal', 3);
// minPriorityQueue.enqueue('Low', 5);
// minPriorityQueue.enqueue('Medium', 4);
// minPriorityQueue.enqueue('High', 2);

// console.log('Min Priority Queue size:', minPriorityQueue.size());
// console.log('Min Priority Queue is empty:', minPriorityQueue.isEmpty());
// console.log('Min Priority Queue Peek:', minPriorityQueue.peek());

// console.log('Dequeueing from Min Priority Queue:');
// while (!minPriorityQueue.isEmpty()) {
//   console.log(minPriorityQueue.dequeue());
// }
