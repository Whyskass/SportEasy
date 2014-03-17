using System;
using GalaSoft.MvvmLight;
using SportEasy.Model.Localization;
using SportEasy.Model.Navigation;

namespace SportEasy.ViewModel
{
    public class GlobalViewModel : ViewModelBase
    {
        #region Events

        #region Navigate

        public event Action<NavigationEventHandler> Navigate;

        protected virtual void OnNavigate(NavigationEventHandler obj)
        {
            Action<NavigationEventHandler> handler = Navigate;
            if (handler != null) handler(obj);
        }

        #endregion

        #endregion
    }
}