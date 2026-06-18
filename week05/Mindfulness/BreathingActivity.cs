public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public void StartBreathingActivity()
    {
        DisplayStartingMessage();
        Console.WriteLine("Breathe in...");
        ShowCountDown(4);
        Console.WriteLine("Breathe out...");
        ShowCountDown(6);
        DisplayEndingMessage();
    }
}