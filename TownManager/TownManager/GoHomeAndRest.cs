using System;

namespace TownManager {
    class GoHomeAndRest : State {
        public void Enter(Group g) {
            g.Log += "The group comes home to rest!" + Environment.NewLine;
        }

        public void Execute(Group g) {
            g.Log += "The group rests up in the infirmary" + Environment.NewLine;

            g.GroupCurrentHp = g.GroupHp;

            g.BecomeAvailable();

        }

        public void Exit(Group g) {//Rettet
            g.Log += "The group is now rested and ready for more adventure!" + Environment.NewLine;
        }
    }
}