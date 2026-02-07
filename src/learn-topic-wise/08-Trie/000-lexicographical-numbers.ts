export const url =
  '[Lexicographical Numbers](https://leetcode.com/problems/lexicographical-numbers/)';

interface TreeType {
  key: string;
  value: TreeType[];
}

class Trie {
  _tree: TreeType[] = [];
  insert = (word: string) => {
    dfs(this._tree, 0);

    function dfs(tree: TreeType[], i: number) {
      if (i < word.length) {
        for (let j = 0; j < tree.length; ++j) {
          const curTree = tree[j];
          if (curTree.key === word[i]) {
            dfs(curTree.value, i + 1);

            return;
          }
        }

        const cur = { key: word[i], value: [] };
        dfs(cur.value, i + 1);
        tree.push(cur);
      }
    }
  };
}

function lexicalOrder_my_own(n: number): number[] {
  const t = new Trie();
  for (let i = 1; i <= n; ++i) {
    t.insert(i.toString());
  }

  const res: number[] = [];
  function dfs(tree: TreeType[], word: string) {
    for (const curTree of tree) {
      const curWord = word.concat(curTree.key);
      res.push(parseInt(curWord));
      dfs(curTree.value, curWord);
    }
  }

  dfs(t._tree, '');

  return res;
}

var num = 24;
console.log(lexicalOrder_my_own(num));
