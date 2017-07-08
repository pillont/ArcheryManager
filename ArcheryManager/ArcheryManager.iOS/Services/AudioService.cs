using ArcheryManager.Services;
using System.IO;
using Foundation;
using AVFoundation;
using ArcheryManager.iOS.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(AudioService))]

namespace ArcheryManager.iOS.Services
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
