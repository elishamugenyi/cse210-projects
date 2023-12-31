using OfficeOpenXml;
using OfficeOpenXml.Filter;
using System;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
//create a class that lets a student to top up their account balance.
public class TopUp
{
    private double _amount;
    private string _bankname;
    private double _bankaccount;


    public void BuyCredit(Student student)
    {
        Console.WriteLine("Do you want to Top Up? Y/N");
        string s = Console.ReadLine();

        if(s == "Y")
        {
            int studentID = student.GetStudentId();//used get method to get studentId
            Console.WriteLine("How much do you need to top up?");
            _amount = double.Parse(Console.ReadLine());
            
            Console.WriteLine("Provide your Local Bank Name:");
            _bankname = Console.ReadLine();
            Console.WriteLine("Provide your Local Bank Account:");
            _bankaccount = double.Parse(Console.ReadLine());
            Console.WriteLine("NOTE: ||Bank name & account will be used to remit funds to StudentPay for the credit you have bought.||");

            student.AccountBalance += _amount;
            Console.WriteLine($"{student.GetStudentId()} Your new Account balance is {student.AccountBalance}");
             //create a file that stores student credit & semester payment transactions for remitances in the future
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            FileInfo file = new FileInfo("StudentCredit.xlsx");//check if file already exist
            using (var package = new ExcelPackage(file))
            {
                //get worksheet assuming it exists.
                var worksheet = package.Workbook.Worksheets.FirstOrDefault();

                //if the worksheet doesn't exist, create it.
                if (worksheet == null)
                {
                    worksheet = package.Workbook.Worksheets.Add("StudentCredit");
                    //set column headers
                    worksheet.Cells["A1"].Value = "StudentID";
                    worksheet.Cells["B1"].Value = "Amount";
                    worksheet.Cells["C1"].Value = "Bank Name";
                    worksheet.Cells["D1"].Value = "Bank Account";
                }
                //find the first empty row
                int row = 2;
                while (worksheet.Cells[row, 1].Value != null)
                {
                    row++;
                }
                //add values to the excel sheet
                worksheet.Cells[row, 1].Value = studentID;
                worksheet.Cells[row, 2].Value = _amount;
                worksheet.Cells[row, 3].Value = _bankname;
                worksheet.Cells[row, 4].Value = _bankaccount;
                
                //save the file
                //var file = new FileInfo("StudentCredit.xlsx");
                package.Save();
            }
            Console.WriteLine("Data saved.");
            
        }
        else
        {
            Console.WriteLine("Sorry transaction cancelled!");
        }
    }

}
