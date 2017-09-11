using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Universal_Game_Configurator {
    public class GamesCollectionViewModel : BaseViewModel {

        public ObservableCollection<GameViewModel> games { get; set; }

        public GamesCollectionViewModel() {
            Games database = GamesUtil.DeserializeDatabase();

            List<Game> gamesList = GamesUtil.GetInstalledGames(database.GamesList);

            this.games = new ObservableCollection<GameViewModel>(gamesList.Select(g => new GameViewModel(g.Id, g.Name, g.Configurator, new Genres(g.Genres), g.ImageName, g.InstallPath)));
        }



    }
}
