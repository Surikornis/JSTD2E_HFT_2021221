using JSTD2E_HFT_2021221.Models;
using JSTD2E_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JSTD2E_HFT_2021221.Logic
{
    public class BuyerLogic : IBuyerLogic
    {
        IBuyerRepository buyerRepo;

        public BuyerLogic(IBuyerRepository buyerRepo)
        {
            this.buyerRepo = buyerRepo;
        }
        public void Create(Buyer buyer)
        {
            if (buyer.Age < 18)
            {
                throw new Exception("Restricted age");
            }
            buyerRepo.Create(buyer);
        }

        public void Delete(int id)
        {
            buyerRepo.Delete(id);
        }

        public IEnumerable<Buyer> GetAll()
        {
            return buyerRepo.GetAll();
        }

        public Buyer Read(int id)
        {
            return buyerRepo.Read(id);
        }

        public void Update(Buyer buyer)
        {
            buyerRepo.Update(buyer);
        }

        public double AvgAge()
        {
            return buyerRepo.GetAll().Average(t => t.Age);
        }
    }
}
