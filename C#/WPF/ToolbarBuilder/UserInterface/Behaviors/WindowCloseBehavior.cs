using System.Windows;

namespace ToolbarBuilder.UserInterface.Behaviors
{
    internal sealed class WindowCloseBehavior
    {
        public static readonly DependencyProperty CloseProperty
            = DependencyProperty.RegisterAttached(
                "Close",
                typeof(bool),
                typeof(WindowCloseBehavior),
                new UIPropertyMetadata(false, OnClosePropertyChanged));

        public static void SetClose(DependencyObject target, bool value)
        {
            target.SetValue(CloseProperty, value);
        }

        public static void OnClosePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(sender is Window targetWindow))
            {
                return;
            }

            if ((bool)e.NewValue)
            {
                targetWindow.DialogResult = true;
                targetWindow.Close();
            }
        }
    }
}
