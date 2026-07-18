#ifndef COMMON_UTILS_H
#define COMMON_UTILS_H

#include <iostream>
#include <vector>

namespace utils {

template <typename T>
struct BinaryHeapPriorityQueueNode {
    T v;
    int p;
    BinaryHeapPriorityQueueNode(T value, int priority) : v(value), p(priority) {};
};

template <typename T>
class BinaryHeapPriorityQueue {
   private:
    std::vector<BinaryHeapPriorityQueueNode<T>*> heap;

   public:
    BinaryHeapPriorityQueue() = default;
    void enqueue(T value, int priority) {
        heap.push_back(new BinaryHeapPriorityQueueNode<T>(value, priority));
    };
    BinaryHeapPriorityQueueNode<T>* dequeue() {
        return heap[0];
    };
};

}  // namespace utils

#endif