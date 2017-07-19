using ArcheryManager.Interfaces;
using ArcheryManager.Pages;
using ArcheryManager.Settings;
using ArcheryManager.Utils;
using NUnit.Framework;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ArcheryManager.UnitTest.Utils
{
    [TestFixture]
    public class ScoreCounterTest
    {
        private List<ToolbarItem> toolBarList;

        private ScoreCounter counter;
        private TargetSetting targetSetting;

        private IArrowSetting arrowSetting;
        private CountSetting setting;

        [SetUp]
        public void Init()
        {
            setting = new CountSetting();
            toolBarList = new List<ToolbarItem>();
            targetSetting = new TargetSetting(setting);
            arrowSetting = EnglishArrowSetting.Instance;
            counter = new ScoreCounter(targetSetting, toolBarList, arrowSetting);
        }

        [Test]
        public void Counter_initTest()
        {
            Assert.IsEmpty(counter.CurrentArrows);
            Assert.Zero(counter.FlightScore);
            Assert.Zero(counter.TotalScore);
        }

        #region total calcul

        [Test]
        public void Counter_AddArrowTest()
        {
            var arrow1 = new Arrow(10, 0);
            var arrow2 = new Arrow(9, 1);
            var arrow3 = new Arrow(8, 2);

            counter.AddArrow(arrow1);
            counter.AddArrow(arrow2);
            counter.AddArrow(arrow3);

            Assert.AreEqual(3, counter.CurrentArrows.Count);
            Assert.AreEqual(arrow1, counter.CurrentArrows[0]);
            Assert.AreEqual(arrow2, counter.CurrentArrows[1]);
            Assert.AreEqual(arrow3, counter.CurrentArrows[2]);
        }

        [Test]
        public void Counter_AddRemoveArrowTest()
        {
            var arrow1 = new Arrow(10, 0);
            var arrow2 = new Arrow(9, 1);
            var arrow3 = new Arrow(10, 2);

            counter.AddArrow(arrow1);
            counter.AddArrow(arrow2);
            counter.AddArrow(arrow3);

            counter.RemoveLastArrow();
            Assert.AreEqual(2, counter.CurrentArrows.Count);
            Assert.AreEqual(arrow1, counter.CurrentArrows[0]);
            Assert.AreEqual(arrow2, counter.CurrentArrows[1]);

            counter.RemoveLastArrow();
            Assert.AreEqual(1, counter.CurrentArrows.Count);
            Assert.AreEqual(arrow1, counter.CurrentArrows[0]);

            counter.RemoveLastArrow();
            Assert.AreEqual(0, counter.CurrentArrows.Count);

            counter.RemoveLastArrow();
            Assert.AreEqual(0, counter.CurrentArrows.Count);
        }

        [Test]
        public void Counter_RemoveAllArrowTest()
        {
            var arrow1 = new Arrow(10, 0);
            var arrow2 = new Arrow(9, 1);
            var arrow3 = new Arrow(10, 2);

            counter.AddArrow(arrow1);
            counter.AddArrow(arrow2);
            counter.AddArrow(arrow3);

            counter.ClearArrows();
            Assert.AreEqual(0, counter.CurrentArrows.Count);
        }

        [Test]
        public void Counter_RemoveAllArrowNewFlightTest()
        {
            var arrow1 = new Arrow(10, 0);
            var arrow2 = new Arrow(9, 1);
            var arrow3 = new Arrow(10, 2);

            counter.AddArrow(arrow1);
            counter.AddArrow(arrow2);
            counter.AddArrow(arrow3);

            Assert.AreEqual(3, counter.CurrentArrows.Count);
            counter.NewFlight();
            Assert.AreEqual(0, counter.CurrentArrows.Count);
        }

        [Test]
        public void Counter_ScoreUpdateTest()
        {
            Assert.AreEqual(0, counter.FlightScore);
            Assert.AreEqual(0, counter.TotalScore);
            Assert.AreEqual(0, counter.CurrentArrows.Count);

            var arrow1 = new Arrow(10, 0);
            counter.AddArrow(arrow1);

            Assert.AreEqual(10, counter.FlightScore);
            Assert.AreEqual(10, counter.TotalScore);
            Assert.AreEqual(1, counter.CurrentArrows.Count);

            var arrow2 = new Arrow(9, 1);
            counter.AddArrow(arrow2);

            Assert.AreEqual(19, counter.FlightScore);
            Assert.AreEqual(19, counter.TotalScore);
            Assert.AreEqual(2, counter.CurrentArrows.Count);

            var arrow3 = new Arrow(7, 2);
            counter.AddArrow(arrow3);

            Assert.AreEqual(26, counter.FlightScore);
            Assert.AreEqual(26, counter.TotalScore);
            Assert.AreEqual(3, counter.CurrentArrows.Count);

            counter.RemoveLastArrow();
            Assert.AreEqual(19, counter.FlightScore);
            Assert.AreEqual(19, counter.TotalScore);
            Assert.AreEqual(2, counter.CurrentArrows.Count);

            counter.ClearArrows();
            Assert.AreEqual(0, counter.FlightScore);
            Assert.AreEqual(0, counter.TotalScore);
            Assert.AreEqual(0, counter.CurrentArrows.Count);
        }

        [Test]
        public void Counter_TotalScoreUpdateTest()
        {
            Assert.AreEqual(0, counter.FlightScore);
            Assert.AreEqual(0, counter.TotalScore);
            Assert.AreEqual(0, counter.CurrentArrows.Count);

            var arrow1 = new Arrow(10, 0);
            counter.AddArrow(arrow1);

            Assert.AreEqual(10, counter.FlightScore);
            Assert.AreEqual(10, counter.TotalScore);
            Assert.AreEqual(1, counter.CurrentArrows.Count);

            counter.NewFlight();

            Assert.AreEqual(0, counter.FlightScore);
            Assert.AreEqual(10, counter.TotalScore);
            Assert.AreEqual(0, counter.CurrentArrows.Count);

            var arrow2 = new Arrow(9, 1);
            counter.AddArrow(arrow2);

            Assert.AreEqual(9, counter.FlightScore);
            Assert.AreEqual(19, counter.TotalScore);
            Assert.AreEqual(1, counter.CurrentArrows.Count);

            var arrow3 = new Arrow(7, 2);
            counter.AddArrow(arrow3);
            counter.NewFlight();

            Assert.AreEqual(0, counter.FlightScore);
            Assert.AreEqual(26, counter.TotalScore);
            Assert.AreEqual(0, counter.CurrentArrows.Count);
        }

        #endregion total calcul

        [Test]
        public void CurrentArrowTest()
        {
            var a1 = new Arrow(1, 0);
            var a2 = new Arrow(2, 1);
            var a3 = new Arrow(3, 2);
            var a4 = new Arrow(4, 0);
            var a5 = new Arrow(5, 1);

            counter.AddArrow(a1);
            counter.AddArrow(a2);
            Assert.AreEqual(2, counter.CurrentArrows.Count);
            Assert.IsTrue(counter.CurrentArrows.Contains(a1));
            Assert.IsTrue(counter.CurrentArrows.Contains(a2));

            counter.NewFlight();
            Assert.AreEqual(0, counter.CurrentArrows.Count);

            counter.AddArrow(a3);
            Assert.AreEqual(1, counter.CurrentArrows.Count);
            Assert.IsTrue(counter.CurrentArrows.Contains(a3));

            counter.RemoveLastArrow();
            Assert.AreEqual(0, counter.CurrentArrows.Count);

            counter.AddArrow(a4);
            Assert.AreEqual(1, counter.CurrentArrows.Count);
            Assert.IsTrue(counter.CurrentArrows.Contains(a4));

            counter.ClearArrows();
            Assert.AreEqual(0, counter.CurrentArrows.Count);
        }

        [Test]
        public void PreviousArrowTest()
        {
            var a1 = new Arrow(1, 0);
            var a2 = new Arrow(2, 1);
            var a3 = new Arrow(3, 2);
            var a4 = new Arrow(4, 0);
            var a5 = new Arrow(5, 1);

            counter.AddArrow(a1);
            counter.AddArrow(a2);
            Assert.AreEqual(0, counter.PreviousArrows.Count);

            counter.NewFlight();
            Assert.AreEqual(2, counter.PreviousArrows.Count);
            Assert.IsTrue(counter.PreviousArrows.Contains(a1));
            Assert.IsTrue(counter.PreviousArrows.Contains(a2));

            counter.AddArrow(a3);
            Assert.AreEqual(2, counter.PreviousArrows.Count);
            Assert.IsTrue(counter.PreviousArrows.Contains(a1));
            Assert.IsTrue(counter.PreviousArrows.Contains(a2));
        }

        [Test]
        public void AllArrowTest()
        {
            var a1 = new Arrow(1, 0);
            var a2 = new Arrow(2, 1);
            var a3 = new Arrow(3, 2);
            var a4 = new Arrow(4, 0);
            var a5 = new Arrow(5, 1);

            counter.AddArrow(a1);
            counter.AddArrow(a2);
            Assert.AreEqual(2, counter.AllArrows.Count);
            Assert.IsTrue(counter.AllArrows.Contains(a1));
            Assert.IsTrue(counter.AllArrows.Contains(a2));

            counter.NewFlight();
            Assert.AreEqual(2, counter.AllArrows.Count);
            Assert.IsTrue(counter.AllArrows.Contains(a1));
            Assert.IsTrue(counter.AllArrows.Contains(a2));

            counter.AddArrow(a3);
            Assert.AreEqual(3, counter.AllArrows.Count);
            Assert.IsTrue(counter.AllArrows.Contains(a1));
            Assert.IsTrue(counter.AllArrows.Contains(a2));
            Assert.IsTrue(counter.AllArrows.Contains(a3));

            counter.RemoveLastArrow();
            Assert.AreEqual(2, counter.AllArrows.Count);
            Assert.IsTrue(counter.AllArrows.Contains(a1));
            Assert.IsTrue(counter.AllArrows.Contains(a2));

            counter.AddArrow(a4);
            Assert.AreEqual(3, counter.AllArrows.Count);
            Assert.IsTrue(counter.AllArrows.Contains(a1));
            Assert.IsTrue(counter.AllArrows.Contains(a2));
            Assert.IsTrue(counter.AllArrows.Contains(a4));

            counter.ClearArrows();
            Assert.AreEqual(2, counter.AllArrows.Count);
            Assert.IsTrue(counter.AllArrows.Contains(a1));
            Assert.IsTrue(counter.AllArrows.Contains(a2));
        }

        [Test]
        public void ArrowsShowedTest()
        {
            var a1 = new Arrow(1, 0);
            var a2 = new Arrow(2, 1);
            var a3 = new Arrow(3, 2);
            var a4 = new Arrow(4, 0);

            counter.AddArrow(a1);
            counter.AddArrow(a2);

            counter.NewFlight();
            counter.AddArrow(a3);
            counter.AddArrow(a4);

            Assert.AreEqual(counter.CurrentArrows, counter.ArrowsShowed);
            targetSetting.ShowAllArrows = true;
            Assert.AreEqual(counter.AllArrows, counter.ArrowsShowed);
        }

        [Test]
        public void UpdateOrderBeforeTest()
        {
            targetSetting.IsDecreasingOrder = true;
            var a1 = new Arrow(1, 0);
            var a2 = new Arrow(8, 0);
            var a3 = new Arrow(5, 0);
            counter.AddArrow(a1);
            counter.AddArrow(a2);
            counter.AddArrow(a3);

            Assert.AreEqual(a2, counter.CurrentArrows[0]);
            Assert.AreEqual(a3, counter.CurrentArrows[1]);
            Assert.AreEqual(a1, counter.CurrentArrows[2]);
        }

        [Test]
        public void UpdateOrderAfetrTest()
        {
            var a1 = new Arrow(1, 0);
            var a2 = new Arrow(8, 0);
            var a3 = new Arrow(5, 0);
            counter.AddArrow(a1);
            counter.AddArrow(a2);
            counter.AddArrow(a3);
            targetSetting.IsDecreasingOrder = true;

            Assert.AreEqual(a2, counter.CurrentArrows[0]);
            Assert.AreEqual(a3, counter.CurrentArrows[1]);
            Assert.AreEqual(a1, counter.CurrentArrows[2]);
        }

        [Test]
        public void UpdateOrderbeforeAndAfetrTest()
        {
            targetSetting.IsDecreasingOrder = true;

            var a1 = new Arrow(1, 0);
            var a2 = new Arrow(8, 1);
            var a3 = new Arrow(5, 2);
            counter.AddArrow(a1);
            counter.AddArrow(a2);
            counter.AddArrow(a3);
            targetSetting.IsDecreasingOrder = false;

            // keep the same order
            Assert.AreEqual(a1, counter.CurrentArrows[0]);
            Assert.AreEqual(a2, counter.CurrentArrows[1]);
            Assert.AreEqual(a3, counter.CurrentArrows[2]);
        }

        [Test]
        public void UpdateOrderWithSameScoreTest()
        {
            targetSetting.IsDecreasingOrder = true;

            var a1 = new Arrow(11, 0);
            var a2 = new Arrow(10, 0);
            var a3 = new Arrow(11, 0);
            counter.AddArrow(a1);
            counter.AddArrow(a2);
            counter.AddArrow(a3);

            // keep the same order
            Assert.AreEqual(a1, counter.CurrentArrows[0]);
            Assert.AreEqual(a3, counter.CurrentArrows[1]);
            Assert.AreEqual(a2, counter.CurrentArrows[2]);
        }

        [Test]
        public void ToolBarItems_HaveMaxTest()
        {
            targetSetting.CountSetting.HaveMaxArrowsCount = true;
            counter.AddDefaultToolbarItems();
            setting.ArrowsCount = 2;
            Assert.AreEqual(3, toolBarList.Count);

            counter.AddArrow(new Arrow(0, 0));
            Assert.AreEqual(3, toolBarList.Count);

            counter.AddArrow(new Arrow(0, 0));
            Assert.AreEqual(4, toolBarList.Count);
        }

        [Test]
        public void ToolBarItems_AddTest()
        {
            targetSetting.CountSetting.HaveMaxArrowsCount = false;
            counter.AddDefaultToolbarItems();
            Assert.AreEqual(3, toolBarList.Count);

            setting.ArrowsCount = 2;
            counter.AddArrow(new Arrow(0, 0));
            Assert.AreEqual(4, toolBarList.Count);
        }

        [Test]
        public void ToolBarItems_RemoveTest()
        {
            targetSetting.CountSetting.HaveMaxArrowsCount = true;
            counter.AddDefaultToolbarItems();
            Assert.AreEqual(3, toolBarList.Count);
            setting.ArrowsCount = 2;

            counter.AddArrow(new Arrow(0, 0));
            counter.AddArrow(new Arrow(0, 0));

            counter.RemoveLastArrow();
            Assert.AreEqual(3, toolBarList.Count);
        }

        [Test]
        public void ToolBarItems_RemoveWithoutMaxTest()
        {
            targetSetting.CountSetting.HaveMaxArrowsCount = false;
            counter.AddDefaultToolbarItems();
            Assert.AreEqual(3, toolBarList.Count);
            setting.ArrowsCount = 2;

            counter.AddArrow(new Arrow(0, 0));
            counter.AddArrow(new Arrow(0, 0));

            counter.RemoveLastArrow();
            Assert.AreEqual(4, toolBarList.Count);
            counter.RemoveLastArrow();
            Assert.AreEqual(3, toolBarList.Count);
        }

        [Test]
        public void RestartTest()
        {
            var a1 = new Arrow(1, 0);
            var a2 = new Arrow(2, 0);
            var a3 = new Arrow(3, 0);
            var a4 = new Arrow(4, 0);

            counter.AddArrow(a1);
            counter.AddArrow(a2);
            counter.NewFlight();
            counter.AddArrow(a3);
            counter.AddArrow(a4);

            counter.RestartCount();

            Assert.IsEmpty(counter.AllArrows);
            Assert.Zero(counter.TotalScore);
            Assert.Zero(counter.FlightScore);
        }

        [Test]
        public void RestartAndContinueTest()
        {
            var a1 = new Arrow(1, 0);
            var a2 = new Arrow(2, 0);
            var a3 = new Arrow(3, 0);
            var a4 = new Arrow(4, 0);

            counter.AddArrow(a1);
            counter.AddArrow(a2);
            counter.NewFlight();
            counter.AddArrow(a3);
            counter.AddArrow(a4);

            counter.RestartCount();

            counter.AddArrow(a1);
            counter.AddArrow(a2);
            counter.AddArrow(a3);
            counter.NewFlight();
            counter.AddArrow(a4);

            Assert.AreEqual(4, counter.AllArrows.Count);
            Assert.AreEqual(1, counter.CurrentArrows.Count);
            Assert.AreEqual(3, counter.PreviousArrows.Count);
            Assert.AreEqual(10, counter.TotalScore);
            Assert.AreEqual(4, counter.FlightScore);
        }

        [Test]
        public void DefaultScoreStringTest()
        {
            Assert.AreEqual("0/0", counter.FlightScoreString);
            Assert.AreEqual("0/0", counter.TotalScoreString);
        }

        [Test]
        public void DefaultScoreStringBeforeNewArrowTest()
        {
            counter.AddArrow(new Arrow(1, 0));
            counter.AddArrow(new Arrow(2, 0));
            counter.AddArrow(new Arrow(3, 0));

            Assert.AreEqual("6/30", counter.FlightScoreString);
            Assert.AreEqual("6/30", counter.TotalScoreString);
        }

        [Test]
        public void DefaultScoreStringInNewArrowTest()
        {
            counter.AddArrow(new Arrow(1, 0));
            counter.AddArrow(new Arrow(2, 0));
            counter.AddArrow(new Arrow(3, 0));
            counter.NewFlight();

            Assert.AreEqual("0/0", counter.FlightScoreString);
            Assert.AreEqual("6/30", counter.TotalScoreString);
        }

        [Test]
        public void TotalScoreTest()
        {
            counter.AddArrow(new Arrow(1, 0));
            counter.AddArrow(new Arrow(2, 0));
            counter.AddArrow(new Arrow(3, 0));
            counter.NewFlight();
            counter.AddArrow(new Arrow(4, 0));
            counter.AddArrow(new Arrow(5, 0));

            Assert.AreEqual("9/20", counter.FlightScoreString);
            Assert.AreEqual("15/50", counter.TotalScoreString);
        }
    }
}
