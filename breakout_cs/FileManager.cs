using System.IO;

public static class FileManager
{
    private static string path = "highscore.txt";

    public static int LoadHighScore()
    {
        if (!File.Exists(path)) return 0;
        return int.TryParse(File.ReadAllText(path), out int score) ? score : 0;
    }

    public static void SaveHighScore(int score)
    {
        File.WriteAllText(path, score.ToString());
    }
}
