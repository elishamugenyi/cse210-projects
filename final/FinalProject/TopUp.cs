using OfficeOpenXml;
using System;
using System.IO;

public class TopUp
{
    private double _amount;
    private string _bankname;
    private double _bankaccount;
    private string _cardNumber;

    public void BuyCredit(Student student)
    {   
        //get student Id logged in
        int studentId = student.GetStudentId();
        
        Console.WriteLine("Do you want to Top Up? (Y/N)");
        string response = Console.ReadLine();

        if (response.ToUpper() == "Y")
        {
            // Ask for and validate card number
            Console.WriteLine("Enter your virtual card number:");
            _cardNumber = Console.ReadLine();

            if (!ValidateCardNumber(_cardNumber))
            {
                Console.WriteLine("Invalid card number. Please create a virtual card first (Option 3 in main menu).");
                return;
            }

            // Get current card balance
            double currentBalance = GetCardBalance(_cardNumber);
            Console.WriteLine($"Current card balance: {currentBalance}");

            // Get top-up details
            Console.WriteLine("How much do you want to top up?");
            _amount = double.Parse(Console.ReadLine());
            
            Console.WriteLine("Provide your Local Bank Name:");
            _bankname = Console.ReadLine();
            Console.WriteLine("Provide your Local Bank Account:");
            _bankaccount = double.Parse(Console.ReadLine());
            Console.WriteLine("NOTE: Bank name & account will be used to remit funds to StudentPay for the credit you have bought.");

            // Update card balance
            double newBalance = currentBalance + _amount;
            UpdateCardBalance(_cardNumber, newBalance);

            Console.WriteLine($"Top-up successful. New card balance: {newBalance}");

            // Record transaction in StudentCredit.xlsx
            RecordTransaction(student.GetStudentId(), _amount, _bankname, _bankaccount, _cardNumber, newBalance);
        }
        else
        {
            Console.WriteLine("Transaction cancelled!");
        }
    }

    private bool ValidateCardNumber(string cardNumber)
    {
        FileInfo file = new FileInfo("VirtualCards.xlsx");
        if (!file.Exists)
            return false;

        using (var package = new ExcelPackage(file))
        {
            var worksheet = package.Workbook.Worksheets.FirstOrDefault();
            if (worksheet == null)
                return false;

            int rowCount = worksheet.Dimension.Rows;
            
            for (int row = 2; row <= rowCount; row++)
            {
                var storedCardNumber = worksheet.Cells[row, 2].Value?.ToString();
                if (storedCardNumber == cardNumber)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private double GetCardBalance(string cardNumber)
    {
        FileInfo file = new FileInfo("VirtualCards.xlsx");
        using (var package = new ExcelPackage(file))
        {
            var worksheet = package.Workbook.Worksheets.FirstOrDefault();
            if (worksheet == null) return 0;

            int rowCount = worksheet.Dimension.Rows;
            
            for (int row = 2; row <= rowCount; row++)
            {
                var storedCardNumber = worksheet.Cells[row, 2].Value?.ToString();
                if (storedCardNumber == cardNumber)
                {
                    if (worksheet.Dimension.Columns >= 5 && worksheet.Cells[row, 5].Value != null)
                    {
                        return Convert.ToDouble(worksheet.Cells[row, 5].Value);
                    }
                    return 0;
                }
            }
        }
        return 0;
    }

    private void UpdateCardBalance(string cardNumber, double newBalance)
    {
        FileInfo file = new FileInfo("VirtualCards.xlsx");
        using (var package = new ExcelPackage(file))
        {
            var worksheet = package.Workbook.Worksheets.FirstOrDefault();
            if (worksheet == null) return;

            int rowCount = worksheet.Dimension.Rows;
            
            for (int row = 2; row <= rowCount; row++)
            {
                var storedCardNumber = worksheet.Cells[row, 2].Value?.ToString();
                if (storedCardNumber == cardNumber)
                {
                    // Ensure we have enough columns (add if needed)
                    if (worksheet.Dimension.Columns < 5)
                    {
                        worksheet.Cells[row, 5].Value = newBalance;
                    }
                    else
                    {
                        worksheet.Cells[row, 5].Value = newBalance;
                    }
                    break;
                }
            }
            package.Save();
        }
    }

    private void RecordTransaction(int studentId, double amount, string bankName, double bankAccount, string cardNumber, double newBalance)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        FileInfo file = new FileInfo("StudentCredit.xlsx");
        
        using (var package = new ExcelPackage(file))
        {
            var worksheet = package.Workbook.Worksheets.FirstOrDefault();

            if (worksheet == null)
            {
                worksheet = package.Workbook.Worksheets.Add("StudentCredit");
                worksheet.Cells["A1"].Value = "StudentID";
                worksheet.Cells["B1"].Value = "Amount";
                worksheet.Cells["C1"].Value = "Bank Name";
                worksheet.Cells["D1"].Value = "Bank Account";
                worksheet.Cells["E1"].Value = "Card Number";
                worksheet.Cells["F1"].Value = "New Balance";
            }

            int row = 2;
            while (worksheet.Cells[row, 1].Value != null)
            {
                row++;
            }
            
            worksheet.Cells[row, 1].Value = studentId;
            worksheet.Cells[row, 2].Value = amount;
            worksheet.Cells[row, 3].Value = bankName;
            worksheet.Cells[row, 4].Value = bankAccount;
            worksheet.Cells[row, 5].Value = cardNumber;
            worksheet.Cells[row, 6].Value = newBalance;
            
            package.Save();
        }
        Console.WriteLine("Transaction details saved.");
    }
}

/*using OfficeOpenXml;
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
*/