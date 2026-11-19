using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Your journal is currently empty.\n");
            return;
        }

        int totalWords = 0;

        foreach (Entry entry in _entries)
        {
            entry.Display();
            string[] words = entry._entryText.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            totalWords += words.Length;
        }

        Console.WriteLine($"--- Journal Summary: {_entries.Count} entries | {totalWords} total words written ---\n");
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}~|~{entry._promptText}~|~{entry._entryText}~|~{entry._mood}~|~{entry._location}");
            }
        }
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("File not found. Please check the filename and try again.\n");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(file);

        foreach (string line in lines)
        {
            string[] parts = line.Split("~|~");

            if (parts.Length >= 5)
            {
                Entry loadedEntry = new Entry();
                loadedEntry._date = parts[0];
                loadedEntry._promptText = parts[1];
                loadedEntry._entryText = parts[2];
                loadedEntry._mood = parts[3];
                loadedEntry._location = parts[4];

                _entries.Add(loadedEntry);
            }
        }

        Console.WriteLine("Journal loaded.\n");
    }
}