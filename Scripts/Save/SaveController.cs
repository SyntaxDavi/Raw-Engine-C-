using System.Text.Json;
using System.IO;
using System.Numerics;

// Classe simples para estruturar os dados que queremos salvar
public class SaveData
{
    public float PlayerX { get; set; }
    public float PlayerY { get; set; }
    // public List<string> Inventory { get; set; }
    // public int CurrentLevel { get; set; }
}

public class SaveController
{
    private string _saveFileName = "savegame.json";

    public void SaveGame(PlayerController player)
    {
        SaveData data = new SaveData
        {
            PlayerX = player.Position.X,
            PlayerY = player.Position.Y
        };

        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(data, options);
        
        File.WriteAllText(_saveFileName, jsonString);
        System.Console.WriteLine("Jogo salvo com sucesso em: " + _saveFileName);
    }

    public SaveData? LoadGame()
    {
        if (!File.Exists(_saveFileName))
        {
            System.Console.WriteLine("Arquivo de save não encontrado.");
            return null;
        }

        string jsonString = File.ReadAllText(_saveFileName);
        SaveData? data = JsonSerializer.Deserialize<SaveData>(jsonString);
        
        System.Console.WriteLine("Jogo carregado com sucesso!");
        return data;
    }
}