using System;
using System.Collections.Generic;
using System.Text;

// Represents one journal entry. Fields are private; other classes use methods.
public class Entry
{
    private string _date;
    private string _prompt;
    private string _response;
    private string _mood;

    public Entry(string date, string prompt, string response, string mood)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
        _mood = mood;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Mood: {_mood}/10");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"> {_response}");
        Console.WriteLine();
    }

    // Converts the entry to one CSV line (Excel-safe: commas and quotes handled).
    public string ToCsvLine()
    {
        return string.Join(",",
            Escape(_date), Escape(_prompt), Escape(_response), Escape(_mood));
    }

    // Builds an Entry from one CSV line. Returns null if the line is malformed.
    public static Entry FromCsvLine(string line)
    {
        List<string> fields = ParseCsvLine(line);
        if (fields.Count < 4)
        {
            return null;
        }
        return new Entry(fields[0], fields[1], fields[2], fields[3]);
    }

    private static string Escape(string value)
    {
        if (value.Contains(",") || value.Contains("\"") || value.Contains("\n"))
        {
            return "\"" + value.Replace("\"", "\"\"") + "\"";
        }
        return value;
    }

    private static List<string> ParseCsvLine(string line)
    {
        List<string> fields = new List<string>();
        StringBuilder current = new StringBuilder();
        bool inQuotes = false;

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];
            if (inQuotes)
            {
                if (c == '"' && i + 1 < line.Length && line[i + 1] == '"')
                {
                    current.Append('"'); // escaped quote
                    i++;
                }
                else if (c == '"')
                {
                    inQuotes = false;
                }
                else
                {
                    current.Append(c);
                }
            }
            else
            {
                if (c == '"')
                {
                    inQuotes = true;
                }
                else if (c == ',')
                {
                    fields.Add(current.ToString());
                    current.Clear();
                }
                else
                {
                    current.Append(c);
                }
            }
        }
        fields.Add(current.ToString());
        return fields;
    }
}