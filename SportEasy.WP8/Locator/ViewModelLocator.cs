using System.Collections.ObjectModel;
using Autofac.Extras.CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using SportEasy.Data;
using SportEasy.Model.Data;
using SportEasy.Model.Navigation;
using SportEasy.Model.Team;
using SportEasy.Model.User;
using SportEasy.ViewModel;
using SportEasy.ViewModel.Pages;
using SportEasy.WP8.Helper;
using SportEasy.WP8.Helper.Navigation;

namespace SportEasy.WP8.Locator
{
    public class ViewModelLocator
    {
        #region Properties

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public LoginViewModel Login
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }

        public MyTeamViewModel MyTeam
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MyTeamViewModel>();
            }
        }

        public MyEventViewModel MyEvent
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MyEventViewModel>();
            }
        }

        public IDataService DataService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IDataService>();
            }
        }

        #endregion

        #region Constructor

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IDataService, DesignDataService>();
            }
            else
            {
                SimpleIoc.Default.Register<IDataService, WebServiceDataService>();
            }

            SimpleIoc.Default.Register<NavigationService>();

            SimpleIoc.Default.Register<MyTeamViewModel>(true);
            SimpleIoc.Default.Register<MainViewModel>(true);
            SimpleIoc.Default.Register<MyEventViewModel>(true);
            SimpleIoc.Default.Register<LoginViewModel>();

            #region Navigate

            Main.Navigate += Main_Navigate;
            Login.Navigate += Login_Navigate;
            MyTeam.Navigate += MyTeam_Navigate;

            #endregion
        }

        #endregion

        #region Business

        #region Private

        void MyTeam_Navigate(NavigationEventHandler obj)
        {
            if (obj.PageViewModel == typeof(MyEventViewModel))
            {
                //StaticValues.Dispatcher.BeginInvoke(() =>
                //{

                Messenger.Default.Send<Event>((Event)obj.Parameter, "SelectedEvent");
                var navigation = new NavigationService();
                navigation.Navigate<MyEventViewModel>(null);
                //});
            }
        }

        void Main_Navigate(NavigationEventHandler obj)
        {
            if (obj.PageViewModel == typeof(MyTeamViewModel))
            {
                Messenger.Default.Send<Team>((Team)obj.Parameter, "SelectedTeam");
                var navigation = new NavigationService();
                navigation.Navigate<MyTeamViewModel>(null);
            }
        }

        void Login_Navigate(NavigationEventHandler obj)
        {
            if (obj.PageViewModel == typeof(MainViewModel))
            {
                StaticValues.Dispatcher.BeginInvoke(() =>
                {
                    StaticValues.CurrentUser = (User)obj.Parameter;

                    var navigation = new NavigationService();
                    navigation.Navigate<MainViewModel>(null);
                });
            }
        }

        #endregion

        #endregion
    }
}