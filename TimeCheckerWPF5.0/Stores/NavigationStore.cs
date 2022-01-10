using System;
using System.Windows.Input;
using TimeCheckerWPF5_0.ViewModels;

namespace TimeCheckerWPF5_0.Stores
{

    public class NavigationStore
    {   
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public event Action CurrentViewModelChanged;

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

    }
}
