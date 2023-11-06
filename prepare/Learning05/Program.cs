using System;
using System.Collections.ObjectModel;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Areas of shapes. Start with the square!");
        
      //create list of shapes and add any shape in it.
        List<Shape> shapes = new List<Shape>();

        Square s1 = new Square("Red", 3);
        shapes.Add(s1);

        Rectangle s2 = new Rectangle("Blue", 4, 5);
        shapes.Add(s2);

        Circle s3 = new Circle("Green", 6);
        shapes.Add(s3);

        foreach (Shape s in shapes)
        {
            // Notice that all shapes have a GetColor method from the base class
            string color = s.GetColor();

            //get area method same but behavior is different
            double area = s.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}