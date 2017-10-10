using System;

namespace TownManager {
    public static class RndPicker {
        private static Random rnd = new Random();

        public static Random Rnd { get { return rnd; } }
    }
}