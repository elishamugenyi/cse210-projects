using System;

class Program
{
    static Journal journal = new Journal();
    static Journal.PromptRandomizer journal1 = new Journal.PromptRandomizer(); 
    static Random random = new Random();

    static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Journal Program Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option (1-5): ");
            int userResponse = int.Parse(Console.ReadLine());

            if (userResponse == 1)
            {     
                //i want to run a random prompt for the user here then they add their response after which i add it to the list        
                journal1.ChoosePrompt();
                Console.WriteLine("Answer here:");// code executes here is i type in 1, then shows this "Answer here:", and it goes back to the menu display.
                journal.AddEntry();
            }
            else if (userResponse == 2)
            {
                Console.WriteLine("Your Journal entry is:");
                journal.ToString();
            }
            else if (userResponse == 3)
            {
                //still constructing this.journal.saveJournal();
            }
            else if (userResponse == 4)
            {
                //journal.loadjournal();
            }
            else if (userResponse == 5)
            {
                //exit program
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
       
    }
}