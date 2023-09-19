using System;

class Program
{
    static void Main(string[] args)
    {
        //this is for part 1
        Console.WriteLine("What is the magic number?");
       // string number1 = Console.ReadLine();
        //int num = int.Parse(number1);

        //Console.WriteLine("What is your guess?");
        //string guess = Console.ReadLine();
       // int guessed = int.Parse(guess);

        //this is part 2 where i introduced a while loop.
        Random randomGenerator = new Random();
        int num = randomGenerator.Next(1,100);

        int guess = -1;


        while (guess != num)
        {
            Console.WriteLine("What is your guess?");
            guess = int.Parse(Console.ReadLine());
        }
            if (num > guess)
            {
                Console.WriteLine("Higher, Try again");
            }
            else if (num < guess)
            {
                Console.WriteLine("Lower, Try again");
            }
            else 
            {
            Console.WriteLine("Correct, congrats!");
            }
    }
}