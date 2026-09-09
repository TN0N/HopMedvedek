using System.IO;

namespace HopMedvedek.Data;

public static class DataStore
{
#if ANDROID || IOS
    private static string WritableRoot =>
        System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);

    public static string ReadText(string relativePath)
    {
        string local = Path.Combine(WritableRoot, relativePath);
        if (File.Exists(local))
            return File.ReadAllText(local);

        // First run: read the default shipped inside the app.
        using Stream stream = Microsoft.Xna.Framework.TitleContainer.OpenStream(relativePath);
        using StreamReader reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }

    public static void WriteText(string relativePath, string contents)
    {
        string local = Path.Combine(WritableRoot, relativePath);
        string dir = Path.GetDirectoryName(local);
        if (!string.IsNullOrEmpty(dir))
            Directory.CreateDirectory(dir);
        File.WriteAllText(local, contents);
    }
#else
    public static string ReadText(string relativePath) => File.ReadAllText(relativePath);

    public static void WriteText(string relativePath, string contents) => File.WriteAllText(relativePath, contents);
#endif
}
