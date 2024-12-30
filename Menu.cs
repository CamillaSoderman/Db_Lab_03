using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db_Lab_03.Data;


// Bygg menuchoice ex student choice i metoden istället för i menyn.
//  string? sortChoice = Console.ReadLine();

// SET INDENTITY_INSERT TO ON 
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
                //int menuChoice = ShowMainMenu();
                //int studentChoice = StudentMenu();
                //int staffChoice = ShowStaffMenu();
                //int classChoice = ShowClassMenu();
                //int gradeChoice = ShowGradeMenu();

                //ShowMainMenu(); // Show main menu
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
                        // add student and show stundents by fname or lname

                        //switch (studentChoice)
                        //{
                        //    case 1: // Add student
                        //        Console.WriteLine("");
                        //        AddStudent();
                        //        Console.WriteLine("");
                        //        break;
                        //    case 2: // Show all students
                        //        Console.WriteLine("");
                        //        DisplayStudents();
                        //        Console.WriteLine("");
                        //        break;
                        //}
                        Console.WriteLine("");
                        break;


                    case "2":
                        ShowStaffMenu();
                        // Show all staff after choice/title
                        // add staff using entity framework

                        //switch (staffChoice)
                        //{
                        //    case 1: // Add staff
                        //        break;
                        //    case 2: // Show all staff
                        //        break;
                        //    case 3: // Show all teachers
                        //        break;
                        //    case 4: // Show all adminitrators
                        //        break;
                        //    case 5: // Exit
                        //        break;

                        //}
                        Console.WriteLine("");
                        
                        break;
                    case "3":

                        ShowClassMenu();
                        // Show all classes, select class and show grades

                        //switch (classChoice)
                        //{
                        //    case 1: // Show classes
                        //        break;
                        //    case 2: // Show grades
                        //        break;
                        //    case 3: // Exit
                        //        break;


                        //}
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
            {
                Console.WriteLine("Enter first name: ");
                var sfirstName = Console.ReadLine();
                Console.WriteLine("Enter last name: ");
                var slastName = Console.ReadLine();
                Console.WriteLine("Enter city: ");
                var adress = Console.ReadLine();
               
                var student = new Models.Student
                {
                    SfirstName = sfirstName,
                    SlastName = slastName,
                    Sadress = adress,
                   
                };
                context.Students.Add(student);
                context.SaveChanges();
                Console.WriteLine($"{sfirstName} {slastName} is now added as a student ");

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
                        var students = context.Students.OrderBy(s => s.SfirstName).ToList();
                        foreach (var student in students)
                        {
                            Console.WriteLine($"{student.SfirstName} {student.SlastName}");
                        }
                        break;
                    case "2": // Sort by last name
                        var students2 = context.Students.OrderBy(s => s.SlastName).ToList();
                        foreach (var student in students2)
                        {
                            Console.WriteLine($"{student.SfirstName} {student.SlastName}");
                        }
                        break;
                    case "3": // Add student
                        AddStudent();
                        break;
                    case "4": // Exit
                        break;
                }

                //Console.SetCursorPosition(1, Console.CursorTop);

                //int input = GetValidInput(1, 3);

                //switch (input)
                //{
                //    case 1: // Sort by first name
                //        var students = context.Students.OrderBy(s => s.SfirstName).ToList();
                //        foreach (var student in students)
                //        {
                //            Console.WriteLine($"{student.SfirstName} {student.SlastName}");
                //        }
                //        break;

                //    case 2: // Sort by last name
                //        var students2 = context.Students.OrderBy(s => s.SlastName).ToList();
                //        foreach (var student in students2)
                //        {
                //            Console.WriteLine($"{student.SfirstName} {student.SlastName}");
                //        }
                //        break;

                //    case 3: // Exit
                //        break;
                //}
            }
        }

        //private static int ShowMainMenu()
        //{

        //    Console.WriteLine("[1] Show students");
        //    Console.WriteLine("[2] Show staff");
        //    Console.WriteLine("[3] Show classes");
        //    Console.WriteLine("[4] Exit");
        //    Console.SetCursorPosition(1, Console.CursorTop);

        //    return GetValidInput(1, 4);

        //}

        //private static int ShowStudentMenu()
        //{
        //    Console.WriteLine("[1] Add student");
        //    Console.WriteLine("[2] Show all students");
        //    Console.WriteLine("[3] Exit");
        //    Console.SetCursorPosition(1, Console.CursorTop);
        //    return GetValidInput(1, 3);
        //}

        private static int ShowStaffMenu()
        {
            Console.WriteLine("[1] Add staff");
            Console.WriteLine("[2] Show all staff");
            Console.WriteLine("[3] Show all teachers");
            Console.WriteLine("[4] Show all administrators");
            Console.WriteLine("[5] Exit");
            Console.SetCursorPosition(1, Console.CursorTop);
            return GetValidInput(1, 5);
        }

        private static int ShowClassMenu()
        {
            Console.WriteLine("[1] Show classes");
            Console.WriteLine("[2] Show grades");
            Console.WriteLine("[3] Exit");
            Console.SetCursorPosition(1, Console.CursorTop);
            return GetValidInput(1, 3);
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
    }
}


