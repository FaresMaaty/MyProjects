using Hotel_Project.Classes_Projects.Customer;
using Hotel_Project.Classes_Projects.Hotel;
using System;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using System.Collections.Concurrent;
namespace Hotel_Project
{
    internal class Program
    {



        static void Main(string[] args)
        {
            string name;
            int age;
            int id;
            Console.WriteLine("Please Enter Name:");
            name = Console.ReadLine();
            Console.WriteLine("Please Enter Age:");
            age = int.Parse(Console.ReadLine());
            Console.WriteLine("Please Enter Id:");
            id = int.Parse(Console.ReadLine());

            Customer oCustomer = new Customer(name, age, id);
            Reservation oReserv;
            Console.WriteLine("Please Choice Type of Reservation for press (S => Standar or V => VIP) ");
            string sChoice = Console.ReadLine();
            switch (sChoice)
            {
                case "s":
                    oReserv = new Standard_Reservation();
                    oReserv.Room = new Standard_Room();
                    oReserv.Room.CheckIn();
                    oReserv.Create();
                    oReserv.Room.Price = 200;
                    oReserv.Room.CheckOut();
                    break;
                case "v":
                    oReserv = new VIP_Reservation();
                    oReserv.Room = new Standard_Room();
                    oReserv.Room.CheckIn();
                    oReserv.Room.Price = 500;
                    oReserv.Create();
                    oReserv.Room.CheckOut();
                    break;

            }
        }

       
    }
}
