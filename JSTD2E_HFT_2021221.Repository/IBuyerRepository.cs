using JSTD2E_HFT_2021221.Models;
using System.Linq;

namespace JSTD2E_HFT_2021221.Repository
{
    public interface IBuyerRepository
    {
        void Create(Buyer buyer);
        void Delete(string name);
        IQueryable<Buyer> GetAll();
        Buyer Read(string name);
        void Update(Buyer buyer);
    }
}
