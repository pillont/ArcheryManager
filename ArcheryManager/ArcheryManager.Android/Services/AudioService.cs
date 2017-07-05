using Android.Media;
using ArcheryManager.Droid.Services;
using ArcheryManager.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(AudioService))]

namespace ArcheryManager.Droid.Services
{
    public class AudioService : IAudioPlayer
    {
        public AudioService()
        {
        }

        public void PlayAudioFile(string fileName)
        {
            var player = new MediaPlayer();
            var fd = global::Android.App.Application.Context.Assets.OpenFd(fileName);
            player.Prepared += (s, e) =>
            {
                player.Start();
            };
            player.SetDataSource(fd.FileDescriptor, fd.StartOffset, fd.Length);
            player.Prepare();
        }
    }
}
