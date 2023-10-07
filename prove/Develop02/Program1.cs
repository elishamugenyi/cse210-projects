using System;

class Program
{    static void Main(string[] args)
    {
        
    Journal journal = new Journal();
    
    // Define the filename for saving and loading journal entries
    string filename = "journal.csv";

    //create instance for PromptRandomizer class to handle prompts.
     PromptGeneration promptGenerator = new PromptGeneration();
    //static Random random = new Random();

        //use loop to run menu and display prompts to user
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
            
            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                if (choice == 1)
                    {    
                        //i implemented ToString() to display the user input, then picked a random prompt. 
                        //i want to run a random prompt for the user here then they add their response after which i add it to the list        
                        string date = DateTime.Now.ToString();
                        string prompt = promptGenerator.ChoosePrompt();

                        Console.WriteLine(prompt);
                        Console.WriteLine("Answer here:");// user types their answer here
                        string response = Console.ReadLine();
                
                        //then add to journal
                        journal.AddEntry(prompt, response, date);
                    }
                    else if (choice == 2)
                    {
                        //display entries using the display method in the csv file not on terminal.
                        Console.WriteLine("Your Journal entries are:");
                        journal.DisplayEntries();
                    }
                    else if (choice == 3)
                    {
                        //got this method in journal class to help me save file
                        journal.SaveToFile(filename);
                    }
                    else if (choice == 4)
                    {
                        //this loads entries into the file, these were missing
                        journal.LoadFromFile(filename);
                    }
                    else if (choice == 5)
                    {
                        //exit program
                        break;
                    }
                    else 
                    {       
                        Console.WriteLine("Invalid option, Please Try Again");
                    }

            }

            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
       
    }
}