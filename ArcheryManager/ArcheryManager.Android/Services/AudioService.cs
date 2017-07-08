using Android.Media;
using ArcheryManager.Droid.Services;
using ArcheryManager.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(AudioService))]

namespace ArcheryManager.Droid.Services
{
    public class AudioService : IAudioPlayer
    {
        protected static readonly MediaPlayer Player;

        static AudioService()
        {
            Player = new MediaPlayer();
        }

        public void PlayAudioFile(string fileName)
        {
            Player.Reset();
            var fd = global::Android.App.Application.Context.Assets.OpenFd(fileName);
            Player.SetDataSource(fd.FileDescriptor, fd.StartOffset, fd.Length);
            Player.Prepare();
            Player.Start();
        }
    }
}
