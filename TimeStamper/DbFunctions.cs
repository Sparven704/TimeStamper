using Microsoft.EntityFrameworkCore;
using Spectre.Console;
using System;
using System.Diagnostics.Metrics;
using TimeStamper.Data;

namespace TimeStamper
{
    public class DbFunctions
    {
        // Function to create a list of all projects in db and print them to console
        public static void ListProjects()
        {
            using (var db = new TimeStampAppDbContext())
            {
                // Creating a Spectre.Console table 
                var table = new Spectre.Console.Table();

                // Adding colums to the table
                table.AddColumn(" ");
                table.AddColumn(new TableColumn("Projects"));
                var projects = db.AljProjects.ToList();
                int counter = 1;
                foreach (var project in projects)
                {
                    // Adds new row to table for each itteration of loop
                    table.AddRow($"{counter}", $"[yellow]{project.ProjectName}[/]");
                    counter++;
                }
                // Prints table to the console
                AnsiConsole.Write(table);
            }
        }
        // Function to create a list of all people in db and print them to console
        public static void ListPeople()
        {
            using (var db = new TimeStampAppDbContext())
            {
                // Creating a Spectre.Console table 
                var table = new Spectre.Console.Table();

                // Adding colums to the table
                table.AddColumn(" ");
                table.AddColumn(new TableColumn("People"));
                var people = db.AljPeople.ToList();
                int counter = 1;
                foreach (var person in people)
                {
                    // Adds new row to table for each itteration of loop
                    table.AddRow($"{counter}", $"[yellow]{person.PersonName}[/]");
                    counter++;
                }
                // Prints table to the console
                AnsiConsole.Write(table);
            }
        }
        // Function to update the name of a person
        public static void UpdatePerson()
        {
            using (var db = new TimeStampAppDbContext())
            {
                Console.WriteLine("Who's name do you want to edit? ");
                ListPeople();
                string userInput = Console.ReadLine();
                // Checks db if userInput matches a name in the db
                var person = db.AljPeople.Find(userInput);
                // If it finds a match runs code to edit that name
                if (person != null)
                {
                    Console.WriteLine("Enter new name: ");
                    string userInput2 = Console.ReadLine();
                    person.PersonName = userInput2;
                }
                // If it does not find a match it gives an error message and restards the function
                else
                {
                    Console.WriteLine("Error: Invalid name.");
                    UpdatePerson();
                }
                db.SaveChanges();
            }
            Console.WriteLine("Name updated...");
        }
        // Function to add a new person to the db
        public static void AddPerson()
        {
            Console.WriteLine("What is the persons name? ");
            string name = Console.ReadLine();
            using (var db = new TimeStampAppDbContext())
            {
                // Creates a new AljPerson object
                AljPerson person = new AljPerson();
                person.PersonName = name;
                db.AljPeople.Add(person);
                db.SaveChanges();
            }
            Console.WriteLine("Person added...");
        }
        // Function to add a new project to the db
        public static void AddProject()
        {
            Console.WriteLine("What is the project name? ");
            string name = Console.ReadLine();
            using (var db = new TimeStampAppDbContext())
            {
                // Creates a new AljProject object
                AljProject project = new AljProject();
                project.ProjectName = name;
                db.AljProjects.Add(project);
                db.SaveChanges();
            }
            Console.WriteLine("Project added...");
        }
        // Function for a person to log hours spent on a project 
        public static void LogHours(string activePerson)
        {

            using (var db = new TimeStampAppDbContext())
            {
                var person = db.AljPeople.Where(p => p.PersonName == activePerson).ToList();
                if (person == null)
                {
                    // If person doesn't exist give error
                    throw new Exception("Error"); 
                }
                // If person is not null that means it found a match in the db and the function continues
                else if (person != null)
                {
                    int personId = person[0].Id;
                    Console.WriteLine("What project did you work on?");
                    ListProjects();
                    string projectInput = Console.ReadLine();
                    var project = db.AljProjects.Where(p => p.ProjectName == projectInput).ToList();
                    if (project != null)
                    {
                        int projectId = project[0].Id;
                        Console.WriteLine("How many hours did you work on it?");
                        int hoursInput = int.Parse(Console.ReadLine());

                        AljProjectPerson projectLog = new AljProjectPerson()
                        {
                            Hours = hoursInput,
                            PersonId = personId,
                            ProjectId = projectId
                        };
                        projectLog.Hours = hoursInput;

                        db.AljProjectPeople.Add(projectLog);
                    }
                }
                

                db.SaveChanges();
            }
            Console.WriteLine("Project added...");
        }
    }

}

