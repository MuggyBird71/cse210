using System.Collections.Generic;

public class GoalManager
{
    private List<GoalBase> _goals;

    // Constructor that accepts an initial list of goals
    public GoalManager(List<GoalBase> goals)
    {
        _goals = goals ?? new List<GoalBase>();
    }

    // Read-only property exposing the list of goals
    public IReadOnlyList<GoalBase> Goals => _goals.AsReadOnly();

    public void AddGoal(GoalBase goal)
    {
        _goals.Add(goal);
    }

    public void CompleteGoal(string title)
    {
        var goal = _goals.Find(g => g.Title == title);
        goal?.MarkComplete();
    }

    public void DisplayGoals()
    {
        foreach (var goal in _goals)
        {
            goal.DisplayInfo();
        }
    }
}
