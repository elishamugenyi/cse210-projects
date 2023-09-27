using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        //i have created two instances called job1 and job2
        Job job1 = new Job();
        Job job2 = new Job();

        //set the member variables using dot notation
        job1._company ="Microsoft";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2020;
        job1._endYear = 2023;

        job2._company ="Apple";
        job2._jobTitle = "Social Engineer";
        job2._startYear = 2019;
        job2._endYear = 2022;
        
         
        //adding a new instance of resume class
        Resume myResume = new Resume();
        myResume._name = "Elisha Mugenyi";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        Console.WriteLine("Displaying results of the job!");
        job1.Display();
        myResume.Display();
    }
}