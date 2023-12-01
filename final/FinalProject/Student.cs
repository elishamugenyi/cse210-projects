using OfficeOpenXml;
using OfficeOpenXml.Filter;
using System;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;

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
        _email = email;
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

        Console.WriteLine("Enter Password:");
        _password =Console.ReadLine();


        //create excel package
        //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;//mentioning EPPlus is non commercial for this project
        using (var package = new ExcelPackage())
        {
            //add a worksheet to the excel package
            var worksheet = package.Workbook.Worksheets.Add("StudentData");

            //set column headers
            worksheet.Cells["A1"].Value = "Student ID";
            worksheet.Cells["B1"].Value = "Name";
            worksheet.Cells["C1"].Value = "Email";
            worksheet.Cells["D1"].Value = "Password";
            

            //add user date to worksheet
            worksheet.Cells["A2"].Value = _studentID;
            worksheet.Cells["B2"].Value = _name;
            worksheet.Cells["C2"].Value = _email;
            worksheet.Cells["D2"].Value = _password;
          

            //save the excel package to a file
            var file = new FileInfo("StudentData.xlsx");
            package.SaveAs(file);

        }

        Console.WriteLine("Registered successfully");
    }


}