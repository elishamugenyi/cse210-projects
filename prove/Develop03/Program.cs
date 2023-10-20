using System;
using System.ComponentModel;
using System.Reflection.PortableExecutable;


class Program
{ 
    static void Main(String[] args)
    {
               
        Console.WriteLine("Your scripture of the day is");

        //create instance for reference class.
        Reference refer1 = new Reference();
       

        //create an instance for Scripture class to call methods in that class here
        Scripture scripture = new Scripture();

        refer1.GetReference();
        scripture.DisplayScripture(); 
        scripture.RemoveWords();

        //Reference refer = new Reference();
        //Console.WriteLine($"Book is {refer.GetReference()}");

        


    }
}
