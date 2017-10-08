using System;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace Universal_Game_Configurator.Util.Tools {

    public static class GithubTools {

        public const String DATA_REPONAME = "UCG-Data";

        private const String OWNER = "0xNeffarion";

        private static String GetResponse(String RepoName) {
            String url = String.Format("https://github.com/{0}/{1}/releases/latest", OWNER, RepoName);
            String output = null;
            HttpWebRequest webReq = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            webReq.Method = "GET";
            webReq.Timeout = 6000;
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

        private static String ReadVersion(String RepoName) {
            String response = GetResponse(RepoName);
            if (String.IsNullOrEmpty(response)) {
                return null;
            }

            String[] res = Regex.Split(response, "<div class=\"release-meta\">");
            String[] res1 = Regex.Split(res[1], "<ul class=\"tag-references\">");
            String[] res2 = Regex.Split(res1[1], "<span class=\"css-truncate-target\">");
            String result = Regex.Split(res2[1], "</span>")[0].Trim();

            return result;
        }

        private static String ReadReleaseDownload(String RepoName) {
            String response = GetResponse(RepoName);
            if (String.IsNullOrEmpty(response)) {
                return null;
            }

            String[] res = Regex.Split(response, "<ul class=\"release-downloads\">");
            String[] res1 = Regex.Split(res[1], "<li>");
            String[] res2 = Regex.Split(res1[1], "<a href=");
            String result = Regex.Split(res2[1], "rel=\"nofollow\">")[0].Trim();

            return "https://github.com" + (result.Replace("\"", "").Trim());
        }

        public static Version GetLastVersion(String repositoryName) {
            return Version.Parse(ReadVersion(repositoryName).Substring(1));
        }

        public static String GetLastRelease(String repositoryName) {
            return ReadReleaseDownload(repositoryName);
        }

    }
}
