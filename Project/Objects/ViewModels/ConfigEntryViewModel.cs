using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using Universal_Game_Configurator.Configurators;
using Universal_Game_Configurator.Objects.Commands.Base;
using Universal_Game_Configurator.Objects.Data;
using Universal_Game_Configurator.Objects.Data.Helpers;
using Universal_Game_Configurator.Objects.ViewModels.Base;

namespace Universal_Game_Configurator.Objects.ViewModels {
    public class ConfigEntryViewModel : BaseViewModel {

        private String _initialValue { get; set; }


        #region Window Commands

        public ICommand CloseWindowCommand { get; set; }

        public ICommand MinimizeWindowCommand { get; set; }

        public ICommand GoBackToSelectorCommand { get; set; }

        #region Window Actions/Functions

        public void CloseWindow(Object param) {
            Window win = param as Window;
            if (win == null) {
                return;
            }

            DoubleAnimation anim = new DoubleAnimation(0, TimeSpan.FromMilliseconds(200 * Settings.AnimationMult));
            anim.Completed += (s, _) => win.Close();
            win.BeginAnimation(UIElement.OpacityProperty, anim);
        }

        public void MinimizeWindow(Object param) {
            Window win = param as Window;
            if (win == null) {
                return;
            }

            win.WindowState = WindowState.Minimized;
        }

        public void GoBackToSelector(Object param) {
            Window win = param as Window;
            if (win == null) {
                return;
            }

            GameSelector gs = new GameSelector();
            DoubleAnimation anim = new DoubleAnimation(0, TimeSpan.FromMilliseconds(200 * Settings.AnimationMult));
            anim.Completed += (s, _) => {
                win.Close();
                gs.Show();
                gs.Activate();
            };
            win.BeginAnimation(UIElement.OpacityProperty, anim);
        }

        #endregion

        #endregion

    }
}
