using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_Game_Configurator.Configurators {
    public interface Configurator {
        List<String> Files { get; set; }

        void WriteValue(Config cf);

        String ReadValue(String variable, String section = "", short index = 0);

        String ReadValue(Config cg);

    }
}
