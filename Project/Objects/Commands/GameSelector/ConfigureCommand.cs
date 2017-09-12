using System;
using System.Windows.Input;
using Universal_Game_Configurator.Objects.Data;

namespace Universal_Game_Configurator.Objects.Commands.GameSelector {
    public class ConfigureCommand : ICommand {

        private Action action { get; set; }

        public ConfigureCommand(Action action = null) {
            this.action = action;
        }

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {
            Game g = (Game)parameter;
            if (g != null) {
                MainWindow mw = new MainWindow(g);
                mw.Show();
                this.action();
            }
        }
    }
}
