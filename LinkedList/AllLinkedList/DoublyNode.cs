using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    class NodeDoubly
    {
        public int Data; // البيانات
        public NodeDoubly Next; // الرابط للعقدة التالية
        public NodeDoubly Previous;
        public NodeDoubly(int data)
        {
            Data = data;
            Next = Previous = null;
        }
    }

}
