using System;
using System.Collections.Generic;

namespace Universal_Game_Configurator {

    public abstract class Configurator {

        public List<String> Files { get; set; }

        public Configurator(List<String> Files) {
            this.Files = Files;
        }

        public abstract void WriteValue(ConfigEntry cf);

        public abstract String ReadValue(ConfigEntry cf);

        public abstract String ReadValue(String variable, String section = "", short index = 0);

    }
}
