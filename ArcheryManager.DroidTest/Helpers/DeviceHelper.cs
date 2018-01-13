using System;

namespace ArcheryManager.DroidTest.Helpers
{
    public class DeviceHelper
    {
        public static DateTime GetDeviceTime()
        {
            var now = DateTime.Now;
            string dateString = "";
            dateString = (string)TestSetting.App.Invoke("GetDeviceTime");
            now = DateTime.ParseExact(dateString, "yyyyMMddHHmmss", null);
            return now;
        }
    }
}
