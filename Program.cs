using System.Runtime.ConstrainedExecution;
using System;

// Chas academy
// Fullstack .net
// Camilla Söderman
// 2024-12-20

namespace Db_Lab_03
{

    // Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=School;Integrated Security=True;Trust Server Certificate=False;
    // Sortera Personal efter titel
    // Sortera klasser (subject) och få fram klasslista i vald klass
    // Hämta alla betyg senaste månaden där namn, kursens namn och betyget framgår
    //Hämta en lista med alla kurser och det snittbetyg som eleverna fått på den kursen samt det högsta och lägsta betyget som någon fått i kursen
    
    //Lägga till nya elever (kan lösas med [ADO.NET](http://ADO.NET) och SQL, annars Entity framework)
    // Användaren får möjlighet att mata in uppgifter om en ny elev och den datan sparas då ner i databasen.
    // Lägga till ny personal(ska lösas genom Entity framework)
    //Användaren får möjlighet att mata in uppgifter om en ny anställd och den data sparas då ner i databasen.




    internal class Program
    {
        static void Main(string[] args)
        {
            Menu.Run();
        }
    }
}
