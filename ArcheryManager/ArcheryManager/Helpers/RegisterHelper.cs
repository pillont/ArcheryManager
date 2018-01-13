using ArcheryManager.Controllers;
using ArcheryManager.CustomControls;
using ArcheryManager.Entities;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Pages;
using ArcheryManager.Upjv;
using ArcheryManager.Utils;
using ArcheryManager.ViewModels;
using XLabs.Forms.Mvvm;
using XLabs.Ioc;

namespace ArcheryManager.Helpers
{
    public static class RegisterHelper
    {
        public const string UpjvUri = "http://upjv-archery-api.azurewebsites.net/";

        public static void InitViewFactory(CounterManager manager)
        {
            InitResolver(manager);

            ViewFactory.Register<BackDoorPage, BackDoorPageViewModel>();
            ViewFactory.Register<TargetPage, TargetPageViewModel>();
            ViewFactory.Register<CounterButtonPage, CounterButtonPageViewModel>();
            ViewFactory.Register<CounterSelectorPage, CounterSelectorPageViewModel>();
            ViewFactory.Register<GeneralMenu, GeneralMenuViewModel>();
            ViewFactory.Register<RemarksPage, RemarksPageViewModel>();
            ViewFactory.Register<SettingTargetPage, SettingTargetPageViewModel>();
            ViewFactory.Register<Target, TargetViewModel>();
            ViewFactory.Register<ScoreList, ScoreListViewModel>();
            ViewFactory.Register<ShootSavedPage, ShootSavedPageViewModel>();
            ViewFactory.Register<LogPage, LogPageViewModel>();
            ViewFactory.Register<ScoreList, ScoreListCurrentArrowsViewModel>();
            ViewFactory.Register<ConnectedShootPage, ConnectedShootPageViewModel>();
        }

        internal static void InitRegister()
        {
            var manager = new CounterManager();
            InitViewFactory(manager);
        }

        private static void InitResolver(CounterManager manager)
        {
            var resolverContainer = new SimpleContainer();

            // GENERAL
            resolverContainer.Register(r => manager);
            resolverContainer.Register(r => manager.CurrentShoot);
            resolverContainer.Register(r => manager.Counter);
            resolverContainer.Register(r => manager.MessageManager);
            resolverContainer.Register(r => new TargetStarterController(manager));
            resolverContainer.Register<IUpjvScore>(r => new UpjvScore(UpjvUri));
            //VIEWMODELS
            resolverContainer.Register(r => new CounterSelectorPageViewModel(r.Resolve<CounterManager>(), r.Resolve<TargetStarterController>()));
            resolverContainer.Register(r => new GeneralMenuViewModel(new PageOpenerController(manager)));
            resolverContainer.Register(r => new BackDoorPageViewModel(new PageOpenerController(manager), manager.DBSaver));
            resolverContainer.Register(r => new TargetPageViewModel(r.Resolve<ScoreCounter>(), r.Resolve<CounterToolbarItemsBehavior>()));
            resolverContainer.Register(r => new CounterButtonPageViewModel(r.Resolve<CounterManager>()));
            resolverContainer.Register(r => new SettingTargetPageViewModel(r.Resolve<CounterManager>()));
            resolverContainer.Register(r => new RemarksPageViewModel(r.Resolve<CounterManager>()));
            resolverContainer.Register(r => new TargetViewModel(r.Resolve<CounterManager>()));
            resolverContainer.Register(r => new ScoreListCurrentArrowsViewModel(r.Resolve<CounterManager>()));
            resolverContainer.Register(r => new ShootSavedPageViewModel(r.Resolve<CounterManager>()));
            resolverContainer.Register(r => new CounterButtonsViewModel(r.Resolve<CountedShoot>()));
            resolverContainer.Register(r => new ConnectedShootPageViewModel(r.Resolve<CounterManager>(), r.Resolve<TargetStarterController>(), r.Resolve<IUpjvScore>()));
            //BEHAVIOR
            resolverContainer.Register(r => new CounterButtonBehavior(r.Resolve<CounterManager>()));
            resolverContainer.Register(r => new ArrowListOrderedBehavior(r.Resolve<CountedShoot>()));
            resolverContainer.Register(r => new CounterToolbarItemsBehavior(r.Resolve<CounterManager>(), r.Resolve<CounterToolbarGenerator>()));

            resolverContainer.Register(r => new CounterToolbarGenerator(r.Resolve<ScoreCounter>()));

            if (!Resolver.IsSet)
                Resolver.SetResolver(resolverContainer.GetResolver());
            else
                Resolver.ResetResolver(resolverContainer.GetResolver());
        }
    }
}
