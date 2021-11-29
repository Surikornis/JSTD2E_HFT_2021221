using JSTD2E_HFT_2021221.Models;
using System.Linq;

namespace JSTD2E_HFT_2021221.Repository
{
    public interface IBuyerRepository
    {
        void Create(Buyer buyer);
        void Delete(int id);
        IQueryable<Buyer> GetAll();
        Buyer Read(int id);
        void Update(Buyer buyer);
    }
}
