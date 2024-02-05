using System;
using System.Linq;
using ConsoleApp.Data; // Adjust namespace as needed
using Microsoft.EntityFrameworkCore;
using PersonsDb.IRepository;

namespace PersonsDb.Services
{
    internal class DisplayAllService : IDisplayAllRepository  // Choose a more descriptive name for the class
    {
        private readonly IDisplayAllRepository _displayAllRepository;

        public DisplayAllService(IDisplayAllRepository displayAllRepository)
        {
            _displayAllRepository = displayAllRepository;
        }

        public void DisplayAll()  // Change the return type to void
        {
            _displayAllRepository.DisplayAll();
        }
    }
}
