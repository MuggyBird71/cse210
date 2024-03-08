// Program.cs
using System;

class Program
{
    static void Main()
    {
        var simpleAssignment = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(simpleAssignment.GetSummary());

        var mathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions");
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());

        var writingAssignment = new WritingAssignment("Mary Waters", "European History");
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());
    }
}
