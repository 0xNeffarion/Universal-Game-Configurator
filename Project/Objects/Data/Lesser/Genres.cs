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
                if (i != (genres.Length - 1)) {
                    sb.Append(genres[i]).Append(@"/");
                } else {
                    sb.Append(genres[i]);
                }
            }

            return sb.ToString();
        }
    }
}
