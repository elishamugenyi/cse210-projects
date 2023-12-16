using System;
using OfficeOpenXml;

class Program
{
    static void Main(string[] args)
    {
        
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        //perform student login
        Login login = new Login();
        Student student = new Student(0,"","","");//create student instance
        
        

        //pay tuition
        PayUniversity paytuition = new PayUniversity();
        //Student student = null;

        //DISPLAY MENU
        bool exit = false;
        while(!exit)
        {
            Console.WriteLine("Select a choice to start.");
            Console.WriteLine("1.Sign up.");
            Console.WriteLine("2.Login.");
            Console.WriteLine("3.Create Virtual Card.");
            Console.WriteLine("4.Exit.");
            Console.WriteLine("Select an option 1-4");

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
                        login.LoginStudent();
                        Console.WriteLine($"Login successful.");

                        //set students balance to zero
                        student.SetAccountBalance(0.00);
                        
                        Console.WriteLine("");
                        paytuition.Pay(student);            
                    }
                    else
                    {
                        Console.WriteLine("Login unsuccessfull, Invalid ID or Password");
                        student.SignUp();
                    }
                    
                    Console.WriteLine("Thank you for using StudentPay"); 
                }
                else if (choice ==3)
                {
                    //create Virtual card
                    VirtualCard virtualcard = new VirtualCard();

                }
                else if (choice == 4)
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