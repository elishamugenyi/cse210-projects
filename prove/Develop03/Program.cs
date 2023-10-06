using System;
using System.Collections.Generic;
using System.IO;

class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }

    public JournalEntry(string prompt, string response)
    {
        Prompt = prompt;
        Response = response;
        Date = DateTime.Now;
    }

    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}

class Journal
{
    private List<JournalEntry> entries = new List<JournalEntry>();

    public void AddEntry(string prompt, string response)
    {
        entries.Add(new JournalEntry(prompt, response));
    }

    public List<JournalEntry> GetEntries()
    {
        return entries;
    }

    // Implement methods to save and load the journal to/from a file.
}

class Program
{
    static Journal journal = new Journal();
    static Random random = new Random();

    static void Main()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Journal Program Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option (1-5): ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        WriteNewEntry();
                        break;
                    case 2:
                        DisplayJournal();
                        break;
                    case 3:
                        SaveJournal();
                        break;
                    case 4:
                        LoadJournal();
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    // Implement the WriteNewEntry, DisplayJournal, SaveJournal, and LoadJournal methods.
}
