using System;
using System.Threading;

//create breathing class with attributes
public class Breathing : Message
{
    //private string _breatheout;
    //private string _breathin;
    //private string _durationinseconds;

    //a constructor
    public Breathing(int inhaleDuration, int exhaleDuration)
    {
        Console.WriteLine("Welcome to the Breathing Activity!");
        Console.WriteLine("This activity will help you relax by walking your through breathing in and out slowly.");
        Console.WriteLine("Clear your mind and focus on your breathing.");
        Console.WriteLine();

        //int inhaleDuration = GetDuration("Set up the duration for Inhaling (Up to 3 seconds:) ");
        //int exhaleDuration = GetDuration("Set up the duration for exhaling (Up to 3 seconds:) ");

        //after setting these two up for 3 seconds, user needs to breath in and out alternatively for 3 seconds each at atleast 3 intervals then it breaks or stops

        while (true)
        {
            if( PerformBreath("Breath In...", inhaleDuration))
            {
                break;
            }
            if( PerformBreath("Breath out...", exhaleDuration))
            {
                break;
            }
        }         
    }

    //add performbreath method to get intervals
    private bool PerformBreath(string message, int duration)
    {
        Console.WriteLine(message);
        int elapsedSeconds = 0;

        // Perform the breath while checking the elapsed time
        while (elapsedSeconds < 3)
        {
            DisplaySpinner(duration);
            elapsedSeconds += duration;

            // Check if 3 seconds have elapsed
            if (elapsedSeconds >= 3)
            {
                return true; // Signal to stop the activity
            }
        }

        return false; // Continue the activity
    }

    //create method for GetDuration
   /* private int GetDuration(string prompt)
    {
        int duration;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out duration) && duration >= 1 && duration <= 3)
            {
                return duration;
            }
            Console.WriteLine("Invalid input. Please enter a valid number between 1 and 3 seconds.");
        }
    }
    */
    //set spinner method, this methods needs modifying so it counts for 3 seconds for each breathing but does so for only like 2 or 3 intervals and it stops, return to the main screen and user goes to another exercise.
    private void DisplaySpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("/ ");
            Thread.Sleep(250);
            Console.Write("- ");
            Thread.Sleep(250);
            Console.Write("\\ ");
            Thread.Sleep(250);
            Console.Write("| ");
            Thread.Sleep(250);
        }

        Console.WriteLine();
    }   
    
}