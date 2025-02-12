using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    class DoublyLinkedList
    {
        NodeDoubly head;
        NodeDoubly tail;
        public int Count;
        public void insertFirst(int data)
        {
            NodeDoubly newNode = new NodeDoubly(data); // إنشاء عقدة جديدة

            if (head != null) // لو القائمة فاضية
            {
                newNode.Next = head;
                head.Previous = newNode;
                head = newNode;
            }
            else
            {
                head = tail = newNode;
                tail.Next = newNode;
                newNode.Next = null; // اربط العقدة الجديدة بعد الـ Tail
            }
            Count++;
        }
        public void insertLast(int data)
        {
            NodeDoubly newNode = new NodeDoubly(data);
            if (head == null)
            {
                head = tail = newNode;
                newNode.Next = newNode.Previous = null;
            }
            else
            {
                if (head != null)
                {
                    newNode.Previous = tail;
                    tail.Next = newNode;
                    tail = newNode;

                }
            }
            Count++;
        }
        public void insertAtPosition(int position, int value)
        {
            NodeDoubly newNode = new NodeDoubly(value);

            if (position < 0 || position > Count)
            {
                Console.WriteLine("Out of Range linked list.");
            }
            else
            {
                if (position == 0)
                {
                    insertFirst(value);
                }
                else if (position == Count)
                {
                    insertLast(value);
                }
                else
                {
                    NodeDoubly current = head;
                    for (int i = 0; i < position - 1; i++)
                    {
                        current = current.Next;
                    }
                    newNode.Next = current.Next;
                    newNode.Previous = current;
                    current.Next.Previous = newNode;
                    current.Next = newNode;
                }
            }


        }
        public void deleteAtPosition(int position)
        {
            if (head == null)
            {
                return;
            }
            if (position < 0 || position >= Count)
            {
                throw new Exception("Out of Range linked list.");
            }
            if (position == 0)
            {

                head = head.Next;
                head.Previous = null;
                Count--;
            }
            else if (position == Count - 1)
            {
                NodeDoubly curr = tail;
                curr.Previous.Next = null;
                curr.Previous = null;
                Count--;

            }
            else
            {
                NodeDoubly curr = head;
                for (int i = 1; i < position; i++)
                {
                    curr = curr.Next;
                }
                curr.Next.Next.Previous = curr;
                curr.Next = curr.Next.Next;

            }
            Count--;
        }
        public void Display()
        {
            NodeDoubly curr = head;
            Console.WriteLine("NextNode to DoublyLinkedList:");
            while (curr != null)
            {
                Console.Write(curr.Data + ">");
                curr = curr.Next;
            }

            Console.WriteLine("PreviousNode to DoublyLinkedList:");
            curr = tail;
            while (curr != null)
            {
                Console.Write(curr.Data + ">");
                curr = curr.Previous;
            }
        }
    }

}
