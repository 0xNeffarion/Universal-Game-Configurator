using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace Universal_Game_Configurator.Util.Tools {


    public static class GithubTools {

        private const String OWNER = "0xNeffarion";
        private const String REPO = "CELO-Enhanced";
        private static readonly String API_RELEASES_URL = String.Format("https://github.com/{0}/{1}/releases/latest", OWNER, REPO);

        private static String GetResponse() {
            String url = String.Format(API_RELEASES_URL);
            String output = null;
            HttpWebRequest webReq = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            webReq.Method = "GET";
            webReq.Timeout = 5000;
            HttpWebResponse resp = (HttpWebResponse)webReq.GetResponse();
            using (resp) {
                Stream stream = resp.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                output = sr.ReadToEnd().Trim();

                sr.Close();
                stream.Close();
            }

            return output;
        }

        private static String ReadVersion() {
            String response = GetResponse();
            if (String.IsNullOrEmpty(response)) {
                return null;
            }
            String[] res = Regex.Split(response, "<div class=\"release-meta\">");
            String[] res1 = Regex.Split(res[1], "<ul class=\"tag-references\">");
            String[] res2 = Regex.Split(res1[1], "<span class=\"css-truncate-target\">");
            String result = Regex.Split(res2[1], "</span>")[0].Trim();

            return result;
        }

        public static Version GetLastVersion() {
            String webVersion = ReadVersion().Substring(1);
            return Version.Parse(webVersion);
        }

    }
}
