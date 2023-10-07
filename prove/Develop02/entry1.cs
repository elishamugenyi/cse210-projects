using System;
//i will create a class for the entyies from the user.

public class Entry{
    //create the variables needed here

    public string Prompt {get; set;}
    public string Response {get; set;}
    public string Date {get; set;}

    //create a constructor for entry class
    public Entry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    public override string ToString()//method that will display journal entry by user with a date
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
    
}

