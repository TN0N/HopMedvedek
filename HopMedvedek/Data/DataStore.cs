using System.IO;

namespace HopMedvedek.Data;

/// <summary>
/// Small indirection over the JSON persistence files (player data, options, shop).
///
/// On desktop this is a straight pass-through to <see cref="File"/> using the same
/// relative paths as before, so behaviour is unchanged.
///
/// On Android / iOS the app cannot write next to its installed assets, so writes
/// are redirected to app-private storage and reads fall back to the read-only
/// copy bundled in the app (assets/ on Android, the .app bundle on iOS) the first
/// time the game runs.
/// </summary>
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
