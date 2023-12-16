using System;
 //create class to create a virtual card
 public class VirtualCard
 {
    private int _cardnumber;
    private int _ccvnumber;
    private string _cardholder;
    private DateTime _expire;

    //constructor that takes input from user to create virtual card
    public VirtualCard()
    {
        Console.WriteLine("Enter Your Name:");
        _cardholder = Console.ReadLine();
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
 }