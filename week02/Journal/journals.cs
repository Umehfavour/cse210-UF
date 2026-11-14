using System;
using System.Collections.Generic;
using System.IO;

// Holds the list of entries and handles saving/loading.
public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.\n");
            return;
        }

        Console.WriteLine();
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine("Date,Prompt,Response,Mood"); // header so Excel shows columns
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine(entry.ToCsvLine());
                }
            }
            Console.WriteLine($"Saved {_entries.Count} entries to {filename}.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Could not save the file: {ex.Message}\n");
        }
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"File '{filename}' was not found.\n");
            return;
        }

        try
        {
            List<Entry> loaded = new List<Entry>();
            string[] lines = File.ReadAllLines(filename);

            for (int i = 1; i < lines.Length; i++) // skip header row
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    continue;
                }
                Entry entry = Entry.FromCsvLine(lines[i]);
                if (entry != null)
                {
                    loaded.Add(entry);
                }
            }

            _entries = loaded; // replaces the current journal
            Console.WriteLine($"Loaded {_entries.Count} entries from {filename}.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Could not load the file: {ex.Message}\n");
        }
    }
}
