using System;

class Program
{
    static void Main(string[] args)
    {
        // Creating fractions using different constructors
        Fraction fraction1 = new Fraction();
        Fraction fraction2 = new Fraction(6);
        Fraction fraction3 = new Fraction(6, 7);

        // Demonstrating the use of getters and setters
        fraction3.Numerator = 3;
        fraction3.Denominator = 4;

        // Displaying the fractional and decimal representations
        Console.WriteLine(fraction1.GetFractionString()); // 1/1
        Console.WriteLine(fraction2.GetFractionString()); // 6/1
        Console.WriteLine(fraction3.GetFractionString()); // 3/4
        Console.WriteLine(fraction3.GetDecimalValue());   // 0.75

        // Another example
        Fraction fraction4 = new Fraction(1, 3);
        Console.WriteLine(fraction4.GetFractionString()); // 1/3
        Console.WriteLine(fraction4.GetDecimalValue());   // Approximately 0.3333
    }
}
