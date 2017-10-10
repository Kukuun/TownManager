namespace TownManager {
    interface State {
        void Enter(Group g);
        void Execute(Group g);
        void Exit(Group g);
    }
}