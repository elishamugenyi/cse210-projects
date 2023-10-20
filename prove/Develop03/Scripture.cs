using System;

//create variables for this class
public class Scripture
{
    private string _script;
    private string verse;
    private string verse2;

//create a constructor, takes no arguments and gets user input
    public Scripture()
    {
        Console.WriteLine("Write your favorite scripture verse?");
        verse = Console.ReadLine();

        Console.WriteLine("Write your favorite scripture verse 2? If there is no verse write NA");
        verse2 = Console.ReadLine();

        if (verse2 == "NA")
        {
            _script = $"Favorite scripture:{verse}";
        }
        else
        {
            _script = $"Favorite scripture:{verse} {verse2}";
        }
    }

    //method to display the user input as script, returns nothing
    public void DisplayScripture()
    {
        Console.WriteLine(_script);
    }

    //create a method that removes words each time an enter key is pressed
    public void RemoveWords()
    {
         Console.WriteLine("Press Enter to remove words from the scripture. Press any other key to exit.");
        while (Console.ReadKey().Key == ConsoleKey.Enter)
        {
            // Split the scripture into words
            string[] words = _script.Split(' ');

            // Remove one word
            if (words.Length > 1)
            {
                Array.Resize(ref words, words.Length - 1);
                _script = string.Join(" ", words);
                Console.WriteLine(_script);
            }
            else
            {
                Console.WriteLine("No more words to remove.");
                break;
            }
        }
    }
}