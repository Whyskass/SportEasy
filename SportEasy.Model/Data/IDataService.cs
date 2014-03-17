using System.Collections.Generic;
using SportEasy.Model.Team;

namespace SportEasy.Model.Data
{
    public interface IDataService
    {
        User.User LogIn(string email, string password);

        User.User Register(string firstname, string lastname, string email, string password);

        IEnumerable<Team.Team> GetTeams(int userId);

        IEnumerable<Event> GetEvents(int teamId);

        IEnumerable<Player> GetPlayers(int teamId);

        IEnumerable<Participant> GetParticipant(int eventId);
    }
}