using OfficeOpenXml;
using System;
using System.IO;

public class PayUniversity
{
    private string _semester;
    private double _tuitionamount;
    private string _cardNumber;

    public PayUniversity()
    {
    }

    public void Pay(Student student)
    {   
        //Get the logged-in student's ID
        int studentId = student.GetStudentId();
        
        Console.WriteLine("Enter your virtual card number:");
        _cardNumber = Console.ReadLine();

        // Validate card and get balance
        double cardBalance = GetCardBalance(_cardNumber);
        
        if (cardBalance < 0)
        {
            Console.WriteLine("Invalid card number. Please create a virtual card first.");
            return;
        }

        Console.WriteLine($"Current card balance: {cardBalance}");
        Console.WriteLine("Enter Semester to Pay:");
        _semester = Console.ReadLine();
        Console.WriteLine("Enter Tuition Amount to Pay:");
        _tuitionamount = double.Parse(Console.ReadLine());

        if (cardBalance >= _tuitionamount)
        {
            // Process payment
            cardBalance -= _tuitionamount;
            UpdateCardBalance(_cardNumber, cardBalance);
            
            Console.WriteLine("\nPaid successfully");
            Console.WriteLine($"Your new card balance is: {cardBalance}");

            // Record transaction
            RecordTransaction(student.GetStudentId(), _semester, _tuitionamount, _cardNumber, cardBalance);
            
            Console.WriteLine("Transaction saved.");
        }
        else
        {
            Console.WriteLine("\nInsufficient funds on card. Please top up.");
            TopUp top = new TopUp();
            top.BuyCredit(student);
        }
    }

    private double GetCardBalance(string cardNumber)
    {
        FileInfo file = new FileInfo("VirtualCards.xlsx");
        if (!file.Exists) return -1;

        using (var package = new ExcelPackage(file))
        {
            var worksheet = package.Workbook.Worksheets.FirstOrDefault();
            if (worksheet == null) return -1;

            int rowCount = worksheet.Dimension.Rows;
            
            for (int row = 2; row <= rowCount; row++)
            {
                var storedCardNumber = worksheet.Cells[row, 2].Value?.ToString();
                if (storedCardNumber == cardNumber)
                {
                    // Check if balance column exists (column 5)
                    if (worksheet.Dimension.Columns >= 5 && worksheet.Cells[row, 5].Value != null)
                    {
                        return Convert.ToDouble(worksheet.Cells[row, 5].Value);
                    }
                    return 0; // If balance column doesn't exist, assume zero balance
                }
            }
        }
        return -1;
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
                    // Update balance in column 5
                    worksheet.Cells[row, 5].Value = newBalance;
                    break;
                }
            }
            package.Save();
        }
    }

    private void RecordTransaction(int studentId, string semester, double amount, string cardNumber, double cardBalance)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        FileInfo file = new FileInfo("StudentTransactions.xlsx");
        
        using (var package = new ExcelPackage(file))
        {
            var worksheet = package.Workbook.Worksheets.FirstOrDefault();

            if (worksheet == null)
            {
                worksheet = package.Workbook.Worksheets.Add("StudentTransactions");
                worksheet.Cells["A1"].Value = "Student ID";
                worksheet.Cells["B1"].Value = "Semester";
                worksheet.Cells["C1"].Value = "Tuition Paid";
                worksheet.Cells["D1"].Value = "Card Number";
                worksheet.Cells["E1"].Value = "Card Balance After Payment";
            }

            int row = 2;
            while (worksheet.Cells[row, 1].Value != null)
            {
                row++;
            }
            
            worksheet.Cells[row, 1].Value = studentId;
            worksheet.Cells[row, 2].Value = semester;
            worksheet.Cells[row, 3].Value = amount;
            worksheet.Cells[row, 4].Value = cardNumber;
            worksheet.Cells[row, 5].Value = cardBalance;
            
            package.Save();
        }
    }
}



//this does not inherit from student but use student as an object because paying is an activity and not some type of student.
/*using OfficeOpenXml;
using OfficeOpenXml.Filter;
using System;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
*/

/*
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
}*/