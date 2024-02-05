using ConsoleApp.Data;
using ConsoleApp.Models;
using PersonsDb.IRepository;
using PersonsDb.Services;
using PersonsDb.Services.SubServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsDb.Repository
{
    public class UpdateRepository : IUpdateRepository
    {


        public  void UpdatePersonInformation()
        {
            // Create an instance of the context
            using (var context = new AppSettings())
            {
                Console.Clear();
                // Ensure the database is created
                context.Database.EnsureCreated();

                // Prompt user for person ID to update
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("---Update Info---\n");
                Console.ResetColor();
                GetAllMini getAllMiniService = new GetAllMini();
                getAllMiniService.getAllMini();
                Console.WriteLine();
                Console.Write("Enter the Person ID to update: ");
                if (int.TryParse(Console.ReadLine(), out int personId))
                {
                    // Find the person by ID
                    var personToUpdate = context.Persons.Find(personId);

                    if (personToUpdate != null)
                    {
                        // Display current information
                        Console.WriteLine("Current Information:");
                        DisplayPersonInformation(personToUpdate);

                        // Prompt user for updated information
                        Console.WriteLine("Enter the updated information:");

                        // Update all person information
                        Console.Write("Enter updated Name: ");
                        personToUpdate.Name = Console.ReadLine();

                        bool gender;
                        if (InputValidator.TryParseGender(out gender))
                        {
                            // Now 'gender' contains the valid input, and you can use it as needed.
                        }
                        else
                        {
                            // Handle the case where the user failed to provide a valid input after multiple attempts.
                            Console.WriteLine("Failed to get valid gender after multiple attempts.");
                        }

                        Console.Write("Enter updated Country: ");
                        personToUpdate.Address.Country = Console.ReadLine();

                        Console.Write("Enter updated City: ");
                        personToUpdate.Address.City = Console.ReadLine();

                        Console.Write("Enter updated Neighborhood: ");
                        personToUpdate.Address.Neighborhood = Console.ReadLine();

                        Console.Write("Enter updated Street: ");
                        personToUpdate.Address.Street = Console.ReadLine();

                        Console.Write("Enter updated House Number: ");
                        personToUpdate.Address.HouseNumber = Console.ReadLine();

                        Console.Write("Enter updated Phone: ");
                        personToUpdate.Contact.Phone1 = Console.ReadLine();

                        Console.Write("Enter updated Mobile Number: ");
                        personToUpdate.Contact.MobileNumber1 = Console.ReadLine();

                        Console.Write("Enter updated Email: ");
                        personToUpdate.Contact.Email1 = Console.ReadLine();


                        bool isMarried;

                        if (InputValidator.TryParseMaritalStatus(out isMarried))
                        {
                            // The value of 'isMarried' is already set by the TryParseMaritalStatus method.
                        }
                        else
                        {
                            Console.WriteLine("Failed to get valid Marital after multiple attempts.");
                        }

                        Console.Write("Enter updated Has Children (true/false): ");
                        if (bool.TryParse(Console.ReadLine(), out bool hasChildren))
                        {
                            personToUpdate.FamilyStatus.HasChildren = hasChildren;
                        }

                        Console.Write("Enter updated Job Title: ");
                        personToUpdate.Employment.JobTitle = Console.ReadLine();

                        Console.Write("Enter updated Department: ");
                        personToUpdate.Employment.Department = Console.ReadLine();

                        Console.Write("Enter updated Salary: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal salary))
                        {
                            personToUpdate.Employment.Salary = salary;
                        }

                        Console.Write("Enter updated Employment Date (YYYY-MM-DD): ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime employmentDate))
                        {
                            personToUpdate.Employment.EmploymentDate = employmentDate;
                        }

                        // Save changes to the database
                        context.SaveChanges();

                        Console.WriteLine($"Person with ID {personId} updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine($"Person with ID {personId} not found.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer for Person ID.");
                }

                Console.WriteLine("Press any key to return to the main menu.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // Helper method to display person information
        public  void DisplayPersonInformation(Person person)
        {
            Console.WriteLine($"Person Id: {person.PersonId}");
            Console.WriteLine($"Name: {person.Name}");
            Console.WriteLine($"Gender: {person.Gender}");
            Console.WriteLine($"Address: {person.Address?.Country} {person.Address?.City} {person.Address?.Neighborhood} {person.Address?.Street} {person.Address?.HouseNumber}");
            Console.WriteLine($"Contact: {person.Contact?.Phone1} {person.Contact?.MobileNumber1} {person.Contact?.Email1}");
            Console.WriteLine($"Family Status: {person.FamilyStatus?.MaritalStatus} {person.FamilyStatus?.HasChildren}");
            Console.WriteLine($"Employment: {person.Employment?.JobTitle} {person.Employment?.Department} {person.Employment?.Salary} {person.Employment?.EmploymentDate}");
        }


    }
}
