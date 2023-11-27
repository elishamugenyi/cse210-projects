using System;
using OfficeOpenXml;

class Program
{
    static void Main(string[] args)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        //perform student login
        Login login = new Login();
        Student student = login.LoginStudent();

        if (student !=null)
        {
            Console.WriteLine($"Login successful. Welcome, {student.Name}");

            //set students balance to zero
            student.SetAccountBalance(0.00);
            Console.WriteLine($"Your account balance is:  {student.AccountBalance}");            
        }
        else
        {
            Console.WriteLine("Login unsuccessfull, Invalid ID or Password");
        }
        //Student student1 = new Student(20234567,  "eli", "email@testing.com", "password123");
        //student.SignUp();
        Console.WriteLine("Hello FinalProject World!...The End");
    }
}