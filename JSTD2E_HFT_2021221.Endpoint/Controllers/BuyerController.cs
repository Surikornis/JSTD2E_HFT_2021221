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
    public class BuyerController : ControllerBase
    {

        IBuyerLogic bl;
        IHubContext<SignalRHub> hub;

        public BuyerController(IBuyerLogic bl, IHubContext<SignalRHub> hub)
        {
            this.bl = bl;
            this.hub = hub;
        }

        // GET: /buyer
        [HttpGet]
        public IEnumerable<Buyer> Get()
        {
            return bl.GetAll();
        }

        // GET /buyer/5
        [HttpGet("{id}")]
        public Buyer Get(int id)
        {
            return bl.Read(id);
        }

        // POST /car
        [HttpPost]
        public void Post([FromBody] Buyer value)
        {
            bl.Create(value);
            this.hub.Clients.All.SendAsync("BuyerCreated", value);
        }

        // PUT /car
        [HttpPut]
        public void Put([FromBody] Buyer value)
        {
            bl.Update(value);
            this.hub.Clients.All.SendAsync("BuyerUpdated", value);
        }

        // DELETE car/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var buyerToDelete = bl.Read(id);
            bl.Delete(id);
            this.hub.Clients.All.SendAsync("BuyerDeleted", buyerToDelete);
        }
    }
}
