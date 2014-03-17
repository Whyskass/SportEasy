using System;

namespace SportEasy.Model.Navigation
{
    public class NavigationEventHandler
    {
        #region Properties

        public Type PageViewModel { get; set; }
        public object Parameter { get; set; }

        #endregion

        #region Constructor

        public NavigationEventHandler(Type pageViewModel, object parameter)
        {
            PageViewModel = pageViewModel;
            Parameter = parameter;
        }

        #endregion
    }
}