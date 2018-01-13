using ArcheryManager.Droid.Services;
using ArcheryManager.Services;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileManager))]

namespace ArcheryManager.Droid.Services
{
    public class FileManager : IFileManager
    {
        public string LoadText(string filename)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var filePath = Path.Combine(documentsPath, filename);
            return File.ReadAllText(filePath);
        }

        public void SaveText(string filename, string text)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var filePath = Path.Combine(documentsPath, filename);
            File.AppendAllLines(filePath, new List<string>() { text });
        }
    }
}
