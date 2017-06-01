using Xamarin.Forms;
using static ArcheryManager.Utils.TargetScoreCounter;

namespace ArcheryManager.Utils
{
    public class Arrow : ContentView
    {
        public readonly Score score;

        public Arrow(View visual, Score score)
        {
            this.Content = visual;
            this.score = score;
        }
    }
}
