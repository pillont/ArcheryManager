using ArcheryManager.CustomControls;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Settings;
using ArcheryManager.Settings.ArrowSettings;
using Moq;
using NUnit.Framework;

namespace ArcheryManager.UnitTest.Interactions.Behaviors
{
    [TestFixture]
    public class ArrowListOrderedBehaviorTest
    {
        private Mock<ArrowUniformGrid> _grid;
        private readonly GeneralCounterSetting GeneralCountSetting;
        private ArrowListOrderedBehavior _behavior;

        public ArrowListOrderedBehaviorTest()
        {
            GeneralCountSetting = new GeneralCounterSetting();
        }

        [SetUp]
        public void Init()
        {
            Xamarin.Forms.Mocks.MockForms.Init();

            _behavior = new ArrowListOrderedBehavior(GeneralCountSetting);
            _grid = new Mock<ArrowUniformGrid>();
            _grid.SetupProperty(s => s.OrderSelector);
            _grid.Object.Behaviors.Add(_behavior);
        }

        [Test]
        public void DefaultOrderTest()
        {
            Assert.IsFalse(GeneralCountSetting.CountSetting.IsDecreasingOrder);
            Assert.IsNull(_grid.Object.OrderSelector);
        }

        [Test]
        public void IsDecreasingOrderChangeTest()
        {
            GeneralCountSetting.CountSetting.IsDecreasingOrder = true;
            Assert.IsNotNull(_grid.Object.OrderSelector);

            GeneralCountSetting.CountSetting.IsDecreasingOrder = true;
            Assert.IsNotNull(_grid.Object.OrderSelector);

            GeneralCountSetting.CountSetting.IsDecreasingOrder = false;
            Assert.IsNull(_grid.Object.OrderSelector);

            GeneralCountSetting.CountSetting.IsDecreasingOrder = false;
            Assert.IsNull(_grid.Object.OrderSelector);
        }
    }
}
