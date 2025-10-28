using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade: ");
        string gradePercentageFromUser = Console.ReadLine();
        int gradePercentage = int.Parse(gradePercentageFromUser);

        if (gradePercentage >= 90)
        {
            Console.WriteLine('A');
        }
        else if (gradePercentage >= 80)
        {
            Console.WriteLine('B');
        }
        else if (gradePercentage >= 70)
        {
            Console.WriteLine('C');
        }
        else if (gradePercentage >= 60)
        {
            Console.WriteLine('D');
        }
        else if (gradePercentage < 60)
        {
            Console.WriteLine('F');
        }

        if (gradePercentage >= 70)
        {
            Console.Write("Congratulations! You passed");
        }
        else
        {
            Console.Write("Uh... you failed, but next time it going to be better!");
        }
    }
}