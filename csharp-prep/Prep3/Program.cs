using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is the magic number?");
        string number1 = Console.ReadLine();
        int num = int.Parse(number1);

        Console.WriteLine("What is your guess?");
        string guess = Console.ReadLine();
        int guessed = int.Parse(guess);

        if (guessed <5)
        {
            Console.WriteLine("You guessed is lower");
        }
        else if(guessed > 5)
        {
            Console.WriteLine("You guessed is higher");
        }
        else 
        {
            Console.WriteLine("Correct, the Number is 5!");

        }

    }
}