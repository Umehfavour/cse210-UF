using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;
    public string _mood;
    public string _location;

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"Mood: {_mood} | Location: {_location}");
        Console.WriteLine($"> {_entryText}");
        Console.WriteLine();
    }
}