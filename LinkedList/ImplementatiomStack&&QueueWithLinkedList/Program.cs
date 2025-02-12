namespace ImplementatiomStack__QueueWithLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StackWithLinkedList<string> st = new StackWithLinkedList<string>();
            st.Push("a");
            st.Push("b");
            st.Push("c");
            st.Push("d");

            Console.WriteLine(st.Peek());
            Console.WriteLine(st.Pop());
            Console.WriteLine(st.Peek());

            Console.WriteLine("******************************");

            QueueWithLinkedList<string> qu = new QueueWithLinkedList<string>();
            qu.Enqueue("a");
            qu.Enqueue("b");
            qu.Enqueue("c");
            qu.Enqueue("d");

            Console.WriteLine(qu.Peek());
            Console.WriteLine(qu.Dequeue());
            Console.WriteLine(qu.Peek());
        }
    }
}
