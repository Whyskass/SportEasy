﻿namespace SportEasy.Model.Navigation
{
    public interface INavigationService
    {
        /// <summary> 
        /// Gets a value indicating whether can go back. 
        /// </summary> 
        bool CanGoBack { get; }

        /// <summary> 
        /// The go back. 
        /// </summary> 
        void GoBack();

        /// <summary> 
        /// The navigate. 
        /// </summary> 
        /// <param name="parameter"> 
        /// The parameter. 
        /// </param> 
        /// <typeparam name="TDestinationViewModel"> 
        /// The destination view model. 
        /// </typeparam> 
        void Navigate<TDestinationViewModel>(object parameter = null); 
    }
}