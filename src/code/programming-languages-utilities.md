# Min / Max integer

## CPP

```cpp

#include <limits>
using namespace std;

int MIN_INT = numeric_limit<int>::min();
int MAX_INT = numeric_limit<int>::max();
```

## Py

```py
MIN_INT = -2**31
MAX_INT = 2**31
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
