using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TimeChecker.WPF.Commands;
using TimeChecker.WPF.ViewModels;

namespace TimeChecker.WPF.State.Navigator
{
    class Navigator : INavigator
    {
        public ViewModelBase CurrentViewModel { get; set; }

        public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this);
    }
}
