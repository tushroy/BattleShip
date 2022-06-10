namespace webbackend
{
    public class BattleshipDataModel
    {
        public bool IsGameEnd { get; set; }
        public string? Message { get; set; }
        public char[,]? BoardData { get; set; }
    }
}
