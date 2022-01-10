using TimeCheckerWPF5_0.Models;
using TimeCheckerWPF5_0.ViewModels;

namespace TimeCheckerWPF5_0.Stores
{
    public class NavigationCommandElapsedTimes : CommandBase
    {
        private NavigationStore navigationStore;

        //public NavigationCommandElapsedTimes()
        //{
        //}

        public NavigationCommandElapsedTimes(NavigationStore navigationStore)
        {
            this.navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
           this.navigationStore.CurrentViewModel = new ElapsedTimesViewModel();
        }

    }
}
