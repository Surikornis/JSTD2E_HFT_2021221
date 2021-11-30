using JSTD2E_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSTD2E_HFT_2021221.Logic
{
    public interface IDeveloperTeamLogic
    {
        void Create(DeveloperTeam devteam);
        void Delete(int id);
        IEnumerable<DeveloperTeam> GetAll();
        DeveloperTeam Read(int id);
        void Update(DeveloperTeam devteam);
        public int Latest();
    }
}
