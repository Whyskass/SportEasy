using System;
using System.Collections.Generic;
using System.Linq;
using SportEasy.Model.Data;
using SportEasy.Model.Team;
using SportEasy.Model.User;

namespace SportEasy.Data
{
    public class WebServiceDataService : IDataService
    {
        #region IDataService implementation

        public User LogIn(string email, string password)
        {
            return new User();
        }

        public User Register(string firstname, string lastname, string email, string password)
        {
            return new User();
        }

        public IEnumerable<Team> GetTeams(int userId)
        {
            return new List<Team>()
            {
                new Team()
                {
                    Id = 1,
                    Name = "WildPigs",
                    ImageUrl = "Assets/FakeImage/wildpigs.jpg",
                    PlayersCount = 42,
                    Games = 5
                },
                new Team()
                {
                    Id = 2,
                    Name = "BUC",
                    ImageUrl = "Assets/FakeImage/buc.jpg",
                    PlayersCount = 36,
                    Games = 8
                }
            };
        }

        public IEnumerable<Event> GetEvents(int teamId)
        {
            return new List<Event>()
            {
                new Event()
                {
                    Date = new DateTime(2013,11,12,11,00,00),
                    Match = "Wildpigs 8 - 16 Hesby",
                    Type = "Regionale 3",
                    RdvDate = new DateTime(2013,11,12,10,30,00),
                    Location = "BUC Rugby St Josse"
                },
                new Event()
                {
                    Date = new DateTime(2013,11,19,13,00,00),
                    Match = "Wildpigs 12 - 3 Mons",
                    Type = "Regionale 3"
                },
                new Event()
                {
                    Date = new DateTime(2013,11,23,19,30,00),
                    Match = "Liege 5 - 5 WildPigs",
                    Type = "Regionale 3"
                },
                new Event()
                {
                    Date = new DateTime(2013,11,26,11,00,00),
                    Match = "Wildpigs 15 - 12 Charleroi",
                    Type = "Coupe de Belgique"
                },
                new Event()
                {
                    Date = new DateTime(2013,12,4,20,00,00),
                    Match = "Wildpigs 13 - 5 Klet",
                    Type = "Regionale 3"
                },
                new Event()
                {
                    Date = new DateTime(2013,12,6,13,00,00),
                    Match = "Wildpigs 3 - 25 La Hulpe",
                    Type = "Regionale 3"
                },
                new Event()
                {
                    Date = new DateTime(2013,12,9,21,00,00),
                    Match = "Kituro 23 - 25 WildPigs",
                    Type = "Regionale 3"
                },
                new Event()
                {
                    Date = new DateTime(2013,12,13,15,00,00),
                    Match = "Hesby 8 - 20 Wildpigs",
                    Type = "Regionale 3"
                },
                new Event()
                {
                    Date = new DateTime(2013,12,20,18,00,00),
                    Match = "Wildpigs 44 - 3 Mons",
                    Type = "Coupe de Belgique"
                },
            };
        }

        public IEnumerable<Player> GetPlayers(int teamId)
        {
            return new List<Player>()
                    {
                        new Player()
                        {
                            FullName = "Alexandre De Mathelin",
                            Role = "Joueur",
                            Position = "Ailier"
                        },
                        new Player()
                        {
                            FullName = "Gaetan Timmermans",
                            Role = "Joueur",
                            Position = "Trois-quarts"
                        },
                        new Player()
                        {
                            FullName = "Bernard Plaes",
                            Role = "Joueur",
                            Position = "Pilier"
                        },
                        new Player()
                        {
                            FullName = "Brieuc De Viron",
                            Role = "Joueur",
                            Position = "Troisième ligne aile"
                        },
                        new Player()
                        {
                            FullName = "Duke Quarcoo",
                            Role = "Joueur",
                            Position = "Deuxième ligne"
                        },
                        new Player()
                        {
                            FullName = "François Delestrait",
                            Role = "Joueur",
                            Position = "Deuxième ligne"
                        },
                        new Player()
                        {
                            FullName = "Henri Houtart",
                            Role = "Joueur",
                            Position = "Ailier"
                        },
                        new Player()
                        {
                            FullName = "Louis André",
                            Role = "Joueur-coach",
                            Position = "Centre"
                        },
                        new Player()
                        {
                            FullName = "Pierre Kelecom",
                            Role = "Joueur",
                            Position = "Troisième ligne"
                        }
                    }.OrderBy(x => x.FullName);
        }

        public IEnumerable<Participant> GetParticipant(int eventId)
        {
            DesignDataService dataService = new DesignDataService();
            return dataService.GetParticipant(1);
        }

        #endregion
    }
}