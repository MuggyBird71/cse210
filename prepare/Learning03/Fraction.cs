using System;

public class Fraction
{
    private int numerator;
    private int denominator;

    // Default constructor initializes to 1/1
    public Fraction() : this(1, 1) {}

    // Constructor that accepts numerator only, denominator defaults to 1
    public Fraction(int numerator) : this(numerator, 1) {}

    // Constructor that accepts both numerator and denominator
    public Fraction(int numerator, int denominator)
    {
        this.numerator = numerator;
        this.denominator = denominator != 0 ? denominator : 1; // Prevent division by zero
    }

    // Getter and setter for numerator
    public int Numerator
    {
        get { return numerator; }
        set { numerator = value; }
    }

    // Getter and setter for denominator, prevents setting to 0
    public int Denominator
    {
        get { return denominator; }
        set { denominator = value != 0 ? value : 1; }
    }

    // Returns a string representation of the fraction
    public string GetFractionString()
    {
        return $"{numerator}/{denominator}";
    }

    // Returns the decimal representation of the fraction
    public double GetDecimalValue()
    {
        return (double)numerator / denominator;
    }
}
