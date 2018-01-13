using ArcheryManager.Entities;
using ArcheryManager.Helpers;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Resources;
using System;
using System.Linq;

namespace ArcheryManager.Utils
{
    public class MessageManager
    {
        private readonly CountedShoot Shoot;

        public MessageManager(CountedShoot shoot)
        {
            Shoot = shoot;
        }

        public void AddArrowOrShowError(Action addArrow, Action cancel = null)
        {
            bool noSelection = Shoot.CurrentArrows.All(a => !a.IsSelected);
            bool notInTheMaxOfArrow = ((!Shoot.HaveMaxArrowsCount)
                                        || Shoot.CurrentArrows.Count < Shoot.ArrowsCount);
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

        /// <summary>
        /// send alert to ask question
        /// if the answer is yes, this action is done
        /// </summary>
        /// <param name="message">message on the alert</param>
        /// <param name="action">action if awser is yes</param>
        public void AskForDone(string message, Action action)
        {
            var arg = new AlertArg()
            {
                Title = AppResources.Question,
                Message = message,
                Accept = AppResources.Yes,
                Cancel = AppResources.No
            };

            EventHandler<bool> e = null;
            e = (sender, valid) =>
            {
                arg.ResultChange -= e;

                if (valid)
                {
                    action?.Invoke();
                }
            };
            arg.ResultChange += e;

            MessagingCenterHelper.SendToast(this, arg);
        }

        private void SendToast(string message)
        {
            MessagingCenterHelper.SendToast(this, ErrorResources.Error, message, AppResources.OK);
        }
    }
}
