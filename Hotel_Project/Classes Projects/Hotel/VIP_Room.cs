using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Project.Classes_Projects.Hotel
{
    internal class VIP_Room : IRoom
    {
        public VIP_Room()
        {
            LstComponents = new List<Components>();
            Build = new Building();
        }
        public List<Components> LstComponents { get; set; }
        public Building Build { get; set; }
        public string Facility { get; set; }
        public int Id { get; set; }
        public double Price { get; set; }

        public void CheckIn()
        {

            Console.WriteLine("VIP_Room is Found.");

        }

        public void CheckOut()
        {
            Console.WriteLine($"Price of VIP_Room is {Price} USD");
        }

        public void Clean()
        {


        }

        public void IsAvailable()
        {


        }

    }
}
