using JSTD2E_HFT_2021221.Models;
using JSTD2E_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSTD2E_HFT_2021221.Logic
{
    public class DeveloperLogic : IDeveloperTeamLogic
    {
        IDeveloperTeamRepository devRepo;

        public DeveloperLogic(IDeveloperTeamRepository devRepo)
        {
            this.devRepo = devRepo;
        }
        public void Create(DeveloperTeam devteam)
        {
            if (devteam.DateofFoundation > DateTime.Now.Year)
            {
                throw new Exception("Invalid fundation date");
            }
            devRepo.Create(devteam);
        }

        public void Delete(int id)
        {
            devRepo.Delete(id);
        }

        public IEnumerable<DeveloperTeam> GetAll()
        {
            return devRepo.GetAll();
        }

        public DeveloperTeam Read(int id)
        {
            return devRepo.Read(id);
        }

        public void Update(DeveloperTeam devteam)
        {
            devRepo.Update(devteam);
        }
        
        public int Latest()
        {
            return devRepo.GetAll().Max(t => t.DateofFoundation);
        }
    }
}