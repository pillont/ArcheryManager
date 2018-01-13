using ArcheryManager.Entities;
using NUnit.Framework;
using System;

namespace ArcheryManager.UnitTest.Entities
{
    [TestFixture]
    public class BaseEntityTest
    {
        private CountedShoot Counter;
        private DateTime Date;

        [Test]
        public void CreationDate_DefaultDateTest()
        {
            Counter = new CountedShoot();
            // Create date is now !
            Assert.AreEqual(DateTime.Now.Year, Counter.CreationDate.Year);
            Assert.AreEqual(DateTime.Now.Month, Counter.CreationDate.Month);
            Assert.AreEqual(DateTime.Now.Day, Counter.CreationDate.Day);
            Assert.AreEqual(DateTime.Now.Hour, Counter.CreationDate.Hour, 1);

            // LastUpdateDate is now !
            Assert.AreEqual(DateTime.Now.Year, Counter.LastChangeDate.Year);
            Assert.AreEqual(DateTime.Now.Month, Counter.LastChangeDate.Month);
            Assert.AreEqual(DateTime.Now.Day, Counter.LastChangeDate.Day);
            Assert.AreEqual(DateTime.Now.Hour, Counter.LastChangeDate.Hour, 1);
        }

        [Test]
        public void CreationDate_NotChangeTest()
        {
            Counter.OnPropertyChange("test");

            // LastDate not change during update
            Assert.AreEqual(Date, Counter.CreationDate);
        }

        [SetUp]
        public void Init()
        {
            Date = new DateTime(2012, 12, 12);
            Counter = new CountedShoot() { CreationDate = Date, LastChangeDate = Date };
        }

        [Test]
        public void LastUpdateDateTest()
        {
            Counter.OnPropertyChange("test");

            // LastDate change during update
            Assert.AreNotEqual(Date, Counter.LastChangeDate);

            // and date is now !
            Assert.AreEqual(DateTime.Now.Year, Counter.LastChangeDate.Year);
            Assert.AreEqual(DateTime.Now.Month, Counter.LastChangeDate.Month);
            Assert.AreEqual(DateTime.Now.Day, Counter.LastChangeDate.Day);
            Assert.AreEqual(DateTime.Now.Hour, Counter.LastChangeDate.Hour, 1);
        }
    }
}
