using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Project.Classes_Projects.Hotel
{
    enum ComponentTypes
    {
        HomeFurnature,
        Devices,
        Furnature
    }
    internal struct Components
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public ComponentTypes Type { get; set; }
    }
}
