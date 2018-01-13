using ArcheryManager.Utils;

namespace ArcheryManager.Services
{
    public interface ISqliteService
    {
        SQLiteConnectionManager GetAsyncConnection();
    }
}
