using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TimeStamper.Data;

namespace TimeStamper
{
    public class Menu
    {
        // Menu function using spectre.console and a switch function
        public static void MainMenu()
        {
            
            bool isRunning = true;
            while (isRunning == true)
            {
                Console.Clear();
                var menu = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Select an [green]option[/]?")
                        .PageSize(4)
                        .MoreChoicesText("[grey](Use arrow keys to move up and down)[/]")
                        .AddChoices(new[] {
                            "Add a person", "Add a project", "Log time", "Exit program",

                        }));
                switch (menu)
                {
                    // Runs function to add a person
                    case "Add a person":
                        Console.Clear();
                        DbFunctions.AddPerson();
                        break;
                    // Runs function to add a project
                    case "Add a project":
                        Console.Clear();
                        DbFunctions.AddProject();
                        break;
                    case "Log time":
                        Console.Clear();
                        // Lists all people in db
                        DbFunctions.ListPeople();
                        
                        using (var db = new TimeStampAppDbContext()) // Opens a connection to the db
                        {
                            Console.WriteLine("Who wants to log time? ");
                            string activePerson = Console.ReadLine();
                            // Checks if the user input matches a name in the db
                            var person = db.AljPeople.Where(p => p.PersonName == activePerson).ToList();
                            // If a match run LogHours function with that name
                            if (person != null)
                            {
                                DbFunctions.LogHours(activePerson);
                            }
                            // If no match give error message and run menu function again
                            else
                            {
                                Console.WriteLine($"Error: Invalid name, no person by the name of {person} exists on the database");
                                MainMenu();
                            }
                        }
                        break;
                    case "Exit program":
                        // Exits the application
                        isRunning = false;
                        break;
                }
            }
        }
    }
}
