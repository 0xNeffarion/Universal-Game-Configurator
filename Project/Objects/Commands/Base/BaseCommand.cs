using System;
using System.Windows.Input;

namespace Universal_Game_Configurator.Objects.Commands.Base {
    public class BaseCommand : ICommand {

        private readonly Action baseAction;

        public BaseCommand(Action action) {
            this.baseAction = action;
        }

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {
            if (this.baseAction != null) {
                baseAction.Invoke();
            }
        }
    }
}
