using System;
using System.Reflection;
using System.Windows.Input;
using Xamarin.Forms;

namespace ArcheryManager.Interactions.Behaviors
{
    public class EventToCommandBehavior : CustomBehavior<View>
    {
        public static readonly BindableProperty CommandParameterProperty =
          BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(EventToCommandBehavior), null);

        public static readonly BindableProperty CommandProperty =
          BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(EventToCommandBehavior), null);

        public static readonly BindableProperty EventNameProperty =
                          BindableProperty.Create(nameof(EventName), typeof(string), typeof(EventToCommandBehavior), null);

        public static readonly BindableProperty InputConverterProperty =
          BindableProperty.Create(nameof(Converter), typeof(IValueConverter), typeof(EventToCommandBehavior), null);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public IValueConverter Converter
        {
            get { return (IValueConverter)GetValue(InputConverterProperty); }
            set { SetValue(InputConverterProperty, value); }
        }

        public string EventName
        {
            get { return (string)GetValue(EventNameProperty); }
            set { SetValue(EventNameProperty, value); }
        }

        protected override void OnAttachedTo(View bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.BindingContextChanged += Bindable_BindingContextChanged;
            RegisterEvent(EventName);
        }

        protected override void OnDetachingFrom(View bindable)
        {
            UnRegisterEvent(EventName);
            base.OnDetachingFrom(bindable);
        }

        private void Bindable_BindingContextChanged(object sender, EventArgs e)
        {
            this.BindingContext = AssociatedObject.BindingContext;
        }

        private Delegate GetEventHandler(EventInfo eventInfo)
        {
            if (eventInfo == null)
            {
                throw new ArgumentException(string.Format("EventToCommandBehavior: Can't register the '{0}' event.", EventName));
            }
            MethodInfo methodInfo = typeof(EventToCommandBehavior).GetTypeInfo().GetDeclaredMethod("OnEvent");
            var eventHandler = methodInfo.CreateDelegate(eventInfo.EventHandlerType, this);
            return eventHandler;
        }

        private void OnEvent(object sender, object eventArgs)
        {
            if (Command == null)
            {
                return;
            }

            object resolvedParameter;
            if (CommandParameter != null)
            {
                resolvedParameter = CommandParameter;
            }
            else if (Converter != null)
            {
                resolvedParameter = Converter.Convert(eventArgs, typeof(object), null, null);
            }
            else
            {
                resolvedParameter = eventArgs;
            }

            if (Command.CanExecute(resolvedParameter))
            {
                Command.Execute(resolvedParameter);
            }
        }

        private void RegisterEvent(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                EventInfo eventInfo = AssociatedObject.GetType().GetRuntimeEvent(name);
                var eventHandler = GetEventHandler(eventInfo);
                eventInfo.AddEventHandler(AssociatedObject, eventHandler);
            }
        }

        private void UnRegisterEvent(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                EventInfo eventInfo = AssociatedObject.GetType().GetRuntimeEvent(name);
                var eventHandler = GetEventHandler(eventInfo);
                eventInfo.RemoveEventHandler(AssociatedObject, eventHandler);
            }
        }
    }
}
