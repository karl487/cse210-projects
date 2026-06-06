using System;
public class Program
{
    public static void Main()
    {
        Fraction fraction1 = new Fraction();
        Console.WriteLine($"The fraction is: {fraction1.GetFractionString()}");
        Console.WriteLine($"The decimal value is: {fraction1.GetDecimalValue()}");

        Fraction fraction2 = new Fraction(5);
        Console.WriteLine($"The fraction is: {fraction2.GetFractionString()}");
        Console.WriteLine($"The decimal value is: {fraction2.GetDecimalValue()}");

        Fraction fraction3 = new Fraction(3, 4);
        Console.WriteLine($"The fraction is: {fraction3.GetFractionString()}");
        Console.WriteLine($"The decimal value is: {fraction3.GetDecimalValue()}");
    }
}