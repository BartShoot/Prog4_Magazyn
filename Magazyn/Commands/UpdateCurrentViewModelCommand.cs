using Magazyn.State.Navigators;
using Magazyn.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Magazyn.Commands
{
    internal class UpdateCurrentViewModelCommand : ICommand
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
            if(parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
                switch (viewType)
                {
                    case ViewType.Zawias:
                        _navigator.CurrentViewModel = new ZawiasyViewModel();
                        break;
                    case ViewType.Prowadnice:
                        _navigator.CurrentViewModel = new ProwadniceViewModel();
                        break;
                    case ViewType.Uchwyty:
                        _navigator.CurrentViewModel = new UchwytyViewModel();
                        break;
                    case ViewType.Akcesoria:
                        _navigator.CurrentViewModel = new AkcesoriaViewModel();
                        break;
                    case ViewType.Płyty:
                        _navigator.CurrentViewModel = new PlytyViewModel();
                        break;
                }
            }
        }
    }
}
