#include "generate-linked-list.h"

#include <iostream>
#include <vector>

using namespace std;

namespace utils {

// Define constructors
ListNode::ListNode() : val(0), next(nullptr) {}
ListNode::ListNode(int x) : val(x), next(nullptr) {}
ListNode::ListNode(int x, ListNode* next) : val(x), next(next) {}

ListNode* LinkedListGenerator::Generate(vector<int> arr) {
    auto n = arr.size();

    ListNode* head = new ListNode();
    ListNode* next = head;
    for (int i = 0; i < n; ++i) {
        next->val = arr[i];
        next->next = nullptr;

        if (i < n - 1) {
            next->next = new ListNode();
            next = next->next;
        }
    }

    return head;
};

}  // namespace utils
