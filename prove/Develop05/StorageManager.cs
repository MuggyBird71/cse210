using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

public class StorageManager
{
    private const string FilePath = "goalTrackingData.json";

    public void SaveData(List<GoalBase> goals, User user)
    {
        var data = new
        {
            Goals = goals,
            User = user
        };
        string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
        File.WriteAllText(FilePath, jsonData);
    }

    public (List<GoalBase>, User) LoadData()
    {
        if (!File.Exists(FilePath))
        {
            return (new List<GoalBase>(), new User("Default User"));
        }

        string jsonData = File.ReadAllText(FilePath);
        var data = JsonConvert.DeserializeObject<(List<GoalBase>, User)>(jsonData);
        return data;
    }
}
