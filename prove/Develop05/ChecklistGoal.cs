// Child Class 3
public class ChecklistGoal : Goal
{
    // Additional Attributes
    public int RequiredCount { get; set; }
    public int AccomplishedCount { get; set; }

    // Additional Method
    public override void CompleteGoal()
    {
        AccomplishedCount++;
        Console.WriteLine($"Checklist goal '{Title}' has been completed {AccomplishedCount}/{RequiredCount} times!");
        IsCompleted = (AccomplishedCount >= RequiredCount);
    }
}