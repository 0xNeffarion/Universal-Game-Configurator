using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Universal_Game_Configurator {
    public class GameViewModel : BaseViewModel {

        public GameViewModel(int id, string name, Configurator configurator, Genres genres, string imageName, string installPath) {
            Initialize(id, name, configurator, genres, imageName, installPath);
        }

        public int Id { get; set; }

        public String Name { get; set; }

        public Configurator Configurator { get; set; }

        public Genres Genres { get; set; }

        public String ImageName { get; set; }

        public String InstallPath { get; set; }

        private void Initialize(int id, string name, Configurator configurator, Genres genres, string imageName, string installPath) {
            this.Id = id;
            this.Name = name;
            this.Configurator = configurator;
            this.Genres = genres;
            this.ImageName = imageName;
            this.InstallPath = installPath;
        }

    }
}
