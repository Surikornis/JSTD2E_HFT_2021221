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
    public class DeveloperTeamController : ControllerBase
    {
        IDeveloperTeamLogic dl;

        public DeveloperTeamController(IDeveloperTeamLogic dl)
        {
            this.dl = dl;
        }

        // GET: /buyer
        [HttpGet]
        public IEnumerable<DeveloperTeam> Get()
        {
            return dl.GetAll();
        }

        // GET /buyer/5
        [HttpGet("{name}")]
        public DeveloperTeam Get(string name)
        {
            return dl.Read(name);
        }

        // POST /car
        [HttpPost]
        public void Post([FromBody] DeveloperTeam value)
        {
            dl.Create(value);
        }

        // PUT /car
        [HttpPut]
        public void Put([FromBody] DeveloperTeam value)
        {
            dl.Update(value);
        }

        // DELETE car/5
        [HttpDelete("{name}")]
        public void Delete(string name)
        {
            dl.Delete(name);
        }
    }
}
