using BattleShipClasses;

namespace webbackend.Game
{
    public static class BattleshipGameWeb
    {
        public static BattleShipGame Game = new BattleShipGame();
        public static void ResetGame()
        {
            Game = new BattleShipGame();
        }
    }
}
