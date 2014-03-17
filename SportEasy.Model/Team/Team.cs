using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SportEasy.Model.Annotations;

namespace SportEasy.Model.Team
{
    public class Team : INotifyPropertyChanged
    {
        #region Variable declaration

        private string _imageUrl;
        private string _name;
        private int _id;
        private int _playersCount;
        private int _games;
        private List<Player> _players;

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string ImageUrl
        {
            get { return _imageUrl; }
            set
            {
                _imageUrl = value;
                OnPropertyChanged();
            }
        }

        public int PlayersCount
        {
            get { return _playersCount; }
            set
            {
                _playersCount = value;
                OnPropertyChanged();
            }
        }

        public int Games
        {
            get { return _games; }
            set
            {
                _games = value;
                OnPropertyChanged();
            }
        }

        public List<Player> Players
        {
            get { return _players; }
            set
            {
                _players = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}