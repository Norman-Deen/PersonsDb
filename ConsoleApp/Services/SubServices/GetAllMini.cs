using ConsoleApp.Data;
using Microsoft.EntityFrameworkCore;


namespace PersonsDb.Services.SubServices
{
    internal class GetAllMini
    {
        public void getAllMini()
        {

            // Create an instance of the context
            using (var context = new AppSettings())
            {
                // Ensure the database is created
                context.Database.EnsureCreated();

                // Retrieve all persons
                var allPersons = context.Persons
                    .Include(p => p.Address)
                    .Include(p => p.Contact)
                    .Include(p => p.FamilyStatus)
                    .Include(p => p.Employment)
                    .ToList();

                // Display information
                foreach (var person in allPersons)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"Id: {person.PersonId}");
                    Console.WriteLine($"Name: {person.Name}");
                    Console.WriteLine();
                    Console.ResetColor();
                }
            }
        }
    }
}
