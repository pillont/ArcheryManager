using Xamarin.Forms;

namespace ArcheryManager.Behaviors
{
    /// <summary>
    /// abstract behavior with associated object initialized during OnAttached
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class CustomBehavior<T> : Behavior<T> where T : BindableObject
    {
        protected T associatedObject;

        protected override void OnAttachedTo(T bindable)
        {
            base.OnAttachedTo(bindable);
            associatedObject = bindable;
        }
    }
}
