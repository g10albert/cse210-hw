using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- Exercise Tracking Program Summary ---");
        Console.WriteLine("[Calculations use Kilometers/Kilometers Per Hour (kph)]\n");

        Running run = new Running("03 Dec 2025", 30, 4.8);
        Cycling cycle = new Cycling("04 Dec 2025", 45, 20.0);
        Swimming swim = new Swimming("05 Dec 2025", 30, 40);

        List<Activity> activities = new List<Activity>
        {
            run,
            cycle,
            swim
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }

        Console.WriteLine("\n--- End of Report ---");
    }
}