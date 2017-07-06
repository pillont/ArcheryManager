using System;
using Xamarin.Forms;

namespace ArcheryManager.CustomControls
{
    public class WaveControl : Label
    {
        private const string AB = "AB";
        private const string CD = "CD";

        private bool changeWave = false;

        public void StopWave()
        {
            this.Text = string.Empty;
        }

        public void NextWave()
        {
            changeWave = !changeWave;

            if (changeWave)
            {
                changeWaveText();
            }
        }

        private void changeWaveText()
        {
            if (!string.IsNullOrWhiteSpace(Text))
            {
                Text =
                    (Text == AB) ?
                                CD :
                                    AB;
            }
        }

        public void StartWave()
        {
            this.Text = AB;
            changeWave = false;
        }
    }
}
