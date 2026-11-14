using System;
using System.Collections.Generic;

// Supplies random journal prompts.
public class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is one thing I learned today that I didn't know yesterday?",
        "What is something I am grateful for right now?",
        "What small win did I have today?",
        "What is one thing I can do tomorrow to make it better than today?"
    };

    private Random _random = new Random();

    public string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }
}
