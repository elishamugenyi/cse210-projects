//this does not inherit from student but use student as an object because paying is an activity and not some type of student.
using OfficeOpenXml;
using OfficeOpenXml.Filter;
using System;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;

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
            top.BuyCredit(student);
            Console.WriteLine("Enter Tuition Amount to Pay:");
            _tuitionamount = double.Parse(Console.ReadLine());
            student.AccountBalance -= _tuitionamount;

            //Console.WriteLine("");
            Console.WriteLine("Paid successfully");
            Console.WriteLine($"Your new Account Balance is: {student.AccountBalance}");

            Console.WriteLine("Your transactions!");
        
            //create a file that stores student credit & semester payment transactions for remitances in the future
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                //add worksheet to store these details to the excel package
                var worksheet = package.Workbook.Worksheets.Add("StudentTransactions");

                //set column headers
                worksheet.Cells["E1"].Value = "Semester";
                worksheet.Cells["F1"].Value = "Tuition Paid";

                //add values to the excel sheet
                worksheet.Cells["E2"].Value = _semester;
                worksheet.Cells["F2"].Value = _tuitionamount;
                //save the file
                var file = new FileInfo("StudentTransactions.xlsx");
                package.SaveAs(file);
            }
            Console.WriteLine("Transactions saved.");
            
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