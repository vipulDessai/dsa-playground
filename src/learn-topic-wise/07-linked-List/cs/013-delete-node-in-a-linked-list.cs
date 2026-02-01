// https://leetcode.com/problems/delete-node-in-a-linked-list/
namespace learning_dsa_csharp._06_linked_list._013_delete_node_in_a_linked_list
{
    internal class MySoln
    {
        public void DeleteNode(ListNode node)
        {
            node.val = node.next.val;
            node.next = node.next.next;
        }
    }
}
