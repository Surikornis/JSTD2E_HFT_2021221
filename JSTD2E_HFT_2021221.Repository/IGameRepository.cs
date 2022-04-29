using JSTD2E_HFT_2021221.Models;
using System.Linq;

namespace JSTD2E_HFT_2021221.Repository
{
    public interface IGameRepository
    {
        void Create(Game game);
        void Delete(int id);
        IQueryable<Game> GetAll();
        Game Read(int id);
        void Update(Game game);
    }
}
