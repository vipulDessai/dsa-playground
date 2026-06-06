// [Merge In Between Linked Lists](https://leetcode.com/problems/merge-in-between-linked-lists/)

#include <generate-linked-list.h>

#include <iostream>

using namespace std;
using namespace utils;

namespace _012_merge_in_between_linkedlist {
class Solution {
   public:
    ListNode* mergeInBetween(ListNode* list1, int a, int b, ListNode* list2) {
        ListNode* l2EndNode = list2;
        while (l2EndNode->next != nullptr) {
            l2EndNode = l2EndNode->next;
        }

        ListNode *l1StartNode, *l1EndNode;

        ListNode* cur = list1;
        while (cur != nullptr) {
            --a;

            if (a == 0) {
                l1StartNode = cur;
            }

            if (b == 0) {
                l1EndNode = cur->next;

                break;
            }

            cur = cur->next;
            --b;
        }

        l1StartNode->next = list2;
        l2EndNode->next = l1EndNode;

        return list1;
    }
};
}  // namespace _012_merge_in_between_linkedlist

class Execute {
   public:
    static void Main() {
        vector<int> l1 = {10, 1, 13, 6, 9, 5};
        vector<int> l2 = {1000000, 1000001, 1000002};

        int a = 3, b = 4;

        ListNode* inputL1 = LinkedListGenerator::Generate(l1);
        ListNode* inputL2 = LinkedListGenerator::Generate(l2);

        _012_merge_in_between_linkedlist::Solution s;
        ListNode* out = s.mergeInBetween(inputL1, a, b, inputL2);

        while (out != nullptr) {
            cout << out->val << endl;

            out = out->next;
        }
    }
};

int main() {
    Execute::Main();

    return 0;
};