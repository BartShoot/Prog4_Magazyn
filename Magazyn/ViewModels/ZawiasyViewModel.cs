using CommunityToolkit.Mvvm.Input;
using FastMember;
using Magazyn.Models;
using Magazyn.Services;
using Magazyn.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Magazyn.ViewModels
{
    public partial class ZawiasyViewModel : ViewModelBase
    {
        public Zawiasy _zawias = new Zawiasy();

        public GenericDataService<Zawiasy> _genericDataService = 
            new GenericDataService<Zawiasy>(new DbContextFactory());

        public ObservableCollection<Zawiasy> ListaZawiasow
        {
            get;
            set;
        }

        private string _firma;
        public string Firma
        {
            get => _firma;
            set
            {
                _firma = value;
                OnPropertyChanged(nameof(Firma));
            }
        }
        private string _model;
        public string Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged(nameof(Model));
            }
        }
        private decimal _cena;
        public decimal Cena
        {
            get => _cena;
            set
            {
                _cena = value;
                OnPropertyChanged(nameof(Cena));
            }
        }
        private int _ilosc = 1;
        public int Ilosc
        {
            get => _ilosc;
            set
            {
                _ilosc = value;
                OnPropertyChanged(nameof(Ilosc));
            }
        }
        private int _katOtwarcia = 90;
        public int KatOtwarcia
        {
            get => _katOtwarcia;
            set
            {
                _katOtwarcia = value;
                OnPropertyChanged(nameof(KatOtwarcia));
            }
        }
        private bool _hamulec;
        public bool Hamulec
        {
            get => _hamulec;
            set
            {
                _hamulec = value;
                OnPropertyChanged(nameof(Hamulec));
            }
        }
        private bool _sprezyna;
        public bool Sprezyna
        {
            get => _sprezyna;
            set
            {
                _sprezyna = value;
                OnPropertyChanged(nameof(Sprezyna));
            }
        }

        public ZawiasyViewModel()
        {
            AddZawiasCommand = new RelayCommand(AddZawias);
            OpenAddWindowCommand = new RelayCommand(OpenAddWindow);
            List<Zawiasy> result = Task.Run(() => GetAllZawiasAsync()).Result.ToList();
            ListaZawiasow = new ObservableCollection<Zawiasy>(result);
        }

        public ICommand AddZawiasCommand { get; }
        public async void AddZawias()
        {
            _zawias.Firma = Firma;
            _zawias.Model = Model;
            _zawias.Cena = Cena;
            _zawias.Ilosc = Ilosc;
            _zawias.Kat_Otwarcia = KatOtwarcia;
            _zawias.Hamulec = Hamulec;
            _zawias.Sprezyna = Sprezyna;
            await _genericDataService.Create(_zawias);
        }

        public ICommand OpenAddWindowCommand { get; }
        public void OpenAddWindow()
        {
            var window = new Window
            {
                Title = "Dodaj zawias",
                Content = new ZawiasyAdd()
            };
            window.Show();
        }

        public ICommand GetAllZawiasCommand { get; }
        public async Task<List<Zawiasy>> GetAllZawiasAsync()
        {
            ListaZawiasow = (ObservableCollection<Zawiasy>)await _genericDataService.GetAllAsync();
            return ListaZawiasow.ToList();
        }
    }
}
