using System;
using System.IO;
using ArcheryManager.Services;
using ArcheryManager.iOS.Services;
using Xamarin.Forms;
using System.Collections.Generic;

[assembly: Dependency(typeof(FileManager))]

namespace ArcheryManager.iOS.Services
{
    public class FileManager : IFileManager
    {
        public string LoadText(string filename)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
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
