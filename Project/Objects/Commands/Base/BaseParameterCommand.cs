using System;
using System.Windows.Input;

namespace Universal_Game_Configurator.Objects.Commands.Base {
    public class BaseParameterCommand<Object> : ICommand {

        private readonly Action<Object> baseAction;

        public BaseParameterCommand(Action<Object> action) {
            this.baseAction = action;
        }

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {
            if (this.baseAction != null) {
                baseAction.Invoke((Object)parameter);
            }
        }
    }
}
