using System;
using System.Collections.Generic;
using System.IO;

//create fraction class with two attribute that are private
public class Fraction
{
    private int _top;
    private int _bottom;

    //create constructors
    public Fraction()//Has no arguments and initializes the top and bottom to 1
    {
        _top = 1;
        _bottom = 1;
    }
    public Fraction(int wholeNumber)//has one argument, the wholeNumber, initializes the top to the wholeNumber and bottom to 1.
    {
        _top = wholeNumber;
        _bottom = 1;
    }
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    //create methods to display string
    public string GetFractionString()
    {
        string text = $"{_top}/{_bottom}";
        return text;
    }

    //create the get decimal value method
    public double GetDecimalValue()
    {
        return (double)_top/ (double)_bottom;
    }

}