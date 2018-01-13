using ArcheryManager.iOS.Services;
using ArcheryManager.Services;
using ArcheryManager.Utils;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.XamarinIOS;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqliteServiceClient))]

namespace ArcheryManager.iOS.Services
{
    public class SqliteServiceClient : ISqliteService
    {
        public SQLiteConnectionManager GetAsyncConnection()
        {
            string sqliteFilename = App.DBName;
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(folder, "..", "Library");
            string path = Path.Combine(libraryPath, sqliteFilename);
            var platform = new SQLitePlatformIOS();
            var param = new SQLiteConnectionString(path, false);
            var connection = new SQLiteAsyncConnection(() => new SQLiteConnectionWithLock(platform, param));
            return new SQLiteConnectionManager(connection);
        }
    }
}
