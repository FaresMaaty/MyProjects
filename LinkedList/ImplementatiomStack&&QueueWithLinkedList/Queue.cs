using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ImplementatiomStack__QueueWithLinkedList
{
    class QueueWithLinkedList<T>
    {
        private Node Head; // العقدة الأولى
        private Node Tail; // العقدة الأخيرة
        Node temp;

        public int Count;
        // إضافة عنصر جديد في النهاية
        public void Enqueue(T data)
        {
            Node newNode = new Node(data); // إنشاء عقدة جديدة

            if (Head == null) // لو القائمة فاضية
            {
                Head = newNode; // اجعل Head تشير لأول عقدة
                Tail = newNode; // Tail تشير لنفس العقدة
            }
            else
            {
                Tail.Next = newNode; // اربط العقدة الجديدة بعد الـ Tail
                Tail = newNode;     // اجعل Tail تشير للعقدة الجديدة
            }
            Count++;
        }
        public T Dequeue()
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
            if (Head == Tail)
            {
                T data = (T)temp.Data;
                Head = Tail = temp = null;
                Count--;
                return data;
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
