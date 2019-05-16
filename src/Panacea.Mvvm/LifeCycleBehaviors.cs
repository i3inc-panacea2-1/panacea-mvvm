using System.Windows;

namespace Panacea.Mvvm
{
    class LifeCycleBehaviors : DependencyObject
    {
        public static bool GetAutoWireEvents(DependencyObject d)
        {
            return (bool)d.GetValue(AutoWireEventsProperty);
        }

        public static void SetAutoWireEvents(DependencyObject d, string value)
        {
            d.SetValue(AutoWireEventsProperty, value);
        }


        // Using a DependencyProperty as the backing store for ScrollsHorizontally.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AutoWireEventsProperty =
            DependencyProperty.RegisterAttached("AutoWireEvents", typeof(bool), typeof(LifeCycleBehaviors), new PropertyMetadata(false, OnChange));

        private static void OnChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var c = d as FrameworkElement;
            if (c == null) return;
            c.Loaded -= C_Loaded;
            c.Unloaded -= C_Unloaded;
            if ((bool)e.NewValue)
            {
                c.Loaded += C_Loaded;
                c.Unloaded += C_Unloaded;
            }
        }

        private static void C_Unloaded(object sender, RoutedEventArgs e)
        {
            var c = sender as FrameworkElement;
            if (c == null) return;
            var vm = c.DataContext as ViewModelBase;
            if (vm == null) return;
            vm.Deactivate();
        }

        private static void C_Loaded(object sender, RoutedEventArgs e)
        {
            var c = sender as FrameworkElement;
            if (c == null) return;
            var vm = c.DataContext as ViewModelBase;
            if (vm == null) return;
            vm.Activate();
        }
    }
}
