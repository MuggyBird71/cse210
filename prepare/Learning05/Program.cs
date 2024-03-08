// Program.cs
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Shape> shapes = new List<Shape>
        {
            new Square("Red", 4),
            new Rectangle("Blue", 5, 7),
            new Circle("Green", 3)
        };

        foreach (var shape in shapes)
        {
            Console.WriteLine($"{shape.GetType().Name} - Color: {shape.Color}, Area: {shape.GetArea():F2}");
        }
    }
}
