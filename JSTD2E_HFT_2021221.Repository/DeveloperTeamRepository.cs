using JSTD2E_HFT_2021221.Data;
using JSTD2E_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSTD2E_HFT_2021221.Repository
{
    public class DeveloperTeamRepository : IDeveloperTeamRepository
    {
        ModelsDbContext mdb;

        public DeveloperTeamRepository(ModelsDbContext mdb)
        {
            this.mdb = mdb;
        }

        public void Create(DeveloperTeam devteam)
        {
            mdb.DeveloperTeam.Add(devteam);
            mdb.SaveChanges();
        }

        public void Delete(int id)
        {
            var devteamToDelete = Read(id);
            mdb.DeveloperTeam.Remove(devteamToDelete);
            mdb.SaveChanges();
        }

        public IQueryable<DeveloperTeam> GetAll()
        {
            return mdb.DeveloperTeam;
        }

        public DeveloperTeam Read(int id)
        {
            return mdb.DeveloperTeam.FirstOrDefault(x => x.Id == id);
        }

        public void Update(DeveloperTeam devteam)
        {
            var devteamToUpdate = Read(devteam.Id);
            devteamToUpdate.DevTeam = devteam.DevTeam;
            mdb.SaveChanges();
        }
    }
}
