using ArcheryManager.CustomControls;
using ArcheryManager.Entities;
using ArcheryManager.Factories;
using ArcheryManager.Helpers;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.UnitTest.TestSettings;
using ArcheryManager.Utils;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace ArcheryManager.UnitTest.Interactions.Behaviors
{
    [TestFixture]
    public class SelectableArrowInListBehaviorTest
    {
        private Arrow a1;
        private Arrow a2;
        private Arrow a3;
        private Arrow a4;
        private SelectableArrowInListBehavior behavior;
        private List<ToolbarItem> list;
        private CounterManager Manager;
        private ArrowUniformGrid scorelist;

        [SetUp]
        public void Init()
        {
            Manager = new CounterManager() { CurrentShoot = new CountedShoot() };
            RegisterHelperTest.InitTestRegister(Manager);

            list = new List<ToolbarItem>();
            MessagingCenterHelper.Instance.AddedToolbarItem += (s, e) => list.Add(e.ToolbarItem);
            MessagingCenterHelper.Instance.RemovedToolbarItem += (s, e) => list.Remove(e.ToolbarItem);
            MessagingCenterHelper.Instance.ClearedToolbarItem += (s, e) => list.Clear();

            Manager.Counter.NewFlight();
            scorelist = ScoreListFactory.CreateScoreList();

            a1 = new Arrow() { Index = 1 };
            a2 = new Arrow() { Index = 2 };
            a3 = new Arrow() { Index = 3 };
            a4 = new Arrow() { Index = 4 };
            Manager.Counter.AddArrowIfPossible(a1);
            Manager.Counter.AddArrowIfPossible(a2);
            Manager.Counter.AddArrowIfPossible(a3);
            Manager.Counter.AddArrowIfPossible(a4);

            behavior = scorelist.Behaviors.OfType<SelectableArrowInListBehavior>().First();
        }

        [Test]
        public void SelectAndRemoveTest()
        {
            //select
            behavior.ArrowRecognizer_Tapped(scorelist.Children[0], null);
            behavior.ArrowRecognizer_Tapped(scorelist.Children[2], null);

            // remove
            list[1].Command.Execute(null);

            Assert.IsFalse(scorelist.Items.Contains(a1));
            Assert.IsTrue(scorelist.Items.Contains(a2));
            Assert.IsFalse(scorelist.Items.Contains(a3));
        }

        [Test]
        public void SelectAndResetTest()
        {
            behavior.ArrowRecognizer_Tapped(scorelist.Children[0], null);
            behavior.ArrowRecognizer_Tapped(scorelist.Children[1], null);
            behavior.ArrowRecognizer_Tapped(scorelist.Children[2], null);

            // reset selection
            list[0].Command.Execute(null);

            Assert.IsFalse(a1.IsSelected);
            Assert.IsFalse(a2.IsSelected);
            Assert.IsFalse(a3.IsSelected);
        }

        [Test]
        public void SelectAndUnselectTest()
        {
            //select
            behavior.ArrowRecognizer_Tapped(scorelist.Children[0], null);
            behavior.ArrowRecognizer_Tapped(scorelist.Children[1], null);
            behavior.ArrowRecognizer_Tapped(scorelist.Children[2], null);

            //unselect
            behavior.ArrowRecognizer_Tapped(scorelist.Children[0], null);
            behavior.ArrowRecognizer_Tapped(scorelist.Children[1], null);
            behavior.ArrowRecognizer_Tapped(scorelist.Children[2], null);

            Assert.IsFalse(a1.IsSelected);
            Assert.IsFalse(a2.IsSelected);
            Assert.IsFalse(a3.IsSelected);
        }

        [Test]
        public void SelectTest()
        {
            behavior.ArrowRecognizer_Tapped(scorelist.Children[0], null);
            behavior.ArrowRecognizer_Tapped(scorelist.Children[1], null);
            behavior.ArrowRecognizer_Tapped(scorelist.Children[2], null);

            Assert.IsTrue(a1.IsSelected);
            Assert.IsTrue(a2.IsSelected);
            Assert.IsTrue(a3.IsSelected);
        }
    }
}
