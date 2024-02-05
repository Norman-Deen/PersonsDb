
using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsDb.Services.SubServices;

public class MenuService
{

    public void mainMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("PersonsDb Db V1.0\n");
        Console.ResetColor();
        Console.WriteLine("1 Display All Persons");
        Console.WriteLine("2 Get Person info by Id");
        Console.WriteLine("3 Add New Person");
        Console.WriteLine("4 Update Person Info");
        Console.WriteLine("5 Delete Person\n");

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("6 Exit");
        Console.ResetColor();
    }


}
