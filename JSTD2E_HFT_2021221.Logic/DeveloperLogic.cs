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
            // need to test if checks well 🠗
            if (devteam.DateofFoundation > DateTime.Now.Year)
            {
                throw new Exception("Invalid fundation date");
            }
            devRepo.Create(devteam);
        }

        public void Delete(string devteam)
        {
            devRepo.Delete(devteam);
        }

        public IEnumerable<DeveloperTeam> GetAll()
        {
            return devRepo.GetAll();
        }

        public DeveloperTeam Read(string devteam)
        {
            return devRepo.Read(devteam);
        }

        public void Update(DeveloperTeam devteam)
        {
            devRepo.Update(devteam);
        }

        public IEnumerable<KeyValuePair<string, IEnumerable<string>>> LengthCheck()
        {
            return from x in devRepo.GetAll()
                   group x by x.DevTeam into g
                   select new KeyValuePair<string, IEnumerable<string>>
                   (g.Key, g.Select(t => t.DevTeam).Where(t => t.Length < 20));

        }
        // the companies which were founded after 2005
        public IEnumerable<KeyValuePair<string, IEnumerable<string>>> Foundation()
        {
            return from x in devRepo.GetAll()
                   group x by x.DevTeam into g
                   select new KeyValuePair<string, IEnumerable<string>>
                   (g.Key, g.Where(t => t.DateofFoundation > 2005).Select(t => t.DevTeam));
        }
    }
}