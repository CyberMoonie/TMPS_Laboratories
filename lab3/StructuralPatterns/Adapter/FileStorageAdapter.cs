namespace StructuralPatterns.Adapter;

// Adapter that makes legacy system work with modern interface
public class FileStorageAdapter : ICloudStorage
{
    private readonly LegacyFileStorage _legacyStorage;

    public FileStorageAdapter(LegacyFileStorage legacyStorage)
    {
        _legacyStorage = legacyStorage;
    }

    public void SaveToCloud(string playerName, int score)
    {
        Console.WriteLine("[Adapter] Converting cloud save request to file operation...");
        
        // Adapt the interface: convert parameters to legacy format
        string filename = $"{playerName}.dat";
        string data = $"PlayerData: Score={score}";
        
        _legacyStorage.WriteToFile(filename, data);
        Console.WriteLine("[Adapter] Save completed!\n");
    }

    public string LoadFromCloud(string playerName)
    {
        Console.WriteLine("[Adapter] Converting cloud load request to file operation...");
        
        // Adapt the interface: convert parameters to legacy format
        string filename = $"{playerName}.dat";
        string fileContent = _legacyStorage.ReadFromFile(filename);
        
        // Parse the legacy format and return it
        Console.WriteLine("[Adapter] Load completed!\n");
        return fileContent;
    }
}
