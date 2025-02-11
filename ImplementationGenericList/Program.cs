using DataStructure.List;

namespace DataStructure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> m = new();
            m.Push(1);
            m.Push(2);

            string[] strArr = { "4", "5", "6" };
            List<string> list = new List<string>();
            list.Add("1");
            list.Add("2");
            list.Add("3");
            list.AddRange(list);
            GenericList<string> lst = new GenericList<string>(list); // Add List 
            Console.WriteLine(lst.Capacity); // Default Capacity=4
            // Add Items
            lst.Add("A");
            lst.Add("B");
            lst.Add("C");
            lst.Add("D");
            lst.AddRange(lst);
            //Current Capacity 
            Console.WriteLine("*********************000*************************");
            Console.WriteLine(lst.Capacity);
            Console.WriteLine("*********************000*************************");
            // Count of Items
            Console.WriteLine("*********************000*************************");
            Console.WriteLine(lst.Count);
            Console.WriteLine("*********************000*************************");
            // Insert
            lst.Insert(5, "fady");
            lst.InsertRange(8, strArr);
            // Reverse List
            lst.Reverse();
            // Remove
            lst.Remove("A");
            lst.RemoveAt(0);
            lst.RemoveRange(0, 4);
            lst.UndoOfItem();
            lst.RemoveAll();
            // lst.Clear();

            // Capacity
            Console.WriteLine("*********************000*************************");
            Console.WriteLine(lst.Capacity);
            Console.WriteLine("*********************000*************************");
            // Count of Items
            Console.WriteLine("*********************000*************************");
            Console.WriteLine(lst.Count);
            Console.WriteLine("*********************000*************************");



            Console.WriteLine();





        }
    }
}
