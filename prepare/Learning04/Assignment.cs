using System;

//create a base/parent/super class with attributes needed by other child classes.

public class Assignment
{
    //all attributes here are private (encapsulation principle)

    private string _studentname;
    private string _topic;
   

    //create a no argument constructor
    public Assignment(string studentName, string topic)
    {
        _studentname = studentName;
        _topic = topic;

    }

    //create get methods
    public string GetStudentName()
    {
        return _studentname;
    }
    public string GetTopic()
    {
        return _topic;
    }

    //create a method GetSummary
    public string GetSummary()
    {
        return _studentname + "-" + _topic;
    }

}