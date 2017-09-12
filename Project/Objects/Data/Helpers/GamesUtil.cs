using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Universal_Game_Configurator.Const;
using Universal_Game_Configurator.Objects.Data.Databases;

namespace Universal_Game_Configurator.Objects.Data.Helpers {
    public class GamesUtil {

        private static GamesDatabase DeserializeDatabase() {
            XmlSerializer serializer = new XmlSerializer(typeof(GamesDatabase));
            StreamReader reader = new StreamReader(Paths.GAMESLIST_PATH);
            GamesDatabase games = null;
            games = (GamesDatabase)serializer.Deserialize(reader);

            return games;
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
                    Console.WriteLine("Found game. Name: " + g.Name);
                }
            });
            Console.WriteLine("Finished finding games");

            return games.Cast<Game>().ToList();
        }

    }
}
