using System;
using System.Collections.Generic;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        // Main program loop structure goes here
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.\n");
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            // Just lists names for selection when recording an event
            Console.WriteLine($"{i + 1}. {_goals[i].GetStringRepresentation().Split(':')[1].Split(',')[0]}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        // Menu selection to create Simple, Eternal, or Checklist goals
    }

    public void RecordEvent()
    {
        // Select a goal and call its RecordEvent method
    }

    public void SaveGoals()
    {
        // Save score and _goals list to a text file using GetStringRepresentation()
    }

    public void LoadGoals()
    {
        // Parse a text file to rebuild the score and _goals list
    }
}