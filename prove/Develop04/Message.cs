using System;

//create base class Message for all classes for this assignment.
public class Message
{
    //create attributes and make them private.
    private string _username;

    //create constructor with no arguments for this class
    public Message()
    {
        //set the welcome message
        Console.WriteLine("Whats your name?");
        _username = Console.ReadLine();
        Console.WriteLine($"Welcome {_username}");

        //add a welcome message here to show
    }

    //method for end message on all screens.
    public void EndMessage()
    {
        Console.WriteLine("Thank you for Participating! Kuddos to you.");
    }
}