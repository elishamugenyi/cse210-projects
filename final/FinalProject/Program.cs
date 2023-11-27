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

        //DISPLAY MENU
        bool exit = false;
        while(!exit)
        {
            Console.WriteLine("Select a choice to start.");
            Console.WriteLine("1.Sign up.");
            Console.WriteLine("2.Login.");
            Console.WriteLine("3.Exit");
            Console.WriteLine("Select an option 1-3");

            int choice;
            if(int.TryParse(Console.ReadLine(), out choice))
            {
                if (choice ==1)
                {
                    student.SignUp();
                }
                else if (choice ==2)
                {
                   if (student !=null)
                    {
                        Console.WriteLine($"Login successful. Welcome, {student.Name}");

                        //set students balance to zero
                        student.SetAccountBalance(0.00);
                        Console.WriteLine($"Your account balance is:  {student.AccountBalance:2f}");            
                    }
                    else
                    {
                        Console.WriteLine("Login unsuccessfull, Invalid ID or Password");
                        student.SignUp();
                    }
                    //Student student1 = new Student(20234567,  "eli", "email@testing.com", "password123");
                    //student.SignUp();
                    Console.WriteLine("Hello FinalProject World!...The End"); 
                }
                else if (choice ==3)
                {
                    //exit menu
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice, please try again");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice, please enter a number");
            }
        }
        
    }
}