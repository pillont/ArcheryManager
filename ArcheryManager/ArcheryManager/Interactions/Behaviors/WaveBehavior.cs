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
            associatedObject.Text = string.Empty;
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
            if (!string.IsNullOrWhiteSpace(associatedObject.Text))
            {
                associatedObject.Text =
                    (associatedObject.Text == AB) ?
                                                CD :
                                                    AB;
            }
        }

        public void StartWave()
        {
            associatedObject.Text = AB;
            changeWave = false;
        }
    }
}
