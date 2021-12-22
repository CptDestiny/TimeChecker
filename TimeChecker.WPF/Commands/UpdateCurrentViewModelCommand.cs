using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TimeChecker.WPF.State.Navigator;
using TimeChecker.WPF.ViewModels;

namespace TimeChecker.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {

        public event EventHandler? CanExecuteChanged;

        private INavigator _navigator;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator;
        }


        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType) parameter;
                switch (viewType)
                {
                    case ViewType.Home:
                        _navigator.CurrentViewModel = new HomeViewModel();
                        break;
                    case ViewType.ElapsedTimesListing:
                        _navigator.CurrentViewModel = new ElapsedTimesListingView();
                        break;
                    case ViewType.Database:
                        _navigator.CurrentViewModel = new DBViewModel();
                        break;
                    case ViewType.Absences:
                        _navigator.CurrentViewModel = new AbsencesViewModel();
                        break;
                }
            }
        }

    }
}
