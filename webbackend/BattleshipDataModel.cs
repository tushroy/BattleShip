namespace webbackend
{
    /// <summary>
    /// Data model class for json output
    /// </summary>
    public class BattleshipDataModel
    {
        public bool IsGameEnd { get; set; }
        public string? Message { get; set; }
        public List<List<char>>? BoardData { get; set; }
    }
}
