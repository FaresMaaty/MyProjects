using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
namespace ConsoleApp15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SingleLinkedList sLL=new SingleLinkedList();
            sLL.insertFirst(1);
            sLL.insertFirst(2);
            sLL.insertFirst(3);
            sLL.insertFirst(4);
            sLL.insertFirst(7);
            sLL.insertLast(8);


        }
    }

}

