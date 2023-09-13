using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage, Do not include the percent symbol!");
        string grade = Console.ReadLine();
        int grade1 = int.Parse(grade);
        
        if (grade1 >= 90)
        {
            Console.WriteLine("Your Grade is A");
        }
        else if(grade1 >= 80)
        {
            Console.WriteLine("Your Grade is B");
        }
        else if(grade1 >= 70)
        {
            Console.WriteLine("Your Grade is C");
        }
        else if(grade1 >= 60)
        {
            Console.WriteLine("Your Grade is D");
        }
        else
        {
            Console.WriteLine("Your Grade is an F");
        }

        if (grade1== 70 || grade1>= 70)
        {
            Console.WriteLine("Congragulations, You passed the class");
        }
        else 
        {
            Console.Write("You did not pass the class, please try again next Semester");
        }
    }
}