using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db_Lab_03.Data;
using Db_Lab_03.Models;

namespace Db_Lab_03
{
    internal class Menu
    {
        private SchoolContext context = new SchoolContext();

        public static void Run()
        {
        bool isRunning = true;


            while (isRunning)
            {
                // Main Menu
                Console.WriteLine("Welcome to Chas Academy");
                Console.WriteLine("[1] Show and add students");
                Console.WriteLine("[2] Show and add staff");
                Console.WriteLine("[3] Show classes and grades");
                Console.WriteLine("[4] Exit");
                string? menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        
                        StudentMenu();
              
                        Console.WriteLine("");
                        break;

                    case "2":
                        StaffMenu();
                   
                        Console.WriteLine("");
                        
                        break;

                    case "3":

                        ShowClassMenu();
               
                        Console.WriteLine("");
                        break;

                    case "4":
                        Console.WriteLine("Goodbye!");
                        isRunning = false;
                        break;

                    default:
                        break;
                }

            }

        }

        private static void AddStudent()
        {

            // Add student to database
            using (var context = new SchoolContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                Console.WriteLine("Enter first name: ");
                string sfirstName = Console.ReadLine();
                Console.WriteLine("Enter last name: ");
                string slastName = Console.ReadLine();
                Console.WriteLine("Enter personalnumber: ");
                var sssn = Console.ReadLine();

                long ssn = long.Parse(sssn); // User input in string converted to long for the security number

                var student = new Models.Student
                {
                    SfirstName = sfirstName,
                    SlastName = slastName,
                    StudentNsn = ssn, // Social security number

                };

                // Using raw SQL to set IDENTITY_INSERT to ON and OFF
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Student] ON"); // SET IDENTITY_INSERT TO ON
               
                context.Students.Add(student);
                //context.SaveChanges();
                try
                {
                    context.SaveChanges();
                    Console.WriteLine($"{sfirstName} {slastName} is now added as a student ");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error saving to the database: {ex.Message}");
                }

                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Student] OFF"); // SET IDENTITY_INSERT TO OFF

                transaction.Commit();


            }
        }
        private static void AddStaff()
        {
            // Add staff to database
            using (var context = new SchoolContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                Console.WriteLine("Add employee\n");
                Console.WriteLine("Enter first name: ");
                var empFirstName = Console.ReadLine();
                Console.WriteLine("Enter last name: ");
                var empLastName = Console.ReadLine();
                Console.WriteLine("Enter employment start date (format: yyyy-MM-dd) : ");
                var empDate = Console.ReadLine();

                if (DateTime.TryParse(empDate, out DateTime dateTimeValue)) // Double check if the input is a valid date
                {
                    // Since the user only entered a date, the time part will be set to 00:00:00
                    DateTime onlyDate = dateTimeValue.Date;                   
                }
                else
                {
                    // If the input is not valid, notify the user
                    Console.WriteLine("Invalid date format. Please use the correct format.");
                }


                Console.WriteLine("Select the number of your role: ");
                Console.WriteLine("[1] Teacher");
                Console.WriteLine("[2] Administrator");
                Console.WriteLine("[3] Other");
                string? roleIdstring = Console.ReadLine();

                int roleId = int.Parse(roleIdstring); // User input in string converted to int
                var empName = empFirstName + " " + empLastName;

                var staff = new Models.Employee
                {
                    EmpFirstName = empFirstName,
                    EmpLastName = empLastName,
                    EmploymentDate = DateTime.Parse(empDate),
                    RoleId = roleId 

                };

         
                context.Employees.Add(staff);
                context.SaveChanges();

                transaction.Commit();


                Console.WriteLine($"{empName} is now added as a member of the staff ");

            }
        }
        private static void StudentMenu()
        {
          
            // Display all student

            using (var context = new SchoolContext())
            {
                Console.WriteLine("[1] Sort by first name ");
                Console.WriteLine("[2] Sort by last name");
                Console.WriteLine("[3] Add student");
                Console.WriteLine("[4] Exit");
                string? studentChoice = Console.ReadLine();

                Console.WriteLine("");

                switch (studentChoice)
                {
                    case "1": // Sort by first name
                        SortStudents(context, "first");
                        
                        break;
                    case "2": // Sort by last name
                        SortStudents(context, "last");
                        
                        break;
                    case "3": // Add student
                        AddStudent();
                        break;
                    case "4": // Exit
                        break;
                }

               
            }
        }
        // Method to sort students by first or last name and ascending or descending
        private static void SortStudents(SchoolContext context, string sortBy)
        {
            Console.WriteLine("[1] Ascending");
            Console.WriteLine("[2] Descending");
            string? sortChoice = Console.ReadLine();
            bool isDescending = sortChoice == "2";

            var students = sortBy switch
            {
                "first" => isDescending ? context.Students.OrderByDescending(s => s.SfirstName).ToList()
                                        : context.Students.OrderBy(s => s.SfirstName).ToList(),
                "last" => isDescending ? context.Students.OrderByDescending(s => s.SlastName).ToList()
                                       : context.Students.OrderBy(s => s.SlastName).ToList(),
                _ => new List<Models.Student>()
            };

            foreach (var student in students)
            {
                Console.WriteLine($"{student.SfirstName} {student.SlastName}");
            }
        }


        private static void StaffMenu()
        {

            using (var context = new SchoolContext())
            {
                Console.WriteLine("[1] Add staff");
                Console.WriteLine("[2] Show all staff");
                Console.WriteLine("[3] Show all teachers");
                Console.WriteLine("[4] Show all administrators");
                Console.WriteLine("[5] Show staff by role");
                Console.WriteLine("[6] Exit");
                string? staffChoice = Console.ReadLine();

                Console.WriteLine("");


                switch (staffChoice)
                {
                    case "1": // Add staff
                        AddStaff();
                        break;

                    case "2": // Show all staff
                        ShowAllStaff(context);
                        
                        break;

                    case "3": // Show all teachers
                        ShowStaffByRole(context, 1); // Teacher
                        
                        break;
                    case "4": // Show all administrators
                        ShowStaffByRole(context, 2); // Teacher
                        
                        break;
                    case "5":   // Show staff by role
                        ShowStaffByRole(context);

                        break;
                    case "6": // Exit
                        break;

                }


            }
        }
        // Method to show all staff ordered by first name
        private static void ShowAllStaff(SchoolContext context)
        {
            var employees = context.Employees.OrderBy(e => e.EmpFirstName).ToList();
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.EmpFirstName} {employee.EmpLastName}, Role: {GetRoleName(employee.RoleId)}");
            }
        }

        // Method to show staff by role with user inut as navigation
        private static void ShowStaffByRole(SchoolContext context, int roleId = 0)
        {
            var employees = roleId == 0
                ? context.Employees.ToList()
                : context.Employees.Where(e => e.RoleId == roleId).ToList();

            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.EmpFirstName} {employee.EmpLastName}, Role: {GetRoleName(employee.RoleId)}");
            }
        }
        private static void ShowClassMenu()
        {
            using (var context = new SchoolContext())
            {
                Console.WriteLine("[1] Show classes");
                Console.WriteLine("[2] Show grades");
                Console.WriteLine("[3] Exit");
                string? classChoice = Console.ReadLine();
                Console.WriteLine("");
                switch (classChoice)
                {
                    case "1": // Show classes
                        ShowClasses(context);
                        break;
                    case "2": // Show grades
                        ShowGrades(context);
                        break;
                    case "3": // Exit
                        break;
                }
            }
          
        }

        private static void ShowGrades(SchoolContext context)
        {
            int gradeMenuChoice;
            do
            {
                gradeMenuChoice = ShowGradeMenu();
                switch (gradeMenuChoice)
                {
                    case 1:
                        ShowAllGrades(context); // Show all grades
                        break;
                    case 2:
                        ShowHighLowAverage(context);    // Show high/low/average grades
                        break;
                    case 3:
                        ShowGradesByClass(context); // Show grades by class
                        break;
                }
            } while (gradeMenuChoice != 4);
        }

        // Show classes with classID and className
        private static void ShowClasses(SchoolContext context)
        {

            var courses = context.Courses.ToList();
            foreach (var course in courses)
            {
                Console.WriteLine($"{course.CourseId} {course.CourseName}");
            }
        }

        private static int ShowGradeMenu()
        {
            Console.WriteLine("[1] Show grades for all students");
            Console.WriteLine("[2] Show grades high/low/ average all classes");
            Console.WriteLine("[3] Show grades for a specific class");
            Console.WriteLine("[4] Exit");
            Console.SetCursorPosition(1, Console.CursorTop);
            return GetValidInput(1, 4);
        }

        private static int GetValidInput(int v1, int v2)
        {
            // Get valid input from user and returns the input if valid input is given
            int input;
            do
            {
                if (int.TryParse(Console.ReadLine(), out input) &&
                    input >= v1 && input <= v2)
                {
                    break;
                }
                Console.WriteLine($"Invalid input. Please try again, enter a number between {v1} and {v2}");
            } while (true);
            return input;
        }
        // Method to get role name depending on roleId
        private static string GetRoleName(int roleId)
        {
            switch (roleId)
            {
                case 1: return "Teacher";
                case 2: return "Administrator";
                default: return "Other";
            }
        }
        private static void ShowAllGrades(SchoolContext context)
        {
            Console.WriteLine("Grades:");
            // Get the current date
            DateTime currentDate = DateTime.Now;

            // Get the date 30 days ago
            DateTime thirtyDaysAgo = currentDate.AddDays(-30);

            // Query grades from the last 30 days
            var grades = context.Enrolments
                                .Where(e => e.GradeDate >= thirtyDaysAgo) // Only collect the grades that are 30 days old or newer
                                .ToList();

            Console.WriteLine("Grades from the last 30 days:");

            // Grades from the last 30 days
            foreach (var grade in grades)
            {
                Console.WriteLine($"Student ID: {grade.StudentId}, Course ID: {grade.CourseId}, Grade: {grade.Grade}, Date: {grade.GradeDate}");
            }
            Console.WriteLine("");

            // All grades
            Console.WriteLine("All grades:");
            var grades1 = context.Enrolments.ToList();
            foreach (var grade in grades1)
            {
                Console.WriteLine($"Student ID: {grade.StudentId}, Course ID: {grade.CourseId}, Grade: {grade.Grade}, Date: {grade.GradeDate}");
            }
        }
        private static void ShowHighLowAverage(SchoolContext context)
        {
            var grades = context.Enrolments.ToList();
            if (grades.Count == 0)          // If no grades are available
            {
                Console.WriteLine("No grades available.");
                return;
            }

            decimal? highestGrade = grades.Max(g => g.Grade);
            decimal? lowestGrade = grades.Min(g => g.Grade);
            decimal? averageGrade = grades.Average(g => g.Grade);

            Console.WriteLine($"Highest Grade: {highestGrade}");
            Console.WriteLine($"Lowest Grade: {lowestGrade}");
            Console.WriteLine($"Average Grade: {averageGrade}");
        }
        private static void ShowGradesByClass(SchoolContext context)
        {
            var courses = context.Courses.ToList();
            foreach (var course in courses)
            {
                Console.WriteLine($"{course.CourseId} {course.CourseName}");
            }
            Console.WriteLine("");

            Console.WriteLine("Enter the class ID: ");


            if (int.TryParse(Console.ReadLine(), out int classId))
            {
                var grades = context.Enrolments.Where(e => e.CourseId == classId).ToList();
                if (grades.Count == 0)
                {
                    Console.WriteLine("No grades available for this class.");
                    return;
                }

                foreach (var grade in grades)
                {
                    Console.WriteLine($"Student ID: {grade.StudentId}, Grade: {grade.Grade}");
                }
            }
            else
            {
                Console.WriteLine("Invalid class ID.");
            }
        }
    }
}


