using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Panacea.Mvvm
{
    public abstract class PropertyChangedBase : INotifyPropertyChanged
    {
        public virtual event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}