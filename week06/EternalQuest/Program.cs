using System;

class Program
{
    public static void DisplayMainMenu()
    {
        Console.WriteLine("\n--- Menu Options ---");
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. List Goals");
        Console.WriteLine("3. Record Event");
        Console.WriteLine("4. Save Goals");
        Console.WriteLine("5. Load Goals");
        Console.WriteLine("6. Quit");
        Console.WriteLine(new string('-', 20));
    }

    public static void DisplayGoalTypeMenu()
    {
        Console.WriteLine("\n--- Goal Types ---");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine(new string('-', 20));
    }

    public static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.LoadGoals();

        while (true)
        {
            manager.DisplayPlayerInfo();
            DisplayMainMenu();

            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayGoalTypeMenu();
                    Console.Write("Which type of goal would you like to create? ");
                    string goalChoice = Console.ReadLine();

                    string goalType = null;
                    if (goalChoice == "1") goalType = "Simple";
                    else if (goalChoice == "2") goalType = "Eternal";
                    else if (goalChoice == "3") goalType = "Checklist";

                    if (goalType != null)
                    {
                        manager.CreateGoal(goalType);
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid goal type selection.");
                    }
                    break;

                case "2":
                    manager.ListGoalDetails();
                    break;

                case "3":
                    manager.ListGoalNames();
                    if (int.TryParse(Console.ReadLine(), out int goalIndex) && goalIndex > 0)
                    {
                        manager.RecordEvent(goalIndex);
                    }
                    else
                    {
                        Console.WriteLine("Invalid goal number entered.");
                    }
                    break;

                case "4":
                    manager.SaveGoals();
                    break;

                case "5":
                    manager.LoadGoals();
                    break;

                case "6":
                    manager.SaveGoals();
                    Console.WriteLine("\nThank you for playing the Eternal Quest! Goodbye.");
                    return;

                default:
                    Console.WriteLine("\nInvalid selection. Please choose a number from 1 to 6.");
                    break;
            }
        }
    }
}