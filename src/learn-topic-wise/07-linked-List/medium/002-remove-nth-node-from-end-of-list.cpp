#include <iostream>
#include <vector>

#include "generate-linked-list.h"

using namespace std;

struct ListNode {
    int val;
    ListNode* next;
    ListNode() : val(0), next(nullptr) {}
    ListNode(int x) : val(x), next(nullptr) {}
    ListNode(int x, ListNode* next) : val(x), next(next) {}
};

namespace _003_remove_nth_node_from_end_of_list {

class Solution {
   public:
    ListNode* removeNthFromEnd(ListNode* head, int n) {
        // ListNode t = new ListNode(0);
        // t.next = head;

        // ListNode l = t;
        // ListNode r = head;

        // while (n > 0 && r != null) {
        //     r = r.next;
        //     n--;
        // }

        // while (r != null) {
        //     r = r.next;
        //     l = l.next;
        // }

        // l.next = l.next.next;

        return head;
    }
};
}  // namespace _003_remove_nth_node_from_end_of_list

class Execute {
   public:
    static void Main() {
        _003_remove_nth_node_from_end_of_list::Solution obj;

        printHello();
    }
};

int main() {
    Execute::Main();
    return 0;
}