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
    public class DeveloperTeamController : ControllerBase
    {
        IDeveloperTeamLogic dl;
        IHubContext<SignalRHub> hub;

        public DeveloperTeamController(IDeveloperTeamLogic dl, IHubContext<SignalRHub> hub)
        {
            this.dl = dl;
            this.hub = hub;
        }

        // GET: /developerteam
        [HttpGet]
        public IEnumerable<DeveloperTeam> Get()
        {
            return dl.GetAll();
        }

        // GET /developerteam/5
        [HttpGet("{id}")]
        public DeveloperTeam Get(int id)
        {
            return dl.Read(id);
        }

        // POST /developerteam
        [HttpPost]
        public void Post([FromBody] DeveloperTeam value)
        {
            dl.Create(value);
            this.hub.Clients.All.SendAsync("DeveloperTeamCreated", value);
        }

        // PUT /developerteam
        [HttpPut]
        public void Put([FromBody] DeveloperTeam value)
        {
            dl.Update(value);
            this.hub.Clients.All.SendAsync("DeveloperTeamUpdated", value);
        }

        // DELETE developerteam/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var devteamToDelete = dl.Read(id);
            dl.Delete(id);
            this.hub.Clients.All.SendAsync("DeveloperTeamDeleted", devteamToDelete);
        }
    }
}
