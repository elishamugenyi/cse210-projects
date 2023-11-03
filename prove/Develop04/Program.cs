using System;

class Program
{
    static void Main(string[] args)
    {
        //create the listing instance
        Listing listing = new Listing();

        //use loop to run and display menu to user
        bool exit = false;
        while(!exit)
        {
            Console.WriteLine("Mindfull App:");
            Console.WriteLine("1. Start Breathing exercise");
            Console.WriteLine("2. Start the Reflection exercise");
            Console.WriteLine("3. Start the Listing exercise");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option (1-4): ");
            
            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                if (choice == 1)
                    {    
                        //start the breathing activity        
                        Breathing breathing = new Breathing();

                    }
                    else if (choice == 2)
                    {
                        //run the reflection activity.
                        Console.Write("Enter the duration for the reflection activity in seconds: ");
                        if (int.TryParse(Console.ReadLine(), out int durationInSeconds))
                        {
                            Reflection reflection = new Reflection(durationInSeconds);
                            reflection.StartActivity();
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number of seconds.");
                        }
                        
                    }
                    else if (choice == 3)
                    {
                        //run the listing exercise
                        string prompt = listing.ChoosePrompt();

                        Console.WriteLine(prompt);
                        Console.WriteLine("Answer here:");// user types their answer here
                        string response = Console.ReadLine();
                        
                    }
                    else if (choice == 4)
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
