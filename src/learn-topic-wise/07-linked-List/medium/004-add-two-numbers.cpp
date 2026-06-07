// [Add Two Numbers](https://leetcode.com/problems/add-two-numbers/description/)

#include <iostream>
#include <vector>

#include "generate-linked-list.h"

using namespace std;
using namespace utils;

namespace _005_add_two_numbers {
class Solution {
   public:
    ListNode* addTwoNumbers(ListNode* l1, ListNode* l2) {
        ListNode* d = new ListNode();
        ListNode* cur = d;

        int carry = 0;
        while (l1 != nullptr || l2 != nullptr || carry > 0) {
            int v1 = (int)(l1 != nullptr ? l1->val : 0);
            int v2 = (int)(l2 != nullptr ? l2->val : 0);

            // new digit
            int val = v1 + v2 + carry;

            carry = (val - (val % 10)) / 10;  // Math.floor(val / 10)
            val = val % 10;

            cur->next = new ListNode(val);

            // update pointers
            cur = cur->next;
            l1 = l1 != nullptr ? l1->next : nullptr;
            l2 = l2 != nullptr ? l2->next : nullptr;
        }

        // returning the next as the first one
        // value is empty
        return d->next;
    }
};
}  // namespace _005_add_two_numbers

class Execute {
   public:
    static void Main() {
        vector<int> input1 = {2, 4, 3};
        vector<int> input2 = {5, 6, 4};
        ListNode* inputList1 = LinkedListGenerator::Generate(input1);
        ListNode* inputList2 = LinkedListGenerator::Generate(input2);

        _005_add_two_numbers::Solution s;
        auto out = s.addTwoNumbers(inputList1, inputList2);

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