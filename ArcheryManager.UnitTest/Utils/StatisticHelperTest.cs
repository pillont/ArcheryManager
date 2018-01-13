using ArcheryManager.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ArcheryManager.UnitTest.Utils
{
    [TestFixture]
    public class StatisticHelperTest
    {
        [Test]
        public void StdDev_EmptyTest()
        {
            double res = -1;
            Assert.DoesNotThrow(() => res = StatisticHelper.CalculateStdDev(new List<double>()));
            Assert.AreEqual(0, res);
        }

        [Test]
        public void StdDev_NullTest()
        {
            double res = -1;
            Assert.DoesNotThrow(() => res = StatisticHelper.CalculateStdDev(null));
            Assert.AreEqual(0, res);
        }

        [Test]
        public void StdDevTest()
        {
            double res = -1;
            Assert.DoesNotThrow(() => res = StatisticHelper.CalculateStdDev(new List<double> { 1, 2, 3, 4 }));
            Assert.AreEqual(1.29, Math.Round(res, 2));
        }
    }
}
