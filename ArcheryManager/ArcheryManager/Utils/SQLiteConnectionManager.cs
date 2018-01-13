using ArcheryManager.Entities;
using SQLite.Net;
using SQLite.Net.Async;
using SQLiteNetExtensionsAsync.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArcheryManager.Utils
{
    public class SQLiteConnectionManager : ISQLiteConnectionManager
    {
        private readonly SQLiteAsyncConnection Connection;

        public SQLiteConnectionManager(SQLiteAsyncConnection connection)
        {
            Connection = connection;
        }

        public async Task<CreateTablesResult> CreateTableAsync<T>() where T : class
        {
            return await Connection.CreateTableAsync<T>();
        }

        public async void DeleteRecursivelyAsync(BaseEntity entity)
        {
            await Connection.DeleteAsync(entity, recursive: true);
        }

        public async Task<int> DropTableAsync<T>() where T : class
        {
            return await Connection.DropTableAsync<T>();
        }

        public virtual List<T> GetAllWithChildrenRecursivelyAsync<T>() where T : class
        {
            return Connection.GetAllWithChildrenAsync<T>(recursive: true).Result;
        }

        public async void InsertOrReplaceWithChildrenRecursivelyAsync(BaseEntity entity)
        {
            await Connection.InsertOrReplaceWithChildrenAsync(entity, recursive: true);
        }

        public async void UpdateWithChildrenAsync(BaseEntity entity)
        {
            await Connection.UpdateWithChildrenAsync(entity);
        }
    }
}
