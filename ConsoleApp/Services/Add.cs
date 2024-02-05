using ConsoleApp.Data;
using ConsoleApp.Models;
using PersonsDb.Repository;
using System;

namespace PersonsDb.Services
{
    internal class Add
    {
        internal static void AddPerson()
        {
            // Create an instance of the AddRepository
            AddRepository addRepository = new AddRepository();

            // Invoke the method to add a person
            addRepository.AddPerson();
        }
    }
}
