using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_Game_Configurator {
    public static class CollectionTools {

        /// <summary>
        /// Randomize List elements
        /// </summary>
        /// <typeparam name="T">List type</typeparam>
        /// <param name="source">The list</param>
        /// <returns>Randomized list</returns>
        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source) {
            var rnd = new Random();
            return source.OrderBy(item => rnd.Next());
        }

    }
}
