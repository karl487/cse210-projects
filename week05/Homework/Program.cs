using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment a1 = new Assignment("John Doe", "Math");
        Console.WriteLine(a1.GetSummary());

        // Create a MathAssignment object
        MathAssignment mathAssignment = new MathAssignment("John Doe", "Algebra", "Section 5.2", "Problems 1-10");
        Console.WriteLine(mathAssignment.GetHomeworkList());
        Console.WriteLine(mathAssignment.GetHomeworkListAndSummary());

        // Create a WritingAssignment object
        WritingAssignment writingAssignment = new WritingAssignment("Jane Smith", "Essay", "The Importance of Education");
        Console.WriteLine(writingAssignment.GetWritingInformation());
    }
}