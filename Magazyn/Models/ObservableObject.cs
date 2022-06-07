using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections;

namespace Magazyn.Models
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void OnListChanged<T>(ObservableCollection<T> listaObiektow) where T : DomainObject
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(listaObiektow)));
        }
    }
}
