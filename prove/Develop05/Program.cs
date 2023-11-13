using System;
using System.IO;
using System.Linq;
using System.Text;


// User Class
public class User
{
    // Attributes
    public List<Goal> Goals { get; set; }
    public int TotalScore { get; set; }

    // Methods
    public void AddGoal(Goal goal)
    {
        Goals.Add(goal);
    }

    public void RecordEvent(Goal goal)
    {
        goal.CompleteGoal();
        TotalScore += goal.Value;
    }

    public void SaveGoals(string filePath)
    {
        // Save goals implementation and save them to a csv file
        var csvContent = new StringBuilder();
        foreach (var goal in Goals)
        {
            var goalLine = $"{goal.Title},{goal.Value},{goal.IsCompleted},{(goal is ChecklistGoal ? ((ChecklistGoal)goal).AccomplishedCount : 0)},{(goal is ChecklistGoal ? ((ChecklistGoal)goal).RequiredCount : 0)}";
            csvContent.AppendLine(goalLine);
        }

        File.WriteAllText(filePath, csvContent.ToString());
        Console.WriteLine($"Goals saved to {filePath} successfully!");

       // Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals(string filePath)
    {
        // Load goals implementation and load them to a csv file
        try
        {
            var lines = File.ReadAllLines(filePath);
            Goals.Clear();

            foreach (var line in lines.Skip(1)) // Skip header line
            {
                var values = line.Split(',');
                var title = values[0];
                var goalValue = int.Parse(values[1]);
                var isCompleted = bool.Parse(values[2]);

                Goal goal;
                if (values.Length == 3)
                {
                    goal = new SimpleGoal { Title = title, Value = goalValue, IsCompleted = isCompleted };
                }
                else if (values.Length == 5)
                {
                    var accomplishedCount = int.Parse(values[3]);
                    var requiredCount = int.Parse(values[4]);
                    goal = new ChecklistGoal { Title = title, Value = goalValue, IsCompleted = isCompleted, AccomplishedCount = accomplishedCount, RequiredCount = requiredCount };
                }
                else
                {
                    goal = new Goal { Title = title, Value = goalValue, IsCompleted = isCompleted };
                }

                Goals.Add(goal);
            }

            Console.WriteLine($"Goals loaded from {filePath} successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
        //Console.WriteLine("Goals loaded successfully!");
    }
}


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Eternal Quest Game!");
        // create instance for user to start capturing goals.
        User user = new User();
        user.Goals = new List<Goal>();

        int mainChoice;
        do
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goal");
            Console.WriteLine("4. Load Goal");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");

            Console.Write("Select an option (1-6): ");
            mainChoice = int.Parse(Console.ReadLine());

            switch (mainChoice)
            {
                case 1:
                    CreateNewGoalMenu(user);
                    break;
                case 2:
                    ListGoals(user);
                    break;
                case 3:
                    Console.Write("Enter the file path to save goals (e.g., goals.csv): ");
                    string saveFilePath = Console.ReadLine();
                    user.SaveGoals(saveFilePath);
                    break;
                case 4:
                    Console.Write("Enter the file path to load goals from (e.g., goals.csv): ");
                    string loadFilePath = Console.ReadLine();
                    user.LoadGoals(loadFilePath);
                    break;
                case 5:
                    RecordEvent(user);
                    break;
                case 6:
                    Console.WriteLine("Exiting the program.");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

        } while (mainChoice != 6);
       
    }

    static void CreateNewGoalMenu(User user)
    {
        int goalTypeChoice;

        do
        {
            Console.WriteLine("Create New Goal Menu:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.WriteLine("4. Back to Main Menu");

            Console.Write("Select an option (1-4): ");
            goalTypeChoice = int.Parse(Console.ReadLine());

            switch (goalTypeChoice)
            {
                case 1:
                    CreateSimpleGoal(user);
                    break;
                case 2:
                    CreateEternalGoal(user);
                    break;
                case 3:
                    CreateChecklistGoal(user);
                    break;
                case 4:
                    Console.WriteLine("Returning to the main menu.");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

        } while (goalTypeChoice != 4);
    }

    static void CreateSimpleGoal(User user)
    {
        SimpleGoal simpleGoal = new SimpleGoal();
        Console.Write("Enter the title of the Simple Goal: ");
        simpleGoal.Title = Console.ReadLine();
        Console.Write("Enter the value of the Simple Goal: ");
        simpleGoal.Value = int.Parse(Console.ReadLine());

        user.AddGoal(simpleGoal);
        Console.WriteLine($"Simple Goal '{simpleGoal.Title}' created!");
    }

    static void CreateEternalGoal(User user)
    {
        EternalGoal eternalGoal = new EternalGoal();
        Console.Write("Enter the title of the Eternal Goal: ");
        eternalGoal.Title = Console.ReadLine();
        Console.Write("Enter the value of the Eternal Goal: ");
        eternalGoal.Value = int.Parse(Console.ReadLine());

        user.AddGoal(eternalGoal);
        Console.WriteLine($"Eternal Goal '{eternalGoal.Title}' created!");
    }

    static void CreateChecklistGoal(User user)
    {
        ChecklistGoal checklistGoal = new ChecklistGoal();
        Console.Write("Enter the title of the Checklist Goal: ");
        checklistGoal.Title = Console.ReadLine();
        Console.Write("Enter the value of the Checklist Goal: ");
        checklistGoal.Value = int.Parse(Console.ReadLine());
        Console.Write("Enter the required count for the Checklist Goal: ");
        checklistGoal.RequiredCount = int.Parse(Console.ReadLine());

        user.AddGoal(checklistGoal);
        Console.WriteLine($"Checklist Goal '{checklistGoal.Title}' created!");
    }

    static void ListGoals(User user)
    {
        Console.WriteLine("Listing Goals:");
        foreach (var goal in user.Goals)
        {
            Console.WriteLine($"- {goal.Title}");
        }
    }

    static void RecordEvent(User user)
    {
        ListGoals(user);
        Console.Write("Select the goal to record an event for: Use index[] numbers only! ");
        int selectedGoalIndex = int.Parse(Console.ReadLine());

        if (selectedGoalIndex >= 0 && selectedGoalIndex < user.Goals.Count)
        {
            Goal selectedGoal = user.Goals[selectedGoalIndex];
            user.RecordEvent(selectedGoal);
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }
}