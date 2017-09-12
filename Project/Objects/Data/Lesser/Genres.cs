using System.Text;

namespace Universal_Game_Configurator.Objects.Data.Lesser {
    public class Genres {

        public Genre[] genres;

        public Genres(params Genre[] g) {
            genres = g;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < genres.Length; i++) {
                sb.Append(genres[i]).Append(@"/");
            }

            return sb.ToString();
        }
    }
}
