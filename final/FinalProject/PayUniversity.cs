//this does not inherit from student but use student as an object because paying is an activity and not some type of student.
using System;
using System.IO;
using System.Runtime.InteropServices;

//create a class for paying, does not inherit from student because it is an action not a typenof student
public class PayUniversity
{
    //set attributes here
    private string _semester;
    private double _tuitionamount;
    //create a constructor
    public PayUniversity()
    {

    }

    public void Pay(Student student)
    {
        Console.WriteLine("Enter Semester to Pay:");
        _semester = Console.ReadLine();

        if (student.AccountBalance == 0)
        {
            TopUp top = new TopUp();
            top.TopUp(student)
            Console.WriteLine("Enter Tuition Amount to Pay:");
            _tuitionamount = double.Parse(Console.ReadLine());
            student.AccountBalance -= _tuitionamount;

            Console.WriteLine("");
            //Console.WriteLine($"Your new Account Balance is: {student.AccountBalance}");
            Console.WriteLine("Paid successfully");
            //student.AccountBalance -= _tuitionamount;
            //Console.WriteLine("Paid successfully!");
            
        }
        else
        {
            Console.WriteLine("Enter Tuition Amount to Pay:");
            _tuitionamount = double.Parse(Console.ReadLine());

            if(student.AccountBalance >= _tuitionamount)
            {
                Console.WriteLine("");
                Console.WriteLine("Paid successfully");
                Console.WriteLine("");
                student.AccountBalance -= _tuitionamount;
                Console.WriteLine($"Your Tuition Balance is {student.AccountBalance}");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Insufficent Funds. Please add funds to your account");
                Console.WriteLine($" StudentPay account balance is {student.AccountBalance}");
            }
            
        }
    }
}