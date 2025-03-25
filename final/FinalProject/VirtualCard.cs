using System;
using System.IO;
using SkiaSharp;
using OfficeOpenXml;
using OfficeOpenXml.Filter;

public class VirtualCard
{
    private int _cardnumber;
    private int _ccvnumber;
    private string _cardholder;
    private DateTime _expire;
    private string _imagePath;

    public VirtualCard()
    {
        Console.WriteLine("Enter Your First Name:");
        string firstName = Console.ReadLine();
        Console.WriteLine("Enter Your Last Name:");
        string lastName = Console.ReadLine();
        _cardholder = $"{firstName} {lastName}";
        
        CreateCard();
        GenerateCardImage();
    }

    public void CreateCard()
    {
        Console.WriteLine($"Card created for {_cardholder}");

        _cardnumber = GenerateCardNumber();
        //Console.WriteLine($"Card number: {FormatCardNumber(_cardnumber)}");

        _ccvnumber = GenerateCcvNumber();
        //Console.WriteLine($"CCV number: {_ccvnumber}");

        _expire = DateTime.Now.AddYears(2);
        //Console.WriteLine($"Valid To: {_expire.ToString("MM/yy")}");
    }

    private int GenerateCardNumber()
    {
        Random rand = new Random();
        return rand.Next(10000000, 99999999);
    }

    private int GenerateCcvNumber()
    {
        Random rand = new Random();
        return rand.Next(100, 999);
    }

    private string FormatCardNumber(int cardNumber)
    {
        // Format as XXXX-XXXX for display
        return $"{cardNumber.ToString().Substring(0, 4)}-{cardNumber.ToString().Substring(4)}";
    }
    //Added function that generates card and displays details on the image card.
    public void GenerateCardImage()
    {
        int width = 850;
        int height = 540;

        using (var bitmap = new SKBitmap(width, height))
        using (var canvas = new SKCanvas(bitmap))
        {
            // Create a linear gradient paint
            var gradientShader = SKShader.CreateLinearGradient(
                new SKPoint(0, 0),
                new SKPoint(width, height),
                new SKColor[] { new SKColor(30, 80, 180), new SKColor(50, 150, 100) },
                SKShaderTileMode.Clamp
            );

            using (var paint = new SKPaint { Shader = gradientShader })
            {
                canvas.DrawRect(new SKRect(0, 0, width, height), paint);
            }

            // Draw text on the card
            using (var paint = new SKPaint { Color = SKColors.White, TextSize = 36, IsAntialias = true })
            {
                canvas.DrawText(_cardholder.ToUpper(), 50, 400, paint);
                canvas.DrawText(FormatCardNumber(_cardnumber), 50, 300, paint);
                canvas.DrawText($"VALID TO: {_expire:MM/yy}", 50, 350, paint);
                canvas.DrawText($"CCV: {_ccvnumber}", 600, 400, paint);
                canvas.DrawText("VIRTUAL CREDIT CARD", 50, 50, paint);
            }

            // Save the image
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            _imagePath = Path.Combine(desktopPath, $"{_cardholder.Replace(" ", "_")}_VirtualCard.png");

            using (var image = SKImage.FromBitmap(bitmap))
            using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
            using (var stream = File.OpenWrite(_imagePath))
            {
                data.SaveTo(stream);
            }

            Console.WriteLine($"\nCard image saved to: {_imagePath}");
        }

        //store the created card details in an excel file.
        FileInfo file = new FileInfo("VirtualCards.xlsx");
        using (var package = new ExcelPackage(file))
        {
            //get first worksheet assuming it exist.
            var worksheet = package.Workbook.Worksheets.FirstOrDefault();
            //add a worksheet to the excel package
            //var worksheet = package.Workbook.Worksheets.Add("StudentData");

            //if worksheet doesn't exist, create it
            if (worksheet == null)
            {
                worksheet = package.Workbook.Worksheets.Add("VirtualCards");
                //set column headers
                worksheet.Cells["A1"].Value = "Card Holder";
                worksheet.Cells["B1"].Value = " Card Number";
                worksheet.Cells["C1"].Value = "CCV Number";
                worksheet.Cells["D1"].Value = "Expiry Date";
            }
            //find the first empty row
            int row = 2;
            while (worksheet.Cells[row, 1].Value != null)
            {
                row++;
            }          
            //add user date to worksheet
            worksheet.Cells[row, 1].Value = _cardholder;
            worksheet.Cells[row, 2].Value = _cardnumber;
            worksheet.Cells[row, 3].Value = _ccvnumber;
            worksheet.Cells[row, 4].Value = _expire;
            worksheet.Cells[row, 5].Value = 0; // Initialize balance to zero
          

            //save the excel package to a file
            //var file = new FileInfo("StudentData.xlsx");
            package.Save();

        }
    }
    public string GetImagePath()
    {
        return _imagePath;
    }
}
 //create class to create a virtual card
 /*public class VirtualCard
 {
    private int _cardnumber;
    private int _ccvnumber;
    private string _cardholder;
    private DateTime _expire;

    //constructor that takes input from user to create virtual card
    public VirtualCard()
    {
        Console.WriteLine("Enter Your First Name:");
        _cardholder = Console.ReadLine();
        Console.WritelINE("Enter Your Last Name")
        CreateCard();

    }
    public void CreateCard()
    {
        Console.WriteLine($"Card created for {_cardholder}");

        //create card number
        _cardnumber = GenerateCardNumber();
        Console.WriteLine($"Card number: {_cardnumber}");

        //create ccv number
        _ccvnumber = GenerateCcvNumber();
        Console.WriteLine($"CCV number: {_ccvnumber}");

        //set expire date for card to 2 years from date of creation.
        _expire = DateTime.Now.AddYears(2);
        Console.WriteLine($"Valid To: {_expire.ToShortDateString()}");
    }

    //method to generate random numbers.
    private int GenerateCardNumber()
    {
        Random rand = new Random();
        int cardnumber = rand.Next(10000000, 99999999);
        return cardnumber;
    }

    private int GenerateCcvNumber()
    {
        Random rand = new Random();
        int ccvnumber = rand.Next(100, 999);
        return ccvnumber;
    }
 }*/