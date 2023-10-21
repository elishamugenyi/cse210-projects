using System;

//create a class mathassignement that inherits from assignment class
public class WritingAssignment : Assignment
{
    private string _title;

    //create a constructor that takes all four parameters including the two from the base class
    public WritingAssignment(string studentName, string topic, string title) : base(studentName, topic)
    {
        _title = title;
    }
    
    //create the GetHomeworklist method that returns the string of all the assignments values
    public string GetWritingInfo()
    {
        string studentName = GetStudentName();
        return $"{_title} by {studentName}";
    }
}
