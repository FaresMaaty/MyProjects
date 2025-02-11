using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Project.Classes_Projects.Customer
{
    internal class Customer
    {
        int age;
        string Name { get; set; }
        int Age
        {
            set
            {
                if (value >= 20)
                    age = value;
            }
            get
            {
                return age;
            }
        }
        int Id { get; set; }
        public Customer(string name, int age, int id)
        {
            Name = name;
            Age = age;
            Id = id;
        }
    }
}
