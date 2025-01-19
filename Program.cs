using System.Runtime.ConstrainedExecution;
using System;
using Db_Lab_03.Data;
using static Db_Lab_03.Data.SchoolContext;

// Chas academy
// Fullstack .net
// Camilla Söderman
// 2025-01-05



namespace Db_Lab_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Used this method to check that all migrations are applied
            //using (var context = new SchoolContext())
            //{
            //    MigrationChecker.CheckPendingMigrations(context);
            //}

            Menu.Run();
        }
    }
}
