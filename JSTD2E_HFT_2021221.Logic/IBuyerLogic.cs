using JSTD2E_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSTD2E_HFT_2021221.Logic
{
    public interface IBuyerLogic
    {
        void Create(Buyer buyer);
        void Delete(int id);
        IEnumerable<Buyer> GetAll();
        Buyer Read(int id);
        void Update(Buyer buyer);
        double AvgAge();
    }
}
