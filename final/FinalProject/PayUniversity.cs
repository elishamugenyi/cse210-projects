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
        int studentId = student.GetStudentId();//get student ID so it can be appended to the list.
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
            FileInfo file = new FileInfo("StudentTransactions.xlsx");
            using (var package = new ExcelPackage(file))
            {
                //add worksheet to store these details to the excel package
                //var worksheet = package.Workbook.Worksheets.Add("StudentTransactions");

                //get first worksheet assuming it exist
                var worksheet = package.Workbook.Worksheets.FirstOrDefault();

                //if it doesn't exist, create it
                if (worksheet == null)
                {
                    worksheet = package.Workbook.Worksheets.Add("StudentTransactions");
                    //set column headers
                    worksheet.Cells["A1"].Value = "Student ID";
                    worksheet.Cells["B1"].Value = "Semester";
                    worksheet.Cells["C1"].Value = "Tuition Paid";
                }
                //find the first empty row
                int row = 2;
                while (worksheet.Cells[row, 1].Value != null)
                {
                    row++;
                }                       
                //add values to the excel sheet
                worksheet.Cells[row, 1].Value = studentId;
                worksheet.Cells[row, 2].Value = _semester;
                worksheet.Cells[row, 3].Value = _tuitionamount;
                //save the file
                //var file = new FileInfo("StudentTransactions.xlsx");
                package.Save();
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