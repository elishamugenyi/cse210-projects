using System;
using System.Drawing;
//create a base class for shape class.
public class Shape
{
    private string _color;

    //create a constructor which accepts color and sets it
    public Shape(string color)
    {
        _color = color;
    }
     public string GetColor()//gets color
     {
        return _color;
     }
      public void SetColor(string color)//sets color
      {
            _color = color;
      }

      public virtual double GetArea()
      {
        return 0;
      }
}