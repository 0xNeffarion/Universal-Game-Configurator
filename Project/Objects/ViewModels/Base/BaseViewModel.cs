using PropertyChanged;
using System.ComponentModel;

namespace Universal_Game_Configurator.Objects.ViewModels.Base {

    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}
