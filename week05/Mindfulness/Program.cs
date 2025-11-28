using System;

class Program
{
    static void Main(string[] args)
    {
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness Activities Program");
                Console.WriteLine("1. Start Breathing Activity");
                Console.WriteLine("2. Start Listing Activity");
                Console.WriteLine("3. Start Reflecting Activity");
                Console.WriteLine("4. Quit");
                Console.Write("Select an activity: ");

                string choice = Console.ReadLine();
                Activity selectedActivity = null;

                if (choice == "1")
                {
                    selectedActivity = new BreathingActivity();
                }
                else if (choice == "2")
                {
                    selectedActivity = new ListingActivity();
                }
                else if (choice == "3")
                {
                    selectedActivity = new ReflectingActivity();
                }
                else if (choice == "4")
                {
                    running = false;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Press Enter to try again.");
                    Console.ReadLine();
                    continue;
                }

                if (selectedActivity != null)
                {
                    selectedActivity.Run();
                    Console.WriteLine("\nPress Enter to return to the main menu.");
                    Console.ReadLine();
                }
            }
            Console.WriteLine("Goodbye!");
        }
    }
}