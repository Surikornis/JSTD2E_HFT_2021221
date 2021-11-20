﻿using JSTD2E_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSTD2E_HFT_2021221.Logic
{
    interface IBuyerLogic
    {
        void Create(Buyer buyer);
        void Delete(string name);
        IEnumerable<Buyer> GetAll();
        Buyer Read(string name);
        void Update(Buyer buyer);
    }
}