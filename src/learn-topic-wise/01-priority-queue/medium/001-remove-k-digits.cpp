// https://leetcode.com/problems/remove-k-digits/description/

#include <string>

#include "priority-queue.hpp"

using namespace std;
using namespace utils;

namespace _049_remove_k_digits {
class MySoln_string_only {
    // fails for k = 3 and "111111" i.e. all same digits
   public:
    string RemoveKdigits(string num, int k) {
        int n = num.size();
        if (n == k)
            return "0";

        num = num + '0';

        string sB = "";
        for (int i = 0; i < n; ++i) {
            if (num[i] > num[i + 1] & k > 0) {
                --k;
            } else {
                sB += to_string(num[i]);
            }
        }

        auto res = sB;
        sB = "";

        bool f = false;
        for (int i = 0; i < res.size(); ++i) {
            if (res[i] != '0' && !f) {
                f = true;
            }

            if (f) {
                sB += res[i];
            }
        }

        res = sB;
        return res == "" ? "0" : res;
    }
};

class Solution {
   public:
    string removeKdigits(string num, int k) {
        return num;
    }
};
}  // namespace _049_remove_k_digits

class Execute {
   public:
    static void Main() {
        _049_remove_k_digits::Solution s;

        string input = "1432219";
        int k = 3;
        cout << s.removeKdigits(input, k);

        BinaryHeapPriorityQueue<int>* q = new BinaryHeapPriorityQueue<int>();

        int p = 0;

        q->enqueue(0, 0);

        cout << q->dequeue()->v;
    }
};

int main() {
    Execute::Main();
    return 0;
}