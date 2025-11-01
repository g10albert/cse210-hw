using System;

class Program
{
    static void Main(string[] args)
    {

        static void Main()
        {
            DisplayWelcome();

            string name = PromptUserName();
            int number = PromptUserNumber();
            int squaredNumber = SquareNumber(number);

            DisplayResult(name, squaredNumber);
        }

        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the program");
        }
        static string PromptUserName()
        {
            Console.Write("Please enter you name: ");
            string name = Console.ReadLine();
            return name;
        }

        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            string number = Console.ReadLine();
            int favNumber = int.Parse(number);
            return favNumber;
        }
        static int SquareNumber(int number)
        {
            int numberSquared = number * number;
            return numberSquared;
        }

        static void DisplayResult(string name, int numberSquared)
        {
            Console.WriteLine($"Brothen {name}, the square of your number is {numberSquared}");
        }
    ;
        ;
        Main();
    }
}