using System;
using System.Collections.Generic;

namespace GoalTrackingApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize StorageManager and load existing data
            StorageManager storageManager = new StorageManager();
            var (loadedGoals, loadedUser) = storageManager.LoadData();

            GoalManager goalManager = new GoalManager(loadedGoals);
            User user = loadedUser ?? new User("Default User");
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
            // Before exiting, when saving the state
            storageManager.SaveData(new List<GoalBase>(goalManager.Goals), user);
            Console.WriteLine("Progress saved. Exiting application...");
        }
    }
}
