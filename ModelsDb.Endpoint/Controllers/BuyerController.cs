﻿using JSTD2E_HFT_2021221.Logic;
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
    public class BuyerController : ControllerBase
    {

        IBuyerLogic bl;

        public BuyerController(IBuyerLogic bl)
        {
            this.bl = bl;
        }

        // GET: /buyer
        [HttpGet]
        public IEnumerable<Buyer> Get()
        {
            return bl.GetAll();
        }

        // GET /buyer/5
        [HttpGet("{name}")]
        public Buyer Get(string name)
        {
            return bl.Read(name);
        }

        // POST /car
        [HttpPost]
        public void Post([FromBody] Buyer value)
        {
            bl.Create(value);
        }

        // PUT /car
        [HttpPut]
        public void Put([FromBody] Buyer value)
        {
            bl.Update(value);
        }

        // DELETE car/5
        [HttpDelete("{name}")]
        public void Delete(string name)
        {
            bl.Delete(name);
        }
    }
}
