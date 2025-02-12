using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    class Node
    {
        public int Data; // البيانات
        public Node Next; // الرابط للعقدة التالية

        public Node(int data)
        {
            Data = data;
            Next = null;
        }
    }

}
