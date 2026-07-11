# logs

## CPP

```cpp
cout << var1 << ": " << var2 << endl;

// print array
for (int v : value) {
    cout << v << " ";
}
```

# Min / Max Integer/Float

## CPP

```cpp

#include <limits>
using namespace std;

int MIN_INT = numeric_limit<int>::min();
int MAX_INT = numeric_limit<int>::max();
```

## Py

```py
MIN_INT = -(2**31)
MAX_INT = 2**31

MIN_FLOAT = float("-inf")
MAX_FLOAT = float("inf")
```

## C#

```cs
int MIN_INT = int.MinValue();
int MAX_INT = int.MaxValue();
```

## JS

```js
Number.MIN_SAFE_INTEGER; // -9007199254740991
Number.MAX_SAFE_INTEGER; //  9007199254740991 (≈ 9 quadrillion)

Number.MIN_VALUE; // ≈ 5e-324
Number.MAX_VALUE; // ≈ 1.7976931348623157e+308
```

# Floor

```cpp
int m = floor(l + (r - l) / 2)
```

# Max element

## CPP

```cpp
using namespace std;

vector<int> nums = {1, 2, 10, 4, 5, 6};

// max_element return index or iterator, thats why a *
int _m = *max_element(nums.begin(), nums.end());    // 10
```

## Py

```py
nums = [1, 2, 10, 4, 5, 6]
_m = max(nums) # 10
```

## C#

```cs
int[] nums = {1, 2, 10, 4, 5, 6};
int _m = nums.Max(); // 10
```

# Destructure

## CPP

```cpp
array<int, 2> dfs(vector<vector<int>>& land, int r, int c) {
    // function logic
}
auto [x, y] = dfs(land, i, j);
```

### cpp - cant destructure

-   vectors

## c#

Only supports `tuple` destructuring

```c#
var point = (1, 2, 3, 4);
var (a, b, c, d) = point;   // x=1, y=2

var (_, _, _, fourthVar) = point // special _ is used for discard, can be used many times
```

# Initialization

## C#

```cs
string s = "0202";
string[] strArr = { s, "0101", "0102", "1212", "2002" };

StringBuilder sb1 = new(s);

HashSet<string> dead = [.. strArr];
HashSet<string> visited = ["0000"];

Queue<string> q = new();
q.Enqueue("0000");

// rectangular array (same size of cols for every row)
int[,] arr = new int[m, n];

// fixed size and values array
int[,] dir = {{-1, 0}, {0, 1}, {1, 0}, {0, -1}};

int nR = r + dir[0, 0];

dir.Length;        // 8  (4 * 2, total elements)
dir.GetLength(0);  // 4   (size of dimension 0 = rows)
dir.GetLength(1);  // 2   (size of dimension 1 = columns)

// jagged array
int[][] jagged = new int[m][];
for (int i = 0; i < m; i++)
    jagged[i] = new int[n];
```

### named fields

```cs
var dir = new (int dr, int dc)[] {
    (-1, 0), (0, 1), (1, 0), (0, -1)
};
foreach (var (dr, dc) in dirs) {
    int nr = r + dr, nc = c + dc;
    // more code
}

// as a class member
class Solution {
    // by default class members are private
    // readonly is just to prevent reassign
    private readonly (int dr, int dc)[] dirs = {
        (-1, 0), (0, 1), (1, 0), (0, -1)
    };
}
```

### optional

```c#
List<int?> list = new List<int?> { 1, null, 3 };

int?[] arr = new int?[5] { 1, null, 3, null, 5 };
int?[] arr = { 1, null, 3, null, 5 };
```

## Py

```py
distance = [0] * n

size(distance)

dist = [[-1] * n for _ in range(m)]
```

## CPP

```cpp
array<bool, 2> nei = {{false, false}};
array<array<int, 2>, 4> fixedSizeArr = {{{1, 0}, {0, 1}}};

size(nei);
nei.size();
```

### optional

```cpp
#include <optional>

using namespace std;

vector<optional<int>> input = {1, 2, 3, nullopt, nullopt, 4, 5};

if(input[0].has_value()) {
    // if .value() is called without .has_value()
    // and if input[0] is nullopt, then CPP throws error
    // Caught exception: bad optional access
    int num = input[0].value();
}
```

# Hash Set and Map

## CPP

### Set

```cpp
#include <unordered_set>

using namespace std;

std::unordered_set<int> s;

s.insert(5);
s.count(5);            // 0 or 1
s.contains(5);         // C++20, bool
s.erase(5);
s.size();

for (int x : s) { }
```

### Map

```cpp
#include <unordered_map>

using namespace std;

unordered_map<int, vector<int>> adjList;

for (int i = 0; i < edges.size(); ++i) {
    auto e = edges[i];
    adjList[e[0]].push_back(e[1]);
    adjList[e[1]].push_back(e[0]);
}

if (adjList.count(key))           // contains in c#
{
    // adjList contains key
}

for (auto& [key, value] : adjList) {
    cout << key << " " << value << endl;
}
```

# Pointers

## CPP

```cpp
int x = 10;

int* ptr = &x;   // ptr is a variable holding x's address
*ptr = 20;
cout << x; // prints 20

int& ref = x;    // ref IS x, just another name (alias) for it
ref = 30;
cout << x; // prints 30

int copy = x;   // plain new assignment
copy = 40;
cout << x; // prints 30

TreeNode* createBinaryTree(vector<vector<int>>& descriptions) {
    // `new` always returns an address
    TreeNode* root = new TreeNode(0);
    // some logic
    return root;
}

Solution s;

TreeNode* outPtr = s.createBinaryTree(des);
cout << outPtr->val << endl;

// * dereferences the pointer
// but outRef points to the same memory, NO COPY
TreeNode& outRef = *s.createBinaryTree(des);
cout << outRef.val << endl;

// creates a new object at a different memory location
TreeNode outCopy = *s.createBinaryTree(des);  // * dereferences the pointer
cout << outCopy.val << endl;
```

# Conversions

```cpp
#include <string>

using namespace std;

string s = "10"
int num = stoi(s);
```

# Split Array

## CPP

```cpp
#include <sstream>
#include <string>

using namespace std;

string s = "1,2,3,#,4,5"

stringstream ss(s);
string token;

vector<string> arr;
while(getline(ss, token, ',')) {
    arr.push_back(token);
}

arr // {1, 2, 3, #, 4, 5}
```
