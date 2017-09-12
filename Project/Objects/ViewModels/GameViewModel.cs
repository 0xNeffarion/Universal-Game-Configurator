using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Universal_Game_Configurator.Objects.Commands.Base;
using Universal_Game_Configurator.Objects.Commands.GameSelector;
using Universal_Game_Configurator.Objects.Data;
using Universal_Game_Configurator.Objects.Data.Helpers;
using Universal_Game_Configurator.Objects.ViewModels.Base;

namespace Universal_Game_Configurator.Objects.ViewModels {
    public class GameViewModel : BaseViewModel {

        public ObservableCollection<Game> Games { get; set; }

        public ICommand ConfigureCommand { get; set; }

        public ICommand GetGamesCommand { get; set; }

        public Action CloseWindowAction { get; set; }

        public GameViewModel() {
            ConfigureCommand = new ConfigureCommand(Configure);
            GetGamesCommand = new BaseCommand(GetGames);
            GetGames();
        }

        private void Configure() {
            CloseWindowAction();
        }

        private void GetGames() {
            Games = new ObservableCollection<Game>(GamesUtil.GetInstalledGames());
        }



    }
}
