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
            Menu(rest);
        }

        public static void Menu(RestService rest)
        {
            string crudchoice;
            string choice;
            string workwith;
            do
            {
                Console.WriteLine("What would you like to go for?\nCruds - C || Non-Cruds - N || Exit - X");
                crudchoice = Console.ReadLine().Trim().ToLower();
                if (crudchoice == "c")
                {
                    Console.Clear();
                    Console.WriteLine("What would you like to work with?\nBuyer - B || DevTeam - D || Game - G");
                    workwith = Console.ReadLine().Trim().ToLower();
                    Console.WriteLine("Choose one action:\nC\t-\tCreate\nR\t-\tRead\nU\t-\tUpdate\nD\t-\tDelete\n");
                    choice = Console.ReadLine().Trim().ToLower();

                    if (choice == "c")
                    {
                        Console.WriteLine("How many instances would you like to create?");
                        int objects = int.Parse(Console.ReadLine());

                        for (int i = 0; i < objects; i++)
                        {
                            if (workwith == "b")
                            {
                                Console.WriteLine("Buyer's name?");
                                string name = Console.ReadLine();
                                Console.WriteLine("Date of birth?");
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
                            else if (workwith == "d")
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
                            else if (workwith == "g")
                            {
                                Console.WriteLine("Game's name?");
                                string name = Console.ReadLine();
                                Console.WriteLine("Game's type?");
                                string type = Console.ReadLine();
                                Console.WriteLine("Price?");
                                int price = int.Parse(Console.ReadLine());

                                rest.Post<Game>(new Game()
                                {
                                    GameName = name,
                                    Type = type,
                                    Price = price
                                }, "game");
                            }
                        }
                    }

                    else if (choice == "r")
                    {
                        if (workwith == "b")
                        {
                            var buyers = rest.Get<Buyer>("buyer");

                            foreach (var item in buyers)
                            {
                                Console.WriteLine("\nId: " + item.Id + "\nName: " + item.Name + "\nAge: " + item.Age + "\nPurchased: " + item.DateofPurchase + "\n");
                            }
                        }
                        else if (workwith == "d")
                        {
                            var devteams = rest.Get<DeveloperTeam>("developerteam");

                            foreach (var item in devteams)
                            {
                                Console.WriteLine("\nId: " + item.Id + "\nCompany name: " + item.DevTeam + "\nFounded : " + item.DateofFoundation + "\nHQ: " + item.HQ + "\n");
                            }
                        }
                        else if (workwith == "g")
                        {
                            var games = rest.Get<Game>("game");

                            foreach (var item in games)
                            {
                                Console.WriteLine("\nId: " + item.Id + "\nGame name: " + item.GameName + "\nType : " + item.Type + "\nPrice: " + item.Price + "\nDeveloped by: "
                                    + item.DevTeam.DevTeam + "\nBuyer's ID: " + item.BuyerId);
                            }
                        }
                    }

                    else if (choice == "u")
                    {
                        if (workwith == "b")
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

                            buyers[id].Name = name;
                            buyers[id].Age = age;
                            buyers[id].DateofPurchase = dop;
                        }
                        else if (workwith == "d")
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

                            devteams[id].DevTeam = name;
                            devteams[id].DateofFoundation = dof;
                            devteams[id].HQ = hq;
                        }
                        else if (workwith == "g")
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

                            games[id].GameName = name;
                            games[id].Type = type;
                            games[id].Price = price;
                        }
                    }

                    else if (choice == "d")
                    {
                        Console.WriteLine("Which instance would you like to delete? (ID)");
                        int id = int.Parse(Console.ReadLine());

                        if (workwith == "b")
                        {
                            rest.Delete(id, "/buyer");
                        }
                        else if (workwith == "d")
                        {
                            rest.Delete(id, "/developerteam");
                        }
                        else if (workwith == "g")
                        {
                            rest.Delete(id, "/game");
                        }
                    }
                }
                else if (crudchoice == "n")
                {
                    Console.WriteLine("What would you like to look into?\nA - Average age of buyers\nL - Latest year a devteam's been founded\nS - List the games in the database"
                        + "\nE - Most expensive game published by developers\nP - Average price of the games");
                    string lookinto = Console.ReadLine().Trim().ToLower();

                    if (lookinto == "a")
                    {
                        double avgage = rest.GetSingle<double>("stat/avgage");
                        Console.WriteLine(avgage);
                    }
                    else if (lookinto == "l")
                    {
                        int latest = rest.GetSingle<int>("stat/latest");
                        Console.WriteLine(latest);
                    }
                    else if (lookinto == "s")
                    {
                        var list = rest.Get<string>("stat/list");

                        foreach (var item in list)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    else if (lookinto == "e")
                    {
                        var expensive = rest.Get<KeyValuePair<string, double>>("stat/expensive");

                        foreach (var item in expensive)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    else if (lookinto == "p")
                    {
                        double avgprice = rest.GetSingle<double>("stat/averageprice");
                        Console.WriteLine(avgprice);
                    }
                }

                if (crudchoice != "x")
                {
                    Console.WriteLine("\n\tHit enter if you want to restart");
                    Console.ReadLine();
                    Console.Clear();
                }

            } while (crudchoice.ToLower() != "x");

            Console.WriteLine("The program has exited");
        }
    }
}
