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

        // GET: /buyer
        [HttpGet]
        public IEnumerable<Game> Get()
        {
            return gl.GetAll();
        }

        // GET /buyer/5
        [HttpGet("{name}")]
        public Game Get(int id)
        {
            return gl.Read(id);
        }

        // POST /car
        [HttpPost]
        public void Post([FromBody] Game value)
        {
            gl.Create(value);
        }

        // PUT /car
        [HttpPut]
        public void Put([FromBody] Game value)
        {
            gl.Update(value);
        }

        // DELETE car/5
        [HttpDelete("{name}")]
        public void Delete(int id)
        {
            gl.Delete(id);
        }
    }
}
