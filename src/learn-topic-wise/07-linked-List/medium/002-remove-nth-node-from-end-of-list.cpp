// [Remove Nth Node From End of List](https://leetcode.com/problems/remove-nth-node-from-end-of-list/description/)

#include <iostream>
#include <vector>

#include "generate-linked-list.h"

using namespace std;
using namespace utils;

namespace _003_remove_nth_node_from_end_of_list {

class Solution {
   public:
    ListNode* removeNthFromEnd(ListNode* head, int n) {
        int len = 0;

        ListNode* t = head;
        while (t != nullptr) {
            t = t->next;
            ++len;
        }

        int remInd = len - n;

        if (remInd == 0) {
            head = head->next;
        } else {
            t = head;
            while (remInd > 1) {
                t = t->next;
                --remInd;
            }

            t->next = t->next->next;
        }

        return head;
    }
};
}  // namespace _003_remove_nth_node_from_end_of_list

class Execute {
   public:
    static void Main() {
        vector<int> input = {1, 2, 3, 4, 5};
        ListNode* inputList = LinkedListGenerator::Generate(input);

        _003_remove_nth_node_from_end_of_list::Solution s;
        int n = 2;
        auto out = s.removeNthFromEnd(inputList, n);

        while (out != nullptr) {
            cout << out->val << endl;
            out = out->next;
        }
    }
};

int main() {
    Execute::Main();
    return 0;
}