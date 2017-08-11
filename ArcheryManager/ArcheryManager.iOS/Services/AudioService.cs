using System.IO;
using Foundation;
using AVFoundation;
using Xamarin.Forms;
using ArcheryManager.iOS;
using ArcheryManager.Services;

[assembly: Dependency(typeof(AudioService))]

namespace ArcheryManager.iOS
{
    public class AudioService : IAudioPlayer
    {
        public AudioService()
        {
        }

        public void PlayAudioFile(string fileName)
        {
            string sFilePath = NSBundle.MainBundle.PathForResource(Path.GetFileNameWithoutExtension(fileName), Path.GetExtension(fileName));
            var url = NSUrl.FromString(sFilePath);
            var _player = AVAudioPlayer.FromUrl(url);
            _player.FinishedPlaying += (object sender, AVStatusEventArgs e) =>
            {
                _player = null;
            };
            _player.Play();
        }
    }
}
