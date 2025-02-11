using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
namespace Employees_System.Employee
{
    public class Employee_Project:Developer
    {
        #region Fields
        string nameEmployee;
        int ageEmployee;
        double salaryEmployee;
        double sumAmount = 0;
        double sumDetuction = 0;
        #endregion
        #region Properties
        public string NameEmployee
        {
            set
            {
                if (value.Length <= 200)
                    nameEmployee = value;
                else
                    Console.WriteLine("Name is maxuimam");
            }
            get
            {
                return nameEmployee;
            }
        }
        public string AddressEmployee { set; get; }
        public int AgeEmployee
        {
            set
            {
                if (value >= 23)
                    ageEmployee = value;
                else
                    Console.WriteLine("AgeEmployee is Minimam");
            }
            get
            {
                return ageEmployee;
            }
        }
        public int IdEmployee { get; set; }
        public double SalaryEmployee { get; set; }
        public double SalaryEmployee_After_Addition{ get; set; }
        public Department _Department { get; set; }
        public Employee_Project(Employee_Project EM)
        {
            
        }
        #endregion
        #region PropertiesOfList
        private List<Allowance> _Allowance { get; set; }
        private List<Detuctions> _Detuction { get; set; }
        private List<Vacation> _Vacation { get; set; }
        private List<Detuctions> _Detuctions { get; set; }
        #endregion
        #region Constructor
        public Employee_Project()
        {
            _Allowance = new List<Allowance>();
            _Detuction = new List<Detuctions>();
            _Vacation = new List<Vacation>();
            _Detuctions = new List<Detuctions>();
        }
        //parameterized constructor details of Employee (details of public )
        public Employee_Project(string name, string address, int age, int id, float salary)
        {
            NameEmployee = name;
            AddressEmployee = address;
            AgeEmployee = age;
            IdEmployee = id;
            SalaryEmployee = salary;
            _Department = new Department();
            _Allowance = new List<Allowance>();
            _Detuction = new List<Detuctions>();
            _Vacation = new List<Vacation>();
        }
        #endregion
        #region Methods
        public void Add_Data_Department(string departName, int departId)
        {
            _Department._DepartmentName = departName;
            _Department._DepartmentID = departId;
        }
        public void Print_Details_Employee()
        {
            Console.WriteLine(@$"
EmployeeName is {NameEmployee}
AddressEmployee is {AddressEmployee}
AgeEmployee is {AgeEmployee}
IdEmployee is {IdEmployee}
DepartmentName is {_Department._DepartmentName}:DepartmentId is {_Department._DepartmentID}
SalaryBeforeAnyAddition is {SalaryEmployee}");
        }
        public void Add_Allow(string Allowance, int amountAllowance)
        {
            Allowance allow = new Allowance();
            allow.All_Allowance(Allowance, amountAllowance);
            _Allowance.Add(allow);
        }
        public void Print_Allowance()
        {
            foreach (Allowance al in _Allowance)
            {
                Console.WriteLine($"AllowanceName is {al._AllowanceName}:AmountAllowance is {al._AmountAllowance}");
                sumAmount += al._AmountAllowance;
            }
            Console.WriteLine($"Sum Of Allowance = {sumAmount}");
        }
        public void Detuct(string detuctName, double detuctAmount)
        {
            Detuctions det = new Detuctions();
            det.DetuctionName = detuctName;
            det.DetuctionAmount = SalaryEmployee * detuctAmount;
            _Detuction.Add(det);
        }
        public void Print_Detuction()
        {
            foreach (Detuctions det in _Detuction)
            {
                Console.WriteLine($"DetuctionName is {det.DetuctionName}:DetuctionAmount is {det.DetuctionAmount}");
                sumDetuction += det.DetuctionAmount;
            }
            Console.WriteLine($"Sum of Detuctions={sumDetuction}");
            SalaryEmployee -= sumDetuction;
        }
        public void Salary_After()
        {
            SalaryEmployee_After_Addition = SalaryEmployee + sumAmount;
            Console.WriteLine($"SalaryEmployeeAfterAddition={SalaryEmployee_After_Addition}");
        }

        internal void Add_DepartmentData(string? departName, int departId)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
