using Xamarin.Forms;

namespace ArcheryManager.Interactions.Behaviors
{
    /// <summary>
    /// abstract behavior with associated object initialized during OnAttached
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class CustomBehavior<T> : Behavior<T> where T : BindableObject
    {
        protected T AssociatedObject { get; private set; }

        protected override void OnAttachedTo(T bindable)
        {
            base.OnAttachedTo(bindable);
            AssociatedObject = bindable;
        }
    }
}
