using Xamarin.Forms;

namespace ArcheryManager.Interactions.Behaviors
{
    public class WaveBehavior : CustomBehavior<Label>
    {
        public const string AB = "AB";
        public const string CD = "CD";

        public bool DuelMode { get; set; }

        private bool changeWave = false;

        public void StopWave()
        {
            AssociatedObject.Text = string.Empty;
        }

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

        public void StartWave()
        {
            AssociatedObject.Text = AB;
            changeWave = false;
        }
    }
}
