using System;

//create a reference class
public class Reference
{
    //create the attibrutes for this class
    private string _book;
    private string _chapter;
    private string _verse;
    private string _endverse;
    private string _ref;

    //create constructors to help set values and use in methods.

    public Reference ()
    {
        Console.WriteLine("What is the scripture Book?");
        _book = Console.ReadLine();

        Console.WriteLine("What is the scripture Chapter?");
        _chapter = Console.ReadLine();
        int chap = int.Parse(_chapter);

        Console.WriteLine("What is the scripture Verse? Give verse number.");
        _verse = Console.ReadLine();
        int verse1 = int.Parse(_verse);

        Console.WriteLine("What is the scripture End/Next Verse? Give verse number. If there is no next verse please type NA");
        _endverse = Console.ReadLine();

        if (_endverse == "NA")
        {
            _ref = $"{_book} {chap}:{verse1}";
        }
        else
        {
            _ref = $"{_book} {chap}:{verse1}-{_endverse}";
        }
        
    }

    //create a method that gets the reference string
    public void GetReference()
    {
        Console.WriteLine(_ref);        
    }

}