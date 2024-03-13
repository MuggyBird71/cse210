using System;
using System.Collections.Generic;

namespace GoalTrackingApplication
{
    class Program
    {
        static void Main(string[] args)
        {
           StorageManager storageManager = new StorageManager();
        // Assuming LoadData returns the necessary data to initialize these objects
        var (goals, user) = storageManager.LoadData();
        
        GoalManager goalManager = new GoalManager(goals);
        UIManager uiManager = new UIManager(goalManager, user, storageManager);

        bool exitRequested = false;
        while (!exitRequested)
        {
            uiManager.DisplayMainMenu();
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    uiManager.InputGoalDetails();
                    break;
                case "2":
                    uiManager.CompleteGoal();
                    break;
                case "3":
                    uiManager.DisplayGoals();
                    break;
                case "4":
                    uiManager.ShowAchievements();
                    break;
                case "5":
                    exitRequested = true;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }

        // Save the state before exiting
        storageManager.SaveData(goalManager.Goals, user);
        Console.WriteLine("Progress saved. Exiting application...");
        }
    }

    // Placeholder for StorageManager
    public class StorageManager
    {
        public void SaveData(List<GoalBase> goals, User user)
        {
            // Implement saving logic here
        }

        public (List<GoalBase>, User) LoadData()
        {
            // Implement loading logic here
            // Return dummy data for demonstration
            return (new List<GoalBase>(), new User("John Doe"));
        }
    }

    // Implement other classes (GoalBase, GoalManager, User, UIManager) here or in separate files
}
