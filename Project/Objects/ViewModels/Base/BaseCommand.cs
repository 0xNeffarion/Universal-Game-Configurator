﻿using System;
using System.Windows.Input;

namespace Universal_Game_Configurator {
    public class BaseCommand : ICommand {

        private Action baseAction;

        public BaseCommand(Action action) {
            this.baseAction = action;
        }

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {
            baseAction();
        }
    }
}
