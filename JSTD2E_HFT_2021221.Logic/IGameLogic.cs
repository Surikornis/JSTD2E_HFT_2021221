using JSTD2E_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSTD2E_HFT_2021221.Logic
{
    interface IGameLogic
    {
        void Create(Game game);
        void Delete(string gameName);
        IEnumerable<Game> GetAll();
        Game Read(string gameName);
        void Update(Game game);
    }
}
