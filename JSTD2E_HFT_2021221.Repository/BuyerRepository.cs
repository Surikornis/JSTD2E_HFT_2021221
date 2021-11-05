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

        public void Delete(string name)
        {
            var buyerToDelete = Read(name);
            mdb.Buyers.Remove(buyerToDelete);
            mdb.SaveChanges();
        }

        public IQueryable<Buyer> GetAll()
        {
            return mdb.Buyers;
        }

        public Buyer Read(string name)
        {
            return mdb.Buyers.FirstOrDefault(x => x.Name == name);
        }

        public void Update(Buyer buyer)
        {
            var buyerToUpdate = Read(buyer.Name);
            buyerToUpdate.Name = buyer.Name;
            mdb.SaveChanges();
        }
    }
}
