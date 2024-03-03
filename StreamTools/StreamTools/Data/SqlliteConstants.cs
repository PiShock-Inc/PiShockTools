namespace StreamTools.Data;
internal static class SqlLiteConstants
{
    public const string DatabaseFilename = "StreamTools.db3";

    public static string DatabasePath =>
        Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
}
