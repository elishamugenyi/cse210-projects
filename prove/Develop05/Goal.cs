using System;
using System.Collections.Generic;

// Base Class
public class Goal
{
    // Attributes
    public string Title { get; set; }
    public int Value { get; set; }
    public bool IsCompleted { get; set; }

    // Methods
    public virtual void CompleteGoal()
    {
        Console.WriteLine($"Goal '{Title}' has been completed!");
        IsCompleted = true;
    }

    public virtual void GetProgress()
    {
        Console.WriteLine($"Goal '{Title}' is {(IsCompleted ? "completed" : "not completed")}");
    }
}