using JSTD2E_HFT_2021221.Models;
using System.Linq;

namespace JSTD2E_HFT_2021221.Repository
{
    public interface IDeveloperTeamRepository
    {
        void Create(DeveloperTeam devteam);
        void Delete(int id);
        IQueryable<DeveloperTeam> GetAll();
        DeveloperTeam Read(int id);
        void Update(DeveloperTeam devteam);
    }
}
