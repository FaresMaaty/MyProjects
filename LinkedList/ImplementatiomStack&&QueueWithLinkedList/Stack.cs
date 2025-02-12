using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ImplementatiomStack__QueueWithLinkedList
{
    class StackWithLinkedList<T>
    {
        private Node Head; // العقدة الأولى
        private Node Tail; // العقدة الأخيرة
        Node temp;

        public int Count;
        // إضافة عنصر جديد في النهاية
        public void Push(T data)
        {
            Node newNode = new Node(data); // إنشاء عقدة جديدة

            if (Head != null) // لو القائمة فاضية
            {
                newNode.Next = Head;
                Head = newNode; // اجعل Head تشير لأول عقدة
            }
            else
            {
                Head = Tail = newNode;
                Tail.Next = newNode;
                newNode.Next = null; // اربط العقدة الجديدة بعد الـ Tail
            }
            Count++;
        }
        public T Pop()
        {

            int position = 0;
            temp = Head;
            if (Head == null)
            {
                Console.WriteLine("-1");       
            }
            if (position < 0 || position > Count)
            {
                Console.WriteLine("Out of Range linked list.");
            }
            if (position == 0)
            {
                Head = Head.Next;
            }
            else
            {
                Node temp1 = Head;//60
                for (int i = 0; i < position - 1; i++)
                {
                    temp1 = temp1.Next;//50
                }
                temp1.Next = temp1.Next.Next;//90
            }
            Count--;
            return (T)temp.Data;
        }
        public T Peek()
        {
            return (T)Head.Data;
        }
        public bool isEmpty()
        {
            return Count == 0;
        }
    }
}
