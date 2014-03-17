using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight.Messaging;
using SportEasy.Model.Data;
using SportEasy.Model.Team;

namespace SportEasy.ViewModel.Pages
{
    public class MyEventViewModel : GlobalViewModel
    {
        #region Variable declaration

        private IDataService _dataService;
        private ObservableCollection<Participant> _participants;

        #endregion

        #region Properties

        public Event SelectedEvent { get; set; }

        public ObservableCollection<Participant> Participants
        {
            get { return _participants; }
            set
            {
                _participants = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Constructor

        public MyEventViewModel(IDataService dataService)
        {
            _dataService = dataService;

            if (IsInDesignMode)
            {
                SelectedEvent = _dataService.GetEvents(1).FirstOrDefault();

                Participants = new ObservableCollection<Participant>(_dataService.GetParticipant(1));
            }

            Messenger.Default.Register<Event>(this, "SelectedEvent", evt =>
            {
                if (evt != null)
                {
                    LoadMyEvent(evt);
                }
            });
        }

        #endregion

        #region Business

        #region Private

        private void LoadMyEvent(Event evt)
        {
            SelectedEvent = evt;

            Participants = new ObservableCollection<Participant>(_dataService.GetParticipant(evt.Id));
        }

        #endregion

        #endregion
    }
}