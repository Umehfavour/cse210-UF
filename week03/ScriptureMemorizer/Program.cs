using System;
using System.Collections.Generic;
using System.IO;

/*
 * EXCEEDING REQUIREMENTS / CREATIVITY:
 * 1. Scripture Library from File: Instead of hardcoding a single scripture, the program loads a library 
 * of scriptures from an external file named "scriptures.txt" and randomly selects one for the user 
 * to memorize each time the program runs. (Includes a built-in fallback library in case the file 
 * is missing).
 * 2. Stretch Challenge: The HideRandomWords method filters for only visible words before selecting 
 * which ones to hide, ensuring the program never wastes a turn trying to hide an already-hidden word.
 * 3. Smart Punctuation Handling: When hiding a word, punctuation marks (like commas, periods, and 
 * semicolons) remain visible while only letters are replaced by underscores, making memorization 
 * more natural.
 */

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptureLibrary = LoadScriptures("scriptures.txt");

        Random random = new Random();
        int randomIndex = random.Next(scriptureLibrary.Count);
        Scripture currentScripture = scriptureLibrary[randomIndex];

        string userInput = "";

        while (userInput.ToLower() != "quit" && !currentScripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(currentScripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            userInput = Console.ReadLine();

            if (userInput.ToLower() != "quit")
            {
                currentScripture.HideRandomWords(3);
            }
        }

        // Final display when all words are hidden (unless the user typed quit)
        if (currentScripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(currentScripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("All words are hidden! Great job memorizing.");
        }
    }

    static List<Scripture> LoadScriptures(string filename)
    {
        List<Scripture> scriptures = new List<Scripture>();

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                // Expected format in file: Book|Chapter|StartVerse|EndVerse|Text
                // If single verse, EndVerse is 0 (e.g., John|3|16|0|For God so loved the world...)
                string[] parts = line.Split('|');
                if (parts.Length >= 5)
                {
                    string book = parts[0];
                    int chapter = int.Parse(parts[1]);
                    int startVerse = int.Parse(parts[2]);
                    int endVerse = int.Parse(parts[3]);
                    string text = parts[4];

                    Reference reference = new Reference(book, chapter, startVerse, endVerse);
                    scriptures.Add(new Scripture(reference, text));
                }
            }
        }
        else
        {
            // Fallback library if the file is missing
            scriptures.Add(new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."));
            scriptures.Add(new Scripture(new Reference("Philippians", 4, 13), "I can do all this through him who gives me strength."));
        }

        return scriptures;
    }
}