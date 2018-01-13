using ArcheryManager.Services;
using System;
using Xamarin.Forms;

namespace ArcheryManager.Helpers
{
    public class LoggerHelper
    {
        private const string DateFormat = "MM/dd/yyyy HH:mm";
        private const string LogFileName = "ArcheryManagerLog";

        public static string ReadLog()
        {
            var writer = DependencyService.Get<IFileManager>();
            string res = writer.LoadText(LogFileName);
            return res;
        }

        public static void WriteError(Exception e)
        {
            string date = DateTime.Now.ToString(DateFormat);
            string message = e.Message;
            string stackTrace = e.StackTrace;

            var writer = DependencyService.Get<IFileManager>();

            writer.SaveText(LogFileName, date + " - " + message);
            writer.SaveText(LogFileName, stackTrace);
            writer.SaveText(LogFileName, "");
        }
    }
}
