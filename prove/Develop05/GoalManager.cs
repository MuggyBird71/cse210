using System.Collections.Generic;
using System.Linq;

public class GoalManager
{
    private readonly List<GoalBase> _goals;

    // Constructor initializing with an empty list or a provided list of goals
    public GoalManager(List<GoalBase> goals = null)
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
        var goal = _goals.FirstOrDefault(g => g.Title == title);
        if (goal != null)
        {
            goal.MarkComplete();
        }
    }

    public void DisplayGoals()
    {
        foreach (var goal in _goals)
        {
            goal.DisplayInfo();
        }
    }
}
