using Hotel_Project.Classes_Projects.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Project.Classes_Projects.Customer
{
    internal abstract class Reservation
    {
        public Reservation()
        {
            _Customer = new Customer("", 0, 0);
           
            FromData = DateTime.Now;
            ToData = DateTime.Now;
        }
        public virtual IRoom Room { get; set; }
        public Customer _Customer { get; set; }
        public decimal Price { get; set; }
        public DateTime FromData { get; set; }
        public DateTime ToData { get; set; }

        public virtual void Create()
        {

        }
        public void Edit()
        {

        }
        public void Delete()
        {

        }
        public abstract void Cancel();





    }
}
