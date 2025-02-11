using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Project.Classes_Projects.Hotel
{
    internal interface IRoom
    {
        public string Facility { get; set; }
        public List<Components> LstComponents { get; set; }
        public Building Build { get; set; }
        public int Id { get; set; }
        public double Price { get; set; }
        void Clean();
        void IsAvailable();
        void CheckIn();
        void CheckOut();
    }
}
