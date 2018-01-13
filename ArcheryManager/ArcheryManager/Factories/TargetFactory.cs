using ArcheryManager.CustomControls;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Utils;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;
using XLabs.Ioc;

namespace ArcheryManager.Factories
{
    public class TargetFactory
    {
        private const int MinimumTargetSize = 1200;

        /// <summary>
        /// create Target
        /// </summary>
        /// <param name="counter"></param>
        /// <param name="targetSetting"></param>
        /// <param name="arrowSetting"></param>
        /// <returns></returns>
        public static Target Create(View gestureMoveTarget)
        {
            var manager = Resolver.Resolve<CounterManager>();
            var messageManager = Resolver.Resolve<MessageManager>();
            var customTarget = ViewFactory.CreatePage<TargetViewModel, Target>() as Target;
            customTarget.MinimumHeightRequest = MinimumTargetSize;
            customTarget.MinimumWidthRequest = MinimumTargetSize;

            var averageBehavior = new AverageBehavior(manager, customTarget);
            customTarget.AverageCanvas.Behaviors.Add(averageBehavior);

            var behavior = new MovableTargetBehavior(gestureMoveTarget, manager, messageManager);
            customTarget.Behaviors.Add(behavior);

            return customTarget;
        }
    }
}
