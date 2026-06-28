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
array<int, 2> dfs(vector<vector<int>>& land, int r, int c) {}
auto [x, y] = dfs(land, i, j);

vector<vector<int>> edges = {{1,0}, {1,2}, {1,3}};
```

## c#

```c#

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
```

## Py

```py
distance = [0] * n

size(distance)
```

## CPP

```cpp
array<bool, 2> nei = {{false, false}};
array<array<int, 2>, 4> fixedSizeArr = {{{1, 0}, {0, 1}}};

size(nei); 
nei.size();
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
