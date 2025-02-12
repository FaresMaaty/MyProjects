using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp15
{
    class CirculyLinkedList
    {
        private Node Head; // العقدة الأولى
        private Node Tail; // العقدة الأخيرة
        int length;
        // إضافة عنصر جديد في النهاية
        public void insertFirst(int data)
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
            Tail.Next = Head;
            length++;
        }
        public void insertLast(int data)
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
                Tail.Next = Head;

            }
            Tail.Next = Head;
            length++;
        }
        public void insertAtPosition(int position, int value)
        {
            Node newNode = new Node(value);

            if (position < 0 || position > length)
            {
                Console.WriteLine("Out of Range linked list.");
            }
            else
            {
                if (position == 0)
                {
                    newNode.Next = Head;
                    Head = newNode;//
                }
                else if (position == length)
                {
                    newNode.Next = Tail;
                }
                else
                {
                    Node current = Head;
                    for (int i = 1; i < position; i++)
                    {
                        current = current.Next;
                    }
                    newNode.Next = current.Next;//Next
                    current.Next = newNode;
                }
            }
            Tail.Next = Head;

        }
        public void deleteAtPosition(int position)
        {
            if (Head == null)
            {
                return;
            }
            if (position < 0 || position > length)
            {
                Console.WriteLine("Out of Range linked list.");
            }
            if (position == 0)
            {
                Node temp = Head;
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
            Tail.Next = Head;
            length--;
        }
        public void Reverse()
        {
            if (Head == null)
            {
                return;
            }
            else
            {
                Node prevuos = null;
                Node curr = Head;//001
                Node next = null;

                while (curr != null)
                {
                    next = curr.Next;//002
                    curr.Next = prevuos;//null
                    prevuos = curr;//001
                    curr = next;//002
                }
                Head = prevuos;
            }
            Tail.Next = Head;
        }
        public int Search(int data)
        {
            Node curr = Head;
            int position = 0;

            while (curr != null)
            {
                if (curr.Data == data)
                {
                    return position;
                }
                curr = curr.Next;
                position++;
            }
            return -1;
        }
        // طباعة العناصر
        public void Print()
        {
            Node current = Head;

            while (current != null)
            {
                Console.Write(current.Data + " -> ");
                current = current.Next;
            }
            Console.WriteLine("null");
        }

        // عرض آخر عنصر (Tail)
        public int GetTail()
        {
            if (Tail != null)
            {
                return Tail.Data; // إرجاع بيانات العقدة الأخيرة
            }
            throw new InvalidOperationException("The list is empty!");
        }
    }
}
