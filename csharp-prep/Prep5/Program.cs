using System;

class Program
{
    static void Main(string[] args)
    {
        //declared the function names, i was getting yellow underlinings
        //on the function names, before i checked the sample solution to realize
        //the names were declared on top to be used later. this removed the yellow lines.
        DisplayWelcome();
        string username = PromptUserName();
        int userNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(userNumber);

        DisplayResult(username, squaredNumber);

        //display message function
        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Program!");
        }

        //displays username
       static string PromptUserName()
       {
            Console.WriteLine("What is your name?:");
            string username = Console.ReadLine();
            return username;
        }

        //displays usernumber
        static int PromptUserNumber()
       {
            Console.WriteLine("What is your number?:");
            int userNumber = int.Parse(Console.ReadLine());
            return userNumber;
        }

        //squares the number of the user
        static int SquareNumber(int userNumber)
       {
            //Console.WriteLine("What is your number?:");
            //square = int.Parse(Console.ReadLine());
            int num = userNumber * userNumber;
            return num;
        }

        //displays name and number squared.
        static void DisplayResult(string username, int square)
    {
        Console.WriteLine($"{username}, the square of your number is {square}");
    }
    }
}