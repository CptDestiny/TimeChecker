using System.Windows.Input;
using TimeCheckerWPF5_0.Stores;

namespace TimeCheckerWPF5_0.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public NavigationViewModel NavigationViewModel { get; internal set; }

        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            RaisePropertyChanged("CurrentViewModel");
        }
    }
}
