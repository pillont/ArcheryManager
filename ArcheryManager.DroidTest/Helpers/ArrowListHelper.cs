using System.Linq;
using Xamarin.UITest.Queries;

namespace ArcheryManager.DroidTest.Helpers
{
    public static class ArrowListHelper
    {
        public static AppResult ArrowInList(int index)
        {
            double width = TestSetting.App.Query(e => e.Marked("scoreList")).First().Rect.Width;
            int childCount = TestSetting.App.Query(e => e.Marked("scoreList").Child()).Count();
            double cellWidth = width / childCount;
            for (int i = 0; i < childCount; i++)
            {
                var child = TestSetting.App.Query(e => e.Marked("scoreList").Child(i).Child(1).Child(0)).First();
                int position = (int)(child.Rect.CenterX / cellWidth);
                if (position == index)
                {
                    return child;
                }
            }
            return null;
        }

        public static int IndexInList(int index)
        {
            double width = TestSetting.App.Query(e => e.Marked("scoreList")).First().Rect.Width;
            int childCount = TestSetting.App.Query(e => e.Marked("scoreList").Child()).Count();
            double cellWidth = width / childCount;
            for (int i = 0; i < childCount; i++)
            {
                var child = TestSetting.App.Query(e => e.Marked("scoreList").Child(i).Child(1).Child(0)).First();
                int position = (int)(child.Rect.CenterX / cellWidth);
                if (position == index)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
