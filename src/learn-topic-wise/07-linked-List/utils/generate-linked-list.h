#ifndef COMMON_UTILS_H
#define COMMON_UTILS_H

#include <vector>

namespace utils {

struct ListNode {
    int val;
    ListNode* next;

    ListNode();
    ListNode(int x);
    ListNode(int x, ListNode* next);
};
class LinkedListGenerator {
public:
    static ListNode* Generate(std::vector<int> arr);
};

} // namespace utils

#endif