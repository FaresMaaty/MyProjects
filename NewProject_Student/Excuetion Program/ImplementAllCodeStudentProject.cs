using NewProject_Student.Student_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewProject_Student.Student_Project;
namespace NewProject_Student.Excuetion_Program
{
    public class ImplementAllCodeStudentProject
    {
        #region Field UniversityStage
        int universityStage; 
        #endregion
        #region Default Constructor of Class Student
        Student student = new Student();
        #endregion
        #region Default Constructor of Class ImplementAllCodeStudentProject to Enter DetialCharacters

        public ImplementAllCodeStudentProject()
        {
            #region InputsDetialCharacters
            string studentName;
            int studentAge;
            int StudentId;
            Console.WriteLine("Please Enter NameStudent:");
            studentName = Console.ReadLine();
            Console.WriteLine("Please Enter AgeStudent:");
            studentAge = int.Parse(Console.ReadLine());
            Console.WriteLine("Please Enter IdStudent:");
            StudentId = int.Parse(Console.ReadLine());
            #endregion
            #region Method about DetialCharacters Within Class Student
            student.Detial_Characters(studentName, studentAge, StudentId);
            #endregion          
        }

        #endregion      
        #region Detials of UniversityStage With Loop on Addition Course and Major
        public void DetialsOfAll()
        {
            // Inputs Course
            string courseName;
            int courseId;
            int courseHours;
            // Inputs Major
            string departName;
            int departId;
            // While Loop
            string sExist = "";
            // Inputs UniversityStage (Condition in Switch Case)
            Console.WriteLine("-*-*-*-*--*-*-*-*--*-*-*-*--*-*-*-");
            Console.WriteLine("Please Enter UniversityStage:");
            Console.WriteLine("Press 1 for FirstStage.");
            Console.WriteLine("Press 2 for SecondStage.");
            Console.WriteLine("Press 3 for ThirdStage.");
            Console.WriteLine("Press 4 for FourthStage.");
            Console.WriteLine("-*-*-*-*--*-*-*-*--*-*-*-*--*-*-*-");
            universityStage = int.Parse(Console.ReadLine());
            student._Stage._UniversityStage = universityStage;
            // Condition(Condition if else Within Condition in Switch Case)
            int nCount = 0;
            while (sExist != "x")
            {
                switch (universityStage)
                {
                    case 1:
                        if (nCount == 0)
                        {
                            Console.WriteLine("-*-*-*-*--*-*-*-*--*-*-*-*--*-*-*-");
                            Console.WriteLine("-            MyCourses           -");
                            Console.WriteLine("-*-*-*-*--*-*-*-*--*-*-*-*--*-*-*-");
                        }
                        Console.WriteLine($"Course{nCount + 1}");
                        Console.WriteLine($"Please Enter CourseName:");
                        courseName = Console.ReadLine();
                        Console.WriteLine("Please Enter CourseId:");
                        courseId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Please Enter CourseHours:");
                        courseHours = int.Parse(Console.ReadLine());
                        student.AddCourses(courseName, courseId, courseHours);
                        break;
                    case 2:
                        if (nCount == 0)
                        {
                            Console.WriteLine("-*-*-*-*--*-*-*-*--*-*-*-*--*-*-*-");
                            Console.WriteLine("-            MyCourses           -");
                            Console.WriteLine("-*-*-*-*--*-*-*-*--*-*-*-*--*-*-*-");
                        }
                        Console.WriteLine($"Course{nCount + 1}");
                        Console.WriteLine("Please Enter CourseName:");
                        courseName = Console.ReadLine();
                        Console.WriteLine("Please Enter CourseId:");
                        courseId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Please Enter CourseHours:");
                        courseHours = int.Parse(Console.ReadLine());
                        student.AddCourses(courseName, courseId, courseHours);
                        break;
                    case 3:
                        if (nCount == 0)
                        {
                            Console.WriteLine("-*-*-*-*--*-*-*-*--*-*-*-*--*-*-*-");
                            Console.WriteLine("-            MyMajor             -");
                            Console.WriteLine("-*-*-*-*--*-*-*-*--*-*-*-*--*-*-*-");
                            Console.WriteLine("Please Enter DepartName:");
                            departName = Console.ReadLine();
                            Console.WriteLine("Please Enter DepartId:");
                            departId = int.Parse(Console.ReadLine());
                            student.AddMajor(departName, departId);
                            Console.WriteLine("-*-*-*-*--*-*-*-*--*-*-*-*--*-*-*-");
                            Console.WriteLine("*            MyCourses           *");
                            Console.WriteLine("-*-*-*-*--*-*-*-*--*-*-*-*--*-*-*-");
                        }
                        Console.WriteLine($"******** Course{nCount + 1} ********");
                        Console.WriteLine("Please Enter CourseName:");
                        courseName = Console.ReadLine();
                        Console.WriteLine("Please Enter CourseId:");
                        courseId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Please Enter CourseHours:");
                        courseHours = int.Parse(Console.ReadLine());
                        student.AddCourses(courseName, courseId, courseHours);
                        break;
                    case 4:
                        if (nCount == 0)
                        {
                            Console.WriteLine("-*-*-*-*--*-*-*-*--*-*-*-*--*-*-*-");
                            Console.WriteLine("-            MyMajor             -");
                            Console.WriteLine("-*-*-*-*--*-*-*-*--*-*-*-*--*-*-*-");
                            Console.WriteLine("Please Enter DepartName:");
                            departName = Console.ReadLine();
                            Console.WriteLine("Please Enter DepartId:");
                            departId = int.Parse(Console.ReadLine());
                            student.AddMajor(departName, departId);
                            Console.WriteLine("-*-*-*-*--*-*-*-*--*-*-*-*--*-*-*-");
                            Console.WriteLine("-            MyCourses           -");
                            Console.WriteLine("-*-*-*-*--*-*-*-*--*-*-*-*--*-*-*-");
                        }
                        Console.WriteLine($"******** Course{nCount + 1} ********");
                        Console.WriteLine("Please Enter CourseName:");
                        courseName = Console.ReadLine();
                        Console.WriteLine("Please Enter CourseId:");
                        courseId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Please Enter CourseHours:");
                        courseHours = int.Parse(Console.ReadLine());
                        student.AddCourses(courseName, courseId, courseHours);
                        break;
                }
                Console.WriteLine("for Exist press x:");
                sExist = Console.ReadLine().ToLower();
                nCount++;
            }
            Console.WriteLine("-----------------------------------------------------------");
        }
        #endregion
        #region Print All Detials for Project
        public void PrintAllDetials()
        {
        student.PrintAllDetials();
        }
            #endregion
    }
}
