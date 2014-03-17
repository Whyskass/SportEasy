using System;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight.Messaging;
using SportEasy.Model.Data;
using SportEasy.Model.Navigation;
using SportEasy.Model.Team;
namespace SportEasy.ViewModel.Pages
{
    public class MyTeamViewModel : GlobalViewModel
    {
        #region Variable declaration

        private readonly IDataService _dataService;
        private Team _selectedTeam;
        private ObservableCollection<Event> _events;
        private ObservableCollection<Player> _players;
        private Event _selectedEvent;

        #endregion

        #region Properties

        public Team SelectedTeam
        {
            get { return _selectedTeam; }
            set
            {
                _selectedTeam = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Event> Events
        {
            get { return _events; }
            set
            {
                _events = value;
                RaisePropertyChanged();
            }
        }

        public Event SelectedEvent
        {
            get { return _selectedEvent; }
            set
            {
                _selectedEvent = value;

                if (_selectedEvent != null)
                {
                    OnNavigate(new NavigationEventHandler(typeof (MyEventViewModel), _selectedEvent));
                    _selectedEvent = null;
                }

                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Player> Players
        {
            get { return _players; }
            set
            {
                _players = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Constructor

        public MyTeamViewModel(IDataService dataService)
        {
            _dataService = dataService;

            if (IsInDesignMode)
            {
                SelectedTeam = dataService.GetTeams(1).FirstOrDefault();
                Events = new ObservableCollection<Event>(dataService.GetEvents(1));
                Players = new ObservableCollection<Player>(dataService.GetPlayers(1));
            }

            Messenger.Default.Register<Team>(this, "SelectedTeam", team =>
            {
                if (team != null)
                {
                    LoadMyTeam(team);
                }
            });
        }

        #endregion

        #region Business

        #region Private

        private void LoadMyTeam(Team myTeam)
        {
            SelectedTeam = myTeam;
            Events = new ObservableCollection<Event>(_dataService.GetEvents(SelectedTeam.Id));
            Players = new ObservableCollection<Player>(_dataService.GetPlayers(SelectedTeam.Id));
        }

        #endregion

        #endregion
    }
}