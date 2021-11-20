using JSTD2E_HFT_2021221.Models;
using JSTD2E_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSTD2E_HFT_2021221.Logic
{
    class GameLogic : IGameLogic
    {
        IGameRepository gameRepo;
        public GameLogic(IGameRepository gameRepo)
        {
            this.gameRepo = gameRepo;
        }

        public void Create(Game game)
        {
            if (game.GameName == null)
            {
                throw new ArgumentNullException("Game must have a name");
            }
            gameRepo.Create(game);
        }

        public void Delete(string gameName)
        {
            gameRepo.Delete(gameName);
        }

        public IEnumerable<Game> GetAll()
        {
            return gameRepo.GetAll();
        }

        public Game Read(string gameName)
        {
            return gameRepo.Read(gameName);
        }

        public void Update(Game game)
        {
            gameRepo.Update(game);
        }

        // gives back the most expensive game the buyer have purchased
        // check this one again
        public IEnumerable<KeyValuePair<List<Game>, string>> Oldest()
        {
            return from x in gameRepo.GetAll()
                   group x by x.Buyer.Games into g
                   select new KeyValuePair<List<Game>, string>
                   (g.Key, g.Max(t => t.GameName));
        }

        // gives back the type of a game
        public IEnumerable<KeyValuePair<string, IEnumerable<string>>> GetGameType()
        {
            return from x in gameRepo.GetAll()
                   group x by x.Type into g
                   select new KeyValuePair<string, IEnumerable<string>>
                   (g.Key, g.Select(t => t.Type).Where(t => t.Contains("TPS")));
        }
    }
}
