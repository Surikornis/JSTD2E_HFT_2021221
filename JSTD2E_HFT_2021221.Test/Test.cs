using JSTD2E_HFT_2021221.Logic;
using JSTD2E_HFT_2021221.Models;
using JSTD2E_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JSTD2E_HFT_2021221.Test
{
    [TestFixture]
    public class Test
    {
        GameLogic g1;

        [SetUp]
        public void Init()
        {
            var mockGameRepository = new Mock<IGameRepository>();

            Buyer fakeBuyer = new Buyer();
            fakeBuyer.Name = "Sanyi";
            fakeBuyer.Age = 18;

            var games = new List<Game>()
            {
                new Game()
                {
                    GameName = "LoL",
                    Price = 1000,
                    Type = "Moba",
                    Buyer = fakeBuyer,
                    DevTeamName = "Riot"
                },
                new Game()
                {
                    GameName = "CoD",
                    Price = 2000,
                    Type = "FPS",
                    Buyer = fakeBuyer,
                    DevTeamName = "Activision"
                }
            }.AsQueryable();

            mockGameRepository.Setup((t) => t.GetAll()).Returns(games);

            g1 = new GameLogic(mockGameRepository.Object);
        }

        [Test]
        public void Dunno()
        {
            var result = g1.Oldest();

            //Assert.That(result, Is.EqualTo());
        }
    }
}
