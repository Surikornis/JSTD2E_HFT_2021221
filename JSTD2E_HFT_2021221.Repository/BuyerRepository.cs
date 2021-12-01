using JSTD2E_HFT_2021221.Data;
using JSTD2E_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSTD2E_HFT_2021221.Repository
{
    public class BuyerRepository : IBuyerRepository
    {
        ModelsDbContext mdb;

        public BuyerRepository(ModelsDbContext mdb)
        {
            this.mdb = mdb;
        }
        public void Create(Buyer buyer)
        {
            mdb.Buyers.Add(buyer);
            mdb.SaveChanges();
        }

        public void Delete(int id)
        {
            var buyerToDelete = Read(id);
            mdb.Buyers.Remove(buyerToDelete);
            mdb.SaveChanges();
        }

        public IQueryable<Buyer> GetAll()
        {
            return mdb.Buyers;
        }

        public Buyer Read(int id)
        {
            return mdb.Buyers.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Buyer buyer)
        {
            var buyerToUpdate = Read(buyer.Id);
            buyerToUpdate.Name = buyer.Name;
            buyerToUpdate.Age = buyer.Age;
            buyerToUpdate.DateofPurchase = buyer.DateofPurchase;
            mdb.SaveChanges();
        }
    }
}
