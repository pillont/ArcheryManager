using ArcheryManager.Entities;
using ArcheryManager.Factories;
using ArcheryManager.Helpers;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Pages.PagesTemplates;
using ArcheryManager.Utils;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace ArcheryManager.Controllers
{
    public class TargetStarterController
    {
        private readonly CounterManager CounterManager;

        private CountedShoot Shoot => CounterManager.CurrentShoot;

        public TargetStarterController(CounterManager manager)
        {
            CounterManager = manager;
        }

        public Page CreateMultiTargetPage(Dictionary<string, CountedShoot> res)
        {
            try
            {
                if (res.Count < 1)
                    return null;

                if (res.Count == 1)
                {
                    var first = res.First();

                    CounterManager.CurrentShoot = first.Value;
                    CounterManager.Counter.NewFlight();

                    return CreateSimpleCounter(first.Key, first.Value);
                }

                CounterManager.CurrentShoot = res.First().Value;
                var page = new TabbedPageWithGeneralEvent();

                foreach (var pair in res)
                {
                    var target = CreateSimpleCounter(pair.Key, pair.Value);
                    pair.Value.CreateNewFlight();
                    page.Children.Add(target);
                }

                return page;
            }
            catch (System.Exception e)
            {
                throw;
            }
        }

        public Page CreatePage()
        {
            Page page = null;
            page = CounterPageFactory.CreateTabbedCounter(Shoot);

            return page;
        }

        public virtual void StartPage()
        {
            StartShoot();
            SaveCounterInDB();
            ChangePage();
        }

        private static ContentPageWithGeneralEvent CreateSimpleCounter(string name, CountedShoot shoot)
        {
            var target = CounterPageFactory.CreateSimpleCounter(shoot);
            target.Title = name;
            return target;
        }

        private void ChangePage()
        {
            var page = CreatePage();
            MessagingCenterHelper.PopToRootAndPushPage(this, page);
        }

        private void SaveCounterInDB()
        {
            var saver = CounterManager.DBSaver;
            saver.InsertOrReplaceWithChildrenRecursivelyAsync(CounterManager.CurrentShoot);
        }

        private void StartShoot()
        {
            CounterManager.Counter.NewFlight();
        }
    }
}
