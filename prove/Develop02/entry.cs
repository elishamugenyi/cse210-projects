//i will create a class for the entyies from the user.

public class Entry{
    //create the variables needed here

    public string _prompt;
    public string _response;
    public DateTime _date;

    public override string ToString()//method that will display journal entry by user with a date
    {
        return $"Date: {_date}\nPrompt: {_prompt}\nResponse: {_response}\n";
    }
    
}