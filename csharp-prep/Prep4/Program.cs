using System;

class Program
{
    static void Main(string[] args)
    {
        //started by creating the list
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a Number, Type 0 when finished!");

        //used a while loop to capture entries and stop once the user enters 0
        while (true)
        {
            Console.WriteLine("Enter Number:");
            int num = int.Parse(Console.ReadLine());

            if (num == 0)
            {
                break;
            }
            numbers.Add(num);
        }   
        //used a for each loop to get the numbers entered and 
        //calculate sum, average and find the largest 
        Console.WriteLine("Numbers You Entered:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }    
        //finding sum of numbers
        int sum = numbers.Sum();
        Console.WriteLine("Sum is:" +sum);

        //finding the average
        double average = numbers.Average();
        Console.WriteLine("Average of the List:" +average);

        //finding the largest number
        int max = numbers.Max();
        Console.WriteLine("Largest number:"+max);

    }
}