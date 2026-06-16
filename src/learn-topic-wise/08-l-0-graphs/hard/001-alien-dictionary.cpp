#include <iostream>
#include <vector>

using namespace std;

namespace _001_alien_dictionary {
class Solution {
   public:
    string foreignDictionary(vector<string>& words) {
        return "";
    }
};
}  // namespace _001_alien_dictionary

class Execute {
   public:
    static void Main() {
        _001_alien_dictionary::Solution s;

        vector<string> input = {"z", "o"};

        cout << s.foreignDictionary(input) << endl;
    }
};

int main() {
    Execute::Main();
    return 0;
}