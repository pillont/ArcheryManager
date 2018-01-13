using ArcheryManager.Droid.Services;
using ArcheryManager.Services;
using ArcheryManager.Utils;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.XamarinAndroid;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqliteServiceClient))]

namespace ArcheryManager.Droid.Services
{
    public class SqliteServiceClient : ISqliteService
    {
        public SQLiteConnectionManager GetAsyncConnection()
        {
            const string sqliteFilename = App.DBName;
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            var path = Path.Combine(documentsPath, sqliteFilename);

            var platform = new SQLitePlatformAndroid();

            var connectionWithLock = new SQLiteConnectionWithLock(
            platform,
            new SQLiteConnectionString(path, true));

            var connection = new SQLiteAsyncConnection(() => connectionWithLock);

            return new SQLiteConnectionManager(connection);
        }
    }
}
