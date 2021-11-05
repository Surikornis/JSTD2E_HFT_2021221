using JSTD2E_HFT_2021221.Models;
using System.Linq;

namespace JSTD2E_HFT_2021221.Repository
{
    public interface IDeveloperTeamRepository
    {
        void Create(DeveloperTeam devteam);
        void Delete(string devteam);
        IQueryable<DeveloperTeam> GetAll();
        DeveloperTeam Read(string devteam);
        void Update(DeveloperTeam devteam);
    }
}
