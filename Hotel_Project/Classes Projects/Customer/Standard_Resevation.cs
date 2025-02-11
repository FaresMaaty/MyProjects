using Hotel_Project.Classes_Projects.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Project.Classes_Projects.Customer
{
    internal class Standard_Reservation : Reservation
    {
        Standard_Room standard;
        public override IRoom Room
        {
            set => standard = value as Standard_Room;
            get => standard;
        }
        public override void Cancel()
        {
            Console.WriteLine("For Cancel Check Out 100 USD");
            Console.WriteLine("Done Cancel Standard_Reservation");
        }
    }
}
