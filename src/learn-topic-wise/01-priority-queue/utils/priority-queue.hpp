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
    bool isMinHeap = true;

    int getParent(int i) {
        return (i - 1) / 2;
    }
    int getLeftChild(int i) {
        return i * 2 + 1;
    }
    int getRightChild(int i) {
        return i * 2 + 2;
    }

    bool shouldSwap(int i, int j) {
        return heap[i]->p < heap[j]->p;
    }

    void heapifyUp() {
        int n = heap.size();
        int i = n - 1;
        int j = getParent(i);

        while(j >= 0 && shouldSwap(i, j)) {
            std::swap(heap[j], heap[i]);

            i = j;
            j = getParent(i);
        }
    }

    void heapifyDown() {
        int n = heap.size();

        int i = 0;
        int j = getLeftChild(i);

        while(j < n) {
            int rInd = getRightChild(i);

            if(rInd < n && shouldSwap(rInd, j)) {
                j = rInd;
            }

            if(shouldSwap(j, i)) {
                std::swap(heap[j], heap[i]);

                i = j;
                j = getLeftChild(i);
            }
            else {
                break;
            }
        }
    }

   public:
    BinaryHeapPriorityQueue() = default;
    BinaryHeapPriorityQueue(bool isMin) {
        isMinHeap = isMin;
    };
    void enqueue(T value, int priority) {
        heap.push_back(new BinaryHeapPriorityQueueNode<T>(value, priority));
        heapifyUp();
    };
    BinaryHeapPriorityQueueNode<T>* dequeue() {
        int n = heap.size();

        if(n == 0) return nullptr;

        if(n == 1) {
            BinaryHeapPriorityQueueNode<T>* top = heap[0];
            heap.pop_back();

            return top;
        }

        BinaryHeapPriorityQueueNode<T>* top = heap[0];
        heap[0] = heap.back();
        heap.pop_back();

        heapifyDown();

        return top;
    };

    int size() {
        return heap.size();
    }
};

}  // namespace utils

#endif