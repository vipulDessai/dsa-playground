// simple PQ usage

#include <string>

#include "priority-queue.hpp"

using namespace std;
using namespace utils;
class Execute {
   public:
    static void Main() {
        string input = "1432219";

        BinaryHeapPriorityQueue<int>* q = new BinaryHeapPriorityQueue<int>();

        for (int i = 0; i < input.size(); ++i) {
            int cur = input[i] - '0';
            q->enqueue(cur, cur);
        }

        while (q->size() > 0) {
            cout << q->dequeue()->v;
        }
    }
};

int main() {
    Execute::Main();
    return 0;
}