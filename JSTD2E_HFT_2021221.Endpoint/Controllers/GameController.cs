using JSTD2E_HFT_2021221.Logic;
using JSTD2E_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsDb.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        IGameLogic gl;

        public GameController(IGameLogic gl)
        {
            this.gl = gl;
        }

        // GET: /game
        [HttpGet]
        public IEnumerable<Game> Get()
        {
            return gl.GetAll();
        }

        // GET /game/5
        [HttpGet("{id}")]
        public Game Get(int id)
        {
            return gl.Read(id);
        }

        // POST /game
        [HttpPost]
        public void Post([FromBody] Game value)
        {
            gl.Create(value);
        }

        // PUT /game
        [HttpPut]
        public void Put([FromBody] Game value)
        {
            gl.Update(value);
        }

        // DELETE game/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            gl.Delete(id);
        }
    }
}
