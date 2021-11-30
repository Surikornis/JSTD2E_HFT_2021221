using JSTD2E_HFT_2021221.Data;
using JSTD2E_HFT_2021221.Logic;
using JSTD2E_HFT_2021221.Repository;
using System;

namespace JSTD2E_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            ModelsDbContext mdb = new ModelsDbContext();

            BuyerLogic buyerLogic = new BuyerLogic(new BuyerRepository(mdb));
            DeveloperLogic developerLogic = new DeveloperLogic(new DeveloperTeamRepository(mdb));
            GameLogic gameLogic = new GameLogic(new GameRepository(mdb));

            //var q1 = buyerLogic.AvgAge();
            //var q2 = developerLogic.Latest();
            //var q3 = gameLogic.AveragePrice();
            //var q5 = gameLogic.List();

            //var q4 = gameLogic.Expensive();
        }
    }
}
