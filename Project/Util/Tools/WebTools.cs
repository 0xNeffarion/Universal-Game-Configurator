using System;
using System.Net;
using System.Net.NetworkInformation;

namespace Universal_Game_Configurator {
    public class WebTools {

        /// <summary>
        /// Check for internet connection
        /// </summary>
        /// <returns>true if internet connection is available</returns>
        public static bool CheckInternet() {
            try {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("www.google.com")) {
                    return true;
                }
            } catch {
                return false;
            }
        }

        /// <summary>
        /// Checks if website loads correctly
        /// </summary>
        /// <param name="url">website to load</param>
        /// <param name="timeoutMs">connection timeout in milliseconds</param>
        /// <returns>True if connection is good, false if something is not right</returns>
        public static bool CheckWebSiteLoad(string url, int timeoutMs = 8000) {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = timeoutMs;
            request.Method = "GET";
            try {
                var res = (HttpWebResponse)request.GetResponse();
                if (res.StatusCode == HttpStatusCode.OK) {
                    return true;
                }
            } catch (Exception) {
                return false;
            }


            return false;
        }

        /// <summary>
        ///     Pings an url
        /// </summary>
        /// <param name="url">domain to ping</param>
        /// <returns>true if any ping returns otherwise false</returns>
        public static bool PingDomain(string url) {
            var result = new Ping().Send(url);

            return result.Status == IPStatus.Success;
        }

    }
}
