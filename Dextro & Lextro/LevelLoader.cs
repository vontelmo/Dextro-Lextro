using System.IO;
using System.Text.Json;

namespace MyGame
{
    public static class LevelLoader
    {
        public static LevelData LoadLevelFromJson(string path)
        {
            string fullPath = Path.Combine("assets", "Levels", path);
            string json = File.ReadAllText(fullPath);
            return JsonSerializer.Deserialize<LevelData>(json);
        }
    }
}
