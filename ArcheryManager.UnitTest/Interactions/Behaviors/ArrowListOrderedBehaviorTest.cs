using ArcheryManager.CustomControls;
using ArcheryManager.Entities;
using ArcheryManager.Interactions.Behaviors;
using Moq;
using NUnit.Framework;

namespace ArcheryManager.UnitTest.Interactions.Behaviors
{
    [TestFixture]
    public class ArrowListOrderedBehaviorTest
    {
        private ArrowListOrderedBehavior _behavior;
        private Mock<ArrowUniformGrid> _grid;
        private CountedShoot Shoot;

        [Test]
        public void DefaultOrderTest()
        {
            Assert.IsFalse(Shoot.IsDecreasingOrder);
            Assert.IsNull(_grid.Object.OrderSelector);
        }

        [SetUp]
        public void Init()
        {
            Xamarin.Forms.Mocks.MockForms.Init();
            Shoot = new CountedShoot();

            _behavior = new ArrowListOrderedBehavior(Shoot);
            _grid = new Mock<ArrowUniformGrid>();
            _grid.SetupProperty(s => s.OrderSelector);
            _grid.Object.Behaviors.Add(_behavior);
        }

        [Test]
        public void IsDecreasingOrderChangeTest()
        {
            Shoot.IsDecreasingOrder = true;
            Assert.IsNotNull(_grid.Object.OrderSelector);

            Shoot.IsDecreasingOrder = true;
            Assert.IsNotNull(_grid.Object.OrderSelector);

            Shoot.IsDecreasingOrder = false;
            Assert.IsNull(_grid.Object.OrderSelector);

            Shoot.IsDecreasingOrder = false;
            Assert.IsNull(_grid.Object.OrderSelector);
        }
    }
}
