using Hotel_Project.Classes_Projects.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Project.Classes_Projects.Customer
{
    internal class VIP_Reservation : Reservation
    {
        VIP_Room vIP;
        public override IRoom Room
        {
            set => vIP = value as VIP_Room;
            get => vIP;
        }



        public override void Cancel()
        {
            Console.WriteLine("For Cancel not Check Out.");
            Console.WriteLine("Done Cancel for VIP_Reservation.");
        }
    }
}
