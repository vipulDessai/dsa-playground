// https://leetcode.com/problems/implement-queue-using-stacks/description/

#include <iostream>
#include <string>
#include <unordered_map>
#include <variant>
#include <vector>

using namespace std;

namespace _003_create_queue_using_stack {
class MyQueue {
    vector<int> qI;
    vector<int> qO;

   public:
    MyQueue() {
        qI = {};
        qO = {};
    }

    void push(int x) {
        qI.push_back(x);
    }

    int pop() {
        UpdateOutStack();

        int out = qO.back();
        qO.pop_back();
        return out;
    }

    int peek() {
        UpdateOutStack();

        return qO.back();
    }

    bool empty() {
        return qI.size() == 0 && qO.size() == 0 ? true : false;
    }

   private:
    void UpdateOutStack() {
        if (qO.size() == 0) {
            while (qI.size() > 0) {
                qO.push_back(qI.back());
                qI.pop_back();
            }
        }
    }
};

}  // namespace _003_create_queue_using_stack

class Execute {
   public:
    static void Main() {
        _003_create_queue_using_stack::MyQueue obj;
        vector<string> input1 = {"MyQueue", "push", "push", "peek", "pop", "empty"};
        vector<vector<int>> input2 = {{}, {1}, {2}, {}, {}, {}};

        using ResType = variant<int, bool, nullptr_t>;
        vector<ResType> res;

        for (int i = 0; i < input1.size(); ++i) {
            string cmd = input1[i];

            if (cmd == "MyQueue") {
                res.push_back(nullptr);
            } else if (cmd == "push") {
                obj.push(input2[i][0]);
                res.push_back(nullptr);
            } else if (cmd == "peek") {
                res.push_back(obj.peek());
            } else if (cmd == "pop") {
                res.push_back(obj.pop());
            } else if (cmd == "empty") {
                res.push_back(obj.empty());
            } else {
                cout << "Unknown command: " << cmd << endl;
            }
        }

        for (ResType cur : res) {
            visit([](auto&& arg) { cout << arg << endl; }, cur);
        }
    }
};

int main() {
    Execute::Main();
    return 0;
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue* obj = new MyQueue();
 * obj->push(x);
 * int param_2 = obj->pop();
 * int param_3 = obj->peek();
 * bool param_4 = obj->empty();
 */