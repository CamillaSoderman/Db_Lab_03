
# Db_Lab_03
# Labb 3 – Anropa databasen (SQL & ORM)

## Om uppgiften

Denna labb bygger vidare på labb 2 och du ska alltså jobba vidare med samma databas som du skapade där.

**Du får, om du vill, ändra i databasens struktur och design när du gör denna uppgift!**

## Vad du ska göra

- [ ]  Fyll på din databas från labb 2 med lite mer exempeldata i alla tabeller.
- [ ]  Skapa ett nytt console-program i C#
- [ ]  Skapa en enkel navigation i programmet som gör att användaren kan välja mellan följande funktioner.
    - [ ]  Hämta personal (kan lösas med [ADO.NET](http://ADO.NET) och SQL, annars Entity framework)
        
        Användaren får välja om denna vill se alla anställda, eller bara inom en av kategorierna så som ex lärare.
        
    - [ ]  Hämta alla elever (ska lösas med Entity framework)
        
        Användaren får välja om de vill se eleverna sorterade på för- eller efternamn och om det ska vara stigande eller fallande sortering.
        
    - [ ]  Hämta alla elever i en viss klass (ska lösas med Entity framework)
        
        Användaren ska först få se en lista med alla klasser som finns, sedan får användaren välja en av klasserna och då skrivs alla elever i den klassen ut.
        
        🏆 Extra utmaning (Frivillig): låt användaren även få välja sortering på eleverna som i punkten ovan.
        
    - [ ]  Hämta alla betyg som satts den senaste månaden (kan lösas med [ADO.NET](http://ADO.NET) och SQL, annars Entity framework)
        
        Här får användaren direkt en lista med alla betyg som satts senaste månaden där elevens namn, kursens namn och betyget framgår.
        
    - [ ]  Hämta en lista med alla kurser och det snittbetyg som eleverna fått på den kursen samt det högsta och lägsta betyget som någon fått i kursen (kan lösas med [ADO.NET](http://ADO.NET) och SQL, annars Entity framework)
        
        Här får användaren direkt upp en lista med alla kurser i databasen, snittbetyget samt det högsta och lägsta betyget för varje kurs.
        
        💡 Tips: Det kan vara svårt att göra detta med betyg i form av bokstäver så du kan välja att lagra betygen som siffror istället.
        
    - [ ]  Lägga till nya elever (kan lösas med [ADO.NET](http://ADO.NET) och SQL, annars Entity framework)
        
        Användaren får möjlighet att mata in uppgifter om en ny elev och den datan sparas då ner i databasen.
        
    - [ ]  Lägga till ny personal (ska lösas genom Entity framework)
        
        Användaren får möjlighet att mata in uppgifter om en ny anställd och den data sparas då ner i databasen.
        

## Projekt Individual

I detta projekt ska du bygga klart en helt fungerande applikation för den fiktiva skola du jobbat med i de senaste labbarna. Du ska alltså skapa en Consol-applikation som skolan kan använda och som har den funktionalitet som efterfrågas nedan.

### Funktioner i programmet:

Här följer de funktioner du ska bygga i ditt program. 

<aside>
➡️ Det måste finnas en meny där man kan välja att visa olika data som efterfrågas av skolan. (Console)

</aside>

<aside>
➡️ Skolan vill kunna ta fram en översikt över all personal där det framgår namn och vilka befattningar de har samt hur många år de har arbetat på skolan. Administratören vill också ha möjlighet att spara ner ny personal. (SQL i SSMS)

</aside>

<aside>
➡️ Vi vill spara ner elever och se vilken klass de går i. Vi vill kunna spara ner betyg för en elev i varje kurs de läst och vi vill kunna se vilken lärare som satt betyget. Betyg ska också ha ett datum då de satts. (SQL i SSMS)

</aside>

<aside>
➡️ Hur många lärare jobbar på de olika avdelningarna? (EF i VS)

</aside>

<aside>
➡️ Visa information om alla elever (EF i VS)

</aside>

<aside>
➡️ Visa en lista på alla (aktiva) kurser (EF i VS)

</aside>

<aside>
➡️ Hur mycket betalar respektive avdelning ut i lön varje månad? (SQL i SSMS)

</aside>

<aside>
➡️ Hur mycket är medellönen för de olika avdelningarna? (SQL i SSMS)

</aside>

<aside>
➡️ Skapa en Stored Procedure som tar emot ett Id och returnerar viktig information om den elev som är registrerad med aktuellt id. (SQL i SSMS)

</aside>

<aside>
➡️ Sätt betyg på en elev genom att använda Transactions ifall något går fel. (SQL i SSMS)

</aside>


