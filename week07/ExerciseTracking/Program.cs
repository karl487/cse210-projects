using System;
using System.Collections.Generic;

// Base Activity Class
public abstract class Activity
{
    private string _date;
    private int _minutes;

    public Activity(string date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public string GetDate() => _date;
    public int GetMinutes() => _minutes;

    // Abstract or virtual methods to be overridden in derived classes
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // Base GetSummary method
    public virtual string GetSummary()
    {
        return $"{_date} {GetType().Name} ({_minutes} min): " +
               $"Distance: {GetDistance():0.0} miles, " +
               $"Speed: {GetSpeed():0.0} mph, " +
               $"Pace: {GetPace():0.0} min per mile";
    }
}

// Running Class
public class Running : Activity
{
    private double _distance;

    public Running(string date, int minutes, double distance) : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;

    // Speed (mph) = (distance / minutes) * 60
    public override double GetSpeed() => (_distance / GetMinutes()) * 60;

    // Pace (min per mile) = minutes / distance
    public override double GetPace() => GetMinutes() / _distance;
}

// Stationary Bicycles Class
public class Cycling : Activity
{
    private double _speed;

    public Cycling(string date, int minutes, double speed) : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance() => (_speed / 60) * GetMinutes();
    public override double GetSpeed() => _speed;

    // Pace (min per mile) = 60 / speed
    public override double GetPace() => 60 / _speed;
}

// Lap Pool Swimming Class
public class Swimming : Activity
{
    private int _laps;

    public Swimming(string date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    // Distance (miles) = swimming laps * 50 / 1000 * 0.62
    public override double GetDistance() => _laps * 50 / 1000.0 * 0.62;

    // Speed (mph) = (distance / minutes) * 60
    public override double GetSpeed() => (GetDistance() / GetMinutes()) * 60;

    // Pace (min per mile) = minutes / distance
    public override double GetPace() => GetMinutes() / GetDistance();
}

// Main Program
class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>();

        // Create, set, and add one of each activity
        activities.Add(new Running("03 Nov 2022", 30, 3.0));
        activities.Add(new Cycling("04 Nov 2022", 45, 15.0));
        activities.Add(new Swimming("05 Nov 2022", 40, 20));

        // Iterate through the polymorphic list
        foreach (Activity act in activities)
        {
            Console.WriteLine(act.GetSummary());
        }
    }
}