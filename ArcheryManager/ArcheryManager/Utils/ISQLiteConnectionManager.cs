using System.Collections.Generic;
using System.Threading.Tasks;
using ArcheryManager.Entities;
using SQLite.Net;

namespace ArcheryManager.Utils
{
    public interface ISQLiteConnectionManager
    {
        Task<CreateTablesResult> CreateTableAsync<T>() where T : class;

        void DeleteRecursivelyAsync(BaseEntity entity);

        Task<int> DropTableAsync<T>() where T : class;

        List<T> GetAllWithChildrenRecursivelyAsync<T>() where T : class;

        void InsertOrReplaceWithChildrenRecursivelyAsync(BaseEntity entity);

        void UpdateWithChildrenAsync(BaseEntity entity);
    }
}
