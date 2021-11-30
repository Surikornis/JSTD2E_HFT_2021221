using JSTD2E_HFT_2021221.Models;
using System;
using System.Collections.Generic;

namespace JSTD2E_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(12000);

            RestService rest = new RestService("http://localhost:62282");

            var cars = rest.Get<Buyer>("buyer");
            var devteams = rest.Get<DeveloperTeam>("devteam");
            var games = rest.Get<Game>("game");

            ;
        }
    }
}
