using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Universal_Game_Configurator {
    public class GamesUtil {

        public static Games DeserializeDatabase() {
            XmlSerializer serializer = new XmlSerializer(typeof(Games));
            StreamReader reader = new StreamReader(Paths.GAMESLIST_PATH);
            Games games = null;
            games = (Games)serializer.Deserialize(reader);

            return games;
        }

        public static List<Game> GetInstalledGames(List<Game> database) {
            ArrayList games = new ArrayList();
            ArrayList.Synchronized(games);

            database.AsParallel().ForAll((Game g) => {
                if (!String.IsNullOrEmpty(g.InstallPath)) {
                    lock (games.SyncRoot) {
                        games.Add(g);
                    }
                }
            });

            return games.Cast<Game>().ToList();
        }

    }
}
