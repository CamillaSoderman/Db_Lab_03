using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db_Lab_03.Data;

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
                int menuChoice = ShowMainMenu();
                int studentChoice = ShowStudentMenu();
                int staffChoice = ShowStaffMenu();
                int classChoice = ShowClassMenu();
                int gradeChoice = ShowGradeMenu();

                switch (menuChoice)
                {
                    case 1:
                        Console.WriteLine("Show students");
                        switch (studentChoice)
                        {
                            case 1: // Add student

                            case 2: // Show all students


                        }
                        break;
                    case 2:
                        Console.WriteLine("Show staff");
                        switch (staffChoice)
                        {
                            case 1: // Add staff

                            case 2: // Show all staff

                            case 3: // Show all teachers

                            case 4: // Show all adminitrators




                        }
                        break;
                    case 3:
                        Console.WriteLine("Show classes and grades");
                        switch (classChoice)
                        {
                            case 1: // Show classes
                                switch (classChoice)
                                {
                                    case 1: // Show all classes
                                    case 2: // Show math
                                    case 3: // Show english
                                    case 4: // Show history
                                }
                            case 2: // Show grades
                                switch (gradeChoice)
                                {
                                    case 1: // Show grades for all students, name, course, grade
                                    case 2: // Show grades high/low/ average all classes
                                    case 3: // Show grades for a specific class
                                }


                        }
                        break;
                    case 4:
                        isRunning = false;
                        break;
                    default:
                        break;
                }

            }

}

        private static int ShowMainMenu()
        {

            Console.WriteLine("[1] Show students");
            Console.WriteLine("[2] Show staff");
            Console.WriteLine("[3] Show classes");
            Console.WriteLine("[4] Exit");
            Console.SetCursorPosition(1, Console.CursorTop);

            return GetValidInput(1, 4);

        }

        private static int ShowStudentMenu()
        {
            Console.WriteLine("[1] Add student");
            Console.WriteLine("[2] Show all students");
            Console.SetCursorPosition(1, Console.CursorTop);
            return GetValidInput(1, 2);
        }

        private static int ShowStaffMenu()
        {
            Console.WriteLine("[1] Add staff");
            Console.WriteLine("[2] Show all staff");
            Console.WriteLine("[3] Show all teachers");
            Console.WriteLine("[4] Show all administrators");
            Console.SetCursorPosition(1, Console.CursorTop);
            return GetValidInput(1, 4);
        }

        private static int ShowClassMenu()
        {
            Console.WriteLine("[1] Show classes");
            Console.WriteLine("[2] Show grades");
            Console.SetCursorPosition(1, Console.CursorTop);
            return GetValidInput(1, 2);
        }

        private static int ShowGradeMenu()
        {
            Console.WriteLine("[1] Show grades for all students");
            Console.WriteLine("[2] Show grades high/low/ average all classes");
            Console.WriteLine("[3] Show grades for a specific class");
            Console.SetCursorPosition(1, Console.CursorTop);
            return GetValidInput(1, 3);
        }

        private static int GetValidInput(int v1, int v2)
        {
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


