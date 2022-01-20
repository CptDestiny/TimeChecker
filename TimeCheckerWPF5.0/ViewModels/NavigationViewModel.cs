﻿using System.Windows.Input;
using TimeCheckerWPF5._0.Commands;
using TimeCheckerWPF5._0.Services;

namespace TimeCheckerWPF5._0.ViewModels
{
    public class NavigationViewModel: ViewModelBase
    {

        public ICommand NavigateLoginCommand { get; }
        public ICommand NavigateTimeCheckerCommand { get; }
        public ICommand NavigateElapsedTimeSpansCommand { get; }
        public ICommand NavigateExitApplicationCommand { get; }

        public NavigationViewModel(
            INavigationService loginNavigationService,
            INavigationService timeCheckerNavigationService,
            INavigationService elapsedTimesNavigationService
           )
        {
            NavigateLoginCommand = new NavigateCommand(loginNavigationService);
            NavigateTimeCheckerCommand = new NavigateCommand(timeCheckerNavigationService);
            NavigateElapsedTimeSpansCommand = new NavigateCommand(elapsedTimesNavigationService);
            NavigateExitApplicationCommand = new ExitApplicationCommand();
        }

    }
     
}
