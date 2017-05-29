using Xamarin.Forms;

namespace ArcheryManager.Interfaces
{
    public interface ITimer
    {
        Color BorderColor { get; set; }
        Color Color { get; set; }
        bool IsPaused { get; set; }
        bool IsStopped { get; set; }
        bool IsWaitingTime { get; set; }
        int LimitTime { get; set; }
        int Progress { get; set; }
        string Text { get; set; }
        int Time { get; set; }
        Color WaitingColor { get; set; }
        int WaitingTime { get; set; }
        int MaxProgress { get; }
    }
}
