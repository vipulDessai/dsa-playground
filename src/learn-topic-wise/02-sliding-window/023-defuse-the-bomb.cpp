// [Defuse the Bomb](https://leetcode.com/problems/defuse-the-bomb/description)

#include <iostream>
#include <vector>

using namespace std;

namespace _023_defuse_th_bomb
{
    class MySoln
    {
    public:
        vector<int> decrypt(vector<int> &code, int k)
        {
            int n = code.size();

            if (k == 0)
            {
                return vector<int>(n, 0);
            }

            if (k > 0)
            {
                int sum = 0;
                for (int i = 0; i < k; ++i)
                {
                    sum += code[i];
                }

                vector<int> res;
                for (int i = 0; i < n; ++i)
                {
                    sum -= code[i];
                    sum += code[(i + k) % n];
                    res.push_back(sum);
                }
                return res;
            }
            else
            {
                int sum = 0;
                for (int i = n - 1; i >= n + k; --i)
                {
                    sum += code[i];
                }

                vector<int> res;
                for (int i = n - 1; i >= 0; --i)
                {
                    sum -= code[i];
                    sum += code[(i + (n + k)) % n];
                    res.push_back(sum);
                }
                return res;
            }
        }
    };
};

class Execute
{
public:
    static void Main()
    {
        _023_defuse_th_bomb::MySoln obj;
        vector<int> input = {5, 7, 1, 4};
        int k = 3;

        input = {2, 4, 9, 3};
        k = -2;
        vector<int> res = obj.decrypt(input, k);

        for (int n : res)
        {
            cout << n;
        }
    }
};

int main()
{
    Execute::Main();
    return 0;
}