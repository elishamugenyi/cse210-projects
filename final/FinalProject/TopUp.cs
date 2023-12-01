using System;
using Sytem.IO;
//create a class that lets a student to top up their account balance.
public class TopUp
{
    private double _amount;
    //private int _Id, ;

    public void TopUp(Student student)
    {
        Console.WriteLine("Do you want to Top Up? Y/N");
        string s = Console.ReadLine();

        if(s == "Y")
        {
            Console.WriteLine("How much do you need to top up?");
            _amount = double.Parse(Console.ReadLine());

            student.AccountBalance += _amount;
            Console.WriteLine($"{student.StudentID} Your new Account balance is {student.AccountBalance}");
        }
        else (s == "N")
        {
            Console.WriteLine("Sorry transaction cancelled!")
        }
    }
}
