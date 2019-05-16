using System;
using System.Linq;
using System.Windows;

namespace Panacea.Mvvm
{
    public abstract class ViewModelBase : PropertyChangedBase
    {
        private FrameworkElement _view;
        public virtual void Activate()
        {

        }

        public virtual void Deactivate()
        {

        }

        public virtual FrameworkElement View
        {
            get
            {
                if (_view != null) return _view;
                var type = GetViewType();
                _view = Activator.CreateInstance(type) as FrameworkElement;
                _view.DataContext = this;
                _view.SetValue(LifeCycleBehaviors.AutoWireEventsProperty, true);
                return _view;
            }
        }

        public virtual Type GetViewType()
        {
            var type = GetType();
            var attr = type.GetCustomAttributes(false).FirstOrDefault(a => a is ViewAttribute);
            if (attr == null) throw new Exception($"No view found for type '{type.FullName}'.");
            return (attr as ViewAttribute).Type;
        }

    }
}
