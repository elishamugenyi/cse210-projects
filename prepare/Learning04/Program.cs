using System;
using System.ComponentModel;
using System.Reflection.PortableExecutable;


class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new Assignment("Elisha", "Inheritance");
          
        Console.WriteLine(assignment.GetSummary());

        MathAssignment m1 = new MathAssignment("Elisha", "Inheritance", "OOP", "Abstraction");
        Console.WriteLine(assignment.GetSummary());
        Console.WriteLine(m1.GetHomeWorkList());

        WritingAssignment w1 = new WritingAssignment("Elisha", "Wealth", "Rich Dad Poor Dad");
        //Console.WriteLine(assignment.GetSummary());
        Console.WriteLine(w1.GetWritingInfo());
    }
}