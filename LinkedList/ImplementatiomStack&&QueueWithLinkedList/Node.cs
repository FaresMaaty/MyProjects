using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementatiomStack__QueueWithLinkedList
{
    class Node
    {
        public object Data; 
        public Node Next;

        public Node(object data)
        {
            Data = data;
            Next = null;
        }
    }

}
