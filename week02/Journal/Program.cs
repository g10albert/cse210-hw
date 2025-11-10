using System;

class Program
{
    static void Main(string[] args)
    {
        PromptGenerator promptGenerator1 = new PromptGenerator();
        promptGenerator1._entries.Add("What was the moment of the day you enjoyed the most? ");
        promptGenerator1._entries.Add("What was the best music you listened to today");
        promptGenerator1._entries.Add("How would you describe the day in 3 words?");
        promptGenerator1._entries.Add("What didn't you do today that you want to do tomorrow?");
        promptGenerator1._entries.Add("What do you think you could've done to be happier today?");

        Journal newJournal = new Journal();

        Console.WriteLine("Welcome to the journal program!");
        string userSelection = "";

        while (userSelection != "5")
        {
            Console.WriteLine("Please select one of the following choises: \n 1. Write \n 2. Display \n 3. Load \n 4. Save \n 5. Quit");

            Console.Write("What would you like to do? ");
            userSelection = Console.ReadLine();

            if (userSelection == "1")
            {
                string generatedPrompt = promptGenerator1.GetRandomPrompt();
                Console.WriteLine(generatedPrompt);

                newJournal.AddEntry(generatedPrompt);
            }
            else if (userSelection == "2")
            {
                newJournal.DisplayAll();
            }
            else if (userSelection == "3")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                newJournal.LoadFromFile(filename);
            }
            else if (userSelection == "4")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                newJournal.SaveToFile(filename);
            }
            else if (userSelection == "5")
            {
                Console.WriteLine("Exiting program");
            }
            else
            {
                Console.WriteLine("Enter a valid answer");
            }
        }
    }
}