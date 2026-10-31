using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 100);
        int guess = 0;
        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            string answer = Console.ReadLine();
            guess = int.Parse(answer);
            if (guess < magicNumber)
            {
                Console.WriteLine("Your guess is too low.");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Your guess is too high.");
            }
        }
        Console.WriteLine("Congratulations! You guessed the magic number.");
    }
}