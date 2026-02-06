function rob2(nums: number[]): number {
  function houseRobber1(nums: number[]) {
    let r1 = 0,
      r2 = 0;

    // [r1, r2, n, n+1, ...]
    // up untill the index, what is the max
    // we can rob in those adjacent items
    for (const i in nums) {
      [r1, r2] = [r2, Math.max(r1 + nums[i], r2)];
    }

    return r2;
  }

  // num[0] in case of the array has only one item
  return Math.max(
    nums[0],
    houseRobber1(nums.slice(1, nums.length)),
    houseRobber1(nums.slice(0, nums.length - 1)),
  );
}
