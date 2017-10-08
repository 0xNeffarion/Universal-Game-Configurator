using System;
using System.Windows.Forms;
using System.Windows.Input;
using Universal_Game_Configurator.Objects.Commands.Base;
using Universal_Game_Configurator.Objects.ViewModels.Base;

namespace Universal_Game_Configurator.Editor.ViewModels {
    public class MainEditorViewModel : BaseViewModel {

        public String GamesPath { get; set; }

        public String ConfigPath { get; set; }

        public String DescriptionsPath { get; set; }

        public ICommand EditGames { get; set; }

        public ICommand EditDescriptions { get; set; }

        public ICommand EditConfig { get; set; }

        public ICommand NewGame { get; set; }

        public ICommand BrowseCommand { get; set; }

        public MainEditorViewModel() {
            EditGames = new BaseCommand(EditGamesAction);
            EditDescriptions = new BaseCommand(EditDescriptionsAction);
            EditConfig = new BaseCommand(EditConfigAction);
            NewGame = new BaseParameterCommand<Object>(BrowseAction);
            GetSettings();
        }

        private void GetSettings() {
            GamesPath = Settings.EditorPathGames;
            ConfigPath = Settings.EditorPathConfig;
            DescriptionsPath = Settings.EditorPathDescription;
        }

        private void EditGamesAction() {

        }

        private void EditDescriptionsAction() {

        }

        private void EditConfigAction() {

        }

        private void NewGameAction() {

        }

        private void BrowseAction(Object param) {
            if (param == null) {
                return;
            }

            System.Windows.Controls.Button btn = (System.Windows.Controls.Button)param;
            int tag = Int32.Parse((String)btn.Tag);
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.CheckFileExists = true;
            dialog.Multiselect = false;
            String path = "";
            if (dialog.ShowDialog() != DialogResult.OK) {
                return;
            } else {
                path = dialog.FileName;
            }

            if (tag == 0) {
                GamesPath = path;
            } else if (tag == 1) {
                ConfigPath = path;
            } else if (tag == 2) {
                DescriptionsPath = path;
            }

        }

    }
}
