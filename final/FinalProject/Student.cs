using OfficeOpenXml;
using OfficeOpenXml.Filter;
using System;
//using System.Data.Common;
using System.IO;
//using System.Linq;
//using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;

//this is the base class and starting class in this final project.
public class Student
{
    //create the attributes for this class.
    private int _studentID;
    private string _name, _email, _password;
    private double _accountbalance;

    //set properties for accessing attributes
    public int StudentID{ get=> _studentID;}
    public string Name{ get=> _name;}
    public string Email{ get=> _email;}
    public string Password{ get=> _password;}
    public double AccountBalance{ get=> _accountbalance; set=> _accountbalance = value;}

    //create a constructor using the properties set
    public Student(int studentID, string name, string email, string password)
    {
        _studentID = studentID;
        _name = name;
        _email = email;/*IsValidEmail(email) ? email : throw new ArgumentException("Invalid email format");*/
        _password = password;
        _accountbalance = 0;
    }

    //create a getstudentid method to use in other classes
    public int GetStudentId()
    {
        return _studentID;
    }
    //set account balance method
    public void SetAccountBalance(double balance)
    {
        _accountbalance = balance;
    }


    public void SignUp()
    {
        Console.WriteLine("Enter Student ID( NUMBERS ONLY ):");
        _studentID = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Name:");
        _name = Console.ReadLine();

        Console.WriteLine("Enter Email:");
        _email =Console.ReadLine();
        //check email validation
        /*if(IsValidEmail(inputEmail))
        {
            _email = inputEmail;
        }
        else
        {
            Console.WriteLine("Invalid Email format. Registration failed");
            return;
        }
        */
        Console.WriteLine("Enter Password:");
        _password =Console.ReadLine();


        //load eixisting file and it is not present, create excel package
        //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;//mentioning EPPlus is non commercial for this project
        FileInfo file = new FileInfo("StudentData.xlsx");
        using (var package = new ExcelPackage(file))
        {
            //get first worksheet assuming it exist.
            var worksheet = package.Workbook.Worksheets.FirstOrDefault();
            //add a worksheet to the excel package
            //var worksheet = package.Workbook.Worksheets.Add("StudentData");

            //if worksheet doesn't exist, create it
            if (worksheet == null)
            {
                worksheet = package.Workbook.Worksheets.Add("StudentData");
                //set column headers
                worksheet.Cells["A1"].Value = "Student ID";
                worksheet.Cells["B1"].Value = "Name";
                worksheet.Cells["C1"].Value = "Email";
                worksheet.Cells["D1"].Value = "Password";
            }
            //find the first empty row
            int row = 2;
            while (worksheet.Cells[row, 1].Value != null)
            {
                row++;
            }          
            //add user date to worksheet
            worksheet.Cells[row, 1].Value = _studentID;
            worksheet.Cells[row, 2].Value = _name;
            worksheet.Cells[row, 3].Value = _email;
            worksheet.Cells[row, 4].Value = _password;
          

            //save the excel package to a file
            //var file = new FileInfo("StudentData.xlsx");
            package.Save();

        }

        Console.WriteLine("Registered successfully");
    }
    /*private bool IsValidEmail(string email)
    {
        // Use a regular expression for basic email validation
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        return Regex.IsMatch(email, pattern);
    }
*/

}