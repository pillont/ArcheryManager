using ArcheryManager.CustomControls;
using ArcheryManager.Factories;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Interfaces;
using ArcheryManager.Pages;
using ArcheryManager.Settings;
using ArcheryManager.Utils;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace ArcheryManager.UnitTest.Factories
{
    [TestFixture]
    public class ScoreListFactoryTest
    {
        private IArrowSetting setting;
        private ScoreCounter counter;
        private List<ToolbarItem> list;
        private Mock<Target> target;
        private ArrowUniformGrid scorelist;
        private Arrow a4;
        private Arrow a3;
        private Arrow a2;
        private Arrow a1;
        private IList<ToolbarItem> toolbarItems;
        private Setting countSetting;

        [SetUp]
        public void Init()
        {
            Xamarin.Forms.Mocks.MockForms.Init();
            toolbarItems = new List<ToolbarItem>();
            setting = EnglishArrowSetting.Instance;
            list = new List<ToolbarItem>();

            countSetting = new Setting();
            counter = new ScoreCounter(new TargetSetting(countSetting), toolbarItems, setting);

            target = new Mock<Target>();
            scorelist = ScoreListFactory.Create(target.Object, counter, list, setting);
            a1 = new Arrow(1, 0);
            a2 = new Arrow(2, 0);
            a3 = new Arrow(3, 0);
            a4 = new Arrow(4, 0);
            scorelist.Items.Add(a1);
            scorelist.Items.Add(a2);
            scorelist.Items.Add(a3);
            scorelist.Items.Add(a4);
        }

        [Test]
        public void SelectTest()
        {
            var behavior = scorelist.Behaviors.OfType<SelectableArrowInListBehavior>().First();
            target.Setup(mock => mock.SelectArrow(It.IsAny<Arrow>()));
            target.Setup(mock => mock.ResetSelection());

            behavior.ArrowRecognizer_Tapped(scorelist.Children[0], null);
            behavior.ArrowRecognizer_Tapped(scorelist.Children[1], null);
            behavior.ArrowRecognizer_Tapped(scorelist.Children[2], null);

            target.Verify(mock => mock.SelectArrow(a1), Times.Once());
            target.Verify(mock => mock.SelectArrow(a2), Times.Once());
            target.Verify(mock => mock.SelectArrow(a3), Times.Once());
        }

        [Test]
        public void SelectAndResetTest()
        {
            var behavior = scorelist.Behaviors.OfType<SelectableArrowInListBehavior>().First();
            target.Setup(mock => mock.SelectArrow(It.IsAny<Arrow>()));
            target.Setup(mock => mock.ResetSelection());

            behavior.ArrowRecognizer_Tapped(scorelist.Children[0], null);
            behavior.ArrowRecognizer_Tapped(scorelist.Children[1], null);
            behavior.ArrowRecognizer_Tapped(scorelist.Children[2], null);

            // reset selection
            list[0].Command.Execute(null);

            target.Verify(mock => mock.ResetSelection(), Times.Once());
        }

        [Test]
        public void SelectAndUnselectTest()
        {
            var behavior = scorelist.Behaviors.OfType<SelectableArrowInListBehavior>().First();
            target.Setup(mock => mock.SelectArrow(It.IsAny<Arrow>()));
            target.Setup(mock => mock.UnSelectArrow(It.IsAny<Arrow>()));

            //select
            behavior.ArrowRecognizer_Tapped(scorelist.Children[0], null);
            behavior.ArrowRecognizer_Tapped(scorelist.Children[1], null);
            behavior.ArrowRecognizer_Tapped(scorelist.Children[2], null);

            //unselect
            behavior.ArrowRecognizer_Tapped(scorelist.Children[0], null);
            behavior.ArrowRecognizer_Tapped(scorelist.Children[1], null);
            behavior.ArrowRecognizer_Tapped(scorelist.Children[2], null);

            target.Verify(mock => mock.UnSelectArrow(a1), Times.Once());
            target.Verify(mock => mock.UnSelectArrow(a2), Times.Once());
            target.Verify(mock => mock.UnSelectArrow(a3), Times.Once());
        }

        [Test]
        public void SelectAndRemoveTest()
        {
            var behavior = scorelist.Behaviors.OfType<SelectableArrowInListBehavior>().First();
            target.Setup(mock => mock.SelectArrow(It.IsAny<Arrow>()));
            target.Setup(mock => mock.UnSelectArrow(It.IsAny<Arrow>()));

            //select
            behavior.ArrowRecognizer_Tapped(scorelist.Children[0], null);
            behavior.ArrowRecognizer_Tapped(scorelist.Children[1], null);
            behavior.ArrowRecognizer_Tapped(scorelist.Children[2], null);

            // reset selection
            list[1].Command.Execute(null);

            target.Verify(mock => mock.UnSelectArrow(a1), Times.Once());
            target.Verify(mock => mock.UnSelectArrow(a2), Times.Once());
            target.Verify(mock => mock.UnSelectArrow(a3), Times.Once());
        }
    }
}
