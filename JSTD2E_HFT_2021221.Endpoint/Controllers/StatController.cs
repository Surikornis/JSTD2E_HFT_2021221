using JSTD2E_HFT_2021221.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsDb.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IBuyerLogic bl;
        IDeveloperTeamLogic dl;
        IGameLogic gl; // hf

        public StatController(IBuyerLogic bl, IDeveloperTeamLogic dl, IGameLogic gl)
        {
            this.bl = bl;
            this.dl = dl;
            this.gl = gl;
        }

        // GET: stat/avgage
        [HttpGet]
        public double AvgAge()
        {
            return bl.AvgAge();
        }

        // GET: stat/latest
        [HttpGet]
        public int Latest()
        {
            return dl.Latest();
        }

        // GET: stat/expensive
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> Expensive()
        {
            return gl.Expensive();
        }

        // GET: stat/list
        [HttpGet]
        public List<string> List()
        {
            return gl.List();
        }

        // GET: stat/averageprice
        [HttpGet]
        public double AveragePrice()
        {
            return gl.AveragePrice();
        }
    }
}
