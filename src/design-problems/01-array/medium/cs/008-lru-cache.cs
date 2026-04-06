using System.Collections.Generic;

namespace learning_dsa_csharp._06_linked_list._008_lru_cache
{
    public class LRUCache
    {
        private int c { get; set; }
        private Dictionary<int, Node> cache { get; set; } = new Dictionary<int, Node>();
        private Node l { get; set; }
        private Node r { get; set; }

        public LRUCache(int capacity)
        {
            c = capacity;
            l = new Node(0, 0);
            r = new Node(0, 0);
            l.next = r;
            r.prev = l;
        }

        public int Get(int key)
        {
            if (cache.ContainsKey(key))
            {
                Remove(cache[key]);
                Insert(cache[key]);
                return cache[key].value;
            }

            return -1;
        }

        public void Put(int key, int value)
        {
            if (cache.ContainsKey(key))
            {
                Remove(cache[key]);
            }

            cache.Add(key, new Node(key, value));
            Insert(cache[key]);

            if (cache.Count > c)
            {
                // remove from the list and delete the LRU from the hashmap
                var lru = l.next;
                Remove(lru);

                cache.Remove(lru.key);
            }
        }

        private void Remove(Node n)
        {
            var next = n.next;
            var prev = n.prev;

            prev.next = next;
            next.prev = prev;
        }

        private void Insert(Node n)
        {
            var prev = r.prev;

            n.next = r;
            n.prev = prev;

            r.prev = prev.next = n;
        }
    }

    class Node
    {
        public int key;
        public int value;
        public Node next = null;
        public Node prev = null;

        public Node(int _key, int _value)
        {
            key = _key;
            value = _value;
        }
    }
}
