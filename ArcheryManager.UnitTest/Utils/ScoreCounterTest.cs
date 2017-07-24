﻿using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Interfaces;
using ArcheryManager.Settings;
using ArcheryManager.Settings.ArrowSettings;
using ArcheryManager.Utils;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ArcheryManager.UnitTest.Utils
{
    [TestFixture]
    public class ScoreCounterTest
    {
        private ScoreCounter counter;
        private IArrowSetting arrowSetting;
        private CountSetting countSetting;
        private GeneralCounterSetting generalCounterSetting;

        [SetUp]
        public void Init()
        {
            countSetting = new CountSetting();
            arrowSetting = EnglishArrowSetting.Instance;
            var result = new ScoreResult();
            generalCounterSetting = new GeneralCounterSetting()
            {
                CountSetting = countSetting,
                ArrowSetting = arrowSetting,
                ScoreResult = result
            };
            counter = new ScoreCounter(generalCounterSetting);
        }

        [Test]
        public void Counter_initTest()
        {
            Assert.IsEmpty(counter.Result.CurrentArrows);
            Assert.Zero(counter.Result.FlightScore);
            Assert.Zero(counter.Result.TotalScore);
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

            Assert.AreEqual(3, counter.Result.CurrentArrows.Count);
            Assert.AreEqual(arrow1, counter.Result.CurrentArrows[0]);
            Assert.AreEqual(arrow2, counter.Result.CurrentArrows[1]);
            Assert.AreEqual(arrow3, counter.Result.CurrentArrows[2]);
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
            Assert.AreEqual(2, counter.Result.CurrentArrows.Count);
            Assert.AreEqual(arrow1, counter.Result.CurrentArrows[0]);
            Assert.AreEqual(arrow2, counter.Result.CurrentArrows[1]);

            counter.RemoveLastArrow();
            Assert.AreEqual(1, counter.Result.CurrentArrows.Count);
            Assert.AreEqual(arrow1, counter.Result.CurrentArrows[0]);

            counter.RemoveLastArrow();
            Assert.AreEqual(0, counter.Result.CurrentArrows.Count);

            counter.RemoveLastArrow();
            Assert.AreEqual(0, counter.Result.CurrentArrows.Count);
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
            Assert.AreEqual(0, counter.Result.CurrentArrows.Count);
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

            Assert.AreEqual(3, counter.Result.CurrentArrows.Count);
            counter.NewFlight();
            Assert.AreEqual(0, counter.Result.CurrentArrows.Count);
        }

        [Test]
        public void Counter_ScoreUpdateTest()
        {
            Assert.AreEqual(0, counter.Result.FlightScore);
            Assert.AreEqual(0, counter.Result.TotalScore);
            Assert.AreEqual(0, counter.Result.CurrentArrows.Count);

            var arrow1 = new Arrow(10, 0);
            counter.AddArrow(arrow1);

            Assert.AreEqual(10, counter.Result.FlightScore);
            Assert.AreEqual(10, counter.Result.TotalScore);
            Assert.AreEqual(1, counter.Result.CurrentArrows.Count);

            var arrow2 = new Arrow(9, 1);
            counter.AddArrow(arrow2);

            Assert.AreEqual(19, counter.Result.FlightScore);
            Assert.AreEqual(19, counter.Result.TotalScore);
            Assert.AreEqual(2, counter.Result.CurrentArrows.Count);

            var arrow3 = new Arrow(7, 2);
            counter.AddArrow(arrow3);

            Assert.AreEqual(26, counter.Result.FlightScore);
            Assert.AreEqual(26, counter.Result.TotalScore);
            Assert.AreEqual(3, counter.Result.CurrentArrows.Count);

            counter.RemoveLastArrow();
            Assert.AreEqual(19, counter.Result.FlightScore);
            Assert.AreEqual(19, counter.Result.TotalScore);
            Assert.AreEqual(2, counter.Result.CurrentArrows.Count);

            counter.ClearArrows();
            Assert.AreEqual(0, counter.Result.FlightScore);
            Assert.AreEqual(0, counter.Result.TotalScore);
            Assert.AreEqual(0, counter.Result.CurrentArrows.Count);
        }

        [Test]
        public void Counter_TotalScoreUpdateTest()
        {
            Assert.AreEqual(0, counter.Result.FlightScore);
            Assert.AreEqual(0, counter.Result.TotalScore);
            Assert.AreEqual(0, counter.Result.CurrentArrows.Count);

            var arrow1 = new Arrow(10, 0);
            counter.AddArrow(arrow1);

            Assert.AreEqual(10, counter.Result.FlightScore);
            Assert.AreEqual(10, counter.Result.TotalScore);
            Assert.AreEqual(1, counter.Result.CurrentArrows.Count);

            counter.NewFlight();

            Assert.AreEqual(0, counter.Result.FlightScore);
            Assert.AreEqual(10, counter.Result.TotalScore);
            Assert.AreEqual(0, counter.Result.CurrentArrows.Count);

            var arrow2 = new Arrow(9, 1);
            counter.AddArrow(arrow2);

            Assert.AreEqual(9, counter.Result.FlightScore);
            Assert.AreEqual(19, counter.Result.TotalScore);
            Assert.AreEqual(1, counter.Result.CurrentArrows.Count);

            var arrow3 = new Arrow(7, 2);
            counter.AddArrow(arrow3);
            counter.NewFlight();

            Assert.AreEqual(0, counter.Result.FlightScore);
            Assert.AreEqual(26, counter.Result.TotalScore);
            Assert.AreEqual(0, counter.Result.CurrentArrows.Count);
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
            Assert.AreEqual(2, counter.Result.CurrentArrows.Count);
            Assert.IsTrue(counter.Result.CurrentArrows.Contains(a1));
            Assert.IsTrue(counter.Result.CurrentArrows.Contains(a2));

            counter.NewFlight();
            Assert.AreEqual(0, counter.Result.CurrentArrows.Count);

            counter.AddArrow(a3);
            Assert.AreEqual(1, counter.Result.CurrentArrows.Count);
            Assert.IsTrue(counter.Result.CurrentArrows.Contains(a3));

            counter.RemoveLastArrow();
            Assert.AreEqual(0, counter.Result.CurrentArrows.Count);

            counter.AddArrow(a4);
            Assert.AreEqual(1, counter.Result.CurrentArrows.Count);
            Assert.IsTrue(counter.Result.CurrentArrows.Contains(a4));

            counter.ClearArrows();
            Assert.AreEqual(0, counter.Result.CurrentArrows.Count);
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
            Assert.AreEqual(0, counter.Result.PreviousArrows.Count);

            counter.NewFlight();
            Assert.AreEqual(2, counter.Result.PreviousArrows.Count);
            Assert.IsTrue(counter.Result.PreviousArrows.Contains(a1));
            Assert.IsTrue(counter.Result.PreviousArrows.Contains(a2));

            counter.AddArrow(a3);
            Assert.AreEqual(2, counter.Result.PreviousArrows.Count);
            Assert.IsTrue(counter.Result.PreviousArrows.Contains(a1));
            Assert.IsTrue(counter.Result.PreviousArrows.Contains(a2));
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
            Assert.AreEqual(2, counter.Result.AllArrows.Count);
            Assert.IsTrue(counter.Result.AllArrows.Contains(a1));
            Assert.IsTrue(counter.Result.AllArrows.Contains(a2));

            counter.NewFlight();
            Assert.AreEqual(2, counter.Result.AllArrows.Count);
            Assert.IsTrue(counter.Result.AllArrows.Contains(a1));
            Assert.IsTrue(counter.Result.AllArrows.Contains(a2));

            counter.AddArrow(a3);
            Assert.AreEqual(3, counter.Result.AllArrows.Count);
            Assert.IsTrue(counter.Result.AllArrows.Contains(a1));
            Assert.IsTrue(counter.Result.AllArrows.Contains(a2));
            Assert.IsTrue(counter.Result.AllArrows.Contains(a3));

            counter.RemoveLastArrow();
            Assert.AreEqual(2, counter.Result.AllArrows.Count);
            Assert.IsTrue(counter.Result.AllArrows.Contains(a1));
            Assert.IsTrue(counter.Result.AllArrows.Contains(a2));

            counter.AddArrow(a4);
            Assert.AreEqual(3, counter.Result.AllArrows.Count);
            Assert.IsTrue(counter.Result.AllArrows.Contains(a1));
            Assert.IsTrue(counter.Result.AllArrows.Contains(a2));
            Assert.IsTrue(counter.Result.AllArrows.Contains(a4));

            counter.ClearArrows();
            Assert.AreEqual(2, counter.Result.AllArrows.Count);
            Assert.IsTrue(counter.Result.AllArrows.Contains(a1));
            Assert.IsTrue(counter.Result.AllArrows.Contains(a2));
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

            Assert.AreEqual(counter.Result.CurrentArrows, counter.ArrowsShowed);
            countSetting.ShowAllArrows = true;
            Assert.AreEqual(counter.Result.AllArrows, counter.ArrowsShowed);
        }

        [Test]
        public void UpdateOrderBeforeTest()
        {
            countSetting.IsDecreasingOrder = true;
            var a1 = new Arrow(1, 0);
            var a2 = new Arrow(8, 0);
            var a3 = new Arrow(5, 0);
            counter.AddArrow(a1);
            counter.AddArrow(a2);
            counter.AddArrow(a3);

            Assert.AreEqual(a2, counter.Result.CurrentArrows[0]);
            Assert.AreEqual(a3, counter.Result.CurrentArrows[1]);
            Assert.AreEqual(a1, counter.Result.CurrentArrows[2]);
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
            countSetting.IsDecreasingOrder = true;

            Assert.AreEqual(a2, counter.Result.CurrentArrows[0]);
            Assert.AreEqual(a3, counter.Result.CurrentArrows[1]);
            Assert.AreEqual(a1, counter.Result.CurrentArrows[2]);
        }

        [Test]
        public void UpdateOrderbeforeAndAfetrTest()
        {
            countSetting.IsDecreasingOrder = true;

            var a1 = new Arrow(1, 0);
            var a2 = new Arrow(8, 1);
            var a3 = new Arrow(5, 2);
            counter.AddArrow(a1);
            counter.AddArrow(a2);
            counter.AddArrow(a3);
            countSetting.IsDecreasingOrder = false;

            // keep the same order
            Assert.AreEqual(a1, counter.Result.CurrentArrows[0]);
            Assert.AreEqual(a2, counter.Result.CurrentArrows[1]);
            Assert.AreEqual(a3, counter.Result.CurrentArrows[2]);
        }

        [Test]
        public void UpdateOrderWithSameScoreTest()
        {
            countSetting.IsDecreasingOrder = true;

            var a1 = new Arrow(11, 0);
            var a2 = new Arrow(10, 0);
            var a3 = new Arrow(11, 0);
            counter.AddArrow(a1);
            counter.AddArrow(a2);
            counter.AddArrow(a3);

            // keep the same order
            Assert.AreEqual(a1, counter.Result.CurrentArrows[0]);
            Assert.AreEqual(a3, counter.Result.CurrentArrows[1]);
            Assert.AreEqual(a2, counter.Result.CurrentArrows[2]);
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

            Assert.IsEmpty(counter.Result.AllArrows);
            Assert.Zero(counter.Result.TotalScore);
            Assert.Zero(counter.Result.FlightScore);
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

            Assert.AreEqual(4, counter.Result.AllArrows.Count);
            Assert.AreEqual(1, counter.Result.CurrentArrows.Count);
            Assert.AreEqual(3, counter.Result.PreviousArrows.Count);
            Assert.AreEqual(10, counter.Result.TotalScore);
            Assert.AreEqual(4, counter.Result.FlightScore);
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
