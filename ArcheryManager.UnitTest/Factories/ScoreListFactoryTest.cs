using ArcheryManager.CustomControls;
using ArcheryManager.Factories;
using ArcheryManager.Interactions.Behaviors;
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
        private ScoreCounter counter;
        private List<ToolbarItem> list;
        private Mock<Target> target;
        private ArrowUniformGrid scorelist;
        private Arrow a4;
        private Arrow a3;
        private Arrow a2;
        private Arrow a1;

        [SetUp]
        public void Init()
        {
            Xamarin.Forms.Mocks.MockForms.Init();
            list = new List<ToolbarItem>();
            counter = new ScoreCounter();
            target = new Mock<Target>();
            scorelist = ScoreListFactory.Create(target.Object, counter, list);
            a1 = new Arrow("1", 1, Color.White);
            a2 = new Arrow("2", 2, Color.White);
            a3 = new Arrow("3", 3, Color.Black);
            a4 = new Arrow("4", 4, Color.Black);
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
