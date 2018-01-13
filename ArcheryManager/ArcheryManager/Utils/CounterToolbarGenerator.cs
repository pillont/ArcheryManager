using ArcheryManager.Helpers;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Interfaces;
using ArcheryManager.Pages;
using ArcheryManager.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace ArcheryManager.Utils
{
    public class CounterToolbarGenerator : IToolbarItemsGenerator
    {
        private readonly ScoreCounter Counter;

        public ToolbarItem NewFlightButton
        {
            get
            {
                return new ToolbarItem()
                {
                    Text = AppResources.NewFlight,
                    Order = ToolbarItemOrder.Primary,
                    Command = new Command(() => AskValidation(AppResources.NewFlightQuestion, Counter.NewFlight)),
                };
            }
        }

        public IEnumerable<ToolbarItem> ToolbarItems
        {
            get
            {
                return new Collection<ToolbarItem>()
                {
                    new ToolbarItem()
                    {
                        Text = AppResources.Finish,
                        Order = ToolbarItemOrder.Primary,
                        Command = new Command(Counter.FinishShoot)
                    },

                    //NOTE : Button was remove to free place on toolbar
                    //       Use selection to remove some arrow
                    /*
                    new ToolbarItem()
                    {
                        Text = AppResources.RemoveLast,
                        Order = ToolbarItemOrder.Primary,
                        Command = new Command(Counter.RemoveLastArrow)
                    },
                    */

                    new ToolbarItem()
                    {
                        Text = AppResources.RemoveAll,
                        Order = ToolbarItemOrder.Secondary,
                        Command = new Command(() => AskValidation(AppResources.RemoveAllQuestion, Counter.ClearArrows))
                    },

                    new ToolbarItem()
                    {
                        Text = AppResources.Restart,
                        Order = ToolbarItemOrder.Secondary,
                        Command = new Command(() => AskValidation(AppResources.RestartQuestion, Counter.RestartCount))
                    },

                    new ToolbarItem()
                    {
                        Text = AppResources.Settings,
                        Order = ToolbarItemOrder.Secondary,
                        Command = new Command(OpenSettingPage)
                    },
                };
            }
        }

        public CounterToolbarGenerator(ScoreCounter counter)
        {
            Counter = counter;
        }

        private void AskValidation(string message, Action action)
        {
            var arg = new AlertArg()
            {
                Title = AppResources.Question,
                Message = message,
                Accept = AppResources.Yes,
                Cancel = AppResources.No
            };
            MessagingCenterHelper.SendToast(this, arg);

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
        }

        private void OpenSettingPage(object obj)
        {
            var page = ViewFactory.CreatePage<SettingTargetPageViewModel, SettingTargetPage>() as Page;
            MessagingCenterHelper.PushInNavigationPage(this, page);
        }
    }
}
