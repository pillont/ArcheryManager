namespace ArcheryManager.Services
{
    public interface IFileManager
    {
        string LoadText(string filename);

        void SaveText(string filename, string text);
    }
}
