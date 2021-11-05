using JSTD2E_HFT_2021221.Data;
using JSTD2E_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSTD2E_HFT_2021221.Repository
{
    public class GameRepository : IGameRepository
    {
        ModelsDbContext mdb;

        public GameRepository(ModelsDbContext mdb)
        {
            this.mdb = mdb;
        }

        public void Create(Game game)
        {
            mdb.Games.Add(game);
            mdb.SaveChanges();
        }

        public void Delete(string gameName)
        {
            var gameToDelete = Read(gameName);
            mdb.Games.Remove(gameToDelete);
            mdb.SaveChanges();
        }

        public IQueryable<Game> GetAll()
        {
            return mdb.Games;
        }

        public Game Read(string gameName)
        {
            return mdb.Games.FirstOrDefault(x => x.GameName == gameName);
        }

        public void Update(Game game)
        {
            var gameToUpdate = Read(game.GameName);
            gameToUpdate.GameName = game.GameName;
            mdb.SaveChanges();
        }
    }
}
