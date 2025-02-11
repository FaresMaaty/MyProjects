using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees_System.Employee
{
    public class Allowance
    {
        public string _AllowanceName;
        public int _AmountAllowance;
        public void All_Allowance(string Allowance, int amountAllowance)
        {
           _AllowanceName = Allowance;
           _AmountAllowance = amountAllowance;
            
        }
    }
}
