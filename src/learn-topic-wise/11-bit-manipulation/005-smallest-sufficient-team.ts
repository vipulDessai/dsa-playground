export const url =
  '[Smallest Sufficient Team](https://leetcode.com/problems/smallest-sufficient-team/)';

function smallestSufficientTeam(
  req_skills: string[],
  people: string[][],
): number[] {
  const n = req_skills.length;
  const skillMap = new Map<string, number>();

  // Map each skill to an index
  req_skills.forEach((skill, i) => skillMap.set(skill, i));

  const peopleSkills = people.map((person) => {
    let mask = 0;
    for (const skill of person) {
      if (skillMap.has(skill)) {
        mask |= 1 << skillMap.get(skill)!;
      }
    }
    return mask;
  });

  const memo = new Map<number, number[]>();

  function dfs(skillMask: number): number[] {
    if (skillMask === 0) return [];
    if (memo.has(skillMask)) return memo.get(skillMask)!;

    let bestTeam: number[] = Array(people.length)
      .fill(0)
      .map((_, i) => i); // Worst case: all people

    for (let i = 0; i < people.length; i++) {
      const personSkill = peopleSkills[i];
      if ((skillMask & personSkill) === 0) continue; // Person doesn't contribute new skills

      const newSkillMask = skillMask & ~personSkill;
      const team = [i, ...dfs(newSkillMask)];

      if (team.length < bestTeam.length) {
        bestTeam = team;
      }
    }

    memo.set(skillMask, bestTeam);
    return bestTeam;
  }

  return dfs((1 << n) - 1);
}

console.log(
  smallestSufficientTeam(
    ['java', 'nodejs', 'reactjs'],
    [['java'], ['nodejs'], ['nodejs', 'reactjs']],
  ),
);
