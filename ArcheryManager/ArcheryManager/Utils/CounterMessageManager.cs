using ArcheryManager.Resources;
using ArcheryManager.Settings;
using System;
using System.Linq;
using Xamarin.Forms;

namespace ArcheryManager.Utils
{
    public class CounterMessageManager
    {
        private readonly ScoreResult ScoreResult;
        private readonly CountSetting CountSetting;
        private readonly Page Page;

        public CounterMessageManager(ScoreResult scoreResult, CountSetting countSetting, Page page)
        {
            ScoreResult = scoreResult;
            CountSetting = countSetting;
            Page = page;
        }

        public void AddArrowOrShowError(Action addArrow, Action cancel = null)
        {
            bool noSelection = ScoreResult.CurrentArrows.All(a => !a.IsSelected);
            bool notInTheMaxOfArrow = ((!CountSetting.HaveMaxArrowsCount)
                                        || ScoreResult.CurrentArrows.Count < CountSetting.ArrowsCount);
            bool canShootNewArrow = notInTheMaxOfArrow && noSelection;

            if (canShootNewArrow)
            {
                addArrow?.Invoke();
            }
            else
            {
                cancel?.Invoke();
                if (!noSelection)
                {
                    SendToast(ErrorResources.NoAddingDuringSelection);
                }
                else if (!notInTheMaxOfArrow)
                {
                    SendToast(ErrorResources.CantAddMoreThanMaxArrow);
                }
            }
        }

        private void SendToast(string message)
        {
            Page.DisplayAlert(ErrorResources.Error, message, AppResources.OK);
        }
    }
}
