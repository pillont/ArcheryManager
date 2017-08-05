using ArcheryManager.CustomControls;
using ArcheryManager.Factories;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Models;
using ArcheryManager.Settings;
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
        private GeneralCounterSetting generalCounterSetting;
        private List<ToolbarItem> list;
        private ArrowUniformGrid scorelist;
        private Arrow a4;
        private Arrow a3;
        private Arrow a2;
        private Arrow a1;
        private SelectableArrowInListBehavior behavior;

        [SetUp]
        public void Init()
        {
            Xamarin.Forms.Mocks.MockForms.Init();
            list = new List<ToolbarItem>();
            generalCounterSetting = new GeneralCounterSetting();
            scorelist = ScoreListFactory.Create(generalCounterSetting, list);

            a1 = new Arrow(1, 0);
            a2 = new Arrow(2, 0);
            a3 = new Arrow(3, 0);
            a4 = new Arrow(4, 0);
            scorelist.Items.Add(a1);
            scorelist.Items.Add(a2);
            scorelist.Items.Add(a3);
            scorelist.Items.Add(a4);

            behavior = scorelist.Behaviors.OfType<SelectableArrowInListBehavior>().First();
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
    }
}
