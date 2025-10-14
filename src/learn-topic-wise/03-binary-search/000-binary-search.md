# binary saerch

# common template

- if a target exists in the array use

```ts
while (l <= r) {
  const m = Math.floor(l + (r - l) / 2);

  if (nums[m] === target) {
    return m;
  } else if (nums[m] > target) {
    r = m - 1;
  } else {
    l = m + 1;
  }
}

return -1;
```

- if its finding the answer is in a range

```ts
while (l < r) {
  // refer the common range based template
  // like
  // 1. square root
  // 2. koko-eating-banana
  // etc
}
```

# blogs

- https://leetcode.com/problems/minimum-number-of-days-to-make-m-bouquets/solutions/769703/python-clear-explanation-powerful-ultimate-binary-search-template-solved-many-problems
