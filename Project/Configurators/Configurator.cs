using System;
using System.Collections.Generic;
using System.Linq;
using Universal_Game_Configurator.Objects.Data;
using Universal_Game_Configurator.Objects.Data.Lesser;

namespace Universal_Game_Configurator.Configurators {

    public abstract class Configurator {
        public List<String> Files { get; set; }

        public Configurator(List<ConfigFile> Files, String InstallPath) {
            this.Files = new List<String>(Files.Select(c => c.TruePath(InstallPath)));
        }

        public abstract void WriteValue(ConfigEntry cf);

        public abstract String ReadValue(ConfigEntry cf);

        public abstract String ReadValue(String variable, String section = "", short index = 0);

    }
}
