namespace StructuralPatterns.Adapter;

// Modern interface that our game expects
public interface ICloudStorage
{
    void SaveToCloud(string playerName, int score);
    string LoadFromCloud(string playerName);
}

// Legacy system with incompatible interface
public class LegacyFileStorage
{
    public void WriteToFile(string filename, string data)
    {
        Console.WriteLine($"  [Legacy] Writing to file: {filename}");
        Console.WriteLine($"  [Legacy] Data: {data}");
    }

    public string ReadFromFile(string filename)
    {
        Console.WriteLine($"  [Legacy] Reading from file: {filename}");
        return "PlayerData: Score=1000"; // Simulated file content
    }
}
