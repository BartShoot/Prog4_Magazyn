using Magazyn.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Magazyn.State.Navigators
{
    public enum ViewType
    {
        Zawias,
        Prowadnice,
        Uchwyty,
        Akcesoria,
        Płyty
    }
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
