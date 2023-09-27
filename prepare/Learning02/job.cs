//create a new class called job

using System.ComponentModel.DataAnnotations;

public class Job{
    //Class variables
    public String _company, _jobTitle;
    public int _startYear, _endYear;

    //class method returns nothing

    public void Display()
    {
         Console.WriteLine($"Job Details:{_jobTitle}({_company}) {_startYear}-{_endYear}");
    }

}