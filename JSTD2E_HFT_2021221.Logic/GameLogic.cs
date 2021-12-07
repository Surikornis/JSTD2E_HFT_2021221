using JSTD2E_HFT_2021221.Models;
using JSTD2E_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSTD2E_HFT_2021221.Logic
{
    public class GameLogic : IGameLogic
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

        public void Delete(int id)
        {
            gameRepo.Delete(id);
        }

        public IEnumerable<Game> GetAll()
        {
            return gameRepo.GetAll();
        }

        public Game Read(int id)
        {
            return gameRepo.Read(id);
        }

        public void Update(Game game)
        {
            gameRepo.Update(game);
        }

        // gives the most expensive game specified devteam has made
        public IEnumerable<KeyValuePair<string, double>> Expensive()
        {
            return from x in gameRepo.GetAll()
                   group x by x.DevTeam.DevTeam into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Max(t => t.Price));
        }

        // gives back type of a game the specified company published
        public IEnumerable<KeyValuePair<string, string>> Type()
        {
            return from x in gameRepo.GetAll()
                   group x by x.DevTeam.DevTeam into g
                   select new KeyValuePair<string, string>
                   (g.Key, g.Min(t => t.Type));
        }

        // gives back the game of every company with the longest name
        public IEnumerable<KeyValuePair<string, string>> Name()
        {
            return from x in gameRepo.GetAll()
                   group x by x.DevTeam.DevTeam into g
                   select new KeyValuePair<string, string>
                   (g.Key, g.Max(t => t.GameName));
        }

        // gives back the identification number of each developer team
        public IEnumerable<KeyValuePair<string, int>> Identification()
        {
            return from x in gameRepo.GetAll()
                   group x by x.DevTeam.DevTeam into g
                   select new KeyValuePair<string, int>
                   (g.Key, g.Max(t => t.DevTeamId));
        }

        // gives back the average price of games made by devteams
        public IEnumerable<KeyValuePair<string, double>> Price()
        {
            return from x in gameRepo.GetAll()
                   group x by x.DevTeam.DevTeam into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Average(t => t.Price));
        }

        public List<string> List()
        {
            return gameRepo.GetAll().Where(t => t.Price > 1500).Select(t => t.GameName).ToList();
        }

        public double AveragePrice()
        {
            return gameRepo.GetAll().Average(t => t.Price);
        }
    }
}
