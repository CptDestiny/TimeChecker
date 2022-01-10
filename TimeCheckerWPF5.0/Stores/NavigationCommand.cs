using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCheckerWPF5_0.Models;
using TimeCheckerWPF5_0.ViewModels;

namespace TimeCheckerWPF5_0.Stores
{
    public class NavigationCommand : CommandBase
    {

        private readonly NavigationStore _navigationStore;

        public NavigationCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new ElapsedTimesViewModel();
        }
        
    }
}
