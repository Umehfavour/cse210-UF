/*
 * EXCEEDING CORE REQUIREMENTS (Creativity - 7 pts):
 * 1. Saved Additional Context in Entries: Beyond the prompt, response, and date, each Entry 
 *    captures and stores the user's current Mood and Location to provide richer context when 
 *    reviewing past entries.
 * 2. Journal Analytics Summary: When displaying all entries, the program calculates and displays 
 *    the total number of entries and total word count written across the journal to motivate 
 *    consistent writing habits.
 * 3. Input & File Validation: Added checks to prevent crashes if a user tries to load a file 
 *    that does not exist or enters an invalid menu selection.
 */

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        string userChoice = "";

        Console.WriteLine("Welcome to the Journal Program!");

        while (userChoice != "5")
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            userChoice = Console.ReadLine();
            Console.WriteLine();

            if (userChoice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();

                Console.Write("How are you feeling right now (Mood)? ");
                string mood = Console.ReadLine();

                Console.Write("Where are you writing from (Location)? ");
                string location = Console.ReadLine();

                DateTime theCurrentTime = DateTime.Now;
                string dateText = theCurrentTime.ToShortDateString();

                Entry newEntry = new Entry();
                newEntry._date = dateText;
                newEntry._promptText = prompt;
                newEntry._entryText = response;
                newEntry._mood = mood;
                newEntry._location = location;

                theJournal.AddEntry(newEntry);
                Console.WriteLine("Entry added!\n");
            }
            else if (userChoice == "2")
            {
                theJournal.DisplayAll();
            }
            else if (userChoice == "3")
            {
                Console.Write("What is the filename? ");
                string fileName = Console.ReadLine();
                theJournal.LoadFromFile(fileName);
            }
            else if (userChoice == "4")
            {
                Console.Write("What is the filename? ");
                string fileName = Console.ReadLine();
                theJournal.SaveToFile(fileName);
                Console.WriteLine("Journal saved.\n");
            }
            else if (userChoice == "5")
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid option. Please enter a number from 1 to 5.\n");
            }
        }
    }
}