﻿using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BattleshipController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BattleshipController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BattleshipController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}