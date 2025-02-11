using Employees_System.Employee;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using Employees_System.Employee;
namespace Employees_System
{
    internal class Program
    {
        static void Main(string[] args) 
        {
            #region Fields to Details of Employee 
            string name;
            string address;
            int age;
            int id;
            string departName;
            int departId;
            float salary; 
            #endregion
            #region Inputs Details of Employee
            Console.WriteLine("Details of Employee:");
            Console.WriteLine("*****************************");
            Console.WriteLine("Please Enter Name:");
            name = Console.ReadLine();
            Console.WriteLine("Please Enter Address:");
            address = Console.ReadLine();
            Console.WriteLine("Please Enter Age:");
            age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please Enter Id:");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please Enter DepartmentName:");
            departName = Console.ReadLine();
            Console.WriteLine("Please Enter DepartmentId:");
            departId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please Enter SalaryBeforeTax:");
            salary = Convert.ToSingle(Console.ReadLine());

            #endregion            Console.WriteLine("*****************************");
            #region Employee_Project is Constructor
            Employee_Project emp = new Employee_Project(name, address, age, id, salary);
            emp.Add_DepartmentData(departName, departId); 
            #endregion
            #region Print_Details_Employee
            Console.WriteLine("***** Print_all_Details *****");
            emp.Print_Details_Employee();
            Console.WriteLine("*****************************"); 
            #endregion
            #region Field To Allowance and Detuction 
            string exist = "";
            string _Allow;
            int _Amount;
            string detuctName;
            double detuctAmount; 
            #endregion
            #region Loop to Enter Allowance and Detuction
            while (exist != "exist")
            {
                Console.WriteLine("Please Enter Allowance:");
                _Allow = Console.ReadLine();
                Console.WriteLine("Please Enter Amount:");
                _Amount = Convert.ToInt32(Console.ReadLine());
                emp.Add_Allow(_Allow, _Amount);
                Console.WriteLine("---------------------------");
                Console.WriteLine("Please Enter DetuctionName:");
                detuctName = Console.ReadLine();
                Console.WriteLine("Please Enter DetuctionAmount:");
                detuctAmount = Convert.ToDouble(Console.ReadLine());
                emp.Detuct(detuctName, detuctAmount);
                Console.WriteLine("for out write exist");
                exist = Console.ReadLine().ToLower();
            }
            #endregion
            #region Print All_Allowance
            Console.WriteLine("********* All_Allowance *********");
            emp.Print_Allowance();
            #endregion
            #region Print All_Detuction 
            Console.WriteLine("********* All_Detuction *********");
            emp.Print_Detuction();
            #endregion
            #region Salary_After Tax 
            Console.WriteLine("********* Final_Salary  *********");
            emp.Salary_After();

            #endregion  
        }
    }
}
