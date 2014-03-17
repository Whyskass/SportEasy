using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using SportEasy.Model.Data;
using SportEasy.Model.Localization;
using SportEasy.Model.Navigation;
using SportEasy.Model.Team;
using SportEasy.ViewModel.Pages;

namespace SportEasy.ViewModel
{
    public class MainViewModel : GlobalViewModel
    {
        #region Variable declaration

        private readonly IDataService _dataService;
        private Team _selectedTeam;

        #endregion

        #region Properties

        public ObservableCollection<Team> Teams { get; set; }

        public Team SelectedTeam
        {
            get { return _selectedTeam; }
            set
            {
                _selectedTeam = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Command

        public ICommand AddCommand { get; set; }
        public ICommand SelectTeamCommand { get; set; }

        #endregion

        #region Constructor

        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            Teams = new ObservableCollection<Team>(_dataService.GetTeams(1));
            //Teams.Add(new Team()
            //{
            //    ImageUrl = "Assets/Team/add.png",
            //    Name = AppResources.string_Add
            //});

            #region Command initialization

            AddCommand = new RelayCommand(OnAddCommand);
            SelectTeamCommand = new RelayCommand(OnSelectTeamCommand);

            #endregion
        }

        #endregion

        #region Business

        #region Private

        private void OnSelectTeamCommand()
        {
            if (_selectedTeam != null)
            {
               // Messenger.Default.Send<Team>(_selectedTeam, "SelectedTeam");
                OnNavigate(new NavigationEventHandler(typeof(MyTeamViewModel), _selectedTeam));
                SelectedTeam = null;
            }
        }

        private void OnAddCommand()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #endregion
    }
}