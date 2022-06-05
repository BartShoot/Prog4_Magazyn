using CommunityToolkit.Mvvm.ComponentModel;
using Magazyn.Commands;
using Magazyn.ViewModels;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Magazyn.State.Navigators
{
    public class Navigator : ObservableObject, INavigator
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel 
        { 
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this);

    }
}
