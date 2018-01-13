using ArcheryManager.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcheryManager.UnitTest.Entities
{
    [TestFixture]
    public class CountedShootTest
    {
        private CountedShoot Counter;
        private DateTime Date;

        [SetUp]
        public void Init()
        {
            Date = new DateTime(2012, 12, 12);
            Counter = new CountedShoot() { LastChangeDate = Date };
            Counter.Flights.Add(new Flight());
        }

        [Test]
        public void LastUpdateDate_ArrowsChangeTest()
        {
            Counter.CurrentArrows.Add(new Arrow());

            // LastDate change during update
            Assert.AreNotEqual(Date, Counter.LastChangeDate);
        }

        [Test]
        public void LastUpdateDate_FlightChangeTest()
        {
            Counter.Flights.Add(new Flight());

            // LastDate change during update
            Assert.AreNotEqual(Date, Counter.LastChangeDate);
        }
    }
}
