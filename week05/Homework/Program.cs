using System;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        Assignment a1 = new Assignment();

        a1.setName("Albert");
        a1.SetTopic("Math");
        Console.WriteLine(a1.GetSummary());


        MathAssignment a2 = new MathAssignment("Albert", "Math", "7.1", "1-4");
        Console.WriteLine(a2.GetHomeworkList());

        WritingAssignment a3 = new WritingAssignment("Jose", "Tech", "Technology in the future");
        Console.WriteLine(a3.GetWritingInformation());
    }
}