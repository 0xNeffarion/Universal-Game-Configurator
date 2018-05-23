using System;

namespace Universal_Game_Configurator.Util {
    public static class Calculations {

        public static double BytesToKBytes(long bytes) {
            return Math.Round((double)bytes / 1024, 2, MidpointRounding.AwayFromZero);
        }

        public static double BytesToMBytes(long bytes) {
            return Math.Round((double)(bytes / 1024) / 1024, 2, MidpointRounding.AwayFromZero);
        }

        public static double BytesToGBytes(long bytes) {
            return Math.Round((double)((bytes / 1024) / 1024) / 1024, 2, MidpointRounding.AwayFromZero);
        }


    }
}
