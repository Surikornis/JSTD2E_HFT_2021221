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
        BuyerLogic b1;
        DeveloperLogic d1;

        [SetUp]
        public void Init()
        {
            var mockGameRepository = new Mock<IGameRepository>();
            var mockBuyerRepository = new Mock<IBuyerRepository>();
            var mockDevRepository = new Mock<IDeveloperTeamRepository>();

            Buyer fakeBuyer = new Buyer();
            fakeBuyer.Name = "Sanyi";
            fakeBuyer.Age = 18;

            var devteams = new List<DeveloperTeam>()
            {
                new DeveloperTeam()
                {
                    DevTeam = "Activision",
                    DateofFoundation = 2010
                },

                new DeveloperTeam()
                {
                    DevTeam = "Blizzard",
                    DateofFoundation = 2000
                }

            }.AsQueryable();

            var games = new List<Game>()
            {
                new Game()
                {
                    GameName = "CoD",
                    Price = 2000,
                    Type = "FPS",
                    Buyer = fakeBuyer,
                    DevTeam = devteams.ToList()[0]
                },
                new Game()
                {
                    GameName = "Starcraft",
                    Price = 1000,
                    Type = "Moba",
                    Buyer = fakeBuyer,
                    DevTeam = devteams.ToList()[1]
                }

            }.AsQueryable();

            var buyers = new List<Buyer>()
            {
                new Buyer()
                {
                    Name = "Laci",
                    Age = 20
                },

                new Buyer()
                {
                    Name = "Saci",
                    Age = 10
                }

            }.AsQueryable();

            mockGameRepository.Setup((t) => t.GetAll()).Returns(games);
            g1 = new GameLogic(mockGameRepository.Object);

            mockBuyerRepository.Setup((t) => t.GetAll()).Returns(buyers);
            b1 = new BuyerLogic(mockBuyerRepository.Object);

            mockDevRepository.Setup((t) => t.GetAll()).Returns(devteams);
            d1 = new DeveloperLogic(mockDevRepository.Object);
        }

        [Test]
        public void MostExpensive()
        {
            //ACT
            var result = g1.Expensive();

            var expected = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("Activision", 2000),
                new KeyValuePair<string, double>("Blizzard", 1000)
            };

            //ASSERT
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Type()
        {
            //ACT
            var result = g1.Type();

            var expected = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Activision", "FPS"),
                new KeyValuePair<string, string>("Blizzard", "Moba")
            };

            //ASSERT
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Name()
        {
            var result = g1.Name();

            var expected = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Activision", "CoD"),
                new KeyValuePair<string, string>("Blizzard", "Starcraft")
            };

            //ASSERT
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Identification()
        {
            var result = g1.Identification();

            var expected = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>("Activision", 0),
                new KeyValuePair<string, int>("Blizzard", 0)
            };

            //ASSERT
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void Method()
        {
            var result = g1.Price();

            var expected = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("Activision", 2000),
                new KeyValuePair<string, double>("Blizzard", 1000)
            };

            //ASSERT
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void AvgPrice()
        {
            //ACT
            var result = g1.AveragePrice();

            //ASSERT
            Assert.That(result, Is.EqualTo(1500));
        }

        [Test]
        public void List()
        {
            var result = g1.List();

            var expected = new List<string>();
            expected.Add("CoD");

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void AvgAge()
        {
            var result = b1.AvgAge();

            Assert.That(result, Is.EqualTo(15));
        }

        [Test]
        public void Foundation()
        {
            var result = d1.Latest();

            Assert.That(result, Is.EqualTo(2010));
        }

        [Test]
        public void CreateBuyerException()
        {
            Buyer buyer = new Buyer()
            {
                Age = 12
            };

            Assert.That(() => b1.Create(buyer), Throws.Exception);
        }

        [Test]
        public void CreateDevTeam()
        {
            DeveloperTeam dt = new DeveloperTeam()
            {
                DateofFoundation = 2022
            };

            Assert.That(() => d1.Create(dt), Throws.Exception);
        }

        [Test]
        public void CreateGame()
        {
            Game game = new Game()
            {
                Id = 1,
                GameName = "CoD"
            };

            Assert.That(() => g1.Create(game), Throws.Nothing);
        }
        [Test]
        public void CreateGameException()
        {
            Game game = new Game()
            {
                Id = 2
            };

            Assert.That(() => g1.Create(game), Throws.Exception);
        }

        [Test]
        public void CreateBuyer()
        {
            Buyer buyer = new Buyer()
            {
                Age = 19
            };

            Assert.That(() => b1.Create(buyer), Throws.Nothing);
        }
    }
}
