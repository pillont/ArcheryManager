using Xamarin.Forms;

namespace ArcheryManager.Interactions.Behaviors
{
    public class WaveBehavior : CustomBehavior<Label>
    {
        public const string AB = "AB";
        public const string CD = "CD";

        private bool changeWave = false;
        public bool DuelMode { get; set; }

        public void NextWave()
        {
            if (DuelMode)
            {
                changeWave = true;
            }
            else
            {
                changeWave = !changeWave;
            }

            if (changeWave)
            {
                changeWaveText();
            }
        }

        public void StartWave()
        {
            AssociatedObject.Text = AB;
            changeWave = false;
        }

        public void StopWave()
        {
            AssociatedObject.Text = string.Empty;
        }

        private void changeWaveText()
        {
            if (!string.IsNullOrWhiteSpace(AssociatedObject.Text))
            {
                AssociatedObject.Text =
                    (AssociatedObject.Text == AB) ?
                                                CD :
                                                    AB;
            }
        }
    }
}
