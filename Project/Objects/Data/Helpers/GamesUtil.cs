using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Universal_Game_Configurator.Const;
using Universal_Game_Configurator.Objects.Data.Databases;
using Universal_Game_Configurator.Util;

namespace Universal_Game_Configurator.Objects.Data.Helpers {
    public class GamesUtil {

        private static GamesDatabase DeserializeDatabase() {
            return Serialization.Deserialize<GamesDatabase>(Paths.GAMESLIST_PATH);
        }

        public static List<Game> GetInstalledGames() {
            List<Game> database = DeserializeDatabase().Games;

            ArrayList games = new ArrayList();
            ArrayList.Synchronized(games);
            Console.WriteLine("Searching installed games...");
            database.AsParallel().ForAll((Game g) => {
                if (!String.IsNullOrEmpty(g.InstallPath)) {
                    lock (games.SyncRoot) {
                        games.Add(g);
                    }
                    Console.WriteLine(String.Format("Found game. Name: {0}. Directory: {1}", g.Name, g.InstallPath));
                }
            });

            return games.Cast<Game>().ToList();
        }

    }
}
