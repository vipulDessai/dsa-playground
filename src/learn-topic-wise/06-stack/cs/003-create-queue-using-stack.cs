namespace learning_dsa_csharp._04_stack._003_create_queue_using_stack
{
    public class MyQueue_MySonl
    {
        Stack<int> qI;
        Stack<int> qO;

        public MyQueue_MySonl()
        {
            qI = new Stack<int>();
            qO = new Stack<int>();
        }

        public void Push(int x)
        {
            qI.Push(x);
        }

        public int Pop()
        {
            UpdateOutStack();
            return qO.Pop();
        }

        public int Peek()
        {
            UpdateOutStack();
            return qO.Peek();
        }

        public bool Empty()
        {
            return qI.Count == 0 && qO.Count == 0 ? true : false;
        }

        private void UpdateOutStack()
        {
            if (qO.Count == 0)
            {
                while (qI.Count > 0)
                {
                    qO.Push(qI.Pop());
                }
            }
        }
    }
}
