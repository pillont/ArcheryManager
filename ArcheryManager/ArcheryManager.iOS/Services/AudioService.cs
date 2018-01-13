using ArcheryManager.iOS;
using ArcheryManager.Services;
using AVFoundation;
using Foundation;
using System.IO;
using Xamarin.Forms;

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
