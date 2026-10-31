using System;

class Program
{
    static void Main(string[] args)
    {
      Console.Write("What is your grade percentage?");
      string answer = Console.ReadLine();
      int percent = int.Parse(answer);
      string letter = " ";
      if (percent >=97)
        {
            letter = "A+";        
        }
        else if (percent >=93)
        {
            letter = "A";
        }
        else if (percent >=90)
        {
            letter = "A-";
        }
        else if (percent >=87)
        {
            letter = "B+";
        }
        else if (percent >=83)
        {
            letter = "B";
        }
        else if (percent >=80)
        {
            letter = "B-";
        }
        else if (percent >=77)
        {
            letter = "C+";
        }
        else if (percent >=73)
        {
            letter = "C";
        }
        else if (percent >=70)
        {
            letter = "C-";
        }
        else if (percent >=60)
        {
            letter = "D-";
        }    
        else if (percent >=63)
        {
            letter = "D";
        }
        else if (percent >=77)
        {
            letter = "D+";
        }
        else
        {
            letter = "F";
        }
        Console.WriteLine($"Your grade is {letter}");
        if (percent >=70)
        {
            Console.WriteLine($"You are doing great");
        }
        if (percent >=50)
        {
            Console.WriteLine($"You can do better");
        }
        if (percent >=0)
        {
         Console.WriteLine($"Better luck next time");
        }
    }
}