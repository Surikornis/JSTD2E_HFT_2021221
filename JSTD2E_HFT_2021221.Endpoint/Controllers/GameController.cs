using JSTD2E_HFT_2021221.Endpoint.Services;
using JSTD2E_HFT_2021221.Logic;
using JSTD2E_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        IHubContext<SignalRHub> hub;

        public GameController(IGameLogic gl, IHubContext<SignalRHub> hub)
        {
            this.gl = gl;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("GameCreated", value);
        }

        // PUT /game
        [HttpPut]
        public void Put([FromBody] Game value)
        {
            gl.Update(value);
            this.hub.Clients.All.SendAsync("GameUpdated", value);
        }

        // DELETE game/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var gameToDelete = gl.Read(id);
            gl.Delete(id);
            this.hub.Clients.All.SendAsync("GameDeleted", gameToDelete);
        }
    }
}
