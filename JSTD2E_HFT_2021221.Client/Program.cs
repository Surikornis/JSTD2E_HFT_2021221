using JSTD2E_HFT_2021221.Models;
using System;
using System.Collections.Generic;

namespace JSTD2E_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            RestService rest = new RestService("http://localhost:62282");
            Console.WriteLine("The program will ask for a single key and an enter each time to navigate with\n\nWhat would you like to go for?\nCruds - C || Non-Cruds - N");
            string choice = Console.ReadLine().Trim().ToLower();

            if (choice == "c")
            {
                Crud(rest);
            }
            else if (choice == "n")
            {
                NonCrud(rest);
            }
            else if (choice != "c" && choice != "n")
            {
                Console.WriteLine("Improper input format! The program will exit.");
            }
        }

        public static void Crud(RestService rest)
        {
            Console.WriteLine("Your selected option: Cruds");
            string choice;
            string workwith;
            do
            {
                Console.Clear();
                Console.WriteLine("What would you like to work with?\nBuyer - B || DevTeam - D || Game - G");
                workwith = Console.ReadLine().Trim().ToLower();
                Console.WriteLine("Choose an action:\nC\t-\tCreate\nR\t-\tRead\nU\t-\tUpdate\nD\t-\tDelete\n");
                choice = Console.ReadLine().Trim().ToLower();

                if (choice == "c")
                {
                    Console.WriteLine("How many instances would you like to create?");
                    int objects = int.Parse(Console.ReadLine());

                    for (int i = 0; i < objects; i++)
                    {
                        if (workwith == "b")
                        {
                            BuyerCreate(rest);
                        }
                        else if (workwith == "d")
                        {
                            DevteamCreate(rest);
                        }
                        else if (workwith == "g")
                        {
                            GameCreate(rest);
                        }
                    }
                }

                else if (choice == "r")
                {
                    if (workwith == "b")
                    {
                        ReadBuyers(rest);
                    }
                    else if (workwith == "d")
                    {
                        ReadDevteams(rest);
                    }
                    else if (workwith == "g")
                    {
                        ReadGames(rest);
                    }
                }

                else if (choice == "u")
                {
                    if (workwith == "b")
                    {
                        UpdateBuyer(rest);
                    }

                    else if (workwith == "d")
                    {
                        UpdateDevteam(rest);
                    }

                    else if (workwith == "g")
                    {
                        UpdateGame(rest);
                    }
                }

                else if (choice == "d")
                {
                    Console.WriteLine("Which instance would you like to delete? (ID)");
                    int id = int.Parse(Console.ReadLine());

                    if (workwith == "b")
                    {
                        DeleteBuyer(rest, id);
                    }
                    else if (workwith == "d")
                    {

                        DeleteDevteam(rest, id);
                    }
                    else if (workwith == "g")
                    {
                        DeleteGame(rest, id);
                    }
                }

                Console.WriteLine("Would you like to exit?(y/n)");

                if (Console.ReadLine().Trim().ToLower() == "y")
                {
                    workwith = "x";
                }

            } while (workwith.ToLower() != "x");

            Console.WriteLine("Would you like to step into Non-Crud methods?(y/n)");

            if (Console.ReadLine().Trim().ToLower() == "y")
            {
                NonCrud(rest);
            }
            else
            {
                Console.WriteLine("The program has exited");
            }
        }

        public static void NonCrud(RestService rest)
        {
            string lookinto;
            Console.Clear();

            Console.WriteLine("Your selected option: Non-Cruds");
            do
            {
                Console.WriteLine(
                    "\nWhat would you like to look into?\nA - Average age of buyers\nL - Latest year a devteam's been founded\nS - List the games in the database" +
                    "\nE - Most expensive game published by developers\nP - Average price of the games\nT - Type of games made by devteams" +
                    "\nN - Each company's game with the longest name\nI - Gives back each devteam's ID\nG - Average price of games per devteams" +
                    "\nX - EXIT");

                lookinto = Console.ReadLine().Trim().ToLower();

                if (lookinto == "a")
                {
                    AvgAge(rest);
                }

                else if (lookinto == "l")
                {
                    Latest(rest);
                }

                else if (lookinto == "s")
                {
                    List(rest);
                }

                else if (lookinto == "e")
                {
                    Expensive(rest);
                }

                else if (lookinto == "p")
                {
                    AveragePrice(rest);
                }

                else if (lookinto == "t")
                {
                    Type(rest);
                }

                else if (lookinto == "n")
                {
                    Name(rest);
                }

                else if (lookinto == "i")
                {
                    Identification(rest);
                }

                else if (lookinto == "g")
                {
                    Price(rest);
                }

                Console.WriteLine("\nHit enter if you wish to restart");
                Console.ReadLine();
                Console.Clear();

            } while (lookinto.ToLower() != "x");

            Console.Clear();
            Console.WriteLine("Would you like to step into Crud methods?(y/n)");

            if (Console.ReadLine().Trim().ToLower() == "y")
            {
                Crud(rest);
            }
            else
            {
                Console.WriteLine("The program has exited");
            }
        }

        // Cruds //

        public static void BuyerCreate(RestService rest)
        {
            Console.WriteLine("Buyer's name?");
            string name = Console.ReadLine();
            Console.WriteLine("Age?");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Date of purchase?");
            int dop = int.Parse(Console.ReadLine());

            rest.Post<Buyer>(new Buyer()
            {
                Name = name,
                Age = age,
                DateofPurchase = dop
            }, "buyer");
        }
        public static void DevteamCreate(RestService rest)
        {
            Console.WriteLine("Devteam's name?");
            string name = Console.ReadLine();
            Console.WriteLine("Date of foundation?");
            int founded = int.Parse(Console.ReadLine());
            Console.WriteLine("HQ?");
            string hq = Console.ReadLine();

            rest.Post<DeveloperTeam>(new DeveloperTeam()
            {
                DevTeam = name,
                DateofFoundation = founded,
                HQ = hq
            }, "developerteam");
        }
        public static void GameCreate(RestService rest)
        {
            Console.WriteLine("Game's name?");
            string name = Console.ReadLine();
            Console.WriteLine("Game's type?");
            string type = Console.ReadLine();
            Console.WriteLine("Price?");
            int price = int.Parse(Console.ReadLine());
            Console.WriteLine("DevTeam's Id?");
            int devid = int.Parse(Console.ReadLine());
            Console.WriteLine("Buyer's Id??");
            int buyerid = int.Parse(Console.ReadLine());

            rest.Post<Game>(new Game()
            {
                GameName = name,
                Type = type,
                Price = price,
                DevTeamId = devid,
                BuyerId = buyerid
            }, "game");
        }

        public static void ReadBuyers(RestService rest)
        {
            var buyers = rest.Get<Buyer>("buyer");

            foreach (var item in buyers)
            {
                Console.WriteLine("\nId: " + item.Id + "\nName: " + item.Name + "\nAge: " + item.Age + "\nPurchased: " + item.DateofPurchase + "\n");
            }
        }
        public static void ReadDevteams(RestService rest)
        {
            var devteams = rest.Get<DeveloperTeam>("developerteam");

            foreach (var item in devteams)
            {
                Console.WriteLine("\nId: " + item.Id + "\nCompany name: " + item.DevTeam + "\nFounded : " + item.DateofFoundation + "\nHQ: " + item.HQ + "\n");
            }
        }
        public static void ReadGames(RestService rest)
        {
            var games = rest.Get<Game>("game");

            foreach (var item in games)
            {
                Console.WriteLine("\nId: " + item.Id + "\nGame name: " + item.GameName + "\nType : " + item.Type + "\nPrice: " + item.Price + "\nDeveloped by: "
                    + item.DevTeam.DevTeam + "\nBuyer's ID: " + item.BuyerId);
            }
        }

        public static void UpdateBuyer(RestService rest)
        {
            var buyers = rest.Get<Buyer>("buyer");

            Console.WriteLine("Which game do would you like to update?(ID)");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Updated buyer's name?");
            string name = Console.ReadLine();
            Console.WriteLine("Updated buyer's age?");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Updated date of purchase?");
            int dop = int.Parse(Console.ReadLine());

            Buyer updated = new Buyer()
            {
                Id = id,
                Name = name,
                Age = age,
                DateofPurchase = dop
            };

            rest.Put(updated, "/buyer");
        }
        public static void UpdateDevteam(RestService rest)
        {
            var devteams = rest.Get<DeveloperTeam>("developerteam");

            Console.WriteLine("Which game do would you like to update?(ID)");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Updated devteam's name?");
            string name = Console.ReadLine();
            Console.WriteLine("Updated devteam's date of foundation?");
            int dof = int.Parse(Console.ReadLine());
            Console.WriteLine("Updated HQ?");
            string hq = Console.ReadLine();

            DeveloperTeam updated = new DeveloperTeam()
            {
                Id = id,
                DevTeam = name,
                DateofFoundation = dof,
                HQ = hq
            };

            rest.Put(updated, "/developerteam");
        }
        public static void UpdateGame(RestService rest)
        {
            var games = rest.Get<Game>("game");

            Console.WriteLine("Which game do would you like to update?(ID)");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Updated game's name?");
            string name = Console.ReadLine();
            Console.WriteLine("Updated game's type?");
            string type = Console.ReadLine();
            Console.WriteLine("Updated price?");
            int price = int.Parse(Console.ReadLine());

            Game updated = new Game()
            {
                Id = id,
                GameName = name,
                Type = type,
                Price = price
            };

            rest.Put(updated, "/game");
        }

        public static void DeleteBuyer(RestService rest, int id)
        {
            rest.Delete(id, "/buyer");
        }
        public static void DeleteDevteam(RestService rest, int id)
        {
            rest.Delete(id, "/developerteam");
        }
        public static void DeleteGame(RestService rest, int id)
        {
            rest.Delete(id, "/game");
        }

        // Non-Cruds //

        public static void AvgAge(RestService rest)
        {
            double avgage = rest.GetSingle<double>("stat/avgage");
            Console.WriteLine(avgage);
        }
        public static void Latest(RestService rest)
        {
            int latest = rest.GetSingle<int>("stat/latest");
            Console.WriteLine(latest);
        }
        public static void List(RestService rest)
        {
            var list = rest.Get<string>("stat/list");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        public static void Expensive(RestService rest)
        {
            var expensive = rest.Get<KeyValuePair<string, double>>("stat/expensive");

            foreach (var item in expensive)
            {
                Console.WriteLine(item);
            }
        }
        public static void AveragePrice(RestService rest)
        {
            double avgprice = rest.GetSingle<double>("stat/averageprice");
            Console.WriteLine(avgprice);
        }
        public static void Type(RestService rest)
        {
            var types = rest.Get<KeyValuePair<string, string>>("stat/type");

            foreach (var item in types)
            {
                Console.WriteLine(item);
            }
        }
        public static void Name(RestService rest)
        {
            var names = rest.Get<KeyValuePair<string, string>>("stat/name");

            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
        }
        public static void Identification(RestService rest)
        {
            var identification = rest.Get<KeyValuePair<string, int>>("stat/identification");

            foreach (var item in identification)
            {
                Console.WriteLine(item);
            }
        }
        public static void Price(RestService rest)
        {
            var prices = rest.Get<KeyValuePair<string, double>>("stat/price");

            foreach (var item in prices)
            {
                Console.WriteLine(item);
            }
        }
    }
}
