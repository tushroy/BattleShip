using BattleShipClasses;

namespace webbackend.Game
{
    /// <summary>
    /// Static class to hold game data
    /// </summary>
    public static class BattleshipGameWeb
    {
        public static BattleShipGame Game = new BattleShipGame();
        public static void ResetGame() // reset the game
        {
            Game = new BattleShipGame();
        }
    }
}
