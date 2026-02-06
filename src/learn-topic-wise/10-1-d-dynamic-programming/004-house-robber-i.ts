function rob1(nums: number[]): number {
  let r1 = 0,
    r2 = 0;

  // [r1, r2, n, n+1, ...]
  for (const i in nums) {
    [r1, r2] = [r2, Math.max(r1 + nums[i], r2)];
    console.log(r1, r2);
  }

  return r2;
}

rob1([1, 2, 3, 1]);
