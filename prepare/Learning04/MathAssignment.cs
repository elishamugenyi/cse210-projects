using System;

//create a class mathassignement that inherits from assignment class
public class MathAssignment : Assignment
{
    private string _textbook;
    private string _problem;

    //create a constructor that takes all four parameters including the two from the base class
    public MathAssignment(string studentName, string topic, string textbook, string problem) : base(studentName, topic)
    {
        _textbook = textbook;
        _problem = problem;
    }

    //create a set method
    public string GetTextBook()
    {
        return _textbook;
    }
    public string GetProblem()
    {
        return _problem;
    }

    //create the GetHomeworklist method that returns the string of all the assignments values
    public string GetHomeWorkList()
    {
        return $"Sections {_textbook}: Problems {_problem}";
    }
}
