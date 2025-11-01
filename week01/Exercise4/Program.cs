using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string numbersInput = "";
        double total = 0.0;
        double average = 0.0;
        List<int> numbersList = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 only when finished");

        while (numbersInput != "0")
        {
            Console.Write("Enter number: ");
            numbersInput = Console.ReadLine();
            int number = int.Parse(numbersInput);

            if (number != 0)
            {
                numbersList.Add(number);

                total += number;
            }

        }

        double listCount = numbersList.Count;
        average = total / listCount;

        double largest = numbersList[0];

        foreach (double number in numbersList)
        {
            if (number > largest)
            {
                largest = number;
            }
        }

        Console.WriteLine(listCount);
        Console.WriteLine($"The sum is: {total}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");



    }
}