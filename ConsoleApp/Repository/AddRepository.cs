using ConsoleApp.Data;
using ConsoleApp.Models;
using PersonsDb.IRepository;
using PersonsDb.Services;
using System;

namespace PersonsDb.Repository
{
    internal class AddRepository : IAddRepository
    {
        public void AddPerson()
        {
            // Create an instance of the context
            using (var context = new AppSettings())
            {
                Console.Clear();
                // Ensure the database is created
                context.Database.EnsureCreated();

                // Prompt user for new person details
                Console.Write("Enter Name: ");
                var name = Console.ReadLine();

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

                // Prompt user for address details
                Console.WriteLine("Enter Address Details:");
                Console.Write("Country: ");
                var country = Console.ReadLine();
                Console.Write("City: ");
                var city = Console.ReadLine();
                Console.Write("Neighborhood: ");
                var neighborhood = Console.ReadLine();
                Console.Write("Street: ");
                var street = Console.ReadLine();
                Console.Write("House Number: ");
                var houseNumber = Console.ReadLine();

                // Create a new Person instance with Address
                var newPerson = new Person
                {
                    Name = name,
                    Gender = gender,
                    Address = new Address
                    {
                        Country = country,
                        City = city,
                        Neighborhood = neighborhood,
                        Street = street,
                        HouseNumber = houseNumber
                    }
                };

                // Prompt user for contact details
                Console.WriteLine();
                Console.WriteLine("Enter Contact Details:");
                Console.Write("Phone: ");
                var phone = Console.ReadLine();
                Console.Write("Mobile Number: ");
                var mobileNumber = Console.ReadLine();
                Console.Write("Email: ");
                var email = Console.ReadLine();

                // Add Contact details to the new person
                newPerson.Contact = new Contact
                {
                    Phone1 = phone,
                    MobileNumber1 = mobileNumber,
                    Email1 = email
                };

                // Prompt user for family status details
                Console.WriteLine();
                Console.WriteLine("Enter Family Status Details:");

                bool isMarried;

                if (InputValidator.TryParseMaritalStatus(out isMarried))
                {
                    // The value of 'isMarried' is already set by the TryParseMaritalStatus method.
                }
                else
                {
                    Console.WriteLine("Failed to get valid Marital after multiple attempts.");
                }

                bool hasChildren;

                if (InputValidator.TryParseHasChildren(out hasChildren))
                {
                    // Now 'hasChildren' contains the valid input, and you can use it as needed.
                }
                else
                {
                    // Handle the case where the user failed to provide a valid input after multiple attempts.
                    Console.WriteLine("Failed to get valid Has Children status after multiple attempts.");
                }


                // Add Family Status details to the new person
                newPerson.FamilyStatus = new FamilyStatus
                {
                    MaritalStatus = isMarried,
                    HasChildren = hasChildren
                };


                // Prompt user for employment details
                Console.WriteLine("Enter Employment Details:");
                Console.Write("Job Title: ");
                var jobTitle = Console.ReadLine();
                Console.Write("Department: ");
                var department = Console.ReadLine();
                Console.Write("Salary: ");
                var salaryInput = Console.ReadLine();
                decimal salary;
                decimal.TryParse(salaryInput, out salary);

                // Add Employment details to the new person
                newPerson.Employment = new Employment
                {
                    JobTitle = jobTitle,
                    Department = department,
                    Salary = salary,
                    EmploymentDate = DateTime.Now // Assuming employment date is the current date
                };

                // Add the new person to the context
                context.Persons.Add(newPerson);

                // Save changes to the database
                context.SaveChanges();

                Console.WriteLine($"Person with ID {newPerson.PersonId} added successfully.");

                Console.WriteLine("Press any key to return to the main menu.");
                Console.ReadKey();
                Console.Clear();
            }
        }

    }
}
