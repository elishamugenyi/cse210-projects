using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Encapsulation process.!");
        //create fractions using different constructors

        Fraction fraction1 = new Fraction();
        Console.WriteLine($"fraction1 is:{fraction1.GetFractionString()}");
        Console.WriteLine($"fraction1 is:{fraction1.GetDecimalValue()}");

        Fraction fraction2 = new Fraction(5);
        Console.WriteLine($"fraction2 is:{fraction2.GetFractionString()}");
        Console.WriteLine($"fraction2 is:{fraction2.GetDecimalValue()}");

        Fraction fraction3 = new Fraction(5,3);
        Console.WriteLine($"For fraction 3 {fraction3.GetFractionString()}");
        Console.WriteLine($"For fraction 3 {fraction3.GetDecimalValue()}");
    
    }
}