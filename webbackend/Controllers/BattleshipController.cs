using Microsoft.AspNetCore.Mvc;
using webbackend.Game;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattleshipController : ControllerBase
    {
        // GET: api/<BattleshipController>
        [HttpGet]
        public BattleshipDataModel Get()
        {
            var data = new BattleshipDataModel
            {
                BoardData = BattleshipGameWeb.Game.GridDataForWeb(),
                IsGameEnd = BattleshipGameWeb.Game.isGameEnd(),
                Message = ""
            };
            return data;
        }

        // GET api/<BattleshipController>/5
        [HttpGet("{row}/{col}")]
        public BattleshipDataModel Get(int row, int col)
        {
            var msg = BattleshipGameWeb.Game.Fire(row, col);

            var data = new BattleshipDataModel
            {
                BoardData = BattleshipGameWeb.Game.GridDataForWeb(),
                IsGameEnd = BattleshipGameWeb.Game.isGameEnd(),
                Message = msg
            };
            return data;
        }
    }
}
