using System;

class Program
{
    static void Main(string[] args)
    {
        int guess = 0;
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 100);

        while (magicNumber != guess)
        {

            Console.Write("What is your guess? ");
            string userGuess = Console.ReadLine();
            guess = int.Parse(userGuess);

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }


    }
}