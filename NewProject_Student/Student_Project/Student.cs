using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject_Student.Student_Project
{
    public class Student
    {
        #region Fields and Properties
        string nameStudent;
        int ageStudent;
        public UniversityStage _Stage { get; set; }
        public string NameStudent
        {
            set
            {
                if (value.Length <= 200)
                    nameStudent = value;
            }
            get
            {
                return nameStudent;
            }
        }
        public int AgeStudent
        {
            set
            {
                if (value >= 20)
                    ageStudent = value;
            }
            get
            {
                return ageStudent;
            }
        }
        public int IdStudent { get; set; }
        public List<Courses> _Courses { get; set; }
        public List<Major> _Major { get; set; }
        #endregion
        #region Special Fields of Color 
        Colors colors;
        string colorName;
        ConsoleColor selectColor;
        #endregion
        #region Default Constructor to initialize Class(Courses,Major,UniversityStage)
        public Student()
        {
            _Courses = new List<Courses>();
            _Major = new List<Major>();
            _Stage = new UniversityStage();
        }
        #endregion
        #region Initialize Detial_Characters
        public void Detial_Characters(string nameStudent, int ageStudent, int idStudent)
        {
            NameStudent = nameStudent;
            AgeStudent = ageStudent;
            IdStudent = idStudent;
        }
        #endregion
        #region AddCourses
        public void AddCourses(string name, int id, int hour)
        {
            Courses courses = new Courses();
            courses.name = name;
            courses.id = id;
            courses.hoursNumbers = hour;
            _Courses.Add(courses);
        }
        #endregion
        #region AddMajor
        public void AddMajor(string nameDepart, int idDepart)
        {
            Major major = new Major();
            major.departmentName = nameDepart;
            major.departId = idDepart;
            _Major.Add(major);
        }
        #endregion
        #region PrintAllDetials
        public void PrintAllDetials()
        {
            Console.WriteLine("-*-*-*-*--*-*-*-*--*-*-*-*--*-*-*-*-*-*-*-*");
            Console.WriteLine("-                DetialCharacters         -");
            Console.WriteLine("-*-*-*-*--*-*-*-*--*-*-*-*--*-*-*-*-*-*-*-*");
            Console.WriteLine($"Name:{NameStudent},Age:{AgeStudent},Id:{IdStudent}");
            if (_Stage._UniversityStage == 3)
            {
                Console.WriteLine("-*-*-*-*--*-*-*-*--*-*-*-*--*-*-*-*-*-*-*-*");
                Console.WriteLine("-            MyThirdMajor                 -");
                Console.WriteLine("-*-*-*-*--*-*-*-*--*-*-*-*--*-*-*-*-*-*-*-*");
                Console.WriteLine($"DepartName:{_Major[0].departmentName},DepartId:{_Major[0].departId}");
            }
            else if (_Stage._UniversityStage == 4)
            {
                Console.WriteLine("-*-*-*-*--*-*-*-*--*-*-*-*--*-*-*-*-*-*-*-*");
                Console.WriteLine("-            MyFourthMajor                -");
                Console.WriteLine("-*-*-*-*--*-*-*-*--*-*-*-*--*-*-*-*-*-*-*-*");
                Console.WriteLine($"DepartName:{_Major[0].departmentName},DepartId:{_Major[0].departId}");
            }
            Console.WriteLine("-*-*-*-*--*-*-*-*--*-*-*-*--*-*-*-*-*-*-*-*");
            Console.WriteLine("-            MyCourses                    -");
            Console.WriteLine("-*-*-*-*--*-*-*-*--*-*-*-*--*-*-*-*-*-*-*-*");

            for (int i = 0; i < _Courses.Count; i++)
            {
                int number = i + 1;
                colors = (Colors)number;
                colorName = colors.ToString();
                if (i + 1 == i + 1)
                {
                    ConsoleColor selectColor = (ConsoleColor)Enum.Parse(typeof(Colors), colorName, true);
                    Console.BackgroundColor = selectColor;
                    Console.WriteLine($"Course{i + 1}:");
                }

                Console.WriteLine($"Name:{_Courses[i].name}");
                Console.WriteLine($"Id:{_Courses[i].id}");
                Console.WriteLine($"Hours:{_Courses[i].hoursNumbers}");
            }
            Console.WriteLine("--------------------------------------------------");
        } 
        #endregion
    }
}
